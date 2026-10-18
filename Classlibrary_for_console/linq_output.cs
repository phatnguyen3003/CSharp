public static class Linq_Output
{
    public static void Dump(this object obj, string tieuDe = "")
    {
        if (!string.IsNullOrEmpty(tieuDe))
            Console.WriteLine("\n" + tieuDe);

        if (obj is System.Collections.IEnumerable danhSach && !(obj is string))
        {
            foreach (var item in danhSach)
                Console.WriteLine(" - " + item);
        }
        else
        {
            Console.WriteLine(" => " + obj);
        }
    }
}