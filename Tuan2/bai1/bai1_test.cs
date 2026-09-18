using Tuan2;

namespace Tuan2;

public static class Bai1Tests
{
    public static void TestTaoHocSinh()
    {
        HocSinh hocSinh = new HocSinh("An", 2005);

        Assert(hocSinh != null, "Tao doi tuong HocSinh");
    }

    public static void TestHoTen()
    {
        HocSinh hocSinh = new HocSinh("An", 2005);

        Assert(hocSinh.HoTen == "An", "Luu dung ho ten");
    }

    public static void TestNamSinh()
    {
        HocSinh hocSinh = new HocSinh("An", 2005);

        Assert(hocSinh.NamSinh == 2005, "Luu dung nam sinh");
    }

    public static void TestTinhTuoi()
    {
        HocSinh hocSinh = new HocSinh("An", DateTime.Now.Year - 20);
        using StringWriter output = new StringWriter();
        TextWriter oldOutput = Console.Out;
        Console.SetOut(output);

        try
        {
            hocSinh.Tinhtuoi();
        }
        finally
        {
            Console.SetOut(oldOutput);
        }

        Assert(output.ToString().Contains("20"), "Tinh dung tuoi");
    }

    public static void TestThongBaoTinhTuoi()
    {
        HocSinh hocSinh = new HocSinh("An", 2000);
        using StringWriter output = new StringWriter();
        TextWriter oldOutput = Console.Out;
        Console.SetOut(output);

        try
        {
            hocSinh.Tinhtuoi();
        }
        finally
        {
            Console.SetOut(oldOutput);
        }

        Assert(output.ToString().StartsWith("Tuoi cua sinh vien nay la:"), "In dung thong bao tuoi");
    }

    private static void Assert(bool condition, string testName)
    {
        Console.WriteLine(condition ? $"PASS: {testName}" : $"FAIL: {testName}");
    }
}
