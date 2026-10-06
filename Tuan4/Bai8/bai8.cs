using Bai1; // su dung lai bai1
namespace Bai8
{
    public partial class bai8 : Form
    {
        Bai1.bai1 bai1Form = new Bai1.bai1();
        public bai8()
        {
            InitializeComponent();
        }

        private void textbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            bai1Form.txt_KeyPress(sender, e, intnumber: false, lineofnum: false); //wrapper cho ham keypress cua bai1, cho phep nhap so thuc va co dau cham, khong cho nhap day so
        }

        private void textbox_Textchanged(object sender, EventArgs e)
        {
            bai1Form.txt_TextChanged(sender, e);//wrapper cho ham textchanged cua bai1
        }

        private void btn_cal_Click(object sender, EventArgs e) //ham tinh toan
        {
            float a = float.Parse(textbox_a.Text);
            float b = float.Parse(textbox_b.Text);

            if (radio_plus.Checked)
            {
                textbox_result.Text = (a + b).ToString();
            }
            else if (radio_minus.Checked)
            {
                textbox_result.Text = (a - b).ToString();
            }
            else if (radio_mul.Checked)
            {
                textbox_result.Text = (a * b).ToString();
            }
            else if (radio_devide.Checked)
            {
                if (b == 0)
                {
                    errorProvider1.SetError(textbox_b, "Không thể chia cho 0");
                    return;
                }
                textbox_result.Text = (a / b).ToString();
            }
        }

        public void form_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có muốn thoát?", "Thoát",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (r == DialogResult.No)
                e.Cancel = true;
        }
    }
}
