using System.IO;


namespace SharedLibs
{
    public static class InputHelper
    {
        public static int InputNatural(string variableName)
        {
            // Read a non-negative integer
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
            // Read a floating-point number
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
            // Read a non-empty string
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
            // Read an integer value
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