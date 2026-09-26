using System;
using SharedLibs;

using System.Collections.Generic;




namespace Tuan2
{
    public class DaThuc
    {
        private DonThuc[] DsDonThuc;    //mang don thuc
        private int bac;

        public int Bac  //get
        {
            get
            {
                return bac;
            }
        }


        public DaThuc()
        {
            bac = 0;
            DsDonThuc = new DonThuc[1];
            DsDonThuc[0] = new DonThuc(0, 0);//tao danh sach don thuc bac 0,0
        }

        public DaThuc(int n)
        {
            bac = Math.Max(0, n); // han che viec n < 0 => khong tao duoc da thuc

            DsDonThuc = new DonThuc[bac + 1];

            for (int i = 0; i <= bac; i++)
            {
                DsDonThuc[i] = new DonThuc(0, i);   // tao cac don thuc bac n voi he so 0 cho da thuc
            }
        }

        public DaThuc(DonThuc[] ds) //constructor co mang la tham so
        {
            if (ds == null || ds.Length == 0)
            {
                bac = 0;
                DsDonThuc = new DonThuc[] {
                    new DonThuc(0, 0)

                    };
            }
            else
            {
                bac = ds.Length - 1;
                DsDonThuc = new DonThuc[ds.Length];
                for (int i = 0; i < ds.Length; i++)
                {
                    DsDonThuc[i] = new DonThuc(ds[i]);
                }
            }
        }

        public DaThuc(DaThuc dtKhac) //copy constructor
        {
            if (dtKhac != null)
            {
                bac = dtKhac.bac;

                DsDonThuc = new DonThuc[dtKhac.DsDonThuc.Length];

                for (int i = 0; i < DsDonThuc.Length; i++)
                {
                    DsDonThuc[i] = new DonThuc(dtKhac.DsDonThuc[i]);
                }
            }
            else
            {
                bac = 0;
                DsDonThuc = new DonThuc[] { new DonThuc(0, 0) };
            }
        }


        public DonThuc this[int i]
        {
            get
            {
                if (i >= 0 && i <= bac)
                {
                    return DsDonThuc[i];
                }
                throw new IndexOutOfRangeException($"Chi so {i} vuot qua bac cua da thuc (0 -> {bac}).");
            }
            set
            {
                if (i >= 0 && i <= bac)
                {
                    DsDonThuc[i] = value;
                }
                else
                {
                    throw new IndexOutOfRangeException($"Chi so {i} vuot qua bac cua da thuc (0 -> {bac}).");
                }
            }
        }



        public void Input()
        {
            bac = SharedLibs.InputHelper.InputNatural("bac cua da thuc n");
            DsDonThuc = new DonThuc[bac + 1];

            Console.WriteLine($"--- Nhap he so cho da thuc bac {bac} ---");
            for (int i = 0; i <= bac; i++)
            {
                double heSo = SharedLibs.InputHelper.InputDouble($"he so thu {i + 1} (cho x^{i})");
                DsDonThuc[i] = new DonThuc(heSo, i);
            }
        }

        public override string ToString() // overwrite ham tostring
        {
            List<string> ketqua = new List<string>();

            for (int i = 0; i <= bac; i++)
            {
                double hs = DsDonThuc[i].Heso;
                if (hs == 0 && bac > 0) continue; // bo qua he so 0 tru da thuc hang 0

                string donthuc;
                if (i == 0)
                    donthuc = $"{hs}";  //neu mu 0 thi = he so
                else if (i == 1) donthuc = (hs == 1) ? "x" : (hs == -1) ? "-x" : $"{hs}x"; // xu ly voi truong hop so mu = 1 va he so = 1 hoac -1
                else donthuc = (hs == 1) ? $"x^{i}" : (hs == -1) ? $"-x^{i}" : $"{hs}x^{i}"; // xu ly doi voi so mu >1 va he so = 1 va  -1 de format dung

                ketqua.Add(donthuc);
            }

            if (ketqua.Count == 0) return "0";

            return string.Join(" + ", ketqua).Replace("+ -", "- ");
        }


        public void Output()
        {
            Console.WriteLine($"P(x) = {this}"); // tu dong goi ham tostring
        }

        public double Calculate(double x)
        {
            double sum = 0;
            for (int i = 0; i <= bac; i++)
            {
                sum += DsDonThuc[i].Calculating(x); // su dung lai ham tinh toan cua lop don thuc
            }
            return sum;
        }



    }
}