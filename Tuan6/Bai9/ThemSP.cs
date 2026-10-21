using System;

namespace Bai9
{
    public partial class ThemSP : Form
    {
        public ThemSP()
        {
            InitializeComponent();

            btn_them.Click += btn_them_Click;
            btn_thoat.Click += btn_thoat_Click;
        }

        private async void btn_them_Click(object? sender, EventArgs e)
        {
            // Kiem tra ten san pham truoc khi ghi vao co so du lieu
            string productName = textbox_tenSP.Text.Trim();
            if (string.IsNullOrWhiteSpace(productName))
            {
                MessageBox.Show("Tên sản phẩm không được để trống.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textbox_tenSP.Focus();
                return;
            }

            const string addProductQuery = @"
                USE QLCuaHang;
                SET XACT_ABORT ON;
                BEGIN TRY
                    BEGIN TRANSACTION;

                    -- Them san pham va ton kho ban dau trong cung giao dich
                    DECLARE @MaSP int;
                    INSERT INTO dbo.SANPHAM (TenSP) VALUES (@TenSP);
                    SET @MaSP = CONVERT(int, SCOPE_IDENTITY());

                    INSERT INTO dbo.TONKHO (MaSP, NgayTon, SLDau, SLNhap, SLBan)
                    VALUES (@MaSP, CONVERT(date, GETDATE()), 0, 0, 0);

                    COMMIT TRANSACTION;
                END TRY
                BEGIN CATCH
                    IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
                    THROW;
                END CATCH;";

            try
            {
                await CuaHangDatabase.Helper.ExecuteNonQueryAsync(
                    addProductQuery,
                    new Dictionary<string, object?> { ["@TenSP"] = productName });

                MessageBox.Show("Thêm sản phẩm và dòng tồn kho hôm nay thành công.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textbox_tenSP.Clear();
                textbox_tenSP.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Không thể thêm sản phẩm: {ex.Message}",
                    "Lỗi cơ sở dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_thoat_Click(object? sender, EventArgs e)
        {
            // Dong form them san pham
            Close();
        }
    }
}
