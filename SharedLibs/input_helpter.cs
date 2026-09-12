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
                Console.Write($"Gia tri khong hop le (phai la so nguyen >= 0). Nhap lai {variableName}: ");
            }

            return value;
        }

        public static double InputDouble(string variableName)
        {
            double value;
            Console.Write($"Nhap so thuc {variableName}: ");

            while (!double.TryParse(Console.ReadLine(), out value))
            {
                Console.Write($"Gia tri khong hop le. Nhap lai {variableName}: ");
            }

            return value;
        }

        public static string InputString(string variableName)
        {
            Console.Write($"Nhap chuoi {variableName}: ");
            string? input = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(input))
            {
                Console.Write($"Chuoi khong duoc de trong. Nhap lai chuoi {variableName}: ");
                input = Console.ReadLine();
            }
            return input;
        }

        public static int InputInt(string variableName)
        {
            int value;
            Console.Write($"Nhap so nguyen {variableName}: ");

            while (!int.TryParse(Console.ReadLine(), out value))
            {
                Console.Write($"Gia tri khong hop le (phai la so nguyen). Nhap lai {variableName}: ");
            }

            return value;
        }
    }
}