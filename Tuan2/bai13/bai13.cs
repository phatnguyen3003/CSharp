using System;

namespace Tuan2
{
    public class ArraySort_Bai13
    {
        // ham ho tro xap xep theo ten cua danh sach lay tu bai 12
        public static void SapXepTheoTen(NhanVien[] ds)
        {
            Array.Sort(ds, SoSanhTheoTen);
        }

        public static int SoSanhTheoTen(NhanVien nv1, NhanVien nv2)
        {
            return nv1.HoTen.CompareTo(nv2.HoTen);
        }

        public static void SapXepTheoLuongGiamDan(NhanVien[] ds)
        {
            Array.Sort(ds); // tu dong dung ham compareto da dinh nghia o bai 12
        }
    }
}