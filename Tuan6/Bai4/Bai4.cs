using Classlibrary_for_database;

namespace Bai4
{
    public partial class Bai4 : Form
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
        public Bai4()
        {
            helper = new DatabaseHelper(connectionString);
            InitializeComponent();

            Load += Form_Load;
            btn_them.Click += btn_them_Click;
            btn_xoa.Click += btn_xoa_Click;
            btn_sua.Click += btn_sua_Click;
        }

        // Su kien khi Form duoc tai: Kiem tra ket noi CSDL SQL Server
        private async void Form_Load(object sender, EventArgs e)
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

        // Su kien Them lop moi vao bang Lop
        private async void btn_them_Click(object? sender, EventArgs e)
        {
            // Lay du lieu MaKhoa, MaLop, TenLop tu cac textbox tren giao dien
            string departmentID = textbox_MaKhoa.Text.Trim();
            string classID = textbox_MaLop.Text.Trim();
            string className = textbox_TenLop.Text.Trim();

            // Kiem tra cac truong thong tin bat buoc khong duoc de trong
            if (string.IsNullOrWhiteSpace(departmentID) ||
                string.IsNullOrWhiteSpace(classID) ||
                string.IsNullOrWhiteSpace(className))
            {
                MessageBox.Show("Mã khoa, mã lớp và tên lớp không được để trống.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Thuc thi cau lenh INSERT voi tham so an toan, co lenh USE chi dinh database QLSinhVien
                int affectedRows = await helper.ExecuteNonQueryAsync(
                    "USE QLSinhVien; INSERT INTO Lop (MaKhoa, MaLop, TenLop) " +
                    "VALUES (@MaKhoa, @MaLop, @TenLop)",
                    new Dictionary<string, object?>
                    {
                        ["@MaKhoa"] = departmentID,
                        ["@MaLop"] = classID,
                        ["@TenLop"] = className
                    });

                // Hien thi ket qua them du lieu
                ShowWriteResult(affectedRows, "Thêm lớp thành công.", "Không thêm được lớp.");
            }
            catch (Exception ex)
            {
                ShowDatabaseError("thêm lớp", ex);
            }
        }

        // Su kien Xoa lop theo MaLop
        private async void btn_xoa_Click(object? sender, EventArgs e)
        {
            // Lay ma lop can xoa tu textbox
            string classID = textbox_MaLop.Text.Trim();

            // Kiem tra ma lop khong duoc de trong
            if (string.IsNullOrWhiteSpace(classID))
            {
                MessageBox.Show("Mã lớp không được để trống.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiem tra cac o khac phai de trong khi thuc hien thao tac xoa
            if (!string.IsNullOrWhiteSpace(textbox_MaKhoa.Text) ||
                !string.IsNullOrWhiteSpace(textbox_TenLop.Text))
            {
                MessageBox.Show("Khi xóa, chỉ nhập mã lớp.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Thuc thi cau lenh DELETE voi tham so an toan
                int affectedRows = await helper.ExecuteNonQueryAsync(
                    "USE QLSinhVien; DELETE FROM Lop WHERE MaLop = @MaLop",
                    new Dictionary<string, object?> { ["@MaLop"] = classID });

                // Hien thi ket qua xoa
                ShowWriteResult(affectedRows, "Xóa lớp thành công.", "Không tìm thấy lớp cần xóa.");
            }
            catch (Exception ex)
            {
                ShowDatabaseError("xóa lớp", ex);
            }
        }

        // Su kien Sua (Cap nhat) thong tin lop hoc linh hoat theo MaLop
        private async void btn_sua_Click(object? sender, EventArgs e)
        {
            string classID = textbox_MaLop.Text.Trim();
            string departmentID = textbox_MaKhoa.Text.Trim();
            string className = textbox_TenLop.Text.Trim();

            // Kiem tra ma lop khong duoc de trong vi la dieu kien WHERE
            if (string.IsNullOrWhiteSpace(classID))
            {
                MessageBox.Show("Mã lớp không được để trống.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiem tra xem co it nhat mot trong hai thong tin can sua duoc nhap hay khong
            if (string.IsNullOrWhiteSpace(departmentID) &&
                string.IsNullOrWhiteSpace(className))
            {
                MessageBox.Show("Nhập ít nhất mã khoa hoặc tên lớp cần sửa.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Xay dung danh sach cac cot can cap nhat dong (dynamic update)
            var updates = new List<string>();
            var parameters = new Dictionary<string, object?>
            {
                ["@MaLop"] = classID
            };

            if (!string.IsNullOrWhiteSpace(departmentID))
            {
                updates.Add("MaKhoa = @MaKhoa");
                parameters["@MaKhoa"] = departmentID;
            }

            if (!string.IsNullOrWhiteSpace(className))
            {
                updates.Add("TenLop = @TenLop");
                parameters["@TenLop"] = className;
            }

            try
            {
                // Thuc thi cau lenh UPDATE dong du lieu
                int affectedRows = await helper.ExecuteNonQueryAsync(
                    $"USE QLSinhVien; UPDATE Lop SET {string.Join(", ", updates)} WHERE MaLop = @MaLop",
                    parameters);

                // Hien thi ket qua cap nhat
                ShowWriteResult(affectedRows, "Sửa thông tin lớp thành công.", "Không tìm thấy lớp cần sửa.");
            }
            catch (Exception ex)
            {
                ShowDatabaseError("sửa lớp", ex);
            }
        }

        // Ham phu tro: Hien thi hop thoai thong bao ket quả thuc thi (Thanh cong hoac Canh bao)
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