namespace Bai7
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
            TextBox_name = new TextBox();
            TextBox_mssv = new TextBox();
            label2 = new Label();
            label3 = new Label();
            panel1 = new Panel();
            Radio_nu = new RadioButton();
            Radio_Nam = new RadioButton();
            panel2 = new Panel();
            CheckBox_hoa = new CheckBox();
            CheckBox_phap = new CheckBox();
            CheckBox_anh = new CheckBox();
            label4 = new Label();
            label5 = new Label();
            Combo_dantoc = new ComboBox();
            dataGridView1 = new DataGridView();
            HoTen = new DataGridViewTextBoxColumn();
            MaSV = new DataGridViewTextBoxColumn();
            GioiTinh = new DataGridViewTextBoxColumn();
            NgoaiNgu = new DataGridViewTextBoxColumn();
            DanToc = new DataGridViewTextBoxColumn();
            btn_them = new Button();
            btn_xoa = new Button();
            btn_sua = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(213, 21);
            label1.Name = "label1";
            label1.Size = new Size(73, 20);
            label1.TabIndex = 0;
            label1.Text = "Họ và tên";
            // 
            // TextBox_name
            // 
            TextBox_name.Location = new Point(310, 14);
            TextBox_name.Name = "TextBox_name";
            TextBox_name.Size = new Size(189, 27);
            TextBox_name.TabIndex = 1;
            // 
            // TextBox_mssv
            // 
            TextBox_mssv.Location = new Point(310, 60);
            TextBox_mssv.Name = "TextBox_mssv";
            TextBox_mssv.Size = new Size(189, 27);
            TextBox_mssv.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(213, 67);
            label2.Name = "label2";
            label2.Size = new Size(91, 20);
            label2.TabIndex = 2;
            label2.Text = "Mã sinh viên";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(3, 11);
            label3.Name = "label3";
            label3.Size = new Size(65, 20);
            label3.TabIndex = 4;
            label3.Text = "Giới tính";
            // 
            // panel1
            // 
            panel1.Controls.Add(Radio_nu);
            panel1.Controls.Add(Radio_Nam);
            panel1.Controls.Add(label3);
            panel1.Location = new Point(213, 118);
            panel1.Name = "panel1";
            panel1.Size = new Size(286, 42);
            panel1.TabIndex = 5;
            // 
            // Radio_nu
            // 
            Radio_nu.AutoSize = true;
            Radio_nu.Location = new Point(233, 9);
            Radio_nu.Name = "Radio_nu";
            Radio_nu.Size = new Size(50, 24);
            Radio_nu.TabIndex = 6;
            Radio_nu.Text = "Nữ";
            Radio_nu.UseVisualStyleBackColor = true;
            // 
            // Radio_Nam
            // 
            Radio_Nam.AutoSize = true;
            Radio_Nam.Checked = true;
            Radio_Nam.Location = new Point(108, 9);
            Radio_Nam.Name = "Radio_Nam";
            Radio_Nam.Size = new Size(62, 24);
            Radio_Nam.TabIndex = 5;
            Radio_Nam.TabStop = true;
            Radio_Nam.Text = "Nam";
            Radio_Nam.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            panel2.Controls.Add(CheckBox_hoa);
            panel2.Controls.Add(CheckBox_phap);
            panel2.Controls.Add(CheckBox_anh);
            panel2.Controls.Add(label4);
            panel2.Location = new Point(213, 185);
            panel2.Name = "panel2";
            panel2.Size = new Size(286, 40);
            panel2.TabIndex = 6;
            // 
            // CheckBox_hoa
            // 
            CheckBox_hoa.AutoSize = true;
            CheckBox_hoa.Location = new Point(224, 10);
            CheckBox_hoa.Name = "CheckBox_hoa";
            CheckBox_hoa.Size = new Size(59, 24);
            CheckBox_hoa.TabIndex = 3;
            CheckBox_hoa.Text = "Hoa";
            CheckBox_hoa.UseVisualStyleBackColor = true;
            // 
            // CheckBox_phap
            // 
            CheckBox_phap.AutoSize = true;
            CheckBox_phap.Location = new Point(154, 10);
            CheckBox_phap.Name = "CheckBox_phap";
            CheckBox_phap.Size = new Size(64, 24);
            CheckBox_phap.TabIndex = 2;
            CheckBox_phap.Text = "Pháp";
            CheckBox_phap.UseVisualStyleBackColor = true;
            // 
            // CheckBox_anh
            // 
            CheckBox_anh.AutoSize = true;
            CheckBox_anh.Location = new Point(91, 10);
            CheckBox_anh.Name = "CheckBox_anh";
            CheckBox_anh.Size = new Size(57, 24);
            CheckBox_anh.TabIndex = 1;
            CheckBox_anh.Text = "Anh";
            CheckBox_anh.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(0, 10);
            label4.Name = "label4";
            label4.Size = new Size(80, 20);
            label4.TabIndex = 0;
            label4.Text = "Ngoại ngữ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(213, 245);
            label5.Name = "label5";
            label5.Size = new Size(61, 20);
            label5.TabIndex = 7;
            label5.Text = "Dân tộc";
            // 
            // Combo_dantoc
            // 
            Combo_dantoc.FormattingEnabled = true;
            Combo_dantoc.Location = new Point(293, 237);
            Combo_dantoc.Name = "Combo_dantoc";
            Combo_dantoc.Size = new Size(206, 28);
            Combo_dantoc.TabIndex = 8;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { HoTen, MaSV, GioiTinh, NgoaiNgu, DanToc });
            dataGridView1.Location = new Point(12, 271);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(681, 195);
            dataGridView1.TabIndex = 9;
            // 
            // HoTen
            // 
            HoTen.HeaderText = "Họ Tên";
            HoTen.MinimumWidth = 6;
            HoTen.Name = "HoTen";
            HoTen.Width = 125;
            // 
            // MaSV
            // 
            MaSV.HeaderText = "Mã Sinh Viên";
            MaSV.MinimumWidth = 6;
            MaSV.Name = "MaSV";
            MaSV.Width = 125;
            // 
            // GioiTinh
            // 
            GioiTinh.HeaderText = "Giới Tính";
            GioiTinh.MinimumWidth = 6;
            GioiTinh.Name = "GioiTinh";
            GioiTinh.Width = 125;
            // 
            // NgoaiNgu
            // 
            NgoaiNgu.HeaderText = "Ngoại Ngữ";
            NgoaiNgu.MinimumWidth = 6;
            NgoaiNgu.Name = "NgoaiNgu";
            NgoaiNgu.Width = 125;
            // 
            // DanToc
            // 
            DanToc.HeaderText = "Dân Tộc";
            DanToc.MinimumWidth = 6;
            DanToc.Name = "DanToc";
            DanToc.Width = 125;
            // 
            // btn_them
            // 
            btn_them.Location = new Point(96, 473);
            btn_them.Name = "btn_them";
            btn_them.Size = new Size(94, 29);
            btn_them.TabIndex = 10;
            btn_them.Text = "➕Thêm";
            btn_them.UseVisualStyleBackColor = true;
            // 
            // btn_xoa
            // 
            btn_xoa.Location = new Point(321, 473);
            btn_xoa.Name = "btn_xoa";
            btn_xoa.Size = new Size(94, 29);
            btn_xoa.TabIndex = 11;
            btn_xoa.Text = "❌Xóa";
            btn_xoa.UseVisualStyleBackColor = true;
            // 
            // btn_sua
            // 
            btn_sua.Location = new Point(529, 473);
            btn_sua.Name = "btn_sua";
            btn_sua.Size = new Size(94, 29);
            btn_sua.TabIndex = 12;
            btn_sua.Text = "⚙️ Sửa";
            btn_sua.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(763, 514);
            Controls.Add(btn_sua);
            Controls.Add(btn_xoa);
            Controls.Add(btn_them);
            Controls.Add(dataGridView1);
            Controls.Add(Combo_dantoc);
            Controls.Add(label5);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(TextBox_mssv);
            Controls.Add(label2);
            Controls.Add(TextBox_name);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Bai7";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox TextBox_name;
        private TextBox TextBox_mssv;
        private Label label2;
        private Label label3;
        private Panel panel1;
        private RadioButton Radio_nu;
        private RadioButton Radio_Nam;
        private Panel panel2;
        private CheckBox CheckBox_hoa;
        private CheckBox CheckBox_phap;
        private CheckBox CheckBox_anh;
        private Label label4;
        private Label label5;
        private ComboBox Combo_dantoc;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn HoTen;
        private DataGridViewTextBoxColumn MaSV;
        private DataGridViewTextBoxColumn GioiTinh;
        private DataGridViewTextBoxColumn NgoaiNgu;
        private DataGridViewTextBoxColumn DanToc;
        private Button btn_them;
        private Button btn_xoa;
        private Button btn_sua;
    }
}
