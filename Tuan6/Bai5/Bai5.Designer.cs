namespace Bai5
{
    partial class Bai5
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
            label4 = new Label();
            combo_MaLop = new ComboBox();
            textbox_MaSV = new TextBox();
            textbox_HoTen = new TextBox();
            maskedtextbox_NgaySinh = new MaskedTextBox();
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
            label1.Size = new Size(34, 20);
            label1.TabIndex = 0;
            label1.Text = "Lớp";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 78);
            label2.Name = "label2";
            label2.Size = new Size(51, 20);
            label2.TabIndex = 1;
            label2.Text = "Mã SV";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 126);
            label3.Name = "label3";
            label3.Size = new Size(56, 20);
            label3.TabIndex = 2;
            label3.Text = "Họ Tên";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 174);
            label4.Name = "label4";
            label4.Size = new Size(76, 20);
            label4.TabIndex = 3;
            label4.Text = "Ngày Sinh";
            // 
            // combo_MaLop
            // 
            combo_MaLop.FormattingEnabled = true;
            combo_MaLop.Location = new Point(120, 17);
            combo_MaLop.Name = "combo_MaLop";
            combo_MaLop.Size = new Size(217, 28);
            combo_MaLop.TabIndex = 4;
            // 
            // textbox_MaSV
            // 
            textbox_MaSV.Location = new Point(120, 71);
            textbox_MaSV.Name = "textbox_MaSV";
            textbox_MaSV.Size = new Size(217, 27);
            textbox_MaSV.TabIndex = 5;
            // 
            // textbox_HoTen
            // 
            textbox_HoTen.Location = new Point(120, 123);
            textbox_HoTen.Name = "textbox_HoTen";
            textbox_HoTen.Size = new Size(217, 27);
            textbox_HoTen.TabIndex = 6;
            // 
            // maskedtextbox_NgaySinh
            // 
            maskedtextbox_NgaySinh.Location = new Point(120, 171);
            maskedtextbox_NgaySinh.Mask = "00/00/0000";
            maskedtextbox_NgaySinh.Name = "maskedtextbox_NgaySinh";
            maskedtextbox_NgaySinh.Size = new Size(217, 27);
            maskedtextbox_NgaySinh.TabIndex = 7;
            maskedtextbox_NgaySinh.ValidatingType = typeof(DateTime);
            // 
            // btn_them
            // 
            btn_them.Location = new Point(12, 222);
            btn_them.Name = "btn_them";
            btn_them.Size = new Size(94, 29);
            btn_them.TabIndex = 8;
            btn_them.Text = "Thêm";
            btn_them.UseVisualStyleBackColor = true;
            // 
            // btn_xoa
            // 
            btn_xoa.Location = new Point(120, 222);
            btn_xoa.Name = "btn_xoa";
            btn_xoa.Size = new Size(94, 29);
            btn_xoa.TabIndex = 9;
            btn_xoa.Text = "Xóa";
            btn_xoa.UseVisualStyleBackColor = true;
            // 
            // btn_sua
            // 
            btn_sua.Location = new Point(243, 222);
            btn_sua.Name = "btn_sua";
            btn_sua.Size = new Size(94, 29);
            btn_sua.TabIndex = 10;
            btn_sua.Text = "Sửa";
            btn_sua.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(349, 289);
            Controls.Add(btn_sua);
            Controls.Add(btn_xoa);
            Controls.Add(btn_them);
            Controls.Add(maskedtextbox_NgaySinh);
            Controls.Add(textbox_HoTen);
            Controls.Add(textbox_MaSV);
            Controls.Add(combo_MaLop);
            Controls.Add(label4);
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
        private Label label4;
        private ComboBox combo_MaLop;
        private TextBox textbox_MaSV;
        private TextBox textbox_HoTen;
        private MaskedTextBox maskedtextbox_NgaySinh;
        private Button btn_them;
        private Button btn_xoa;
        private Button btn_sua;
    }
}
