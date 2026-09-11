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

            Console.WriteLine($"ket qua {x} mu {y} la: {Math.Pow(x, y)}");

        }
    }
}