
using System;

namespace Tuan2
{

    class Program
    {
        // -----------------------------------------------------------------
        // Các phương thức so sánh tĩnh (Named Methods)
        // -----------------------------------------------------------------
        static int SoSanhTheoTen(NhanVien nv1, NhanVien nv2)
        {
            return nv1.HoTen.CompareTo(nv2.HoTen);
        }

        static int SoSanhTheoLuongGiamDan(NhanVien nv1, NhanVien nv2)
        {
            return nv2.TinhLuong().CompareTo(nv1.TinhLuong());
        }

        static int SoSanhTheoSoNgayVang(NhanVien nv1, NhanVien nv2)
        {
            return nv1.SoNgayVang.CompareTo(nv2.SoNgayVang);
        }

        // -----------------------------------------------------------------
        // Hàm Main
        // -----------------------------------------------------------------
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            NhanVien[] dsNhanVien = new NhanVien[]
            {
                    new NhanVien("Nguyen Van C", 10000000, 3),
                    new NhanVien("Tran Thi A", 15000000, 1),
                    new NhanVien("Le Van B", 12000000, 5),
                    new NhanVien("Pham Thi D", 8000000, 0)
            };


            //goi lan 1 dung delegate tu dinh nghia

            // 1. BubbleSort theo ho ten A -> Z
            CustomArrayDelegate.Sort(dsNhanVien, new SoSanhDelegate<NhanVien>(SoSanhTheoTen));// can truyen dang new Comparison<NhanVien> de tranh trung chu ky voi ham tich hop san
            Console.WriteLine("\n==== lan 1 bubble sort theo ho ten (A -> Z) ====");
            InDanhSach(dsNhanVien);

            // 2. BubbleSort theo luong thuc nhan
            CustomArrayDelegate.Sort(dsNhanVien, new SoSanhDelegate<NhanVien>(SoSanhTheoLuongGiamDan));
            Console.WriteLine("\n==== lan 1 bubble sort theo luong thuc nhan (giam dan) ====");
            InDanhSach(dsNhanVien);

            // 3. BubbleSort theo Số ngày vắng Tăng dần
            CustomArrayDelegate.Sort(dsNhanVien, new SoSanhDelegate<NhanVien>(SoSanhTheoSoNgayVang));
            Console.WriteLine("\n==== lan 1 bubble sort theo so ngay vang (tang dan) ====");
            InDanhSach(dsNhanVien);





            //goi lan 2 dung delegate tich hop san

            // 1. BubbleSort theo ho ten A -> Z
            CustomArrayDelegate.Sort(dsNhanVien, new Comparison<NhanVien>(SoSanhTheoTen));// can truyen dang new Comparison<NhanVien> de tranh trung chu ky voi ham tich hop san
            Console.WriteLine("\n==== lan 2 bubble sort theo ho ten (A -> Z) ====");
            InDanhSach(dsNhanVien);

            // 2. BubbleSort theo luong thuc nhan
            CustomArrayDelegate.Sort(dsNhanVien, new Comparison<NhanVien>(SoSanhTheoLuongGiamDan));
            Console.WriteLine("\n==== lan 2 bubble sort theo luong thuc nhan (giam dan) ====");
            InDanhSach(dsNhanVien);

            // 3. BubbleSort theo Số ngày vắng Tăng dần
            CustomArrayDelegate.Sort(dsNhanVien, new Comparison<NhanVien>(SoSanhTheoSoNgayVang));
            Console.WriteLine("\n==== lan 2 bubble sort theo so ngay vang (tang dan) ====");
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
