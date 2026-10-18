namespace Bai9
{
    partial class Bai9
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Bai9));
            toolStrip1 = new ToolStrip();
            btn_dropdown_update = new ToolStripDropDownButton();
            btn_add = new ToolStripMenuItem();
            btn_switch_class_B = new ToolStripMenuItem();
            btn_switch_class_A = new ToolStripMenuItem();
            btn_delete = new ToolStripMenuItem();
            btn_exit = new ToolStripButton();
            group_A = new GroupBox();
            group_B = new GroupBox();
            listbox_A = new ListBox();
            listbox_B = new ListBox();
            toolStrip1.SuspendLayout();
            group_A.SuspendLayout();
            group_B.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Items.AddRange(new ToolStripItem[] { btn_dropdown_update, btn_exit });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(448, 27);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // btn_dropdown_update
            // 
            btn_dropdown_update.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btn_dropdown_update.DropDownItems.AddRange(new ToolStripItem[] { btn_add, btn_switch_class_B, btn_switch_class_A, btn_delete });
            btn_dropdown_update.ImageTransparentColor = Color.Magenta;
            btn_dropdown_update.Name = "btn_dropdown_update";
            btn_dropdown_update.Size = new Size(82, 24);
            btn_dropdown_update.Text = "Cập nhật";
            // 
            // btn_add
            // 
            btn_add.Name = "btn_add";
            btn_add.Size = new Size(224, 26);
            btn_add.Text = "Nhập học viên mới";
            // 
            // btn_switch_class_B
            // 
            btn_switch_class_B.Name = "btn_switch_class_B";
            btn_switch_class_B.Size = new Size(224, 26);
            btn_switch_class_B.Text = "Chuyển sang lớp B";
            // 
            // btn_switch_class_A
            // 
            btn_switch_class_A.Name = "btn_switch_class_A";
            btn_switch_class_A.Size = new Size(224, 26);
            btn_switch_class_A.Text = "Chuyển sang lớp A";
            // 
            // btn_delete
            // 
            btn_delete.Name = "btn_delete";
            btn_delete.Size = new Size(224, 26);
            btn_delete.Text = "Xóa học viên";
            // 
            // btn_exit
            // 
            btn_exit.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btn_exit.Image = (Image)resources.GetObject("btn_exit.Image");
            btn_exit.ImageTransparentColor = Color.Magenta;
            btn_exit.Name = "btn_exit";
            btn_exit.Size = new Size(67, 24);
            btn_exit.Text = "Kết thúc";
            // 
            // group_A
            // 
            group_A.Controls.Add(listbox_A);
            group_A.Location = new Point(12, 46);
            group_A.Name = "group_A";
            group_A.Size = new Size(174, 246);
            group_A.TabIndex = 1;
            group_A.TabStop = false;
            group_A.Text = "Lớp A";
            // 
            // group_B
            // 
            group_B.Controls.Add(listbox_B);
            group_B.Location = new Point(229, 46);
            group_B.Name = "group_B";
            group_B.Size = new Size(174, 246);
            group_B.TabIndex = 2;
            group_B.TabStop = false;
            group_B.Text = "Lớp B";
            // 
            // listbox_A
            // 
            listbox_A.FormattingEnabled = true;
            listbox_A.Location = new Point(0, 26);
            listbox_A.Name = "listbox_A";
            listbox_A.Size = new Size(174, 224);
            listbox_A.TabIndex = 0;
            // 
            // listbox_B
            // 
            listbox_B.FormattingEnabled = true;
            listbox_B.Location = new Point(0, 27);
            listbox_B.Name = "listbox_B";
            listbox_B.Size = new Size(174, 224);
            listbox_B.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(448, 350);
            Controls.Add(group_B);
            Controls.Add(group_A);
            Controls.Add(toolStrip1);
            Name = "Form1";
            Text = "Form1";
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            group_A.ResumeLayout(false);
            group_B.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip1;
        private ToolStripDropDownButton btn_dropdown_update;
        private ToolStripMenuItem btn_add;
        private ToolStripMenuItem btn_switch_class_B;
        private ToolStripMenuItem btn_switch_class_A;
        private ToolStripMenuItem btn_delete;
        private ToolStripButton btn_exit;
        private GroupBox group_A;
        private ListBox listbox_A;
        private GroupBox group_B;
        private ListBox listbox_B;
    }
}
