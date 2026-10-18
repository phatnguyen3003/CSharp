using Classlibrary_for_console;

namespace Tuan1
{
    public class Bai8
    {
        public static void Swap(ref double x, ref double y)
        {
            // Swap values of two variables
            double temp = x;
            x = y;
            y = temp;
        }

        public static void Run()
        {
            double x = Classlibrary_for_console.InputHelper.InputDouble("x");
            double y = Classlibrary_for_console.InputHelper.InputDouble("y");


            Console.WriteLine($"Truoc khi hoan vi: x= {x}, y= {y}");

            Swap(ref x, ref y);

            Console.WriteLine($"sau khi hoan vi: x= {x}, y= {y}");
        }
    }
}