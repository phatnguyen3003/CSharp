namespace Bai7
{
    partial class bai7
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            textbox_input = new TextBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            btn_backspace = new Button();
            btn_devide = new Button();
            btn_mul = new Button();
            btn_9 = new Button();
            btn_8 = new Button();
            btn_7 = new Button();
            btn_minus = new Button();
            btn_plus = new Button();
            btn_6 = new Button();
            btn_5 = new Button();
            btn_4 = new Button();
            btn_3 = new Button();
            btn_2 = new Button();
            btn_1 = new Button();
            btn_0 = new Button();
            btn_clear = new Button();
            btn_equal = new Button();
            textbox_output = new TextBox();
            label2 = new Label();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label1.ForeColor = Color.Red;
            label1.Location = new Point(86, 9);
            label1.Name = "label1";
            label1.Size = new Size(246, 41);
            label1.TabIndex = 0;
            label1.Text = "Máy Tính Bỏ Túi";
            // 
            // textbox_input
            // 
            textbox_input.Location = new Point(9, 53);
            textbox_input.Name = "textbox_input";
            textbox_input.ReadOnly = true;
            textbox_input.Size = new Size(385, 27);
            textbox_input.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 5;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.Controls.Add(btn_backspace, 3, 0);
            tableLayoutPanel1.Controls.Add(btn_devide, 4, 2);
            tableLayoutPanel1.Controls.Add(btn_mul, 3, 2);
            tableLayoutPanel1.Controls.Add(btn_9, 2, 2);
            tableLayoutPanel1.Controls.Add(btn_8, 1, 2);
            tableLayoutPanel1.Controls.Add(btn_7, 0, 2);
            tableLayoutPanel1.Controls.Add(btn_minus, 4, 1);
            tableLayoutPanel1.Controls.Add(btn_plus, 3, 1);
            tableLayoutPanel1.Controls.Add(btn_6, 2, 1);
            tableLayoutPanel1.Controls.Add(btn_5, 1, 1);
            tableLayoutPanel1.Controls.Add(btn_4, 0, 1);
            tableLayoutPanel1.Controls.Add(btn_3, 2, 0);
            tableLayoutPanel1.Controls.Add(btn_2, 1, 0);
            tableLayoutPanel1.Controls.Add(btn_1, 0, 0);
            tableLayoutPanel1.Controls.Add(btn_0, 1, 3);
            tableLayoutPanel1.Controls.Add(btn_clear, 4, 0);
            tableLayoutPanel1.Controls.Add(btn_equal, 4, 3);
            tableLayoutPanel1.Location = new Point(12, 115);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.Size = new Size(385, 191);
            tableLayoutPanel1.TabIndex = 2;
            // 
            // btn_backspace
            // 
            btn_backspace.Location = new Point(234, 3);
            btn_backspace.Name = "btn_backspace";
            btn_backspace.Size = new Size(71, 41);
            btn_backspace.TabIndex = 15;
            btn_backspace.Text = "<-";
            btn_backspace.UseVisualStyleBackColor = true;
            // 
            // btn_devide
            // 
            btn_devide.Location = new Point(311, 97);
            btn_devide.Name = "btn_devide";
            btn_devide.Size = new Size(71, 41);
            btn_devide.TabIndex = 14;
            btn_devide.Text = "%";
            btn_devide.UseVisualStyleBackColor = true;
            // 
            // btn_mul
            // 
            btn_mul.Location = new Point(234, 97);
            btn_mul.Name = "btn_mul";
            btn_mul.Size = new Size(71, 41);
            btn_mul.TabIndex = 13;
            btn_mul.Text = "x";
            btn_mul.UseVisualStyleBackColor = true;
            // 
            // btn_9
            // 
            btn_9.Location = new Point(157, 97);
            btn_9.Name = "btn_9";
            btn_9.Size = new Size(71, 41);
            btn_9.TabIndex = 12;
            btn_9.Text = "9";
            btn_9.UseVisualStyleBackColor = true;
            // 
            // btn_8
            // 
            btn_8.Location = new Point(80, 97);
            btn_8.Name = "btn_8";
            btn_8.Size = new Size(71, 41);
            btn_8.TabIndex = 11;
            btn_8.Text = "8";
            btn_8.UseVisualStyleBackColor = true;
            // 
            // btn_7
            // 
            btn_7.Location = new Point(3, 97);
            btn_7.Name = "btn_7";
            btn_7.Size = new Size(71, 41);
            btn_7.TabIndex = 10;
            btn_7.Text = "7";
            btn_7.UseVisualStyleBackColor = true;
            // 
            // btn_minus
            // 
            btn_minus.Location = new Point(311, 50);
            btn_minus.Name = "btn_minus";
            btn_minus.Size = new Size(71, 41);
            btn_minus.TabIndex = 9;
            btn_minus.Text = "-";
            btn_minus.UseVisualStyleBackColor = true;
            // 
            // btn_plus
            // 
            btn_plus.Location = new Point(234, 50);
            btn_plus.Name = "btn_plus";
            btn_plus.Size = new Size(71, 41);
            btn_plus.TabIndex = 8;
            btn_plus.Text = "+";
            btn_plus.UseVisualStyleBackColor = true;
            // 
            // btn_6
            // 
            btn_6.Location = new Point(157, 50);
            btn_6.Name = "btn_6";
            btn_6.Size = new Size(71, 41);
            btn_6.TabIndex = 7;
            btn_6.Text = "6";
            btn_6.UseVisualStyleBackColor = true;
            // 
            // btn_5
            // 
            btn_5.Location = new Point(80, 50);
            btn_5.Name = "btn_5";
            btn_5.Size = new Size(71, 41);
            btn_5.TabIndex = 6;
            btn_5.Text = "5";
            btn_5.UseVisualStyleBackColor = true;
            // 
            // btn_4
            // 
            btn_4.Location = new Point(3, 50);
            btn_4.Name = "btn_4";
            btn_4.Size = new Size(71, 41);
            btn_4.TabIndex = 5;
            btn_4.Text = "4";
            btn_4.UseVisualStyleBackColor = true;
            // 
            // btn_3
            // 
            btn_3.Location = new Point(157, 3);
            btn_3.Name = "btn_3";
            btn_3.Size = new Size(71, 41);
            btn_3.TabIndex = 2;
            btn_3.Text = "3";
            btn_3.UseVisualStyleBackColor = true;
            // 
            // btn_2
            // 
            btn_2.Location = new Point(80, 3);
            btn_2.Name = "btn_2";
            btn_2.Size = new Size(71, 41);
            btn_2.TabIndex = 1;
            btn_2.Text = "2";
            btn_2.UseVisualStyleBackColor = true;
            // 
            // btn_1
            // 
            btn_1.Location = new Point(3, 3);
            btn_1.Name = "btn_1";
            btn_1.Size = new Size(71, 41);
            btn_1.TabIndex = 0;
            btn_1.Text = "1";
            btn_1.UseVisualStyleBackColor = true;
            // 
            // btn_0
            // 
            btn_0.Location = new Point(80, 144);
            btn_0.Name = "btn_0";
            btn_0.Size = new Size(71, 44);
            btn_0.TabIndex = 3;
            btn_0.Text = "0";
            btn_0.UseVisualStyleBackColor = true;
            // 
            // btn_clear
            // 
            btn_clear.Location = new Point(311, 3);
            btn_clear.Name = "btn_clear";
            btn_clear.Size = new Size(71, 41);
            btn_clear.TabIndex = 4;
            btn_clear.Text = "C";
            btn_clear.UseVisualStyleBackColor = true;
            // 
            // btn_equal
            // 
            btn_equal.Location = new Point(311, 144);
            btn_equal.Name = "btn_equal";
            btn_equal.Size = new Size(71, 41);
            btn_equal.TabIndex = 16;
            btn_equal.Text = "=";
            btn_equal.UseVisualStyleBackColor = true;
            // 
            // textbox_output
            // 
            textbox_output.Location = new Point(278, 86);
            textbox_output.Name = "textbox_output";
            textbox_output.ReadOnly = true;
            textbox_output.Size = new Size(116, 27);
            textbox_output.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(209, 89);
            label2.Name = "label2";
            label2.Size = new Size(63, 20);
            label2.TabIndex = 4;
            label2.Text = "Kết quả:";
            // 
            // bai7
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(409, 318);
            Controls.Add(label2);
            Controls.Add(textbox_output);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(textbox_input);
            Controls.Add(label1);
            Name = "bai7";
            Text = "Form1";
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textbox_input;
        private TableLayoutPanel tableLayoutPanel1;
        private Button btn_devide;
        private Button btn_mul;
        private Button btn_9;
        private Button btn_8;
        private Button btn_7;
        private Button btn_minus;
        private Button btn_plus;
        private Button btn_6;
        private Button btn_5;
        private Button btn_4;
        private Button btn_clear;
        private Button btn_0;
        private Button btn_3;
        private Button btn_2;
        private Button btn_1;
        private Button btn_backspace;
        private Button btn_equal;
        private TextBox textbox_output;
        private Label label2;
    }
}
