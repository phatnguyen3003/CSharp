using System.Windows.Forms;

namespace Bai1;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();

    }


    private void btn_PhepTinh_Click(object sender, EventArgs e)
    {
        if (!double.TryParse(textBox1.Text, out double a) || !double.TryParse(textBox2.Text, out double b))
        {
            MessageBox.Show("Vui lòng nhập số hợp lệ!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        // Ép kiểu sender về Button để lấy Text (+, -, *, /)
        Button btn = (Button)sender;

        switch (btn.Text)
        {
            case "+":
                textBox3.Text = (a + b).ToString();
                break;
            case "-":
                textBox3.Text = (a - b).ToString();
                break;
            case "*":
                textBox3.Text = (a * b).ToString();
                break;
            case "/":
                if (b == 0)
                {
                    MessageBox.Show("Không thể chia cho 0!", "Lỗi toán học", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox3.Text = "Lỗi chia 0";
                }
                else
                {
                    textBox3.Text = (a / b).ToString();
                }
                break;
        }
    }

    // Hàm kiểm tra và gắn ErrorProvider cho các TextBox
    private bool KiemTraDuLieu(out double a, out double b)
    {
        bool laHopLe = true;

        // 1. Kiểm tra ô a
        if (!double.TryParse(textBox1.Text, out a))
        {
            errorProvider1.SetError(textBox1, "Vui lòng nhập số hợp lệ vào ô a!");
            laHopLe = false;
        }
        else
        {
            errorProvider1.SetError(textBox1, ""); // Xóa biểu tượng lỗi nếu đúng
        }

        // 2. Kiểm tra ô b
        if (!double.TryParse(textBox2.Text, out b))
        {
            errorProvider1.SetError(textBox2, "Vui lòng nhập số hợp lệ vào ô b!");
            laHopLe = false;
        }
        else
        {
            errorProvider1.SetError(textBox2, ""); // Xóa biểu tượng lỗi nếu đúng
        }

        return laHopLe;
    }

    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
        DialogResult r;
        r = MessageBox.Show("Bạn có muốn thoát?", "Thoát",

        MessageBoxButtons.YesNo, MessageBoxIcon.Question,
        MessageBoxDefaultButton.Button1);

        if (r == DialogResult.No)
            e.Cancel = true;
    }

    private void textBox1_TextChanged(object sender, EventArgs e)
    {
        if (!double.TryParse(textBox1.Text, out _))
        {
            errorProvider1.SetError(textBox1, "Nội dung nhập vào phải là số!");
        }
        else
        {
            errorProvider1.SetError(textBox1, "");
        }
    }

    private void textBox2_TextChanged(object sender, EventArgs e)
    {
        if (!double.TryParse(textBox2.Text, out _))
        {
            errorProvider1.SetError(textBox2, "Nội dung nhập vào phải là số!");
        }
        else
        {
            errorProvider1.SetError(textBox2, "");
        }
    }

    private void txt_KeyPress(object sender, KeyPressEventArgs e)
    {
        TextBox txt = (TextBox)sender;

        // Cho phép phím điều khiển (Backspace, Delete...) và các chữ số
        if (char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar))
        {
            return;
        }

        // Cho phép 1 dấu '-' ở đầu chuỗi (số âm)
        if (e.KeyChar == '-' && txt.SelectionStart == 0 && !txt.Text.Contains("-"))
        {
            return;
        }

        // Cho phép 1 dấu phân cách thập phân (dấu '.' hoặc ',')
        if ((e.KeyChar == '.' || e.KeyChar == ',') && !txt.Text.Contains(".") && !txt.Text.Contains(","))
        {
            return;
        }

        // Chặn tất cả các ký tự khác (chữ cái, ký tự đặc biệt...)
        e.Handled = true;
    }

}
