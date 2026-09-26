using System;

namespace Tuan2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            DayPS dps = new DayPS();

            // Nhập dãy phân số từ bàn phím
            dps.Input();

            // Xuất dãy phân số
            Console.WriteLine("\n===================================");
            dps.Output();

            // Tính và xuất tổng
            PhanSo tong = dps.TinhTong();
            Console.WriteLine($"Tong {dps.Dayphanso.Length} phan so = {tong}");
        }
    }
}