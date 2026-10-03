using System;
using System.Windows.Forms;

namespace Bai1;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();

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
    public void txt_KeyPress(object sender, KeyPressEventArgs e)
    {
        TextBox txt = (TextBox)sender;

        // Cho phép phím điều khiển (Backspace...) và chữ số
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