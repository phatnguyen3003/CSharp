using Classlibrary_for_database;
using System.Data;
using System.Globalization;

namespace Bai2
{
    public partial class Bai2 : Form
    {
        // Khai bao thong so ket noi SQL Server trong Docker
        private static readonly string Server = "localhost,1433";
        private static readonly string Database = "QLSinhVien";
        private static readonly string User_ID = "sa";
        private static readonly string Password = "SqlServer@2026";
        private static readonly string TrustServer = "True";

        // Khoi tao bien DatabaseHelper dung chung va chuoi ket noi
        private readonly DatabaseHelper helper;
        string connectionString = $"Server={Server};Database={Database};User Id={User_ID};Password={Password};TrustServerCertificate={TrustServer};";

        // Phuong thuc khoi tao Form va dang ky su kien
        public Bai2()
        {
            helper = new DatabaseHelper(connectionString);
            InitializeComponent();

            Load += Form_Load;
            btn_delete.Click += btn_delete_Click;
            btn_edit.Click += btn_edit_Click;
        }

        // Su kien khi Form duoc tai: Kiem tra ket noi CSDL
        private async void Form_Load(object? sender, EventArgs e)
        {
            bool isConnected = await helper.TestConnectionAsync();

            if (!isConnected)
            {
                MessageBox.Show(
                    "Không thể kết nối đến cơ sở dữ liệu.",
                    "Lỗi kết nối",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                Close();
                return;
            }
        }

        // Su kien Them sinh vien vao CSDL
        private async void btn_add_Click(object sender, EventArgs e)
        {
            // Lay du lieu tu cac control tren giao dien
            string classID = textbox_classID.Text.Trim();
            string studentID = textbox_studentID.Text.Trim();
            string name = textbox_name.Text.Trim();
            string dateofbirthText = maskedtextbox_datetime.Text;

            // Kiem tra cac truong bat buoc khong duoc de trong
            if (string.IsNullOrWhiteSpace(classID) ||
                string.IsNullOrWhiteSpace(studentID) ||
                string.IsNullOrWhiteSpace(name) ||
                !maskedtextbox_datetime.MaskCompleted)
            {
                MessageBox.Show("Mã lớp, mã sinh viên, tên sinh viên và ngày sinh không được để trống.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiem tra va chuyen doi dinh dang ngay sinh (dd/MM/yyyy)
            if (!DateTime.TryParseExact(dateofbirthText, "dd/MM/yyyy",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dateOfBirth))
            {
                MessageBox.Show("Ngày sinh không hợp lệ. Hãy nhập theo định dạng dd/MM/yyyy.",
                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                maskedtextbox_datetime.Focus();
                return;
            }

            try
            {
                // Dong goi tham so truyen vao cau lenh SQL de chong SQL Injection
                var parameters = new Dictionary<string, object?>
                {
                    ["@MaLop"] = classID,
                    ["@MaSinhVien"] = studentID,
                    ["@HoTen"] = name,
                    ["@NgaySinh"] = dateOfBirth
                };

                // Thuc thi lenh INSERT va nhan ve so dong bi anh huong
                int affectedRows = await helper.ExecuteNonQueryAsync(
                    "INSERT INTO SinhVien (MaLop, MaSinhVien, HoTen, NgaySinh) " +
                    "VALUES (@MaLop, @MaSinhVien, @HoTen, @NgaySinh)",
                    parameters);

                // Thong bao ket qua them du lieu
                MessageBox.Show(
                    affectedRows > 0 ? "Thêm sinh viên thành công." : "Không thêm được sinh viên.",
                    "Thông báo", MessageBoxButtons.OK,
                    affectedRows > 0 ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Không thể thêm sinh viên: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Su kien Xoa sinh vien theo MaSinhVien va HoTen
        private async void btn_delete_Click(object? sender, EventArgs e)
        {
            string studentID = textbox_studentID.Text.Trim();
            string name = textbox_name.Text.Trim();

            // Kiem tra dieu kien bat buoc de xoa
            if (string.IsNullOrWhiteSpace(studentID) || string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Mã sinh viên và tên sinh viên không được để trống.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!string.IsNullOrWhiteSpace(textbox_classID.Text) ||
                maskedtextbox_datetime.Text.Any(char.IsDigit))
            {
                MessageBox.Show("Khi xóa, chỉ nhập mã sinh viên và tên sinh viên.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Thuc thi cau lenh DELETE voi tham so an toan
                int affectedRows = await helper.ExecuteNonQueryAsync(
                    "DELETE FROM SinhVien WHERE MaSinhVien = @MaSinhVien AND HoTen = @HoTen",
                    new Dictionary<string, object?>
                    {
                        ["@MaSinhVien"] = studentID,
                        ["@HoTen"] = name
                    });

                // Thong bao ket qua xoa
                MessageBox.Show(
                    affectedRows > 0 ? "Xóa sinh viên thành công." : "Không tìm thấy sinh viên khớp thông tin.",
                    "Thông báo", MessageBoxButtons.OK,
                    affectedRows > 0 ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Không thể xóa sinh viên: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Su kien Sua (Cap nhat) thong tin sinh vien linh hoat
        private async void btn_edit_Click(object? sender, EventArgs e)
        {
            string studentID = textbox_studentID.Text.Trim();
            string classID = textbox_classID.Text.Trim();
            string name = textbox_name.Text.Trim();
            bool hasDate = maskedtextbox_datetime.Text.Any(char.IsDigit);

            // Kiem tra xem da nhap ma sinh vien chua
            if (string.IsNullOrWhiteSpace(studentID))
            {
                MessageBox.Show("Mã sinh viên không được để trống.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiem tra xem co it nhat mot truong thong tin nao duoc thay doi khong
            if (string.IsNullOrWhiteSpace(classID) &&
                string.IsNullOrWhiteSpace(name) &&
                !hasDate)
            {
                MessageBox.Show("Nhập ít nhất một thông tin cần sửa.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime dateOfBirth = default;
            if (hasDate &&
                (!maskedtextbox_datetime.MaskCompleted ||
                 !DateTime.TryParseExact(maskedtextbox_datetime.Text, "dd/MM/yyyy",
                     CultureInfo.InvariantCulture, DateTimeStyles.None, out dateOfBirth)))
            {
                MessageBox.Show("Ngày sinh không hợp lệ. Hãy nhập theo định dạng dd/MM/yyyy.",
                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                maskedtextbox_datetime.Focus();
                return;
            }

            // Xây dung danh sach cac cot can cap nhat dong (dynamic update)
            var updates = new List<string>();
            var parameters = new Dictionary<string, object?>
            {
                ["@MaSinhVien"] = studentID
            };

            if (!string.IsNullOrWhiteSpace(classID))
            {
                updates.Add("MaLop = @MaLop");
                parameters["@MaLop"] = classID;
            }

            if (!string.IsNullOrWhiteSpace(name))
            {
                updates.Add("HoTen = @HoTen");
                parameters["@HoTen"] = name;
            }

            if (hasDate)
            {
                updates.Add("NgaySinh = @NgaySinh");
                parameters["@NgaySinh"] = dateOfBirth;
            }

            try
            {
                // Thuc thi cau lenh UPDATE dong du lieu
                int affectedRows = await helper.ExecuteNonQueryAsync(
                    $"UPDATE SinhVien SET {string.Join(", ", updates)} WHERE MaSinhVien = @MaSinhVien",
                    parameters);

                // Thong bao ket qua cap nhat
                MessageBox.Show(
                    affectedRows > 0 ? "Cập nhật sinh viên thành công." : "Không tìm thấy mã sinh viên.",
                    "Thông báo", MessageBoxButtons.OK,
                    affectedRows > 0 ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Không thể sửa thông tin sinh viên: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}