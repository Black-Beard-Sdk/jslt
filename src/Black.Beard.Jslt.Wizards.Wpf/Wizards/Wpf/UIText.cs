using Bb.Wizards.Wpf;
using System;
using System.Windows.Forms;

namespace Bb.Wizards
{
    public class UIText : UIMethodWizardBase
    {

        public UIText(WizardModel model)
          : base(model)
        {

        }

        protected override void InitializeComponent()
        {

            this._textBox1 = new TextBox()
            {
                Name = "textBox1",
                Size = new System.Drawing.Size(465, 22),
                TabIndex = 0,
                Visible = true,
                Location = new System.Drawing.Point(15, 13),
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
            };

            this.Controls.Add(_textBox1);

            Map(_textBox1, "Text");

        }

        protected override void ExecuteMethod_Resize(object sender, EventArgs e)
        {
            var s = this.Size;
            _textBox1.Size = new System.Drawing.Size(s.Width - 35, s.Height);

        }

        private TextBox _textBox1;

    }


}
