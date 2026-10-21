namespace Bai6
{
    partial class Form1
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
            label2 = new Label();
            label3 = new Label();
            combobox_MaSV = new ComboBox();
            combobox_MaMH = new ComboBox();
            textbox_Diem = new TextBox();
            btn_them = new Button();
            btn_xoa = new Button();
            btn_sua = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 25);
            label1.Name = "label1";
            label1.Size = new Size(70, 20);
            label1.TabIndex = 0;
            label1.Text = "Sinh Viên";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 86);
            label2.Name = "label2";
            label2.Size = new Size(70, 20);
            label2.TabIndex = 1;
            label2.Text = "Môn Học";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 151);
            label3.Name = "label3";
            label3.Size = new Size(45, 20);
            label3.TabIndex = 2;
            label3.Text = "Điểm";
            // 
            // combobox_MaSV
            // 
            combobox_MaSV.FormattingEnabled = true;
            combobox_MaSV.Location = new Point(105, 17);
            combobox_MaSV.Name = "combobox_MaSV";
            combobox_MaSV.Size = new Size(241, 28);
            combobox_MaSV.TabIndex = 3;
            // 
            // combobox_MaMH
            // 
            combobox_MaMH.FormattingEnabled = true;
            combobox_MaMH.Location = new Point(105, 78);
            combobox_MaMH.Name = "combobox_MaMH";
            combobox_MaMH.Size = new Size(241, 28);
            combobox_MaMH.TabIndex = 4;
            // 
            // textbox_Diem
            // 
            textbox_Diem.Location = new Point(105, 144);
            textbox_Diem.Name = "textbox_Diem";
            textbox_Diem.Size = new Size(241, 27);
            textbox_Diem.TabIndex = 5;
            textbox_Diem.KeyPress += textbox_Diem_KeyPress;
            // 
            // btn_them
            // 
            btn_them.Location = new Point(12, 195);
            btn_them.Name = "btn_them";
            btn_them.Size = new Size(94, 29);
            btn_them.TabIndex = 6;
            btn_them.Text = "Thêm";
            btn_them.UseVisualStyleBackColor = true;
            // 
            // btn_xoa
            // 
            btn_xoa.Location = new Point(132, 195);
            btn_xoa.Name = "btn_xoa";
            btn_xoa.Size = new Size(94, 29);
            btn_xoa.TabIndex = 7;
            btn_xoa.Text = "Xóa";
            btn_xoa.UseVisualStyleBackColor = true;
            // 
            // btn_sua
            // 
            btn_sua.Location = new Point(252, 195);
            btn_sua.Name = "btn_sua";
            btn_sua.Size = new Size(94, 29);
            btn_sua.TabIndex = 8;
            btn_sua.Text = "Sửa";
            btn_sua.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(358, 262);
            Controls.Add(btn_sua);
            Controls.Add(btn_xoa);
            Controls.Add(btn_them);
            Controls.Add(textbox_Diem);
            Controls.Add(combobox_MaMH);
            Controls.Add(combobox_MaSV);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private ComboBox combobox_MaSV;
        private ComboBox combobox_MaMH;
        private TextBox textbox_Diem;
        private Button btn_them;
        private Button btn_xoa;
        private Button btn_sua;
    }
}
