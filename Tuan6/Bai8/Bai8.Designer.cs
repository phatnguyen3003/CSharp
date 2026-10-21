namespace Bai8
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
            combobox_MaMH = new ComboBox();
            btn_loc = new Button();
            datagridview_dulieu = new DataGridView();
            STT = new DataGridViewTextBoxColumn();
            TenSV = new DataGridViewTextBoxColumn();
            NgaySinh = new DataGridViewTextBoxColumn();
            TenMonHoc = new DataGridViewTextBoxColumn();
            Diem = new DataGridViewTextBoxColumn();
            label2 = new Label();
            textbox_tongdiem = new TextBox();
            ((System.ComponentModel.ISupportInitialize)datagridview_dulieu).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(76, 41);
            label1.Name = "label1";
            label1.Size = new Size(70, 20);
            label1.TabIndex = 0;
            label1.Text = "Môn Học";
            // 
            // combobox_MaMH
            // 
            combobox_MaMH.FormattingEnabled = true;
            combobox_MaMH.Location = new Point(188, 33);
            combobox_MaMH.Name = "combobox_MaMH";
            combobox_MaMH.Size = new Size(322, 28);
            combobox_MaMH.TabIndex = 1;
            // 
            // btn_loc
            // 
            btn_loc.Location = new Point(555, 33);
            btn_loc.Name = "btn_loc";
            btn_loc.Size = new Size(94, 29);
            btn_loc.TabIndex = 2;
            btn_loc.Text = "Lọc dữ liệu";
            btn_loc.UseVisualStyleBackColor = true;
            // 
            // datagridview_dulieu
            // 
            datagridview_dulieu.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            datagridview_dulieu.Columns.AddRange(new DataGridViewColumn[] { STT, TenSV, NgaySinh, TenMonHoc, Diem });
            datagridview_dulieu.Location = new Point(12, 89);
            datagridview_dulieu.Name = "datagridview_dulieu";
            datagridview_dulieu.RowHeadersWidth = 51;
            datagridview_dulieu.Size = new Size(684, 293);
            datagridview_dulieu.TabIndex = 3;
            // 
            // STT
            // 
            STT.HeaderText = "STT";
            STT.MinimumWidth = 6;
            STT.Name = "STT";
            STT.Width = 125;
            // 
            // TenSV
            // 
            TenSV.HeaderText = "Tên Sinh Viên";
            TenSV.MinimumWidth = 6;
            TenSV.Name = "TenSV";
            TenSV.Width = 125;
            // 
            // NgaySinh
            // 
            NgaySinh.HeaderText = "Ngày Sinh";
            NgaySinh.MinimumWidth = 6;
            NgaySinh.Name = "NgaySinh";
            NgaySinh.Width = 125;
            // 
            // TenMonHoc
            // 
            TenMonHoc.HeaderText = "Tên Môn Học";
            TenMonHoc.MinimumWidth = 6;
            TenMonHoc.Name = "TenMonHoc";
            TenMonHoc.Width = 125;
            // 
            // Diem
            // 
            Diem.HeaderText = "Điểm";
            Diem.MinimumWidth = 6;
            Diem.Name = "Diem";
            Diem.Width = 125;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(432, 406);
            label2.Name = "label2";
            label2.Size = new Size(81, 20);
            label2.TabIndex = 4;
            label2.Text = "Tổng điểm";
            // 
            // textbox_tongdiem
            // 
            textbox_tongdiem.Location = new Point(534, 399);
            textbox_tongdiem.Name = "textbox_tongdiem";
            textbox_tongdiem.ReadOnly = true;
            textbox_tongdiem.Size = new Size(125, 27);
            textbox_tongdiem.TabIndex = 5;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(704, 450);
            Controls.Add(textbox_tongdiem);
            Controls.Add(label2);
            Controls.Add(datagridview_dulieu);
            Controls.Add(btn_loc);
            Controls.Add(combobox_MaMH);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)datagridview_dulieu).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox combobox_MaMH;
        private Button btn_loc;
        private DataGridView datagridview_dulieu;
        private Label label2;
        private TextBox textbox_tongdiem;
        private DataGridViewTextBoxColumn STT;
        private DataGridViewTextBoxColumn TenSV;
        private DataGridViewTextBoxColumn NgaySinh;
        private DataGridViewTextBoxColumn TenMonHoc;
        private DataGridViewTextBoxColumn Diem;
    }
}
