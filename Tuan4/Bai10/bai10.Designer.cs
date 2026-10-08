namespace Bai10
{
    partial class bai10
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
            components = new System.ComponentModel.Container();
            label1 = new Label();
            label2 = new Label();
            textbox_name = new TextBox();
            textbox_guest_number = new TextBox();
            label3 = new Label();
            checkbox_student = new CheckBox();
            group_drinks = new GroupBox();
            radio_cafe_scream = new RadioButton();
            radio_cafe_ice = new RadioButton();
            radio_cafe_milk_ice = new RadioButton();
            radio_cafe_milk = new RadioButton();
            radio_cafe_black = new RadioButton();
            group_foods = new GroupBox();
            checkbox_noodle_spicy = new CheckBox();
            checkbox_noodle_beef = new CheckBox();
            checkbox_noodle_egg = new CheckBox();
            checkbox_bread_fish = new CheckBox();
            checkbox_bread_egg = new CheckBox();
            btn_cal = new Button();
            btn_reset = new Button();
            btn_exit = new Button();
            btn_payout = new Button();
            group_sumary = new GroupBox();
            textbox_sumary_cash = new TextBox();
            label5 = new Label();
            textbox_sumary_customer = new TextBox();
            label4 = new Label();
            errorProvider1 = new ErrorProvider(components);
            group_drinks.SuspendLayout();
            group_foods.SuspendLayout();
            group_sumary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label1.ForeColor = Color.Orange;
            label1.Location = new Point(171, 9);
            label1.Name = "label1";
            label1.Size = new Size(331, 54);
            label1.TabIndex = 0;
            label1.Text = "CAFE SINH VIÊN";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 74);
            label2.Name = "label2";
            label2.Size = new Size(114, 20);
            label2.TabIndex = 1;
            label2.Text = "Tên khách hàng:";
            // 
            // textbox_name
            // 
            textbox_name.Location = new Point(132, 67);
            textbox_name.Name = "textbox_name";
            textbox_name.Size = new Size(537, 27);
            textbox_name.TabIndex = 2;
            textbox_name.TextChanged += textbox_name_textChanged;
            // 
            // textbox_guest_number
            // 
            textbox_guest_number.Location = new Point(132, 110);
            textbox_guest_number.Name = "textbox_guest_number";
            textbox_guest_number.Size = new Size(111, 27);
            textbox_guest_number.TabIndex = 4;
            textbox_guest_number.KeyPress += textbox_keyPress;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 117);
            label3.Name = "label3";
            label3.Size = new Size(108, 20);
            label3.TabIndex = 3;
            label3.Text = "Số khách hàng:";
            // 
            // checkbox_student
            // 
            checkbox_student.AutoSize = true;
            checkbox_student.Location = new Point(285, 143);
            checkbox_student.Name = "checkbox_student";
            checkbox_student.Size = new Size(97, 24);
            checkbox_student.TabIndex = 5;
            checkbox_student.Text = "Sinh viên?";
            checkbox_student.UseVisualStyleBackColor = true;
            // 
            // group_drinks
            // 
            group_drinks.Controls.Add(radio_cafe_scream);
            group_drinks.Controls.Add(radio_cafe_ice);
            group_drinks.Controls.Add(radio_cafe_milk_ice);
            group_drinks.Controls.Add(radio_cafe_milk);
            group_drinks.Controls.Add(radio_cafe_black);
            group_drinks.Location = new Point(12, 191);
            group_drinks.Name = "group_drinks";
            group_drinks.Size = new Size(325, 172);
            group_drinks.TabIndex = 6;
            group_drinks.TabStop = false;
            group_drinks.Text = "Nước uống";
            // 
            // radio_cafe_scream
            // 
            radio_cafe_scream.AutoSize = true;
            radio_cafe_scream.Location = new Point(159, 69);
            radio_cafe_scream.Name = "radio_cafe_scream";
            radio_cafe_scream.Size = new Size(108, 24);
            radio_cafe_scream.TabIndex = 4;
            radio_cafe_scream.TabStop = true;
            radio_cafe_scream.Text = "Cà phê kem";
            radio_cafe_scream.UseVisualStyleBackColor = true;
            // 
            // radio_cafe_ice
            // 
            radio_cafe_ice.AutoSize = true;
            radio_cafe_ice.Location = new Point(159, 26);
            radio_cafe_ice.Name = "radio_cafe_ice";
            radio_cafe_ice.Size = new Size(97, 24);
            radio_cafe_ice.TabIndex = 3;
            radio_cafe_ice.TabStop = true;
            radio_cafe_ice.Text = "Cà phê đá";
            radio_cafe_ice.UseVisualStyleBackColor = true;
            // 
            // radio_cafe_milk_ice
            // 
            radio_cafe_milk_ice.AutoSize = true;
            radio_cafe_milk_ice.Location = new Point(6, 118);
            radio_cafe_milk_ice.Name = "radio_cafe_milk_ice";
            radio_cafe_milk_ice.Size = new Size(124, 24);
            radio_cafe_milk_ice.TabIndex = 2;
            radio_cafe_milk_ice.TabStop = true;
            radio_cafe_milk_ice.Text = "Cà phê sữa đá";
            radio_cafe_milk_ice.UseVisualStyleBackColor = true;
            // 
            // radio_cafe_milk
            // 
            radio_cafe_milk.AutoSize = true;
            radio_cafe_milk.Location = new Point(6, 69);
            radio_cafe_milk.Name = "radio_cafe_milk";
            radio_cafe_milk.Size = new Size(103, 24);
            radio_cafe_milk.TabIndex = 1;
            radio_cafe_milk.TabStop = true;
            radio_cafe_milk.Text = "Cà phê sữa";
            radio_cafe_milk.UseVisualStyleBackColor = true;
            // 
            // radio_cafe_black
            // 
            radio_cafe_black.AutoSize = true;
            radio_cafe_black.Location = new Point(6, 26);
            radio_cafe_black.Name = "radio_cafe_black";
            radio_cafe_black.Size = new Size(105, 24);
            radio_cafe_black.TabIndex = 0;
            radio_cafe_black.TabStop = true;
            radio_cafe_black.Text = "Cà phê đen";
            radio_cafe_black.UseVisualStyleBackColor = true;
            // 
            // group_foods
            // 
            group_foods.Controls.Add(checkbox_noodle_spicy);
            group_foods.Controls.Add(checkbox_noodle_beef);
            group_foods.Controls.Add(checkbox_noodle_egg);
            group_foods.Controls.Add(checkbox_bread_fish);
            group_foods.Controls.Add(checkbox_bread_egg);
            group_foods.Location = new Point(360, 191);
            group_foods.Name = "group_foods";
            group_foods.Size = new Size(325, 172);
            group_foods.TabIndex = 7;
            group_foods.TabStop = false;
            group_foods.Text = "Thức ăn";
            // 
            // checkbox_noodle_spicy
            // 
            checkbox_noodle_spicy.AutoSize = true;
            checkbox_noodle_spicy.Location = new Point(170, 70);
            checkbox_noodle_spicy.Name = "checkbox_noodle_spicy";
            checkbox_noodle_spicy.Size = new Size(77, 24);
            checkbox_noodle_spicy.TabIndex = 4;
            checkbox_noodle_spicy.Text = "Mỳ cay";
            checkbox_noodle_spicy.UseVisualStyleBackColor = true;
            // 
            // checkbox_noodle_beef
            // 
            checkbox_noodle_beef.AutoSize = true;
            checkbox_noodle_beef.Location = new Point(170, 26);
            checkbox_noodle_beef.Name = "checkbox_noodle_beef";
            checkbox_noodle_beef.Size = new Size(101, 24);
            checkbox_noodle_beef.TabIndex = 3;
            checkbox_noodle_beef.Text = "Mỳ xào bò";
            checkbox_noodle_beef.UseVisualStyleBackColor = true;
            // 
            // checkbox_noodle_egg
            // 
            checkbox_noodle_egg.AutoSize = true;
            checkbox_noodle_egg.Location = new Point(6, 118);
            checkbox_noodle_egg.Name = "checkbox_noodle_egg";
            checkbox_noodle_egg.Size = new Size(122, 24);
            checkbox_noodle_egg.TabIndex = 2;
            checkbox_noodle_egg.Text = "Mỳ tôm trứng";
            checkbox_noodle_egg.UseVisualStyleBackColor = true;
            // 
            // checkbox_bread_fish
            // 
            checkbox_bread_fish.AutoSize = true;
            checkbox_bread_fish.Location = new Point(6, 69);
            checkbox_bread_fish.Name = "checkbox_bread_fish";
            checkbox_bread_fish.Size = new Size(104, 24);
            checkbox_bread_fish.TabIndex = 1;
            checkbox_bread_fish.Text = "Bánh mì cá";
            checkbox_bread_fish.UseVisualStyleBackColor = true;
            // 
            // checkbox_bread_egg
            // 
            checkbox_bread_egg.AutoSize = true;
            checkbox_bread_egg.Location = new Point(6, 26);
            checkbox_bread_egg.Name = "checkbox_bread_egg";
            checkbox_bread_egg.Size = new Size(125, 24);
            checkbox_bread_egg.TabIndex = 0;
            checkbox_bread_egg.Text = "Bánh mì trứng";
            checkbox_bread_egg.UseVisualStyleBackColor = true;
            // 
            // btn_cal
            // 
            btn_cal.Location = new Point(45, 388);
            btn_cal.Name = "btn_cal";
            btn_cal.Size = new Size(112, 41);
            btn_cal.TabIndex = 8;
            btn_cal.Text = "Tính tiền";
            btn_cal.UseVisualStyleBackColor = true;
            // 
            // btn_reset
            // 
            btn_reset.Location = new Point(202, 388);
            btn_reset.Name = "btn_reset";
            btn_reset.Size = new Size(112, 41);
            btn_reset.TabIndex = 9;
            btn_reset.Text = "Nhập lại";
            btn_reset.UseVisualStyleBackColor = true;
            // 
            // btn_exit
            // 
            btn_exit.Location = new Point(547, 388);
            btn_exit.Name = "btn_exit";
            btn_exit.Size = new Size(112, 41);
            btn_exit.TabIndex = 11;
            btn_exit.Text = "Thoát";
            btn_exit.UseVisualStyleBackColor = true;
            // 
            // btn_payout
            // 
            btn_payout.Location = new Point(390, 388);
            btn_payout.Name = "btn_payout";
            btn_payout.Size = new Size(112, 41);
            btn_payout.TabIndex = 10;
            btn_payout.Text = "Thanh toán";
            btn_payout.UseVisualStyleBackColor = true;
            // 
            // group_sumary
            // 
            group_sumary.Controls.Add(textbox_sumary_cash);
            group_sumary.Controls.Add(label5);
            group_sumary.Controls.Add(textbox_sumary_customer);
            group_sumary.Controls.Add(label4);
            group_sumary.Location = new Point(18, 451);
            group_sumary.Name = "group_sumary";
            group_sumary.Size = new Size(667, 109);
            group_sumary.TabIndex = 12;
            group_sumary.TabStop = false;
            group_sumary.Text = "Tổng kết";
            // 
            // textbox_sumary_cash
            // 
            textbox_sumary_cash.Location = new Point(185, 59);
            textbox_sumary_cash.Name = "textbox_sumary_cash";
            textbox_sumary_cash.ReadOnly = true;
            textbox_sumary_cash.Size = new Size(457, 27);
            textbox_sumary_cash.TabIndex = 16;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(33, 66);
            label5.Name = "label5";
            label5.Size = new Size(147, 20);
            label5.TabIndex = 15;
            label5.Text = "Tổng tiền thanh toán";
            // 
            // textbox_sumary_customer
            // 
            textbox_sumary_customer.Location = new Point(184, 26);
            textbox_sumary_customer.Name = "textbox_sumary_customer";
            textbox_sumary_customer.ReadOnly = true;
            textbox_sumary_customer.Size = new Size(457, 27);
            textbox_sumary_customer.TabIndex = 14;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(32, 33);
            label4.Name = "label4";
            label4.Size = new Size(122, 20);
            label4.TabIndex = 13;
            label4.Text = "Tổng khách hàng";
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // bai10
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(697, 587);
            Controls.Add(group_sumary);
            Controls.Add(btn_exit);
            Controls.Add(btn_payout);
            Controls.Add(btn_reset);
            Controls.Add(btn_cal);
            Controls.Add(group_foods);
            Controls.Add(group_drinks);
            Controls.Add(checkbox_student);
            Controls.Add(textbox_guest_number);
            Controls.Add(label3);
            Controls.Add(textbox_name);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "bai10";
            Text = "Form1";
            group_drinks.ResumeLayout(false);
            group_drinks.PerformLayout();
            group_foods.ResumeLayout(false);
            group_foods.PerformLayout();
            group_sumary.ResumeLayout(false);
            group_sumary.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox textbox_name;
        private TextBox textbox_guest_number;
        private Label label3;
        private CheckBox checkbox_student;
        private GroupBox group_drinks;
        private GroupBox group_foods;
        private RadioButton radio_cafe_scream;
        private RadioButton radio_cafe_ice;
        private RadioButton radio_cafe_milk_ice;
        private RadioButton radio_cafe_milk;
        private RadioButton radio_cafe_black;
        private CheckBox checkbox_noodle_spicy;
        private CheckBox checkbox_noodle_beef;
        private CheckBox checkbox_noodle_egg;
        private CheckBox checkbox_bread_fish;
        private CheckBox checkbox_bread_egg;
        private Button btn_cal;
        private Button btn_reset;
        private Button btn_exit;
        private Button btn_payout;
        private GroupBox group_sumary;
        private TextBox textbox_sumary_cash;
        private Label label5;
        private TextBox textbox_sumary_customer;
        private Label label4;
        private ErrorProvider errorProvider1;
    }
}
