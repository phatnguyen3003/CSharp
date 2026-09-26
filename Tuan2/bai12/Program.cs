using System;

namespace Tuan2
{
    class Program
    {
        static void Main(string[] args)
        {
            PhongBan pb = new PhongBan();

            // Nhập thông tin các nhân viên trong phòng ban
            pb.Input();

            // Xuất bảng lương và tổng lương
            pb.Output();
        }
    }
}