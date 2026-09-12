using SharedLibs;

namespace Tuan1
{
    public class Student
    {
        public string Id { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public int AcademicYear { get; set; }


        public Student(string id, string fullName, string address, int academicYear) // instructor
        {
            Id = id;
            FullName = fullName;
            Address = address;
            AcademicYear = academicYear;
        }

        public void Input()
        {
            Console.WriteLine("--- Nhap thong tin sinh vien ---");
            Id = InputHelper.InputString("ma sinh vien");
            FullName = InputHelper.InputString("ho ten sinh vien");
            Address = InputHelper.InputString("dia chi");
            AcademicYear = InputHelper.InputNatural("nam hoc thu may (1, 2, 3...)");
        }

        public void Display()
        {
            // Display student information
            Console.WriteLine("\n--- Thong tin sinh vien da nhap ---");
            Console.WriteLine($"Ma sinh vien : {Id}");
            Console.WriteLine($"Ho va ten    : {FullName}");
            Console.WriteLine($"Dia chi      : {Address}");
            Console.WriteLine($"Sinh vien nam: Thu {AcademicYear}");
        }
    }

    public class Bai13
    {
        public static void Run()
        {
            Student student = new Student("3124411", "Phat", "Khong", 2);
            student.Display();
        }
    }
}