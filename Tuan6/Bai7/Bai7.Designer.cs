namespace Bai7
{
    partial class Bai7
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
            datagridview_Lop = new DataGridView();
            btn_hienthi = new Button();
            btn_thoat = new Button();
            STT = new DataGridViewTextBoxColumn();
            MaLop = new DataGridViewTextBoxColumn();
            TenLop = new DataGridViewTextBoxColumn();
            MaKhoa = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)datagridview_Lop).BeginInit();
            SuspendLayout();
            // 
            // datagridview_Lop
            // 
            datagridview_Lop.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            datagridview_Lop.Columns.AddRange(new DataGridViewColumn[] { STT, MaLop, TenLop, MaKhoa });
            datagridview_Lop.Location = new Point(12, 51);
            datagridview_Lop.Name = "datagridview_Lop";
            datagridview_Lop.RowHeadersWidth = 51;
            datagridview_Lop.Size = new Size(559, 333);
            datagridview_Lop.TabIndex = 0;
            // 
            // btn_hienthi
            // 
            btn_hienthi.Location = new Point(12, 16);
            btn_hienthi.Name = "btn_hienthi";
            btn_hienthi.Size = new Size(166, 29);
            btn_hienthi.TabIndex = 1;
            btn_hienthi.Text = "Hiển thị dữ liệu";
            btn_hienthi.UseVisualStyleBackColor = true;
            // 
            // btn_thoat
            // 
            btn_thoat.Location = new Point(435, 390);
            btn_thoat.Name = "btn_thoat";
            btn_thoat.Size = new Size(120, 48);
            btn_thoat.TabIndex = 2;
            btn_thoat.Text = "Thoát";
            btn_thoat.UseVisualStyleBackColor = true;
            // 
            // STT
            // 
            STT.HeaderText = "STT";
            STT.MinimumWidth = 6;
            STT.Name = "STT";
            STT.Width = 125;
            // 
            // MaLop
            // 
            MaLop.HeaderText = "Mã Lớp";
            MaLop.MinimumWidth = 6;
            MaLop.Name = "MaLop";
            MaLop.Width = 125;
            // 
            // TenLop
            // 
            TenLop.HeaderText = "Tên Lớp";
            TenLop.MinimumWidth = 6;
            TenLop.Name = "TenLop";
            TenLop.Width = 125;
            // 
            // MaKhoa
            // 
            MaKhoa.HeaderText = "Mã Khoa";
            MaKhoa.MinimumWidth = 6;
            MaKhoa.Name = "MaKhoa";
            MaKhoa.Width = 125;
            // 
            // Bai7
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(596, 450);
            Controls.Add(btn_thoat);
            Controls.Add(btn_hienthi);
            Controls.Add(datagridview_Lop);
            Name = "Bai7";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)datagridview_Lop).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView datagridview_Lop;
        private Button btn_hienthi;
        private Button btn_thoat;
        private DataGridViewTextBoxColumn STT;
        private DataGridViewTextBoxColumn MaLop;
        private DataGridViewTextBoxColumn TenLop;
        private DataGridViewTextBoxColumn MaKhoa;
    }
}
