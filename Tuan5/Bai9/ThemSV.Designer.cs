namespace Bai9
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            textbox_name = new TextBox();
            label2 = new Label();
            combo_class = new ComboBox();
            btn_update = new Button();
            btn_back = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 30);
            label1.Name = "label1";
            label1.Size = new Size(73, 20);
            label1.TabIndex = 0;
            label1.Text = "Họ và tên";
            // 
            // textbox_name
            // 
            textbox_name.Location = new Point(91, 23);
            textbox_name.Name = "textbox_name";
            textbox_name.Size = new Size(272, 27);
            textbox_name.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 82);
            label2.Name = "label2";
            label2.Size = new Size(34, 20);
            label2.TabIndex = 2;
            label2.Text = "Lớp";
            // 
            // combo_class
            // 
            combo_class.FormattingEnabled = true;
            combo_class.Location = new Point(91, 74);
            combo_class.Name = "combo_class";
            combo_class.Size = new Size(118, 28);
            combo_class.TabIndex = 3;
            // 
            // btn_update
            // 
            btn_update.Location = new Point(66, 146);
            btn_update.Name = "btn_update";
            btn_update.Size = new Size(94, 29);
            btn_update.TabIndex = 4;
            btn_update.Text = "Cập nhật";
            btn_update.UseVisualStyleBackColor = true;
            // 
            // btn_back
            // 
            btn_back.Location = new Point(251, 146);
            btn_back.Name = "btn_back";
            btn_back.Size = new Size(94, 29);
            btn_back.TabIndex = 5;
            btn_back.Text = "Trở về";
            btn_back.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(412, 187);
            Controls.Add(btn_back);
            Controls.Add(btn_update);
            Controls.Add(combo_class);
            Controls.Add(label2);
            Controls.Add(textbox_name);
            Controls.Add(label1);
            Name = "Form1";
            Text = "ThemSV";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textbox_name;
        private Label label2;
        private ComboBox combo_class;
        private Button btn_update;
        private Button btn_back;
    }
}