namespace Bai11
{
    partial class Bai11
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
            menu_baitap = new MenuStrip();
            SuspendLayout();
            // 
            // menu_baitap
            // 
            menu_baitap.ImageScalingSize = new Size(20, 20);
            menu_baitap.Location = new Point(0, 0);
            menu_baitap.Name = "menu_baitap";
            menu_baitap.Size = new Size(577, 24);
            menu_baitap.TabIndex = 0;
            menu_baitap.Text = "menuStrip1";
            // 
            // Bai11
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(577, 335);
            Controls.Add(menu_baitap);
            MainMenuStrip = menu_baitap;
            Name = "Bai11";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menu_baitap;
    }
}
