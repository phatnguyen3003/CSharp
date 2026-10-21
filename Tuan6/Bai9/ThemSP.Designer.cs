namespace Bai9
{
    partial class ThemSP
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
            textbox_tenSP = new TextBox();
            btn_them = new Button();
            btn_thoat = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 31);
            label1.Name = "label1";
            label1.Size = new Size(101, 20);
            label1.TabIndex = 0;
            label1.Text = "Tên Sản Phẩm";
            // 
            // textbox_tenSP
            // 
            textbox_tenSP.Location = new Point(119, 24);
            textbox_tenSP.Name = "textbox_tenSP";
            textbox_tenSP.Size = new Size(256, 27);
            textbox_tenSP.TabIndex = 1;
            // 
            // btn_them
            // 
            btn_them.Location = new Point(32, 91);
            btn_them.Name = "btn_them";
            btn_them.Size = new Size(94, 29);
            btn_them.TabIndex = 2;
            btn_them.Text = "Thêm";
            btn_them.UseVisualStyleBackColor = true;
            // 
            // btn_thoat
            // 
            btn_thoat.Location = new Point(261, 91);
            btn_thoat.Name = "btn_thoat";
            btn_thoat.Size = new Size(94, 29);
            btn_thoat.TabIndex = 3;
            btn_thoat.Text = "Thoát";
            btn_thoat.UseVisualStyleBackColor = true;
            // 
            // ThemSP
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(387, 188);
            Controls.Add(btn_thoat);
            Controls.Add(btn_them);
            Controls.Add(textbox_tenSP);
            Controls.Add(label1);
            Name = "ThemSP";
            Text = "ThemSP";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textbox_tenSP;
        private Button btn_them;
        private Button btn_thoat;
    }
}