using System;
using SharedLibs;


namespace Tuan2
{
    public class NhanVien//lop nhan vien
    {
        private string maNV;
        private string tenNV;

        public string MaNV { get; set; }
        public string TenNV { get; set; }

        public NhanVien()//constructor khong tham so
        {
            maNV = null;
            tenNV = null;
        }

        public NhanVien(string maNV, string tenNV)//constructor co tham so
        {
            this.maNV = maNV;
            this.tenNV = tenNV;
        }

        public NhanVien(NhanVien khac)// copy constructor
        {
            this.maNV = khac.maNV;
            this.tenNV = khac.tenNV;
        }

        public virtual double TinhLuong()
        {
            return 0;
        }

        public virtual void XuatThongTin()
        {
            Console.Write($"Mã NV: {MaNV} | Họ tên: {TenNV}");
        }

        public virtual void ThemNV()
        {
            maNV = SharedLibs.InputHelper.InputString("ma nhan vien");
            tenNV = SharedLibs.InputHelper.InputString("ten nhan vien");
        }
    }

    public class NhanVienKinhDoanh : NhanVien
    {
        public double LuongCoBan { get; set; }
        public int SoHopDong { get; set; }


        public NhanVienKinhDoanh(string maNV, string hoTen, double luongCoBan, int soHopDong)
            : base(maNV, hoTen) // tai su dung constructor cua lop cha
        {
            LuongCoBan = luongCoBan;
            SoHopDong = soHopDong;
        }
        public NhanVienKinhDoanh() : base() { }

        public override double TinhLuong()
        {
            return LuongCoBan + (SoHopDong * 500000);
        }

        public override void XuatThongTin()
        {
            base.XuatThongTin();
            Console.WriteLine($" | Bo phan: Kinh Doanh| Luong: {TinhLuong(),12:N0} VNĐ");
        }

        public override void ThemNV()
        {
            base.ThemNV();
            LuongCoBan = SharedLibs.InputHelper.InputDouble("luong co ban");
            SoHopDong = SharedLibs.InputHelper.InputNatural("so hop dong");
        }
    }

    public class NhanVienSanXuat : NhanVien
    {
        public int SoSanPham { get; set; }

        public NhanVienSanXuat(string maNV, string hoTen, int soSanPham)
            : base(maNV, hoTen) // tai su dung constructor cua lop cha
        {
            SoSanPham = soSanPham;
        }
        public NhanVienSanXuat() : base() { }

        public override double TinhLuong()
        {
            double luong = SoSanPham * 1000;
            if (SoSanPham > 3000)
            {
                luong *= 1.05; // thuong them 5% neu tren 300 san pham
            }
            return luong;
        }

        public override void XuatThongTin()
        {
            base.XuatThongTin();
            Console.WriteLine($" | Bo phan: san xuat  | Luong: {TinhLuong(),12:N0} VNĐ");
        }

        public override void ThemNV()
        {
            base.ThemNV();
            SoSanPham = SharedLibs.InputHelper.InputNatural("so san pham");
        }
    }
}
