using Classlibrary_for_database;
using System;
using System.Threading.Tasks;

namespace Tuan6;

public class CreateDatabase
{
    // Khai bao cac thong so ket noi la static de co the su dung ben trong ham Main static
    private static readonly string Server = "localhost,1433";
    private static readonly string Database = "master";
    private static readonly string User_ID = "sa";
    private static readonly string Password = "SqlServer@2026";
    private static readonly string TrustServer = "True";


    public static async Task Main(string[] args)
    {
        string connectionString = $"Server={Server};Database={Database};User Id={User_ID};Password={Password};TrustServerCertificate={TrustServer};";

        // Khoi tao doi tuong DatabaseHelper tu Class Library dung chung
        DatabaseHelper helper = new DatabaseHelper(connectionString);

        bool connected = await helper.TestConnectionAsync();


        // Cau lenh SQL kiem tra xem database 'QLSinhVien' da ton tai chua, neu chua thi tao moi
        string createDbQuery = "IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'QLSinhVien') CREATE DATABASE QLSinhVien;";
        
        try
        {
            Console.WriteLine("Dang tien hanh tao co so du lieu tren SQL Server (Docker)...");

            // Thuc thi cau lenh tao database bat dong bo
            int rowsAffected = await helper.ExecuteNonQueryAsync(createDbQuery);

            Console.WriteLine("Tao co so du lieu thanh cong hoac da ton tai tu truoc!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Loi khi thuc thi tao co so du lieu: {ex.Message}");
        }





        // 2. Chuoi lenh su dung lenh USE theo Cach 2 de tao toan bo cac bang ben trong QLSinhVien
        string createTablesQuery = @"
            -- Chuyen ngu canh sang database QLSinhVien
            USE QLSinhVien;

            -- Tao bang Khoa
            IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Khoa')
            BEGIN
                CREATE TABLE Khoa (
                    MaKhoa NVARCHAR(20) PRIMARY KEY,
                    TenKhoa NVARCHAR(100) NOT NULL
                );
            END;

            -- Tao bang Lop (co khoa ngoai tham chieu toi Khoa)
            IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Lop')
            BEGIN
                CREATE TABLE Lop (
                    MaLop NVARCHAR(20) PRIMARY KEY,
                    TenLop NVARCHAR(100) NOT NULL,
                    MaKhoa NVARCHAR(20) NOT NULL,
                    CONSTRAINT FK_Lop_Khoa FOREIGN KEY (MaKhoa) REFERENCES Khoa(MaKhoa)
                );
            END;

            -- Tao bang SinhVien (co khoa ngoai tham chieu toi Lop)
            IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'SinhVien')
            BEGIN
                CREATE TABLE SinhVien (
                    MaSinhVien NVARCHAR(20) PRIMARY KEY,
                    HoTen NVARCHAR(100) NOT NULL,
                    NgaySinh DATE NULL,
                    MaLop NVARCHAR(20) NOT NULL,
                    CONSTRAINT FK_SinhVien_Lop FOREIGN KEY (MaLop) REFERENCES Lop(MaLop)
                );
            END;

            -- Tao bang MonHoc
            IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'MonHoc')
            BEGIN
                CREATE TABLE MonHoc (
                    MaMonHoc NVARCHAR(20) PRIMARY KEY,
                    TenMonHoc NVARCHAR(100) NOT NULL
                );
            END;

            -- Tao bang Diem (co khoa chinh phuc hop va khoa ngoai tham chieu toi SinhVien, MonHoc)
            IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Diem')
            BEGIN
                CREATE TABLE Diem (
                    MaSinhVien NVARCHAR(20) NOT NULL,
                    MaMonHoc NVARCHAR(20) NOT NULL,
                    Diem FLOAT NULL,
                    CONSTRAINT PK_Diem PRIMARY KEY (MaSinhVien, MaMonHoc),
                    CONSTRAINT FK_Diem_SinhVien FOREIGN KEY (MaSinhVien) REFERENCES SinhVien(MaSinhVien),
                    CONSTRAINT FK_Diem_MonHoc FOREIGN KEY (MaMonHoc) REFERENCES MonHoc(MaMonHoc)
                );
            END;
        ";

        try
        {
            Console.WriteLine("Dang tien hanh tao cac bang");
            await helper.ExecuteNonQueryAsync(createTablesQuery);
            Console.WriteLine("Hoan tat tao cac bang");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Co loi xay ra khi thuc thi: {e.Message}");
        }

        string insertSampleDataQuery = @"
            USE QLSinhVien;

            IF NOT EXISTS (SELECT 1 FROM Khoa WHERE MaKhoa = 'KHOA_MAU01')
                INSERT INTO Khoa (MaKhoa, TenKhoa) VALUES ('KHOA_MAU01', N'Công nghệ thông tin');
            IF NOT EXISTS (SELECT 1 FROM Khoa WHERE MaKhoa = 'KHOA_MAU02')
                INSERT INTO Khoa (MaKhoa, TenKhoa) VALUES ('KHOA_MAU02', N'Kinh tế');
            IF NOT EXISTS (SELECT 1 FROM Khoa WHERE MaKhoa = 'KHOA_MAU03')
                INSERT INTO Khoa (MaKhoa, TenKhoa) VALUES ('KHOA_MAU03', N'Ngoại ngữ');

            IF NOT EXISTS (SELECT 1 FROM Lop WHERE MaLop = 'LOP_MAU01')
                INSERT INTO Lop (MaLop, TenLop, MaKhoa) VALUES ('LOP_MAU01', N'Công nghệ phần mềm', 'KHOA_MAU01');
            IF NOT EXISTS (SELECT 1 FROM Lop WHERE MaLop = 'LOP_MAU02')
                INSERT INTO Lop (MaLop, TenLop, MaKhoa) VALUES ('LOP_MAU02', N'An toàn thông tin', 'KHOA_MAU01');
            IF NOT EXISTS (SELECT 1 FROM Lop WHERE MaLop = 'LOP_MAU03')
                INSERT INTO Lop (MaLop, TenLop, MaKhoa) VALUES ('LOP_MAU03', N'Quản trị kinh doanh', 'KHOA_MAU02');

            IF NOT EXISTS (SELECT 1 FROM SinhVien WHERE MaSinhVien = 'SV_MAU01')
                INSERT INTO SinhVien (MaSinhVien, HoTen, NgaySinh, MaLop)
                VALUES ('SV_MAU01', N'Nguyễn An', '2004-03-15', 'LOP_MAU01');
            IF NOT EXISTS (SELECT 1 FROM SinhVien WHERE MaSinhVien = 'SV_MAU02')
                INSERT INTO SinhVien (MaSinhVien, HoTen, NgaySinh, MaLop)
                VALUES ('SV_MAU02', N'Trần Bình', '2003-08-21', 'LOP_MAU02');
            IF NOT EXISTS (SELECT 1 FROM SinhVien WHERE MaSinhVien = 'SV_MAU03')
                INSERT INTO SinhVien (MaSinhVien, HoTen, NgaySinh, MaLop)
                VALUES ('SV_MAU03', N'Lê Chi', '2004-11-02', 'LOP_MAU03');

            IF NOT EXISTS (SELECT 1 FROM MonHoc WHERE MaMonHoc = 'MH_MAU01')
                INSERT INTO MonHoc (MaMonHoc, TenMonHoc) VALUES ('MH_MAU01', N'Cơ sở dữ liệu');
            IF NOT EXISTS (SELECT 1 FROM MonHoc WHERE MaMonHoc = 'MH_MAU02')
                INSERT INTO MonHoc (MaMonHoc, TenMonHoc) VALUES ('MH_MAU02', N'Lập trình C#');
            IF NOT EXISTS (SELECT 1 FROM MonHoc WHERE MaMonHoc = 'MH_MAU03')
                INSERT INTO MonHoc (MaMonHoc, TenMonHoc) VALUES ('MH_MAU03', N'Toán rời rạc');

            IF NOT EXISTS (SELECT 1 FROM Diem WHERE MaSinhVien = 'SV_MAU01' AND MaMonHoc = 'MH_MAU01')
                INSERT INTO Diem (MaSinhVien, MaMonHoc, Diem) VALUES ('SV_MAU01', 'MH_MAU01', 8.5);
            IF NOT EXISTS (SELECT 1 FROM Diem WHERE MaSinhVien = 'SV_MAU01' AND MaMonHoc = 'MH_MAU02')
                INSERT INTO Diem (MaSinhVien, MaMonHoc, Diem) VALUES ('SV_MAU01', 'MH_MAU02', 9.0);
            IF NOT EXISTS (SELECT 1 FROM Diem WHERE MaSinhVien = 'SV_MAU02' AND MaMonHoc = 'MH_MAU01')
                INSERT INTO Diem (MaSinhVien, MaMonHoc, Diem) VALUES ('SV_MAU02', 'MH_MAU01', 7.5);
            IF NOT EXISTS (SELECT 1 FROM Diem WHERE MaSinhVien = 'SV_MAU03' AND MaMonHoc = 'MH_MAU03')
                INSERT INTO Diem (MaSinhVien, MaMonHoc, Diem) VALUES ('SV_MAU03', 'MH_MAU03', 8.0);
        ";

        try
        {
            Console.WriteLine("Dang them du lieu mau vao cac bang...");
            await helper.ExecuteNonQueryAsync(insertSampleDataQuery);
            Console.WriteLine("Da them du lieu mau (cac ban ghi da ton tai duoc bo qua).");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Loi khi them du lieu mau: {e.Message}");
        }



    }
}