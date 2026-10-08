namespace Bai11
{
    partial class bai11
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
            panel1 = new Panel();
            group_service = new GroupBox();
            checkbox_kara = new CheckBox();
            group_features = new GroupBox();
            checkbox_waterheater = new CheckBox();
            checkbox_wifi = new CheckBox();
            checkbox_tv = new CheckBox();
            group_room_type = new GroupBox();
            radio_tripple = new RadioButton();
            radio_couple = new RadioButton();
            radio_single = new RadioButton();
            textbox_dayofstaying = new TextBox();
            label4 = new Label();
            textbox_livingplace = new TextBox();
            label3 = new Label();
            textbox_name = new TextBox();
            label2 = new Label();
            panel2 = new Panel();
            group_sumary = new GroupBox();
            textbox_sum_cash = new TextBox();
            label7 = new Label();
            textbox_sum_customer = new TextBox();
            label6 = new Label();
            btn_sumary = new Button();
            textbox_cash_cal = new TextBox();
            label5 = new Label();
            btn_reset = new Button();
            btn_checkout = new Button();
            checkbox_breakfast = new CheckBox();
            panel1.SuspendLayout();
            group_service.SuspendLayout();
            group_features.SuspendLayout();
            group_room_type.SuspendLayout();
            panel2.SuspendLayout();
            group_sumary.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 163);
            label1.ForeColor = Color.Orange;
            label1.Location = new Point(14, 9);
            label1.Name = "label1";
            label1.Size = new Size(774, 50);
            label1.TabIndex = 0;
            label1.Text = "KHÁCH SẠN THANH THANH - TRẢ PHÒNG";
            // 
            // panel1
            // 
            panel1.Controls.Add(group_service);
            panel1.Controls.Add(group_features);
            panel1.Controls.Add(group_room_type);
            panel1.Controls.Add(textbox_dayofstaying);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(textbox_livingplace);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(textbox_name);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(14, 92);
            panel1.Name = "panel1";
            panel1.Size = new Size(501, 346);
            panel1.TabIndex = 1;
            // 
            // group_service
            // 
            group_service.Controls.Add(checkbox_breakfast);
            group_service.Controls.Add(checkbox_kara);
            group_service.Location = new Point(362, 221);
            group_service.Name = "group_service";
            group_service.Size = new Size(139, 125);
            group_service.TabIndex = 8;
            group_service.TabStop = false;
            group_service.Text = "Dịch vụ";
            // 
            // checkbox_kara
            // 
            checkbox_kara.AutoSize = true;
            checkbox_kara.Location = new Point(6, 26);
            checkbox_kara.Name = "checkbox_kara";
            checkbox_kara.Size = new Size(85, 24);
            checkbox_kara.TabIndex = 0;
            checkbox_kara.Text = "Karaoke";
            checkbox_kara.UseVisualStyleBackColor = true;
            // 
            // group_features
            // 
            group_features.Controls.Add(checkbox_waterheater);
            group_features.Controls.Add(checkbox_wifi);
            group_features.Controls.Add(checkbox_tv);
            group_features.Location = new Point(200, 221);
            group_features.Name = "group_features";
            group_features.Size = new Size(139, 125);
            group_features.TabIndex = 7;
            group_features.TabStop = false;
            group_features.Text = "Tiện ích";
            // 
            // checkbox_waterheater
            // 
            checkbox_waterheater.AutoSize = true;
            checkbox_waterheater.Location = new Point(6, 86);
            checkbox_waterheater.Name = "checkbox_waterheater";
            checkbox_waterheater.Size = new Size(134, 24);
            checkbox_waterheater.TabIndex = 2;
            checkbox_waterheater.Text = "Máy nước nóng";
            checkbox_waterheater.UseVisualStyleBackColor = true;
            // 
            // checkbox_wifi
            // 
            checkbox_wifi.AutoSize = true;
            checkbox_wifi.Location = new Point(6, 56);
            checkbox_wifi.Name = "checkbox_wifi";
            checkbox_wifi.Size = new Size(55, 24);
            checkbox_wifi.TabIndex = 1;
            checkbox_wifi.Text = "wifi";
            checkbox_wifi.UseVisualStyleBackColor = true;
            // 
            // checkbox_tv
            // 
            checkbox_tv.AutoSize = true;
            checkbox_tv.Location = new Point(6, 26);
            checkbox_tv.Name = "checkbox_tv";
            checkbox_tv.Size = new Size(56, 24);
            checkbox_tv.TabIndex = 0;
            checkbox_tv.Text = "TiVi";
            checkbox_tv.UseVisualStyleBackColor = true;
            // 
            // group_room_type
            // 
            group_room_type.Controls.Add(radio_tripple);
            group_room_type.Controls.Add(radio_couple);
            group_room_type.Controls.Add(radio_single);
            group_room_type.Location = new Point(29, 218);
            group_room_type.Name = "group_room_type";
            group_room_type.Size = new Size(139, 125);
            group_room_type.TabIndex = 6;
            group_room_type.TabStop = false;
            group_room_type.Text = "Loại phòng";
            // 
            // radio_tripple
            // 
            radio_tripple.AutoSize = true;
            radio_tripple.Location = new Point(6, 86);
            radio_tripple.Name = "radio_tripple";
            radio_tripple.Size = new Size(93, 24);
            radio_tripple.TabIndex = 2;
            radio_tripple.TabStop = true;
            radio_tripple.Text = "Phòng ba";
            radio_tripple.UseVisualStyleBackColor = true;
            // 
            // radio_couple
            // 
            radio_couple.AutoSize = true;
            radio_couple.Location = new Point(6, 56);
            radio_couple.Name = "radio_couple";
            radio_couple.Size = new Size(98, 24);
            radio_couple.TabIndex = 1;
            radio_couple.TabStop = true;
            radio_couple.Text = "Phòng đôi";
            radio_couple.UseVisualStyleBackColor = true;
            // 
            // radio_single
            // 
            radio_single.AutoSize = true;
            radio_single.Location = new Point(6, 26);
            radio_single.Name = "radio_single";
            radio_single.Size = new Size(102, 24);
            radio_single.TabIndex = 0;
            radio_single.TabStop = true;
            radio_single.Text = "Phòng đơn";
            radio_single.UseVisualStyleBackColor = true;
            // 
            // textbox_dayofstaying
            // 
            textbox_dayofstaying.Location = new Point(135, 128);
            textbox_dayofstaying.Name = "textbox_dayofstaying";
            textbox_dayofstaying.Size = new Size(71, 27);
            textbox_dayofstaying.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(56, 135);
            label4.Name = "label4";
            label4.Size = new Size(75, 20);
            label4.TabIndex = 4;
            label4.Text = "Số ngày ở";
            // 
            // textbox_livingplace
            // 
            textbox_livingplace.Location = new Point(135, 78);
            textbox_livingplace.Name = "textbox_livingplace";
            textbox_livingplace.Size = new Size(342, 27);
            textbox_livingplace.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(56, 85);
            label3.Name = "label3";
            label3.Size = new Size(55, 20);
            label3.TabIndex = 2;
            label3.Text = "Địa chỉ";
            // 
            // textbox_name
            // 
            textbox_name.Location = new Point(135, 31);
            textbox_name.Name = "textbox_name";
            textbox_name.Size = new Size(224, 27);
            textbox_name.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(56, 38);
            label2.Name = "label2";
            label2.Size = new Size(73, 20);
            label2.TabIndex = 0;
            label2.Text = "Họ và tên";
            // 
            // panel2
            // 
            panel2.Controls.Add(group_sumary);
            panel2.Controls.Add(btn_sumary);
            panel2.Controls.Add(textbox_cash_cal);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(btn_reset);
            panel2.Controls.Add(btn_checkout);
            panel2.Location = new Point(521, 92);
            panel2.Name = "panel2";
            panel2.Size = new Size(267, 346);
            panel2.TabIndex = 2;
            // 
            // group_sumary
            // 
            group_sumary.Controls.Add(textbox_sum_cash);
            group_sumary.Controls.Add(label7);
            group_sumary.Controls.Add(textbox_sum_customer);
            group_sumary.Controls.Add(label6);
            group_sumary.Location = new Point(17, 160);
            group_sumary.Name = "group_sumary";
            group_sumary.Size = new Size(237, 125);
            group_sumary.TabIndex = 12;
            group_sumary.TabStop = false;
            group_sumary.Text = "Thông tin tổng kết";
            // 
            // textbox_sum_cash
            // 
            textbox_sum_cash.Location = new Point(121, 61);
            textbox_sum_cash.Name = "textbox_sum_cash";
            textbox_sum_cash.ReadOnly = true;
            textbox_sum_cash.Size = new Size(110, 27);
            textbox_sum_cash.TabIndex = 12;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(15, 68);
            label7.Name = "label7";
            label7.Size = new Size(72, 20);
            label7.TabIndex = 11;
            label7.Text = "Tổng tiền";
            // 
            // textbox_sum_customer
            // 
            textbox_sum_customer.Location = new Point(121, 26);
            textbox_sum_customer.Name = "textbox_sum_customer";
            textbox_sum_customer.ReadOnly = true;
            textbox_sum_customer.Size = new Size(110, 27);
            textbox_sum_customer.TabIndex = 10;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(15, 33);
            label6.Name = "label6";
            label6.Size = new Size(100, 20);
            label6.TabIndex = 9;
            label6.Text = "Số lượt người";
            // 
            // btn_sumary
            // 
            btn_sumary.Location = new Point(13, 112);
            btn_sumary.Name = "btn_sumary";
            btn_sumary.Size = new Size(94, 29);
            btn_sumary.TabIndex = 11;
            btn_sumary.Text = "Tổng kết";
            btn_sumary.UseVisualStyleBackColor = true;
            // 
            // textbox_cash_cal
            // 
            textbox_cash_cal.Location = new Point(92, 63);
            textbox_cash_cal.Name = "textbox_cash_cal";
            textbox_cash_cal.ReadOnly = true;
            textbox_cash_cal.Size = new Size(162, 27);
            textbox_cash_cal.TabIndex = 10;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(13, 70);
            label5.Name = "label5";
            label5.Size = new Size(78, 20);
            label5.TabIndex = 9;
            label5.Text = "Thành tiền";
            // 
            // btn_reset
            // 
            btn_reset.Location = new Point(160, 12);
            btn_reset.Name = "btn_reset";
            btn_reset.Size = new Size(94, 29);
            btn_reset.TabIndex = 1;
            btn_reset.Text = "Nhập mới";
            btn_reset.UseVisualStyleBackColor = true;
            // 
            // btn_checkout
            // 
            btn_checkout.Location = new Point(13, 12);
            btn_checkout.Name = "btn_checkout";
            btn_checkout.Size = new Size(94, 29);
            btn_checkout.TabIndex = 0;
            btn_checkout.Text = "Thanh toán";
            btn_checkout.UseVisualStyleBackColor = true;
            // 
            // checkbox_breakfast
            // 
            checkbox_breakfast.AutoSize = true;
            checkbox_breakfast.Location = new Point(6, 56);
            checkbox_breakfast.Name = "checkbox_breakfast";
            checkbox_breakfast.Size = new Size(84, 24);
            checkbox_breakfast.TabIndex = 1;
            checkbox_breakfast.Text = "Ăn sáng";
            checkbox_breakfast.UseVisualStyleBackColor = true;
            // 
            // bai11
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(label1);
            Name = "bai11";
            Text = "Form1";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            group_service.ResumeLayout(false);
            group_service.PerformLayout();
            group_features.ResumeLayout(false);
            group_features.PerformLayout();
            group_room_type.ResumeLayout(false);
            group_room_type.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            group_sumary.ResumeLayout(false);
            group_sumary.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Panel panel1;
        private TextBox textbox_dayofstaying;
        private Label label4;
        private TextBox textbox_livingplace;
        private Label label3;
        private TextBox textbox_name;
        private Label label2;
        private Panel panel2;
        private GroupBox group_service;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
        private CheckBox checkbox_kara;
        private GroupBox group_features;
        private CheckBox checkbox_waterheater;
        private CheckBox checkbox_wifi;
        private CheckBox checkbox_tv;
        private GroupBox group_room_type;
        private RadioButton radio_tripple;
        private RadioButton radio_couple;
        private RadioButton radio_single;
        private GroupBox group_sumary;
        private TextBox textbox_sum_cash;
        private Label label7;
        private TextBox textbox_sum_customer;
        private Label label6;
        private Button btn_sumary;
        private TextBox textbox_cash_cal;
        private Label label5;
        private Button btn_reset;
        private Button btn_checkout;
        private CheckBox checkbox_breakfast;
    }
}
