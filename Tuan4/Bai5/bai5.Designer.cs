namespace Bai5;

partial class bai5
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
        textbox_nhap = new TextBox();
        btn_thuchien = new Button();
        btn_xoa = new Button();
        btn_thoat = new Button();
        textbox_xuat = new TextBox();
        SuspendLayout();
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 163);
        label1.ForeColor = Color.Red;
        label1.Location = new Point(12, 9);
        label1.Name = "label1";
        label1.Size = new Size(261, 41);
        label1.TabIndex = 0;
        label1.Text = "Đọc số thành chữ";
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(12, 117);
        label2.Name = "label2";
        label2.Size = new Size(164, 20);
        label2.TabIndex = 1;
        label2.Text = "Nhập số:( từ 1 đến 999)";
        // 
        // textbox_nhap
        // 
        textbox_nhap.Location = new Point(190, 110);
        textbox_nhap.Name = "textbox_nhap";
        textbox_nhap.Size = new Size(83, 27);
        textbox_nhap.TabIndex = 2;
        // 
        // btn_thuchien
        // 
        btn_thuchien.Location = new Point(13, 192);
        btn_thuchien.Name = "btn_thuchien";
        btn_thuchien.Size = new Size(89, 38);
        btn_thuchien.TabIndex = 3;
        btn_thuchien.Text = "Thực hiện";
        btn_thuchien.UseVisualStyleBackColor = true;
        btn_thuchien.Click += btn_thuchien_Click;
        // 
        // btn_xoa
        // 
        btn_xoa.Location = new Point(108, 192);
        btn_xoa.Name = "btn_xoa";
        btn_xoa.Size = new Size(89, 38);
        btn_xoa.TabIndex = 4;
        btn_xoa.Text = "Xóa";
        btn_xoa.UseVisualStyleBackColor = true;
        btn_xoa.Click += btn_xoa_Click;
        // 
        // btn_thoat
        // 
        btn_thoat.Location = new Point(203, 192);
        btn_thoat.Name = "btn_thoat";
        btn_thoat.Size = new Size(89, 38);
        btn_thoat.TabIndex = 5;
        btn_thoat.Text = "Thoát";
        btn_thoat.UseVisualStyleBackColor = true;
        btn_thoat.Click += btn_thoat_Click;
        // 
        // textbox_xuat
        // 
        textbox_xuat.BackColor = SystemColors.Info;
        textbox_xuat.ForeColor = Color.DeepSkyBlue;
        textbox_xuat.Location = new Point(13, 255);
        textbox_xuat.Name = "textbox_xuat";
        textbox_xuat.Size = new Size(279, 27);
        textbox_xuat.TabIndex = 6;
        // 
        // bai5
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(305, 293);
        Controls.Add(textbox_xuat);
        Controls.Add(btn_thoat);
        Controls.Add(btn_xoa);
        Controls.Add(btn_thuchien);
        Controls.Add(textbox_nhap);
        Controls.Add(label2);
        Controls.Add(label1);
        Name = "bai5";
        Text = "Form1";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label label1;
    private Label label2;
    private TextBox textbox_nhap;
    private Button btn_thuchien;
    private Button btn_xoa;
    private Button btn_thoat;
    private TextBox textbox_xuat;
}
