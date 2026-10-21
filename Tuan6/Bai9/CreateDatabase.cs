using Classlibrary_for_database;

namespace Bai9;

public static class CreateDatabase
{
    private static readonly string Server = "localhost,1433";
    private static readonly string Database = "master";
    private static readonly string User_ID = "sa";
    private static readonly string Password = "SqlServer@2026";
    private static readonly string TrustServer = "True";

    public static async Task Main(string[] args)
    {
        string connectionString =
            $"Server={Server};Database={Database};User Id={User_ID};Password={Password};TrustServerCertificate={TrustServer};";
        var helper = new DatabaseHelper(connectionString);

        if (!await helper.TestConnectionAsync())
        {
            Console.WriteLine("Không thể kết nối đến SQL Server.");
            return;
        }

        try
        {
            await helper.ExecuteNonQueryAsync(
                "IF DB_ID(N'QLCuaHang') IS NULL CREATE DATABASE QLCuaHang;");

            string createTablesQuery = @"
                USE QLCuaHang;

                IF OBJECT_ID(N'dbo.SANPHAM', N'U') IS NULL
                BEGIN
                    CREATE TABLE dbo.SANPHAM (
                        MaSP INT IDENTITY(1,1) NOT NULL,
                        TenSP NVARCHAR(100) NOT NULL,
                        CONSTRAINT PK_SANPHAM PRIMARY KEY (MaSP)
                    );
                END;

                IF OBJECT_ID(N'dbo.HOADON', N'U') IS NULL
                BEGIN
                    CREATE TABLE dbo.HOADON (
                        MaHD INT IDENTITY(1,1) NOT NULL,
                        NgayTao DATE NOT NULL,
                        TinhTrangThanhToan BIT NOT NULL
                            CONSTRAINT DF_HOADON_TinhTrangThanhToan DEFAULT (0),
                        CONSTRAINT PK_HOADON PRIMARY KEY (MaHD)
                    );
                END;

                IF OBJECT_ID(N'dbo.CHITIET_HOADON', N'U') IS NULL
                BEGIN
                    CREATE TABLE dbo.CHITIET_HOADON (
                        MaHD INT NOT NULL,
                        MaSP INT NOT NULL,
                        SoLuong INT NOT NULL,
                        CONSTRAINT PK_CHITIET_HOADON PRIMARY KEY (MaHD, MaSP),
                        CONSTRAINT FK_CHITIET_HOADON_HOADON
                            FOREIGN KEY (MaHD) REFERENCES dbo.HOADON(MaHD),
                        CONSTRAINT FK_CHITIET_HOADON_SANPHAM
                            FOREIGN KEY (MaSP) REFERENCES dbo.SANPHAM(MaSP)
                    );
                END;

                IF OBJECT_ID(N'dbo.TONKHO', N'U') IS NULL
                BEGIN
                    CREATE TABLE dbo.TONKHO (
                        MaSP INT NOT NULL,
                        NgayTon DATE NOT NULL,
                        SLDau INT NOT NULL
                            CONSTRAINT DF_TONKHO_SLDau DEFAULT (0),
                        SLNhap INT NOT NULL
                            CONSTRAINT DF_TONKHO_SLNhap DEFAULT (0),
                        SLBan INT NOT NULL
                            CONSTRAINT DF_TONKHO_SLBan DEFAULT (0),
                        CONSTRAINT PK_TONKHO PRIMARY KEY (MaSP, NgayTon),
                        CONSTRAINT FK_TONKHO_SANPHAM
                            FOREIGN KEY (MaSP) REFERENCES dbo.SANPHAM(MaSP)
                    );
                END;";

            await helper.ExecuteNonQueryAsync(createTablesQuery);

            string insertSampleDataQuery = @"
                USE QLCuaHang;

                IF NOT EXISTS (SELECT 1 FROM dbo.SANPHAM WHERE TenSP = N'Trà xanh')
                    INSERT INTO dbo.SANPHAM (TenSP) VALUES (N'Trà xanh');
                IF NOT EXISTS (SELECT 1 FROM dbo.SANPHAM WHERE TenSP = N'Mứt dâu')
                    INSERT INTO dbo.SANPHAM (TenSP) VALUES (N'Mứt dâu');
                IF NOT EXISTS (SELECT 1 FROM dbo.SANPHAM WHERE TenSP = N'Cafe')
                    INSERT INTO dbo.SANPHAM (TenSP) VALUES (N'Cafe');

                IF NOT EXISTS (
                    SELECT 1 FROM dbo.TONKHO AS tk
                    INNER JOIN dbo.SANPHAM AS sp ON sp.MaSP = tk.MaSP
                    WHERE sp.TenSP = N'Trà xanh' AND tk.NgayTon = '20161029')
                    INSERT INTO dbo.TONKHO (MaSP, NgayTon, SLDau, SLNhap, SLBan)
                    SELECT TOP (1) MaSP, '20161029', 50, 0, 0
                    FROM dbo.SANPHAM WHERE TenSP = N'Trà xanh' ORDER BY MaSP;

                IF NOT EXISTS (
                    SELECT 1 FROM dbo.TONKHO AS tk
                    INNER JOIN dbo.SANPHAM AS sp ON sp.MaSP = tk.MaSP
                    WHERE sp.TenSP = N'Mứt dâu' AND tk.NgayTon = '20161029')
                    INSERT INTO dbo.TONKHO (MaSP, NgayTon, SLDau, SLNhap, SLBan)
                    SELECT TOP (1) MaSP, '20161029', 50, 0, 0
                    FROM dbo.SANPHAM WHERE TenSP = N'Mứt dâu' ORDER BY MaSP;

                IF NOT EXISTS (
                    SELECT 1 FROM dbo.TONKHO AS tk
                    INNER JOIN dbo.SANPHAM AS sp ON sp.MaSP = tk.MaSP
                    WHERE sp.TenSP = N'Cafe' AND tk.NgayTon = '20161029')
                    INSERT INTO dbo.TONKHO (MaSP, NgayTon, SLDau, SLNhap, SLBan)
                    SELECT TOP (1) MaSP, '20161029', 50, 0, 0
                    FROM dbo.SANPHAM WHERE TenSP = N'Cafe' ORDER BY MaSP;";

            await helper.ExecuteNonQueryAsync(insertSampleDataQuery);

            Console.WriteLine("Đã tạo/cập nhật database QLCuaHang, các bảng và dữ liệu mẫu.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Không thể tạo database hoặc dữ liệu mẫu: {ex.Message}");
        }
    }
}
