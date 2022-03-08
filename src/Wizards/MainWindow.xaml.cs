using Bb.Wizards;
using Bb.Wizards.Wpf;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Wizards
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            
            InitializeComponent();


            var model = new WizardModel()

                .SetTitle("Resent the codes")
                //.SetVariable("templateContent", "")

                .Add(new WizardTabModel("CodeToResent", "Please select the file with the code to resent.")
                .IsRequired()
                //.SetModel("")
                .SetTemplate(TemplateEnum.Text))


                //.Add(new WizardTabModel("folderCmd", "Please select a folder to store the command line") 
                //.IsRequired()
                //.SetTemplate(TemplateEnum.ButtonExecute)
                //.SetAction((uc, t) =>
                //{
                //    //System.Windows.Forms.FolderBrowserDialog folderDialog = new System.Windows.Forms.FolderBrowserDialog()
                //    //{
                //    //    InitialDirectory = _lastShownFolder,
                //    //};
                //    //var result = folderDialog.ShowDialog();
                //    //if (result == System.Windows.Forms.DialogResult.OK)
                //    //{
                //    //    t.Model = uc.DataText = folderDialog.SelectedPath;
                //    //    _lastShownFolder = folderDialog.SelectedPath;
                //    //}
                //}
                //))


                .Execute(async (model) =>
                {

                    var folderCmd = model["CodeToResent"].ToString();

                });

            ;


            var wizard = new WizardWindow(model);

            wizard.Show();



        }
    }
}
