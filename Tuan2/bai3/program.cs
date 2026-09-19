
namespace Tuan2
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0 && args[0] == "test")
            {
                Console.WriteLine("===================================");
                Bai3Tests.TestDefaultConstructor();
                Bai3Tests.TestId();
                Bai3Tests.TestName();
                Bai3Tests.TestYob();
                Bai3Tests.TestYod();
                Bai3Tests.TestIsLivingTrue();
                Bai3Tests.TestIsLivingFalse();
                Bai3Tests.TestCopyConstructor();
                Bai3Tests.TestOutputLiving();
                Bai3Tests.TestOutputDead();
                return;
            }

            // 1. Kiểm thử Default Constructor và Input/Output
            Console.WriteLine("--- NHAP THONG TIN PERSON 1 ---");
            Person p1 = new Person();
            p1.Input();

            Console.WriteLine("\n--- THONG TIN PERSON 1 ---");
            p1.Output();

            // 2. Kiểm thử Copy Constructor
            Console.WriteLine("\n--- SAO CHEP SANG PERSON 2 (COPY CONSTRUCTOR) ---");
            Person p2 = new Person(p1);
            p2.Output();

            // 3. Kiểm thử phương thức IsLiving()
            Console.WriteLine($"\nPerson 1 con song hay khong? -> {p1.IsLiving()}");
        }
    }
}
