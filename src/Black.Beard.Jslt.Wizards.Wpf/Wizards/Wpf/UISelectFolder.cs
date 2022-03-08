using Bb.Wizards.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bb.Wizards
{


    public class UISelectFolder : UIExecuteMethod
    {


        public UISelectFolder(WizardModel model)
            : base(model)
        {

            Action<UIExecuteMethod, WizardTabModel> action = (a, b) =>
            {

                System.Windows.Forms.FolderBrowserDialog folderDialog = new System.Windows.Forms.FolderBrowserDialog()
                {
                    InitialDirectory = (string)b.Model,
                };

                var result = folderDialog.ShowDialog();
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    Datas = folderDialog.SelectedPath;
                }

            };

            ExecuteButton = action;

        }
             
    }


}
