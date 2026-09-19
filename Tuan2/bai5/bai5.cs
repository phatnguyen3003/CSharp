using System;

using SharedLibs;

namespace Tuan2
{
    public class DonThuc
    {
        // 1. Fields
        private double heso;
        private int somu;

        // 2. Properties
        public double Heso
        {
            get
            {
                return heso;
            }
            set
            {
                heso = value;
            }
        }

        public int Somu
        {
            get
            {
                return somu;
            }
            set
            {
                somu = value;
            }
        }

        // 3. Constructors
        // Default Constructor (0x^0 = 0)
        public DonThuc()
        {
            heso = 0;
            somu = 0;
        }

        // Constructor 
        public DonThuc(double heso, int somu)
        {
            this.heso = heso;
            this.somu = somu;
        }

        // Copy Constructor
        public DonThuc(DonThuc donphuckhac)
        {
            if (donphuckhac != null)
            {
                this.heso = donphuckhac.heso;
                this.somu = donphuckhac.somu;
            }
        }

        public override string ToString()
        {
            return $"{this.heso}x^{somu}";
        }

        public void Input()
        {
            this.heso = SharedLibs.InputHelper.InputDouble("he so");
            this.Somu = SharedLibs.InputHelper.InputNatural("so mu");
        }

        public void Output()
        {
            Console.WriteLine($"Don thuc la: {this}");
        }


        public double Calculating(double x)
        {
            return heso * Math.Pow(x, somu);
        }

        public DonThuc derivative()
        {
            if (somu == 0)
                return new DonThuc(0, 0);   // xu ly doi voi truong hop so mu =0, yeu cau n la so nguyen khong am

            return new DonThuc(heso * somu, somu - 1);
        }
    }







    public class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length > 0 && args[0] == "test")
            {
                Console.WriteLine("===================================");
                UnitTestBai5.TestDefaultConstructor();
                UnitTestBai5.TestConstructor();
                UnitTestBai5.TestProperties();
                UnitTestBai5.TestCopyConstructor();
                UnitTestBai5.TestToString();
                UnitTestBai5.TestCalculating();
                UnitTestBai5.TestDerivative();
                UnitTestBai5.TestDerivativeOfConstant();
                UnitTestBai5.TestOutput();
                return;
            }

            DonThuc p = new DonThuc();
            p.Input();

            double x = SharedLibs.InputHelper.InputDouble("x");
            DonThuc daoHam = p.derivative();

            Console.WriteLine("===================================");
            p.Output();
            Console.WriteLine($"Gia tri P({x}) = {p.Calculating(x)}");
            Console.WriteLine($"Dao ham: {daoHam}");
        }
    }
}