using Bb.ComponentModel.Factories;
using Bb.JsltEvaluator;
using Bb.Json.Jslt.Parser;
using Bb.Json.Jslt.Services;
using ICSharpCode.AvalonEdit;
using ICSharpCode.AvalonEdit.CodeCompletion;
using ICSharpCode.AvalonEdit.Folding;
using Microsoft.Win32;
using Newtonsoft.Json.Linq;
using ScintillaNET;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

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
                    _templateUpdated = false;

                }

            }
            else
                this._parameters = new Parameters();

            RowErrors.Height = new GridLength(70);
                               
        }

        //public static bool keyMatch(KeyEventArg.TYos e, Key key, bool ctrl = false, bool shift = false, bool alt = false)
        //{
        //    bool keyIsOk = e.Key == key;
        //    bool CtrlIsOk = ctrl == ((e.KeyboardDevice.Modifiers & ModifierKeys.Control) == ModifierKeys.Control);
        //    bool shiftIsOk = shift == ((e.KeyboardDevice.Modifiers & ModifierKeys.Shift) == ModifierKeys.Shift);
        //    bool altIsOk = alt == ((e.KeyboardDevice.Modifiers & ModifierKeys.Alt) == ModifierKeys.Alt);
        //    return keyIsOk && CtrlIsOk && shiftIsOk && altIsOk;
        //}

        void InitializeTextMarkerService()
        {

            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

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

                    Errors.Items.Add(item);

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
                Errors.Items.Add(new ErrorModel() { Severity = SeverityEnum.Error, Message = e1.Message });
            }

        }

        private void Update()
        {

            if (_template != null && _template.Diagnostics.Success)
            {

                Errors.Items.Clear();

                try
                {
                    var src = new Sources(SourceJson.GetFromText(String.Empty));
                    RuntimeContext result = _template.Transform(src);

                    var resultTokens = result.TokenResult;

                    if (_template.RuleOutput != null)
                    {

                        if (!string.IsNullOrEmpty(_template.RuleOutput.Filter))
                        {
                            var selects = resultTokens.SelectTokens(_template.RuleOutput.Filter).ToList();
                            if (selects.Count == 1)
                                resultTokens = selects[0];

                            else if (selects.Count > 1)
                                resultTokens = new JArray(selects);

                            else
                            {
                                resultTokens = JValue.CreateNull();
                            }

                        }

                        if (_template.RuleOutput.Rule != null)
                        {

                            result.TokenResult = resultTokens;

                            var sb = _template.RuleOutput.Rule(result, null);
                            this.TextArea.Text = sb.ToString();
                        }
                        else
                            this.TextArea.Text = resultTokens.ToString();

                    }
                    else
                        this.TextArea.Text = result.TokenResult.ToString();


                    foreach (var item in result.Diagnostics)
                        Errors.Items.Add(item);
                
                }
                catch (Exception e2)
                {
                    Errors.Items.Add(new ErrorModel() { Severity = SeverityEnum.Error, Message = e2.Message });
                }

            }


        }

        private void TemplateEditorTextChanged(object sender, EventArgs e)
        {
            _templateUpdated = true;
            UpdateFolding(_templateFoldingManager, TemplateEditor);
            UpdateTemplate();
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

                foreach (TransformJsonServiceProvider provider in serviceProvider)
                {
                    foreach (Factory factory in provider.GetItems())
                    {
                        var c = new MyCompletionData(factory.MethodInfos.Content, factory.MethodInfos.Name, string.IsNullOrEmpty(factory.MethodInfos.Description) ? factory.MethodInfos.Content : factory.MethodInfos.Description);
                        data.Add(c);
                    }
                }

                completionWindow.Show();


                var p = completionWindow.CompletionList.RenderSize;
                completionWindow.CompletionList.RenderSize = new Size(270, p.Height);

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

            if (e.Key == Key.S && e.IsToggled)
                SaveTemplate();

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

        private void ErrorDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (Errors.SelectedValue != null)
            {
                if (Errors.SelectedValue is ErrorModel m)
                {
                    if (m.StartIndex != 0)
                    {
                        TemplateEditor.SelectionStart = m.StartIndex;
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

            textArea.TextChanged += (this.OnTextChanged);

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

        private void OnTextChanged(object sender, EventArgs e)
        {

        }

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

        private void Click_Search(object sender, RoutedEventArgs e)
        {

        }
    }

}
