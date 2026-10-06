namespace Bai7
{
    public partial class bai7 : Form
    {
        public bai7()
        {
            InitializeComponent();
            btn_0.Click += btn_Click;
            btn_1.Click += btn_Click;
            btn_2.Click += btn_Click;
            btn_3.Click += btn_Click;
            btn_4.Click += btn_Click;
            btn_5.Click += btn_Click;
            btn_6.Click += btn_Click;
            btn_7.Click += btn_Click;
            btn_8.Click += btn_Click;
            btn_9.Click += btn_Click;
            btn_backspace.Click += btn_Click;
            btn_clear.Click += btn_Click;
            btn_plus.Click += btn_Click;
            btn_minus.Click += btn_Click;
            btn_mul.Click += btn_Click;
            btn_devide.Click += btn_Click;
            btn_equal.Click += (s, e) => TinhKetQua();
        }


        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn == null) return;

            string btnText = btn.Text;
            string text = textbox_input.Text.Trim();

            // xu ly rieng cho nut clear (xoa tat ca)
            if (btn == btn_clear || btnText == "C")
            {
                textbox_input.Text = "";
                return;
            }

            // xu ly rieng cho nut backspace (xoa 1 ky tu cuoi)
            if (btn == btn_backspace || btnText == "<-" || btnText == "DEL")
            {
                if (!string.IsNullOrEmpty(text))
                {
                    textbox_input.Text = text.Substring(0, text.Length - 1);
                }
                return;
            }

            // chuoi chua cac phep toan co ban
            string operators = "+-x%";

            // xu ly khi o nhap dang trong
            if (string.IsNullOrEmpty(text))
            {
                // cho phep nhap so hoac dau tru (-) dau tien
                if (!operators.Contains(btnText) || btnText == "-")
                {
                    textbox_input.Text = btnText;
                }
                return;
            }

            // xu ly khi o nhap da co du lieu
            char lastChar = text[text.Length - 1]; // lay ky tu cuoi cung

            bool lastIsOperator = operators.Contains(lastChar); // ky tu cuoi co phai la dau?
            bool btnIsOperator = operators.Contains(btnText);   // nut vua bam co phai la dau?

            if (lastIsOperator && btnIsOperator)
            {

                // neu man hinh chi dang co duy nhat dau '-' ma bam tiep dau khac -> khong lam gi ca
                if (text == "-" && btnText != "-")
                    return;

                // bam 2 dau lien tiep (vd: "5+" bam tiep "-") -> thay dau "+" bang "-"
                textbox_input.Text = text.Substring(0, text.Length - 1) + btnText;
            }
            else
            {
                // nhap so sau dau ("5+" bam "2" -> "5+2") hoac nhap so tiep theo -> noi chuoi
                textbox_input.Text += btnText;
            }
        }



        private void TinhKetQua()
        {
            string text = textbox_input.Text.Trim();
            if (string.IsNullOrEmpty(text)) return;

            string operators = "+-x%";

            // cat bo dau du thua o cuoi phep toan
            while (text.Length > 0 && operators.Contains(text[^1]))
            {
                text = text[..^1];
            }

            if (string.IsNullOrEmpty(text)) return;

            List<double> numbers = new List<double>();
            List<char> sympols = new List<char>();

            // tach bieu thuc thanh cac so va cac phep toan
            string currentNum = "";
            for (int i = 0; i < text.Length; i++)
            {
                char character = text[i];

                // ho tro so am o dau bieu thuc
                if (i == 0 && character == '-')
                {
                    currentNum += character;
                    continue;
                }

                if (operators.Contains(character))
                {
                    if (!string.IsNullOrEmpty(currentNum))
                    {
                        numbers.Add(double.Parse(currentNum));
                        currentNum = "";
                    }
                    sympols.Add(character);
                }
                else
                {
                    currentNum += character;
                }
            }

            if (!string.IsNullOrEmpty(currentNum))
            {
                numbers.Add(double.Parse(currentNum));
            }

            if (numbers.Count == 0) return;

            // tinh nhan va chia tu trai sang phai truoc
            for (int i = 0; i < sympols.Count; i++)
            {
                if (sympols[i] == 'x' || sympols[i] == '%')
                {
                    double a = numbers[i];
                    double b = numbers[i + 1];
                    double res = 0;

                    if (sympols[i] == 'x')
                    {
                        res = a * b;
                    }
                    else if (sympols[i] == '%')
                    {
                        if (b == 0)
                        {
                            MessageBox.Show("Không thể chia cho 0!", "Lỗi toán học");
                            return;
                        }
                        res = a / b;
                    }

                    numbers[i] = res;        // cap nhat ket qua vao vi tri so dau
                    numbers.RemoveAt(i + 1);  // xoa so thu hai
                    sympols.RemoveAt(i);         // xoa dau da tinh
                    i--;                      // lui chi so de kiem tra tiep
                }
            }

            // tinh cong va tru tu trai sang phai
            for (int i = 0; i < sympols.Count; i++)
            {
                double a = numbers[i];
                double b = numbers[i + 1];
                double result = 0;

                if (sympols[i] == '+')
                    result = a + b;
                else if (sympols[i] == '-')
                    result = a - b;

                numbers[i] = result;
                numbers.RemoveAt(i + 1);
                sympols.RemoveAt(i);
                i--;
            }

            // hien thi ket qua cua phep tinh
            textbox_output.Text = numbers[0].ToString();
        }

    }
}