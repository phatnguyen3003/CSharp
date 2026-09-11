using System.ComponentModel.DataAnnotations;
using System.IO;

namespace Tuan1
{
    public class Bai6
    {
        static int[] mynums = new int[3];
        static int max = int.MinValue;
        public static int Find()
        {

            Console.WriteLine("Nhap 3 so nguyen");
            for (int i = 0; i < 3; i++)
            {
                try
                {
                    mynums[i] = int.Parse(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.Write(e);
                }
                if (mynums[i] > max)
                {
                    max = mynums[i];
                }
            }

            return max;


        }

        public static void Run()
        {
            Find();

            Console.Write($"So lon nhat trong3 so: {mynums[0]}, {mynums[1]}, {mynums[2]} la: {max}");
        }
    }
}