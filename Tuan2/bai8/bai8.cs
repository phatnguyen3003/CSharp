using System;
using SharedLibs;
using System.Collections.Generic;

namespace Tuan2
{
    public class DaySo
    {
        private int[] a;

        public DaySo()//constructor rong
        {
            a = new int[0];
        }

        public DaySo(int n)//constructor voi kich thuoc n
        {
            if (n < 0)
            {
                n = 0;
            }
            a = new int[n];
        }
        public DaySo(int[] arr) // tao tu 1 mang so nguyen
        {
            if (arr != null)
            {
                a = new int[arr.Length];
                Array.Copy(arr, a, arr.Length);
            }
            else
            {
                a = new int[0];
            }
        }

        public DaySo(DaySo daysokhac) // copy constructor
        {
            if (daysokhac != null && daysokhac.a != null)
            {
                a = new int[daysokhac.a.Length];
                Array.Copy(daysokhac.a, a, daysokhac.a.Length);
            }
            else
            {
                a = new int[0];
            }
        }

        public int Length//lay chieu dai day so
        {
            get
            {
                return a.Length;
            }
        }


        public int this[int i]//indexer
        {
            get
            {
                if (i < 0 || i >= a.Length)
                {
                    throw new IndexOutOfRangeException("chi so i vuot qua pham vi day so.");
                }
                return a[i];
            }
            set
            {
                if (i < 0 || i >= a.Length)
                {
                    throw new IndexOutOfRangeException("chi so i vuot qua pham vi day so.");
                }
                a[i] = value;
            }
        }


        public void Input()
        {
            int n = SharedLibs.InputHelper.InputNatural("So luong phan tu n");
            a = new int[n];

            for (int i = 0; i < n; i++)
            {
                a[i] = SharedLibs.InputHelper.InputInt($"Phan tu a[{i}]");
            }
        }

        public void Output()
        {
            if (a.Length == 0)
            {
                Console.WriteLine("Day so rong.");
                return;
            }

            Console.WriteLine("Day so: " + string.Join(" ", a));
        }


        public DaySo TimSoChan()
        {
            List<int> dsChan = new List<int>();

            foreach (int item in a)
            {
                if (item % 2 == 0)
                {
                    dsChan.Add(item);
                }
            }

            return new DaySo(dsChan.ToArray());//tra ve day so chua cac so chan tim duoc
        }
    }

    class Program
    {
        static void Main(string[] args)
        {


            // kiem tra nhap xuat
            DaySo ds1 = new DaySo();
            Console.WriteLine("\nNhap day so:");
            ds1.Input();

            Console.WriteLine("\nday so vua nhap:");
            ds1.Output();

            // indexer
            if (ds1.Length > 0)
            {
                Console.WriteLine($"\nphan tu dau tien (ds1[0]): {ds1[0]}");

                // thay doi gia tri bang indeexer
                ds1[0] = 999;
                Console.WriteLine("day so sau khi sua:");
                ds1.Output();
            }

            // tim cac so chan
            Console.WriteLine("\ndanh sach cac so chan:");
            DaySo dsChan = ds1.TimSoChan();
            dsChan.Output();

            // kiem tra copy constructor
            Console.WriteLine("\ntao ban sao day so co san:");
            DaySo dsCopy = new DaySo(ds1);
            dsCopy.Output();
        }
    }
}