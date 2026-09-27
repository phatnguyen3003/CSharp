using System;
using SharedLibs;

namespace Tuan3;

public class Bai3_2
{
    static void Bai32()
    {
        // Mang danh sach cac mon an
        string[] monAn = { "Bún bò Huế", "Hủ tiếu heo", "Bánh canh", "Bánh mì",
                "Nước Cà phê", "Mì quảng", "Cơm tấm", "Nước Chanh dây", "Mì xào",
                "Bún riêu", "Bánh cuốn", "Mì gói", "Bún chả", "Hủ tiếu Nam vang" };

        // Tim do dai ngan nhat va dai nhat
        int doDaiNganNhat = monAn.Min(s => s.Length);
        int doDaiDaiNhat = monAn.Max(s => s.Length);

        // Cau a: tim cac mon an co chieu dai ngan nhat
        var kqA_1 = monAn.Where(s => s.Length == doDaiNganNhat);
        kqA_1.Dump($"-------------Bai 3.2.a) Mon an ngan nhat ({doDaiNganNhat} ky tu): --------------");

        // Tim cac mon an co chieu dai dai nhat
        var kqA_2 = monAn.Where(s => s.Length == doDaiDaiNhat);
        kqA_2.Dump($"-------------Bai 3.2.a) Mon an dai nhat ({doDaiDaiNhat} ky tu): --------------");

        // Cau b: phan nhom theo tu dau tien cua ten mon
        var kqB = from monan in monAn
                  group monan by monan.Split(' ')[0] into tu
                  select new
                  {
                      TuDauTien = tu.Key,
                      CacMonAn = string.Join(", ", tu)
                  };

        kqB.Dump("-------------Bai 3.2.b) Phan nhom theo tu dau tien: --------------");

        // Cau c: dem so phan tu bat dau bang tu 'Banh'
        var kqC = (from monan in monAn
                   group monan by monan.Split(' ')[0] into tu
                   where tu.Key == "Bánh"
                   select tu.Count()).FirstOrDefault();

        kqC.Dump("-------------Bai 3.2.c) So tu bat dau bang 'Banh': --------------");
    }

    public static void Main(string[] args)
    {
        // Goi ham thuc thi bai 3.2
        Bai32();
    }
}