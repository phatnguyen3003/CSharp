namespace Bai9
{
    partial class BanHang
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
            button1 = new Button();
            groupBox1 = new GroupBox();
            label1 = new Label();
            textbox_maHD = new TextBox();
            label2 = new Label();
            combobox_MaSP = new ComboBox();
            label3 = new Label();
            textbox_SoLuong = new TextBox();
            btn_them = new Button();
            btn_huy = new Button();
            btn_thanhtoan = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(224, 30);
            button1.Name = "button1";
            button1.Size = new Size(168, 44);
            button1.TabIndex = 0;
            button1.Text = "Tạo hóa đơn mới";
            button1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btn_huy);
            groupBox1.Controls.Add(btn_them);
            groupBox1.Controls.Add(textbox_SoLuong);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(combobox_MaSP);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(textbox_maHD);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 100);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(380, 202);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Chi tiết hóa đơn";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 38);
            label1.Name = "label1";
            label1.Size = new Size(89, 20);
            label1.TabIndex = 0;
            label1.Text = "Mã hóa đơn";
            // 
            // textbox_maHD
            // 
            textbox_maHD.Location = new Point(125, 31);
            textbox_maHD.Name = "textbox_maHD";
            textbox_maHD.Size = new Size(249, 27);
            textbox_maHD.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 76);
            label2.Name = "label2";
            label2.Size = new Size(99, 20);
            label2.TabIndex = 2;
            label2.Text = "Mã Sản Phẩm";
            // 
            // combobox_MaSP
            // 
            combobox_MaSP.FormattingEnabled = true;
            combobox_MaSP.Location = new Point(125, 68);
            combobox_MaSP.Name = "combobox_MaSP";
            combobox_MaSP.Size = new Size(249, 28);
            combobox_MaSP.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 114);
            label3.Name = "label3";
            label3.Size = new Size(69, 20);
            label3.TabIndex = 4;
            label3.Text = "Số lượng";
            // 
            // textbox_SoLuong
            // 
            textbox_SoLuong.Location = new Point(125, 107);
            textbox_SoLuong.Name = "textbox_SoLuong";
            textbox_SoLuong.Size = new Size(249, 27);
            textbox_SoLuong.TabIndex = 5;
            // 
            // btn_them
            // 
            btn_them.Location = new Point(136, 157);
            btn_them.Name = "btn_them";
            btn_them.Size = new Size(94, 29);
            btn_them.TabIndex = 6;
            btn_them.Text = "Thêm";
            btn_them.UseVisualStyleBackColor = true;
            // 
            // btn_huy
            // 
            btn_huy.Location = new Point(265, 157);
            btn_huy.Name = "btn_huy";
            btn_huy.Size = new Size(94, 29);
            btn_huy.TabIndex = 7;
            btn_huy.Text = "Hủy";
            btn_huy.UseVisualStyleBackColor = true;
            // 
            // btn_thanhtoan
            // 
            btn_thanhtoan.Location = new Point(251, 354);
            btn_thanhtoan.Name = "btn_thanhtoan";
            btn_thanhtoan.Size = new Size(135, 29);
            btn_thanhtoan.TabIndex = 2;
            btn_thanhtoan.Text = "Thanh toán";
            btn_thanhtoan.UseVisualStyleBackColor = true;
            // 
            // BanHang
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(407, 422);
            Controls.Add(btn_thanhtoan);
            Controls.Add(groupBox1);
            Controls.Add(button1);
            Name = "BanHang";
            Text = "BanHang";
            Load += BanHang_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private GroupBox groupBox1;
        private TextBox textbox_SoLuong;
        private Label label3;
        private ComboBox combobox_MaSP;
        private Label label2;
        private TextBox textbox_maHD;
        private Label label1;
        private Button btn_huy;
        private Button btn_them;
        private Button btn_thanhtoan;
    }
}