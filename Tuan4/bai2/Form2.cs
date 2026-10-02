namespace Bai2;

public partial class Form2 : Form
{
    public Form2()
    {
        InitializeComponent();
        textbox_email.Leave += email_check;
        textbox_password.PasswordChar = '*';
        textbox_retype_password.PasswordChar = '*';
    }


    private void email_check(object sender, EventArgs e)
    {
        string email = textbox_email.Text;
        if (email.Contains("@") && email.Contains("."))
        {
            email_error.SetError(textbox_email, "");
        }
        else
        {
            email_error.SetError(textbox_email, "Email không hợp lệ");
        }
    }

    private void Form2_FormClosing(object sender, FormClosingEventArgs e)
    {
        DialogResult r;
        r = MessageBox.Show("Bạn có muốn thoát?", "Thoát",

        MessageBoxButtons.YesNo, MessageBoxIcon.Question,
        MessageBoxDefaultButton.Button1);

        if (r == DialogResult.No)
            e.Cancel = true;
    }

    private void btn_dangky_Click(object sender, EventArgs e)
    {
        string name = textbox_name.Text;
        string email = textbox_email.Text;
        string password = textbox_password.Text;
        string confirmPassword = textbox_retype_password.Text;

        if(name == "" || email == "" || password == "" || confirmPassword == "")
        {
            MessageBox.Show("Vui lòng điền đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (password != confirmPassword)
        {
            MessageBox.Show("Mật khẩu không khớp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }


        if (email_error.GetError(textbox_email) == "")
        {
            MessageBox.Show($"Đăng ký thành công\ntài khoản: {name}\nemail: {email}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        else
        {
            MessageBox.Show("Vui lòng nhập đúng email", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
