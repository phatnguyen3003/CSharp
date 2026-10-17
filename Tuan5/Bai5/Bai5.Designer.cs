namespace Bai5
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
            groupbox = new GroupBox();
            listbox = new ListBox();
            btn_input = new Button();
            textbox_input = new TextBox();
            groupBox1 = new GroupBox();
            btn_odd = new Button();
            btn_even = new Button();
            btn_replace_pow = new Button();
            btn_add_2 = new Button();
            btn_delete_currentSelected = new Button();
            btn_delete_FirstEnd = new Button();
            btn_sum_all = new Button();
            btn_exit = new Button();
            groupbox.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label1.ForeColor = Color.DarkOrange;
            label1.Location = new Point(145, 9);
            label1.Name = "label1";
            label1.Size = new Size(214, 60);
            label1.TabIndex = 0;
            label1.Text = "LIST BOX";
            // 
            // groupbox
            // 
            groupbox.Controls.Add(listbox);
            groupbox.Controls.Add(btn_input);
            groupbox.Controls.Add(textbox_input);
            groupbox.Location = new Point(23, 72);
            groupbox.Name = "groupbox";
            groupbox.Size = new Size(177, 310);
            groupbox.TabIndex = 1;
            groupbox.TabStop = false;
            groupbox.Text = "ListBox";
            // 
            // listbox
            // 
            listbox.FormattingEnabled = true;
            listbox.Location = new Point(6, 94);
            listbox.Name = "listbox";
            listbox.Size = new Size(165, 204);
            listbox.TabIndex = 2;
            // 
            // btn_input
            // 
            btn_input.Location = new Point(6, 59);
            btn_input.Name = "btn_input";
            btn_input.Size = new Size(165, 29);
            btn_input.TabIndex = 1;
            btn_input.Text = "Nhập";
            btn_input.UseVisualStyleBackColor = true;
            // 
            // textbox_input
            // 
            textbox_input.Location = new Point(6, 26);
            textbox_input.Name = "textbox_input";
            textbox_input.Size = new Size(165, 27);
            textbox_input.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btn_odd);
            groupBox1.Controls.Add(btn_even);
            groupBox1.Controls.Add(btn_replace_pow);
            groupBox1.Controls.Add(btn_add_2);
            groupBox1.Controls.Add(btn_delete_currentSelected);
            groupBox1.Controls.Add(btn_delete_FirstEnd);
            groupBox1.Controls.Add(btn_sum_all);
            groupBox1.Location = new Point(206, 83);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(306, 299);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Xử lý ListBox";
            // 
            // btn_odd
            // 
            btn_odd.Location = new Point(6, 258);
            btn_odd.Name = "btn_odd";
            btn_odd.Size = new Size(294, 29);
            btn_odd.TabIndex = 6;
            btn_odd.Text = "Chọn số lẻ";
            btn_odd.UseVisualStyleBackColor = true;
            // 
            // btn_even
            // 
            btn_even.Location = new Point(6, 223);
            btn_even.Name = "btn_even";
            btn_even.Size = new Size(294, 29);
            btn_even.TabIndex = 5;
            btn_even.Text = "Chọn số chẵn";
            btn_even.UseVisualStyleBackColor = true;
            // 
            // btn_replace_pow
            // 
            btn_replace_pow.Location = new Point(6, 166);
            btn_replace_pow.Name = "btn_replace_pow";
            btn_replace_pow.Size = new Size(294, 51);
            btn_replace_pow.TabIndex = 4;
            btn_replace_pow.Text = "Thay phần tử đang chọn bằng bình phương";
            btn_replace_pow.UseVisualStyleBackColor = true;
            // 
            // btn_add_2
            // 
            btn_add_2.Location = new Point(6, 131);
            btn_add_2.Name = "btn_add_2";
            btn_add_2.Size = new Size(294, 29);
            btn_add_2.TabIndex = 3;
            btn_add_2.Text = "Tăng mỗi phần tử lên 2";
            btn_add_2.UseVisualStyleBackColor = true;
            // 
            // btn_delete_currentSelected
            // 
            btn_delete_currentSelected.Location = new Point(6, 96);
            btn_delete_currentSelected.Name = "btn_delete_currentSelected";
            btn_delete_currentSelected.Size = new Size(294, 29);
            btn_delete_currentSelected.TabIndex = 2;
            btn_delete_currentSelected.Text = "Xóa các phần tử đang chọn";
            btn_delete_currentSelected.UseVisualStyleBackColor = true;
            // 
            // btn_delete_FirstEnd
            // 
            btn_delete_FirstEnd.Location = new Point(6, 61);
            btn_delete_FirstEnd.Name = "btn_delete_FirstEnd";
            btn_delete_FirstEnd.Size = new Size(294, 29);
            btn_delete_FirstEnd.TabIndex = 1;
            btn_delete_FirstEnd.Text = "Xóa phần tử đầu và cuối";
            btn_delete_FirstEnd.UseVisualStyleBackColor = true;
            // 
            // btn_sum_all
            // 
            btn_sum_all.Location = new Point(6, 26);
            btn_sum_all.Name = "btn_sum_all";
            btn_sum_all.Size = new Size(294, 29);
            btn_sum_all.TabIndex = 0;
            btn_sum_all.Text = "Tổng các phần tử trong List";
            btn_sum_all.UseVisualStyleBackColor = true;
            // 
            // btn_exit
            // 
            btn_exit.Location = new Point(23, 401);
            btn_exit.Name = "btn_exit";
            btn_exit.Size = new Size(489, 37);
            btn_exit.TabIndex = 3;
            btn_exit.Text = "Kết thúc";
            btn_exit.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(524, 450);
            Controls.Add(btn_exit);
            Controls.Add(groupBox1);
            Controls.Add(groupbox);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            groupbox.ResumeLayout(false);
            groupbox.PerformLayout();
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private GroupBox groupbox;
        private ListBox listbox;
        private Button btn_input;
        private TextBox textbox_input;
        private GroupBox groupBox1;
        private Button btn_delete_currentSelected;
        private Button btn_delete_FirstEnd;
        private Button btn_sum_all;
        private Button btn_replace_pow;
        private Button btn_add_2;
        private Button btn_odd;
        private Button btn_even;
        private Button btn_exit;
    }
}
