namespace Bai1;

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
        labelMaMonHoc = new Label();
        labelTenMonHoc = new Label();
        textbox_MaMH = new TextBox();
        textbox_TenMH = new TextBox();
        btn_them = new Button();
        btn_xoa = new Button();
        btn_sua = new Button();
        SuspendLayout();
        // 
        // labelMaMonHoc
        // 
        labelMaMonHoc.AutoSize = true;
        labelMaMonHoc.Location = new Point(28, 35);
        labelMaMonHoc.Name = "labelMaMonHoc";
        labelMaMonHoc.Size = new Size(92, 20);
        labelMaMonHoc.TabIndex = 0;
        labelMaMonHoc.Text = "Mã môn học";
        // 
        // labelTenMonHoc
        // 
        labelTenMonHoc.AutoSize = true;
        labelTenMonHoc.Location = new Point(28, 83);
        labelTenMonHoc.Name = "labelTenMonHoc";
        labelTenMonHoc.Size = new Size(94, 20);
        labelTenMonHoc.TabIndex = 1;
        labelTenMonHoc.Text = "Tên môn học";
        // 
        // textbox_MaMH
        // 
        textbox_MaMH.Location = new Point(139, 32);
        textbox_MaMH.Name = "textbox_MaMH";
        textbox_MaMH.Size = new Size(300, 27);
        textbox_MaMH.TabIndex = 2;
        // 
        // textbox_TenMH
        // 
        textbox_TenMH.Location = new Point(139, 80);
        textbox_TenMH.Name = "textbox_TenMH";
        textbox_TenMH.Size = new Size(300, 27);
        textbox_TenMH.TabIndex = 3;
        // 
        // btn_them
        // 
        btn_them.Location = new Point(62, 136);
        btn_them.Name = "btn_them";
        btn_them.Size = new Size(94, 32);
        btn_them.TabIndex = 4;
        btn_them.Text = "Thêm";
        btn_them.UseVisualStyleBackColor = true;
        // 
        // btn_xoa
        // 
        btn_xoa.Location = new Point(190, 136);
        btn_xoa.Name = "btn_xoa";
        btn_xoa.Size = new Size(94, 32);
        btn_xoa.TabIndex = 5;
        btn_xoa.Text = "Xóa";
        btn_xoa.UseVisualStyleBackColor = true;
        // 
        // btn_sua
        // 
        btn_sua.Location = new Point(318, 136);
        btn_sua.Name = "btn_sua";
        btn_sua.Size = new Size(94, 32);
        btn_sua.TabIndex = 6;
        btn_sua.Text = "Sửa";
        btn_sua.UseVisualStyleBackColor = true;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(470, 195);
        Controls.Add(btn_sua);
        Controls.Add(btn_xoa);
        Controls.Add(btn_them);
        Controls.Add(textbox_TenMH);
        Controls.Add(textbox_MaMH);
        Controls.Add(labelTenMonHoc);
        Controls.Add(labelMaMonHoc);
        Name = "Form1";
        Text = "Quản lý môn học";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label labelMaMonHoc;
    private Label labelTenMonHoc;
    private TextBox textbox_MaMH;
    private TextBox textbox_TenMH;
    private Button btn_them;
    private Button btn_xoa;
    private Button btn_sua;
}
