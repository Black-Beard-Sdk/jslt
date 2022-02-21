using AppJsonEvaluator;
using System;
using System.Threading.Tasks;
using System.Windows;

namespace Bb.JsltEvaluator.Wizards
{


    /// <summary>
    /// Logique d'interaction pour WizardWindow.xaml
    /// </summary>
    public partial class WizardWindow : Window
    {
        private readonly WizardModel _model;

        public WizardWindow(WizardModel model)
        {
            InitializeComponent();
            this._model = model;
            this.DataContext = model;
            InitializeChild();
        }




        public void Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        public void MovePrevious(object sender, RoutedEventArgs e)
        {
            _model.MovePrevious();
            InitializeChild();
        }


        public void MoveNext(object sender, RoutedEventArgs e)
        {
            _model.MoveNext();
            _model.CleanError();

            InitializeChild();

        }

        private void InitializeChild()
        {
            System.Windows.Forms.Control child = null;

            switch (_model.Current.Template)
            {


                case TemplateEnum.ButtonExecute:
                    var uc = new ExecuteMethod(this._model)
                    {
                        Visible = true,
                        ExecuteButton = (Action<ExecuteMethod, WizardTabModel>)_model.Current.Tag,
                        DataText = _model.CurrentValue?.ToString(),
                    };
                    child = uc;
                    break;


                case TemplateEnum.Text:
                    var text = new System.Windows.Forms.TextBox()
                    {
                        Visible = true,
                        Text = _model.CurrentValue?.ToString(),
                    };
                    child = text;
                    break;


                default:
                    break;

            }
            
            DataTemplate.Child = child;
        }

        public async void Terminate(object sender, RoutedEventArgs e)
        {
            
            progressBar.IsIndeterminate = true;
            progressBar.Refresh();
            this.Refresh();

            var result = Task.Run(() =>
            {

                this._model.ExecuteTerminate();
            
            });

            result.Wait();

            progressBar.IsIndeterminate = false;
            this.Close();
        }


    }
}
