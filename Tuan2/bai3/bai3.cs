using System;
using SharedLibs;

namespace Tuan2
{
    public class Person
    {
        // 1. Fields
        private string id;
        private string name;
        private int yob; // Year of Birth
        private int yod; // Year of Death (0 nếu còn sống)

        // Properties
        public string Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public int Yob
        {
            get
            {
                return yob;
            }
            set
            {
                yob = value;
            }
        }

        public int Yod
        {
            get
            {
                return yod;
            }
            set
            {
                yod = value;
            }
        }

        // 2. Default Constructor
        public Person()
        {
            id = string.Empty;
            name = string.Empty;
            yob = 0;
            yod = 0;
        }

        // 3. Copy Constructor (Khởi tạo sao chép từ một đối tượng Person khác)
        public Person(Person other)
        {
            if (other != null)
            {
                this.id = other.id;
                this.name = other.name;
                this.yob = other.yob;
                this.yod = other.yod;
            }
        }

        public Person(string id, string name, int yob, int yod)
        {
            this.id = id;
            this.name = name;
            this.yob = yob;
            this.yod = yod;
        }

        // 4. Method: IsLiving (Trả về true nếu yod == 0, ngược lại false)
        public bool IsLiving()
        {
            if (yod != 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        // 5. Method: Input
        public void Input()
        {
            id = SharedLibs.InputHelper.InputString("ID");

            name = SharedLibs.InputHelper.InputString("Ho ten");

            yob = SharedLibs.InputHelper.InputNatural("Nam Sinh");
            while (yob > DateTime.Now.Year)
            {
                yob = SharedLibs.InputHelper.InputNatural("lai nam Sinh");
            }

            yod = SharedLibs.InputHelper.InputNatural("nam mat (YOD) [Nhap 0 neu con song]: ");
            while (yod != 0 && yod < yob)
            {
                yod = SharedLibs.InputHelper.InputNatural("lai nam mat (YOD) [Nhap 0 neu con song]: ");
            }
        }

        // 6. Method: Output
        public void Output()
        {
            string status = IsLiving() ? "Con song" : $"Da mat (Nam {yod})";
            Console.WriteLine($"ID: {id} | Ten: {name} | Nam sinh: {yob} | Trang thai: {status}");
        }
    }
}
