namespace Bai6
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
            treeview = new TreeView();
            panel1 = new Panel();
            btn_add = new Button();
            textbox_lastname = new TextBox();
            textbox_firstname = new TextBox();
            label2 = new Label();
            label1 = new Label();
            btn_exit = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // treeview
            // 
            treeview.Location = new Point(12, 12);
            treeview.Name = "treeview";
            treeview.Size = new Size(151, 301);
            treeview.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(btn_add);
            panel1.Controls.Add(textbox_lastname);
            panel1.Controls.Add(textbox_firstname);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(169, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(222, 136);
            panel1.TabIndex = 1;
            // 
            // btn_add
            // 
            btn_add.Location = new Point(116, 96);
            btn_add.Name = "btn_add";
            btn_add.Size = new Size(94, 29);
            btn_add.TabIndex = 4;
            btn_add.Text = "Add";
            btn_add.UseVisualStyleBackColor = true;
            // 
            // textbox_lastname
            // 
            textbox_lastname.Location = new Point(85, 63);
            textbox_lastname.Name = "textbox_lastname";
            textbox_lastname.Size = new Size(125, 27);
            textbox_lastname.TabIndex = 3;
            // 
            // textbox_firstname
            // 
            textbox_firstname.Location = new Point(86, 6);
            textbox_firstname.Name = "textbox_firstname";
            textbox_firstname.Size = new Size(133, 27);
            textbox_firstname.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 70);
            label2.Name = "label2";
            label2.Size = new Size(76, 20);
            label2.TabIndex = 1;
            label2.Text = "Last name";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 13);
            label1.Name = "label1";
            label1.Size = new Size(77, 20);
            label1.TabIndex = 0;
            label1.Text = "First name";
            // 
            // btn_exit
            // 
            btn_exit.Location = new Point(294, 170);
            btn_exit.Name = "btn_exit";
            btn_exit.Size = new Size(94, 29);
            btn_exit.TabIndex = 2;
            btn_exit.Text = "Exit";
            btn_exit.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(403, 325);
            Controls.Add(btn_exit);
            Controls.Add(panel1);
            Controls.Add(treeview);
            Name = "Form1";
            Text = "Bai6";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TreeView treeview;
        private Panel panel1;
        private Button btn_add;
        private TextBox textbox_lastname;
        private TextBox textbox_firstname;
        private Label label2;
        private Label label1;
        private Button btn_exit;
    }
}
