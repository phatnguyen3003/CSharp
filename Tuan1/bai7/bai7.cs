using System.IO;
using SharedLibs;

namespace Tuan1
{
    public class Bai7
    {
        public static bool Prime_checking(int n)
        {

            if (n < 2)  //check for n lower than 2
            {
                return false;
            }


            for (int i = 2; i <= Math.Sqrt(n); i++) //prime number checking logic
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