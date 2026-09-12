using SharedLibs;

namespace Tuan1
{
    public class Bai12
    {
        public static int WordsCount(string s)
        {
            // Count words in a string
            if (string.IsNullOrWhiteSpace(s))
            {
                return 0;
            }
            string[] words = s.Split(new char[] { ' ', '\n', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            return words.Length;
        }

        public static void Run()
        {
            string text = InputHelper.InputString("doan van ban/chuoi");

            // Convert string to lowercase
            Console.WriteLine($"\nChuoi ky tu thuong : {text.ToLower()}");
            Console.WriteLine($"Chuoi ky tu hoa    : {text.ToUpper()}");
            Console.WriteLine($"So tu trong chuoi   : {WordsCount(text)}");
        }
    }
}