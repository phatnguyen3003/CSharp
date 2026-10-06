namespace Bai8
{
    partial class Baimaucua4d
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
            components = new System.ComponentModel.Container();
            textbox_a = new TextBox();
            label1 = new Label();
            label2 = new Label();
            textbox_b = new TextBox();
            label3 = new Label();
            textbox_result = new TextBox();
            groupBox1 = new GroupBox();
            radio_devide = new RadioButton();
            radio_mul = new RadioButton();
            radio_minus = new RadioButton();
            radio_plus = new RadioButton();
            btn_cal = new Button();
            errorProvider1 = new ErrorProvider(components);
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // textbox_a
            // 
            textbox_a.Location = new Point(49, 53);
            textbox_a.Name = "textbox_a";
            textbox_a.Size = new Size(173, 27);
            textbox_a.TabIndex = 0;
            textbox_a.TextChanged += textbox_Textchanged;
            textbox_a.KeyPress += textbox_KeyPress;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 60);
            label1.Name = "label1";
            label1.Size = new Size(31, 20);
            label1.TabIndex = 1;
            label1.Text = "a =";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(301, 60);
            label2.Name = "label2";
            label2.Size = new Size(32, 20);
            label2.TabIndex = 3;
            label2.Text = "b =";
            // 
            // textbox_b
            // 
            textbox_b.Location = new Point(338, 53);
            textbox_b.Name = "textbox_b";
            textbox_b.Size = new Size(173, 27);
            textbox_b.TabIndex = 2;
            textbox_b.TextChanged += textbox_Textchanged;
            textbox_b.KeyPress += textbox_KeyPress;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 125);
            label3.Name = "label3";
            label3.Size = new Size(63, 20);
            label3.TabIndex = 5;
            label3.Text = "Kết quả:";
            // 
            // textbox_result
            // 
            textbox_result.Location = new Point(81, 118);
            textbox_result.Name = "textbox_result";
            textbox_result.ReadOnly = true;
            textbox_result.Size = new Size(430, 27);
            textbox_result.TabIndex = 4;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(radio_devide);
            groupBox1.Controls.Add(radio_mul);
            groupBox1.Controls.Add(radio_minus);
            groupBox1.Controls.Add(radio_plus);
            groupBox1.Location = new Point(21, 166);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(490, 35);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            // 
            // radio_devide
            // 
            radio_devide.AutoSize = true;
            radio_devide.Location = new Point(373, 11);
            radio_devide.Name = "radio_devide";
            radio_devide.Size = new Size(36, 24);
            radio_devide.TabIndex = 3;
            radio_devide.Text = "/";
            radio_devide.UseVisualStyleBackColor = true;
            // 
            // radio_mul
            // 
            radio_mul.AutoSize = true;
            radio_mul.Location = new Point(246, 11);
            radio_mul.Name = "radio_mul";
            radio_mul.Size = new Size(37, 24);
            radio_mul.TabIndex = 2;
            radio_mul.Text = "x";
            radio_mul.UseVisualStyleBackColor = true;
            // 
            // radio_minus
            // 
            radio_minus.AutoSize = true;
            radio_minus.Location = new Point(123, 11);
            radio_minus.Name = "radio_minus";
            radio_minus.Size = new Size(36, 24);
            radio_minus.TabIndex = 1;
            radio_minus.Text = "-";
            radio_minus.UseVisualStyleBackColor = true;
            // 
            // radio_plus
            // 
            radio_plus.AutoSize = true;
            radio_plus.Checked = true;
            radio_plus.Location = new Point(0, 11);
            radio_plus.Name = "radio_plus";
            radio_plus.Size = new Size(40, 24);
            radio_plus.TabIndex = 0;
            radio_plus.TabStop = true;
            radio_plus.Text = "+";
            radio_plus.UseVisualStyleBackColor = true;
            // 
            // btn_cal
            // 
            btn_cal.Location = new Point(187, 210);
            btn_cal.Name = "btn_cal";
            btn_cal.Size = new Size(161, 29);
            btn_cal.TabIndex = 7;
            btn_cal.Text = "Tính";
            btn_cal.UseVisualStyleBackColor = true;
            btn_cal.Click += btn_cal_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // bai8
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(546, 251);
            Controls.Add(btn_cal);
            Controls.Add(groupBox1);
            Controls.Add(label3);
            Controls.Add(textbox_result);
            Controls.Add(label2);
            Controls.Add(textbox_b);
            Controls.Add(label1);
            Controls.Add(textbox_a);
            Name = "bai8";
            Text = "Form1";
            FormClosing += form_FormClosing;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textbox_a;
        private Label label1;
        private Label label2;
        private TextBox textbox_b;
        private Label label3;
        private TextBox textbox_result;
        private GroupBox groupBox1;
        private RadioButton radio_devide;
        private RadioButton radio_mul;
        private RadioButton radio_minus;
        private RadioButton radio_plus;
        private Button btn_cal;
        private ErrorProvider errorProvider1;
    }
}
