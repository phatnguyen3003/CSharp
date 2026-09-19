namespace Tuan2
{
    public static class Bai2Tests
    {

        // doi voi so thuc, khi tac dong len so( gan, tinh toan,..) co the bi lech so hang rat nho, nen khi test dung phep so sanh 1e-9 = 0.000000001 de kiem tra gan bang, dung kem them abs de so sanh 
        public static void TestTaoDiem()
        {
            Point p = new Point(3, 4);
            Assert(p != null, "Tao doi tuong Point");
        }

        public static void TestToaDoX()
        {
            Point p = new Point(3, 4);
            Assert(Math.Abs(p.X - 3) < 1e-9, "Luu dung hoanh do X");
        }

        public static void TestToaDoY()
        {
            Point p = new Point(3, 4);
            Assert(Math.Abs(p.Y - 4) < 1e-9, "Luu dung tung do Y");
        }

        public static void TestCongDiem()
        {
            Point a = new Point(3, 4);
            Point b = new Point(1, 2);
            Point result = a + b;

            Assert(Math.Abs(result.X - 4) < 1e-9 && Math.Abs(result.Y - 6) < 1e-9, "Phép cộng hai điểm");
        }

        public static void TestTruDiem()
        {
            Point a = new Point(3, 4);
            Point b = new Point(1, 2);
            Point result = a - b;

            Assert(Math.Abs(result.X - 2) < 1e-9 && Math.Abs(result.Y - 2) < 1e-9, "Phép trừ hai điểm");
        }

        public static void TestAmDiem()
        {
            Point a = new Point(3, 4);
            Point result = -a;

            Assert(Math.Abs(result.X + 3) < 1e-9 && Math.Abs(result.Y + 4) < 1e-9, "Phép đổi dấu điểm");
        }

        public static void TestDistanceTo()
        {
            Point a = new Point(3, 4);
            Point b = new Point(1, 2);
            double result = a.DistanceTo(b);

            Assert(Math.Abs(result - Math.Sqrt(8)) < 1e-9, "DistanceTo giữa hai điểm");
        }

        public static void TestDistanceStatic()
        {
            Point a = new Point(3, 4);
            Point b = new Point(1, 2);
            double result = Point.Distance(a, b);

            Assert(Math.Abs(result - Math.Sqrt(8)) < 1e-9, "Point.Distance giữa hai điểm");
        }

        public static void TestMidpointWith()
        {
            Point a = new Point(3, 4);
            Point b = new Point(1, 2);
            Point result = a.MidpointWith(b);

            Assert(Math.Abs(result.X - 2) < 1e-9 && Math.Abs(result.Y - 3) < 1e-9, "MidpointWith giữa hai điểm");
        }

        public static void TestMidpointStatic()
        {
            Point a = new Point(3, 4);
            Point b = new Point(1, 2);
            Point result = Point.Midpoint(a, b);

            Assert(Math.Abs(result.X - 2) < 1e-9 && Math.Abs(result.Y - 3) < 1e-9, "Point.Midpoint giữa hai điểm");
        }

        public static void TestOutput()
        {
            Point p = new Point(3, 4);
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

            Assert(output.ToString().Contains("Toa do cua diem la (3,4)"), "In đúng thông tin điểm");
        }

        private static void Assert(bool condition, string testName)
        {
            Console.WriteLine(condition ? $"PASS: {testName}" : $"FAIL: {testName}");
        }
    }
}