using System;
using SharedLibs;


namespace Tuan2
{


    public class HocSinh
    {
        public string HoTen { get; set; }
        public int NamSinh { get; set; }

        public HocSinh(string HoTen, int NamSinh)
        {
            this.HoTen = HoTen;
            this.NamSinh = NamSinh;
        }

        public void Tinhtuoi()
        {
            Console.Write($"Tuoi cua sinh vien nay la: {DateTime.Now.Year - this.NamSinh}");
        }



    }
    public class Program
    {
        public static void Main(string[] args)
        {

            if (args.Length > 0 && args[0] == "test")
            {
                Console.WriteLine("===================================");
                Bai1Tests.TestTaoHocSinh();
                Bai1Tests.TestHoTen();
                Bai1Tests.TestNamSinh();
                Bai1Tests.TestTinhTuoi();
                Bai1Tests.TestThongBaoTinhTuoi();

                return;
            }
            else
            {
                string HoTen = SharedLibs.InputHelper.InputString("Ho Ten");
                int NamSinh = SharedLibs.InputHelper.InputNatural("nam sinh");
                while (NamSinh <= 0 || NamSinh > DateTime.Now.Year)
                {
                    NamSinh = SharedLibs.InputHelper.InputNatural("nam sinh");
                }

                HocSinh hocsinh = new HocSinh(HoTen, NamSinh);
                hocsinh.Tinhtuoi();
            }
        }

    }
}