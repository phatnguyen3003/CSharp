using System;
using System.IO;

namespace Tuan2;

public static class UnitTestPersonList
{
    public static void TestDefaultConstructor()
    {
        PersonList list = new PersonList();

        using StringWriter output = new StringWriter();
        TextWriter oldOutput = Console.Out;
        Console.SetOut(output);

        try
        {
            list.Output();
        }
        finally
        {
            Console.SetOut(oldOutput);
        }

        Assert(output.ToString().Contains("Danh sach trong."), "Khoi tao mac dinh tao danh sach trong");
    }

    public static void TestAddAndOutput()
    {
        PersonList list = new PersonList();
        Person p = new Person();
        list.Add(p);

        using StringWriter output = new StringWriter();
        TextWriter oldOutput = Console.Out;
        Console.SetOut(output);

        try
        {
            list.Output();
        }
        finally
        {
            Console.SetOut(oldOutput);
        }

        Assert(output.ToString().Contains("Nguoi thu 1"), "Them doi tuong Person va xuat danh sach dung");
    }

    public static void TestAddNull()
    {
        PersonList list = new PersonList();
        list.Add(null!);

        using StringWriter output = new StringWriter();
        TextWriter oldOutput = Console.Out;
        Console.SetOut(output);

        try
        {
            list.Output();
        }
        finally
        {
            Console.SetOut(oldOutput);
        }

        Assert(output.ToString().Contains("Danh sach trong."), "Them doi tuong null khong lam thay doi danh sach");
    }

    public static void TestCopyConstructor()
    {
        PersonList originalList = new PersonList();
        originalList.Add(new Person());

        PersonList copyList = new PersonList(originalList);

        using StringWriter output = new StringWriter();
        TextWriter oldOutput = Console.Out;
        Console.SetOut(output);

        try
        {
            copyList.Output();
        }
        finally
        {
            Console.SetOut(oldOutput);
        }

        Assert(output.ToString().Contains("Nguoi thu 1"), "Copy constructor sao chep dung danh sach");
    }

    public static void TestCopyConstructorWithNull()
    {
        PersonList copyList = new PersonList(null!);

        using StringWriter output = new StringWriter();
        TextWriter oldOutput = Console.Out;
        Console.SetOut(output);

        try
        {
            copyList.Output();
        }
        finally
        {
            Console.SetOut(oldOutput);
        }

        Assert(output.ToString().Contains("Danh sach trong."), "Copy constructor xu ly an toan khi truyen null");
    }

    public static void TestLivingPeople()
    {
        PersonList list = new PersonList();
        list.Add(new Person());

        PersonList livingList = list.LivingPeople();

        using StringWriter output = new StringWriter();
        TextWriter oldOutput = Console.Out;
        Console.SetOut(output);

        try
        {
            livingList.Output();
        }
        finally
        {
            Console.SetOut(oldOutput);
        }

        Assert(livingList != null, "Phuong thuc LivingPeople tra ve danh sach hop le");
    }

    private static void Assert(bool condition, string testName)
    {
        Console.WriteLine(condition ? $"PASS: {testName}" : $"FAIL: {testName}");
    }
}