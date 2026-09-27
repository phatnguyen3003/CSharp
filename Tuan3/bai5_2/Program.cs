using System;
using SharedLibs;

namespace Tuan3;

public class Bai5_2
{
    static void Bai52()
    {
        // Nguon du lieu danh sach mon hoc
        var dsMon = Bai4_1.DuLieu.DS_Mon();

        // Cau a: dem tong so mon hoc hien co
        var kqA = dsMon.Count();
        kqA.Dump("-------------Bai 5.2.a) Tong so mon hien co: --------------");

        // Cau b: dem so mon co ten bat dau bang 'Lap trinh'
        var kqB = dsMon.Count(m => m.TenMon.StartsWith("Lập trình"));
        kqB.Dump("-------------Bai 5.2.b) So mon co ten bat dau bang 'Lap trinh': --------------");

        // Cau c: tinh tong so tiet cua he 'KTV'
        var kqC = dsMon.Where(m => m.He == "KTV").Sum(m => (int)m.SoTiet);
        kqC.Dump("-------------Bai 5.2.c) Tong so tiet cua he KTV: --------------");

        // Cau d: thong ke tong so mon cua moi he
        var kqD = dsMon.GroupBy(m => string.IsNullOrEmpty(m.He) ? "Khác" : m.He)
                       .Select(g => new
                       {
                           He = g.Key,
                           TongSoMon = g.Count()
                       });
        kqD.Dump("-------------Bai 5.2.d) Tong so mon cua moi he: --------------");

        // Cau e: nhom theo so tiet va sap xep giam dan
        var kqE = dsMon.GroupBy(m => m.SoTiet)
                       .OrderByDescending(g => g.Key)
                       .Select(g => new
                       {
                           SoTiet = g.Key,
                           TongSoMon = g.Count()
                       });
        kqE.Dump("-------------Bai 5.2.e) Nhom theo So tiet (sap xep giam dan theo So tiet): --------------");

        // Cau f: lay thong tin mon hoc co so tiet cao nhat
        byte maxSoTiet = dsMon.Max(m => m.SoTiet);
        var kqF = dsMon.Where(m => m.SoTiet == maxSoTiet);
        kqF.Dump("-------------Bai 5.2.f) Thong tin mon hoc co so tiet cao nhat: --------------");

        // Cau g: thong ke chi tiet theo he dao tao
        var kqG = dsMon.GroupBy(m => string.IsNullOrEmpty(m.He) ? "Khác" : m.He)
                       .Select(g => new
                       {
                           He = g.Key,
                           TongSoMon = g.Count(),
                           TongSoTiet = g.Sum(m => (int)m.SoTiet),
                           SoTietCaoNhat = g.Max(m => m.SoTiet),
                           SoTietThapNhat = g.Min(m => m.SoTiet)
                       });
        kqG.Dump("-------------Bai 5.2.g) Thong ke theo He: --------------");

        // Cau h: liet ke danh sach mon hoc theo tung he
        var kqH = dsMon.GroupBy(m => string.IsNullOrEmpty(m.He) ? "Khác" : m.He)
                       .Select(g => new
                       {
                           He = g.Key,
                           CacMonHoc = string.Join(", ", g.Select(m => m.TenMon))
                       });
        kqH.Dump("-------------Bai 5.2.h) Liet ke cac mon hoc phan nhom theo He: --------------");

        // Cau i: liet ke mon hoc theo so tiet (tang dan)
        var kqI = dsMon.GroupBy(m => m.SoTiet)
                       .OrderBy(g => g.Key)
                       .Select(g => new
                       {
                           SoTiet = g.Key,
                           CacMonHoc = string.Join(", ", g.Select(m => m.TenMon))
                       });
        kqI.Dump("-------------Bai 5.2.i) Liet ke cac mon hoc phan nhom theo So tiet (tang dan): --------------");

        // Cau j: he KTV phan nhom theo hoc phan (sap xep theo ma mon)
        var kqJ = dsMon.Where(m => m.He == "KTV")
                       .GroupBy(m => m.MaMon.Split('_')[0])
                       .OrderBy(g => g.Key)
                       .Select(g => new
                       {
                           HocPhan = g.Key,
                           CacMonHoc = string.Join(", ", g.OrderBy(m => m.MaMon).Select(m => $"{m.MaMon}: {m.TenMon}"))
                       });
        kqJ.Dump("-------------Bai 5.2.j) He KTV phan nhom theo hoc phan (sap xep theo Ma mon): --------------");

        // Cau k: phan nhom theo he co so tiet > 40
        var kqK = dsMon.Where(m => m.SoTiet > 40)
                       .GroupBy(m => string.IsNullOrEmpty(m.He) ? "Khác" : m.He)
                       .Select(g => new
                       {
                           He = g.Key,
                           CacMonHoc = string.Join(", ", g.OrderBy(m => m.MaMon).Select(m => $"{m.MaMon}: {m.TenMon} ({m.SoTiet} tiết)"))
                       });
        kqK.Dump("-------------Bai 5.2.k) Phan nhom theo He (So tiet > 40, sap xep theo Ma mon): --------------");
    }

    public static void Main(string[] args)
    {
        // Goi ham thuc thi bai 5.2
        Bai52();
    }
}