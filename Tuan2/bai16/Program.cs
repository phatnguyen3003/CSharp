using SharedLibs;

namespace Tuan2
{


    public class PhuongTrinhBac2 // tao lop chuong trinh bac 2
    {
        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }

        // su kien tra ket qua ra ngoai khi tinh xong
        public event Action<string>? TinhToanXong;

        public PhuongTrinhBac2(double a, double b, double c)
        {
            A = a;
            B = b;
            C = c;
        }

        public virtual void Giai()
        {
            if (A == 0)
            {
                if (B == 0)
                {
                    TinhToanXong?.Invoke(C == 0 ? "phuong trinh vo so nghiem." : "phuong trinh vo nghiem.");
                }
                else
                {
                    TinhToanXong?.Invoke($"phuong trinh bac 1 co 1 nghiem x = {-C / B}");
                }
                return;
            }

            double delta = B * B - 4 * A * C;
            if (delta < 0)
            {
                TinhToanXong?.Invoke("Phuong trinh vo nghiem thuc.");
            }
            else if (delta == 0)
            {
                double x = -B / (2 * A);
                TinhToanXong?.Invoke($"Phuong trinh co nghiem kep x1 = x2 = {x}");
            }
            else
            {
                double x1 = (-B + Math.Sqrt(delta)) / (2 * A);
                double x2 = (-B - Math.Sqrt(delta)) / (2 * A);
                TinhToanXong?.Invoke($"Phuong trinh co 2 nghiem phan biet: x1 = {x1}, x2 = {x2}");
            }
        }
    }


    // lop menu ke thua tu lop consolemenu
    public class PhuongTrinhMenu : ConsoleMenu
    {
        public PhuongTrinhMenu() : base("Menu")
        {
            // Đăng ký các chức năng cụ thể vào Menu
            AddOption("Nhap he so(a,b,c) de giai phuong trinh bac 2: ax^2 + bx + c = 0", ChucNangGiaiPTB2);
            AddOption("Xem huong dan su dung", ChucNangHuongDan);
        }

        private void ChucNangGiaiPTB2()
        {
            double a = SharedLibs.InputHelper.InputDouble("a");
            double b = SharedLibs.InputHelper.InputDouble("b");
            double c = SharedLibs.InputHelper.InputDouble("c");

            PhuongTrinhBac2 pt = new PhuongTrinhBac2(a, b, c);

            // dang ky ket qua de lang nghe ket qua tra ve tu lop PhuongTrinhBac2
            pt.TinhToanXong += (ketQua) =>
            {
                Console.WriteLine($"[ket qua]: {ketQua}");
            };

            pt.Giai();
        }

        private void ChucNangHuongDan()
        {
            Console.WriteLine("-> Nhap 3 so a, b, c de chuong trinh tu tinh delta va ra nghiem");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // khoi tao menu da duoc ke thua
            PhuongTrinhMenu menu = new PhuongTrinhMenu();


            // chay menu
            menu.Run();
        }
    }
}