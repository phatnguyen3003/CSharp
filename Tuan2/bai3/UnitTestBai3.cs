using System;

namespace Tuan2
{
    public static class Bai3Tests
    {
        public static void TestDefaultConstructor()
        {
            Person p = new Person();
            Assert(p != null, "Khoi tao default constructor");
        }

        public static void TestId()
        {
            Person p = new Person("P001", "An", 2000, 0);
            Assert(p.Id == "P001", "Luu dung ID");
        }

        public static void TestName()
        {
            Person p = new Person("P001", "An", 2000, 0);
            Assert(p.Name == "An", "Luu dung ten");
        }

        public static void TestYob()
        {
            Person p = new Person("P001", "An", 2000, 0);
            Assert(p.Yob == 2000, "Luu dung nam sinh");
        }

        public static void TestYod()
        {
            Person p = new Person("P001", "An", 2000, 2024);
            Assert(p.Yod == 2024, "Luu dung nam mat");
        }

        public static void TestIsLivingTrue()
        {
            Person p = new Person("P001", "An", 2000, 0);
            Assert(p.IsLiving() == true, "Tra ve true khi con song");
        }

        public static void TestIsLivingFalse()
        {
            Person p = new Person("P001", "An", 2000, 2024);
            Assert(p.IsLiving() == false, "Tra ve false khi da mat");
        }

        public static void TestCopyConstructor()
        {
            Person original = new Person("P001", "An", 2000, 0);
            Person copy = new Person(original);

            Assert(copy.Id == "P001" && copy.Name == "An" && copy.Yob == 2000 && copy.Yod == 0,
                "Copy constructor sao chep dung thong tin");
        }

        public static void TestOutputLiving()
        {
            Person p = new Person("P001", "An", 2000, 0);
            using StringWriter output = new StringWriter();
            TextWriter oldOutput = Console.Out;
            Console.SetOut(output);

            try
            {
                p.Output();
            }
            finally
            {
                Console.SetOut(oldOutput);
            }

            Assert(output.ToString().Contains("Con song"), "Output hien thi trang thai con song");
        }

        public static void TestOutputDead()
        {
            Person p = new Person("P001", "An", 2000, 2024);
            using StringWriter output = new StringWriter();
            TextWriter oldOutput = Console.Out;
            Console.SetOut(output);

            try
            {
                p.Output();
            }
            finally
            {
                Console.SetOut(oldOutput);
            }

            Assert(output.ToString().Contains("Da mat"), "Output hien thi trang thai da mat");
        }

        private static void Assert(bool condition, string testName)
        {
            Console.WriteLine(condition ? $"PASS: {testName}" : $"FAIL: {testName}");
        }
    }

}
