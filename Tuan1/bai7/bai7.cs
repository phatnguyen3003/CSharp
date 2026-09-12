using System.IO;

namespace Tuan1
{
    public class Bai7
    {
        public static bool Prime_checking(int n)
        {

            if (n < 2)
            {
                return false;
            }


            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

        public static void Run()
        {
            Console.Write("Nhap n: ");
            try
            {
                int n = int.Parse(Console.ReadLine());
                if (Prime_checking(n))
                {
                    Console.Write($"{n} la so nguyen to");
                }
                else
                {
                    Console.Write($"{n} khong la so nguyen to");
                }
            }
            catch (Exception e)
            {
                Console.Write(e);
            }
        }
    }
}