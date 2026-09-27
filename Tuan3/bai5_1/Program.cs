using System;
using SharedLibs;

namespace Tuan3;

public class Bai5_1
{
    static void Bai51()
    {
        // Nguon du lieu danh sach mon hoc
        var DsMonHoc = Bai4_1.DuLieu.DS_Mon();

        // Cau a: lay cac mon hoc bat dau bang 'Lap trinh'
        var kqA = from m in DsMonHoc
                  where m.TenMon.StartsWith("Lập trình")
                  select m;

        kqA.Dump("-------------Bai 5.1.a) Truy van ten mon hoc bat dau tu 'Lap trinh': --------------");

        // Cau b: mon thuoc he 'CD', sap xep so tiet giam dan va ma mon tang dan
        var kqB = from m in DsMonHoc
                  where m.He == "CD"
                  orderby m.SoTiet descending, m.MaMon ascending
                  select m;

        kqB.Dump("-------------Bai 5.1.b) truy van mon hoc he 'CD' co so tiet giam dan va ma nhon tang dan: --------------");

        // Cau c: cac mon co ten chua tu 'web' (chi lay ten mon va he)
        var kqC = from m in DsMonHoc
                  where m.TenMon.ToLower().Contains("web")
                  select new
                  {
                      TenMon = m.TenMon,
                      He = m.He
                  };

        kqC.Dump("-------------Bai 5.1.c) Cac mon co ten chua tu 'web' (chi lay ten mon va he): --------------");

        // Cau d: cac mon thuoc he 'KTV', sap xep theo ma mon tang dan
        var kqD = from m in DsMonHoc
                  where m.He == "KTV"
                  orderby m.MaMon ascending
                  select m;

        kqD.Dump("-------------Bai 5.1.d) Cac mon thuoc he 'KTV' (sap xep theo ma mon tang dan): --------------");
    }

    public static void Main(string[] args)
    {
        // Goi ham thuc thi bai 5.1
        Bai51();
    }
}