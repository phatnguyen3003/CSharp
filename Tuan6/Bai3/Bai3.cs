using Classlibrary_for_database;
using Classlibrary_for_winform;
using System.Globalization;

namespace Bai3
{
    public partial class Form1 : Form
    {
        // Khai bao doi tuong ho tro xu ly rang buoc nhap lieu tren cac textbox (winforms_helper)
        Classlibrary_for_winform.winforms_helper winform_helper = new Classlibrary_for_winform.winforms_helper();

        // Khai bao cac thong so ket noi SQL Server trong Docker
        private static readonly string Server = "localhost,1433";
        private static readonly string Database = "QLSinhVien";
        private static readonly string User_ID = "sa";
        private static readonly string Password = "SqlServer@2026";
        private static readonly string TrustServer = "True";

        // Khai bao bien DatabaseHelper dung chung va chuoi ket noi hoan chinh
        private readonly DatabaseHelper helper;
        string connectionString = $"Server={Server};Database={Database};User Id={User_ID};Password={Password};TrustServerCertificate={TrustServer};";

        // Phuong thuc khoi tao Form, thiet lap ket noi va dang ky cac su kien
        public Form1()
        {
            helper = new DatabaseHelper(connectionString);
            InitializeComponent();

            Load += Form_Load;
            btn_them.Click += btn_them_Click;
            btn_xoa.Click += btn_xoa_Click;
            btn_sua.Click += btn_sua_Click;
        }

        // Su kien khi Form duoc tai: Kiem tra ket noi CSDL SQL Server
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

        // Su kien rang buoc ban phim khi nhap vao textbox Diem (chi cho phep nhap so va dau hop le)
        private void textbox_Diem_KeyPress(object sender, KeyPressEventArgs e)
        {
            winform_helper.txt_KeyPress(sender, e, false, false);
        }

        // Su kien Them diem moi vao bang Diem
        private async void btn_them_Click(object? sender, EventArgs e)
        {
            // Lay du lieu tu cac textbox tren giao dien
            string studentID = textbox_MaSV.Text.Trim();
            string subjectID = textbox_MaMH.Text.Trim();
            string scoreText = textbox_Diem.Text.Trim();

            // Kiem tra cac truong thong tin khong duoc de trong
            if (string.IsNullOrWhiteSpace(studentID) ||
                string.IsNullOrWhiteSpace(subjectID) ||
                string.IsNullOrWhiteSpace(scoreText))
            {
                MessageBox.Show("Mã sinh viên, mã môn học và điểm không được để trống.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiem tra va phan tich gia tri Diem co hop le (tu 0 den 10) hay khong
            if (!TryParseScore(scoreText, out double score))
            {
                MessageBox.Show("Điểm phải là số trong khoảng từ 0 đến 10.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textbox_Diem.Focus();
                return;
            }

            try
            {
                // Thuc thi cau lenh INSERT voi tham so an toan, co lenh USE chi dinh database
                int affectedRows = await helper.ExecuteNonQueryAsync(
                    "USE QLSinhVien; INSERT INTO Diem (MaSinhVien, MaMonHoc, Diem) " +
                    "VALUES (@MaSinhVien, @MaMonHoc, @Diem)",
                    new Dictionary<string, object?>
                    {
                        ["@MaSinhVien"] = studentID,
                        ["@MaMonHoc"] = subjectID,
                        ["@Diem"] = score
                    });

                // Hien thi ket qua them du lieu
                ShowWriteResult(affectedRows, "Thêm điểm thành công.", "Không thêm được điểm.");
            }
            catch (Exception ex)
            {
                ShowDatabaseError("thêm điểm", ex);
            }
        }

        // Su kien Xoa diem theo MaSinhVien va MaMonHoc
        private async void btn_xoa_Click(object? sender, EventArgs e)
        {
            string studentID = textbox_MaSV.Text.Trim();
            string subjectID = textbox_MaMH.Text.Trim();

            // Kiem tra ma sinh vien va ma mon hoc khong duoc trong
            if (string.IsNullOrWhiteSpace(studentID) ||
                string.IsNullOrWhiteSpace(subjectID))
            {
                MessageBox.Show("Mã sinh viên và mã môn học không được để trống.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiem tra o Diem phai de trong khi thuc hiện thao tac xoa
            if (!string.IsNullOrWhiteSpace(textbox_Diem.Text))
            {
                MessageBox.Show("Để trống ô Điểm khi xóa.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textbox_Diem.Focus();
                return;
            }

            try
            {
                // Thuc thi cau lenh DELETE voi tham so truyen vao an toan
                int affectedRows = await helper.ExecuteNonQueryAsync(
                    "USE QLSinhVien; DELETE FROM Diem " +
                    "WHERE MaSinhVien = @MaSinhVien AND MaMonHoc = @MaMonHoc",
                    new Dictionary<string, object?>
                    {
                        ["@MaSinhVien"] = studentID,
                        ["@MaMonHoc"] = subjectID
                    });

                // Hien thi ket qua xoa
                ShowWriteResult(affectedRows, "Xóa điểm thành công.", "Không tìm thấy dòng điểm cần xóa.");
            }
            catch (Exception ex)
            {
                ShowDatabaseError("xóa điểm", ex);
            }
        }

        // Su kien Sua (Cap nhat) diem cua sinh viên theo mon hoc
        private async void btn_sua_Click(object? sender, EventArgs e)
        {
            string studentID = textbox_MaSV.Text.Trim();
            string subjectID = textbox_MaMH.Text.Trim();
            string scoreText = textbox_Diem.Text.Trim();

            // Kiem tra khong duoc de trong bat ky truong nao khi sua
            if (string.IsNullOrWhiteSpace(studentID) ||
                string.IsNullOrWhiteSpace(subjectID) ||
                string.IsNullOrWhiteSpace(scoreText))
            {
                MessageBox.Show("Mã sinh viên, mã môn học và điểm không được để trống khi sửa.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiem tra tinh hop le cua gia tri diem moi
            if (!TryParseScore(scoreText, out double score))
            {
                MessageBox.Show("Điểm phải là số trong khoảng từ 0 đến 10.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textbox_Diem.Focus();
                return;
            }

            try
            {
                // Thuc thi cau lenh UPDATE cap nhat diem
                int affectedRows = await helper.ExecuteNonQueryAsync(
                    "USE QLSinhVien; UPDATE Diem SET Diem = @Diem " +
                    "WHERE MaSinhVien = @MaSinhVien AND MaMonHoc = @MaMonHoc",
                    new Dictionary<string, object?>
                    {
                        ["@Diem"] = score,
                        ["@MaSinhVien"] = studentID,
                        ["@MaMonHoc"] = subjectID
                    });

                // Hien thi ket qua sua du lieu
                ShowWriteResult(affectedRows, "Sửa điểm thành công.", "Không tìm thấy dòng điểm cần sửa.");
            }
            catch (Exception ex)
            {
                ShowDatabaseError("sửa điểm", ex);
            }
        }

        // Ham phu tro: Kiem tra va chuyen doi chuoi sang so thuc, gioi han trong khoang tu 0 den 10
        private static bool TryParseScore(string scoreText, out double score)
        {
            return double.TryParse(
                       scoreText,
                       NumberStyles.Float,
                       CultureInfo.CurrentCulture,
                       out score) &&
                   double.IsFinite(score) &&
                   score >= 0 &&
                   score <= 10;
        }

        // Ham phu tro: Hien thi hop thoai thong bao ket qua thuc thi (Thanh cong hoac Canh bao)
        private void ShowWriteResult(int affectedRows, string successMessage, string noRowsMessage)
        {
            bool succeeded = affectedRows > 0;
            MessageBox.Show(
                succeeded ? successMessage : noRowsMessage,
                "Thông báo",
                MessageBoxButtons.OK,
                succeeded ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
        }

        // Ham phu tro: Hien thi hop thoai bao loi khi thao tac voi co sở dữ liệu that bai
        private void ShowDatabaseError(string operation, Exception exception)
        {
            MessageBox.Show($"Không thể {operation}: {exception.Message}",
                "Lỗi cơ sở dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}