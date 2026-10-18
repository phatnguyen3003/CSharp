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




    }
}