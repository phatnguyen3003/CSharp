using System;
using System.Collections.Generic;
using SharedLibs;

using Tuan1;

namespace Tuan2
{
    public class MangHaiChieu
    {
        private DaySo[] rows; //tai su dung lop day so o bai 8
        private int n; // so dong
        private int m; // so cot


        // 1. Default constructor
        public MangHaiChieu()
        {
            n = 0;
            m = 0;
            rows = new DaySo[0];
        }

        // 2. Constructor voi kich thuoc n x m
        public MangHaiChieu(int n, int m)
        {
            this.n = n < 0 ? 0 : n;
            this.m = m < 0 ? 0 : m;

            rows = new DaySo[this.n];
            for (int i = 0; i < this.n; i++)
            {
                rows[i] = new DaySo(this.m);//tai su dung constructor cua dayso
            }
        }

        // 3. Copy constructor
        public MangHaiChieu(MangHaiChieu other)
        {
            if (other != null && other.rows != null)
            {
                this.n = other.n;
                this.m = other.m;
                this.rows = new DaySo[this.n];

                for (int i = 0; i < this.n; i++)
                {
                    // tai su dung constuctor
                    this.rows[i] = new DaySo(other.rows[i]);
                }
            }
            else
            {
                n = 0;
                m = 0;
                rows = new DaySo[0];
            }
        }

        // Properties
        public int SoDong
        {
            get
            {
                return n;
            }
        }
        public int SoCot
        {
            get
            {
                return m;
            }
        }

        //indexer
        public int this[int i, int j]
        {
            get
            {
                if (i < 0 || i >= n)
                    throw new IndexOutOfRangeException("chi so dong i khong hop le.");

                return rows[i][j];
            }
            set
            {
                if (i < 0 || i >= n)
                    throw new IndexOutOfRangeException("chi so dong i khong hop le.");

                rows[i][j] = value;
            }
        }

        public void Input()
        {
            n = SharedLibs.InputHelper.InputNatural("So dong n");
            m = SharedLibs.InputHelper.InputNatural("So cot m");

            rows = new DaySo[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"--- Nhap dong {i + 1} ---");
                rows[i] = new DaySo(m);
                for (int j = 0; j < m; j++)
                {
                    // Nhap tung phan tu qua indexer
                    this[i, j] = SharedLibs.InputHelper.InputInt($"Phan tu [{i}, {j}]");
                }
            }
        }

        public void Output()
        {
            if (n == 0 || m == 0)
            {
                Console.WriteLine("Mang 2 chieu rong.");
                return;
            }

            Console.WriteLine($"Mang 2 chieu ({n}x{m}):");
            for (int i = 0; i < n; i++)
            {
                // tai su dung output cua dayso
                rows[i].Output();
            }
        }

        public DaySo TimSoNguyenTo()
        {
            List<int> dsSNT = new List<int>();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    int val = this[i, j];
                    if (Bai7.Bai7_Prime_checking(val))
                    {
                        dsSNT.Add(val);
                    }
                }
            }

            // Trả về một đối tượng DaySo chứa toàn bộ các số nguyên tố tìm được
            return new DaySo(dsSNT.ToArray());
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            MangHaiChieu mhc = new MangHaiChieu();
            mhc.Input();

            Console.WriteLine("\nMang 2 chieu vua nhap:");
            mhc.Output();

            Console.WriteLine("\nCac so nguyen to trong mang:");
            DaySo dsSNT = mhc.TimSoNguyenTo();
            dsSNT.Output();
        }
    }
}