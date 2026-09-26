using System;
using System.Collections.Generic;
using SharedLibs;

namespace Tuan2
{
    // Lop truu tuong chua thong tin chung cua thi sinh
    public abstract class ThiSinh
    {
        public string SBD { get; set; }
        public string HoTen { get; set; }
        public double Bai1 { get; set; }
        public double Bai2 { get; set; }
        public double Bai3 { get; set; }

        // Phuong thuc truu tuong de lop con cai dat
        public abstract double TinhTongDiem();

        // Nhap thong tin dung chung cho moi thi sinh
        public virtual void Nhap()
        {
            SBD = SharedLibs.InputHelper.InputString("SBD");
            HoTen = SharedLibs.InputHelper.InputString("ho ten");
            Bai1 = SharedLibs.InputHelper.InputDouble("diem bai 1");
            Bai2 = SharedLibs.InputHelper.InputDouble("diem bai 2");
            Bai3 = SharedLibs.InputHelper.InputDouble("diem bai 3");
        }

        // Xuat thong tin va tong diem
        public virtual void Xuat()
        {
            Console.WriteLine($"SBD: {SBD} | Ho ten: {HoTen} | Tong diem: {TinhTongDiem()}");
        }
    }

    // Lop thi sinh khoi Chuyen
    public class ThiSinhChuyen : ThiSinh
    {
        public double TiengAnh { get; set; }

        public override void Nhap()
        {
            base.Nhap();
            TiengAnh = SharedLibs.InputHelper.InputDouble("diem bai tieng anh");
        }

        // Tinh tong diem thi sinh chuyen kem diem thuong tieng Anh
        public override double TinhTongDiem()
        {
            double tong = Bai1 + Bai2 + Bai3;
            if (TiengAnh >= 7 && TiengAnh <= 8)
            {
                tong += 1;
            }
            else if (TiengAnh >= 9 && TiengAnh <= 10)
            {
                tong += 2;
            }
            return tong;
        }

        public override void Xuat()
        {
            Console.Write("[Chuyen]   ");
            base.Xuat();
        }
    }

    // Lop thi sinh khoi Sieu cup
    public class ThiSinhSieuCup : ThiSinh
    {
        public double CSDL { get; set; }

        public override void Nhap()
        {
            base.Nhap();
            CSDL = SharedLibs.InputHelper.InputDouble("diem bai CSDL");
        }

        // Tinh tong diem thi sinh sieu cup (cong diem 4 bai)
        public override double TinhTongDiem()
        {
            return Bai1 + Bai2 + Bai3 + CSDL;
        }

        public override void Xuat()
        {
            Console.Write("[Sieu Cup] ");
            base.Xuat();
        }
    }

    // Lop quan ly va thuc thi danh sach thi sinh trong cuoc thi
    public class CuocThi
    {
        private List<ThiSinh> dsThiSinh = new List<ThiSinh>();

        // Nhap danh sach thi sinh tu ban phim
        public void NhapDanhSach()
        {
            int n = SharedLibs.InputHelper.InputNatural("so luong thi sinh", true);

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"\n--- NHAP THI SINH THU {i + 1} ---");
                int loai;
                do
                {
                    loai = SharedLibs.InputHelper.InputInt("loai thi sinh (1: Chuyen, 2: Sieu Cup)");
                    if (loai != 1 && loai != 2)
                    {
                        Console.WriteLine("Khong hop le, vui long nhap lai!");
                    }
                } while (loai != 1 && loai != 2);

                ThiSinh ts;
                if (loai == 1)
                {
                    ts = new ThiSinhChuyen();
                }
                else
                {
                    ts = new ThiSinhSieuCup();
                }

                //goi dung ham Nhap cua lop con tuong ung
                ts.Nhap();
                dsThiSinh.Add(ts);
            }
        }

        // Xuat danh sach va tong diem cua tung thi sinh
        public void XuatTongDiem()
        {
            Console.WriteLine("\n================ KET QUA TONG DIEM THI SINH ================");
            if (dsThiSinh.Count == 0)
            {
                Console.WriteLine("Danh sach thi sinh trong!");
                return;
            }

            foreach (ThiSinh ts in dsThiSinh)
            {
                //goi dung ham Xuat va TinhTongDiem cua lop con
                ts.Xuat();
            }
        }
    }

}