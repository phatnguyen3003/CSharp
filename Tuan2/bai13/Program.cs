using System;

namespace Tuan2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // tao mang doi tuong nhan vien, dung class nhan vien tu bai 12
            NhanVien[] dsNhanVien = new NhanVien[]
            {
                new NhanVien("Nguyen Van C", 10000000, 3), // luong thuc su nhan: 9.700.000
                new NhanVien("Tran Thi A", 15000000, 1),  // luong thuc su nhan: 14.900.000
                new NhanVien("Le Van B", 12000000, 5),   // luong thuc su nhan: 11.500.000
                new NhanVien("Pham Thi D", 8000000, 0)    // luong thuc su nhan: 8.000.000
            };

            Console.WriteLine("================ danh sach ban dau ================");
            InDanhSach(dsNhanVien);

            // goi ham sap xep theo ten da khai bao o bai13.cs
            ArraySortTinh_Bai13.SapXepTheoTen(dsNhanVien);
            Console.WriteLine("\n==== sap xep theo ten (A -> Z) ====");
            InDanhSach(dsNhanVien);

            // 3. Gọi hàm SapXepTheoLuongGiamDan từ class ArraySortTinh_Bai13
            ArraySortTinh_Bai13.SapXepTheoLuongGiamDan(dsNhanVien);
            Console.WriteLine("\n==== sap xep theo luong( giam dan) ====");
            InDanhSach(dsNhanVien);
        }

        // inr a man hinh
        static void InDanhSach(NhanVien[] ds)
        {
            for (int i = 0; i < ds.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {ds[i]}");
            }
        }
    }
}