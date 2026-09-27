using System;
using SharedLibs;

namespace Tuan3;

public class Bai6_1
{
    // Dinh nghia lop He dao tao
    public class He
    {
        public string MaHe { get; set; } = "";
        public string TenHe { get; set; } = "";

        // Ghi de ToString de in thong tin he dao tao
        public override string ToString()
        {
            return $"[{MaHe}] {TenHe}";
        }
    }

    // Lop DuLieu_He tao danh sach he dao tao mau
    public class DuLieu_He
    {
        public static List<He> DS_He()
        {
            return new List<He>
            {
                new He { MaHe = "KTV", TenHe = "Kỹ thuật viên" },
                new He { MaHe = "CD",  TenHe = "Chuyên đề" },
                new He { MaHe = "QT",  TenHe = "Chứng chỉ quốc tế" }
            };
        }
    }

    public static void Main(string[] args)
    {
        // Lay va in danh sach cac he dao tao
        var dsHe = DuLieu_He.DS_He();
        dsHe.Dump("------------- Danh sách Hệ đào tạo -------------");
    }
}