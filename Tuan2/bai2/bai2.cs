using SharedLibs;

namespace Tuan2
{
    public class Point
    {
        private double x, y; // Field

        public double X //property
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
            }
        }
        public double Y //property
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
            }
        }

        public Point()
        {
            this.x = 0;
            this.y = 0;
        }

        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public void Input()
        {
            x = SharedLibs.InputHelper.InputDouble("X");
            y = SharedLibs.InputHelper.InputDouble("Y");
        }

        public override string ToString()
        {
            return $"({x},{y})";
        }

        public void Output()
        {
            Console.WriteLine($"Toa do cua diem la {this}");
        }

        public static Point operator +(Point a, Point b) //Phép toán: +
        {
            return new Point(a.x + b.x, a.y + b.y);
        }

        public static Point operator -(Point a, Point b) //Phép toán: -
        {
            return new Point(a.x - b.x, a.y - b.y);
        }

        public static Point operator -(Point a) //Phép toán: lấy âm (-)
        {
            return new Point(-a.x, -a.y);
        }


        public double DistanceTo(Point otherpoint)
        {
            return Math.Sqrt(Math.Pow(this.x - otherpoint.x, 2) + Math.Pow(this.y - otherpoint.y, 2)); //sqrt((x1-x2)^2 + (y1-y2)^2)
        }

        public static double Distance(Point p1, Point p2)
        {
            return Math.Sqrt(Math.Pow(p1.x - p2.x, 2) + Math.Pow(p1.y - p2.y, 2)); //sqrt((x1-x2)^2 + (y1-y2)^2)
        }

        public Point MidpointWith(Point other)
        {
            return new Point((this.x + other.x) / 2, (this.y + other.y) / 2); // (x,y) mid = ((x1+x2)/2, (y1+y2)/2)
        }

        public static Point Midpoint(Point p1, Point p2)
        {
            return new Point((p1.x + p2.x) / 2, (p1.y + p2.y) / 2); // (x,y) mid = ((x1+x2)/2, (y1+y2)/2)
        }



    }


    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0 && args[0] == "test")
            {
                Console.WriteLine("===================================");
                Bai2Tests.TestTaoDiem();
                Bai2Tests.TestToaDoX();
                Bai2Tests.TestToaDoY();
                Bai2Tests.TestCongDiem();
                Bai2Tests.TestTruDiem();
                Bai2Tests.TestAmDiem();
                Bai2Tests.TestDistanceTo();
                Bai2Tests.TestDistanceStatic();
                Bai2Tests.TestMidpointWith();
                Bai2Tests.TestMidpointStatic();
                Bai2Tests.TestOutput();
                return;
            }

            Point A = new Point(3, 4);
            Point B = new Point(1, 2);

            Console.WriteLine($"Diem A: {A}");
            Console.WriteLine($"Diem B: {B}");

            Point sum = A + B;       // (3+1),(4+2) = (4, 6)
            Point diff = A - B;      // (3-1),(4-2) = (2, 2)
            Point negativeA = -A;         //-(3,4) = (-3, -4)

            Console.WriteLine($"\n--- PHEP TOAN ---");
            Console.WriteLine($"A + B = {sum}");
            Console.WriteLine($"A - B = {diff}");
            Console.WriteLine($"-A = {negativeA}");

            // --- KIỂM THỬ KHOẢNG CÁCH ---
            Console.WriteLine($"\n--- KHOANG CACH ---");
            Console.WriteLine($"Member Method A.DistanceTo(B)( thanh vien): {A.DistanceTo(B):F2}");
            Console.WriteLine($"Static Method Point.Distance(A, B)( tinh): {Point.Distance(A, B):F2}");

            // --- KIỂM THỬ TRUNG ĐIỂM ---
            Console.WriteLine($"\n--- TRUNG DIEM ---");
            Console.WriteLine($"Member Method A.MidpointWith(B)( thanh vien): {A.MidpointWith(B)}");
            Console.WriteLine($"Static Method Point.Midpoint(A, B)( tinh): {Point.Midpoint(A, B)}");
        }
    }

}