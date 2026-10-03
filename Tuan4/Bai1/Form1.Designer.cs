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
        components = new System.ComponentModel.Container();
        label1 = new Label();
        textBox1 = new TextBox();
        textBox2 = new TextBox();
        label2 = new Label();
        textBox3 = new TextBox();
        label3 = new Label();
        btn_minus = new Button();
        btn_divide = new Button();
        btn_mul = new Button();
        btn_plus = new Button();
        errorProvider1 = new ErrorProvider(components);
        ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
        SuspendLayout();
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(52, 64);
        label1.Name = "label1";
        label1.Size = new Size(27, 20);
        label1.TabIndex = 0;
        label1.Text = "a=";
        // 
        // textBox1
        // 
        textBox1.ForeColor = SystemColors.WindowText;
        textBox1.Location = new Point(85, 57);
        textBox1.Name = "textBox1";
        textBox1.RightToLeft = RightToLeft.No;
        textBox1.Size = new Size(78, 27);
        textBox1.TabIndex = 1;
        textBox1.TextChanged += txt_TextChanged;
        textBox1.KeyPress += txt_KeyPress;
        // 
        // textBox2
        // 
        textBox2.Location = new Point(214, 57);
        textBox2.Name = "textBox2";
        textBox2.Size = new Size(78, 27);
        textBox2.TabIndex = 3;
        textBox2.TextChanged += txt_TextChanged;
        textBox2.KeyPress += txt_KeyPress;
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(181, 64);
        label2.Name = "label2";
        label2.Size = new Size(28, 20);
        label2.TabIndex = 2;
        label2.Text = "b=";
        // 
        // textBox3
        // 
        textBox3.Location = new Point(113, 140);
        textBox3.Name = "textBox3";
        textBox3.ReadOnly = true;
        textBox3.Size = new Size(198, 27);
        textBox3.TabIndex = 5;
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.Location = new Point(43, 143);
        label3.Name = "label3";
        label3.Size = new Size(64, 20);
        label3.TabIndex = 4;
        label3.Text = "Kết quả ";
        // 
        // btn_minus
        // 
        btn_minus.Location = new Point(113, 214);
        btn_minus.Name = "btn_minus";
        btn_minus.Size = new Size(50, 42);
        btn_minus.TabIndex = 7;
        btn_minus.Text = "-";
        btn_minus.UseVisualStyleBackColor = true;
        btn_minus.Click += btn_PhepTinh_Click;
        // 
        // btn_divide
        // 
        btn_divide.Location = new Point(261, 214);
        btn_divide.Name = "btn_divide";
        btn_divide.Size = new Size(50, 42);
        btn_divide.TabIndex = 9;
        btn_divide.Text = "/";
        btn_divide.UseVisualStyleBackColor = true;
        btn_divide.Click += btn_PhepTinh_Click;
        // 
        // btn_mul
        // 
        btn_mul.Location = new Point(191, 214);
        btn_mul.Name = "btn_mul";
        btn_mul.Size = new Size(50, 42);
        btn_mul.TabIndex = 8;
        btn_mul.Text = "*";
        btn_mul.UseVisualStyleBackColor = true;
        btn_mul.Click += btn_PhepTinh_Click;
        // 
        // btn_plus
        // 
        btn_plus.Location = new Point(43, 214);
        btn_plus.Name = "btn_plus";
        btn_plus.Size = new Size(50, 42);
        btn_plus.TabIndex = 10;
        btn_plus.Text = "+";
        btn_plus.UseVisualStyleBackColor = true;
        btn_plus.Click += btn_PhepTinh_Click;
        // 
        // errorProvider1
        // 
        errorProvider1.ContainerControl = this;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(355, 276);
        Controls.Add(btn_plus);
        Controls.Add(btn_divide);
        Controls.Add(btn_mul);
        Controls.Add(btn_minus);
        Controls.Add(textBox3);
        Controls.Add(label3);
        Controls.Add(textBox2);
        Controls.Add(label2);
        Controls.Add(textBox1);
        Controls.Add(label1);
        Name = "Form1";
        Text = "cộng trừ nhân chia";
        FormClosing += Form1_FormClosing;
        ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label label1;
    private TextBox textBox1;
    private TextBox textBox2;
    private Label label2;
    private TextBox textBox3;
    private Label label3;
    private Button btn_minus;
    private Button btn_divide;
    private Button btn_mul;
    private Button btn_plus;
    private ErrorProvider errorProvider1;
}
