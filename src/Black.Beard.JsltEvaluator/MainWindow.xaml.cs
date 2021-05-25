using Bb.Json.Jslt.Asts;
using Bb.Json.Jslt.Services;
using ICSharpCode.AvalonEdit;
using ICSharpCode.AvalonEdit.Document;
using ICSharpCode.AvalonEdit.Folding;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AppJsonEvaluator
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {

            InitializeComponent();
            this._foldingStrategy = new BraceFoldingStrategy();

            //var o = ICSharpCode.AvalonEdit.Highlighting.HighlightingManager.Instance.HighlightingDefinitions;


            _templateFoldingManager = UpdateTemplate(TemplateEditor);
            _sourceFoldingManager = UpdateTemplate(SourceEditor);
            _targetFoldingManager = UpdateTemplate(TargetEditor);


            this._parameterFile = System.IO.Path.Combine(Environment.CurrentDirectory, "parameters");
            if (System.IO.File.Exists(this._parameterFile))
            {
                this._parameters = this._parameterFile
                    .LoadFile()
                    .Deserialize<Parameters>();

                if (System.IO.File.Exists(this._parameters.TemplateFile))
                {
                    TemplateEditor.Load(this._parameters.TemplateFile);
                    this.LabelTemplateFile.Content = this._parameters.TemplateFile;
                    _templateUpdated = false;
                }

                if (System.IO.File.Exists(this._parameters.SourceTestFile))
                {
                    SourceEditor.Load(this._parameters.SourceTestFile);
                    this.LabelSourceTestFile.Content = this._parameters.SourceTestFile;
                    _sourceUpdated = false;
                }

            }
            else
                this._parameters = new Parameters();

        }

        private FoldingManager UpdateTemplate(TextEditor textEditor)
        {
            textEditor.TextArea.IndentationStrategy = new ICSharpCode.AvalonEdit.Indentation.CSharp.CSharpIndentationStrategy(textEditor.Options);
            textEditor.SyntaxHighlighting = ICSharpCode.AvalonEdit.Highlighting.HighlightingManager.Instance.GetDefinition("Json");
            textEditor.ShowLineNumbers = true;
            textEditor.Options.IndentationSize = 3;

            return FoldingManager.Install(textEditor.TextArea);

        }

        private void UpdateFolding(FoldingManager foldingManager, TextEditor textEditor)
        {
            _foldingStrategy.UpdateFoldings(foldingManager, textEditor.Document);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (_templateUpdated)
                SaveTemplate();

            if (_sourceUpdated)
                SaveSourceTest();

            base.OnClosing(e);

        }

        private void UpdateTemplate()
        {

            _template = null;
            Errors.Items.Clear();

            try
            {

                string[] _path = new string[2];

                if (File.Exists(this._parameters.TemplateFile))
                    _path[0] = new FileInfo(this._parameters.TemplateFile).Directory.FullName;

                if (File.Exists(this._parameters.SourceTestFile))
                    _path[1] = new FileInfo(this._parameters.SourceTestFile).Directory.FullName;

                _template = TemplateEditor.Text.GetTransformProvider(_path);

                foreach (var item in _template.Diagnostics)
                    Errors.Items.Add(item.Message);

            }
            catch (Exception e1)
            {
                Errors.Items.Insert(0, e1.Message);
            }

        }

        private void Update()
        {


            if (_template != null && _template.Diagnostics.Success)
            {

                Errors.Items.Clear();

                try
                {
                    var src = new Sources(SourceJson.GetFromText(SourceEditor.Text));
                    var result = _template.Transform(src);
                    var value = result.TokenResult.ToString();
                    TargetEditor.Text = value;
                }
                catch (Exception e2)
                {
                    Errors.Items.Insert(0, e2.Message);
                }

            }


        }

        private void TemplateEditorTextChanged(object sender, EventArgs e)
        {
            _templateUpdated = true;
            UpdateFolding(_templateFoldingManager, TemplateEditor);
            UpdateTemplate();
            Update();

        }

        private void SourceEditorTextChanged(object sender, EventArgs e)
        {
            _sourceUpdated = true;
            UpdateFolding(_sourceFoldingManager, SourceEditor);
            Update();
        }

        private void TargetEditorTextChanged(object sender, EventArgs e)
        {
            UpdateFolding(_targetFoldingManager, TargetEditor);

        }



        private void BtnOpenTemplate_Click(object sender, RoutedEventArgs e)
        {

            var file = GetFileFromOpenFile(this._parameters.TemplateFile);
            if (!string.IsNullOrEmpty(file))
            {
                TemplateEditor.Load(file);
                this._parameters.TemplateFile = file;
                SaveParameters();

            }

        }

        private void BtnSaveTemplate_Click(object sender, RoutedEventArgs e)
        {
            SaveTemplate();
        }

        private void BtnOpenSourceTest_Click(object sender, RoutedEventArgs e)
        {
            SaveSourceTest();
        }

        private void BtnSaveSourceTest_Click(object sender, RoutedEventArgs e)
        {

            if (string.IsNullOrEmpty(this._parameters.SourceTestFile))
                this._parameters.SourceTestFile = GetFileFromSaveFile("Save source test");

            if (!string.IsNullOrEmpty(this._parameters.SourceTestFile))
            {
                SaveParameters();
                TemplateEditor.Save(this._parameters.SourceTestFile);
            }

        }

        private void SaveTemplate()
        {
            if (string.IsNullOrEmpty(this._parameters.TemplateFile))
                this._parameters.TemplateFile = GetFileFromSaveFile("Save template");

            if (!string.IsNullOrEmpty(this._parameters.TemplateFile))
            {
                SaveParameters();
                TemplateEditor.Save(this._parameters.TemplateFile);
                _templateUpdated = false;
            }
        }

        private void SaveSourceTest()
        {
            var file = GetFileFromOpenFile(this._parameters.SourceTestFile);
            if (!string.IsNullOrEmpty(file))
            {
                SourceEditor.Load(file);
                this._parameters.SourceTestFile = file;
                SaveParameters();
                _sourceUpdated = false;
            }
        }

        private void SaveParameters()
        {
            this._parameterFile.WriteInFile(this._parameters.Serialize());

            this.LabelSourceTestFile.Content = this._parameters.SourceTestFile;
            this.LabelTemplateFile.Content = this._parameters.TemplateFile;

        }

        private string GetFileFromOpenFile(string file)
        {

            string initialFilename = string.Empty;
            string initialDirectory = string.Empty;

            if (!string.IsNullOrEmpty(file))
            {
                var initialFile = new System.IO.FileInfo(file);
                if (initialFile.Exists)
                    initialFilename = initialFile.FullName;

                if (initialFile.Directory.Exists)
                    initialDirectory = initialFile.Directory.FullName;

            }
            else
            {
                initialDirectory = Environment.CurrentDirectory;
            }

            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                FileName = initialFilename,
                InitialDirectory = initialDirectory,
                Filter = "json files (*.json)|*.json|javascript files (*.js)|*.js|Text files (*.txt)|*.txt|All files (*.*)|*.*",
            };

            if (openFileDialog.ShowDialog() == true)
                return openFileDialog.FileName;

            return string.Empty;

        }

        private string GetFileFromSaveFile(string title)
        {

            //string initialFilename = string.Empty;
            //string initialDirectory = string.Empty;

            //if (!string.IsNullOrEmpty(file))
            //{
            //    var initialFile = new System.IO.FileInfo(file);
            //    if (initialFile.Exists)
            //        initialFilename = initialFile.FullName;

            //    if (initialFile.Directory.Exists)
            //        initialDirectory = initialFile.Directory.FullName;

            //}

            SaveFileDialog saveFileDialog = new SaveFileDialog()
            {
                Title = title,
                FileName = "",          // initialFilename,
                InitialDirectory = "",  // initialDirectory,
                Filter = "json files (*.json)|*.json|javascript files (*.js)|*.js|Text files (*.txt)|*.txt|All files (*.*)|*.*",
            };

            if (saveFileDialog.ShowDialog() == true)
                return saveFileDialog.FileName;

            return string.Empty;

        }


        private readonly BraceFoldingStrategy _foldingStrategy;
        private readonly FoldingManager _templateFoldingManager;
        private readonly FoldingManager _sourceFoldingManager;
        private readonly FoldingManager _targetFoldingManager;
        private JsltTemplate _template;
        private string _parameterFile;
        private Parameters _parameters;
        private bool _templateUpdated;
        private bool _sourceUpdated;

        private void TemplateEditor_DragEnter(object sender, DragEventArgs e)
        {

            //var d = e.Data;
            //var file = d.GetData(DataFormats.FileDrop) as string[];
            //foreach (var item in file)
            //{
            //    var _file = new FileInfo(item);
            //    if (_file.Exists)
            //    {
            //        e.Effects
            //    }
            //}

        }

        private void TemplateEditor_Drop(object sender, DragEventArgs e)
        {

            var d = e.Data;
            var file = d.GetData(DataFormats.FileDrop) as string[];

            foreach (var item in file)
            {

                var _file = new FileInfo(item);

                if (_file.Exists)
                {
                    TemplateEditor.Load(_file.FullName);
                    this.LabelTemplateFile.Content = _file.FullName;
                    _templateUpdated = false;

                    break;

                }

            }
        }

        private void SourceEditor_Drop(object sender, DragEventArgs e)
        {

            var d = e.Data;
            var file = d.GetData(DataFormats.FileDrop) as string[];

            foreach (var item in file)
            {

                var _file = new FileInfo(item);

                if (_file.Exists)
                {
                    SourceEditor.Load(_file.FullName);
                    this.LabelSourceTestFile.Content = _file.FullName;
                    _sourceUpdated = false;

                    break;

                }

            }

        }

        private void TemplateEditor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.S && e.SystemKey == Key.LeftCtrl)
            {
                UpdateTemplate();
                Update();
            }
        }
    }


}
