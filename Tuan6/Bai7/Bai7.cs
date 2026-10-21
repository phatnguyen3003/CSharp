using Classlibrary_for_database;
using System.Data;
using System.Globalization;

namespace Bai7
{
    public partial class Bai7 : Form
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

        // Phuong thuc khoi tao Form, thiet lap ket noi va dang ky cac su kien
        public Bai7()
        {
            helper = new DatabaseHelper(connectionString);
            InitializeComponent();

            Load += Form_Load;
            btn_hienthi.Click += btn_hienthi_Click;
            btn_thoat.Click += btn_thoat_Click;
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

        // Su kien Hien thi danh sách Lop tu CSDL len DataGridView khi nhan nut
        private async void btn_hienthi_Click(object? sender, EventArgs e)
        {
            try
            {
                // Truy van lay danh sach MaLop, TenLop, MaKhoa tu bang Lop sap xep theo MaLop
                var table = await helper.GetDataTableAsync(
                    "USE QLSinhVien; SELECT MaLop, TenLop, MaKhoa FROM Lop ORDER BY MaLop;");

                // Xoa cac dong cu hien tai trong DataGridView truoc khi do du lieu moi
                datagridview_Lop.Rows.Clear();

                // Duyet qua tung dong du lieu trong DataTable va them vao DataGridView
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    var row = table.Rows[i];
                    datagridview_Lop.Rows.Add(
                        i + 1,          // Cot STT tu tang
                        row["MaLop"],   // Ma lop
                        row["TenLop"],  // Ten lop
                        row["MaKhoa"]   // Ma khoa
                    );
                }
            }
            catch (Exception ex)
            {
                // Bat loi va thong bao neu qua trình truy van du lieu that bai
                MessageBox.Show($"Không thể tải dữ liệu lớp: {ex.Message}",
                    "Lỗi cơ sở dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Su kien Thoat form hien tai khi nhan nut Thoat
        private void btn_thoat_Click(object? sender, EventArgs e)
        {
            Close();
        }
    }
}