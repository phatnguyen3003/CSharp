using System;
using SharedLibs;


namespace Tuan1
{
    public class Bai17
    {

        public static int[] RandomArray(int n, int m)
        {
            int[] NumsArray = new int[n * m];
            for (int i = 0; i < (n * m); i++)
            {
                NumsArray[i] = Random.Shared.Next(10, 100);
            }
            return NumsArray;
        }

        public static void PrintArray(int[] NumsArray)
        {
            Console.WriteLine("Cac thanh phan cua mang la: ");
            for (int i = 0; i < NumsArray.Length; i++)
            {
                Console.Write($"{NumsArray[i]} | ");
            }
            Console.WriteLine();
        }

        public static void SplitOddEven(int[] NumsArray, int n, int m, out int[] OddArray, out int[] EvenArray)
        {
            // Separate even and odd numbers
            OddArray = new int[0];
            EvenArray = new int[0];
            for (int i = 0; i < (n * m); i++)
            {
                if (NumsArray[i] % 2 == 0)
                {
                    Array.Resize(ref EvenArray, EvenArray.Length + 1);
                    EvenArray[EvenArray.Length - 1] = NumsArray[i];
                }
                else
                {
                    Array.Resize(ref OddArray, OddArray.Length + 1);
                    OddArray[OddArray.Length - 1] = NumsArray[i];
                }
            }
        }
        public static void Run()
        {

            int n = InputHelper.InputNatural("n");
            int m = InputHelper.InputNatural("m");

            int[] NumsArray = RandomArray(n, m);

            PrintArray(NumsArray);

            SplitOddEven(NumsArray, n, m, out int[] OddArray, out int[] EvenArray);

            Console.WriteLine("\nMang so Le: ");
            PrintArray(OddArray);
            Console.WriteLine("\nMang so Chan: ");
            PrintArray(EvenArray);

        }
    }
}