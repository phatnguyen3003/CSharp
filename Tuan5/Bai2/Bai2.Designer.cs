namespace Bai2
{
    partial class Bai2
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
            treeview_main = new TreeView();
            panel_main = new Panel();
            group_infor_student = new GroupBox();
            combobox_class = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            textbox_idnumber = new TextBox();
            textbox_name = new TextBox();
            label3 = new Label();
            textbox_livingplace = new TextBox();
            label4 = new Label();
            btn_update = new Button();
            btn_delete = new Button();
            checkbox_add_class = new CheckBox();
            groupBox1 = new GroupBox();
            textbox_class_name = new TextBox();
            label5 = new Label();
            btn_add_class = new Button();
            panel_main.SuspendLayout();
            group_infor_student.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // treeview_main
            // 
            treeview_main.Location = new Point(12, 12);
            treeview_main.Name = "treeview_main";
            treeview_main.Size = new Size(282, 426);
            treeview_main.TabIndex = 0;
            // 
            // panel_main
            // 
            panel_main.Controls.Add(groupBox1);
            panel_main.Controls.Add(checkbox_add_class);
            panel_main.Controls.Add(group_infor_student);
            panel_main.Controls.Add(combobox_class);
            panel_main.Controls.Add(label1);
            panel_main.Location = new Point(300, 12);
            panel_main.Name = "panel_main";
            panel_main.Size = new Size(401, 426);
            panel_main.TabIndex = 1;
            // 
            // group_infor_student
            // 
            group_infor_student.Controls.Add(btn_delete);
            group_infor_student.Controls.Add(btn_update);
            group_infor_student.Controls.Add(textbox_livingplace);
            group_infor_student.Controls.Add(label4);
            group_infor_student.Controls.Add(textbox_name);
            group_infor_student.Controls.Add(label3);
            group_infor_student.Controls.Add(textbox_idnumber);
            group_infor_student.Controls.Add(label2);
            group_infor_student.Location = new Point(17, 76);
            group_infor_student.Name = "group_infor_student";
            group_infor_student.Size = new Size(355, 259);
            group_infor_student.TabIndex = 2;
            group_infor_student.TabStop = false;
            group_infor_student.Text = "Thông tin sinh viên";
            // 
            // combobox_class
            // 
            combobox_class.FormattingEnabled = true;
            combobox_class.Location = new Point(90, 5);
            combobox_class.Name = "combobox_class";
            combobox_class.Size = new Size(245, 28);
            combobox_class.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(17, 13);
            label1.Name = "label1";
            label1.Size = new Size(67, 20);
            label1.TabIndex = 0;
            label1.Text = "chọn lớp";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(17, 41);
            label2.Name = "label2";
            label2.Size = new Size(95, 20);
            label2.TabIndex = 0;
            label2.Text = "Mã Sinh Viên";
            // 
            // textbox_idnumber
            // 
            textbox_idnumber.Location = new Point(118, 34);
            textbox_idnumber.Name = "textbox_idnumber";
            textbox_idnumber.Size = new Size(216, 27);
            textbox_idnumber.TabIndex = 1;
            // 
            // textbox_name
            // 
            textbox_name.Location = new Point(118, 93);
            textbox_name.Name = "textbox_name";
            textbox_name.Size = new Size(216, 27);
            textbox_name.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(17, 100);
            label3.Name = "label3";
            label3.Size = new Size(56, 20);
            label3.TabIndex = 2;
            label3.Text = "Họ Tên";
            // 
            // textbox_livingplace
            // 
            textbox_livingplace.Location = new Point(118, 153);
            textbox_livingplace.Name = "textbox_livingplace";
            textbox_livingplace.Size = new Size(216, 27);
            textbox_livingplace.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(17, 160);
            label4.Name = "label4";
            label4.Size = new Size(57, 20);
            label4.TabIndex = 4;
            label4.Text = "Địa Chỉ";
            // 
            // btn_update
            // 
            btn_update.Location = new Point(43, 210);
            btn_update.Name = "btn_update";
            btn_update.Size = new Size(137, 29);
            btn_update.TabIndex = 6;
            btn_update.Text = "Cập nhật";
            btn_update.UseVisualStyleBackColor = true;
            // 
            // btn_delete
            // 
            btn_delete.Location = new Point(203, 210);
            btn_delete.Name = "btn_delete";
            btn_delete.Size = new Size(94, 29);
            btn_delete.TabIndex = 7;
            btn_delete.Text = "Xóa";
            btn_delete.UseVisualStyleBackColor = true;
            // 
            // checkbox_add_class
            // 
            checkbox_add_class.AutoSize = true;
            checkbox_add_class.Location = new Point(17, 341);
            checkbox_add_class.Name = "checkbox_add_class";
            checkbox_add_class.Size = new Size(94, 24);
            checkbox_add_class.TabIndex = 3;
            checkbox_add_class.Text = "Thêm lớp";
            checkbox_add_class.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btn_add_class);
            groupBox1.Controls.Add(textbox_class_name);
            groupBox1.Controls.Add(label5);
            groupBox1.Location = new Point(17, 371);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(355, 52);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin lớp";
            // 
            // textbox_class_name
            // 
            textbox_class_name.Location = new Point(99, 19);
            textbox_class_name.Name = "textbox_class_name";
            textbox_class_name.Size = new Size(138, 27);
            textbox_class_name.TabIndex = 3;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(17, 26);
            label5.Name = "label5";
            label5.Size = new Size(58, 20);
            label5.TabIndex = 2;
            label5.Text = "Tên lớp";
            // 
            // btn_add_class
            // 
            btn_add_class.Location = new Point(243, 19);
            btn_add_class.Name = "btn_add_class";
            btn_add_class.Size = new Size(91, 29);
            btn_add_class.TabIndex = 4;
            btn_add_class.Text = "Thêm lớp";
            btn_add_class.UseVisualStyleBackColor = true;
            // 
            // Bai2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(714, 450);
            Controls.Add(panel_main);
            Controls.Add(treeview_main);
            Name = "Bai2";
            Text = "Form1";
            panel_main.ResumeLayout(false);
            panel_main.PerformLayout();
            group_infor_student.ResumeLayout(false);
            group_infor_student.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TreeView treeview_main;
        private Panel panel_main;
        private GroupBox group_infor_student;
        private ComboBox combobox_class;
        private Label label1;
        private TextBox textbox_livingplace;
        private Label label4;
        private TextBox textbox_name;
        private Label label3;
        private TextBox textbox_idnumber;
        private Label label2;
        private GroupBox groupBox1;
        private Button btn_add_class;
        private TextBox textbox_class_name;
        private Label label5;
        private CheckBox checkbox_add_class;
        private Button btn_delete;
        private Button btn_update;
    }
}
