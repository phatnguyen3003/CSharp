using System.IO;
using System.Linq.Expressions;

namespace Tuan1
{
    public class Bai4
    {
        public static void Run()
        {
            int x = 0;
            int y = 0;
            Console.Write("Nhap so nguyen x: ");
            try
            {
                x = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.Write($"{x} khong phai so nguyen");
                return;
            }

            Console.Write("Nhap so nguyen y: ");
            try
            {
                y = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.Write($"{y} khong phai so nguyen");
                return;
            }

            Console.WriteLine($"ket qua {x} mu {y} la: {Math.Pow(x, y)}");

        }
    }
}