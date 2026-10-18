namespace Bai9
{
    public partial class Form1 : Form
    {
        // Delegate luu callback de truyen thong tin hoc vien ve form chinh
        private readonly Action<string, string> addStudent;

        // Khoi tao form con, nhan callback va cai dat du lieu mac dinh cho ComboBox lop
        public Form1(Action<string, string> addStudent)
        {
            InitializeComponent();

            this.addStudent = addStudent;
            combo_class.DropDownStyle = ComboBoxStyle.DropDownList;
            combo_class.Items.AddRange(new object[] { "Lớp A", "Lớp B" });
            combo_class.SelectedIndex = 0;

            // Dang ky su kien cho cac nut bam tren form con
            btn_update.Click += btn_update_Click;
            btn_back.Click += btn_back_Click;
        }

        // Xu ly su kien khi nguoi dung bam nut Cap nhat de them hoc vien moi
        private void btn_update_Click(object? sender, EventArgs e)
        {
            string studentName = textbox_name.Text.Trim();

            // Kiem tra xem nguoi dung da nhap ho ten hoc vien chua
            if (string.IsNullOrWhiteSpace(studentName))
            {
                MessageBox.Show("Vui lòng nhập họ và tên học viên.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textbox_name.Focus();
                return;
            }

            // Kiem tra xem da chon lop hay chua
            if (combo_class.SelectedItem is not string className)
            {
                MessageBox.Show("Vui lòng chọn lớp.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                combo_class.Focus();
                return;
            }

            // Goi callback de truyen du lieu ve form chinh, sau do lam moi o nhap lieu
            addStudent(studentName, className);
            textbox_name.Clear();
            textbox_name.Focus();
        }

        // Dong form con khi nguoi dung bam nut quay lai
        private void btn_back_Click(object? sender, EventArgs e)
        {
            Close();
        }
    }
}