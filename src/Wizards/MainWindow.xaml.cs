using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace Wizards
{


    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow(DirectoryInfo dir)
        {
            InitializeComponent();
            

            this._dir = new DirectoryObject(dir, null);

            this.DataContext = this._dir.Subs;
            

        }

        private readonly DirectoryObject _dir;

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (sender is Button b)
                if (b.DataContext is ParserObject s)
                {
                    s.Click(s, new ParserObbjectEventArgs() { List = lvDataBinding, Button = b, Main = this });
                }

        }

      

    }

}



