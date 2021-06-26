using Bb.ComponentModel.Factories;
using Bb.Json.Jslt.Asts;
using Bb.Json.Jslt.Services;
using ICSharpCode.AvalonEdit;
using ICSharpCode.AvalonEdit.CodeCompletion;
using ICSharpCode.AvalonEdit.Document;
using ICSharpCode.AvalonEdit.Folding;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
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
            InitializeTextMarkerService();
            TemplateEditor.TextArea.TextEntering += textEditor_TextArea_TextEntering;
            TemplateEditor.TextArea.TextEntered += textEditor_TextArea_TextEntered;

            //// ensure all assemblies are loaded.
            //var type = typeof(Bb.Jslt.Services.Excels.Column);

            this._foldingStrategy = new BraceFoldingStrategy();

            _templateFoldingManager = UpdateTemplate(TemplateEditor);
            _targetFoldingManager = UpdateTemplate(TargetEditor);


            this._parameterFile = System.IO.Path.Combine(Environment.CurrentDirectory, "parameters");
            if (System.IO.File.Exists(this._parameterFile))
            {

                this._parameters = this._parameterFile
                    .LoadFile()
                    .Deserialize<Parameters>();

                if (System.IO.File.Exists(this._parameters.TemplateFile))
                {

                    this._path = new string[1];
                    if (File.Exists(this._parameters.TemplateFile))
                        _path[0] = new FileInfo(this._parameters.TemplateFile).Directory.FullName;

                    TemplateEditor.Load(this._parameters.TemplateFile);
                    this.LabelTemplateFile.Content = this._parameters.TemplateFile;
                    _templateUpdated = false;

                }

            }
            else
                this._parameters = new Parameters();

        }

        void InitializeTextMarkerService()
        {
            var textMarkerService = new TextMarkerService(TemplateEditor.Document);
            TemplateEditor.TextArea.TextView.BackgroundRenderers.Add(textMarkerService);
            TemplateEditor.TextArea.TextView.LineTransformers.Add(textMarkerService);
            IServiceContainer services = (IServiceContainer)TemplateEditor.Document.ServiceProvider.GetService(typeof(IServiceContainer));
            if (services != null)
                services.AddService(typeof(ITextMarkerService), textMarkerService);
            this.textMarkerService = textMarkerService;
        }

        private FoldingManager UpdateTemplate(TextEditor textEditor)
        {
            textEditor.TextArea.IndentationStrategy = new ICSharpCode.AvalonEdit.Indentation.CSharp.CSharpIndentationStrategy(textEditor.Options);
            textEditor.SyntaxHighlighting = ICSharpCode.AvalonEdit.Highlighting.HighlightingManager.Instance.GetDefinition("Json");
            textEditor.ShowLineNumbers = true;
            textEditor.Options.IndentationSize = 3;

            return FoldingManager.Install(textEditor.TextArea);

        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (_templateUpdated)
                SaveTemplate();

            base.OnClosing(e);

        }

        private void UpdateTemplate()
        {

            _template = null;
            Errors.Items.Clear();
            textMarkerService.RemoveAll(m => true);

            try
            {
                
                _template = TemplateEditor.Text.GetTransformProvider(DebugCheckBox.IsChecked.Value, this._parameters.TemplateFile, _path);

                foreach (var item in _template.Diagnostics)
                {

                    Errors.Items.Add(item.Message);

                    var index = item.StartIndex;
                    if (index > 0)
                        index--;

                    int lenght = 5;
                    var x = TemplateEditor.Document.TextLength - index;
                    if (x < lenght)
                        lenght = x;

                    ITextMarker marker = textMarkerService.Create(index, lenght);
                    marker.MarkerTypes = TextMarkerTypes.SquigglyUnderline;
                    marker.MarkerColor = Colors.Red;

                }

            }
            catch (ArgumentOutOfRangeException)
            {

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
                    var src = new Sources(SourceJson.GetFromText(""));
                    var result = _template.Transform(src);
                    var value = result.TokenResult.ToString();
                    TargetEditor.Text = value;
                    foreach (var item in result.Diagnostics)
                    {
                        
                        Errors.Items.Insert(0, item.Message);

                    }
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
        }

        private void TargetEditorTextChanged(object sender, EventArgs e)
        {
            UpdateFolding(_targetFoldingManager, TargetEditor);

        }

        private void UpdateFolding(FoldingManager foldingManager, TextEditor textEditor)
        {
            _foldingStrategy.UpdateFoldings(foldingManager, textEditor.Document);
        }

        private void BtnOpenTemplate_Click(object sender, RoutedEventArgs e)
        {

            var file = GetFileFromOpenFile(this._parameters.TemplateFile);
            if (!string.IsNullOrEmpty(file))
            {

                this._parameters.TemplateFile = file;
                this._path = new string[1];
                if (File.Exists(this._parameters.TemplateFile))
                    _path[0] = new FileInfo(this._parameters.TemplateFile).Directory.FullName;

                TemplateEditor.Load(file);
                SaveParameters();

            }

        }

        private void BtnSaveTemplate_Click(object sender, RoutedEventArgs e)
        {
            SaveTemplate();
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

                this._path = new string[1];
                if (File.Exists(this._parameters.TemplateFile))
                    _path[0] = new FileInfo(this._parameters.TemplateFile).Directory.FullName;

                UpdateTemplate();
                Update();

            }
        }

        private void SaveParameters()
        {
            this._parameterFile.WriteInFile(this._parameters.Serialize());
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

        void textEditor_TextArea_TextEntered(object sender, TextCompositionEventArgs e)
        {

            if (e.Text == ".")
            {

                var serviceProvider = Bb.Json.Jslt.Services.ServiceContainer.Common.GetServices();

                // Open code completion after the user has pressed dot:
                completionWindow = new CompletionWindow(TemplateEditor.TextArea);
                IList<ICompletionData> data = completionWindow.CompletionList.CompletionData;

                //data.Add(new MyCompletionData("Item1"));

                foreach (TransformJsonServiceProvider provider in serviceProvider)
                {
                    foreach (Factory factory in provider.GetItems())
                    {
                        var c = new MyCompletionData(factory.MethodInfos.Name, factory.MethodInfos.Content, string.IsNullOrEmpty(factory.MethodInfos.Description) ? factory.MethodInfos.Content : factory.MethodInfos.Description);
                        data.Add(c);
                    }
                }

                completionWindow.Show();
                completionWindow.Closed += delegate
                {
                    completionWindow = null;
                };
            }
        }

        void textEditor_TextArea_TextEntering(object sender, TextCompositionEventArgs e)
        {
            if (e.Text.Length > 0 && completionWindow != null)
            {
                if (!char.IsLetterOrDigit(e.Text[0]))
                {
                    // Whenever a non-letter is typed while the completion window is open,
                    // insert the currently selected element.
                    completionWindow.CompletionList.RequestInsertion(e);
                }
            }
            // Do not set e.Handled=true.
            // We still want to insert the character that was typed.
        }

        private void TemplateEditor_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F5)
            {
                UpdateTemplate();
                Update();
            }
        }

        private readonly BraceFoldingStrategy _foldingStrategy;
        private readonly FoldingManager _templateFoldingManager;
        private readonly FoldingManager _targetFoldingManager;
        private JsltTemplate _template;
        private string _parameterFile;
        private Parameters _parameters;
        private bool _templateUpdated;
        private string[] _path;
        private TextMarkerService textMarkerService;
        CompletionWindow completionWindow;

        private void TemplateEditor_Drop(object sender, DragEventArgs e)
        {

            var d = e.Data;
            var file = d.GetData(DataFormats.FileDrop) as string[];

            foreach (var item in file)
            {

                var _file = new FileInfo(item);

                if (_file.Exists)
                {

                    this._path = new string[1];
                    _path[0] = _file.Directory.FullName;

                    this._parameters = new Parameters()
                    {
                        TemplateFile = _file.FullName
                    };

                    TemplateEditor.Load(_file.FullName);
                    this.LabelTemplateFile.Content = _file.FullName;
                    _templateUpdated = false;
                    
                    break;

                }

            }
        }

        
    }


}
