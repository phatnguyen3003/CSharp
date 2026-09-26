using System;
using System.Collections.Generic;

namespace Tuan2
{

    public class QuanLyNhanVienConsole : ConsoleMenu //su dung lai class console menu bai 16
    {
        private List<NhanVien> dsNhanVien;

        public QuanLyNhanVienConsole(List<NhanVien> ds) : base("QUẢN LÝ LƯƠNG CÔNG TY")
        {
            dsNhanVien = ds;

            AddOption("Hiển thị bảng lương toàn công ty", HienThiDanhSach);
            AddOption("Tính tổng tiền lương công ty phải trả", TinhTongLuong);
            AddOption("Thêm Nhân viên Kinh doanh", ThemKinhDoanh);
            AddOption("Thêm Nhân viên Sản xuất", ThemSanXuat);
        }

        private void ThemKinhDoanh()
        {
            Console.WriteLine("--- NHẬP THÔNG TIN NHÂN VIÊN KINH DOANH ---");
            NhanVienKinhDoanh nv = new NhanVienKinhDoanh(); // tao do ituong
            nv.ThemNV();                                   // goi phuong thuc them nhan vien
            dsNhanVien.Add(nv);
            Console.WriteLine("-> Thêm nhân viên kinh doanh thành công!");
        }

        private void ThemSanXuat()
        {
            Console.WriteLine("--- NHẬP THÔNG TIN NHÂN VIÊN SẢN XUẤT ---");
            NhanVienSanXuat nv = new NhanVienSanXuat();     // tao do ituong
            nv.ThemNV();                                   // goi phuong thuc them nhan vien
            dsNhanVien.Add(nv);
            Console.WriteLine("-> Thêm nhân viên sản xuất thành công!");
        }

        private void HienThiDanhSach()
        {
            Console.WriteLine("================ DANH SÁCH BẢNG LƯƠNG ================");
            if (dsNhanVien.Count == 0)
            {
                Console.WriteLine("Danh sách nhân viên trống!");
                return;
            }

            for (int i = 0; i < dsNhanVien.Count; i++)
            {
                Console.Write($"{i + 1}. ");
                dsNhanVien[i].XuatThongTin();
            }
        }

        private void TinhTongLuong()
        {
            double tongLuong = 0;
            foreach (NhanVien nv in dsNhanVien)
            {
                tongLuong += nv.TinhLuong();
            }
            Console.WriteLine($"\nTổng số tiền lương công ty phải trả: {tongLuong:N0} VNĐ");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            List<NhanVien> dsNhanVien = new List<NhanVien>();

            // khoi tao cac du lieu mau
            dsNhanVien.Add(new NhanVienKinhDoanh("KD01", "Nguyễn Văn A", 7000000, 5));
            dsNhanVien.Add(new NhanVienSanXuat("SX01", "Trần Thị B", 2500));
            dsNhanVien.Add(new NhanVienSanXuat("SX02", "Lê Văn C", 3500)); // thuong 5% 5% do > 3000 SP
            dsNhanVien.Add(new NhanVienKinhDoanh("KD02", "Phạm Thị D", 8000000, 2));


            QuanLyNhanVienConsole menu = new QuanLyNhanVienConsole(dsNhanVien);
            menu.Run();
        }
    }
}