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

            MajTitle();

        }

        private void MajTitle()
        {
            this.Title = $"Wizard ({_model.Index} / {_model.Count})";
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

            MajTitle();

        }

        public void MoveNext(object sender, RoutedEventArgs e)
        {
            _model.MoveNext();
            _model.CleanError();

            InitializeChild();

            MajTitle();

        }


        private void InitializeChild()
        {

            if (Child != null && Child is UIMethodWizardBase wizard)
                wizard.Dispose();

            var child = new UIBlock(this._model.Current);

            var w = PointsToPixels(this.Width, LengthDirection.Horizontal);
            var h = PointsToPixels(this.Height, LengthDirection.Vertical);
            child.Size = new System.Drawing.Size(w - 350, h - 330);

            _model.Current.Configure(child);

            Child = child;

            this._model.StateChange();

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


        protected UIBlock Child
        {
            get => (UIBlock)DataTemplate.Child;
            set
            {
                DataTemplate.Child = value;
                _model.CurrentUI = value;
            }
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
