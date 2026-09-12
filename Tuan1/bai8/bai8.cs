using SharedLibs;

namespace Tuan1
{
    public class Bai8
    {
        public static void Swap(ref double x, ref double y)
        {
            double temp = x;
            x = y;
            y = temp;
        }

        public static void Run()
        {
            double x = SharedLibs.InputHelper.InputDouble("x");
            double y = SharedLibs.InputHelper.InputDouble("y");


            Console.WriteLine($"Truoc khi hoan vi: x= {x}, y= {y}");

            Swap(ref x, ref y);

            Console.WriteLine($"sau khi hoan vi: x= {x}, y= {y}");
        }
    }
}