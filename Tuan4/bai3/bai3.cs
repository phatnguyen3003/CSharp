using Bai1; // dùng lại hàm textchanged của bài 1
namespace bai3;

public partial class bai3 : Form
{
    private Bai1.Form1 form1 = new Bai1.Form1();
    public bai3()
    {
        InitializeComponent();
        textbox_a.TextChanged += form1.txt_TextChanged;//tái sử dụng
        textbox_b.TextChanged += form1.txt_TextChanged;
        textbox_a.KeyPress += form1.txt_KeyPress;
        textbox_b.KeyPress += form1.txt_KeyPress;

        //add form closing event
        this.FormClosing += form1.Form1_FormClosing;
    }

    private int BoiChungNhoNhat(int a, int b)
    {
        int max = Math.Max(a, b);
        int min = Math.Min(a, b);
        int bcnn = max;
        while (bcnn % min != 0)
        {
            bcnn += max;
        }
        return bcnn;
    }

    private int UocChungLonNhat(int a, int b)
    {
        int max = Math.Max(a, b);
        int min = Math.Min(a, b);
        while (min != 0)
        {
            int temp = min;
            min = max % min;
            max = temp;
        }
        return max;
    }

    private void btn_tinh_Click(object sender, EventArgs e)
    {
        int a = int.Parse(textbox_a.Text);
        int b = int.Parse(textbox_b.Text);

        int bcnn = BoiChungNhoNhat(a, b);

        textbox_bscnn.Text = bcnn.ToString();

        int ucln = UocChungLonNhat(a, b);
        textbox_uscln.Text = ucln.ToString();
    }

    private void btn_thoat_Click(object sender, EventArgs e)
    {
        this.Close();
    }

    private void btn_tieptuc_Click(object sender, EventArgs e)
    {
        textbox_a.Text = "";
        textbox_b.Text = "";
        textbox_uscln.Text = "";
        textbox_bscnn.Text = "";
    }


}
