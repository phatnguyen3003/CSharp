using System.Globalization;
using System.Text;

namespace Bai6
{
    public partial class Form1 : Form
    {
        // Khoi tao form va tao san cac node tu A den Z tren TreeView
        public Form1()
        {
            InitializeComponent();

            for (char letter = 'A'; letter <= 'Z'; letter++)
            {
                treeview.Nodes.Add(letter.ToString());
            }

            // Dang ky su kien cho cac nut bam
            btn_add.Click += btn_add_Click;
            btn_exit.Click += btn_exit_Click;
        }

        // Xu ly su kien them ho ten vao nhom chu cai tuong ung tren TreeView
        private void btn_add_Click(object? sender, EventArgs e)
        {
            string firstName = textbox_firstname.Text.Trim();
            string lastName = textbox_lastname.Text.Trim();

            // Kiem tra xem nguoi dung da nhap du ho va ten chua
            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ họ và tên.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lay chu cai dau tien cua ten (da xu ly dau tieng Viet)
            char initial = GetInitialLetter(firstName);
            if (initial < 'A' || initial > 'Z')
            {
                MessageBox.Show("Tên phải bắt đầu bằng một chữ cái từ A đến Z.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Xac dinh chi so node cua chu cai tren TreeView
            int letterIndex = initial - 'A';
            if (letterIndex < 0 || letterIndex >= treeview.Nodes.Count)
            {
                MessageBox.Show("Không tìm thấy nhóm chữ cái phù hợp.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Them ho ten vao node con cua chu cai tuong ung va mo rong node do
            TreeNode letterNode = treeview.Nodes[letterIndex];
            string fullName = $"{firstName}, {lastName}";
            TreeNode personNode = letterNode.Nodes.Add(fullName);
            letterNode.Expand();
            treeview.SelectedNode = personNode;

            // Lam sach o nhap lieu va dua con tro ve o ten
            textbox_firstname.Clear();
            textbox_lastname.Clear();
            textbox_firstname.Focus();
        }

        // Phuong thuc xu ly tach chu cai dau tien va loai bo dau tieng Viet chuan xac
        private static char GetInitialLetter(string firstName)
        {
            string normalized = firstName.Trim().Normalize(NormalizationForm.FormD);
            char firstCharacter = normalized[0];

            // Xu ly dac biet cho chu cai 'đ' hoac 'Đ'
            if (firstCharacter == 'đ' || firstCharacter == 'Đ')
            {
                return 'D';
            }

            // Duyet qua chuoi da chuan hoa de lay chu cai goc (khong dau)
            foreach (char character in normalized)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(character) != UnicodeCategory.NonSpacingMark)
                {
                    return char.ToUpperInvariant(character);
                }
            }

            return '\0';
        }

        // Dong ung dung
        private void btn_exit_Click(object? sender, EventArgs e)
        {
            Close();
        }
    }
}