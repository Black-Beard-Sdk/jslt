using Bb.ComponentModel.Factories;
using Bb.JsltEvaluator;
using Bb.Wizards;
using Bb.Jslt.Parser;
using Bb.Maj;
using Bb.Parsers.Intellisense;
using ICSharpCode.AvalonEdit;
using ICSharpCode.AvalonEdit.CodeCompletion;
using ICSharpCode.AvalonEdit.Document;
using ICSharpCode.AvalonEdit.Folding;
using Microsoft.Win32;
using Bb.Json.Linq;
using ScintillaNET;
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
using System.Windows.Input;
using System.Windows.Media;
using Bb.Wizards.Wpf;
using Bb.JsltEvaluator.AvalonEdit;
using System.Diagnostics;
using Bb;
using Bb.Expressions;
using Bb.Analysis.DiagTraces;
using Bb.Attributes;
using Bb.Jslt;
using Bb.Jslt.Services;
using Bb.Jslt.Visitors;

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

            var mo = 1048576;
            _max = mo * 50;

            this._parsers = new Parsers();
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            InitializeTextMarkerService();
            TemplateEditor.TextArea.TextEntering += textEditor_TextArea_TextEntering;
            this._foldingStrategy = new BraceFoldingStrategy();

            _templateFoldingManager = UpdateTemplate(TemplateEditor);
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
                    _templateIsClean = false;

                }
                else
                    this._parameters.TemplateFile = string.Empty;

            }
            else
                this._parameters = new Parameters();

            this._variableHelper = new VariableHelper(this._parameters);

            RowErrors.Height = new GridLength(70);
            InitializeCompletion();

            this._timerMajUpdateTemplate = new Timer(this.TimerProc2);
            _timerMajUpdateTemplate.Change(700, 800);

            this._timerMajLocalisation = new Timer(this.TimerProc3);
            this._timerMajLocalisation.Change(1000, 700);

        }

        private void TimerProc3(object state)
        {

            this.Dispatcher.BeginInvoke(() =>
            {

                int index = 0;
                int line = 0;

                index = TemplateEditor.CaretOffset;
                DocumentLine docLine = TemplateEditor.Document.GetLineByOffset(index);
                var location = TemplateEditor.Document.GetLocation(index);
                line = docLine.LineNumber;

                this.PositionIndex.Content = index;
                this.PositionLine.Content = location.Line;
                this.PositionColumn.Content = location.Column;

            });

        }

        private void InitializeCompletion()
        {

            var completionProvider = new CompletionDataProvider();

            completionProvider.Add(new CompletionDataFactory("jsonfunctionName")
                .SetAction
                (
                    (key, result) =>
                    {

                        foreach (var provider in Bb.Jslt.ServiceContainer.Instance.GetServices(FunctionKindEnum.FunctionStandard))
                            foreach (Factory factory in provider.GetItems())
                                result.Add(new CompletionData(factory.MethodInfos.Content, factory.MethodInfos.Name, string.IsNullOrEmpty(factory.MethodInfos.Description) ? factory.MethodInfos.Content : factory.MethodInfos.Description));

                        foreach (var provider in Bb.Jslt.ServiceContainer.Instance.GetServices(FunctionKindEnum.Output))
                            foreach (Factory factory in provider.GetItems())
                                result.Add(new CompletionData(factory.MethodInfos.Content, factory.MethodInfos.Name, string.IsNullOrEmpty(factory.MethodInfos.Description) ? factory.MethodInfos.Content : factory.MethodInfos.Description));

                    }
                ));

            completionProvider.Add(new CompletionDataFactory("jsonValueBoolean")
                .SetAction
                (
                    (key, result) =>
                    {
                        result.Add(new CompletionData(Tokens.Get("TRUE")));
                        result.Add(new CompletionData(Tokens.Get("FALSE")));
                    }
                ));


            completionProvider.Add(new CompletionDataFactory("STRING")
            .SetAction
            (
                (key, result) =>
                {
                    result.Add(new CompletionData(@"""""", @"""""", "string value"));
                }
            ));


            // 

            completionProvider.Add(new CompletionDataFactory("jsonValueNull")
                .SetAction
                (
                    (key, result) =>
                    {
                        result.Add(new CompletionData(Tokens.Get("NULL")));
                    }
                ));

            completionProvider.Add(new CompletionDataFactory("jsonType")
                .SetAction
                (
                    (key, result) =>
                    {
                        result.Add(Tokens.Get("URI").GetFromToken(t => "@" + t.Text, t => "@" + t.Text, t => string.Empty));
                        result.Add(Tokens.Get("TIME").GetFromToken(t => "@" + t.Text, t => "@" + t.Text, t => string.Empty));
                        result.Add(Tokens.Get("DATETIME").GetFromToken(t => "@" + t.Text, t => "@" + t.Text, t => string.Empty));
                        result.Add(Tokens.Get("STRING_").GetFromToken(t => "@" + t.Text, t => "@" + t.Text, t => string.Empty));
                        result.Add(Tokens.Get("GUID").GetFromToken(t => "@" + t.Text, t => "@" + t.Text, t => string.Empty));
                        result.Add(Tokens.Get("WHEN").GetFromToken(t => "@" + t.Text, t => "@" + t.Text, t => string.Empty));
                        result.Add(Tokens.Get("CASE").GetFromToken(t => "@" + t.Text, t => "@" + t.Text, t => string.Empty));
                        result.Add(Tokens.Get("DEFAULT").GetFromToken(t => "@" + t.Text, t => "@" + t.Text, t => string.Empty));
                        result.Add(Tokens.Get("INTEGER").GetFromToken(t => "@" + t.Text, t => "@" + t.Text, t => string.Empty));
                        result.Add(Tokens.Get("DECIMAL").GetFromToken(t => "@" + t.Text, t => "@" + t.Text, t => string.Empty));
                    }
                ));

            completionProvider.Add(new CompletionDataFactory("BRACE_LEFT", "BRACKET_LEFT", "NT", "PAREN_LEFT")
                .SetAction
                (
                    (key, result) =>
                    {
                        result.Add(new CompletionData(key.Token.Name.Replace("_", " "), key.Token.Text, string.Empty));
                    }
                ));


            // 

            this._completionProvider = completionProvider;

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

            if (_templateIsClean)
                SaveTemplate();

            base.OnClosing(e);

        }

        private void TemplateEditorTextChanged(object sender, EventArgs e)
        {

            if (!_templateIsRunning)
                _templateIsClean = false;

            UpdateFolding(_templateFoldingManager, TemplateEditor);

        }

        private void TimerProc2(object state)
        {

            if (!this._templateIsClean)
                lock (_lock)
                    if (!this._templateIsClean)
                    {

                        _templateIsClean = true;
                        _templateIsRunning = true;

                        this.Dispatcher.BeginInvoke(new Action(() =>
                        {
                            UpdateTemplate();
                            _templateIsRunning = false;

                        }));

                    }
        }

        private int UpdateTemplate()
        {
            int result = 0;
            _template = null;
            Errors.Items.Clear();
            textMarkerService.RemoveAll(m => true);
            progressBar.IsIndeterminate = true;
            progressBar.Refresh();

            try
            {

                var debug = DebugCheckBox.IsChecked.Value;
                var text = TemplateEditor.Text;
                var filename = this._parameters.TemplateFile;

                _template = text.GetTransformProvider(debug, filename, _path);

                if (_template != null)
                {
                    var colorize = new ColorizeFromTreeVisitor(textMarkerService, TemplateEditor) { Configuration = _template.Configuration };
                    colorize.Apply(_template.Tree);
                }

            }
            catch (ArgumentOutOfRangeException)
            {

            }
            catch (CompilationException e2)
            {
                foreach (var item in e2.AssemblyResult.Diagnostics)
                    if (item.Severity == "Error")
                        Errors.Items.Add(new DiagnosticReport() { Message = item.Message }.SetSeverity(SeverityEnum.Error));

                    else
                    {

                    }
            }
            catch (Exception e1)
            {
                Errors.Items.Add(new DiagnosticReport() { Message = e1.Message }.SetSeverity(SeverityEnum.Error));
            }
            finally
            {
                progressBar.IsIndeterminate = false;
                result = UpdateDiagnostic();
            }

            return result;

        }

        private int UpdateDiagnostic()
        {

            int errors = 0;

            if (_template != null)
            {

                var i = _template.Diagnostics;

                foreach (var item in _template.Diagnostics.Take(200))
                {

                    if (item.Severity == SeverityEnum.Error.ToString())
                        errors++;

                    Errors.Items.Add(item);

                    var index = item.Location != null ? (item.Location.Start as ILocationIndex)?.Index ?? 0 : 0;
                    if (index > 0)
                        index--;

                    int lenght = 5;
                    var x = TemplateEditor.Document.TextLength - index;
                    if (x < lenght)
                        lenght = x;

                    if (item.Severity == SeverityEnum.Error.ToString())
                    {
                        try
                        {
                            ITextMarker marker = textMarkerService.Create(index, lenght);
                            marker.MarkerTypes = TextMarkerTypes.SquigglyUnderline;
                            marker.MarkerColor = Colors.Red;
                        }
                        catch (Exception e1)
                        {
                            Errors.Items.Add(new DiagnosticReport() { Message = e1.Message }.SetSeverity(SeverityEnum.Error));
                        }
                    }


                }
            }

            return errors;

        }

        private void Run()
        {

            if (_template != null && _template.Diagnostics.Success)
            {

                progressBar.IsIndeterminate = true;
                progressBar.Refresh();
                Errors.Items.Clear();

                try
                {

                    var st = new Stopwatch();

                    st.Start();

                    var src = Sources.GetEmpty();
                    foreach (var item in _variableHelper.GetVariables())
                        src.Variables.Add(item.Key, item.Value);
                    src.Variables.Add("My value", new JValue(1));

                    var ctx = _template.GetContext(src);
                    StringBuilder sb = _template.TransformForOutput(ctx);

                    st.Stop();

                    string time = string.Empty;
                    string unity = string.Empty;
                    if (st.Elapsed.TotalSeconds > 60)
                    {
                        time = st.Elapsed.TotalMinutes.ToString();
                        unity = "minute";
                        if (st.Elapsed.TotalMinutes > 1)
                            unity += "s";
                    }
                    if (st.Elapsed.TotalMilliseconds > 10 && st.Elapsed.TotalSeconds < 60)
                    {
                        time = st.Elapsed.TotalSeconds.ToString();
                        unity = "second";
                        if (st.Elapsed.TotalSeconds > 1)
                            unity += "s";

                    }
                    else
                    {
                        time = st.Elapsed.TotalMilliseconds.ToString();
                        unity = "millisecond";
                        if (st.Elapsed.TotalMilliseconds > 1)
                            unity += "s";
                    }

                    _template.Diagnostics.AddInformation(this._template.Filename, Bb.Analysis.DiagTraces.TextLocation.Empty, time, $"runs in {time} {unity}");


                    var p2 = Path.Combine(this._template.Configuration.OutputPath, Path.GetFileNameWithoutExtension(this._template.Filename) + "_result.json");
                    if (File.Exists(p2))
                        File.Delete(p2);

                    p2.Save(sb);


                    if (sb.Length < _max)
                        this.TextArea.Text = sb.ToString();
                    else
                        this.TextArea.Text = sb.ToString().Substring(0, _max);

                    ctx.TokenResult = null;

                }
                catch (Exception e2)
                {
                    Errors.Items.Add(new DiagnosticReport() { Message = e2.Message }.SetSeverity(SeverityEnum.Error));
                }
                finally
                {
                    progressBar.IsIndeterminate = false;
                    UpdateDiagnostic();
                }


            }

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

        private void BtnOpenVariables_Click(object sender, RoutedEventArgs e)
        {

            if (this._variableHelper.OpenWindow())
                SaveParameters();

        }

        private void BtnRun_Click(object sender, RoutedEventArgs e)
        {
            var result = UpdateTemplate();
            if (result == 0)
                Run();
        }

        private void SaveTemplate()
        {

            if (string.IsNullOrEmpty(this._parameters.TemplateFile))
                this._parameters.TemplateFile = GetFileFromSaveFile("Save template");

            if (!string.IsNullOrEmpty(this._parameters.TemplateFile))
            {

                SaveParameters();
                TemplateEditor.Save(this._parameters.TemplateFile);
                _templateIsClean = false;

                this._path = new string[1];
                if (File.Exists(this._parameters.TemplateFile))
                    _path[0] = new FileInfo(this._parameters.TemplateFile).Directory.FullName;

                //UpdateTemplate();
                //Update();

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

        private void OpenCompletions()
        {

            try
            {

                // récupération des propositions de completions contextuelles à la position.
                var position = TemplateEditor.SelectionStart;
                var keys = this._parsers.GetIntellisense(position, new StringBuilder(TemplateEditor.Text), this._parameters.TemplateFile ?? string.Empty);
                if (keys.Count == 0)
                {

                }

                var completions = this._completionProvider.GetCompletions(keys);

                if (completions.Exceptions.Count > 0)
                    foreach (var item in completions.Exceptions)
                        Errors.Items.Add(new DiagnosticReport() { Message = item.Message, Text = item.ToString() }.SetSeverity(SeverityEnum.Error));

                // Open code completion && map from proposition
                completionWindow = new CompletionWindow(TemplateEditor.TextArea);
                IList<ICompletionData> data = completionWindow.CompletionList.CompletionData;
                foreach (CompletionData item in completions.OrderBy(c => c.Priority))
                    data.Add(new MyCompletionData(item));

                completionWindow.Show();
                var p = completionWindow.CompletionList.RenderSize;
                completionWindow.CompletionList.RenderSize = new Size(270, p.Height);

                completionWindow.Closed += delegate
                {
                    completionWindow = null;
                };

            }
            catch (Exception ex)
            {
                Errors.Items.Add(new DiagnosticReport() { Message = ex.Message, Text = ex.ToString() }.SetSeverity(SeverityEnum.Error));
            }

        }

        void textEditor_TextArea_TextEntering(object sender, TextCompositionEventArgs e)
        {
            if (e.Text.Length > 0 && completionWindow != null)
            {

                var c = e.Text[0];

                if (!char.IsLetterOrDigit(c) && c != '_')
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

            if (e.keyMatch(Key.Space, true))
                OpenCompletions();

            else if (e.keyMatch(Key.F5, true))
                SaveTemplate();

            else if (e.Key == Key.F5)
            {
                var result = UpdateTemplate();
                if (result == 0)
                    Run();
            }

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

                    this._path = new string[1];
                    _path[0] = _file.Directory.FullName;

                    this._parameters = new Parameters()
                    {
                        TemplateFile = _file.FullName
                    };

                    TemplateEditor.Load(_file.FullName);
                    this.LabelTemplateFile.Content = _file.FullName;
                    _templateIsClean = false;

                    break;

                }

            }
        }

        private void ErrorDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (Errors.SelectedValue != null)
            {
                if (Errors.SelectedValue is ScriptDiagnostic m)
                {
                    var o = m.Location.Start as LocationLineAndIndex;

                    if (o.Index != 0)
                    {
                        TemplateEditor.SelectionStart = o.Index;
                        TemplateEditor.SelectionLength = 1;
                        TemplateEditor.Focus();
                    }
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Create the MaskedTextBox control.
            this.TextArea = CreateEditor();
            // Assign the MaskedTextBox control as the host control's child.
            ControlBag.Child = TextArea;
        }

        #region Search

        internal void CloseSearch()
        {

            if (this._windowSearch != null)
            {
                this._lastSearch = this._windowSearch.TextSearch;
                this._windowSearch = null;
            }
        }

        private void OpenSearch()
        {

            if (!SearchIsOpen)
            {
                if (this._windowSearch == null)
                {
                    this._windowSearch = new SearchWindow();
                    this._windowSearch.Show();
                    this._windowSearch.TextArea = TextArea;
                    this._windowSearch.Parent = this;
                }

                if (!string.IsNullOrEmpty(this._lastSearch))
                    this._windowSearch.TextSearch = this._lastSearch;

                this._windowSearch.TakeFocus();
                SearchIsOpen = true;
            }
            else
            {


                SearchIsOpen = false;

                if (this._windowSearch != null)
                {
                    this._windowSearch.Close();
                }

            }

        }

        public void InvokeIfNeeded(Action action)
        {
            //if (this.InvokeRequired)
            //{
            //    this.BeginInvoke(action);
            //}
            //else
            //{
            //    action.Invoke();
            //}
        }

        bool SearchIsOpen = false;
        private string _lastSearch;
        private SearchWindow _windowSearch;
        private string _lastShownFolder;
        private CompletionDataProvider _completionProvider;
        private volatile object _lock = new object();

        #endregion Search

        #region Scintilla

        private Scintilla CreateEditor()
        {

            Scintilla textArea;

            // CREATE CONTROL
            textArea = new Scintilla()
            {
                // BASIC CONFIG
                Dock = System.Windows.Forms.DockStyle.Fill,

                // INITIAL VIEW CONFIG
                WrapMode = WrapMode.None,
                IndentationGuides = IndentView.LookBoth,

            };

            // textArea.TextChanged += (this.OnTextChanged);

            // STYLING
            InitColors(textArea);
            InitSyntaxColoring(textArea);

            // NUMBER MARGIN
            InitNumberMargin(textArea);

            // BOOKMARK MARGIN
            InitBookmarkMargin(textArea);

            // CODE FOLDING MARGIN
            InitCodeFolding(textArea);

            // DRAG DROP
            // InitDragDropFile(textArea);

            // DEFAULT FILE
            //LoadDataFromFile("../../MainForm.cs");

            // INIT HOTKEYS
            InitHotkeys(textArea);

            return textArea;

        }

        private void InitColors(Scintilla textArea)
        {
            //  IntToColor(0x114D9C)
            textArea.BackColor = System.Drawing.Color.White;
            textArea.SetSelectionBackColor(true, System.Drawing.Color.Gray);
        }

        public static System.Drawing.Color IntToColor(int rgb)
        {
            return System.Drawing.Color.FromArgb(255, (byte)(rgb >> 16), (byte)(rgb >> 8), (byte)rgb);
        }

        private void InitSyntaxColoring(Scintilla textArea)
        {

            // Configure the default style
            textArea.StyleResetDefault();
            textArea.Styles[ScintillaNET.Style.Default].Font = "Consolas";
            textArea.Styles[ScintillaNET.Style.Default].Size = 10;
            textArea.Styles[ScintillaNET.Style.Default].BackColor = System.Drawing.Color.White; // IntToColor(0x212121);
            textArea.Styles[ScintillaNET.Style.Default].ForeColor = System.Drawing.Color.Black; // IntToColor(0xFFFFFF);
            textArea.StyleClearAll();

            textArea.Styles[ScintillaNET.Style.Json.Default].ForeColor = System.Drawing.Color.Black;

            textArea.Styles[ScintillaNET.Style.Json.PropertyName].ForeColor = System.Drawing.Color.BlueViolet;

            textArea.Styles[ScintillaNET.Style.Json.EscapeSequence].ForeColor = System.Drawing.Color.Red;

            textArea.Styles[ScintillaNET.Style.Json.String].ForeColor = System.Drawing.Color.ForestGreen;
            textArea.Styles[ScintillaNET.Style.Json.Uri].ForeColor = System.Drawing.Color.Blue;
            textArea.Styles[ScintillaNET.Style.Json.Number].ForeColor = System.Drawing.Color.Black;
            textArea.Styles[ScintillaNET.Style.Json.Keyword].ForeColor = System.Drawing.Color.Blue;

            textArea.Styles[ScintillaNET.Style.Json.Operator].ForeColor = System.Drawing.Color.Black;
            textArea.Styles[ScintillaNET.Style.Json.CompactIRI].ForeColor = System.Drawing.Color.Black;
            textArea.Styles[ScintillaNET.Style.Json.LdKeyword].ForeColor = System.Drawing.Color.Black;
            textArea.Styles[ScintillaNET.Style.Json.StringEol].ForeColor = System.Drawing.Color.Black;

            textArea.Styles[ScintillaNET.Style.Json.BlockComment].ForeColor = System.Drawing.Color.SeaGreen;
            textArea.Styles[ScintillaNET.Style.Json.LineComment].ForeColor = System.Drawing.Color.SeaGreen;

            textArea.Styles[ScintillaNET.Style.Json.Error].ForeColor = System.Drawing.Color.Red;

            textArea.Lexer = Lexer.Json;

            //textArea.SetKeywords(0, "class extends implements import interface new case do while else if for in switch throw get set function var try catch finally while with default break continue delete return each const namespace package include use is as instanceof typeof author copy default deprecated eventType example exampleText exception haxe inheritDoc internal link mtasc mxmlc param private return see serial serialData serialField since throws usage version langversion playerversion productversion dynamic private public partial static intrinsic internal native override protected AS3 final super this arguments null Infinity NaN undefined true false abstract as base bool break by byte case catch char checked class const continue decimal default delegate do double descending explicit event extern else enum false finally fixed float for foreach from goto group if implicit in int interface internal into is lock long new null namespace object operator out override orderby params private protected public readonly ref return switch struct sbyte sealed short sizeof stackalloc static string select this throw true try typeof uint ulong unchecked unsafe ushort using var virtual volatile void while where yield");
            //textArea.SetKeywords(1, "void Null ArgumentError arguments Array Boolean Class Date DefinitionError Error EvalError Function int Math Namespace Number Object RangeError ReferenceError RegExp SecurityError String SyntaxError TypeError uint XML XMLList Boolean Byte Char DateTime Decimal Double Int16 Int32 Int64 IntPtr SByte Single UInt16 UInt32 UInt64 UIntPtr Void Path File System Windows Forms ScintillaNET");

        }

        private void InitNumberMargin(Scintilla textArea)
        {

            textArea.Styles[ScintillaNET.Style.LineNumber].BackColor = System.Drawing.Color.LightGray;  // IntToColor(BACK_COLOR);
            textArea.Styles[ScintillaNET.Style.LineNumber].ForeColor = System.Drawing.Color.Black;      // IntToColor(FORE_COLOR);
            textArea.Styles[ScintillaNET.Style.IndentGuide].ForeColor = System.Drawing.Color.Red;       // IntToColor(FORE_COLOR);
            textArea.Styles[ScintillaNET.Style.IndentGuide].BackColor = System.Drawing.Color.LightGray; // IntToColor(BACK_COLOR);

            var nums = textArea.Margins[NUMBER_MARGIN];
            nums.Width = 30;
            nums.Type = MarginType.Number;
            nums.Sensitive = true;
            nums.Mask = 0;

            textArea.MarginClick += TextArea_MarginClick;

        }

        private void InitBookmarkMargin(Scintilla textArea)
        {

            //TextArea.SetFoldMarginColor(true, IntToColor(BACK_COLOR));

            var margin = textArea.Margins[BOOKMARK_MARGIN];
            margin.Width = 20;
            margin.Sensitive = true;
            margin.Type = MarginType.Symbol;
            margin.Mask = (1 << BOOKMARK_MARKER);
            //margin.Cursor = MarginCursor.Arrow;

            var marker = textArea.Markers[BOOKMARK_MARKER];
            marker.Symbol = MarkerSymbol.Circle;
            marker.SetBackColor(IntToColor(0xFF003B));
            marker.SetForeColor(IntToColor(0x000000));
            marker.SetAlpha(100);

        }

        private void InitCodeFolding(Scintilla textArea)
        {

            textArea.SetFoldMarginColor(true, System.Drawing.Color.White);  //  IntToColor(BACK_COLOR)
            textArea.SetFoldMarginHighlightColor(true, IntToColor(BACK_COLOR));

            // Enable code folding
            textArea.SetProperty("fold", "1");
            textArea.SetProperty("fold.compact", "1");

            // Configure a margin to display folding symbols
            textArea.Margins[FOLDING_MARGIN].Type = MarginType.Symbol;
            textArea.Margins[FOLDING_MARGIN].Mask = Marker.MaskFolders;
            textArea.Margins[FOLDING_MARGIN].Sensitive = true;
            textArea.Margins[FOLDING_MARGIN].Width = 20;

            // Set colors for all folding markers
            for (int i = 25; i <= 31; i++)
            {
                textArea.Markers[i].SetForeColor(IntToColor(BACK_COLOR)); // styles for [+] and [-]
                textArea.Markers[i].SetBackColor(IntToColor(FORE_COLOR)); // styles for [+] and [-]
            }

            // Configure folding markers with respective symbols
            textArea.Markers[Marker.Folder].Symbol = CODEFOLDING_CIRCULAR ? MarkerSymbol.CirclePlus : MarkerSymbol.BoxPlus;
            textArea.Markers[Marker.FolderOpen].Symbol = CODEFOLDING_CIRCULAR ? MarkerSymbol.CircleMinus : MarkerSymbol.BoxMinus;
            textArea.Markers[Marker.FolderEnd].Symbol = CODEFOLDING_CIRCULAR ? MarkerSymbol.CirclePlusConnected : MarkerSymbol.BoxPlusConnected;
            textArea.Markers[Marker.FolderMidTail].Symbol = MarkerSymbol.TCorner;
            textArea.Markers[Marker.FolderOpenMid].Symbol = CODEFOLDING_CIRCULAR ? MarkerSymbol.CircleMinusConnected : MarkerSymbol.BoxMinusConnected;
            textArea.Markers[Marker.FolderSub].Symbol = MarkerSymbol.VLine;
            textArea.Markers[Marker.FolderTail].Symbol = MarkerSymbol.LCorner;

            // Enable automatic folding
            textArea.AutomaticFold = (AutomaticFold.Show | AutomaticFold.Click | AutomaticFold.Change);

        }

        private void InitHotkeys(Scintilla TextArea)
        {

            // remove conflicting hotkeys from scintilla
            //TextArea.InterceptKey(OpenSearch, System.Windows.Forms.Keys.F, true);
            //HotKeyManager.AddHotKey(this, CloseSearch, Keys.Escape);

            TextArea.ClearCmdKey(System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F);

        }

        /// <summary>
        /// set this true to show circular buttons for code folding (the [+] and [-] buttons on the margin)
        /// </summary>
        private const bool CODEFOLDING_CIRCULAR = true;

        //private void OnTextChanged(object sender, EventArgs e)
        //{

        //}

        private void TextArea_MarginClick(object sender, MarginClickEventArgs e)
        {
            Scintilla TextArea = sender as Scintilla;


            if (e.Margin == BOOKMARK_MARGIN)
            {
                // Do we have a marker for this line?
                const uint mask = (1 << BOOKMARK_MARKER);
                var line = TextArea.Lines[TextArea.LineFromPosition(e.Position)];
                if ((line.MarkerGet() & mask) > 0)
                {
                    // Remove existing bookmark
                    line.MarkerDelete(BOOKMARK_MARKER);
                }
                else
                {
                    // Add bookmark
                    line.MarkerAdd(BOOKMARK_MARKER);
                }
            }
        }

        /// <summary>
        /// the background color of the text area
        /// </summary>
        private const int BACK_COLOR = 0x2A211C;

        /// <summary>
        /// default text color of the text area
        /// </summary>
        private const int FORE_COLOR = 0xB7B7B7;

        /// <summary>
        /// change this to whatever margin you want the bookmarks/breakpoints to show in
        /// </summary>
        private const int BOOKMARK_MARGIN = 2;
        private const int BOOKMARK_MARKER = 2;

        /// <summary>
        /// change this to whatever margin you want the line numbers to show in
        /// </summary>
        private const int NUMBER_MARGIN = 1;

        /// <summary>
        /// change this to whatever margin you want the code folding tree (+/-) to show in
        /// </summary>
        private const int FOLDING_MARGIN = 3;

        private Scintilla TextArea { get; set; }

        #endregion Scintilla

        private async void ButtonGenerateCmdLine(object sender, RoutedEventArgs e)
        {

            IEnumerable<FileInfo> files = null;
            if (_template != null)
                files = ResolveDependentFilesVisitor.Visit(_template.Tree, _template.Configuration);

            string scriptName = "myScript";
            if (!string.IsNullOrEmpty(this.LabelTemplateFile.Content.ToString()))
                scriptName = Path.GetFileName(this.LabelTemplateFile.Content.ToString());


            VariableWizard variableTemplateName = null;
            VariableWizard variableFolderCmd = null;

            var model = new WizardModel()

                .SetTitle("Create Command line")

                .Add("templateName", (t) =>
                {

                    t.HasDescription("Please give me the name of the script")
                     .InitializeUI(c =>
                     {
                         c.InitializeVariable("templateName", i => i.IsRequired(), scriptName, out VariableWizard variableTemplateName)
                          .AppendText(variableTemplateName, string.Empty)
                         ;
                     });

                })

                .Add("folderCmdTab", (t) =>
                {
                    t.HasDescription("Please select a folder to store the command line")
                    .InitializeUI((c) =>
                    {
                        c.InitializeVariable("folderCmd", i => i.IsRequired(), _lastShownFolder, out variableFolderCmd)
                         .AppendFolderSelector(variableFolderCmd, null, null, true)
                        ;

                    });

                })

            .Execute(async (model) =>
            {

                var folderCmd = variableFolderCmd.Value.ToString();

                if (!Directory.Exists(folderCmd))
                    Directory.CreateDirectory(folderCmd);

                var templateName = Path.GetFileNameWithoutExtension(variableTemplateName.Value.ToString()) + ".json";
                string folderCli = "cli";

                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"{folderCli}\\json.exe template execute \"{templateName}\" --out \"output.json\"");

                var file = Path.Combine(folderCmd, "run.bat");
                if (File.Exists(file))
                    File.Delete(file);
                Bb.ContentHelperFiles.Save(file, sb.ToString());


                if (files != null)
                    foreach (var dependancyFile in files)
                    {
                        var targetFile = Path.Combine(folderCmd, dependancyFile.Name);
                        dependancyFile.CopyTo(targetFile);
                    }

                file = Path.Combine(folderCmd, templateName);
                if (File.Exists(file))
                    File.Delete(file);
                Bb.ContentHelperFiles.Save(file, TemplateEditor.Text.ToString());

                var targetFolder = Path.Combine(folderCmd, folderCli);
                if (!Directory.Exists(targetFolder))
                    Directory.CreateDirectory(targetFolder);

                var resultDownload = await DownloadLastversion(targetFolder, "cli.zip", false);

            });

            ;


            var wizard = new WizardWindow(model);

            wizard.Show();

            //    var targetFolder = new DirectoryInfo(Path.Combine(folderDialog.SelectedPath, folderCli));
            //    progressBar.IsIndeterminate = true;
            //    progressBar.Refresh();
            //    this.Refresh();
            //    var resultDownload = await DownloadLastversion(targetFolder.FullName, "cli.zip");
            //    progressBar.IsIndeterminate = false;
            //}


        }

        private async Task<bool> DownloadLastversion(string targetFolder, string packageName, bool deleteDownloadToEnd)
        {

            var githubMaj = new GitHubVersionHelper(githubRepository);

            var lastVersion = await githubMaj.ResolveLastVersion();
            var versions = await githubMaj.GetUrls(lastVersion);

            var cli = versions.First(c => c.Name == packageName);

            var result = await githubMaj.Download(cli, targetFolder, deleteDownloadToEnd);

            return result == 0;

        }

        private const string githubRepository = "Black-Beard-Sdk/jslt";

        private void WindowSizeChanged(object sender, SizeChangedEventArgs e)
        {
            //TemplateEditor.HorizontalScrollBarVisibility =  System.Windows.Controls.ScrollBarVisibility.Visible;

        }




        private readonly BraceFoldingStrategy _foldingStrategy;
        private readonly FoldingManager _templateFoldingManager;
        private VariableHelper _variableHelper;

        public int _max { get; }

        private readonly Parsers _parsers;
        private Timer _timerMajUpdateTemplate;
        private readonly Timer _timerMajLocalisation;
        private JsltTemplate _template;
        private string _parameterFile;
        private Parameters _parameters;
        private bool _templateIsClean;
        private bool _templateIsRunning;
        private string[] _path;
        private TextMarkerService textMarkerService;
        CompletionWindow completionWindow;

    }


    [System.Diagnostics.DebuggerDisplay("[{Severity}] {Message}")]
    public class DiagnosticReport
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="DiagnosticReport"/> class.
        /// </summary>
        /// <param name="locations">The locations.</param>
        public DiagnosticReport(params DiagnosticLocation[] locations) : this()
        {
            Locations.AddRange(locations);
        }

        public DiagnosticReport()
        {
            Locations = new List<DiagnosticLocation>();
        }

        public string Filename => Location?.Filename;

        public int StartIndex => Location?.StartIndex ?? 0;

        public int StartColumn => Location?.StartColumn ?? 0;

        public int StartLine => Location?.StartLine ?? 0;


        public DiagnosticLocation Location => Locations.FirstOrDefault();

        public List<DiagnosticLocation> Locations { get; set; }


        public string Text { get; set; }

        public string Message { get; set; }

        public string Severity { get; set; }

        public int SeverityLevel { get; set; }

        public bool IsSeverityAsError { get; internal set; }


        // public string Location => $"({StartLine}, {StartColumn})";

        public override string ToString()
        {
            return Message.ToString();
        }

        public DiagnosticReport SetSeverity(SeverityEnum severity)
        {
            this.Severity = severity.ToString();
            this.SeverityLevel = (int)severity;
            this.IsSeverityAsError = severity == SeverityEnum.Error;
            return this;
        }

    }


    public class DiagnosticLocation
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="DiagnosticLocation"/> class.
        /// </summary>
        public DiagnosticLocation()
        {

        }

        public DiagnosticLocation(string filename)
        {
            this.Filename = filename;
        }

        public DiagnosticLocation(string filename, int startIndex, int startline = -1, int startColumn = -1) : this(filename)
        {
            this.StartIndex = startIndex;
            this.StartLine = startline;
            this.StartColumn = startColumn;
        }

        public DiagnosticLocation(Bb.Analysis.DiagTraces.TextLocation location) : this(location.Filename)
        {

            var start = location.Start as LocationLineAndIndex;
            var stop = location.Start as LocationLineAndIndex;

            StartLine = start.Line;
            StartIndex = start.Index;
            StartColumn = start.Column;

            EndLine = start.Line;
            EndIndex = start.Index;
            EndColumn = start.Column;

        }


        public string Filename { get; internal set; }


        public int StartIndex { get; internal set; }
        public int StartColumn { get; internal set; }
        public int StartLine { get; internal set; }


        public int EndIndex { get; internal set; }
        public int EndColumn { get; internal set; }
        public int EndLine { get; internal set; }


        public override string ToString()
        {
            var file = this.Filename ?? string.Empty;
            return $"{file} from (line {this.StartLine}, column {this.StartColumn}) to (line {this.EndLine}, column {this.EndColumn})";
        }

    }

}
