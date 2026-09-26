using System;

namespace Tuan2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // tao da thuc 
            DaThuc p = new DaThuc();
            p.Input();

            // Xuất đa thức
            Console.WriteLine("\n===================================");
            p.Output();

            // dung indexer de kiem tra
            if (p.Bac >= 1)
            {
                Console.WriteLine($"Don thuc bac 1 hien tai: {p[1]}");
            }

            // tinh da thuc khi biet x
            double x = SharedLibs.InputHelper.InputDouble("x");
            double result = p.Calculate(x);
            Console.WriteLine($"Gia tri P({x}) = {result}");
        }
    }
}