using AppJsonEvaluator;
using ICSharpCode.AvalonEdit;
using ICSharpCode.AvalonEdit.Folding;
using Oldtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Bb.JsltEvaluator
{
    /// <summary>
    /// Logique d'interaction pour WindowVariables.xaml
    /// </summary>
    public partial class WindowVariables : Window, INotifyPropertyChanged
    {

        public WindowVariables()
        {
            InitializeComponent();
            InitializeTextMarkerService();
            this.DataContext = this;
        }


        public string Code
        {
            get { return this.TemplateEditor.Text; }
            set { this.TemplateEditor.Text = value; }
        }


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
            this._foldingStrategy = new BraceFoldingStrategy();
            _templateFoldingManager = FoldingManager.Install(TemplateEditor.TextArea);
            TemplateEditor.TextArea.IndentationStrategy = new ICSharpCode.AvalonEdit.Indentation.CSharp.CSharpIndentationStrategy(TemplateEditor.Options);
            TemplateEditor.SyntaxHighlighting = ICSharpCode.AvalonEdit.Highlighting.HighlightingManager.Instance.GetDefinition("Json");
            TemplateEditor.ShowLineNumbers = true;
            TemplateEditor.Options.IndentationSize = 3;

        }

        private void UpdateFolding(FoldingManager foldingManager, TextEditor textEditor)
        {
            _foldingStrategy.UpdateFoldings(foldingManager, textEditor.Document);
        }


        private void TemplateEditorTextChanged(object sender, EventArgs e)
        {

            UpdateFolding(_templateFoldingManager, TemplateEditor);

            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(nameof(CanValidate)));

        }

        private TextMarkerService textMarkerService;
        private BraceFoldingStrategy _foldingStrategy;
        private FoldingManager _templateFoldingManager;

        public event PropertyChangedEventHandler PropertyChanged;

        public bool CanValidate
        {
            get
            {
                try
                {

                    var result = JObject.Parse(TemplateEditor.Text);

                    if (result != null && result is JObject)
                        return true;

                }
                catch (Exception)
                {
                }

                return false;

            }
        }

        private void TemplateEditor_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void TemplateEditor_Drop(object sender, DragEventArgs e)
        {

        }

        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }

        private void CancelChange(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
