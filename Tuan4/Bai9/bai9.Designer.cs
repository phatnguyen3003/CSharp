namespace Bai9
{
    partial class bai9
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
            textbox_input = new TextBox();
            btn_reset = new Button();
            btn_exit = new Button();
            textbox_output = new TextBox();
            label3 = new Label();
            group_sort = new GroupBox();
            radio_down_sort = new RadioButton();
            radio_up_sort = new RadioButton();
            btn_start = new Button();
            group_find = new GroupBox();
            label4 = new Label();
            textbox_result_find = new TextBox();
            textbox_index_find = new TextBox();
            radio_index_find = new RadioButton();
            textbox_value_find = new TextBox();
            radio_value_find = new RadioButton();
            group_delete = new GroupBox();
            label5 = new Label();
            textbox_index_delete = new TextBox();
            radio_index_delete = new RadioButton();
            textbox_value_delete = new TextBox();
            radio_value_delete = new RadioButton();
            group_add = new GroupBox();
            label7 = new Label();
            label6 = new Label();
            textbox_index_add = new TextBox();
            textbox_value_add = new TextBox();
            radio_value_add = new RadioButton();
            group_sum = new GroupBox();
            btn_sum_cal = new Button();
            label10 = new Label();
            textbox_sum_odd = new TextBox();
            label9 = new Label();
            textbox_sum_even = new TextBox();
            label8 = new Label();
            textbox_sum = new TextBox();
            group_min_max = new GroupBox();
            btn_find_minmax = new Button();
            label12 = new Label();
            textbox_min = new TextBox();
            label13 = new Label();
            textbox_max = new TextBox();
            group_replace = new GroupBox();
            label11 = new Label();
            textbox_valueto_replace = new TextBox();
            textbox_index_replace = new TextBox();
            radio_index_replace = new RadioButton();
            textbox_value_replace = new TextBox();
            radio_value_replace = new RadioButton();
            group_sort.SuspendLayout();
            group_find.SuspendLayout();
            group_delete.SuspendLayout();
            group_add.SuspendLayout();
            group_sum.SuspendLayout();
            group_min_max.SuspendLayout();
            group_replace.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label1.ForeColor = Color.Red;
            label1.Location = new Point(136, 9);
            label1.Name = "label1";
            label1.Size = new Size(287, 46);
            label1.TabIndex = 0;
            label1.Text = "Mảng số nguyên";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 77);
            label2.Name = "label2";
            label2.Size = new Size(90, 20);
            label2.TabIndex = 1;
            label2.Text = "Nhập mảng:";
            // 
            // textbox_input
            // 
            textbox_input.Location = new Point(123, 70);
            textbox_input.Name = "textbox_input";
            textbox_input.Size = new Size(344, 27);
            textbox_input.TabIndex = 2;
            textbox_input.KeyPress += textbox_input_KeyPress;
            // 
            // btn_reset
            // 
            btn_reset.Location = new Point(485, 65);
            btn_reset.Name = "btn_reset";
            btn_reset.Size = new Size(66, 32);
            btn_reset.TabIndex = 3;
            btn_reset.Text = "Reset";
            btn_reset.UseVisualStyleBackColor = true;
            // 
            // btn_exit
            // 
            btn_exit.Location = new Point(485, 108);
            btn_exit.Name = "btn_exit";
            btn_exit.Size = new Size(66, 32);
            btn_exit.TabIndex = 6;
            btn_exit.Text = "Thoát";
            btn_exit.UseVisualStyleBackColor = true;
            // 
            // textbox_output
            // 
            textbox_output.Location = new Point(123, 113);
            textbox_output.Name = "textbox_output";
            textbox_output.ReadOnly = true;
            textbox_output.Size = new Size(344, 27);
            textbox_output.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 120);
            label3.Name = "label3";
            label3.Size = new Size(105, 20);
            label3.TabIndex = 4;
            label3.Text = "Kết quả mảng:";
            // 
            // group_sort
            // 
            group_sort.Controls.Add(radio_down_sort);
            group_sort.Controls.Add(radio_up_sort);
            group_sort.Location = new Point(217, 146);
            group_sort.Name = "group_sort";
            group_sort.Size = new Size(250, 54);
            group_sort.TabIndex = 7;
            group_sort.TabStop = false;
            group_sort.Text = "sắp xếp";
            // 
            // radio_down_sort
            // 
            radio_down_sort.AutoSize = true;
            radio_down_sort.Location = new Point(127, 24);
            radio_down_sort.Name = "radio_down_sort";
            radio_down_sort.Size = new Size(119, 24);
            radio_down_sort.TabIndex = 1;
            radio_down_sort.Text = "sắp xếp giảm";
            radio_down_sort.UseVisualStyleBackColor = true;
            // 
            // radio_up_sort
            // 
            radio_up_sort.AutoSize = true;
            radio_up_sort.Checked = true;
            radio_up_sort.Location = new Point(6, 24);
            radio_up_sort.Name = "radio_up_sort";
            radio_up_sort.Size = new Size(115, 24);
            radio_up_sort.TabIndex = 0;
            radio_up_sort.TabStop = true;
            radio_up_sort.Text = "sắp xếp tăng";
            radio_up_sort.UseVisualStyleBackColor = true;
            // 
            // btn_start
            // 
            btn_start.Location = new Point(12, 146);
            btn_start.Name = "btn_start";
            btn_start.Size = new Size(199, 54);
            btn_start.TabIndex = 8;
            btn_start.Text = "Thực hiện";
            btn_start.UseVisualStyleBackColor = true;
            // 
            // group_find
            // 
            group_find.Controls.Add(label4);
            group_find.Controls.Add(textbox_result_find);
            group_find.Controls.Add(textbox_index_find);
            group_find.Controls.Add(radio_index_find);
            group_find.Controls.Add(textbox_value_find);
            group_find.Controls.Add(radio_value_find);
            group_find.Location = new Point(12, 215);
            group_find.Name = "group_find";
            group_find.Size = new Size(212, 113);
            group_find.TabIndex = 9;
            group_find.TabStop = false;
            group_find.Text = "Tìm kiếm";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(36, 84);
            label4.Name = "label4";
            label4.Size = new Size(109, 20);
            label4.TabIndex = 5;
            label4.Text = "Số tìm được là:";
            // 
            // textbox_result_find
            // 
            textbox_result_find.Location = new Point(160, 77);
            textbox_result_find.Name = "textbox_result_find";
            textbox_result_find.ReadOnly = true;
            textbox_result_find.Size = new Size(46, 27);
            textbox_result_find.TabIndex = 4;
            // 
            // textbox_index_find
            // 
            textbox_index_find.Location = new Point(160, 44);
            textbox_index_find.Name = "textbox_index_find";
            textbox_index_find.Size = new Size(46, 27);
            textbox_index_find.TabIndex = 3;
            // 
            // radio_index_find
            // 
            radio_index_find.AutoSize = true;
            radio_index_find.Location = new Point(6, 47);
            radio_index_find.Name = "radio_index_find";
            radio_index_find.Size = new Size(141, 24);
            radio_index_find.TabIndex = 2;
            radio_index_find.Text = "Tìm vị trí cần tìm";
            radio_index_find.UseVisualStyleBackColor = true;
            // 
            // textbox_value_find
            // 
            textbox_value_find.Location = new Point(160, 14);
            textbox_value_find.Name = "textbox_value_find";
            textbox_value_find.Size = new Size(46, 27);
            textbox_value_find.TabIndex = 1;
            // 
            // radio_value_find
            // 
            radio_value_find.AutoSize = true;
            radio_value_find.Checked = true;
            radio_value_find.Location = new Point(6, 17);
            radio_value_find.Name = "radio_value_find";
            radio_value_find.Size = new Size(151, 24);
            radio_value_find.TabIndex = 0;
            radio_value_find.TabStop = true;
            radio_value_find.Text = "Tìm giá trị cần tìm";
            radio_value_find.UseVisualStyleBackColor = true;
            // 
            // group_delete
            // 
            group_delete.Controls.Add(label5);
            group_delete.Controls.Add(textbox_index_delete);
            group_delete.Controls.Add(radio_index_delete);
            group_delete.Controls.Add(textbox_value_delete);
            group_delete.Controls.Add(radio_value_delete);
            group_delete.Location = new Point(339, 215);
            group_delete.Name = "group_delete";
            group_delete.Size = new Size(212, 113);
            group_delete.TabIndex = 10;
            group_delete.TabStop = false;
            group_delete.Text = "Xóa";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label5.ForeColor = Color.Red;
            label5.Location = new Point(32, 82);
            label5.Name = "label5";
            label5.Size = new Size(174, 28);
            label5.TabIndex = 5;
            label5.Text = "Cần sắp xếp tăng";
            // 
            // textbox_index_delete
            // 
            textbox_index_delete.Location = new Point(160, 44);
            textbox_index_delete.Name = "textbox_index_delete";
            textbox_index_delete.Size = new Size(46, 27);
            textbox_index_delete.TabIndex = 3;
            // 
            // radio_index_delete
            // 
            radio_index_delete.AutoSize = true;
            radio_index_delete.Location = new Point(6, 47);
            radio_index_delete.Name = "radio_index_delete";
            radio_index_delete.Size = new Size(143, 24);
            radio_index_delete.TabIndex = 2;
            radio_index_delete.Text = "Tìm vị trí cần xóa";
            radio_index_delete.UseVisualStyleBackColor = true;
            // 
            // textbox_value_delete
            // 
            textbox_value_delete.Location = new Point(160, 14);
            textbox_value_delete.Name = "textbox_value_delete";
            textbox_value_delete.Size = new Size(46, 27);
            textbox_value_delete.TabIndex = 1;
            // 
            // radio_value_delete
            // 
            radio_value_delete.AutoSize = true;
            radio_value_delete.Checked = true;
            radio_value_delete.Location = new Point(6, 17);
            radio_value_delete.Name = "radio_value_delete";
            radio_value_delete.Size = new Size(153, 24);
            radio_value_delete.TabIndex = 0;
            radio_value_delete.TabStop = true;
            radio_value_delete.Text = "Tìm giá trị cần xóa";
            radio_value_delete.UseVisualStyleBackColor = true;
            // 
            // group_add
            // 
            group_add.Controls.Add(label7);
            group_add.Controls.Add(label6);
            group_add.Controls.Add(textbox_index_add);
            group_add.Controls.Add(textbox_value_add);
            group_add.Controls.Add(radio_value_add);
            group_add.Location = new Point(12, 345);
            group_add.Name = "group_add";
            group_add.Size = new Size(220, 113);
            group_add.TabIndex = 11;
            group_add.TabStop = false;
            group_add.Text = "Thêm";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(36, 59);
            label7.Name = "label7";
            label7.Size = new Size(127, 20);
            label7.TabIndex = 6;
            label7.Text = "Tại vị trí cần thêm";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label6.ForeColor = Color.Red;
            label6.Location = new Point(32, 82);
            label6.Name = "label6";
            label6.Size = new Size(174, 28);
            label6.TabIndex = 5;
            label6.Text = "Cần sắp xếp tăng";
            // 
            // textbox_index_add
            // 
            textbox_index_add.Location = new Point(166, 52);
            textbox_index_add.Name = "textbox_index_add";
            textbox_index_add.Size = new Size(46, 27);
            textbox_index_add.TabIndex = 3;
            // 
            // textbox_value_add
            // 
            textbox_value_add.Location = new Point(168, 16);
            textbox_value_add.Name = "textbox_value_add";
            textbox_value_add.Size = new Size(46, 27);
            textbox_value_add.TabIndex = 1;
            // 
            // radio_value_add
            // 
            radio_value_add.AutoSize = true;
            radio_value_add.Checked = true;
            radio_value_add.Location = new Point(6, 17);
            radio_value_add.Name = "radio_value_add";
            radio_value_add.Size = new Size(163, 24);
            radio_value_add.TabIndex = 0;
            radio_value_add.TabStop = true;
            radio_value_add.Text = "Tìm giá trị cần thêm";
            radio_value_add.UseVisualStyleBackColor = true;
            // 
            // group_sum
            // 
            group_sum.Controls.Add(btn_sum_cal);
            group_sum.Controls.Add(label10);
            group_sum.Controls.Add(textbox_sum_odd);
            group_sum.Controls.Add(label9);
            group_sum.Controls.Add(textbox_sum_even);
            group_sum.Controls.Add(label8);
            group_sum.Controls.Add(textbox_sum);
            group_sum.Location = new Point(298, 345);
            group_sum.Name = "group_sum";
            group_sum.Size = new Size(253, 110);
            group_sum.TabIndex = 12;
            group_sum.TabStop = false;
            group_sum.Text = "Tổng";
            // 
            // btn_sum_cal
            // 
            btn_sum_cal.Location = new Point(195, 15);
            btn_sum_cal.Name = "btn_sum_cal";
            btn_sum_cal.Size = new Size(52, 87);
            btn_sum_cal.TabIndex = 13;
            btn_sum_cal.Text = "Tổng";
            btn_sum_cal.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(6, 82);
            label10.Name = "label10";
            label10.Size = new Size(101, 20);
            label10.TabIndex = 12;
            label10.Text = "Tổng mảng lẻ";
            // 
            // textbox_sum_odd
            // 
            textbox_sum_odd.Location = new Point(143, 75);
            textbox_sum_odd.Name = "textbox_sum_odd";
            textbox_sum_odd.Size = new Size(46, 27);
            textbox_sum_odd.TabIndex = 11;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(6, 52);
            label9.Name = "label9";
            label9.Size = new Size(122, 20);
            label9.TabIndex = 10;
            label9.Text = "Tổng mảng Chẳn";
            // 
            // textbox_sum_even
            // 
            textbox_sum_even.Location = new Point(143, 45);
            textbox_sum_even.Name = "textbox_sum_even";
            textbox_sum_even.Size = new Size(46, 27);
            textbox_sum_even.TabIndex = 9;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(6, 23);
            label8.Name = "label8";
            label8.Size = new Size(85, 20);
            label8.TabIndex = 8;
            label8.Text = "Tổng mảng";
            // 
            // textbox_sum
            // 
            textbox_sum.Location = new Point(143, 16);
            textbox_sum.Name = "textbox_sum";
            textbox_sum.Size = new Size(46, 27);
            textbox_sum.TabIndex = 7;
            // 
            // group_min_max
            // 
            group_min_max.Controls.Add(btn_find_minmax);
            group_min_max.Controls.Add(label12);
            group_min_max.Controls.Add(textbox_min);
            group_min_max.Controls.Add(label13);
            group_min_max.Controls.Add(textbox_max);
            group_min_max.Location = new Point(18, 483);
            group_min_max.Name = "group_min_max";
            group_min_max.Size = new Size(253, 89);
            group_min_max.TabIndex = 13;
            group_min_max.TabStop = false;
            group_min_max.Text = "Max - Min";
            // 
            // btn_find_minmax
            // 
            btn_find_minmax.Location = new Point(195, 15);
            btn_find_minmax.Name = "btn_find_minmax";
            btn_find_minmax.Size = new Size(52, 68);
            btn_find_minmax.TabIndex = 13;
            btn_find_minmax.Text = "Tìm";
            btn_find_minmax.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(6, 52);
            label12.Name = "label12";
            label12.Size = new Size(111, 20);
            label12.TabIndex = 10;
            label12.Text = "Giá trị nhỏ nhất";
            // 
            // textbox_min
            // 
            textbox_min.Location = new Point(143, 45);
            textbox_min.Name = "textbox_min";
            textbox_min.ReadOnly = true;
            textbox_min.Size = new Size(46, 27);
            textbox_min.TabIndex = 9;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(6, 23);
            label13.Name = "label13";
            label13.Size = new Size(107, 20);
            label13.TabIndex = 8;
            label13.Text = "Giá trị lớn nhất";
            // 
            // textbox_max
            // 
            textbox_max.Location = new Point(143, 16);
            textbox_max.Name = "textbox_max";
            textbox_max.ReadOnly = true;
            textbox_max.Size = new Size(46, 27);
            textbox_max.TabIndex = 7;
            // 
            // group_replace
            // 
            group_replace.Controls.Add(label11);
            group_replace.Controls.Add(textbox_valueto_replace);
            group_replace.Controls.Add(textbox_index_replace);
            group_replace.Controls.Add(radio_index_replace);
            group_replace.Controls.Add(textbox_value_replace);
            group_replace.Controls.Add(radio_value_replace);
            group_replace.Location = new Point(333, 483);
            group_replace.Name = "group_replace";
            group_replace.Size = new Size(212, 113);
            group_replace.TabIndex = 10;
            group_replace.TabStop = false;
            group_replace.Text = "Thay thế";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(36, 84);
            label11.Name = "label11";
            label11.Size = new Size(122, 20);
            label11.TabIndex = 5;
            label11.Text = "Giá trị thay thế là";
            // 
            // textbox_valueto_replace
            // 
            textbox_valueto_replace.Location = new Point(160, 77);
            textbox_valueto_replace.Name = "textbox_valueto_replace";
            textbox_valueto_replace.Size = new Size(46, 27);
            textbox_valueto_replace.TabIndex = 4;
            // 
            // textbox_index_replace
            // 
            textbox_index_replace.Location = new Point(160, 44);
            textbox_index_replace.Name = "textbox_index_replace";
            textbox_index_replace.Size = new Size(46, 27);
            textbox_index_replace.TabIndex = 3;
            // 
            // radio_index_replace
            // 
            radio_index_replace.AutoSize = true;
            radio_index_replace.Location = new Point(6, 47);
            radio_index_replace.Name = "radio_index_replace";
            radio_index_replace.Size = new Size(145, 24);
            radio_index_replace.TabIndex = 2;
            radio_index_replace.Text = "Vị trí cần thay thế";
            radio_index_replace.UseVisualStyleBackColor = true;
            // 
            // textbox_value_replace
            // 
            textbox_value_replace.Location = new Point(160, 14);
            textbox_value_replace.Name = "textbox_value_replace";
            textbox_value_replace.Size = new Size(46, 27);
            textbox_value_replace.TabIndex = 1;
            // 
            // radio_value_replace
            // 
            radio_value_replace.AutoSize = true;
            radio_value_replace.Location = new Point(6, 17);
            radio_value_replace.Name = "radio_value_replace";
            radio_value_replace.Size = new Size(154, 24);
            radio_value_replace.TabIndex = 0;
            radio_value_replace.Text = "Giá trị cần thay thế";
            radio_value_replace.UseVisualStyleBackColor = true;
            // 
            // bai9
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(563, 606);
            Controls.Add(group_replace);
            Controls.Add(group_min_max);
            Controls.Add(group_sum);
            Controls.Add(group_add);
            Controls.Add(group_delete);
            Controls.Add(group_find);
            Controls.Add(btn_start);
            Controls.Add(group_sort);
            Controls.Add(btn_exit);
            Controls.Add(textbox_output);
            Controls.Add(label3);
            Controls.Add(btn_reset);
            Controls.Add(textbox_input);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "bai9";
            Text = "Form1";
            group_sort.ResumeLayout(false);
            group_sort.PerformLayout();
            group_find.ResumeLayout(false);
            group_find.PerformLayout();
            group_delete.ResumeLayout(false);
            group_delete.PerformLayout();
            group_add.ResumeLayout(false);
            group_add.PerformLayout();
            group_sum.ResumeLayout(false);
            group_sum.PerformLayout();
            group_min_max.ResumeLayout(false);
            group_min_max.PerformLayout();
            group_replace.ResumeLayout(false);
            group_replace.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox textbox_input;
        private Button btn_reset;
        private Button btn_exit;
        private TextBox textbox_output;
        private Label label3;
        private GroupBox group_sort;
        private RadioButton radio_down_sort;
        private RadioButton radio_up_sort;
        private Button btn_start;
        private GroupBox group_find;
        private RadioButton radio_value_find;
        private Label label4;
        private TextBox textbox_result_find;
        private TextBox textbox_index_find;
        private RadioButton radio_index_find;
        private TextBox textbox_value_find;
        private GroupBox group_delete;
        private Label label5;
        private TextBox textbox_index_delete;
        private RadioButton radio_index_delete;
        private TextBox textbox_value_delete;
        private RadioButton radio_value_delete;
        private GroupBox group_add;
        private Label label7;
        private Label label6;
        private TextBox textbox_index_add;
        private TextBox textbox_value_add;
        private RadioButton radio_value_add;
        private GroupBox group_sum;
        private Button btn_sum_cal;
        private Label label10;
        private TextBox textbox_sum_odd;
        private Label label9;
        private TextBox textbox_sum_even;
        private Label label8;
        private TextBox textbox_sum;
        private GroupBox group_min_max;
        private Button btn_find_minmax;
        private Label label12;
        private TextBox textbox_min;
        private Label label13;
        private TextBox textbox_max;
        private GroupBox group_replace;
        private Label label11;
        private TextBox textbox_valueto_replace;
        private TextBox textbox_index_replace;
        private RadioButton radio_index_replace;
        private TextBox textbox_value_replace;
        private RadioButton radio_value_replace;
    }
}
