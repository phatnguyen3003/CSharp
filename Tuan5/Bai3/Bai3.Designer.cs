namespace Bai3
{
    partial class Bai3
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
            btn_random_name = new Button();
            listbox = new ListBox();
            btn_delete_current_selected = new Button();
            btn_delete_name_Son = new Button();
            ben_delete_surname_Le = new Button();
            btn_upper_current = new Button();
            btn_lower_current = new Button();
            btn_upper_current_each = new Button();
            btn_delete_all = new Button();
            SuspendLayout();
            // 
            // btn_random_name
            // 
            btn_random_name.Location = new Point(12, 12);
            btn_random_name.Name = "btn_random_name";
            btn_random_name.Size = new Size(230, 29);
            btn_random_name.TabIndex = 0;
            btn_random_name.Text = "Nhập tên ngẫu nhiên";
            btn_random_name.UseVisualStyleBackColor = true;
            btn_random_name.Click += btn_random_name_Click;
            // 
            // listbox
            // 
            listbox.FormattingEnabled = true;
            listbox.Location = new Point(12, 57);
            listbox.Name = "listbox";
            listbox.Size = new Size(230, 324);
            listbox.TabIndex = 1;
            // 
            // btn_delete_current_selected
            // 
            btn_delete_current_selected.Location = new Point(278, 57);
            btn_delete_current_selected.Name = "btn_delete_current_selected";
            btn_delete_current_selected.Size = new Size(318, 29);
            btn_delete_current_selected.TabIndex = 2;
            btn_delete_current_selected.Text = "Xóa phần tử đang chọn";
            btn_delete_current_selected.UseVisualStyleBackColor = true;
            btn_delete_current_selected.Click += btn_delete_current_selected_Click;
            // 
            // btn_delete_name_Son
            // 
            btn_delete_name_Son.Location = new Point(278, 104);
            btn_delete_name_Son.Name = "btn_delete_name_Son";
            btn_delete_name_Son.Size = new Size(318, 29);
            btn_delete_name_Son.TabIndex = 3;
            btn_delete_name_Son.Text = "Xóa phần tử có tên Sơn";
            btn_delete_name_Son.UseVisualStyleBackColor = true;
            btn_delete_name_Son.Click += btn_delete_name_Son_Click;
            // 
            // ben_delete_surname_Le
            // 
            ben_delete_surname_Le.Location = new Point(278, 153);
            ben_delete_surname_Le.Name = "ben_delete_surname_Le";
            ben_delete_surname_Le.Size = new Size(318, 29);
            ben_delete_surname_Le.TabIndex = 4;
            ben_delete_surname_Le.Text = "Xóa phần tử có họ là Lê";
            ben_delete_surname_Le.UseVisualStyleBackColor = true;
            ben_delete_surname_Le.Click += ben_delete_surname_Le_Click;
            // 
            // btn_upper_current
            // 
            btn_upper_current.Location = new Point(278, 198);
            btn_upper_current.Name = "btn_upper_current";
            btn_upper_current.Size = new Size(318, 29);
            btn_upper_current.TabIndex = 7;
            btn_upper_current.Text = "Chuyển phần tử đang chọn thành chữ hoa";
            btn_upper_current.UseVisualStyleBackColor = true;
            btn_upper_current.Click += btn_upper_current_Click;
            // 
            // btn_lower_current
            // 
            btn_lower_current.Location = new Point(278, 245);
            btn_lower_current.Name = "btn_lower_current";
            btn_lower_current.Size = new Size(318, 29);
            btn_lower_current.TabIndex = 6;
            btn_lower_current.Text = "Chuyển phần tử đang chọn thành chữ thường";
            btn_lower_current.UseVisualStyleBackColor = true;
            btn_lower_current.Click += btn_lower_current_Click;
            // 
            // btn_upper_current_each
            // 
            btn_upper_current_each.Location = new Point(278, 280);
            btn_upper_current_each.Name = "btn_upper_current_each";
            btn_upper_current_each.Size = new Size(318, 54);
            btn_upper_current_each.TabIndex = 5;
            btn_upper_current_each.Text = "Chuyển phần tử đang chọn thành chữ hoa đầu mỗi từ";
            btn_upper_current_each.UseVisualStyleBackColor = true;
            btn_upper_current_each.Click += btn_upper_current_each_Click;
            // 
            // btn_delete_all
            // 
            btn_delete_all.Location = new Point(278, 340);
            btn_delete_all.Name = "btn_delete_all";
            btn_delete_all.Size = new Size(318, 29);
            btn_delete_all.TabIndex = 8;
            btn_delete_all.Text = "Xóa tất cả phần tử";
            btn_delete_all.UseVisualStyleBackColor = true;
            btn_delete_all.Click += btn_delete_all_Click;
            // 
            // Bai3
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(627, 411);
            Controls.Add(btn_delete_all);
            Controls.Add(btn_upper_current);
            Controls.Add(btn_lower_current);
            Controls.Add(btn_upper_current_each);
            Controls.Add(ben_delete_surname_Le);
            Controls.Add(btn_delete_name_Son);
            Controls.Add(btn_delete_current_selected);
            Controls.Add(listbox);
            Controls.Add(btn_random_name);
            Name = "Bai3";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button btn_random_name;
        private ListBox listbox;
        private Button btn_delete_current_selected;
        private Button btn_delete_name_Son;
        private Button ben_delete_surname_Le;
        private Button btn_upper_current;
        private Button btn_lower_current;
        private Button btn_upper_current_each;
        private Button btn_delete_all;
    }
}
