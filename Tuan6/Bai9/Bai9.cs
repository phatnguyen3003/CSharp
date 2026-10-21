namespace Bai9
{
    public partial class Bai9 : Form
    {
        public Bai9()
        {
            InitializeComponent();

            // Tao menu va gan su kien cho cac chuc nang chinh
            CreateMenu();
        }

        // Tao thanh menu dieu huong den cac chuc nang cua cua hang
        private void CreateMenu()
        {
            var menu = new MenuStrip();
            var inventoryMenuItem = new ToolStripMenuItem("Tạo tồn kho");
            var productMenuItem = new ToolStripMenuItem("Thêm sản phẩm mới");
            var salesMenuItem = new ToolStripMenuItem("Bán hàng");

            inventoryMenuItem.Click += btn_taotonkho_Click;
            productMenuItem.Click += btn_themSP_Click;
            salesMenuItem.Click += btn_banhang_Click;

            menu.Items.Add(inventoryMenuItem);
            menu.Items.Add(productMenuItem);
            menu.Items.Add(salesMenuItem);
            MainMenuStrip = menu;
            Controls.Add(menu);
        }

        private async void btn_taotonkho_Click(object? sender, EventArgs e)
        {
            // Tao ton dau ngay tu so ton cuoi ngay truoc, khong tao trung theo ngay
            const string createTodayInventoryQuery = @"
                USE QLCuaHang;
                IF NOT EXISTS (SELECT 1 FROM dbo.SANPHAM)
                    THROW 50001, N'Chưa có sản phẩm để tạo tồn kho.', 1;

                INSERT INTO dbo.TONKHO (MaSP, NgayTon, SLDau, SLNhap, SLBan)
                SELECT
                    sp.MaSP,
                    CONVERT(date, GETDATE()),
                    ISNULL(previousStock.SLDau + previousStock.SLNhap - previousStock.SLBan, 0),
                    0,
                    0
                FROM dbo.SANPHAM AS sp
                OUTER APPLY
                (
                    SELECT TOP (1) tk.SLDau, tk.SLNhap, tk.SLBan
                    FROM dbo.TONKHO AS tk
                    WHERE tk.MaSP = sp.MaSP
                      AND tk.NgayTon < CONVERT(date, GETDATE())
                    ORDER BY tk.NgayTon DESC
                ) AS previousStock
                WHERE NOT EXISTS
                (
                    SELECT 1
                    FROM dbo.TONKHO AS todayStock
                    WHERE todayStock.MaSP = sp.MaSP
                      AND todayStock.NgayTon = CONVERT(date, GETDATE())
                );";

            try
            {
                await CuaHangDatabase.Helper.ExecuteNonQueryAsync(createTodayInventoryQuery);
                MessageBox.Show("Đã tạo tồn kho hôm nay cho các sản phẩm chưa có dữ liệu.",
                    "Tồn kho", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Không thể tạo tồn kho: {ex.Message}",
                    "Lỗi cơ sở dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_themSP_Click(object? sender, EventArgs e)
        {
            // Mo form them san pham
            using var form = new ThemSP();
            form.ShowDialog(this);
        }

        private void btn_banhang_Click(object? sender, EventArgs e)
        {
            // Mo form ban hang
            using var form = new BanHang();
            form.ShowDialog(this);
        }
    }
}
