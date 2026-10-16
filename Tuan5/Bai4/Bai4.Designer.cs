namespace Bai4
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
            tabcontrol = new TabControl();
            tab1 = new TabPage();
            tab2 = new TabPage();
            btn_exit = new Button();
            tabcontrol.SuspendLayout();
            SuspendLayout();
            // 
            // tabcontrol
            // 
            tabcontrol.Controls.Add(tab1);
            tabcontrol.Controls.Add(tab2);
            tabcontrol.Location = new Point(12, 12);
            tabcontrol.Name = "tabcontrol";
            tabcontrol.SelectedIndex = 0;
            tabcontrol.Size = new Size(482, 388);
            tabcontrol.TabIndex = 0;
            // 
            // tab1
            // 
            tab1.Location = new Point(4, 29);
            tab1.Name = "tab1";
            tab1.Padding = new Padding(3);
            tab1.Size = new Size(474, 355);
            tab1.TabIndex = 0;
            tab1.Text = "ANH - VIỆT";
            tab1.UseVisualStyleBackColor = true;
            // 
            // tab2
            // 
            tab2.Location = new Point(4, 29);
            tab2.Name = "tab2";
            tab2.Padding = new Padding(3);
            tab2.Size = new Size(474, 355);
            tab2.TabIndex = 1;
            tab2.Text = "VIỆT - ANH";
            tab2.UseVisualStyleBackColor = true;
            // 
            // btn_exit
            // 
            btn_exit.Location = new Point(336, 409);
            btn_exit.Name = "btn_exit";
            btn_exit.Size = new Size(154, 29);
            btn_exit.TabIndex = 1;
            btn_exit.Text = "Thoát";
            btn_exit.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(506, 450);
            Controls.Add(btn_exit);
            Controls.Add(tabcontrol);
            Name = "Form1";
            Text = "Form1";
            tabcontrol.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabcontrol;
        private TabPage tab1;
        private TabPage tab2;
        private Button btn_exit;
    }
}
