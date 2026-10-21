using System.Data;

namespace Bai9
{
    public partial class BanHang : Form
    {
        public BanHang()
        {
            InitializeComponent();

            // Khoa cac dieu khien cho den khi tao hoa don
            textbox_maHD.Enabled = false;
            combobox_MaSP.Enabled = false;
            textbox_SoLuong.Enabled = false;
            btn_them.Enabled = false;
            btn_huy.Enabled = false;
            btn_thanhtoan.Enabled = false;

            button1.Click += button1_Click;
            btn_them.Click += btn_them_Click;
            btn_huy.Click += btn_huy_Click;
            btn_thanhtoan.Click += btn_thanhtoan_Click;
            Load += BanHang_Load;
        }

        private async void BanHang_Load(object? sender, EventArgs e)
        {
            try
            {
                // Nap ma san pham de chon khi lap hoa don
                DataTable products = await CuaHangDatabase.Helper.GetDataTableAsync(
                    "USE QLCuaHang; SELECT MaSP FROM dbo.SANPHAM ORDER BY MaSP;");

                combobox_MaSP.Items.Clear();
                foreach (DataRow row in products.Rows)
                {
                    string? productID = row["MaSP"].ToString();
                    if (!string.IsNullOrEmpty(productID))
                    {
                        combobox_MaSP.Items.Add(productID);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Không thể tải danh sách sản phẩm: {ex.Message}",
                    "Lỗi cơ sở dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private async void button1_Click(object? sender, EventArgs e)
        {
            try
            {
                // Tao hoa don chua thanh toan va lay ma vua phat sinh
                object? invoiceID = await CuaHangDatabase.Helper.GetSingleValueAsync(@"
                    USE QLCuaHang;
                    INSERT INTO dbo.HOADON (NgayTao, TinhTrangThanhToan)
                    OUTPUT INSERTED.MaHD
                    VALUES (CONVERT(date, GETDATE()), 0);");

                if (invoiceID is null || invoiceID == DBNull.Value)
                {
                    MessageBox.Show("Không tạo được hóa đơn.",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                textbox_maHD.Text = Convert.ToString(invoiceID);
                SetInvoiceControlsEnabled(true);
                button1.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Không thể tạo hóa đơn: {ex.Message}",
                    "Lỗi cơ sở dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btn_them_Click(object? sender, EventArgs e)
        {
            // Kiem tra thong tin hoa don va so luong truoc khi ban
            if (!int.TryParse(textbox_maHD.Text, out int invoiceID) ||
                !int.TryParse(combobox_MaSP.SelectedItem?.ToString(), out int productID) ||
                !int.TryParse(textbox_SoLuong.Text.Trim(), out int quantity) ||
                quantity <= 0)
            {
                MessageBox.Show("Chọn sản phẩm và nhập số lượng nguyên lớn hơn 0.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            const string addInvoiceLineQuery = @"
                USE QLCuaHang;
                SET XACT_ABORT ON;
                BEGIN TRY
                    BEGIN TRANSACTION;

                    IF NOT EXISTS
                    (
                        SELECT 1 FROM dbo.HOADON
                        WHERE MaHD = @MaHD AND TinhTrangThanhToan = 0
                    )
                        THROW 50002, N'Hóa đơn không tồn tại hoặc đã thanh toán.', 1;

                    IF NOT EXISTS (SELECT 1 FROM dbo.SANPHAM WHERE MaSP = @MaSP)
                        THROW 50003, N'Sản phẩm không tồn tại.', 1;

                    IF EXISTS
                    (
                        SELECT 1 FROM dbo.CHITIET_HOADON
                        WHERE MaHD = @MaHD AND MaSP = @MaSP
                    )
                        THROW 50004, N'Sản phẩm đã có trong hóa đơn này.', 1;

                    -- Cap nhat ton va them chi tiet trong cung giao dich
                    UPDATE dbo.TONKHO
                    SET SLBan = SLBan + @SoLuong
                    WHERE MaSP = @MaSP
                      AND NgayTon = CONVERT(date, GETDATE())
                      AND @SoLuong < SLDau + SLNhap - SLBan;

                    IF @@ROWCOUNT = 0
                        THROW 50005, N'Không có tồn kho hôm nay hoặc số lượng bán phải nhỏ hơn số lượng tồn.', 1;

                    INSERT INTO dbo.CHITIET_HOADON (MaHD, MaSP, SoLuong)
                    VALUES (@MaHD, @MaSP, @SoLuong);

                    COMMIT TRANSACTION;
                END TRY
                BEGIN CATCH
                    IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
                    THROW;
                END CATCH;";

            try
            {
                await CuaHangDatabase.Helper.ExecuteNonQueryAsync(
                    addInvoiceLineQuery,
                    new Dictionary<string, object?>
                    {
                        ["@MaHD"] = invoiceID,
                        ["@MaSP"] = productID,
                        ["@SoLuong"] = quantity
                    });

                MessageBox.Show("Đã thêm sản phẩm vào hóa đơn và cập nhật tồn kho.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textbox_SoLuong.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Không thể thêm sản phẩm vào hóa đơn: {ex.Message}",
                    "Lỗi bán hàng", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btn_huy_Click(object? sender, EventArgs e)
        {
            // Hoan lai so luong ton va xoa hoa don chua thanh toan
            if (!int.TryParse(textbox_maHD.Text, out int invoiceID))
            {
                return;
            }

            const string cancelInvoiceQuery = @"
                USE QLCuaHang;
                SET XACT_ABORT ON;
                BEGIN TRY
                    BEGIN TRANSACTION;

                    IF NOT EXISTS
                    (
                        SELECT 1 FROM dbo.HOADON
                        WHERE MaHD = @MaHD AND TinhTrangThanhToan = 0
                    )
                        THROW 50006, N'Hóa đơn không tồn tại hoặc đã thanh toán.', 1;

                    UPDATE tk
                    SET tk.SLBan = tk.SLBan - detail.SoLuong
                    FROM dbo.TONKHO AS tk
                    INNER JOIN dbo.CHITIET_HOADON AS detail ON detail.MaSP = tk.MaSP
                    WHERE detail.MaHD = @MaHD
                      AND tk.NgayTon = CONVERT(date, GETDATE());

                    DELETE FROM dbo.CHITIET_HOADON WHERE MaHD = @MaHD;
                    DELETE FROM dbo.HOADON WHERE MaHD = @MaHD AND TinhTrangThanhToan = 0;

                    COMMIT TRANSACTION;
                END TRY
                BEGIN CATCH
                    IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
                    THROW;
                END CATCH;";

            try
            {
                await CuaHangDatabase.Helper.ExecuteNonQueryAsync(
                    cancelInvoiceQuery,
                    new Dictionary<string, object?> { ["@MaHD"] = invoiceID });

                MessageBox.Show("Đã hủy hóa đơn.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetInvoiceForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Không thể hủy hóa đơn: {ex.Message}",
                    "Lỗi hóa đơn", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btn_thanhtoan_Click(object? sender, EventArgs e)
        {
            // Danh dau hoa don co chi tiet la da thanh toan
            if (!int.TryParse(textbox_maHD.Text, out int invoiceID))
            {
                return;
            }

            try
            {
                int affectedRows = await CuaHangDatabase.Helper.ExecuteNonQueryAsync(@"
                    USE QLCuaHang;
                    UPDATE dbo.HOADON
                    SET TinhTrangThanhToan = 1
                    WHERE MaHD = @MaHD
                      AND TinhTrangThanhToan = 0
                      AND EXISTS (SELECT 1 FROM dbo.CHITIET_HOADON WHERE MaHD = @MaHD);",
                    new Dictionary<string, object?> { ["@MaHD"] = invoiceID });

                if (affectedRows == 0)
                {
                    MessageBox.Show("Hóa đơn chưa có sản phẩm hoặc đã được thanh toán.",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                MessageBox.Show("Thanh toán hóa đơn thành công.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetInvoiceForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Không thể thanh toán hóa đơn: {ex.Message}",
                    "Lỗi hóa đơn", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetInvoiceControlsEnabled(bool enabled)
        {
            // Bat hoac tat cac dieu khien chi tiet hoa don
            textbox_maHD.Enabled = enabled;
            combobox_MaSP.Enabled = enabled;
            textbox_SoLuong.Enabled = enabled;
            btn_them.Enabled = enabled;
            btn_huy.Enabled = enabled;
            btn_thanhtoan.Enabled = enabled;
        }

        private void ResetInvoiceForm()
        {
            // Xoa trang thai hoa don sau khi huy hoac thanh toan
            textbox_maHD.Clear();
            textbox_SoLuong.Clear();
            combobox_MaSP.SelectedIndex = -1;
            SetInvoiceControlsEnabled(false);
            button1.Enabled = true;
        }
    }
}
