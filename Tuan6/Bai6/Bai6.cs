using Classlibrary_for_database;
using Classlibrary_for_winform;
using System.Data;
using System.Globalization;

namespace Bai6
{
    public partial class Form1 : Form
    {
        Classlibrary_for_winform.winforms_helper win_helper = new Classlibrary_for_winform.winforms_helper();

        // Khai bao cac thong so ket noi SQL Server trong Docker
        private static readonly string Server = "localhost,1433";
        private static readonly string Database = "QLSinhVien";
        private static readonly string User_ID = "sa";
        private static readonly string Password = "SqlServer@2026";
        private static readonly string TrustServer = "True";

        // Khai bao bien DatabaseHelper dung chung va chuoi ket noi hoan chinh
        private readonly DatabaseHelper helper;
        string connectionString = $"Server={Server};Database={Database};User Id={User_ID};Password={Password};TrustServerCertificate={TrustServer};";

        public Form1()
        {
            InitializeComponent();
            helper = new DatabaseHelper(connectionString);

            Load += Form_Load;
            btn_them.Click += btn_them_Click;
            btn_xoa.Click += btn_xoa_Click;
            btn_sua.Click += btn_sua_Click;
        }

        // Su kien khi Form duoc tai: Kiem tra ket noi va nap ma sinh vien, ma mon hoc vao ComboBox
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
                    DataTable students = await helper.GetDataTableAsync(
                        "USE QLSinhVien; SELECT MaSinhVien FROM SinhVien ORDER BY MaSinhVien;");
                    DataTable subjects = await helper.GetDataTableAsync(
                        "USE QLSinhVien; SELECT MaMonHoc FROM MonHoc ORDER BY MaMonHoc;");

                    combobox_MaSV.Items.Clear();
                    foreach (DataRow row in students.Rows)
                    {
                        string? studentID = row["MaSinhVien"].ToString();
                        if (!string.IsNullOrEmpty(studentID))
                        {
                            combobox_MaSV.Items.Add(studentID);
                        }
                    }

                    combobox_MaMH.Items.Clear();
                    foreach (DataRow row in subjects.Rows)
                    {
                        string? subjectID = row["MaMonHoc"].ToString();
                        if (!string.IsNullOrEmpty(subjectID))
                        {
                            combobox_MaMH.Items.Add(subjectID);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Không thể tải mã sinh viên và mã môn học: {ex.Message}",
                        "Lỗi cơ sở dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void textbox_Diem_KeyPress(object sender, KeyPressEventArgs e)
        {
            win_helper.txt_KeyPress(sender, e, false, false);
        }

        private async void btn_them_Click(object? sender, EventArgs e)
        {
            string? studentID = combobox_MaSV.SelectedItem?.ToString();
            string? subjectID = combobox_MaMH.SelectedItem?.ToString();

            if (string.IsNullOrWhiteSpace(studentID) ||
                string.IsNullOrWhiteSpace(subjectID))
            {
                MessageBox.Show("Vui lòng chọn mã sinh viên và mã môn học.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!TryGetScore(out double score))
            {
                return;
            }

            try
            {
                if (!await ExistsAsync("SELECT COUNT(*) FROM SinhVien WHERE MaSinhVien = @MaSinhVien;",
                        new Dictionary<string, object?> { ["@MaSinhVien"] = studentID }))
                {
                    MessageBox.Show("Mã sinh viên không tồn tại.",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!await ExistsAsync("SELECT COUNT(*) FROM MonHoc WHERE MaMonHoc = @MaMonHoc;",
                        new Dictionary<string, object?> { ["@MaMonHoc"] = subjectID }))
                {
                    MessageBox.Show("Mã môn học không tồn tại.",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var parameters = new Dictionary<string, object?>
                {
                    ["@MaSinhVien"] = studentID,
                    ["@MaMonHoc"] = subjectID
                };

                if (await ExistsAsync(
                        "SELECT COUNT(*) FROM Diem WHERE MaSinhVien = @MaSinhVien AND MaMonHoc = @MaMonHoc;",
                        parameters))
                {
                    MessageBox.Show("Điểm của sinh viên ở môn học này đã tồn tại.",
                        "Trùng khóa chính", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                parameters["@Diem"] = score;
                int affectedRows = await helper.ExecuteNonQueryAsync(
                    "USE QLSinhVien; INSERT INTO Diem (MaSinhVien, MaMonHoc, Diem) " +
                    "VALUES (@MaSinhVien, @MaMonHoc, @Diem);",
                    parameters);

                ShowWriteResult(affectedRows, "Thêm điểm thành công.", "Không thêm được điểm.");
            }
            catch (Exception ex)
            {
                ShowDatabaseError("thêm điểm", ex);
            }
        }

        private async void btn_xoa_Click(object? sender, EventArgs e)
        {
            string? studentID = combobox_MaSV.SelectedItem?.ToString();
            string? subjectID = combobox_MaMH.SelectedItem?.ToString();

            if (string.IsNullOrWhiteSpace(studentID) || string.IsNullOrWhiteSpace(subjectID))
            {
                MessageBox.Show("Vui lòng chọn mã sinh viên và mã môn học.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (!await ForeignKeysExistAsync(studentID, subjectID))
                {
                    return;
                }

                var parameters = new Dictionary<string, object?>
                {
                    ["@MaSinhVien"] = studentID,
                    ["@MaMonHoc"] = subjectID
                };

                if (!await ExistsAsync(
                        "SELECT COUNT(*) FROM Diem WHERE MaSinhVien = @MaSinhVien AND MaMonHoc = @MaMonHoc;",
                        parameters))
                {
                    MessageBox.Show("Không tìm thấy điểm của sinh viên ở môn học này.",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int affectedRows = await helper.ExecuteNonQueryAsync(
                    "USE QLSinhVien; DELETE FROM Diem " +
                    "WHERE MaSinhVien = @MaSinhVien AND MaMonHoc = @MaMonHoc;",
                    parameters);

                ShowWriteResult(affectedRows, "Xóa điểm thành công.", "Không tìm thấy điểm cần xóa.");
            }
            catch (Exception ex)
            {
                ShowDatabaseError("xóa điểm", ex);
            }
        }

        private async void btn_sua_Click(object? sender, EventArgs e)
        {
            string? studentID = combobox_MaSV.SelectedItem?.ToString();
            string? subjectID = combobox_MaMH.SelectedItem?.ToString();

            if (string.IsNullOrWhiteSpace(studentID) ||
                string.IsNullOrWhiteSpace(subjectID))
            {
                MessageBox.Show("Vui lòng chọn mã sinh viên và mã môn học.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!TryGetScore(out double score))
            {
                return;
            }

            try
            {
                if (!await ForeignKeysExistAsync(studentID, subjectID))
                {
                    return;
                }

                var parameters = new Dictionary<string, object?>
                {
                    ["@MaSinhVien"] = studentID,
                    ["@MaMonHoc"] = subjectID
                };

                if (!await ExistsAsync(
                        "SELECT COUNT(*) FROM Diem WHERE MaSinhVien = @MaSinhVien AND MaMonHoc = @MaMonHoc;",
                        parameters))
                {
                    MessageBox.Show("Không tìm thấy điểm của sinh viên ở môn học này.",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                parameters["@Diem"] = score;
                int affectedRows = await helper.ExecuteNonQueryAsync(
                    "USE QLSinhVien; UPDATE Diem SET Diem = @Diem " +
                    "WHERE MaSinhVien = @MaSinhVien AND MaMonHoc = @MaMonHoc;",
                    parameters);

                ShowWriteResult(affectedRows, "Cập nhật điểm thành công.", "Không cập nhật được điểm.");
            }
            catch (Exception ex)
            {
                ShowDatabaseError("sửa điểm", ex);
            }
        }

        private bool TryGetScore(out double score)
        {
            string scoreText = textbox_Diem.Text.Trim();
            bool parsed = double.TryParse(
                scoreText,
                NumberStyles.Float,
                CultureInfo.CurrentCulture,
                out score);

            if (parsed && double.IsFinite(score) && score >= 0 && score <= 10)
            {
                return true;
            }

            MessageBox.Show("Điểm phải là số trong khoảng từ 0 đến 10.",
                "Điểm không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            textbox_Diem.Focus();
            return false;
        }

        private async Task<bool> ForeignKeysExistAsync(string studentID, string subjectID)
        {
            if (!await ExistsAsync("SELECT COUNT(*) FROM SinhVien WHERE MaSinhVien = @MaSinhVien;",
                    new Dictionary<string, object?> { ["@MaSinhVien"] = studentID }))
            {
                MessageBox.Show("Mã sinh viên không tồn tại.",
                    "Khóa ngoại không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!await ExistsAsync("SELECT COUNT(*) FROM MonHoc WHERE MaMonHoc = @MaMonHoc;",
                    new Dictionary<string, object?> { ["@MaMonHoc"] = subjectID }))
            {
                MessageBox.Show("Mã môn học không tồn tại.",
                    "Khóa ngoại không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private async Task<bool> ExistsAsync(string query, Dictionary<string, object?> parameters)
        {
            object? result = await helper.GetSingleValueAsync($"USE QLSinhVien; {query}", parameters);
            return Convert.ToInt32(result, CultureInfo.InvariantCulture) > 0;
        }

        private static void ShowWriteResult(int affectedRows, string successMessage, string noRowsMessage)
        {
            bool succeeded = affectedRows > 0;
            MessageBox.Show(
                succeeded ? successMessage : noRowsMessage,
                "Thông báo",
                MessageBoxButtons.OK,
                succeeded ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
        }

        private static void ShowDatabaseError(string operation, Exception exception)
        {
            MessageBox.Show($"Không thể {operation}: {exception.Message}",
                "Lỗi cơ sở dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
