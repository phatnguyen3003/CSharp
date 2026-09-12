using System.IO;


namespace SharedLibs
{
    public static class InputHelper
    {
        public static int InputNatural(string variableName)
        {
            int value;
            Console.Write($"Nhap so tu nhien {variableName}: ");

            while (!int.TryParse(Console.ReadLine(), out value) || value < 0)
            {
                Console.Write($"Gia tri khong hop le (phai la so nguyên >= 0). Nhap lai {variableName}: ");
            }

            return value;
        }

        public static double InputDouble(string variableName)
        {
            double value;
            Console.Write($"Nhap so thuc {variableName}: ");

            while (!double.TryParse(Console.ReadLine(), out value) || value < 0)
            {
                Console.Write($"Gia tri khong hop le (phai la so nguyên >= 0). Nhap lai {variableName}: ");
            }

            return value;
        }
    }
}