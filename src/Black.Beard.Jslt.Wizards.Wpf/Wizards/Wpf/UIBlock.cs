using Bb.Wizards.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Bb.Wizards
{


    public class UIBlock : UIMethodWizardBase
    {


        public UIBlock(WizardTabModel model)
          : base(model)
        {

        }


        protected override void InitializeComponent()
        {

            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel()
            {
                //Location = new System.Drawing.Point(50, 36),
                Name = "flowLayoutPanel1",
                //Size = new System.Drawing.Size(443, 281),
                TabIndex = 0,
                FlowDirection = FlowDirection.TopDown,
                Dock = DockStyle.Fill,
            };

            this.Controls.Add(flowLayoutPanel1);

        }


        #region Variables

        public VariableWizard this[string name]
        {
            get
            {
                return this.TabModel.Parent.Variables[name];
            }
        }


        public UIBlock InitializeVariable(string variableName, Action<VariableWizard>? actionInitializer, out VariableWizard variable)
        {
            this.TabModel.InitializeVariable(variableName, actionInitializer, out variable);
            return this;

        }

        public UIBlock InitializeVariable(string variableName, Action<VariableWizard>? actionInitializer)
        {
            this.TabModel.InitializeVariable(variableName, actionInitializer);
            return this;

        }

        public UIBlock InitializeVariable(string variableName, Action<VariableWizard>? actionInitializer, object value, out VariableWizard variable)
        {
            this.TabModel.InitializeVariable(variableName, actionInitializer, value, out variable);
            return this;
        }

      
        public UIBlock InitializeVariable(string variableName, Action<VariableWizard>? actionInitializer, object value)
        {
            this.TabModel.InitializeVariable(variableName, actionInitializer, value);
            return this;

        }

        public UIBlock SetVariable(string varableName, object? value)
        {
            this.TabModel.Parent.Variables.SetVariable(varableName, value);
            return this;
        }

        public UIBlock SetVariable(string varableName, object? value, out VariableWizard variable)
        {
            variable = this.TabModel.Parent.Variables.SetVariable(varableName, value);
            return this;
        }

        #endregion Variables


        public UIBlock AppendGrid(VariableWizard variable, DataSet data, DataGridViewSelectionMode selectionMode)
        {
            this.VariableToValidate(variable);

            var panelParent = new Panel()
            {
                Size = new System.Drawing.Size(900, 350),
            };

            var dataGridView1 = new DataGridView()
            {
                AllowUserToAddRows = false,
                ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize,
                Location = new System.Drawing.Point(0, 120),
                ReadOnly = true,
                RowHeadersWidth = 51,
                Size = new System.Drawing.Size(755, 300),
                MultiSelect = false,
                SelectionMode = selectionMode,
                Dock = DockStyle.Bottom,
                Font = new System.Drawing.Font("Segoe UI", 12.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point),
            };

            var comboBox1 = new ComboBox()
            {
                FormattingEnabled = true,
                Location = new System.Drawing.Point(130, 0),
                Size = new System.Drawing.Size(373, 28),
                DisplayMember = "TableName",
                Font = new System.Drawing.Font("Segoe UI", 12.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point),
            };

            comboBox1.SelectedIndexChanged += (sender, e) =>
            {

                var table = comboBox1.SelectedItem as DataTable;
                if (table != null)
                {
                    foreach (DataColumn column in table.Columns)
                    {
                        var column1 = new DataGridViewTextBoxColumn()
                        {
                            HeaderText = column.ColumnName,
                            MinimumWidth = 6,
                            Name = column.ColumnName,
                            ReadOnly = true,
                            Width = 125,
                            SortMode = DataGridViewColumnSortMode.NotSortable,
                            AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader,
                        };
                        dataGridView1.Columns.Add(column1);
                    }

                    int index = 0;
                    foreach (DataRow row in table.Rows)
                    {
                        dataGridView1.Rows.Add(row.ItemArray);
                        index++;
                        if (index > 10)
                            break;
                    }
                }

            };
            panelParent.Controls.Add(comboBox1);

            dataGridView1.SelectionChanged += (sender, e) =>
            {

                switch (dataGridView1.SelectionMode)
                {
                    case DataGridViewSelectionMode.CellSelect:
                        break;
                    case DataGridViewSelectionMode.RowHeaderSelect:
                    case DataGridViewSelectionMode.FullRowSelect:
                        if (dataGridView1.SelectedRows.Count > 0)
                        {
                            var c = dataGridView1.SelectedRows[0];
                            var table = comboBox1.SelectedItem as DataTable;
                            if (table != null)
                            {
                                DataRow row = table.Rows[c.Index];
                                variable.Value = row;                                
                            }
                        }
                        break;

                    case DataGridViewSelectionMode.ColumnHeaderSelect:
                    case DataGridViewSelectionMode.FullColumnSelect:
                        if (dataGridView1.SelectedColumns.Count > 0)
                        {
                            var c = dataGridView1.SelectedColumns[0];
                            var table = comboBox1.SelectedItem as DataTable;
                            if (table != null)
                            {
                                DataColumn column = table.Columns[c.Name];
                                variable.Value = column;
                            }
                        }
                        break;

                    default:
                        break;
                }

            };
            dataGridView1.RowTemplate.Height = 29;
            panelParent.Controls.Add(dataGridView1);


            var label1 = new Label()
            {
                AutoSize = true,
                Location = new System.Drawing.Point(0, 0),
                Size = new System.Drawing.Size(52, 20),
                Text = "Sheets",
                Font = new System.Drawing.Font("Segoe UI", 12.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point),
            };
            panelParent.Controls.Add(label1);

            this.flowLayoutPanel1.Controls.Add(panelParent);


            var list = new List<DataTable>(data.Tables.Count);
            foreach (DataTable item in data.Tables)
                list.Add(item);

            comboBox1.Items.AddRange(list.OfType<object>().ToArray());

            ApplyTable(variable, comboBox1, list);

            return this;

        }

        public UIBlock AppendFolderSelector(VariableWizard variable, string? Label, string? initialDirectory, bool allowedDrop = false)
        {

            this.VariableToValidate(variable);

            var initialFilename = variable.Value as string;

            var panelParent = new Panel()
            {
                Size = new System.Drawing.Size(832, 90),
                //BackColor = System.Drawing.Color.AliceBlue,
            };

            var labelChild1 = new Label()
            {
                AutoSize = true,
                Dock = DockStyle.Top,
                Font = new System.Drawing.Font("Segoe UI", 12.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point),
                Size = new System.Drawing.Size(59, 25),
                Text = Label ?? string.Empty,
            };


            var panelChild2 = new Panel()
            {
                Dock = DockStyle.Top,
                Size = new System.Drawing.Size(832, 70),
            };
            panelParent.Controls.Add(panelChild2);
            panelParent.Controls.Add(labelChild1);

            var textBox = new TextBox()
            {
                Dock = DockStyle.Left,
                Size = new System.Drawing.Size(770, 41),
                Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point),
                Text = initialFilename ?? string.Empty,
            };
            panelChild2.Controls.Add(textBox);

            var button2 = new Button()
            {
                Dock = DockStyle.Right,
                Size = new System.Drawing.Size(50, textBox.Height),
                Text = "...",
            };
            button2.Click += (sender, e) =>
            {

                FolderBrowserDialog folderDialog = new FolderBrowserDialog()
                {
                    InitialDirectory = initialFilename,
                };

                var result = folderDialog.ShowDialog();
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    variable.Value = folderDialog.SelectedPath;
                }

            };

            panelChild2.Controls.Add(button2);


            panelChild2.Size = new System.Drawing.Size(panelChild2.Size.Width, textBox.Height);

            if (allowedDrop)
            {

                Action<object, DragEventArgs> func1 = (sender, e) =>
                {
                    StringBuilder resultSb = new StringBuilder();

                    if (e.Data.GetDataPresent("FileName"))
                    {

                        var d = e.Data.GetData("FileName");
                        string[] datas = (string[])e.Data.GetData("FileName");
                        var data = datas[0];
                        if (!string.IsNullOrEmpty(data))
                        {
                            variable.Value = data;
                            variable.Validate(resultSb);
                        }

                    }
                    else if (e.Data.GetDataPresent("Text"))
                    {

                        var data = e.Data.GetData("Text")?.ToString() ?? String.Empty;
                        if (!string.IsNullOrEmpty(data))
                        {
                            variable.Value = data;
                            variable.Validate(resultSb);
                        }

                    }
                    else
                    {

                    }

                };


                Action<object, DragEventArgs> func2 = (sender, e) =>
                {
                    StringBuilder resultSb = new StringBuilder();

                    if (e.Data.GetDataPresent("FileName"))
                    {

                        var d = e.Data.GetData("FileName");
                        string[] datas = (string[])e.Data.GetData("FileName");
                        var data = datas[0];
                        if (!string.IsNullOrEmpty(data))
                            if (variable.Validate(data, resultSb))
                                e.Effect = DragDropEffects.Move;

                    }
                    else if (e.Data.GetDataPresent("Text"))
                    {

                        var data = e.Data.GetData("Text")?.ToString() ?? String.Empty;
                        if (!string.IsNullOrEmpty(data))
                            if (variable.Validate(data, resultSb))
                                e.Effect = DragDropEffects.Move;

                    }
                    else
                    {

                    }

                };

            }


            this.flowLayoutPanel1.Controls.Add(panelParent);

            Map(textBox, "Text", variable);

            return this;

        }

        public UIBlock AppendFileSelector(VariableWizard variable, string? Label, string? initialDirectory, string? filter, bool allowedDrop = false)
        {

            this.VariableToValidate(variable);

            var initialFilename = variable.Value as string;

            var panelParent = new Panel()
            {
                Size = new System.Drawing.Size(832, 90),
                //BackColor = System.Drawing.Color.AliceBlue,
            };

            var labelChild1 = new Label()
            {
                AutoSize = true,
                Dock = DockStyle.Top,
                Font = new System.Drawing.Font("Segoe UI", 12.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point),
                Size = new System.Drawing.Size(59, 25),
                Text = Label ?? string.Empty,
            };


            var panelChild2 = new Panel()
            {
                Dock = DockStyle.Top,
                Size = new System.Drawing.Size(832, 70),
            };
            panelParent.Controls.Add(panelChild2);
            panelParent.Controls.Add(labelChild1);

            var textBox = new TextBox()
            {
                Dock = DockStyle.Left,
                Size = new System.Drawing.Size(770, 41),
                Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point),
                //Text = initialFilename ?? string.Empty,
            };
            panelChild2.Controls.Add(textBox);

            var button2 = new Button()
            {
                Dock = DockStyle.Right,
                Size = new System.Drawing.Size(50, textBox.Height),
                Text = "...",
            };
            button2.Click += (sender, e) =>
             {

                 Microsoft.Win32.OpenFileDialog openFileDialog 
                    = new Microsoft.Win32.OpenFileDialog();

                 if (!string.IsNullOrEmpty(textBox.Text))
                     openFileDialog.FileName = textBox.Text;

                 if (!string.IsNullOrEmpty(initialDirectory))
                     openFileDialog.InitialDirectory = initialDirectory;

                 if (!string.IsNullOrEmpty(filter))
                     openFileDialog.Filter = filter;

                 if (openFileDialog.ShowDialog() == true)
                 {
                     variable.Value = openFileDialog.FileName;                     
                     //this.TabModel.Parent.StateChange();
                 }

             };

            panelChild2.Controls.Add(button2);

            panelChild2.Size = new System.Drawing.Size(panelChild2.Size.Width, textBox.Height);

            if (allowedDrop)
            {

                Action<object, DragEventArgs> func1 = (sender, e) =>
                {
                    StringBuilder resultSb = new StringBuilder();

                    if (e.Data.GetDataPresent("FileName"))
                    {

                        var d = e.Data.GetData("FileName");
                        string[] datas = (string[])e.Data.GetData("FileName");
                        var data = datas[0];
                        if (!string.IsNullOrEmpty(data))
                        {
                            variable.Value = data;
                            variable.Validate(resultSb);
                        }

                    }
                    else if (e.Data.GetDataPresent("Text"))
                    {

                        var data = e.Data.GetData("Text")?.ToString() ?? String.Empty;
                        if (!string.IsNullOrEmpty(data))
                        {
                            variable.Value = data;
                            variable.Validate(resultSb);
                        }

                    }
                    else
                    {

                    }

                };


                Action<object, DragEventArgs> func2 = (sender, e) =>
                {
                    StringBuilder resultSb = new StringBuilder();

                    if (e.Data.GetDataPresent("FileName"))
                    {

                        var d = e.Data.GetData("FileName");
                        string[] datas = (string[])e.Data.GetData("FileName");
                        var data = datas[0];
                        if (!string.IsNullOrEmpty(data))
                            if (variable.Validate(data, resultSb))
                                e.Effect = DragDropEffects.Move;

                    }
                    else if (e.Data.GetDataPresent("Text"))
                    {

                        var data = e.Data.GetData("Text")?.ToString() ?? String.Empty;
                        if (!string.IsNullOrEmpty(data))
                            if (variable.Validate(data, resultSb))
                                e.Effect = DragDropEffects.Move;

                    }
                    else
                    {

                    }

                };

            }

            this.flowLayoutPanel1.Controls.Add(panelParent);

            Map(textBox, "Text", variable);

            return this;

        }

        public UIBlock AppendButton(string caption, Action<UIBlock, WizardTabModel> executeButton)
        {                    

            var button = new Button()
            {
                Name = "Button" + this.flowLayoutPanel1.Controls.Count.ToString(),
                Size = new System.Drawing.Size(300, 50),
                TabIndex = 0,
                Visible = true,
                Location = new System.Drawing.Point(15, 13),

                Text = caption,
                Margin = new System.Windows.Forms.Padding(10),
            };


            button.Font = new System.Drawing.Font(button.Font.FontFamily, 12);


            button.Click += new System.EventHandler((sender, EventArgs) =>
            {
                if (executeButton != null)
                    executeButton(this, this.TabModel);
            });


            this.flowLayoutPanel1.Controls.Add(button);


            return this;

        }

        public UIBlock AppendText(VariableWizard variable, string? Label)
        {

            this.VariableToValidate(variable);

            var panelParent = new Panel()
            {
                Size = new System.Drawing.Size(832, 90),
                
            };

            var textBox = new TextBox()
            {
                Size = new System.Drawing.Size(465, 22),
                Visible = true,
                Location = new System.Drawing.Point(15, 13),
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
            };
            panelParent.Controls.Add(textBox);

            this.flowLayoutPanel1.Controls.Add(panelParent);

            Map(textBox, "Text", variable);

            return this;

        }

        private void ApplyTable(VariableWizard variable, ComboBox comboBox1, List<DataTable> list)
        {
            string tableName = string.Empty;

            var v = variable.Value;
            if (v != null)
            {

                if (v is DataRow r)
                    tableName = r.Table.TableName;

                else if (v is DataColumn c)
                    tableName = c.Table.TableName;

                else
                {

                }
            }

            if (!string.IsNullOrEmpty(tableName))
            {
                foreach (var item in list)
                    if (tableName == item.TableName)
                        comboBox1.SelectedItem = item;
            }
            else
            {
                foreach (var item in list)
                    if (item.Columns.Count > 0)
                    {
                        comboBox1.SelectedItem = item;
                        break;
                    }
            }
        }

        private FlowLayoutPanel flowLayoutPanel1;

    }


}
