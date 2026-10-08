using Bai1;
using System;
using System.Windows.Forms;

namespace Bai10
{
    public partial class bai10 : Form
    {
        private Bai1.bai1 bai1Form = new Bai1.bai1();

        // Biến lưu tổng kết
        private int tongSoKhach = 0;
        private double tongTienThanhToan = 0;

        // Biến lưu thông tin của nhóm khách vừa tính tiền
        private double tienKhachHienTai = 0;
        private int soKhachHienTai = 0;

        public bai10()
        {
            InitializeComponent();

            // Đăng ký sự kiện Form Load
            this.Load += bai10_Load;

            // Đăng ký sự kiện các nút
            btn_cal.Click += btn_cal_Click;
            btn_reset.Click += btn_reset_Click;
            btn_payout.Click += btn_payout_Click;
            btn_exit.Click += btn_exit_Click;

            // Đăng ký sự kiện ô số khách hàng
            textbox_guest_number.TextChanged += (s, e) => KiemTraThongTin();

            // Đăng ký sự kiện cho các loại cafe
            radio_cafe_black.CheckedChanged += Drink_CheckedChanged;
            radio_cafe_ice.CheckedChanged += Drink_CheckedChanged;
            radio_cafe_milk.CheckedChanged += Drink_CheckedChanged;
            radio_cafe_milk_ice.CheckedChanged += Drink_CheckedChanged;
            radio_cafe_scream.CheckedChanged += Drink_CheckedChanged;

            // Đăng ký sự kiện cho các loại thức ăn (đảm bảo chỉ chọn 1 món thức ăn)
            checkbox_bread_egg.Click += Food_Click;
            checkbox_bread_fish.Click += Food_Click;
            checkbox_noodle_egg.Click += Food_Click;
            checkbox_noodle_beef.Click += Food_Click;
            checkbox_noodle_spicy.Click += Food_Click;
        }

        // Sự kiện Form_Load
        private void bai10_Load(object? sender, EventArgs e)
        {
            LamMoiForm();
            textbox_sumary_customer.Text = "0";
            textbox_sumary_cash.Text = "0 VNĐ";
        }

        // Sự kiện gõ phím cho ô số khách hàng: chỉ cho nhập số
        private void textbox_keyPress(object sender, KeyPressEventArgs e)
        {
            // Chặn dấu âm vì số lượng khách không thể là số âm
            if (e.KeyChar == '-')
            {
                e.Handled = true;
                return;
            }

            // Tái sử dụng hàm txt_KeyPress từ Bai1
            bai1Form.txt_KeyPress(sender, e, intnumber: true, lineofnum: false);
        }

        // Sự kiện TextChanged của ô tên khách hàng (đã gán trong Designer)
        private void textbox_name_textChanged(object sender, EventArgs e)
        {
            KiemTraThongTin();
        }

        // Sự kiện thay đổi lựa chọn nước uống
        private void Drink_CheckedChanged(object? sender, EventArgs e)
        {
            KiemTraThongTin();
        }

        // Sự kiện khi chọn thức ăn (cho phép chọn nhiều món cùng lúc)
        private void Food_Click(object? sender, EventArgs e)
        {
            KiemTraThongTin();
        }

        // Kiểm tra và cập nhật trạng thái các control
        private void KiemTraThongTin()
        {
            bool coTen = !string.IsNullOrWhiteSpace(textbox_name.Text);

            // Bật/tắt group nước và thức ăn theo tên khách hàng
            group_drinks.Enabled = coTen;
            group_foods.Enabled = coTen;

            // Kiểm tra số khách hàng hợp lệ (số nguyên > 0)
            bool coSoKhach = int.TryParse(textbox_guest_number.Text, out int soKhach) && soKhach > 0;

            // Kiểm tra đã chọn ít nhất 1 loại cafe
            bool coNuoc = LayGiaCafe() > 0;

            // Khi nhập đầy đủ thông tin thì btnTinhTien có tác dụng
            btn_cal.Enabled = coTen && coSoKhach && coNuoc;
        }

        // Lấy giá cafe đã chọn
        private double LayGiaCafe()
        {
            if (radio_cafe_black.Checked) return 20000;
            if (radio_cafe_ice.Checked) return 25000;
            if (radio_cafe_milk.Checked) return 25000;
            if (radio_cafe_milk_ice.Checked) return 30000;
            if (radio_cafe_scream.Checked) return 35000;
            return 0;
        }

        // Lấy giá thức ăn đã chọn
        private double LayGiaThucAn()
        {
            if (checkbox_bread_egg.Checked) return 15000;
            if (checkbox_bread_fish.Checked) return 15000;
            if (checkbox_noodle_egg.Checked) return 20000;
            if (checkbox_noodle_beef.Checked) return 30000;
            if (checkbox_noodle_spicy.Checked) return 50000;
            return 0;
        }

        // + btnTinhTien_Click: tính tiền, hiển thị MessageBox, bật NhapLai và ThanhToan
        private void btn_cal_Click(object? sender, EventArgs e)
        {
            if (!int.TryParse(textbox_guest_number.Text, out int soKhach) || soKhach <= 0)
            {
                MessageBox.Show("Số khách hàng phải là số nguyên lớn hơn 0!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textbox_guest_number.Focus();
                return;
            }

            double giaCafe = LayGiaCafe();
            double giaThucAn = LayGiaThucAn();

            // Tổng tiền cho nhóm = (tiền cafe + tiền thức ăn) * số khách
            double thanhTien = (giaCafe + giaThucAn) * soKhach;

            // Nếu là sinh viên thì giảm 20%
            if (checkbox_student.Checked)
            {
                thanhTien *= 0.8;
            }

            // Lưu lại thông tin thanh toán hiện tại
            tienKhachHienTai = thanhTien;
            soKhachHienTai = soKhach;

            // Hiển thị thông báo
            string thongBao = $"Khách hàng: {textbox_name.Text}\n"
                            + $"Số lượng khách: {soKhach}\n"
                            + $"Đối tượng: {(checkbox_student.Checked ? "Sinh viên (Giảm 20%)" : "Khách thường")}\n"
                            + $"Tổng tiền phải trả: {thanhTien:N0} VNĐ";

            MessageBox.Show(thongBao, "Tính tiền", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Cập nhật trạng thái các nút
            btn_reset.Enabled = true;
            btn_payout.Enabled = true;
            btn_cal.Enabled = false;
        }

        // + btnNhapLai_Click: quay về trạng thái ban đầu của Form, btnNhapLai mờ
        private void btn_reset_Click(object? sender, EventArgs e)
        {
            LamMoiForm();
        }

        // + btnThanhToan_Click: Ghi lại thông tin tổng số khách và tổng tiền, sẵn sàng cho nhóm mới, btnThanhToan mờ
        private void btn_payout_Click(object? sender, EventArgs e)
        {
            tongSoKhach += soKhachHienTai;
            tongTienThanhToan += tienKhachHienTai;

            // Ghi vào các ô tổng kết
            textbox_sumary_customer.Text = tongSoKhach.ToString();
            textbox_sumary_cash.Text = tongTienThanhToan.ToString("N0") + " VNĐ";

            // Sẵn sàng cho việc nhập nhóm khách hàng mới
            LamMoiForm();
        }

        // + btnThoat_Click: hỏi xác nhận trước khi thoát
        private void btn_exit_Click(object? sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn thoát khỏi chương trình?",
                "Xác nhận thoát",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        // Đưa các ô nhập liệu về trạng thái ban đầu
        private void LamMoiForm()
        {
            textbox_name.Clear();
            textbox_guest_number.Clear();
            checkbox_student.Checked = false;

            // Bỏ chọn radio cafe
            radio_cafe_black.Checked = false;
            radio_cafe_ice.Checked = false;
            radio_cafe_milk.Checked = false;
            radio_cafe_milk_ice.Checked = false;
            radio_cafe_scream.Checked = false;

            // Bỏ chọn checkbox thức ăn
            checkbox_bread_egg.Checked = false;
            checkbox_bread_fish.Checked = false;
            checkbox_noodle_egg.Checked = false;
            checkbox_noodle_beef.Checked = false;
            checkbox_noodle_spicy.Checked = false;

            group_drinks.Enabled = false;
            group_foods.Enabled = false;

            btn_cal.Enabled = false;
            btn_reset.Enabled = false;
            btn_payout.Enabled = false;

            tienKhachHienTai = 0;
            soKhachHienTai = 0;

            textbox_name.Focus();
        }
    }
}