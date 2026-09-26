using System.IO;
using SharedLibs;
namespace Tuan1
{
    public class Bai5
    {
        public static void Run()
        {
            int choose = 0;
            double x = -9999;
            double y = -9999;
            do
            {
                // Create selection menu
                Console.WriteLine("\n================ MENU ================");
                Console.WriteLine("1. Nhap hai gia tri so thuc cho x, y");
                Console.WriteLine("2. Tinh x^y");
                Console.WriteLine("3. Tinh can bac 2 cua x va y");
                Console.WriteLine("4. Thoat");
                Console.Write("Chon chuc nang: ");

                choose = InputHelper.InputNatural("cho lua chon cua ban");
                switch (choose)
                {
                    case 1:
                        x = InputHelper.InputDouble("x");
                        y = InputHelper.InputDouble("y");
                        break;
                    case 2:
                        // Calculate power when data is available
                        if (!(x == -9999 || y == -9999))
                        {
                            Console.WriteLine($"mu cua {x} va {y} la: {Math.Pow(x, y)}");
                        }
                        else
                        {
                            Console.WriteLine("Vui long chon chuc nang 1 de nhap x, y truoc");
                        }
                        break;
                    case 3:
                        if (!(x == -9999 || y == -9999))
                        {
                            if (x >= 0)
                                Console.WriteLine($"can bac 2 cua {x} la: {Math.Sqrt(x)}");
                            else
                                Console.WriteLine($"x = {x} < 0, khong tinh duoc can bac 2");

                            if (y >= 0)
                                Console.WriteLine($"can bac 2 cua {y} la: {Math.Sqrt(y)}");
                            else
                                Console.WriteLine($"y = {y} < 0, khong tinh duoc can bac 2");
                        }
                        else
                        {
                            Console.WriteLine("Vui long chon chuc nang 1 de nhap x, y truoc");
                        }
                        break;
                    case 4:
                        break;
                }
            }
            while (choose != 4);
        }
    }
}