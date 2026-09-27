using System;
using SharedLibs;

namespace Tuan3;

public class Bai2_1
{
    static void Bai21()
    {
        // Mang so nguyen ban dau
        int[] mangSo = { 50, 42, 16, 3, 9, 8, 12, 7, 24, 0 };

        mangSo.Dump("-------------Bai 2.1) mang ban dau: --------------");

        // Cau a: liet ke cac so chia het cho ca 4 va 3
        var kq = from n in mangSo
                 where n % 4 == 0 && n % 3 == 0
                 select n;
        kq.Dump("-------------Bai 2.1.a) mang ket qua sau truy van chia het cho 4 va 3: --------------");

        // Cau b: liet ke cac so nho hon hoac bang 3
        kq = from n in mangSo
             where n <= 3
             select n;
        kq.Dump("-------------Bai 2.1.b) mang ket qua sau khi truy van so nho hon hoac bang 3: --------------");

        // Cau c: so chan chia doi, so le giu nguyen gia tri
        kq = from n in mangSo
             select n % 2 == 0 ? n / 2 : n;

        kq.Dump("-------------Bai 2.1.c) mang ket qua sau khi truy van so chan chia doi so le giu nguyen: --------------");
    }

    public static void Main(string[] args)
    {
        // Goi ham thuc thi bai 2.1
        Bai21();
    }
}
