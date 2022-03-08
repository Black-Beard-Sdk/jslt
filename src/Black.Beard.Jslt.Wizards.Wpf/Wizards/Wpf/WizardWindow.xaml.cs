using AppJsonEvaluator;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Media;

namespace Bb.Wizards.Wpf
{


    /// <summary>
    /// Logique d'interaction pour WizardWindow.xaml
    /// </summary>
    public partial class WizardWindow : Window
    {


        public WizardWindow(WizardModel model)
        {
            InitializeComponent();
            this._model = model;
            this.DataContext = model;

            this.SizeChanged += WizardWindow_SizeChanged;

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
            _model.StateChange();

        }


        public void MoveNext(object sender, RoutedEventArgs e)
        {
            Child.ApplyValueToModel();
            _model.MoveNext();
            _model.CleanError();

            InitializeChild();

        }


        private void InitializeChild()
        {

            UIMethodWizardBase child = null;

            switch (_model.Current.Template)
            {

                case TemplateEnum.SelectFolder:
                    var uc = new UISelectFolder(this._model);

                    child = uc;
                    break;

                case TemplateEnum.ButtonExecute:
                    var uc1 = new UIExecuteMethod(this._model)
                    {
                        ExecuteButton = (Action<UIExecuteMethod, WizardTabModel>)_model.Current.Tag,
                    };

                    child = uc1;
                    break;


                case TemplateEnum.Text:
                    var text = new UIText(this._model);

                    child = text;
                    break;


                default:
                    break;

            }

            if (Child != null && Child is UIMethodWizardBase wizard)
                wizard.Dispose();

            var w = PointsToPixels(this.Width, LengthDirection.Horizontal);
            var h = PointsToPixels(this.Height, LengthDirection.Vertical);
            child.Size = new System.Drawing.Size(w - 350, h - 330);

            Child = child;

        }

        private void WizardWindow_SizeChanged(object sender, SizeChangedEventArgs e)
        {

            var w = PointsToPixels(this.Width, LengthDirection.Horizontal);
            var h = PointsToPixels(this.Height, LengthDirection.Vertical);

            using (var graphics = Graphics.FromHwnd(IntPtr.Zero))
            {

                var pixelWidth = (int)(this.DesiredSize.Width * graphics.DpiX / 96.0);
                var pixelHeight = (int)(this.DesiredSize.Height * graphics.DpiY / 96.0);

            }

            Child.Size = new System.Drawing.Size(w - 350, h - 330);

        }


        protected UIMethodWizardBase Child { get => (UIMethodWizardBase)DataTemplate.Child; set => DataTemplate.Child = value; }

        public async void Terminate(object sender, RoutedEventArgs e)
        {

            progressBar.IsIndeterminate = true;
            progressBar.Refresh();
            this.Refresh();

            var result = Task.Run(() =>
            {

                this._model.ExecuteTerminate();

            });

            await result;

            progressBar.IsIndeterminate = false;
            this.Close();
        }

        private readonly WizardModel _model;




        private int PointsToPixels(double wpfPoints, LengthDirection direction)
        {

            if (direction == LengthDirection.Horizontal)
            {
                return (int)(wpfPoints * Screen.PrimaryScreen.WorkingArea.Width / SystemParameters.WorkArea.Width);
            }
            else
            {
                return (int)(wpfPoints * Screen.PrimaryScreen.WorkingArea.Height / SystemParameters.WorkArea.Height);
            }
        }

        private double PixelsToPoints(int pixels, LengthDirection direction)
        {
            if (direction == LengthDirection.Horizontal)
            {
                return (pixels * SystemParameters.WorkArea.Width / Screen.PrimaryScreen.WorkingArea.Width);
            }
            else
            {
                return (pixels * SystemParameters.WorkArea.Height / Screen.PrimaryScreen.WorkingArea.Height);
            }
        }

        public enum LengthDirection
        {
            Vertical,   // |
            Horizontal  // ——
        }
    }


}
