namespace bai3;

partial class bai3
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
        components = new System.ComponentModel.Container();
        label1 = new Label();
        label2 = new Label();
        textbox_a = new TextBox();
        textbox_b = new TextBox();
        label3 = new Label();
        btn_tinh = new Button();
        btn_tieptuc = new Button();
        btn_thoat = new Button();
        textbox_uscln = new TextBox();
        label4 = new Label();
        textbox_bscnn = new TextBox();
        label5 = new Label();
        errorProvider1 = new ErrorProvider(components);
        ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
        SuspendLayout();
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 163);
        label1.ForeColor = Color.Red;
        label1.Location = new Point(12, 9);
        label1.Name = "label1";
        label1.Size = new Size(392, 38);
        label1.TabIndex = 0;
        label1.Text = "Ước số chung - Bội số chung";
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(48, 75);
        label2.Name = "label2";
        label2.Size = new Size(79, 20);
        label2.TabIndex = 1;
        label2.Text = "Nhập số a:";
        // 
        // textbox_a
        // 
        textbox_a.Location = new Point(133, 68);
        textbox_a.Name = "textbox_a";
        textbox_a.Size = new Size(205, 27);
        textbox_a.TabIndex = 2;
        // 
        // textbox_b
        // 
        textbox_b.Location = new Point(133, 120);
        textbox_b.Name = "textbox_b";
        textbox_b.Size = new Size(205, 27);
        textbox_b.TabIndex = 4;
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.Location = new Point(48, 127);
        label3.Name = "label3";
        label3.Size = new Size(80, 20);
        label3.TabIndex = 3;
        label3.Text = "Nhập số b:";
        // 
        // btn_tinh
        // 
        btn_tinh.Location = new Point(22, 266);
        btn_tinh.Name = "btn_tinh";
        btn_tinh.Size = new Size(93, 36);
        btn_tinh.TabIndex = 5;
        btn_tinh.Text = "Thực hiện";
        btn_tinh.UseVisualStyleBackColor = true;
        btn_tinh.Click += btn_tinh_Click;
        // 
        // btn_tieptuc
        // 
        btn_tieptuc.Location = new Point(157, 266);
        btn_tieptuc.Name = "btn_tieptuc";
        btn_tieptuc.Size = new Size(93, 36);
        btn_tieptuc.TabIndex = 6;
        btn_tieptuc.Text = "Tiếp tục";
        btn_tieptuc.UseVisualStyleBackColor = true;
        btn_tieptuc.Click += btn_tieptuc_Click;
        // 
        // btn_thoat
        // 
        btn_thoat.Location = new Point(293, 266);
        btn_thoat.Name = "btn_thoat";
        btn_thoat.Size = new Size(93, 36);
        btn_thoat.TabIndex = 7;
        btn_thoat.Text = "Thoát";
        btn_thoat.UseVisualStyleBackColor = true;
        btn_thoat.Click += btn_thoat_Click;
        // 
        // textbox_uscln
        // 
        textbox_uscln.Location = new Point(228, 174);
        textbox_uscln.Name = "textbox_uscln";
        textbox_uscln.ReadOnly = true;
        textbox_uscln.Size = new Size(110, 27);
        textbox_uscln.TabIndex = 9;
        // 
        // label4
        // 
        label4.AutoSize = true;
        label4.Location = new Point(48, 181);
        label4.Name = "label4";
        label4.Size = new Size(160, 20);
        label4.TabIndex = 8;
        label4.Text = "Ước số chung lớn nhất:";
        // 
        // textbox_bscnn
        // 
        textbox_bscnn.Location = new Point(228, 214);
        textbox_bscnn.Name = "textbox_bscnn";
        textbox_bscnn.ReadOnly = true;
        textbox_bscnn.Size = new Size(110, 27);
        textbox_bscnn.TabIndex = 11;
        // 
        // label5
        // 
        label5.AutoSize = true;
        label5.Location = new Point(48, 221);
        label5.Name = "label5";
        label5.Size = new Size(159, 20);
        label5.TabIndex = 10;
        label5.Text = "Bội số chung nhỏ nhất:";
        // 
        // errorProvider1
        // 
        errorProvider1.ContainerControl = this;
        // 
        // bai3
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(412, 333);
        Controls.Add(textbox_bscnn);
        Controls.Add(label5);
        Controls.Add(textbox_uscln);
        Controls.Add(label4);
        Controls.Add(btn_thoat);
        Controls.Add(btn_tieptuc);
        Controls.Add(btn_tinh);
        Controls.Add(textbox_b);
        Controls.Add(label3);
        Controls.Add(textbox_a);
        Controls.Add(label2);
        Controls.Add(label1);
        Name = "bai3";
        Text = "Form1";
        ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label label1;
    private Label label2;
    private TextBox textbox_a;
    private TextBox textbox_b;
    private Label label3;
    private Button btn_tinh;
    private Button btn_tieptuc;
    private Button btn_thoat;
    private TextBox textbox_uscln;
    private Label label4;
    private TextBox textbox_bscnn;
    private Label label5;
    private ErrorProvider errorProvider1;
}
