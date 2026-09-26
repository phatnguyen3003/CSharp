using System;
using System.Collections.Generic;

namespace Tuan2
{
    public class ConsoleMenu
    {
        protected class MenuItem
        {
            public string Title { get; set; }
            public Action Action { get; set; }

            public MenuItem(string title, Action action)
            {
                Title = title;
                Action = action;
            }
        }

        protected List<MenuItem> items = new List<MenuItem>();
        public string HeaderTitle { get; set; }

        // thuc hien 1 chuc nang bat ky da duoc dang ky va goi
        public event Action<int, string>? OnOptionExecuted;

        public ConsoleMenu(string headerTitle = "Menu")
        {
            HeaderTitle = headerTitle;
        }

        public void AddOption(string title, Action action) // them chuc nang
        {
            items.Add(new MenuItem(title, action));
        }

        // tao phuong thuc virtual de lop con co the chinh sua hanh vi hoac goi lai
        public virtual void Display()
        {
            Console.WriteLine(HeaderTitle);
            for (int i = 0; i < items.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {items[i].Title}");
            }
            Console.WriteLine("0. Thoát chương trình");
        }

        public virtual void Run()
        {
            int choice;
            do
            {
                Console.WriteLine();
                Display();
                Console.Write("Thực hiện: ");
                choice = SharedLibs.InputHelper.InputInt("lua chon");

                if (choice > 0 && choice <= items.Count)
                {
                    Console.WriteLine($"Bạn thực hiện chức năng {choice}");

                    // kich hoat event thong bao chuc nang thuc thi
                    OnOptionExecuted?.Invoke(choice, items[choice - 1].Title);

                    // thuc thi hanh dong tuong ung
                    items[choice - 1].Action?.Invoke();
                }
                else if (choice != 0)
                {
                    Console.WriteLine("lua chon khong hop le!");
                }

                else
                {
                    Console.WriteLine("vui long nhap so nguyen!");
                    choice = -1;
                }
            } while (choice != 0);
        }
    }
}