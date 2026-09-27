using System;
using SharedLibs;

namespace Tuan3;

public class Bai2_2
{
    static void Bai22()
    {
        // Mang chuoi ban dau
        string[] mangChuoi = { "đầu", "lòng", "hai", "ả", "tố", "nga", "Thúy", "Kiều", "là", "chị", "em", "là", "Thúy", "Vân" };

        // Cau a: lay tu co 4 ky tu va sap xep tang dan theo ky tu dau
        var kqA = mangChuoi.Where(w => w.Length == 4).OrderBy(w => w[0]);
        kqA.Dump("-------------Bai 2.2.a) mang ket qua sau khi truy van liet ke phan tu co 4 ky tu va xap xep tang dan theo ky tu dau tien.: --------------");

        // Cau b: bien doi chuoi sang dang <chu thuong> - <CHU HOA>
        var kqB = from w in mangChuoi
                  select $"{w.ToLower()} - {w.ToUpper()}";
        kqB.Dump("-------------Bai 2.2.b) mang ket qua sau khi truy van de chuyen format thanh toLower - toUpper: --------------");

        // Cau c: tim cac tu co chua ky tu 'u'
        var kqC = from w in mangChuoi
                  where w.ToLower().Contains("u")
                  select w;
        kqC.Dump("-------------Bai 2.2.c) mang ket qua sau khi truy van tim tu chua u: --------------");

        // Cau d: lay cac tu bat dau bang chu in hoa
        var kqD = from w in mangChuoi
                  where !string.IsNullOrEmpty(w) && char.IsUpper(w[0])
                  select w;
        kqD.Dump("-------------Bai 2.2.d) mang ket qua sau khi truy van tim tu co chu cai dau in hoa: --------------");
    }

    public static void Main(string[] args)
    {
        // Goi ham thuc thi bai 2.2
        Bai22();
    }
}