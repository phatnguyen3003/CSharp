namespace Bai1;
using Classlibrary_for_database;

// Khai bao lop Form1 quan ly giao dien va thao tac du lieu bang MonHoc
public partial class Form1 : Form
{
    // Khai bao cac thong so ket noi la static de cau hinh ket noi SQL Server trong Docker
    private static readonly string Server = "localhost,1433";
    private static readonly string Database = "QLSinhVien";
    private static readonly string User_ID = "sa";
    private static readonly string Password = "SqlServer@2026";
    private static readonly string TrustServer = "True";

    // Ghep cac thong so thanh chuoi ket noi hoan chinh
    string connectionString = $"Server={Server};Database={Database};User Id={User_ID};Password={Password};TrustServerCertificate={TrustServer};";

    // Khai bao bien doi tuong DatabaseHelper dung chung cho toan bo form
    private DatabaseHelper helper = null!;

    // Phuong thuc khoi tao Form, thiet lap giao dien va dang ky su kien cho cac nut bam
    public Form1()
    {
        InitializeComponent();

        // Khoi tao doi tuong DatabaseHelper tu Class Library voi chuoi ket noi da tao
        helper = new DatabaseHelper(connectionString);

        // Dang ky su kien Click cho cac nut Them, Xoa, Sua
        btn_them.Click += btnThem_Click;
        btn_xoa.Click += btnXoa_Click;
        btn_sua.Click += btnSua_Click;
    }

    // Xu ly su kien khi nhan nut Them mon hoc moi vao co so du lieu
    private async void btnThem_Click(object? sender, EventArgs e)
    {
        // Lay gia tri MaMH va TenMH tu textbox tren giao dien va cat bo khoang trang thua
        string maMonHoc = textbox_MaMH.Text.Trim();
        string tenMonHoc = textbox_TenMH.Text.Trim();

        // Goi ham kiem tra tinh hop le cua du lieu dau vao, neu khong hop le thi dung lai
        if (!KiemTraThongTin(maMonHoc, tenMonHoc))
        {
            return;
        }

        try
        {
            // Thuc thi cau lenh INSERT bat dong bo thong qua DatabaseHelper kem danh sach tham so an toan chong SQL Injection
            await helper.ExecuteNonQueryAsync(
                "INSERT INTO MonHoc (MaMonHoc, TenMonHoc) VALUES (@MaMonHoc, @TenMonHoc)",
                new Dictionary<string, object?>
                {
                    ["@MaMonHoc"] = maMonHoc,
                    ["@TenMonHoc"] = tenMonHoc
                });

            // Hien thi hop thoai thong bao them thanh cong
            MessageBox.Show("Them mon hoc thanh cong.", "Thong bao",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            // Bat va hien thi loi chi tiet neu thao tac them vao database that bai
            MessageBox.Show($"Khong the them mon hoc: {ex.Message}", "Loi",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    // Xu ly su kien khi nhan nut Xoa mon hoc theo ma
    private async void btnXoa_Click(object? sender, EventArgs e)
    {
        // Lay ma mon hoc can xoa tu textbox
        string maMonHoc = textbox_MaMH.Text.Trim();

        // Kiem tra xem nguoi dung da nhap ma mon hoc hay chua
        if (string.IsNullOrWhiteSpace(maMonHoc))
        {
            MessageBox.Show("Vui long nhap ma mon hoc.", "Thong bao",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            textbox_MaMH.Focus();
            return;
        }

        try
        {
            // Thuc thi cau lenh DELETE bat dong bo, nhan ve so luong dong du lieu bi anh huong (soDong)
            int soDong = await helper.ExecuteNonQueryAsync(
                "DELETE FROM MonHoc WHERE MaMonHoc = @MaMonHoc",
                new Dictionary<string, object?> { ["@MaMonHoc"] = maMonHoc });

            // Thong bao ket qua: neu soDong > 0 la xoa thanh cong, nguoc lai la khong tim thay ma mon hoc trong database
            MessageBox.Show(
                soDong > 0 ? "Xoa mon hoc thanh cong." : "Khong tim thay ma mon hoc.",
                "Thong bao", MessageBoxButtons.OK,
                soDong > 0 ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
        }
        catch (Exception ex)
        {
            // Bat loi va hien thi khi thao tac xoa gap su co ket noi hoac rang buoc khoa ngoai
            MessageBox.Show($"Khong the xoa mon hoc: {ex.Message}", "Loi",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    // Xu ly su kien khi nhan nut Sua (Cap nhat) ten mon hoc
    private async void btnSua_Click(object? sender, EventArgs e)
    {
        // Lay du lieu MaMH va TenMH moi tu giao dien
        string maMonHoc = textbox_MaMH.Text.Trim();
        string tenMonHoc = textbox_TenMH.Text.Trim();

        // Kiem tra tinh hop le cua du lieu truoc khi tien hanh cap nhat
        if (!KiemTraThongTin(maMonHoc, tenMonHoc))
        {
            return;
        }

        try
        {
            // Thuc thi cau lenh UPDATE bat dong bo, truyen tham so va nhan ve so luong dong bi thay doi
            int soDong = await helper.ExecuteNonQueryAsync(
                "UPDATE MonHoc SET TenMonHoc = @TenMonHoc WHERE MaMonHoc = @MaMonHoc",
                new Dictionary<string, object?>
                {
                    ["@MaMonHoc"] = maMonHoc,
                    ["@TenMonHoc"] = tenMonHoc
                });

            // Thong bao ket qua cap nhat dua tren soDong thuc te bi anh huong
            MessageBox.Show(
                soDong > 0 ? "Sua mon hoc thanh cong." : "Khong tim thay ma mon hoc.",
                "Thong bao", MessageBoxButtons.OK,
                soDong > 0 ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
        }
        catch (Exception ex)
        {
            // Bat loi va hien thi neu qua trinh sua du lieu gap van de
            MessageBox.Show($"Khong the sua mon hoc: {ex.Message}", "Loi",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    // Ham phu tro kiem tra du lieu dau vao cua cac textbox dam bao khong duoc de trong
    private bool KiemTraThongTin(string maMonHoc, string tenMonHoc)
    {
        // Kiem tra neu ma mon hoc bi trong
        if (string.IsNullOrWhiteSpace(maMonHoc))
        {
            MessageBox.Show("Vui long nhap ma mon hoc.", "Thong bao",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            textbox_MaMH.Focus();
            return false;
        }

        // Kiem tra neu ten mon hoc bi trong
        if (string.IsNullOrWhiteSpace(tenMonHoc))
        {
            MessageBox.Show("Vui long nhap ten mon hoc.", "Thong bao",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            textbox_TenMH.Focus();
            return false;
        }

        // Tra ve true khi tat ca cac dieu kien kiem tra deu hop le
        return true;
    }
}