using System;
using System.Windows.Forms;

namespace Bai1;

public partial class bai1 : Form
{
    public bai1()
    {
        InitializeComponent();

        this.textBox1.KeyPress += (sender, e) => txt_KeyPress(sender, e, intnumber: true, lineofnum: false);
        this.textBox2.KeyPress += (sender, e) => txt_KeyPress(sender, e, intnumber: true, lineofnum: false);
    }

    // 1. Dùng chung 1 hàm TextChanged
    public void txt_TextChanged(object sender, EventArgs e)
    {
        TextBox txt = (TextBox)sender;

        if (string.IsNullOrWhiteSpace(txt.Text))
        {
            errorProvider1.SetError(txt, ""); // Xóa lỗi nếu ô rỗng
            return;
        }

        if (!double.TryParse(txt.Text, out _))
        {
            errorProvider1.SetError(txt, "Nội dung nhập vào phải là số hợp lệ!");
        }
        else
        {
            errorProvider1.SetError(txt, "");
        }
    }




    // 2. Chặn phím ngay lúc gõ
    public void txt_KeyPress(object sender, KeyPressEventArgs e,bool intnumber = false,bool lineofnum = false)
    {
        TextBox txt = (TextBox)sender;

        if(lineofnum == false)
        {
            if (char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar))
            {
                return;
            }
        }
        else
        {
            if (char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar) || e.KeyChar == ' ')
            {
                return;
            }
        }


        // Cho phép 1 dấu '-' ở đầu chuỗi (số âm)
        if (e.KeyChar == '-' && txt.SelectionStart == 0 && !txt.Text.Contains("-"))
        {
            return;
        }

        if (intnumber == false)
        {
            // Cho phép 1 dấu phân cách thập phân (dấu '.' hoặc ',')
            if ((e.KeyChar == '.' || e.KeyChar == ',') && !txt.Text.Contains(".") && !txt.Text.Contains(","))
            {
                return;
            }
        }

        // Chặn tất cả các ký tự khác
        e.Handled = true;
    }



    // 3. Xử lý tính toán khi nhấn nút
    private void btn_PhepTinh_Click(object sender, EventArgs e)
    {
        // Kiểm tra chuyển đổi số
        if (!double.TryParse(textBox1.Text, out double a) || !double.TryParse(textBox2.Text, out double b))
        {
            MessageBox.Show("Vui lòng nhập số hợp lệ vào cả 2 ô!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

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

    public void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
        DialogResult r = MessageBox.Show("Bạn có muốn thoát?", "Thoát",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        if (r == DialogResult.No)
            e.Cancel = true;
    }
}