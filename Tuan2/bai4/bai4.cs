using System;
using SharedLibs;


namespace Tuan2
{
    public class PhanSo
    {
        // Fields
        private int tuso;
        private int mauso;

        // Properties
        public int Tuso
        {
            get
            {
                return tuso;
            }
            set
            {
                tuso = value;
            }
        }

        public int Mauso
        {
            get
            {
                return mauso;
            }
            set
            {
                if (value == 0)
                    throw new ArgumentException("Mau so khong the bang 0.");
                mauso = value;
            }
        }

        // --- CONSTRUCTORS ---

        // 1. Constructor mac dinh
        public PhanSo()
        {
            tuso = 0;
            mauso = 1;
        }

        // 2. Constructor khoi tao voi so nguyen
        public PhanSo(int tuso)
        {
            this.tuso = tuso;
            this.mauso = 1;
        }

        // 3. Constructor du tu so mau so
        public PhanSo(int tuso, int mauso)
        {
            if (mauso == 0)
                throw new ArgumentException("Mau so khong the bang 0.");
            this.tuso = tuso;
            this.mauso = mauso;
            RutGon();
        }

        // 4. Copy Constructor
        public PhanSo(PhanSo khac)
        {
            if (khac != null)
            {
                this.tuso = khac.mauso;
                this.mauso = khac.mauso;
            }
        }

        // --- ho tro viec rut gon ---
        private static int UCLN(int a, int b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);
            while (b != 0)
            {
                int temp = a % b;
                a = b;
                b = temp;
            }
            return a;
        }

        public void RutGon()
        {
            int ucln = UCLN(tuso, mauso);
            tuso /= ucln;
            mauso /= ucln;

            // chuyen dau am len tu so neu mau so an
            if (mauso < 0)
            {
                tuso = -tuso;
                mauso = -mauso;
            }
        }

        // --- ToString() ---
        public override string ToString()
        {
            if (mauso == 1) return $"{tuso}";
            if (tuso == 0) return "0";
            return $"{tuso}/{mauso}";
        }

        // --- toan tu 1 ngoi ---
        public static PhanSo operator +(PhanSo p)
        {
            return new PhanSo(p.tuso, p.mauso);
        }

        public static PhanSo operator -(PhanSo p)
        {
            return new PhanSo(-p.tuso, p.mauso);
        }

        // --- toan tu 2 ngoi ---
        public static PhanSo operator +(PhanSo p1, PhanSo p2)
        {
            int tu = p1.tuso * p2.mauso + p2.tuso * p1.mauso;
            int mau = p1.mauso * p2.mauso;
            return new PhanSo(tu, mau);
        }

        public static PhanSo operator -(PhanSo p1, PhanSo p2)
        {
            int tu = p1.tuso * p2.mauso - p2.tuso * p1.mauso;
            int mau = p1.mauso * p2.mauso;
            return new PhanSo(tu, mau);
        }

        public static PhanSo operator *(PhanSo p1, PhanSo p2)
        {
            return new PhanSo(p1.tuso * p2.tuso, p1.mauso * p2.mauso);
        }

        public static PhanSo operator /(PhanSo p1, PhanSo p2)
        {
            if (p2.tuso == 0)
                throw new DivideByZeroException("Khong the chia cho phan so co tu so bang 0.");
            return new PhanSo(p1.tuso * p2.mauso, p1.mauso * p2.tuso);
        }

        public static bool operator ==(PhanSo p1, PhanSo p2)
        {
            if (ReferenceEquals(p1, p2))    //2 phan so cung tro den 1 doi tuong (vd x1=(1/2), y= x)
                return true;
            if (p1 is null || p2 is null)   // neu null thi khong so sanh duoc
                return false;
            return p1.tuso * p2.mauso == p2.tuso * p1.mauso; // quy dong cheo
        }

        public static bool operator !=(PhanSo p1, PhanSo p2)
        {
            return !(p1 == p2);
        }

        public static bool operator >(PhanSo p1, PhanSo p2)
        {
            return p1.tuso * p2.mauso > p2.tuso * p1.mauso;
        }

        public static bool operator <(PhanSo p1, PhanSo p2)
        {
            return p1.tuso * p2.mauso < p2.tuso * p1.mauso;
        }

        public static bool operator >=(PhanSo p1, PhanSo p2)
        {
            return p1.tuso * p2.mauso >= p2.tuso * p1.mauso;
        }

        public static bool operator <=(PhanSo p1, PhanSo p2)
        {
            return p1.tuso * p2.mauso <= p2.tuso * p1.mauso;
        }

        public override bool Equals(object obj) // khong ghi de ham nay thi c# se so sanh 2 so theo tham chieu, khong phai gia tri khi dung =
        {
            if (obj is PhanSo other)
                return this == other;
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(tuso, mauso);
        }
    }








    class Program
    {
        static void Main(string[] args)
        {
            int x1 = SharedLibs.InputHelper.InputInt("x1");
            int y1 = SharedLibs.InputHelper.InputInt("y1");
            int x2 = SharedLibs.InputHelper.InputInt("x2");
            int y2 = SharedLibs.InputHelper.InputInt("y2");



            // constructor
            PhanSo p1 = new PhanSo();             // 0
            PhanSo p2 = new PhanSo(x1, y1);
            PhanSo p3 = new PhanSo(x2, y2);
            PhanSo p4 = new PhanSo(p2);



            Console.WriteLine("==========================================");

            Console.WriteLine($"p1 = {p1}");
            Console.WriteLine($"p2 = {p2}");
            Console.WriteLine($"p3 = {p3}");
            Console.WriteLine($"p4 (sao chep p2) = {p4}");

            // chay toan tu 1 ngoi
            Console.WriteLine("\n--- TOAN TU 1 NGOI ---");
            Console.WriteLine($"+p2 = {+p2}");
            Console.WriteLine($"-p2 = {-p2}");

            // chay toan tu 2 ngoi
            Console.WriteLine("\n--- TOAN TU 2 NGOI ---");
            Console.WriteLine($"{p2} + {p3} = {p2 + p3}");
            Console.WriteLine($"{p2} - {p3} = {p2 - p3}");
            Console.WriteLine($"{p2} * {p3} = {p2 * p3}");
            Console.WriteLine($"{p2} / {p3} = {p2 / p3}");

            // chay toan tu so sanh
            Console.WriteLine("\n--- TOAN TU SO SANH ---");
            Console.WriteLine($"{p2} == {p4} : {p2 == p4}");
            Console.WriteLine($"{p2} != {p3} : {p2 != p3}");
            Console.WriteLine($"{p2} > {p3}  : {p2 > p3}");
            Console.WriteLine($"{p2} <= {p3} : {p2 <= p3}");
        }
    }
}