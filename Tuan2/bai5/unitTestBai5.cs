namespace Tuan2;


public static class UnitTestBai5
{

    public static void TestDefaultConstructor()
    {
        DonThuc p = new DonThuc();

        Assert(p.Heso == 0 && p.Somu == 0, "Khoi tao mac dinh");
    }

    public static void TestConstructor()
    {
        DonThuc p = new DonThuc(3, 2);

        Assert(p.Heso == 3 && p.Somu == 2, "Khoi tao voi he so va so mu");
    }

    public static void TestProperties()
    {
        DonThuc p = new DonThuc();
        p.Heso = 4.5;
        p.Somu = 3;

        Assert(p.Heso == 4.5 && p.Somu == 3, "Luu dung properties");
    }

    public static void TestCopyConstructor()
    {
        DonThuc original = new DonThuc(3, 2);
        DonThuc copy = new DonThuc(original);

        Assert(copy.Heso == 3 && copy.Somu == 2, "Copy constructor sao chep dung");
    }

    public static void TestToString()
    {
        DonThuc p = new DonThuc(3, 2);

        Assert(p.ToString() == "3x^2", "ToString hien thi dung don thuc");
    }

    public static void TestCalculating()
    {
        DonThuc p = new DonThuc(3, 2);
        double result = p.Calculating(4);

        Assert(Math.Abs(result - 48) < 1e-9, "Tinh dung gia tri don thuc");
    }

    public static void TestDerivative()
    {
        DonThuc p = new DonThuc(3, 2);
        DonThuc result = p.derivative();

        Assert(result.Heso == 6 && result.Somu == 1, "Tinh dung dao ham don thuc");
    }

    public static void TestDerivativeOfConstant()
    {
        DonThuc p = new DonThuc(5, 0);
        DonThuc result = p.derivative();

        Assert(result.Heso == 0 && result.Somu == 0, "Dao ham cua hang so bang 0");
    }

    public static void TestOutput()
    {
        DonThuc p = new DonThuc(3, 2);
        using StringWriter output = new StringWriter();
        TextWriter oldOutput = Console.Out;
        Console.SetOut(output);

        try
        {
            p.Output();
        }
        finally
        {
            Console.SetOut(oldOutput);
        }

        Assert(output.ToString().Contains("Don thuc la: 3x^2"), "Output hien thi dung don thuc");
    }

    private static void Assert(bool condition, string testName)
    {
        Console.WriteLine(condition ? $"PASS: {testName}" : $"FAIL: {testName}");
    }

}