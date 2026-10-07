using System.Globalization;
using Bai1;

namespace Bai9
{
    public partial class bai9 : Form
    {
        Bai1.bai1 bai1Form = new Bai1.bai1();
        private MangSoNguyen? mang;

        public bai9()
        {
            InitializeComponent();

            // dang ky su kien khi chuoi nhap thay doi
            textbox_input.TextChanged += textbox_MangTextChanged;

            // danh sach cac o chi cho nhap so
            TextBox[] cacONhapSo =
            {
                textbox_value_find, textbox_index_find,
                textbox_value_delete, textbox_index_delete,
                textbox_value_add, textbox_index_add,
                textbox_index_replace, textbox_value_replace, textbox_valueto_replace
            };

            // gán kiem tra phim cho tung o nhap
            foreach (TextBox textbox in cacONhapSo)
                textbox.KeyPress += textbox_KeyPress;

            // dang ky su kien nut va radio button
            btn_start.Click += btn_start_Click;
            btn_reset.Click += btn_reset_Click;
            btn_exit.Click += (sender, e) => Close();
            btn_sum_cal.Click += btn_sum_cal_Click;
            btn_find_minmax.Click += btn_find_minmax_Click;
            radio_up_sort.CheckedChanged += radio_sort_CheckedChanged;
            radio_down_sort.CheckedChanged += radio_sort_CheckedChanged;
            radio_value_find.CheckedChanged += radio_find_CheckedChanged;
            radio_index_find.CheckedChanged += radio_find_CheckedChanged;

            // xac nhan khi dong form
            FormClosing += form_FormClosing;

            // thiet lap trang thai ban dau
            CapNhatNhomThemXoa();
            CapNhatNhanTimKiem();
        }

        private void textbox_input_KeyPress(object sender, KeyPressEventArgs e)
        {
            // kiem tra phim bam bang ham cua bai1
            bai1Form.txt_KeyPress(sender, e, intnumber: true, lineofnum: true);
        }

        private void textbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // kiem tra phim bam bang ham cua bai1
            bai1Form.txt_KeyPress(sender, e, intnumber: true, lineofnum: false);
        }

        private void textbox_MangTextChanged(object? sender, EventArgs e)
        {
            // lam moi du lieu khi chuoi nhap thay doi
            mang = null;
            textbox_output.Clear();
            XoaKetQua();
        }

        private void btn_start_Click(object? sender, EventArgs e)
        {
            // tach chuoi thanh mang cac so
            string[] cacSo = textbox_input.Text.Split((char[]?)null, StringSplitOptions.RemoveEmptyEntries);
            if (cacSo.Length == 0)
            {
                MessageBox.Show("Vui lòng nhập các số nguyên của mảng!", "Lỗi nhập liệu",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textbox_input.Focus();
                return;
            }

            // chuyen chuoi thanh danh sach so nguyen
            List<int> danhSach = new List<int>();
            foreach (string chuoiSo in cacSo)
            {
                if (!int.TryParse(chuoiSo, NumberStyles.Integer, CultureInfo.CurrentCulture, out int giaTri))
                {
                    MessageBox.Show("Mảng chỉ được chứa các số nguyên hợp lệ, cách nhau bằng dấu cách!",
                        "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textbox_input.Focus();
                    textbox_input.SelectAll();
                    return;
                }

                danhSach.Add(giaTri);
            }

            // tao doi tuong mang va hien thi
            mang = new MangSoNguyen(danhSach);
            SapXepTheoLuaChon();
            HienThiMang();
            XoaKetQua();

            if(textbox_value_find.Text != "" || textbox_index_find.Text != "")
                find_Function(null, null); // cap nhat giao dien nhom tim kiem

            if(textbox_value_add.Text != "" || textbox_index_add.Text != "")
                add_Function(null, null); // cap nhat giao dien nhom them xoa


            if(textbox_value_delete.Text != "" || textbox_index_delete.Text != "")
                delete_Function(null, null); // cap nhat giao dien nhom them xoa
            
            if(textbox_valueto_replace.Text != "" || textbox_value_replace.Text != "" || textbox_index_replace.Text != "")
                replace_Function(null, null); // cap nhat giao dien nhom thay the
        }

        private void SapXepTheoLuaChon()
        {
            // sap xep mang tang hoac giam
            if (mang == null)
                return;

            if (radio_up_sort.Checked)
                mang.SapXepTang();
            else
                mang.SapXepGiam();
        }

        private void radio_sort_CheckedChanged(object? sender, EventArgs e)
        {
            // cap nhat giao dien va sap xep lai mang khi doi kieu
            CapNhatNhomThemXoa();
            SapXepTheoLuaChon();
            HienThiMang();
            XoaKetQua();
        }

        private void CapNhatNhomThemXoa()
        {
            // an hoac hien nhom chuc năng khi dang sap xep
            bool dangSapXepTang = radio_up_sort.Checked;
            group_add.Enabled = dangSapXepTang;
            group_delete.Enabled = dangSapXepTang;
            //label5.Visible = !dangSapXepTang;
            //label6.Visible = !dangSapXepTang;
        }

        private void btn_reset_Click(object? sender, EventArgs e)
        {
            // xoa sach du lieu va dua ve trang thai dau
            mang = null;
            textbox_input.Clear();
            textbox_output.Clear();
            textbox_value_find.Clear();
            textbox_index_find.Clear();
            textbox_value_delete.Clear();
            textbox_index_delete.Clear();
            textbox_value_add.Clear();
            textbox_index_add.Clear();
            textbox_index_replace.Clear();
            textbox_value_replace.Clear();
            textbox_valueto_replace.Clear();
            radio_up_sort.Checked = true;
            radio_value_find.Checked = true;
            radio_value_delete.Checked = true;
            radio_value_replace.Checked = true;
            XoaKetQua();
            CapNhatNhomThemXoa();
        }

        private void radio_find_CheckedChanged(object? sender, EventArgs e)
        {
            // doi nhan tim kiem va xoa ket qua cu
            CapNhatNhanTimKiem();
            textbox_result_find.Clear();
        }

        private void CapNhatNhanTimKiem()
        {
            // doi noi dung label theo che do tim kiem
            label4.Text = radio_value_find.Checked ? "Vị trí tìm được:" : "Giá trị tại vị trí:";
        }

        private void find_Function(object? sender, EventArgs e)
        {
            // tim kiem gia tri hoac vi tri
            if (!KiemTraMang())
                return;

            if (radio_value_find.Checked)
            {
                if (!TryDocSoNguyen(textbox_value_find, "giá trị cần tìm", out int giaTri))
                    return;

                List<int> viTri = mang!.TimKiem(giaTri);
                textbox_result_find.Text = viTri.Count == 0
                    ? "Không tìm thấy"
                    : string.Join(", ", viTri);
            }
            else
            {
                if (!TryDocViTri(textbox_index_find, mang!.DanhSach.Count - 1, out int viTri))
                    return;

                textbox_result_find.Text = mang.DanhSach[viTri].ToString();
            }
        }

        private void delete_Function(object? sender, EventArgs e)
        {
            // xoa phan tu theo gia tri hoac vi tri
            if (!KiemTraMang())
                return;

            if (radio_index_delete.Checked)
            {
                if (!TryDocViTri(textbox_index_delete, mang!.DanhSach.Count - 1, out int viTri))
                    return;

                mang.XoaTaiViTri(viTri);
            }
            else
            {
                if (!TryDocSoNguyen(textbox_value_delete, "giá trị cần xóa", out int giaTri))
                    return;

                int soLuongXoa = mang!.XoaGiaTri(giaTri);
                if (soLuongXoa == 0)
                {
                    MessageBox.Show("Không tìm thấy giá trị cần xóa trong mảng!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            CapNhatSauKhiThayDoiMang();
        }

        private void add_Function(object? sender, EventArgs e)
        {
            // them phan tu vao mang
            if (!KiemTraMang())
                return;

            if (!TryDocSoNguyen(textbox_value_add, "giá trị cần thêm", out int giaTri) ||
                !TryDocViTri(textbox_index_add, mang!.DanhSach.Count, out int viTri))
                return;

            List<int> danhSach = mang!.DanhSach;
            if ((viTri > 0 && danhSach[viTri - 1] > giaTri) ||
                (viTri < danhSach.Count && danhSach[viTri] < giaTri))
            {
                MessageBox.Show("Giá trị và vị trí thêm phải giữ cho mảng được sắp xếp tăng dần!",
                    "Không thể thêm", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            mang.ThemPhanTu(giaTri, viTri);
            CapNhatSauKhiThayDoiMang();
        }

        private void btn_sum_cal_Click(object? sender, EventArgs e)
        {
            // tinh tong mang, tong chan, tong le
            if (!KiemTraMang())
                return;

            try
            {
                textbox_sum.Text = mang!.TinhTong().ToString();
                textbox_sum_even.Text = mang.TinhTongChan().ToString();
                textbox_sum_odd.Text = mang.TinhTongLe().ToString();
            }
            catch (OverflowException)
            {
                MessageBox.Show("Tổng vượt quá giới hạn số nguyên 32-bit!", "Lỗi tính toán",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                textbox_sum.Clear();
                textbox_sum_even.Clear();
                textbox_sum_odd.Clear();
            }
        }

        private void btn_find_minmax_Click(object? sender, EventArgs e)
        {
            // tim gia tri lon nhat va nho nhat
            if (!KiemTraMang())
                return;

            textbox_max.Text = mang!.TimMax()?.ToString() ?? "";
            textbox_min.Text = mang.TimMin()?.ToString() ?? "";
        }

        private void replace_Function(object? sender, EventArgs e)
        {
            // thay the gia tri trong mang
            if (!KiemTraMang())
                return;

            if (!TryDocSoNguyen(textbox_valueto_replace, "giá trị thay thế", out int giaTriMoi))
                return;

            if (radio_index_replace.Checked)
            {
                if (!TryDocViTri(textbox_index_replace, mang!.DanhSach.Count - 1, out int viTri))
                    return;

                mang.ThayTheTaiViTri(viTri, giaTriMoi);
            }
            else
            {
                if (!TryDocSoNguyen(textbox_value_replace, "giá trị cần thay thế", out int giaTriCu))
                    return;

                int soLuongThay = mang!.ThayTheGiaTri(giaTriCu, giaTriMoi);
                if (soLuongThay == 0)
                {
                    MessageBox.Show("Không tìm thấy giá trị cần thay thế trong mảng!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            CapNhatSauKhiThayDoiMang();
        }

        private bool TryDocSoNguyen(TextBox textbox, string tenGiaTri, out int giaTri)
        {
            // doc va kiem tra so nguyen tu o nhap
            if (!int.TryParse(textbox.Text.Trim(), NumberStyles.Integer, CultureInfo.CurrentCulture, out giaTri))
            {
                MessageBox.Show($"Vui lòng nhập {tenGiaTri} là một số nguyên hợp lệ!", "Lỗi nhập liệu",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                textbox.Focus();
                textbox.SelectAll();
                return false;
            }

            return true;
        }

        private bool TryDocViTri(TextBox textbox, int viTriToiDa, out int viTri)
        {
            // doc va kiem tra chi so vi tri hop le trong mang
            if (!TryDocSoNguyen(textbox, "vị trí", out viTri))
                return false;

            if (viTri < 0 || viTri > viTriToiDa)
            {
                MessageBox.Show($"Vị trí phải nằm trong khoảng từ 0 đến {viTriToiDa}!", "Lỗi vị trí",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textbox.Focus();
                textbox.SelectAll();
                return false;
            }

            return true;
        }

        private bool KiemTraMang()
        {
            // kiem tra mang da khoi tao va co phan tu hay chua
            if (mang != null && mang.DanhSach.Count > 0)
                return true;

            MessageBox.Show("Vui lòng nhập mảng và nhấn Thực hiện trước!", "Chưa có dữ liệu",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            textbox_input.Focus();
            return false;
        }

        private void HienThiMang()
        {
            // xuat chuoi mang len o output
            textbox_output.Text = mang?.XuatMang() ?? "";
        }

        private void CapNhatSauKhiThayDoiMang()
        {
            // sap xep lai, hien thi mang va xoa ket qua cu
            SapXepTheoLuaChon();
            HienThiMang();
            XoaKetQua();
        }

        private void XoaKetQua()
        {
            // xoa toan bo ket qua hien thi tinh toan
            textbox_result_find.Clear();
            textbox_sum.Clear();
            textbox_sum_even.Clear();
            textbox_sum_odd.Clear();
            textbox_max.Clear();
            textbox_min.Clear();
        }

        public void form_FormClosing(object? sender, FormClosingEventArgs e)
        {
            // hoi xac nhan khi nguoi dung tat form
            DialogResult r = MessageBox.Show("Bạn có muốn thoát?", "Thoát",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (r == DialogResult.No)
                e.Cancel = true;
        }
    }
}