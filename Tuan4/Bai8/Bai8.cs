using Bai1;
using System.Globalization;

namespace Bai8
{

    public partial class Bai8 : Form
    {
        Bai1.bai1 bai1Form = new Bai1.bai1();
        public Bai8()
        {
            InitializeComponent();

            // dang ky su kien
            radio_1.CheckedChanged += radio_CheckedChanged;
            radio_2.CheckedChanged += radio_CheckedChanged;
            textbox_a.TextChanged += textbox_Textchanged;
            textbox_b.TextChanged += textbox_Textchanged;
            textbox_c.TextChanged += textbox_Textchanged;
            textbox_a.KeyPress += textbox_KeyPress;
            textbox_b.KeyPress += textbox_KeyPress;
            textbox_c.KeyPress += textbox_KeyPress;
            btn_cal.Click += btn_cal_Click;

            CapNhatGiaoDien();
        }

        private void textbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // kiem tra ky tu dau vao
            bai1Form.txt_KeyPress(sender, e, intnumber: false, lineofnum: false);
        }

        private void textbox_Textchanged(object? sender, EventArgs e)
        {
            // xoa ket qua cu va cap nhat nut giai
            textbox_result.Clear();
            CapNhatNutGiai();
        }

        private void radio_CheckedChanged(object? sender, EventArgs e)
        {
            // cap nhat lai giao dien khi chuyen loai phuong trinh
            CapNhatGiaoDien();
        }

        private void CapNhatGiaoDien()
        {
            // an hien textbox nhap c theo loai phuong trinh
            bool laPhuongTrinhBacHai = radio_2.Checked;
            if (!laPhuongTrinhBacHai)
            {
                label4.ForeColor = Color.Gray;
            }
            else
            {
                label4.BackColor = SystemColors.Control;
            }
            textbox_c.ReadOnly = !laPhuongTrinhBacHai;
            textbox_result.Clear();
            CapNhatNutGiai();
        }

        private void CapNhatNutGiai()
        {
            // chi bat nut giai khi da nhap du du lieu
            bool duThongTin = !string.IsNullOrWhiteSpace(textbox_a.Text) && !string.IsNullOrWhiteSpace(textbox_b.Text) && (!radio_2.Checked || !string.IsNullOrWhiteSpace(textbox_c.Text));

            btn_cal.Enabled = duThongTin;
        }

        private void btn_cal_Click(object? sender, EventArgs e)
        {
            // doc du lieu dau vao
            double a = textbox_a.Text == "" ? 0 : double.Parse(textbox_a.Text, CultureInfo.InvariantCulture);
            double b = textbox_b.Text == "" ? 0 : double.Parse(textbox_b.Text, CultureInfo.InvariantCulture);

            double c = 0;
            if (radio_2.Checked)
            {
                c = textbox_c.Text == "" ? 0 : double.Parse(textbox_c.Text, CultureInfo.InvariantCulture);
            }

            // tinh toan va hien thi ket qua
            PhuongTrinhBacHai phuongTrinh = new PhuongTrinhBacHai(a, b, c);
            textbox_result.Text = radio_2.Checked ? phuongTrinh.GiaiPhuongTrinhBacHai() : phuongTrinh.GiaiPhuongTrinhBacNhat();
            btn_cal.Enabled = false;
        }

        public void form_FormClosing(object sender, FormClosingEventArgs e)
        {
            // xac nhan khi dong form
            DialogResult r = MessageBox.Show("Bạn có muốn thoát?", "Thoát",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (r == DialogResult.No)
                e.Cancel = true;
        }
    }
}