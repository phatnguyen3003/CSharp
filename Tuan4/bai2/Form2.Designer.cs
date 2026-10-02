namespace Bai2;

partial class Form2
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
        textbox_name = new TextBox();
        label2 = new Label();
        label3 = new Label();
        textbox_email = new TextBox();
        label4 = new Label();
        label5 = new Label();
        textbox_password = new TextBox();
        label6 = new Label();
        textbox_retype_password = new TextBox();
        label8 = new Label();
        label7 = new Label();
        btn_dangky = new Button();
        email_error = new ErrorProvider(components);
        ((System.ComponentModel.ISupportInitialize)email_error).BeginInit();
        SuspendLayout();
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(35, 73);
        label1.Name = "label1";
        label1.Size = new Size(107, 20);
        label1.TabIndex = 0;
        label1.Text = "Tên đăng nhập";
        // 
        // textbox_name
        // 
        textbox_name.Location = new Point(148, 70);
        textbox_name.Name = "textbox_name";
        textbox_name.Size = new Size(231, 27);
        textbox_name.TabIndex = 1;
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(396, 73);
        label2.Name = "label2";
        label2.Size = new Size(25, 20);
        label2.TabIndex = 2;
        label2.Text = "(*)";
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.Location = new Point(396, 117);
        label3.Name = "label3";
        label3.Size = new Size(25, 20);
        label3.TabIndex = 5;
        label3.Text = "(*)";
        // 
        // textbox_email
        // 
        textbox_email.Location = new Point(148, 114);
        textbox_email.Name = "textbox_email";
        textbox_email.Size = new Size(231, 27);
        textbox_email.TabIndex = 4;
        // 
        // label4
        // 
        label4.AutoSize = true;
        label4.Location = new Point(46, 117);
        label4.Name = "label4";
        label4.Size = new Size(96, 20);
        label4.TabIndex = 3;
        label4.Text = "Địa chỉ email";
        // 
        // label5
        // 
        label5.AutoSize = true;
        label5.Location = new Point(396, 163);
        label5.Name = "label5";
        label5.Size = new Size(25, 20);
        label5.TabIndex = 8;
        label5.Text = "(*)";
        // 
        // textbox_password
        // 
        textbox_password.Location = new Point(148, 160);
        textbox_password.Name = "textbox_password";
        textbox_password.Size = new Size(231, 27);
        textbox_password.TabIndex = 7;
        // 
        // label6
        // 
        label6.AutoSize = true;
        label6.Location = new Point(72, 163);
        label6.Name = "label6";
        label6.Size = new Size(70, 20);
        label6.TabIndex = 6;
        label6.Text = "Mật khẩu";
        // 
        // textbox_retype_password
        // 
        textbox_retype_password.Location = new Point(148, 207);
        textbox_retype_password.Name = "textbox_retype_password";
        textbox_retype_password.Size = new Size(231, 27);
        textbox_retype_password.TabIndex = 10;
        // 
        // label8
        // 
        label8.AutoSize = true;
        label8.Location = new Point(12, 210);
        label8.Name = "label8";
        label8.Size = new Size(130, 20);
        label8.TabIndex = 9;
        label8.Text = "Nhập lại mật khẩu";
        // 
        // label7
        // 
        label7.AutoSize = true;
        label7.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 163);
        label7.ForeColor = SystemColors.MenuHighlight;
        label7.Location = new Point(117, 9);
        label7.Name = "label7";
        label7.Size = new Size(304, 38);
        label7.TabIndex = 11;
        label7.Text = "ĐĂNG KÝ TÀI KHOẢN";
        // 
        // btn_dangky
        // 
        btn_dangky.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
        btn_dangky.ForeColor = SystemColors.Highlight;
        btn_dangky.Location = new Point(167, 275);
        btn_dangky.Name = "btn_dangky";
        btn_dangky.Size = new Size(170, 53);
        btn_dangky.TabIndex = 12;
        btn_dangky.Text = "Đăng Ký";
        btn_dangky.UseVisualStyleBackColor = true;
        btn_dangky.Click += btn_dangky_Click;
        // 
        // email_error
        // 
        email_error.ContainerControl = this;
        // 
        // Form2
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(503, 386);
        Controls.Add(btn_dangky);
        Controls.Add(label7);
        Controls.Add(textbox_retype_password);
        Controls.Add(label8);
        Controls.Add(label5);
        Controls.Add(textbox_password);
        Controls.Add(label6);
        Controls.Add(label3);
        Controls.Add(textbox_email);
        Controls.Add(label4);
        Controls.Add(label2);
        Controls.Add(textbox_name);
        Controls.Add(label1);
        Name = "Form2";
        Text = "Form2";
        FormClosing += Form2_FormClosing;
        ((System.ComponentModel.ISupportInitialize)email_error).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label label1;
    private TextBox textbox_name;
    private Label label2;
    private Label label3;
    private TextBox textbox_email;
    private Label label4;
    private Label label5;
    private TextBox textbox_password;
    private Label label6;
    private TextBox textbox_retype_password;
    private Label label8;
    private Label label7;
    private Button btn_dangky;
    private ErrorProvider email_error;
}
