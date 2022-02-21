using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bb.JsltEvaluator.Wizards
{

    public class ExecuteMethod : Control
    {

        public ExecuteMethod(WizardModel model)
        {
            this._model = model;
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ExecuteButton != null)
                ExecuteButton(this, this._model.Current);
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {

        }


        public Action<ExecuteMethod, WizardTabModel> ExecuteButton { get; set; }


        public string DataText { get => this.textBox1.Text; set => this.textBox1.Text = value; }


        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {

            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(10, 13);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(413, 22);
            this.textBox1.TabIndex = 0;
            
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(430, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(38, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // UserControl1
            // 
            //this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            //this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Name = "ExecuteMethod";
            this.Size = new System.Drawing.Size(483, 55);
            this.Resize += ExecuteMethod_Resize;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void ExecuteMethod_Resize(object sender, EventArgs e)
        {
            this.button1.Size = new System.Drawing.Size(38, this.textBox1.Size.Height - 5);
        }

        #endregion

        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private readonly WizardModel _model;
    }


}
