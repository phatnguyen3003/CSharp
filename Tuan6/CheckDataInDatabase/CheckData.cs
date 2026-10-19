using Classlibrary_for_database;

namespace CheckDataInDatabase
{
    public partial class Form1 : Form
    {

        // Khai bao cac thong so ket noi la static de co the su dung ben trong ham Main static
        private static readonly string Server = "localhost,1433";
        private static readonly string Database = "QLSinhVien";
        private static readonly string User_ID = "sa";
        private static readonly string Password = "SqlServer@2026";
        private static readonly string TrustServer = "True";


        // Ghep cac thong so thanh chuoi ket noi hoan chinh
        // Khai bao bien doi tuong DatabaseHelper dung chung cho toan bo form
        private readonly DatabaseHelper helper;
        private DataGridView khoaGrid = null!;
        private DataGridView lopGrid = null!;
        private DataGridView sinhVienGrid = null!;
        private DataGridView monHocGrid = null!;
        private DataGridView diemGrid = null!;

        string connectionString = $"Server={Server};Database={Database};User Id={User_ID};Password={Password};TrustServerCertificate={TrustServer};";

        public Form1()
        {
            helper = new DatabaseHelper(connectionString);
            InitializeComponent();

            var tabs = new TabControl { Dock = DockStyle.Fill };
            khoaGrid = AddTableGrid(tabs, "Khoa");
            lopGrid = AddTableGrid(tabs, "Lop");
            sinhVienGrid = AddTableGrid(tabs, "SinhVien");
            monHocGrid = AddTableGrid(tabs, "MonHoc");
            diemGrid = AddTableGrid(tabs, "Diem");
            Controls.Add(tabs);

            Load += Form_Load;
        }

        private static DataGridView AddTableGrid(TabControl tabs, string tableName)
        {
            var grid = new DataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };

            var page = new TabPage(tableName);
            page.Controls.Add(grid);
            tabs.TabPages.Add(page);
            return grid;
        }

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

            try
            {
                khoaGrid.DataSource = await helper.GetDataTableAsync("USE QLSinhVien; SELECT * FROM Khoa;");
                lopGrid.DataSource = await helper.GetDataTableAsync("USE QLSinhVien; SELECT * FROM Lop;");
                sinhVienGrid.DataSource = await helper.GetDataTableAsync("USE QLSinhVien; SELECT * FROM SinhVien;");
                monHocGrid.DataSource = await helper.GetDataTableAsync("USE QLSinhVien; SELECT * FROM MonHoc;");
                diemGrid.DataSource = await helper.GetDataTableAsync("USE QLSinhVien; SELECT * FROM Diem;");
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Không thể tạo bảng hoặc tải dữ liệu: {ex.Message}",
                    "Lỗi cơ sở dữ liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                Close();
            }
        }
    }
}
