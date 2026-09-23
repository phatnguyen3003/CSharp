using System;
using System.Collections.Generic;
using SharedLibs;



namespace Tuan2
{
    public class PersonList
    {
        private List<Person> personlist; //field

        public PersonList()//constructor
        {
            personlist = new List<Person>();
        }

        public PersonList(PersonList otherpersonlist)//copy constructor
        {
            personlist = new List<Person>();
            if (otherpersonlist != null && otherpersonlist.personlist != null)//check
            {
                foreach (Person p in otherpersonlist.personlist)
                {
                    personlist.Add(new Person(p));//create and add Person object
                }
            }
        }


        public void Add(Person p)
        {
            if (p != null)
            {
                personlist.Add(p);
            }
        }


        public void Input()
        {
            int n;
            n = SharedLibs.InputHelper.InputNatural("So luong nguoi");

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Nhap thong tin nguoi thu {i + 1}:");

                Person p = new Person();

                p.Input();

                personlist.Add(p);
            }
        }


        public void Output()
        {
            if (personlist.Count == 0)
            {
                Console.WriteLine("Danh sach trong.");
                return;
            }

            for (int i = 0; i < personlist.Count; i++)
            {
                Console.WriteLine($"\n--- Nguoi thu {i + 1} ---");
                personlist[i].Output(); // goi phuong thuc output co san cua lop person
            }
        }


        public PersonList LivingPeople()
        {
            PersonList resultList = new PersonList();

            foreach (Person p in personlist)
            {
                // kiem tra dieu kien con song
                if (p.IsLiving())
                {
                    resultList.Add(p);
                }
            }

            return resultList;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {


            if (args.Length > 0 && args[0] == "test")
            {
                Console.WriteLine("===================================");
                UnitTestPersonList.TestDefaultConstructor();
                UnitTestPersonList.TestAddAndOutput();
                UnitTestPersonList.TestAddNull();
                UnitTestPersonList.TestCopyConstructor();
                UnitTestPersonList.TestCopyConstructorWithNull();
                UnitTestPersonList.TestLivingPeople();
                return;
            }


            // khoi tao danh sach ban dau
            PersonList list1 = new PersonList();
            Console.WriteLine("\n--- nhap danh sach nhan khau ---");
            list1.Input();

            // xuat danh sach
            Console.WriteLine("\n=================================");
            Console.WriteLine("danh sach cac nhan khau:");
            list1.Output();

            // loc danh sach nhung nguoi con song
            Console.WriteLine("\n=================================");
            Console.WriteLine("danh sach cac nguoi con song:");
            PersonList livingList = list1.LivingPeople();
            livingList.Output();

            // kiem tra copy constructor
            Console.WriteLine("\n=================================");
            Console.WriteLine("kiem tra copy constructor, tao ban sao list:");
            PersonList copyList = new PersonList(list1);
            copyList.Output();
        }
    }
}