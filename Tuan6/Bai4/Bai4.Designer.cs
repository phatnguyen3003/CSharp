namespace Bai4
{
    partial class Bai4
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
            textbox_MaKhoa = new TextBox();
            label1 = new Label();
            label2 = new Label();
            textbox_MaLop = new TextBox();
            label3 = new Label();
            textbox_TenLop = new TextBox();
            btn_them = new Button();
            btn_xoa = new Button();
            btn_sua = new Button();
            SuspendLayout();
            // 
            // textbox_MaKhoa
            // 
            textbox_MaKhoa.Location = new Point(121, 23);
            textbox_MaKhoa.Name = "textbox_MaKhoa";
            textbox_MaKhoa.Size = new Size(268, 27);
            textbox_MaKhoa.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(31, 30);
            label1.Name = "label1";
            label1.Size = new Size(68, 20);
            label1.TabIndex = 1;
            label1.Text = "Mã Khoa";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(31, 82);
            label2.Name = "label2";
            label2.Size = new Size(56, 20);
            label2.TabIndex = 3;
            label2.Text = "Mã lớp";
            // 
            // textbox_MaLop
            // 
            textbox_MaLop.Location = new Point(121, 75);
            textbox_MaLop.Name = "textbox_MaLop";
            textbox_MaLop.Size = new Size(268, 27);
            textbox_MaLop.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(31, 135);
            label3.Name = "label3";
            label3.Size = new Size(58, 20);
            label3.TabIndex = 5;
            label3.Text = "Tên lớp";
            // 
            // textbox_TenLop
            // 
            textbox_TenLop.Location = new Point(121, 128);
            textbox_TenLop.Name = "textbox_TenLop";
            textbox_TenLop.Size = new Size(268, 27);
            textbox_TenLop.TabIndex = 4;
            // 
            // btn_them
            // 
            btn_them.Location = new Point(31, 209);
            btn_them.Name = "btn_them";
            btn_them.Size = new Size(94, 29);
            btn_them.TabIndex = 6;
            btn_them.Text = "Thêm";
            btn_them.UseVisualStyleBackColor = true;
            // 
            // btn_xoa
            // 
            btn_xoa.Location = new Point(156, 209);
            btn_xoa.Name = "btn_xoa";
            btn_xoa.Size = new Size(94, 29);
            btn_xoa.TabIndex = 7;
            btn_xoa.Text = "Xóa";
            btn_xoa.UseVisualStyleBackColor = true;
            // 
            // btn_sua
            // 
            btn_sua.Location = new Point(285, 209);
            btn_sua.Name = "btn_sua";
            btn_sua.Size = new Size(94, 29);
            btn_sua.TabIndex = 8;
            btn_sua.Text = "Sửa";
            btn_sua.UseVisualStyleBackColor = true;
            // 
            // Bai4
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(401, 276);
            Controls.Add(btn_sua);
            Controls.Add(btn_xoa);
            Controls.Add(btn_them);
            Controls.Add(label3);
            Controls.Add(textbox_TenLop);
            Controls.Add(label2);
            Controls.Add(textbox_MaLop);
            Controls.Add(label1);
            Controls.Add(textbox_MaKhoa);
            Name = "Bai4";
            Text = "Form1";
            Load += Form_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textbox_MaKhoa;
        private Label label1;
        private Label label2;
        private TextBox textbox_MaLop;
        private Label label3;
        private TextBox textbox_TenLop;
        private Button btn_them;
        private Button btn_xoa;
        private Button btn_sua;
    }
}
