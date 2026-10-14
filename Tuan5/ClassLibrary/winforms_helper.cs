using System;
using System.Windows.Forms;

namespace ClassLibrary
{
    public class winforms_helper
    {


        // 1. Dùng chung 1 hàm TextChanged
        public void txt_TextChanged(object sender, EventArgs e, ErrorProvider errorProvider)
        {
            var txt = (TextBox)sender;

            if (string.IsNullOrWhiteSpace(txt.Text))
            {
                errorProvider.SetError(txt, "");
                return;
            }

            if (!double.TryParse(txt.Text, out _))
            {
                errorProvider.SetError(txt, "Nội dung nhập vào phải là số hợp lệ!");
            }
            else
            {
                errorProvider.SetError(txt, "");
            }
        }




    // 2. Chặn phím ngay lúc gõ
    public void txt_KeyPress(object sender, KeyPressEventArgs e, bool intnumber = false, bool lineofnum = false)
    {
        TextBox txt = (TextBox)sender;

        if (lineofnum == false)
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
}
}