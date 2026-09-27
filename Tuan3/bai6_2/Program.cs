using System;
using SharedLibs;

namespace Tuan3;

public class Bai6_2
{
    static void Bai62()
    {
        // Nguon du lieu danh sach mon hoc va he dao tao
        var dsMon = Bai4_1.DuLieu.DS_Mon();
        var dsHe = Bai6_1.DuLieu_He.DS_He();

        // Cau a: dung Inner Join liet ke Ten he, Ma mon, Ten mon
        var kqA = from h in dsHe
                  join m in dsMon on h.MaHe equals m.He
                  select new
                  {
                      TenHe = h.TenHe,
                      MaMon = m.MaMon,
                      TenMon = m.TenMon
                  };
        kqA.Dump("-------------Bai 6.2.a) Liet ke Bang Inner Join (Ten he, Ma mon, Ten mon): --------------");

        // Cau b: Left Outer Join liet ke ca he chua co mon hoc
        var kqB = from h in dsHe
                  join m in dsMon on h.MaHe equals m.He into gj
                  from subMon in gj.DefaultIfEmpty()
                  select new
                  {
                      TenHe = h.TenHe,
                      MaMon = subMon?.MaMon ?? "(Chưa có)",
                      TenMon = subMon?.TenMon ?? "(Chưa có)"
                  };
        kqB.Dump("-------------Bai 6.2.b) Left Outer Join (Liet ke ca he chua co mon hoc): --------------");

        // Cau c: Full Outer Join liet ke ca he chua co mon va mon chua khai bao he
        var leftJoin = from h in dsHe
                       join m in dsMon on h.MaHe equals m.He into gj
                       from subMon in gj.DefaultIfEmpty()
                       select new
                       {
                           TenHe = h.TenHe,
                           MaMon = subMon?.MaMon ?? "(Chưa có)",
                           TenMon = subMon?.TenMon ?? "(Chưa có)"
                       };

        var rightOnly = from m in dsMon
                        where !dsHe.Any(h => h.MaHe == m.He)
                        select new
                        {
                            TenHe = "(Chưa khai báo)",
                            MaMon = m.MaMon,
                            TenMon = m.TenMon
                        };

        var kqC = leftJoin.Concat(rightOnly);
        kqC.Dump("-------------Bai 6.2.c) Full Outer Join (Cả hệ chưa có môn và môn chưa có hệ): --------------");

        // Cau d: chi liet ke he chua co mon va mon chua khai bao he
        var heChuaCoMon = from h in dsHe
                          where !dsMon.Any(m => m.He == h.MaHe)
                          select new
                          {
                              TenHe = h.TenHe,
                              MaMon = "(Không có)",
                              TenMon = "(Không có)",
                              GhiChu = "Hệ chưa có môn học"
                          };

        var monChuaCoHe = from m in dsMon
                          where !dsHe.Any(h => h.MaHe == m.He)
                          select new
                          {
                              TenHe = "(Chưa khai báo)",
                              MaMon = m.MaMon,
                              TenMon = m.TenMon,
                              GhiChu = "Môn học chưa khai báo hệ"
                          };

        var kqD = heChuaCoMon.Concat(monChuaCoHe);
        kqD.Dump("-------------Bai 6.2.d) Chi liet ke he chua co mon va mon chua khai bao he: --------------");

        // Cau e: lay top 5 mon hoc co so tiet giam dan
        var kqE = (from m in dsMon
                   join h in dsHe on m.He equals h.MaHe into gj
                   from subHe in gj.DefaultIfEmpty()
                   orderby m.SoTiet descending
                   select new
                   {
                       TenHe = subHe?.TenHe ?? "(Chưa khai báo)",
                       MaMon = m.MaMon,
                       TenMon = m.TenMon,
                       SoTiet = m.SoTiet
                   }).Take(5);
        kqE.Dump("-------------Bai 6.2.e) Top 5 mon hoc co so tiet giam dan: --------------");

        // Cau f: tong so mon hoc cua moi he dao tao
        var kqF = from h in dsHe
                  join m in dsMon on h.MaHe equals m.He into gj
                  select new
                  {
                      MaHe = h.MaHe,
                      TenHe = h.TenHe,
                      TongSoMon = gj.Count()
                  };
        kqF.Dump("-------------Bai 6.2.f) Tong so mon hoc cua moi he: --------------");

        // Cau g: so luong loai So tiet khac nhau
        var kqG = dsMon.Select(m => m.SoTiet).Distinct().Count();
        kqG.Dump("-------------Bai 6.2.g) So loai So tiet khac nhau: --------------");

        // Cau h: mon hoc dau tien co ten bat dau bang 'Lap trinh'
        var kqH = dsMon.FirstOrDefault(m => m.TenMon.StartsWith("Lập trình"));
        kqH.Dump("-------------Bai 6.2.h) Mon hoc dau tien co ten bat dau bang 'Lap trinh': --------------");

        // Cau i: liet ke danh sach mon theo tung he va danh so thu tu
        var kqI = from h in dsHe
                  join m in dsMon on h.MaHe equals m.He into gj
                  select new
                  {
                      TenHe = h.TenHe,
                      DanhSachMon = gj.Any()
                          ? "\n" + string.Join("\n", gj.Select((m, index) => $"      STT {index + 1}: [{m.MaMon}] {m.TenMon} ({m.SoTiet} tiết)"))
                          : " (Không có môn học)"
                  };
        kqI.Dump("-------------Bai 6.2.i) Liet ke cac mon theo tung he (co danh STT): --------------");
    }

    public static void Main(string[] args)
    {
        // Goi ham thuc thi bai 6.2
        Bai62();
    }
}