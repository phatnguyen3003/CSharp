using SharedLibs;


namespace Tuan1
{
    public class Bai10
    {
        public static bool IsSymmetrical(string s)
        {
            int left = 0;
            int right = s.Length - 1;

            while (left < right)
            {
                if (char.ToLower(s[left]) != char.ToLower(s[right]))
                {
                    return false;
                }
                left++;
                right--;
            }
            return true;
        }

        public static void Run()
        {
            string s = SharedLibs.InputHelper.InputString("s");
            if (IsSymmetrical(s))
            {
                Console.Write($"Chuoi {s} doi xung");
            }
            else
            {
                Console.Write($"Chuoi {s} khong doi xung");
            }
        }
    }
}