using Bb.Wizards.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bb.Wizards
{


    public class UIExecuteMethod : UIMethodWizardBase
    {


        public UIExecuteMethod(WizardModel model)
            : base(model)
        {
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (ExecuteButton != null)
                ExecuteButton(this, this.Model.Current);
        }


        private void UserControl1_Load(object sender, EventArgs e)
        {

        }


        public Action<UIExecuteMethod, WizardTabModel> ExecuteButton { get; set; }


      

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        protected override void InitializeComponent()
        {

            this.textBox1 = new System.Windows.Forms.TextBox()
            {
                Name = "textBox1",
                TabIndex = 0,
                Location = new System.Drawing.Point(10, 13),
                Size = new System.Drawing.Size(413, 22),

                Anchor = System.Windows.Forms.AnchorStyles.Top
                    | System.Windows.Forms.AnchorStyles.Left
                    | System.Windows.Forms.AnchorStyles.Right,

            };
            this.Controls.Add(this.textBox1);


            this.button1 = new System.Windows.Forms.Button()
            {
                Name = "button1",
                TabIndex = 1,
                Text = "...",

                Anchor = System.Windows.Forms.AnchorStyles.Top
                    | System.Windows.Forms.AnchorStyles.Right,

                Location = new System.Drawing.Point(430, 13),
                Size = new System.Drawing.Size(38, 23),

                UseVisualStyleBackColor = true,
            };

            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.Controls.Add(this.button1);


            Map(this.textBox1, "Text");


        }


        protected override void ExecuteMethod_Resize(object sender, EventArgs e)
        {
            var s = this.Size;
            textBox1.Size = new System.Drawing.Size(s.Width - 100, s.Height);

            this.button1.Location = new System.Drawing.Point(textBox1.Width + 20, 13);

            this.button1.Size = new System.Drawing.Size(48 , textBox1.Size.Height);

        }

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;

    }


}
