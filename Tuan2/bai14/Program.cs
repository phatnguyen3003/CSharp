using System;
using System.Collections.Generic;

namespace Tuan2
{



    // tao 2 lop bo so sanh ben ngoai dung cho cach 2 (IComparer<T>) de 

    // bo so sanh 1, nhan vien duoc sap xep theo ten (A -> Z)
    public class NhanVienTenComparer : IComparer<NhanVien>
    {
        public int Compare(NhanVien? x, NhanVien? y)
        {
            if (x == null || y == null) return 0;
            return x.HoTen.CompareTo(y.HoTen);
        }
    }

    // bo so sanh 2, nhan vien duoc sap xep theo so ngay vang
    public class NhanVienNgayVangComparer : IComparer<NhanVien>
    {
        public int Compare(NhanVien? x, NhanVien? y)
        {
            if (x == null || y == null) return 0;
            return x.SoNgayVang.CompareTo(y.SoNgayVang);
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // TEST 1: kiem thu voi kieu so nguyen, DotNet da viet san compareto cho kieu nay
            int[] numbers = { 42, 15, 88, 3, 27, 19 };
            Console.WriteLine("=== mang sop nguyen ban dau ===");
            Console.WriteLine(string.Join(", ", numbers));

            CustomArray.Sort(numbers); // tu dong chay compareto co san
            Console.WriteLine("=== mang so nguyen sap xep tang dan, cach 1 ===");
            Console.WriteLine(string.Join(", ", numbers));

            // TEST 2: voi mang doi tuong nhan vien cua bai 12
            NhanVien[] dsNhanVien = new NhanVien[]
            {
                new NhanVien("Nguyen Van C", 10000000, 3), // luong thuc su nhan: 9.700.000
                new NhanVien("Tran Thi A", 15000000, 1),  // luong thuc su nhan: 14.900.000
                new NhanVien("Le Van B", 12000000, 5),   // luong thuc su nhan: 11.500.000
                new NhanVien("Pham Thi D", 8000000, 0)    // luong thuc su nhan: 8.000.000
            };

            Console.WriteLine("\n================ danh sach ban dau ================");
            InDanhSach(dsNhanVien);

            // A. TEST CÁCH 1: dung IComparable (da duoc dinh nghia san trong NhanVien.cs - luong giam dan)
            CustomArray.Sort(dsNhanVien);
            Console.WriteLine("\n==== cach 1 (IComparable): sap xep theo luong giam dan ====");
            InDanhSach(dsNhanVien);

            // B. TEST CÁCH 2:dung IComparer ben ngoai (sap xep theo ten A -> Z)
            CustomArray.Sort(dsNhanVien, new NhanVienTenComparer());
            Console.WriteLine("\n==== CÁCH 2 (IComparer): SẮP XẾP THEO TÊN (A -> Z) ====");
            InDanhSach(dsNhanVien);

            // C. TEST CÁCH 2: Dùng IComparer bên ngoài (Sắp xếp theo Ngày vắng tăng dần)
            CustomArray.Sort(dsNhanVien, new NhanVienNgayVangComparer());
            Console.WriteLine("\n==== CÁCH 2 (IComparer): SẮP XẾP THEO NGÀY VẮNG TĂNG DẦN ====");
            InDanhSach(dsNhanVien);
        }

        static void InDanhSach(NhanVien[] ds)
        {
            for (int i = 0; i < ds.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {ds[i]}");
            }
        }
    }
}