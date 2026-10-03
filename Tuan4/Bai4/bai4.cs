using Bai1;
namespace Bai4;

public partial class bai4 : Form
{
    private Bai1.bai1 bai1 = new Bai1.bai1();
    public bai4()
    {
        InitializeComponent();

        textbox_nhapso.KeyPress += (s, e) => bai1.txt_KeyPress(s, e, intnumber: true, lineofnum: true);// tais su dung ham txt_KeyPress tu bai1
        btn_tinh_tat.Click += btn_tinh_tat_Click;
        btn_tong_chan.Click += TongChan;
        btn_tong_le.Click += TongLe;
    }


    private int[] GetNumbers()
    {
        string input = textbox_nhapso.Text.Trim();

        // kiem tra o nhap rong
        if (string.IsNullOrEmpty(input))
        {
            return new int[0];
        }

        // cat chuoi da nhap thanh cac phan tu rieng biet
        string[] parts = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        // tao danh sach de luu cac so hop le
        List<int> result = new List<int>();

        // duyet qua cac phan tu con
        foreach (string item in parts)
        {
            // kiem tra hop le
            if (int.TryParse(item, out int number))
            {
                result.Add(number); // them so vao danh sach
            }
        }

        // chuyen ve array de tra ve
        return result.ToArray();
    }



    private void TongChan(object sender, EventArgs e)
    {
        int[] nums = GetNumbers();
        int tong_chan = 0;
        foreach (int num in nums)
        {
            if (num % 2 == 0)
            {
                tong_chan += num;
            }
        }
        textbox_tong_chan.Text = tong_chan.ToString();
    }

    private void TongLe(object sender, EventArgs e)
    {
        int[] nums = GetNumbers();
        int tong_le = 0;
        foreach (int num in nums)
        {
            if (num % 2 != 0)
            {
                tong_le += num;
            }
        }
        textbox_tong_le.Text = tong_le.ToString();
    }

    private void btn_tinh_tat_Click(object sender, EventArgs e)
    {
        int[] nums = GetNumbers();
        int tong = 0;
        foreach (int num in nums)
        {
            tong+= num;
        }
        textbox_tong.Text = tong.ToString();

        TongChan(sender, e);
        TongLe(sender, e);
    }

    private void btn_nhap_Click(object sender, EventArgs e)
    {
        int[] nums = GetNumbers();
        textbox_day.Text = string.Join(" ", nums);
    }

    private void btn_tiep_tuc_Click(object sender, EventArgs e)
    {
        textbox_day.Clear();
        textbox_nhapso.Clear();
        textbox_tong.Clear();
        textbox_tong_chan.Clear();
        textbox_tong_le.Clear();
        textbox_nhapso.Clear();
    }
}
