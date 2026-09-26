using System;
using System.Collections.Generic;
using SharedLibs;


namespace Tuan2
{
    public class DayPS
    {
        private PhanSo[] dayphanso;

        public PhanSo[] Dayphanso
        {
            get
            {
                return dayphanso;
            }
        }

        public DayPS()//constructor
        {
            dayphanso = new PhanSo[1];
            dayphanso[0] = new PhanSo(0);
        }

        public DayPS(int n)// constructor voi tham so n
        {
            dayphanso = new PhanSo[n];

            for (int i = 0; i < n; i++)
            {
                PhanSo temp = new PhanSo();
                temp.Tuso = SharedLibs.InputHelper.InputInt($"tu so cua phan so thu {i + 1}");
                temp.Mauso = SharedLibs.InputHelper.InputNatural($"mau so cua phan so thu {i + 1}", largerthan0: true);
                dayphanso[i] = temp;
            }
        }

        public DayPS(DayPS dayKhac)// Copy Constructor
        {
            if (dayKhac != null && dayKhac.dayphanso != null)
            {
                int length = dayKhac.dayphanso.Length;
                dayphanso = new PhanSo[length];
                for (int i = 0; i < length; i++)
                {
                    dayphanso[i] = new PhanSo(dayKhac.dayphanso[i]);
                }
            }
            else
            {
                dayphanso = new PhanSo[0];
            }
        }

        public void Input()
        {
            int n = SharedLibs.InputHelper.InputNatural("so luong phan so n");
            dayphanso = new PhanSo[n];

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"\n--- Nhap phan so thu {i + 1} ---");
                PhanSo ps = new PhanSo();
                ps.Tuso = SharedLibs.InputHelper.InputInt("tu so");
                ps.Mauso = SharedLibs.InputHelper.InputNatural("mau so", true);

                dayphanso[i] = ps;
            }
        }

        public override string ToString()
        {
            if (dayphanso == null || dayphanso.Length == 0)
                return "Day rong";

            return string.Join("; ", (object[])dayphanso);
        }

        public void Output()
        {
            Console.WriteLine($"Day phan so: [ {this} ]");
        }

        public PhanSo TinhTong()
        {
            PhanSo tong = new PhanSo(0, 1); // khoi tao tong = 0/1

            if (dayphanso == null) return tong;

            foreach (PhanSo ps in dayphanso)
            {
                tong = tong + ps; //dung lai toan tu cong cua lop tham so, khong can rut gon vi khi tinh da tu dong goi roi

            }

            return tong;
        }
    }
}