using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Wizards.Actions;
using Wizards.Commands;

namespace Wizards
{


    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow(DirectoryInfo dir, bool debug)
        {

            InitializeComponent();

            Parameters.Instance.Debug = debug;
            var git = Parameters.GetLocalGit(dir.FullName);


            this._dir = new DirectoryObject(dir, null);

            while (_dir.Subs.Where(c => !(c is BackAction)).Count() == 1 && _dir.Subs.FirstOrDefault(c => !(c is BackAction)) is DirectoryObject d)
            {
                _dir = d;
            }

            var item = _dir.Subs.Where(c => (c is BackAction)).FirstOrDefault();
            if (item != null)
                _dir.Subs.Remove(item);

            this._dir.Subs.Add(new CustomAction("Update toolbox", (sender, e) =>
            {

                git.Fetch();

            }));

            this.DataContext = this._dir.Subs;

        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (sender is Button b)
            {
                if (b.DataContext is ParserObject s)
                    s.Click(s, new ParserObbjectEventArgs() { List = lvDataBinding, Button = b, Main = this });

            }

        }

        private readonly Parameters _parameters;
        private readonly DirectoryObject _dir;

    }

}



