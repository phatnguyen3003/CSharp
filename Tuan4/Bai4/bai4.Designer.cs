namespace Bai4;

partial class bai4
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
        textbox_nhapso = new TextBox();
        btn_nhap = new Button();
        textbox_day = new TextBox();
        label3 = new Label();
        textbox_tong = new TextBox();
        label4 = new Label();
        textbox_tong_chan = new TextBox();
        label5 = new Label();
        label6 = new Label();
        btn_tinh_tat = new Button();
        btn_tong_chan = new Button();
        btn_tong_le = new Button();
        textbox_tong_le = new TextBox();
        btn_tiep_tuc = new Button();
        btn_thoat = new Button();
        SuspendLayout();
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 163);
        label1.ForeColor = Color.Red;
        label1.Location = new Point(107, 9);
        label1.Name = "label1";
        label1.Size = new Size(419, 46);
        label1.TabIndex = 0;
        label1.Text = "Nhập dãy số và tính tổng";
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(51, 87);
        label2.Name = "label2";
        label2.Size = new Size(67, 20);
        label2.TabIndex = 1;
        label2.Text = "Nhập số:";
        // 
        // textbox_nhapso
        // 
        textbox_nhapso.Location = new Point(124, 80);
        textbox_nhapso.Name = "textbox_nhapso";
        textbox_nhapso.Size = new Size(367, 27);
        textbox_nhapso.TabIndex = 2;
        // 
        // btn_nhap
        // 
        btn_nhap.Location = new Point(510, 75);
        btn_nhap.Name = "btn_nhap";
        btn_nhap.Size = new Size(80, 32);
        btn_nhap.TabIndex = 3;
        btn_nhap.Text = "Nhập";
        btn_nhap.UseVisualStyleBackColor = true;
        btn_nhap.Click += btn_nhap_Click;
        // 
        // textbox_day
        // 
        textbox_day.Location = new Point(160, 139);
        textbox_day.Name = "textbox_day";
        textbox_day.ReadOnly = true;
        textbox_day.Size = new Size(430, 27);
        textbox_day.TabIndex = 5;
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.Location = new Point(51, 146);
        label3.Name = "label3";
        label3.Size = new Size(103, 20);
        label3.TabIndex = 4;
        label3.Text = "Dãy vừa nhập:";
        // 
        // textbox_tong
        // 
        textbox_tong.Location = new Point(317, 185);
        textbox_tong.Name = "textbox_tong";
        textbox_tong.ReadOnly = true;
        textbox_tong.Size = new Size(273, 27);
        textbox_tong.TabIndex = 7;
        // 
        // label4
        // 
        label4.AutoSize = true;
        label4.Location = new Point(51, 192);
        label4.Name = "label4";
        label4.Size = new Size(260, 20);
        label4.TabIndex = 6;
        label4.Text = "Tổng các phần tử trong dãy vừa nhập:";
        // 
        // textbox_tong_chan
        // 
        textbox_tong_chan.Location = new Point(138, 246);
        textbox_tong_chan.Name = "textbox_tong_chan";
        textbox_tong_chan.ReadOnly = true;
        textbox_tong_chan.Size = new Size(173, 27);
        textbox_tong_chan.TabIndex = 9;
        // 
        // label5
        // 
        label5.AutoSize = true;
        label5.Location = new Point(51, 253);
        label5.Name = "label5";
        label5.Size = new Size(81, 20);
        label5.TabIndex = 8;
        label5.Text = "Tổng chẵn:";
        // 
        // label6
        // 
        label6.AutoSize = true;
        label6.Location = new Point(347, 253);
        label6.Name = "label6";
        label6.Size = new Size(62, 20);
        label6.TabIndex = 10;
        label6.Text = "Tổng lẻ:";
        // 
        // btn_tinh_tat
        // 
        btn_tinh_tat.Location = new Point(12, 294);
        btn_tinh_tat.Name = "btn_tinh_tat";
        btn_tinh_tat.Size = new Size(89, 42);
        btn_tinh_tat.TabIndex = 12;
        btn_tinh_tat.Text = "Tính tất cả";
        btn_tinh_tat.UseVisualStyleBackColor = true;
        btn_tinh_tat.Click += btn_tinh_tat_Click;
        // 
        // btn_tong_chan
        // 
        btn_tong_chan.Location = new Point(107, 294);
        btn_tong_chan.Name = "btn_tong_chan";
        btn_tong_chan.Size = new Size(115, 42);
        btn_tong_chan.TabIndex = 13;
        btn_tong_chan.Text = "Tính tổng chẵn";
        btn_tong_chan.UseVisualStyleBackColor = true;
        // 
        // btn_tong_le
        // 
        btn_tong_le.Location = new Point(230, 294);
        btn_tong_le.Name = "btn_tong_le";
        btn_tong_le.Size = new Size(115, 42);
        btn_tong_le.TabIndex = 14;
        btn_tong_le.Text = "Tính tổng lẻ";
        btn_tong_le.UseVisualStyleBackColor = true;
        // 
        // textbox_tong_le
        // 
        textbox_tong_le.Location = new Point(434, 246);
        textbox_tong_le.Name = "textbox_tong_le";
        textbox_tong_le.ReadOnly = true;
        textbox_tong_le.Size = new Size(156, 27);
        textbox_tong_le.TabIndex = 11;
        // 
        // btn_tiep_tuc
        // 
        btn_tiep_tuc.Location = new Point(351, 294);
        btn_tiep_tuc.Name = "btn_tiep_tuc";
        btn_tiep_tuc.Size = new Size(115, 42);
        btn_tiep_tuc.TabIndex = 15;
        btn_tiep_tuc.Text = "Tiếp tục";
        btn_tiep_tuc.UseVisualStyleBackColor = true;
        btn_tiep_tuc.Click += btn_tiep_tuc_Click;
        // 
        // btn_thoat
        // 
        btn_thoat.Location = new Point(472, 294);
        btn_thoat.Name = "btn_thoat";
        btn_thoat.Size = new Size(115, 42);
        btn_thoat.TabIndex = 16;
        btn_thoat.Text = "Thoát";
        btn_thoat.UseVisualStyleBackColor = true;
        // 
        // bai4
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(629, 348);
        Controls.Add(btn_thoat);
        Controls.Add(btn_tiep_tuc);
        Controls.Add(btn_tong_le);
        Controls.Add(btn_tong_chan);
        Controls.Add(btn_tinh_tat);
        Controls.Add(textbox_tong_le);
        Controls.Add(label6);
        Controls.Add(textbox_tong_chan);
        Controls.Add(label5);
        Controls.Add(textbox_tong);
        Controls.Add(label4);
        Controls.Add(textbox_day);
        Controls.Add(label3);
        Controls.Add(btn_nhap);
        Controls.Add(textbox_nhapso);
        Controls.Add(label2);
        Controls.Add(label1);
        Name = "bai4";
        Text = "Form1";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label label1;
    private Label label2;
    private TextBox textbox_nhapso;
    private Button btn_nhap;
    private TextBox textbox_day;
    private Label label3;
    private TextBox textbox_tong;
    private Label label4;
    private TextBox textbox_tong_chan;
    private Label label5;
    private Label label6;
    private Button btn_tinh_tat;
    private Button btn_tong_chan;
    private Button btn_tong_le;
    private TextBox textbox_tong_le;
    private Button btn_tiep_tuc;
    private Button btn_thoat;
}
