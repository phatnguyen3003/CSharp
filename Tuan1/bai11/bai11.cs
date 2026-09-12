using SharedLibs;

namespace Tuan1
{
    public class Bai11
    {
        public static string RevertString(string s)
        {
            // Reverse string using array
            char[] stringarray = s.ToCharArray();
            Array.Reverse(stringarray);
            return new string(stringarray);
        }

        public static void Run()
        {
            string text = InputHelper.InputString("chuoi can dao");
            string reversed = RevertString(text);

            Console.WriteLine($"Chuoi sau khi dao: {reversed}");
        }
    }
}