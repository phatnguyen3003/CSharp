namespace Bai8
{
    partial class Bai8
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
            groupBox1 = new GroupBox();
            radio_2 = new RadioButton();
            radio_1 = new RadioButton();
            textbox_a = new TextBox();
            label2 = new Label();
            label3 = new Label();
            textbox_b = new TextBox();
            label4 = new Label();
            textbox_c = new TextBox();
            btn_cal = new Button();
            btn_exit = new Button();
            label5 = new Label();
            textbox_result = new TextBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label1.ForeColor = Color.Red;
            label1.Location = new Point(42, 9);
            label1.Name = "label1";
            label1.Size = new Size(309, 46);
            label1.TabIndex = 0;
            label1.Text = "Giải Phương Trình";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(radio_2);
            groupBox1.Controls.Add(radio_1);
            groupBox1.Location = new Point(42, 71);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(250, 102);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Bạn vui lòng chọn:";
            // 
            // radio_2
            // 
            radio_2.AutoSize = true;
            radio_2.Location = new Point(6, 56);
            radio_2.Name = "radio_2";
            radio_2.Size = new Size(155, 24);
            radio_2.TabIndex = 1;
            radio_2.Text = "Phương trình bậc 2";
            radio_2.UseVisualStyleBackColor = true;
            // 
            // radio_1
            // 
            radio_1.AutoSize = true;
            radio_1.Checked = true;
            radio_1.Location = new Point(6, 26);
            radio_1.Name = "radio_1";
            radio_1.Size = new Size(155, 24);
            radio_1.TabIndex = 0;
            radio_1.TabStop = true;
            radio_1.Text = "Phương trình bậc 1";
            radio_1.UseVisualStyleBackColor = true;
            // 
            // textbox_a
            // 
            textbox_a.Location = new Point(48, 204);
            textbox_a.Name = "textbox_a";
            textbox_a.Size = new Size(178, 27);
            textbox_a.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(11, 207);
            label2.Name = "label2";
            label2.Size = new Size(31, 20);
            label2.TabIndex = 3;
            label2.Text = "a =";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(11, 253);
            label3.Name = "label3";
            label3.Size = new Size(32, 20);
            label3.TabIndex = 5;
            label3.Text = "b =";
            // 
            // textbox_b
            // 
            textbox_b.Location = new Point(48, 250);
            textbox_b.Name = "textbox_b";
            textbox_b.Size = new Size(178, 27);
            textbox_b.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(11, 296);
            label4.Name = "label4";
            label4.Size = new Size(30, 20);
            label4.TabIndex = 7;
            label4.Text = "c =";
            // 
            // textbox_c
            // 
            textbox_c.Location = new Point(48, 293);
            textbox_c.Name = "textbox_c";
            textbox_c.Size = new Size(178, 27);
            textbox_c.TabIndex = 6;
            // 
            // btn_cal
            // 
            btn_cal.Location = new Point(254, 208);
            btn_cal.Name = "btn_cal";
            btn_cal.Size = new Size(132, 50);
            btn_cal.TabIndex = 8;
            btn_cal.Text = "Giải";
            btn_cal.UseVisualStyleBackColor = true;
            // 
            // btn_exit
            // 
            btn_exit.Location = new Point(254, 270);
            btn_exit.Name = "btn_exit";
            btn_exit.Size = new Size(132, 50);
            btn_exit.TabIndex = 9;
            btn_exit.Text = "Thoát";
            btn_exit.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(11, 342);
            label5.Name = "label5";
            label5.Size = new Size(63, 20);
            label5.TabIndex = 11;
            label5.Text = "Kết quả:";
            // 
            // textbox_result
            // 
            textbox_result.Location = new Point(80, 339);
            textbox_result.Multiline = true;
            textbox_result.Name = "textbox_result";
            textbox_result.ReadOnly = true;
            textbox_result.Size = new Size(271, 90);
            textbox_result.TabIndex = 10;
            // 
            // Bai8
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(398, 441);
            Controls.Add(label5);
            Controls.Add(textbox_result);
            Controls.Add(btn_exit);
            Controls.Add(btn_cal);
            Controls.Add(label4);
            Controls.Add(textbox_c);
            Controls.Add(label3);
            Controls.Add(textbox_b);
            Controls.Add(label2);
            Controls.Add(textbox_a);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            Name = "Bai8";
            Text = "Form1";
            FormClosing += form_FormClosing;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private GroupBox groupBox1;
        private RadioButton radio_2;
        private RadioButton radio_1;
        private TextBox textbox_a;
        private Label label2;
        private Label label3;
        private TextBox textbox_b;
        private Label label4;
        private TextBox textbox_c;
        private Button btn_cal;
        private Button btn_exit;
        private Label label5;
        private TextBox textbox_result;
    }
}
