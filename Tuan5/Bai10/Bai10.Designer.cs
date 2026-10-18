namespace Bai10
{
    partial class Bai10
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
            clock = new Label();
            btn_start = new Button();
            SuspendLayout();
            // 
            // clock
            // 
            clock.AutoSize = true;
            clock.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 163);
            clock.Location = new Point(84, 9);
            clock.Name = "clock";
            clock.Size = new Size(109, 46);
            clock.TabIndex = 0;
            clock.Text = "00:00";
            // 
            // btn_start
            // 
            btn_start.Location = new Point(84, 58);
            btn_start.Name = "btn_start";
            btn_start.Size = new Size(94, 29);
            btn_start.TabIndex = 1;
            btn_start.Text = "Bắt đầu";
            btn_start.UseVisualStyleBackColor = true;
            // 
            // Bai10
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(269, 125);
            Controls.Add(btn_start);
            Controls.Add(clock);
            Name = "Bai10";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label clock;
        private Button btn_start;
    }
}
