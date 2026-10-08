using System;
using System.Windows.Forms;
using Bai1;

namespace Bai11
{
    public partial class bai11 : Form
    {
        // Biến lưu thông tin tổng kết trong ngày
        private int tongLuotKhach = 0;
        private double tongTien = 0;

        Bai1.bai1 bai1Form = new Bai1.bai1();
        public bai11()
        {
            InitializeComponent();

            // Đăng ký sự kiện Form Load và Form Closing
            this.Load += bai11_Load;
            this.FormClosing += bai11_FormClosing;

            // Đăng ký sự kiện các nút
            btn_checkout.Click += btn_checkout_Click;
            btn_reset.Click += btn_reset_Click;
            btn_sumary.Click += btn_sumary_Click;

            // Chỉ cho phép nhập số vào ô số ngày ở
            textbox_dayofstaying.KeyPress += textbox_dayofstaying_KeyPress;

            // Đăng ký sự kiện kiểm tra thông tin nhập liệu
            textbox_name.TextChanged += (s, e) => KiemTraThongTin();
            textbox_livingplace.TextChanged += (s, e) => KiemTraThongTin();
            textbox_dayofstaying.TextChanged += (s, e) => KiemTraThongTin();

            radio_single.CheckedChanged += (s, e) => KiemTraThongTin();
            radio_couple.CheckedChanged += (s, e) => KiemTraThongTin();
            radio_tripple.CheckedChanged += (s, e) => KiemTraThongTin();
        }

        // − Form_Load: con trỏ văn bản đặt vào ô tên khách hàng, các button TongKet, NhapMoi, ThanhToan bị mờ (enabled=false)
        private void bai11_Load(object? sender, EventArgs e)
        {
            KhoiTaoForm();
            textbox_sum_customer.Text = "0";
            textbox_sum_cash.Text = "0 VNĐ";
        }

        // Chỉ cho phép nhập số vào ô số ngày ở
        private void textbox_dayofstaying_KeyPress(object? sender, KeyPressEventArgs e)
        {
            bai1Form.txt_KeyPress(sender, e, intnumber: true, lineofnum: false);
        }

        // Kiểm tra đã nhập đầy đủ thông tin hay chưa
        private void KiemTraThongTin()
        {
            bool coTen = !string.IsNullOrWhiteSpace(textbox_name.Text);
            bool coDiaChi = !string.IsNullOrWhiteSpace(textbox_livingplace.Text);
            bool coSoNgay = int.TryParse(textbox_dayofstaying.Text, out int soNgay) && soNgay > 0;
            bool coLoaiPhong = radio_single.Checked || radio_couple.Checked || radio_tripple.Checked;

            // Khi nhập đầy đủ thông tin thì btnThanhToan có tác dụng
            btn_checkout.Enabled = coTen && coDiaChi && coSoNgay && coLoaiPhong;
        }

        // − btnThanhToan: thực hiện tính tiền cho khách vừa nhập và hiển thị lên Thành Tiền,
        // đồng thời lưu lại thông tin tổng số tiền và tổng số lượt khách.
        // btnNhapMoi, btnTongKet sáng lên sẵn sàng cho việc nhập khách mới.
        private void btn_checkout_Click(object? sender, EventArgs e)
        {
            if (!int.TryParse(textbox_dayofstaying.Text, out int soNgay) || soNgay <= 0)
            {
                MessageBox.Show("Số ngày ở phải là số nguyên lớn hơn 0!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textbox_dayofstaying.Focus();
                return;
            }

            // 1. Tiền phòng (tính theo ngày)
            double giaPhongMotNgay = 0;
            if (radio_single.Checked) giaPhongMotNgay = 300000;
            else if (radio_couple.Checked) giaPhongMotNgay = 350000;
            else if (radio_tripple.Checked) giaPhongMotNgay = 400000;

            double tienPhong = giaPhongMotNgay * soNgay;

            // 2. Tiện nghi: mỗi loại cộng thêm 10.000đ
            double tienTienNghi = 0;
            if (checkbox_tv.Checked) tienTienNghi += 10000;
            if (checkbox_wifi.Checked) tienTienNghi += 10000;
            if (checkbox_waterheater.Checked) tienTienNghi += 10000;

            // 3. Dịch vụ:
            // Karaoke: 50.000đ
            // Ăn sáng: 15.000đ/1 ngày
            double tienDichVu = 0;
            if (checkbox_kara.Checked) tienDichVu += 50000;
            if (checkbox_breakfast.Checked) tienDichVu += 15000 * soNgay;

            // Tổng thành tiền
            double thanhTien = tienPhong + tienTienNghi + tienDichVu;

            // Hiển thị lên ô Thành tiền
            textbox_cash_cal.Text = thanhTien.ToString("N0") + " VNĐ";

            // Lưu lại thông tin tổng số tiền và tổng số lượt khách
            tongTien += thanhTien;
            tongLuotKhach++;

            // btnNhapMoi, btnTongKet sáng lên, btnThanhToan mờ đi
            btn_reset.Enabled = true;
            btn_sumary.Enabled = true;
            btn_checkout.Enabled = false;
        }

        // − btnNhapMoi: khởi tạo lại trạng thái ban đầu của Form, btnNhapMoi bị mờ
        private void btn_reset_Click(object? sender, EventArgs e)
        {
            KhoiTaoForm();
        }

        // − btnTongKet: Ghi lại thông tin tổng số khách và tổng tiền Thanh toán vào các ô tương ứng,
        // đồng thời khởi tạo lại giá trị tổng số khách hàng = 0, tổng tiền thanh toán = 0. btnTongKet bị mờ.
        private void btn_sumary_Click(object? sender, EventArgs e)
        {
            textbox_sum_customer.Text = tongLuotKhach.ToString();
            textbox_sum_cash.Text = tongTien.ToString("N0") + " VNĐ";

            // Khởi tạo lại giá trị tổng số khách = 0, tổng tiền = 0
            tongLuotKhach = 0;
            tongTien = 0;

            btn_sumary.Enabled = false;
        }

        // − btnThoat_Click: hỏi người dùng có chắc chắn thoát khỏi chương trình hay không? Yes: thoát, No: không.
        public void btnThoat_Click(object? sender, EventArgs e)
        {
            this.Close();
        }

        private void bai11_FormClosing(object? sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn thoát khỏi chương trình?",
                "Xác nhận thoát",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        // Khởi tạo lại trạng thái ban đầu của Form
        private void KhoiTaoForm()
        {
            textbox_name.Clear();
            textbox_livingplace.Clear();
            textbox_dayofstaying.Clear();
            textbox_cash_cal.Clear();

            radio_single.Checked = false;
            radio_couple.Checked = false;
            radio_tripple.Checked = false;

            checkbox_tv.Checked = false;
            checkbox_wifi.Checked = false;
            checkbox_waterheater.Checked = false;

            checkbox_kara.Checked = false;
            checkbox_breakfast.Checked = false;

            btn_checkout.Enabled = false;
            btn_reset.Enabled = false;

            textbox_name.Focus();
        }
    }
}
