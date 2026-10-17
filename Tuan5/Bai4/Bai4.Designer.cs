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
            label2 = new Label();
            label1 = new Label();
            listbox_tab1 = new ListBox();
            textbox_tab1 = new TextBox();
            combobox_tab1 = new ComboBox();
            tab2 = new TabPage();
            label3 = new Label();
            label4 = new Label();
            listbox_tab2 = new ListBox();
            textbox_tab2 = new TextBox();
            combobox_tab2 = new ComboBox();
            btn_exit = new Button();
            tabcontrol.SuspendLayout();
            tab1.SuspendLayout();
            tab2.SuspendLayout();
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
            tabcontrol.SelectedIndexChanged += tabcontrol_SelectedIndexChanged;
            // 
            // tab1
            // 
            tab1.Controls.Add(label2);
            tab1.Controls.Add(label1);
            tab1.Controls.Add(listbox_tab1);
            tab1.Controls.Add(textbox_tab1);
            tab1.Controls.Add(combobox_tab1);
            tab1.Location = new Point(4, 29);
            tab1.Name = "tab1";
            tab1.Padding = new Padding(3);
            tab1.Size = new Size(474, 355);
            tab1.TabIndex = 0;
            tab1.Text = "ANH - VIỆT";
            tab1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(392, 38);
            label2.Name = "label2";
            label2.Size = new Size(76, 20);
            label2.TabIndex = 4;
            label2.Text = "Tiếng Việt";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 38);
            label1.Name = "label1";
            label1.Size = new Size(76, 20);
            label1.TabIndex = 3;
            label1.Text = "Tiếng Anh";
            // 
            // listbox_tab1
            // 
            listbox_tab1.FormattingEnabled = true;
            listbox_tab1.Location = new Point(6, 119);
            listbox_tab1.Name = "listbox_tab1";
            listbox_tab1.Size = new Size(189, 204);
            listbox_tab1.TabIndex = 2;
            // 
            // textbox_tab1
            // 
            textbox_tab1.Location = new Point(221, 71);
            textbox_tab1.Multiline = true;
            textbox_tab1.Name = "textbox_tab1";
            textbox_tab1.Size = new Size(247, 258);
            textbox_tab1.TabIndex = 1;
            // 
            // combobox_tab1
            // 
            combobox_tab1.FormattingEnabled = true;
            combobox_tab1.Location = new Point(6, 71);
            combobox_tab1.Name = "combobox_tab1";
            combobox_tab1.Size = new Size(189, 28);
            combobox_tab1.TabIndex = 0;
            // 
            // tab2
            // 
            tab2.Controls.Add(label3);
            tab2.Controls.Add(label4);
            tab2.Controls.Add(listbox_tab2);
            tab2.Controls.Add(textbox_tab2);
            tab2.Controls.Add(combobox_tab2);
            tab2.Location = new Point(4, 29);
            tab2.Name = "tab2";
            tab2.Padding = new Padding(3);
            tab2.Size = new Size(474, 355);
            tab2.TabIndex = 1;
            tab2.Text = "VIỆT - ANH";
            tab2.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(392, 32);
            label3.Name = "label3";
            label3.Size = new Size(76, 20);
            label3.TabIndex = 9;
            label3.Text = "Tiếng Anh";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 32);
            label4.Name = "label4";
            label4.Size = new Size(76, 20);
            label4.TabIndex = 8;
            label4.Text = "Tiếng Việt";
            // 
            // listbox_tab2
            // 
            listbox_tab2.FormattingEnabled = true;
            listbox_tab2.Location = new Point(6, 99);
            listbox_tab2.Name = "listbox_tab2";
            listbox_tab2.Size = new Size(189, 224);
            listbox_tab2.TabIndex = 7;
            // 
            // textbox_tab2
            // 
            textbox_tab2.Location = new Point(221, 65);
            textbox_tab2.Multiline = true;
            textbox_tab2.Name = "textbox_tab2";
            textbox_tab2.Size = new Size(247, 258);
            textbox_tab2.TabIndex = 6;
            // 
            // combobox_tab2
            // 
            combobox_tab2.FormattingEnabled = true;
            combobox_tab2.Location = new Point(6, 65);
            combobox_tab2.Name = "combobox_tab2";
            combobox_tab2.Size = new Size(189, 28);
            combobox_tab2.TabIndex = 5;
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
            tab1.ResumeLayout(false);
            tab1.PerformLayout();
            tab2.ResumeLayout(false);
            tab2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabcontrol;
        private TabPage tab1;
        private TabPage tab2;
        private Button btn_exit;
        private TextBox textbox_tab1;
        private ComboBox combobox_tab1;
        private Label label2;
        private Label label1;
        private ListBox listbox_tab1;
        private Label label3;
        private Label label4;
        private ListBox listbox_tab2;
        private TextBox textbox_tab2;
        private ComboBox combobox_tab2;
    }
}
