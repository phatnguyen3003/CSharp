using Classlibrary_for_console;


namespace Tuan1
{
    public class Bai9
    {
        public static void FindMinMax(double a, double b, double c, out double MaxVal, out double MinVal)
        {
            MaxVal = Math.Max(a, Math.Max(b, c));
            MinVal = Math.Min(a, Math.Min(b, c));
        }

        public static void Run()
        {
            double a = Classlibrary_for_console.InputHelper.InputDouble("a");
            double b = Classlibrary_for_console.InputHelper.InputDouble("b");
            double c = Classlibrary_for_console.InputHelper.InputDouble("c");

            double MaxVal, MinVal;

            // Find max and min among three
            FindMinMax(a, b, c, out MaxVal, out MinVal);

            Console.WriteLine($"Gia tri lon nhat trong ba so {a}, {b}, {c} la: {MaxVal}");
            Console.WriteLine($"Gia tri nho nhat trong ba so {a}, {b}, {c} la: {MinVal}");
        }
    }
}