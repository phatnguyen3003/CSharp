using System;
using SharedLibs;

namespace Tuan2
{
    public class NhanVien
    {
        // Properties
        public string HoTen { get; set; }
        public double MucLuong { get; set; }
        public int SoNgayVang { get; set; }

        //constructor
        public NhanVien()
        {
            HoTen = "";
            MucLuong = 0;
            SoNgayVang = 0;
        }

        public NhanVien(string hoTen, double mucLuong, int soNgayVang)// constructor voi cac tham so
        {
            HoTen = hoTen;
            MucLuong = mucLuong;
            SoNgayVang = soNgayVang;
        }

        public NhanVien(NhanVien khac)//copy constructor
        {
            if (khac != null)
            {
                HoTen = khac.HoTen;
                MucLuong = khac.MucLuong;
                SoNgayVang = khac.SoNgayVang;
            }
        }

        // tinh luong nhan vien
        public double TinhLuong()
        {
            double luongThucNhan = MucLuong - (SoNgayVang * 100000);
            return Math.Max(0, luongThucNhan); // dam bao luong khong am
        }

        // nhap/xuat
        public void Input()
        {
            HoTen = SharedLibs.InputHelper.InputString("ho ten nhan vien");
            MucLuong = SharedLibs.InputHelper.InputDouble("muc luong co ban");
            SoNgayVang = SharedLibs.InputHelper.InputNatural("so ngay vang");
        }

        public override string ToString()
        {
            return $"Ho ten: {HoTen,-20} | Luong co ban: {MucLuong,12:N0} VNĐ | So ngay vang: {SoNgayVang,2} | Luong thuc nhan: {TinhLuong(),12:N0} VNĐ";
        }
    }


    public class PhongBan
    {
        private NhanVien[] dsNhanVien;

        public int SoLuong
        {
            get
            {
                if (dsNhanVien != null)
                    return dsNhanVien.Length;
                else
                    return 0;
            }
        }

        // Constructor
        public PhongBan()
        {
            dsNhanVien = new NhanVien[0];
        }

        public PhongBan(int n)//constructor voi tham so n
        {
            int size = Math.Max(0, n);
            dsNhanVien = new NhanVien[size];
            for (int i = 0; i < size; i++)
            {
                dsNhanVien[i] = new NhanVien();
            }
        }

        // nhap thong tin danh sach nhan vien
        public void Input()
        {
            int n = SharedLibs.InputHelper.InputNatural("so luong nhan vien n", largerthan0: true);
            dsNhanVien = new NhanVien[n];

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"\n--- Nhap thong tin nhan vien thu {i + 1} ---");
                NhanVien nv = new NhanVien();
                nv.Input();
                dsNhanVien[i] = nv;
            }
        }

        // tinh luong cua phong ban
        public double TinhTongLuong()
        {
            double tongLuong = 0;
            if (dsNhanVien == null) return 0;

            foreach (NhanVien nv in dsNhanVien)
            {
                tongLuong += nv.TinhLuong();
            }
            return tongLuong;
        }

        // xuat danh sach va tong luong
        public void Output()
        {
            Console.WriteLine("\n=================== danh sach luong nhan vien trong phong ban ===================");
            if (dsNhanVien == null || dsNhanVien.Length == 0)
            {
                Console.WriteLine("Phong ban chua co nhan vien.");
                return;
            }

            for (int i = 0; i < dsNhanVien.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {dsNhanVien[i]}");
            }

            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine($"=> tong luong phong ban: {TinhTongLuong():N0} VNĐ");
        }
    }
}