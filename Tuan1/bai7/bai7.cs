using System.IO;
using SharedLibs;

namespace Tuan1
{
    public class Bai7
    {
        public static bool Bai7_Prime_checking(int n)
        {

            // Check prime number
            if (n < 2)  // Reject values below 2
            {
                return false;
            }


            for (int i = 2; i <= Math.Sqrt(n); i++) // Check divisibility up to sqrt of n
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
            int n = SharedLibs.InputHelper.InputNatural("n");
            try
            {
                if (Bai7_Prime_checking(n))
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