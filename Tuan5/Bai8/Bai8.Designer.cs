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
            textbox_number = new TextBox();
            textbox_name = new TextBox();
            textbox_living_place = new TextBox();
            textbox_number_of_cash = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            btn_exit = new Button();
            btn_delete = new Button();
            btn_save = new Button();
            btn_add = new Button();
            datagridview = new DataGridView();
            STT = new DataGridViewTextBoxColumn();
            SoTaiKhoan = new DataGridViewTextBoxColumn();
            TenKhachHang = new DataGridViewTextBoxColumn();
            DiaChi = new DataGridViewTextBoxColumn();
            SoTien = new DataGridViewTextBoxColumn();
            textbox_total = new TextBox();
            label6 = new Label();
            ((System.ComponentModel.ISupportInitialize)datagridview).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label1.ForeColor = SystemColors.Highlight;
            label1.Location = new Point(42, 5);
            label1.Name = "label1";
            label1.Size = new Size(660, 54);
            label1.TabIndex = 0;
            label1.Text = "QUẢN LÝ THÔNG TIN TÀI KHOẢN";
            // 
            // textbox_number
            // 
            textbox_number.Location = new Point(267, 75);
            textbox_number.Name = "textbox_number";
            textbox_number.Size = new Size(419, 27);
            textbox_number.TabIndex = 1;
            // 
            // textbox_name
            // 
            textbox_name.Location = new Point(267, 120);
            textbox_name.Name = "textbox_name";
            textbox_name.Size = new Size(419, 27);
            textbox_name.TabIndex = 2;
            // 
            // textbox_living_place
            // 
            textbox_living_place.Location = new Point(267, 167);
            textbox_living_place.Name = "textbox_living_place";
            textbox_living_place.Size = new Size(419, 27);
            textbox_living_place.TabIndex = 3;
            // 
            // textbox_number_of_cash
            // 
            textbox_number_of_cash.Location = new Point(267, 214);
            textbox_number_of_cash.Name = "textbox_number_of_cash";
            textbox_number_of_cash.Size = new Size(419, 27);
            textbox_number_of_cash.TabIndex = 4;
            textbox_number_of_cash.KeyPress += textbox_number_of_cash_KeyPress;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(170, 82);
            label2.Name = "label2";
            label2.Size = new Size(91, 20);
            label2.TabIndex = 5;
            label2.Text = "Số tài khoản";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(150, 127);
            label3.Name = "label3";
            label3.Size = new Size(111, 20);
            label3.TabIndex = 6;
            label3.Text = "Tên khách hàng";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(127, 174);
            label4.Name = "label4";
            label4.Size = new Size(134, 20);
            label4.TabIndex = 7;
            label4.Text = "Địa chỉ khách hàng";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(101, 221);
            label5.Name = "label5";
            label5.Size = new Size(160, 20);
            label5.TabIndex = 8;
            label5.Text = "Số tiền trong tài khoản";
            // 
            // btn_exit
            // 
            btn_exit.Location = new Point(592, 257);
            btn_exit.Name = "btn_exit";
            btn_exit.Size = new Size(94, 29);
            btn_exit.TabIndex = 9;
            btn_exit.Text = "Thoát";
            btn_exit.UseVisualStyleBackColor = true;
            // 
            // btn_delete
            // 
            btn_delete.Location = new Point(492, 257);
            btn_delete.Name = "btn_delete";
            btn_delete.Size = new Size(94, 29);
            btn_delete.TabIndex = 10;
            btn_delete.Text = "Xóa";
            btn_delete.UseVisualStyleBackColor = true;
            // 
            // btn_save
            // 
            btn_save.Location = new Point(392, 257);
            btn_save.Name = "btn_save";
            btn_save.Size = new Size(94, 29);
            btn_save.TabIndex = 11;
            btn_save.Text = "Lưu";
            btn_save.UseVisualStyleBackColor = true;
            // 
            // btn_add
            // 
            btn_add.Location = new Point(292, 257);
            btn_add.Name = "btn_add";
            btn_add.Size = new Size(94, 29);
            btn_add.TabIndex = 12;
            btn_add.Text = "Thêm";
            btn_add.UseVisualStyleBackColor = true;
            // 
            // datagridview
            // 
            datagridview.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            datagridview.Columns.AddRange(new DataGridViewColumn[] { STT, SoTaiKhoan, TenKhachHang, DiaChi, SoTien });
            datagridview.Location = new Point(6, 292);
            datagridview.Name = "datagridview";
            datagridview.RowHeadersWidth = 51;
            datagridview.Size = new Size(680, 154);
            datagridview.TabIndex = 13;
            // 
            // STT
            // 
            STT.HeaderText = "STT";
            STT.MinimumWidth = 6;
            STT.Name = "STT";
            STT.Width = 125;
            // 
            // SoTaiKhoan
            // 
            SoTaiKhoan.HeaderText = "Số tài khoản";
            SoTaiKhoan.MinimumWidth = 6;
            SoTaiKhoan.Name = "SoTaiKhoan";
            SoTaiKhoan.Width = 125;
            // 
            // TenKhachHang
            // 
            TenKhachHang.HeaderText = "Tên khách hàng";
            TenKhachHang.MinimumWidth = 6;
            TenKhachHang.Name = "TenKhachHang";
            TenKhachHang.Width = 125;
            // 
            // DiaChi
            // 
            DiaChi.HeaderText = "Địa chỉ";
            DiaChi.MinimumWidth = 6;
            DiaChi.Name = "DiaChi";
            DiaChi.Width = 125;
            // 
            // SoTien
            // 
            SoTien.HeaderText = "Số tiền";
            SoTien.MinimumWidth = 6;
            SoTien.Name = "SoTien";
            SoTien.Width = 125;
            // 
            // textbox_total
            // 
            textbox_total.Location = new Point(513, 458);
            textbox_total.Name = "textbox_total";
            textbox_total.Size = new Size(172, 27);
            textbox_total.TabIndex = 14;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(435, 465);
            label6.Name = "label6";
            label6.Size = new Size(72, 20);
            label6.TabIndex = 15;
            label6.Text = "Tổng tiền";
            // 
            // Bai8
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(697, 497);
            Controls.Add(label6);
            Controls.Add(textbox_total);
            Controls.Add(datagridview);
            Controls.Add(btn_add);
            Controls.Add(btn_save);
            Controls.Add(btn_delete);
            Controls.Add(btn_exit);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(textbox_number_of_cash);
            Controls.Add(textbox_living_place);
            Controls.Add(textbox_name);
            Controls.Add(textbox_number);
            Controls.Add(label1);
            Name = "Bai8";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)datagridview).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textbox_number;
        private TextBox textbox_name;
        private TextBox textbox_living_place;
        private TextBox textbox_number_of_cash;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button btn_exit;
        private Button btn_delete;
        private Button btn_save;
        private Button btn_add;
        private DataGridView datagridview;
        private DataGridViewTextBoxColumn STT;
        private DataGridViewTextBoxColumn SoTaiKhoan;
        private DataGridViewTextBoxColumn TenKhachHang;
        private DataGridViewTextBoxColumn DiaChi;
        private DataGridViewTextBoxColumn SoTien;
        private TextBox textbox_total;
        private Label label6;
    }
}
