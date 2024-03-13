namespace zoopark
{
    partial class Order_form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            dataGridView1 = new DataGridView();
            label1 = new Label();
            Price_label = new Label();
            Order_btn = new Button();
            remove_position = new Button();
            back_btn = new Button();
            comboBox1 = new ComboBox();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.BackgroundColor = Color.FromArgb(0, 192, 192);
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.GridColor = Color.FromArgb(0, 192, 192);
            dataGridView1.Location = new Point(12, 59);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(1235, 435);
            dataGridView1.TabIndex = 1;
            dataGridView1.CellFormatting += dataGridView1_CellFormatting;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(435, 9);
            label1.Name = "label1";
            label1.Size = new Size(286, 37);
            label1.TabIndex = 2;
            label1.Text = "Оформление заказа";
            // 
            // Price_label
            // 
            Price_label.AutoSize = true;
            Price_label.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            Price_label.Location = new Point(12, 506);
            Price_label.Name = "Price_label";
            Price_label.Size = new Size(102, 37);
            Price_label.TabIndex = 3;
            Price_label.Text = "Итого:";
            // 
            // Order_btn
            // 
            Order_btn.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            Order_btn.Location = new Point(435, 507);
            Order_btn.Name = "Order_btn";
            Order_btn.Size = new Size(286, 38);
            Order_btn.TabIndex = 4;
            Order_btn.Text = "Оформить заказ";
            Order_btn.UseVisualStyleBackColor = true;
            Order_btn.Click += Order_btn_Click;
            // 
            // remove_position
            // 
            remove_position.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            remove_position.Location = new Point(987, 9);
            remove_position.Name = "remove_position";
            remove_position.Size = new Size(260, 37);
            remove_position.TabIndex = 5;
            remove_position.Text = "Удалить выбранное";
            remove_position.UseVisualStyleBackColor = true;
            remove_position.Click += remove_position_Click;
            // 
            // back_btn
            // 
            back_btn.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            back_btn.Location = new Point(12, 9);
            back_btn.Name = "back_btn";
            back_btn.Size = new Size(260, 37);
            back_btn.TabIndex = 6;
            back_btn.Text = "Назад";
            back_btn.UseVisualStyleBackColor = true;
            back_btn.Click += back_btn_Click;
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(1038, 517);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(207, 23);
            comboBox1.TabIndex = 7;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(818, 507);
            label2.Name = "label2";
            label2.Size = new Size(214, 37);
            label2.TabIndex = 8;
            label2.Text = "Пункт выдачи:";
            // 
            // Order_form
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(0, 192, 192);
            ClientSize = new Size(1254, 552);
            Controls.Add(label2);
            Controls.Add(comboBox1);
            Controls.Add(back_btn);
            Controls.Add(remove_position);
            Controls.Add(Order_btn);
            Controls.Add(Price_label);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            Name = "Order_form";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Оформление заказа";
            FormClosed += Order_form_FormClosed;
            Load += Order_form_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Label label1;
        private Label Price_label;
        private Button Order_btn;
        private Button remove_position;
        private Button back_btn;
        private ComboBox comboBox1;
        private Label label2;
    }
}