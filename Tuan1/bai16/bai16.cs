using SharedLibs;

namespace Tuan1
{
    public class Bai16
    {
        public static void Run()
        {
            int n = InputHelper.InputNatural("so luong nguoi n");
            string[] namesArray = new string[n];

            Console.WriteLine("\n--- Nhap danh sach ho ten ---");
            for (int i = 0; i < n; i++)
            {
                namesArray[i] = InputHelper.InputString($"ho ten nguoi thu {i + 1}").Trim();
            }

            // Sort the name list
            Array.Sort(namesArray);

            Console.WriteLine("\n--- Danh sach ho ten sau khi sap xep tang dan (A-Z) ---");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"{i + 1}. {namesArray[i]}");
            }
        }
    }
}