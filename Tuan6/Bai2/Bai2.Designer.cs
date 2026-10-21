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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            textbox_studentID = new TextBox();
            textbox_name = new TextBox();
            maskedtextbox_datetime = new MaskedTextBox();
            btn_add = new Button();
            btn_delete = new Button();
            btn_edit = new Button();
            textbox_classID = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 39);
            label1.Name = "label1";
            label1.Size = new Size(56, 20);
            label1.TabIndex = 0;
            label1.Text = "Mã lớp";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 77);
            label2.Name = "label2";
            label2.Size = new Size(47, 20);
            label2.TabIndex = 1;
            label2.Text = "Mã sv";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 116);
            label3.Name = "label3";
            label3.Size = new Size(54, 20);
            label3.TabIndex = 2;
            label3.Text = "Họ tên";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 157);
            label4.Name = "label4";
            label4.Size = new Size(74, 20);
            label4.TabIndex = 3;
            label4.Text = "Ngày sinh";
            // 
            // textbox_studentID
            // 
            textbox_studentID.Location = new Point(100, 74);
            textbox_studentID.Name = "textbox_studentID";
            textbox_studentID.Size = new Size(195, 27);
            textbox_studentID.TabIndex = 5;
            // 
            // textbox_name
            // 
            textbox_name.Location = new Point(100, 113);
            textbox_name.Name = "textbox_name";
            textbox_name.Size = new Size(195, 27);
            textbox_name.TabIndex = 6;
            // 
            // maskedtextbox_datetime
            // 
            maskedtextbox_datetime.Location = new Point(100, 150);
            maskedtextbox_datetime.Mask = "00/00/0000";
            maskedtextbox_datetime.Name = "maskedtextbox_datetime";
            maskedtextbox_datetime.Size = new Size(195, 27);
            maskedtextbox_datetime.TabIndex = 7;
            maskedtextbox_datetime.ValidatingType = typeof(DateTime);
            // 
            // btn_add
            // 
            btn_add.Location = new Point(12, 202);
            btn_add.Name = "btn_add";
            btn_add.Size = new Size(94, 29);
            btn_add.TabIndex = 8;
            btn_add.Text = "Thêm";
            btn_add.UseVisualStyleBackColor = true;
            btn_add.Click += btn_add_Click;
            // 
            // btn_delete
            // 
            btn_delete.Location = new Point(112, 202);
            btn_delete.Name = "btn_delete";
            btn_delete.Size = new Size(94, 29);
            btn_delete.TabIndex = 9;
            btn_delete.Text = "Xóa";
            btn_delete.UseVisualStyleBackColor = true;
            // 
            // btn_edit
            // 
            btn_edit.Location = new Point(212, 202);
            btn_edit.Name = "btn_edit";
            btn_edit.Size = new Size(94, 29);
            btn_edit.TabIndex = 10;
            btn_edit.Text = "Sửa";
            btn_edit.UseVisualStyleBackColor = true;
            // 
            // textbox_classID
            // 
            textbox_classID.Location = new Point(100, 36);
            textbox_classID.Name = "textbox_classID";
            textbox_classID.Size = new Size(195, 27);
            textbox_classID.TabIndex = 11;
            // 
            // Bai2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(315, 274);
            Controls.Add(textbox_classID);
            Controls.Add(btn_edit);
            Controls.Add(btn_delete);
            Controls.Add(btn_add);
            Controls.Add(maskedtextbox_datetime);
            Controls.Add(textbox_name);
            Controls.Add(textbox_studentID);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Bai2";
            Text = "Bai2";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox textbox_studentID;
        private TextBox textbox_name;
        private MaskedTextBox maskedtextbox_datetime;
        private Button btn_add;
        private Button btn_delete;
        private Button btn_edit;
        private TextBox textbox_classID;
    }
}
