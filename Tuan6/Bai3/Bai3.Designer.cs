namespace Bai3
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
            textbox_MaSV = new TextBox();
            textbox_Diem = new TextBox();
            textbox_MaMH = new TextBox();
            btn_them = new Button();
            btn_sua = new Button();
            btn_xoa = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 18);
            label1.Name = "label1";
            label1.Size = new Size(51, 20);
            label1.TabIndex = 0;
            label1.Text = "Mã SV";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 54);
            label2.Name = "label2";
            label2.Size = new Size(58, 20);
            label2.TabIndex = 1;
            label2.Text = "Mã MH";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 93);
            label3.Name = "label3";
            label3.Size = new Size(45, 20);
            label3.TabIndex = 2;
            label3.Text = "Điểm";
            // 
            // textbox_MaSV
            // 
            textbox_MaSV.Location = new Point(96, 11);
            textbox_MaSV.Name = "textbox_MaSV";
            textbox_MaSV.Size = new Size(295, 27);
            textbox_MaSV.TabIndex = 3;
            // 
            // textbox_Diem
            // 
            textbox_Diem.Location = new Point(96, 86);
            textbox_Diem.Name = "textbox_Diem";
            textbox_Diem.Size = new Size(295, 27);
            textbox_Diem.TabIndex = 4;
            textbox_Diem.KeyPress += textbox_Diem_KeyPress;
            // 
            // textbox_MaMH
            // 
            textbox_MaMH.Location = new Point(96, 47);
            textbox_MaMH.Name = "textbox_MaMH";
            textbox_MaMH.Size = new Size(295, 27);
            textbox_MaMH.TabIndex = 5;
            // 
            // btn_them
            // 
            btn_them.Location = new Point(12, 130);
            btn_them.Name = "btn_them";
            btn_them.Size = new Size(94, 29);
            btn_them.TabIndex = 6;
            btn_them.Text = "Thêm";
            btn_them.UseVisualStyleBackColor = true;
            // 
            // btn_sua
            // 
            btn_sua.Location = new Point(148, 130);
            btn_sua.Name = "btn_sua";
            btn_sua.Size = new Size(94, 29);
            btn_sua.TabIndex = 7;
            btn_sua.Text = "Sửa";
            btn_sua.UseVisualStyleBackColor = true;
            // 
            // btn_xoa
            // 
            btn_xoa.Location = new Point(287, 130);
            btn_xoa.Name = "btn_xoa";
            btn_xoa.Size = new Size(94, 29);
            btn_xoa.TabIndex = 8;
            btn_xoa.Text = "Xóa";
            btn_xoa.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(403, 179);
            Controls.Add(btn_xoa);
            Controls.Add(btn_sua);
            Controls.Add(btn_them);
            Controls.Add(textbox_MaMH);
            Controls.Add(textbox_Diem);
            Controls.Add(textbox_MaSV);
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
        private TextBox textbox_MaSV;
        private TextBox textbox_Diem;
        private TextBox textbox_MaMH;
        private Button btn_them;
        private Button btn_sua;
        private Button btn_xoa;
    }
}
