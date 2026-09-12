using System.IO;

namespace Tuan1
{
    public class Bai3
    {
        public static void Run()
        {
            Console.Write("Nhap so nguyen x: ");
            int x = int.Parse(Console.ReadLine());
            Console.Write("Nhap so nguyen y: ");
            int y = int.Parse(Console.ReadLine());
            // Calculate power using Math.Pow
            Console.WriteLine($"ket qua {x} mu {y} la: {Bai3_Power(x, y)}");

        }
        public static double Bai3_Power(int x, int y)
        {

            return Math.Pow(x, y);
        }
    }
}