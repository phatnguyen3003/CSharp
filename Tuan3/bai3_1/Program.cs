using System;
using SharedLibs;

namespace Tuan3;

public class Bai3_1
{
    static void Bai31()
    {
        // Mang so nguyen cho truoc
        int[] mangSo = { 50, 42, 12, 3, 9, 8, 1, 50, 3, 42, 85 };

        // Cau a: dem tong so phan tu
        var kqA_1 = mangSo.Length;
        kqA_1.Dump("-------------Bai 3.1.a) so phan tu cua mang: --------------");

        // Dem so luong phan tu chan
        var kqA_2 = (from n in mangSo
                     where n % 2 == 0
                     select n).Count();
        kqA_2.Dump("-------------Bai 3.1.b) so phan tu chan cua mang: --------------");

        // Dem so luong phan tu le
        var kqA_3 = (from n in mangSo
                     where n % 2 != 0
                     select n).Count();
        kqA_3.Dump("-------------Bai 3.1.c) so phan tu le cua mang: --------------");

        // Cau b: tinh tong cac gia tri trong mang
        var kqB_Tong = mangSo.Sum();
        kqB_Tong.Dump("-------------Bai 3.1.b1) Tong cac gia tri trong mang: --------------");

        // Tim gia tri lon nhat (Max)
        var kqB_Max = mangSo.Max();
        kqB_Max.Dump("-------------Bai 3.1.b2) Gia tri lon nhat: --------------");

        // Tim gia tri nho nhat (Min)
        var kqB_Min = mangSo.Min();
        kqB_Min.Dump("-------------Bai 3.1.b3) Gia tri nho nhat: --------------");

        // Cau c: dem so luong gia tri phan biet khac nhau
        var kqC = mangSo.Distinct().Count();
        kqC.Dump("-------------Bai 3.1.c) So gia tri khac nhau trong mang: --------------");

        // Cau d: phan nhom theo so du khi chia cho 5
        var kqD = from n in mangSo
                  group n by n % 5 into g
                  select new
                  {
                      SoDu = g.Key,
                      CacPhanTu = string.Join(", ", g)
                  };

        kqD.Dump("-------------Bai 3.1.d) Phan nhom theo so du khi chia cho 5: --------------");
    }

    public static void Main(string[] args)
    {
        // Goi ham thuc thi bai 3.1
        Bai31();
    }
}