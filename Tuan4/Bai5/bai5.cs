using Bai1;
namespace Bai5;

public partial class bai5 : Form
{
    private Bai1.bai1 bai1 = new Bai1.bai1();
    public bai5()
    {
        InitializeComponent();
        this.FormClosing += bai1.Form1_FormClosing;
        textbox_nhap.KeyPress += (s, e) => bai1.txt_KeyPress(s, e, intnumber: true, lineofnum: false);// tais su dung ham txt_KeyPress tu bai1
    }

    private void btn_thuchien_Click(object sender, EventArgs e)
    {
        string input = textbox_nhap.Text;
        if(string.IsNullOrWhiteSpace(input))
        {
            MessageBox.Show("Vui lòng nhập dữ liệu vào ô textbox.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }


        int number = int.Parse(input);

        if(number < 1  || number > 999)
        {
            MessageBox.Show("Vui lòng nhập số nguyên dương từ 1 đến 999.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        int tram = number / 100;           // Chữ số hàng trăm
        int chuc = (number % 100) / 10;    // Chữ số hàng chục
        int donVi = number % 10;           // Chữ số hàng đơn vị



        string[] calling = {"Một", "Hai", "Ba", "Bốn", "Năm", "Sáu", "Bảy", "Tám", "Chín" };




        // 3. Ghép chuỗi hiển thị đơn giản (Ví dụ: "1 Trăm 2 Mươi 3 Đơn vị")
        string result = "";
        // Hàng trăm
        if (tram > 0)
            result += $"{calling[tram-1]} Trăm ";

        // Hàng chục
        if (chuc == 1)
        {
            result += "Mười ";  
        }
        else if (chuc > 1)
        {
            result += $"{calling[chuc-1]} Mươi "; 
        }
        
        else if (tram > 0 && donVi > 0)
        {
            result += "Lẻ ";           
        }

        // Hàng đơn vị
        if (donVi > 0 || (tram == 0 && chuc == 0))
            result += $"{calling[donVi-1]} Đơn vị";
        else
        {
            result += $"{calling[donVi-1]}";
        }

            textbox_xuat.Text = result.Trim();
    }

    private void btn_xoa_Click(object sender, EventArgs e)
    {
        textbox_nhap.Clear();
        textbox_xuat.Clear();
    }

    private void btn_thoat_Click(object sender, EventArgs e)
    {
        this.Close();
    }
}
