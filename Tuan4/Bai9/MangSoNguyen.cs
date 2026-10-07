using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai9
{
    public class MangSoNguyen
    {
        private List<int> ds;

        // thuoc tinh lay va gan danh sach mang
        public List<int> DanhSach
        {
            get 
            { 
                return ds; 
            }
            set 
            { 
                ds = value; 
            }
        }

        // khoi tao mang rong
        public MangSoNguyen()
        {
            ds = new List<int>();
        }

        // khoi tao tu mot mang hoac danh sach co san
        public MangSoNguyen(IEnumerable<int> collection)
        {
            ds = new List<int>(collection);
        }

        // sap xep mang tang dan
        public void SapXepTang()
        {
            ds.Sort();
        }

        // sap xep mang giam dan
        public void SapXepGiam()
        {
            ds.Sort((a, b) => b.CompareTo(a));
        }

        // tim kiem gia tri va tra ve danh sach tat ca vi tri tim thay
        public List<int> TimKiem(int giaTri)
        {
            List<int> viTri = new List<int>();
            for (int i = 0; i < ds.Count; i++)
            {
                if (ds[i] == giaTri)
                {
                    viTri.Add(i);
                }
            }
            return viTri;
        }

        // them gia tri moi vao vi tri duoc chi dinh
        public bool ThemPhanTu(int giaTri, int viTri)
        {
            if (viTri < 0 || viTri > ds.Count) 
                return false;
            ds.Insert(viTri, giaTri);
            return true;
        }

        // xoa phan tu tai vi tri chi dinh
        public bool XoaTaiViTri(int viTri)
        {
            if (viTri < 0 || viTri >= ds.Count)
                return false;
            ds.RemoveAt(viTri);
            return true;
        }

        // xoa tat ca phan tu co gia tri trung khop va tra ve so luong da xoa
        public int XoaGiaTri(int giaTri)
        {
            return ds.RemoveAll(x => x == giaTri);
        }

        // tinh tong tat ca cac phan tu
        public int TinhTong()
        {
            return ds.Sum();
        }

        // tinh tong cac so chan
        public int TinhTongChan()
        {
            return ds.Where(x => x % 2 == 0).Sum();//linq
        }

        // tinh tong cac so le
        public int TinhTongLe()
        {
            return ds.Where(x => x % 2 != 0).Sum();//linq
        }

        // tim gia tri lon nhat
        public int? TimMax()
        {
            if (ds.Count == 0) 
                return null;
            return ds.Max();
        }

        // tim gia tri nho nhat
        public int? TimMin()
        {
            if (ds.Count == 0) return null;
            return ds.Min();
        }

        // thay the gia tri tai vi tri chi dinh
        public bool ThayTheTaiViTri(int viTri, int giaTriMoi)
        {
            if (viTri < 0 || viTri >= ds.Count) 
                return false;
            ds[viTri] = giaTriMoi;
            return true;
        }

        // thay the tat ca gia tri cu bang gia tri moi
        public int ThayTheGiaTri(int giaTriCu, int giaTriMoi)
        {
            int soLuong = 0;
            for (int i = 0; i < ds.Count; i++)
            {
                if (ds[i] == giaTriCu)
                {
                    ds[i] = giaTriMoi;
                    soLuong++;
                }
            }
            return soLuong;
        }

        // chuyen mang thanh chuoi de hien thi len giao dien
        public string XuatMang()
        {
            return string.Join(" ", ds);
        }
    }
}
