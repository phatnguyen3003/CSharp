namespace Bai1;

partial class Bai1
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
        group_input = new GroupBox();
        combobox_list_numbers = new ComboBox();
        btn_update = new Button();
        textbox_input = new TextBox();
        group_result = new GroupBox();
        listbox_result = new ListBox();
        btn_sum = new Button();
        btn_sum_even = new Button();
        btn_count_prime = new Button();
        btn_exit = new Button();
        group_input.SuspendLayout();
        group_result.SuspendLayout();
        SuspendLayout();
        // 
        // group_input
        // 
        group_input.Controls.Add(combobox_list_numbers);
        group_input.Controls.Add(btn_update);
        group_input.Controls.Add(textbox_input);
        group_input.Location = new Point(23, 24);
        group_input.Name = "group_input";
        group_input.Size = new Size(250, 125);
        group_input.TabIndex = 0;
        group_input.TabStop = false;
        group_input.Text = "Nhập số";
        // 
        // combobox_list_numbers
        // 
        combobox_list_numbers.FormattingEnabled = true;
        combobox_list_numbers.Location = new Point(6, 72);
        combobox_list_numbers.Name = "combobox_list_numbers";
        combobox_list_numbers.Size = new Size(238, 28);
        combobox_list_numbers.TabIndex = 2;
        combobox_list_numbers.SelectedIndexChanged += combobox_list_numbers_SelectedIndexChanged;
        // 
        // btn_update
        // 
        btn_update.Location = new Point(150, 26);
        btn_update.Name = "btn_update";
        btn_update.Size = new Size(94, 29);
        btn_update.TabIndex = 1;
        btn_update.Text = "Cập nhật";
        btn_update.UseVisualStyleBackColor = true;
        btn_update.Click += btn_update_Click;
        // 
        // textbox_input
        // 
        textbox_input.Location = new Point(6, 26);
        textbox_input.Name = "textbox_input";
        textbox_input.Size = new Size(125, 27);
        textbox_input.TabIndex = 0;
        // 
        // group_result
        // 
        group_result.Controls.Add(listbox_result);
        group_result.Location = new Point(335, 24);
        group_result.Name = "group_result";
        group_result.Size = new Size(250, 167);
        group_result.TabIndex = 1;
        group_result.TabStop = false;
        group_result.Text = "Danh sách các ước số";
        // 
        // listbox_result
        // 
        listbox_result.FormattingEnabled = true;
        listbox_result.Location = new Point(12, 26);
        listbox_result.Name = "listbox_result";
        listbox_result.Size = new Size(232, 124);
        listbox_result.TabIndex = 2;
        // 
        // btn_sum
        // 
        btn_sum.Location = new Point(335, 212);
        btn_sum.Name = "btn_sum";
        btn_sum.Size = new Size(250, 29);
        btn_sum.TabIndex = 2;
        btn_sum.Text = "Tổng các ước số";
        btn_sum.UseVisualStyleBackColor = true;
        btn_sum.Click += btn_sum_Click;
        // 
        // btn_sum_even
        // 
        btn_sum_even.Location = new Point(335, 247);
        btn_sum_even.Name = "btn_sum_even";
        btn_sum_even.Size = new Size(250, 29);
        btn_sum_even.TabIndex = 3;
        btn_sum_even.Text = "Số lượng các ước số chẵn";
        btn_sum_even.UseVisualStyleBackColor = true;
        btn_sum_even.Click += btn_sum_even_Click;
        // 
        // btn_count_prime
        // 
        btn_count_prime.Location = new Point(335, 282);
        btn_count_prime.Name = "btn_count_prime";
        btn_count_prime.Size = new Size(250, 29);
        btn_count_prime.TabIndex = 4;
        btn_count_prime.Text = "Số lượng các ước số nguyên tố";
        btn_count_prime.UseVisualStyleBackColor = true;
        btn_count_prime.Click += btn_count_prime_Click;
        // 
        // btn_exit
        // 
        btn_exit.Location = new Point(204, 282);
        btn_exit.Name = "btn_exit";
        btn_exit.Size = new Size(95, 29);
        btn_exit.TabIndex = 5;
        btn_exit.Text = "Thoát";
        btn_exit.UseVisualStyleBackColor = true;
        // 
        // Bai1
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(597, 340);
        Controls.Add(btn_exit);
        Controls.Add(btn_count_prime);
        Controls.Add(btn_sum_even);
        Controls.Add(btn_sum);
        Controls.Add(group_result);
        Controls.Add(group_input);
        Name = "Bai1";
        Text = "Form1";
        group_input.ResumeLayout(false);
        group_input.PerformLayout();
        group_result.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion

    private GroupBox group_input;
    private ComboBox combobox_list_numbers;
    private Button btn_update;
    private TextBox textbox_input;
    private GroupBox group_result;
    private ListBox listbox_result;
    private Button btn_sum;
    private Button btn_sum_even;
    private Button btn_count_prime;
    private Button btn_exit;
}
