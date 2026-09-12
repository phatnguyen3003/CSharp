using SharedLibs;

namespace Tuan1
{
    public class Employee
    {
        public string FullName { get; set; } = string.Empty;
        public double BaseSalary { get; set; }
        public int AbsentDays { get; set; }

        public void Input()
        {
            Console.WriteLine("--- Nhap thong tin nhan vien ---");
            FullName = InputHelper.InputString("ho ten nhan vien");
            BaseSalary = InputHelper.InputDouble("muc luong");
            AbsentDays = InputHelper.InputNatural("so ngay vang");
        }

        public double CalculateSalary()
        {
            double fine = AbsentDays * 100000;
            double finalSalary = BaseSalary - fine;

            if (finalSalary > 0)
            {
                return finalSalary;
            }
            else
            {
                return 0;
            }
        }

        public void Display()
        {
            double finalSalary = CalculateSalary();

            Console.WriteLine("\n--- Bang luong nhan vien ---");
            Console.WriteLine($"Ho va ten     : {FullName}");
            Console.WriteLine($"Muc luong goc : {BaseSalary:N0} VND");
            Console.WriteLine($"So ngay vang  : {AbsentDays} ngay");
            Console.WriteLine($"Tien bi tru   : {AbsentDays * 100000:N0} VND");
            Console.WriteLine($"Luong thuc te : {finalSalary:N0} VND");
        }
    }

    public class Bai14
    {
        public static void Run()
        {
            Employee emp = new Employee();
            emp.Input();
            emp.Display();
        }
    }
}