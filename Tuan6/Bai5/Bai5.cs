using Classlibrary_for_database;
using System.Data;
using System.Globalization;

namespace Bai5
{
    public partial class Bai5 : Form
    {
        // Khai bao cac thong so ket noi SQL Server trong Docker
        private static readonly string Server = "localhost,1433";
        private static readonly string Database = "QLSinhVien";
        private static readonly string User_ID = "sa";
        private static readonly string Password = "SqlServer@2026";
        private static readonly string TrustServer = "True";

        // Khai bao bien DatabaseHelper dung chung va chuoi ket noi hoan chinh
        private readonly DatabaseHelper helper;
        string connectionString = $"Server={Server};Database={Database};User Id={User_ID};Password={Password};TrustServerCertificate={TrustServer};";

        // Phuong thuc khoi tao Form, thiet lap ket noi va dang ky cac su kien click cho button
        public Bai5()
        {
            helper = new DatabaseHelper(connectionString);
            InitializeComponent();

            Load += Form_Load;
            btn_them.Click += btn_them_Click;
            btn_xoa.Click += btn_xoa_Click;
            btn_sua.Click += btn_sua_Click;
        }

        // Su kien khi Form duoc tai: Kiem tra ket noi CSDL va nap danh sach MaLop vao ComboBox
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
            else
            {
                try
                {
                    // Truy van danh sach MaLop tu bang Lop de dua vao ComboBox
                    DataTable table = await helper.GetDataTableAsync(
                        "USE QLSinhVien; SELECT MaLop FROM Lop ORDER BY MaLop;");

                    combo_MaLop.Items.Clear();
                    foreach (DataRow row in table.Rows)
                    {
                        string? classID = row["MaLop"].ToString();
                        if (!string.IsNullOrEmpty(classID))
                        {
                            combo_MaLop.Items.Add(classID);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Không thể tải danh sách lớp: {ex.Message}",
                        "Lỗi cơ sở dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Su kien Them sinh vien moi vao bang SinhVien (co kiem tra tuoi >= 17 va ton tai MaLop)
        private async void btn_them_Click(object? sender, EventArgs e)
        {
            // Lay du lieu tu giao dien
            string studentID = textbox_MaSV.Text.Trim();
            string fullName = textbox_HoTen.Text.Trim();
            string classID = combo_MaLop.Text.Trim();
            string dateText = maskedtextbox_NgaySinh.Text;

            // Kiem tra cac truong thong tin bat buoc khong duoc de trong
            if (string.IsNullOrWhiteSpace(studentID) ||
                string.IsNullOrWhiteSpace(fullName) ||
                string.IsNullOrWhiteSpace(classID) ||
                !maskedtextbox_NgaySinh.MaskCompleted)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ mã lớp, mã sinh viên, họ tên và ngày sinh.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiem tra va phan tich dinh dang ngay sinh (dd/MM/yyyy)
            if (!DateTime.TryParseExact(dateText, "dd/MM/yyyy",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime birthDate))
            {
                MessageBox.Show("Ngày sinh không hợp lệ. Hãy nhập theo định dạng dd/MM/yyyy.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                maskedtextbox_NgaySinh.Focus();
                return;
            }

            // Kiem tra dieu kien tuoi: Sinh vien phai tu 17 tuoi tro len
            if (DateTime.Today.Year - birthDate.Year < 17)
            {
                MessageBox.Show("Sinh viên phải từ 17 tuổi trở lên (tính theo năm sinh).",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                maskedtextbox_NgaySinh.Focus();
                return;
            }

            try
            {
                // Kiem tra xem MaSinhVien da ton tai chua (tránh trung khoa chinh)
                if (await ExistsAsync("SELECT COUNT(*) FROM SinhVien WHERE MaSinhVien = @MaSinhVien;",
                        new Dictionary<string, object?> { ["@MaSinhVien"] = studentID }))
                {
                    MessageBox.Show("Mã sinh viên đã tồn tại.",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kiem tra xem MaLop co ton tai trong bang Lop hay khong (dam bao rang buoc khoa ngoai)
                if (!await ExistsAsync("SELECT COUNT(*) FROM Lop WHERE MaLop = @MaLop;",
                        new Dictionary<string, object?> { ["@MaLop"] = classID }))
                {
                    MessageBox.Show("Mã lớp không tồn tại. Hãy chọn một lớp hợp lệ.",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Thuc thi cau lenh INSERT them sinh vien moi
                int affectedRows = await helper.ExecuteNonQueryAsync(
                    "USE QLSinhVien; INSERT INTO SinhVien (MaSinhVien, HoTen, NgaySinh, MaLop) " +
                    "VALUES (@MaSinhVien, @HoTen, @NgaySinh, @MaLop);",
                    new Dictionary<string, object?>
                    {
                        ["@MaSinhVien"] = studentID,
                        ["@HoTen"] = fullName,
                        ["@NgaySinh"] = birthDate,
                        ["@MaLop"] = classID
                    });

                // Hien thi ket qua them du lieu
                ShowWriteResult(affectedRows, "Thêm sinh viên thành công.", "Không thêm được sinh viên.");
            }
            catch (Exception ex)
            {
                ShowDatabaseError("thêm sinh viên", ex);
            }
        }

        // Su kien Xoa sinh vien theo MaSinhVien (co kiem tra rang buoc khoa ngoai voi bang Diem)
        private async void btn_xoa_Click(object? sender, EventArgs e)
        {
            string studentID = textbox_MaSV.Text.Trim();

            // Kiem tra ma sinh vien khong duoc trong
            if (string.IsNullOrWhiteSpace(studentID))
            {
                MessageBox.Show("Mã sinh viên không được để trống.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Kiem tra xem ma sinh vien co ton tai trong CSDL hay khong
                if (!await ExistsAsync("SELECT COUNT(*) FROM SinhVien WHERE MaSinhVien = @MaSinhVien;",
                        new Dictionary<string, object?> { ["@MaSinhVien"] = studentID }))
                {
                    MessageBox.Show("Mã sinh viên không tồn tại.",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kiem tra xem sinh vien nay da co diem trong bang Diem hay chua (tránh loi rang buoc khoa ngoai)
                if (await ExistsAsync("SELECT COUNT(*) FROM Diem WHERE MaSinhVien = @MaSinhVien;",
                        new Dictionary<string, object?> { ["@MaSinhVien"] = studentID }))
                {
                    MessageBox.Show("Không thể xóa sinh viên vì đã có điểm liên kết với sinh viên này.",
                        "Không thể xóa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Thuc thi cau lenh DELETE xoa sinh vien
                int affectedRows = await helper.ExecuteNonQueryAsync(
                    "USE QLSinhVien; DELETE FROM SinhVien WHERE MaSinhVien = @MaSinhVien;",
                    new Dictionary<string, object?> { ["@MaSinhVien"] = studentID });

                // Hien thi ket qua xoa
                ShowWriteResult(affectedRows, "Xóa sinh viên thành công.", "Không tìm thấy sinh viên cần xóa.");
            }
            catch (Exception ex)
            {
                ShowDatabaseError("xóa sinh viên", ex);
            }
        }

        // Su kien Sua (Cap nhat) thong tin sinh vien theo MaSinhVien
        private async void btn_sua_Click(object? sender, EventArgs e)
        {
            string studentID = textbox_MaSV.Text.Trim();
            string fullName = textbox_HoTen.Text.Trim();
            string classID = combo_MaLop.Text.Trim();
            string dateText = maskedtextbox_NgaySinh.Text;

            // Kiem tra day du thong tin truoc khi sua
            if (string.IsNullOrWhiteSpace(studentID) ||
                string.IsNullOrWhiteSpace(fullName) ||
                string.IsNullOrWhiteSpace(classID) ||
                !maskedtextbox_NgaySinh.MaskCompleted)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ mã lớp, mã sinh viên, họ tên và ngày sinh để sửa.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiem tra va phan tich ngay sinh hop le
            if (!DateTime.TryParseExact(dateText, "dd/MM/yyyy",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime birthDate))
            {
                MessageBox.Show("Ngày sinh không hợp lệ. Hãy nhập theo định dạng dd/MM/yyyy.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                maskedtextbox_NgaySinh.Focus();
                return;
            }

            // Kiem tra dieu kien tuoi: Sinh vien phai tu 17 tuoi tro len
            if (DateTime.Today.Year - birthDate.Year < 17)
            {
                MessageBox.Show("Sinh viên phải từ 17 tuổi trở lên (tính theo năm sinh).",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                maskedtextbox_NgaySinh.Focus();
                return;
            }

            try
            {
                // Kiem tra xem ma sinh vien co ton tai khong de cap nhat
                if (!await ExistsAsync("SELECT COUNT(*) FROM SinhVien WHERE MaSinhVien = @MaSinhVien;",
                        new Dictionary<string, object?> { ["@MaSinhVien"] = studentID }))
                {
                    MessageBox.Show("Mã sinh viên không tồn tại.",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kiem tra ma lop moi co ton tai trong bang Lop hay khong
                if (!await ExistsAsync("SELECT COUNT(*) FROM Lop WHERE MaLop = @MaLop;",
                        new Dictionary<string, object?> { ["@MaLop"] = classID }))
                {
                    MessageBox.Show("Mã lớp không tồn tại. Hãy chọn một lớp hợp lệ.",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Thuc thi cau lenh UPDATE cap nhat thong tin sinh vien
                int affectedRows = await helper.ExecuteNonQueryAsync(
                    "USE QLSinhVien; UPDATE SinhVien " +
                    "SET HoTen = @HoTen, NgaySinh = @NgaySinh, MaLop = @MaLop " +
                    "WHERE MaSinhVien = @MaSinhVien;",
                    new Dictionary<string, object?>
                    {
                        ["@MaSinhVien"] = studentID,
                        ["@HoTen"] = fullName,
                        ["@NgaySinh"] = birthDate,
                        ["@MaLop"] = classID
                    });

                // Hien thi ket qua cap nhat
                ShowWriteResult(affectedRows, "Cập nhật sinh viên thành công.", "Không cập nhật được sinh viên.");
            }
            catch (Exception ex)
            {
                ShowDatabaseError("sửa sinh viên", ex);
            }
        }

        // Ham phu tro noi bo: Kiem tra su ton tai cua ban ghi qua cau truy van dem (COUNT)
        private async Task<bool> ExistsAsync(string query, Dictionary<string, object?> parameters)
        {
            object? result = await helper.GetSingleValueAsync($"USE QLSinhVien; {query}", parameters);
            return Convert.ToInt32(result, CultureInfo.InvariantCulture) > 0;
        }

        // Ham phu tro: Hien thi hop thoai thong bao ket qua thuc thi (Thanh cong hoac Canh bao)
        private static void ShowWriteResult(int affectedRows, string successMessage, string noRowsMessage)
        {
            bool succeeded = affectedRows > 0;
            MessageBox.Show(
                succeeded ? successMessage : noRowsMessage,
                "Thông báo",
                MessageBoxButtons.OK,
                succeeded ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
        }

        // Ham phu tro: Hien thi hop thoai bao loi khi thao tac voi co so du lieu that bai
        private static void ShowDatabaseError(string operation, Exception exception)
        {
            MessageBox.Show($"Không thể {operation}: {exception.Message}",
                "Lỗi cơ sở dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}