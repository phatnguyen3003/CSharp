namespace Bai9
{
    public partial class Bai9 : Form
    {
        // Khoi tao form, cai dat che do chon nhieu nang cao va dang ky cac su kien
        public Bai9()
        {
            InitializeComponent();

            listbox_A.SelectionMode = SelectionMode.MultiExtended;
            listbox_B.SelectionMode = SelectionMode.MultiExtended;

            btn_add.Click += btn_add_Click;
            btn_switch_class_A.Click += btn_switch_class_A_Click;
            btn_switch_class_B.Click += btn_switch_class_B_Click;
            btn_delete.Click += btn_delete_Click;
            btn_exit.Click += btn_exit_Click;
        }

        // Mo form con de nhap thong tin hoc vien moi thong qua callback
        private void btn_add_Click(object? sender, EventArgs e)
        {
            using var addStudentForm = new Form1(AddStudent);
            addStudentForm.ShowDialog(this);
        }

        // Them hoc vien vao ListBox cua lop tuong ung
        private void AddStudent(string name, string className)
        {
            if (className == "Lớp A")
            {
                listbox_A.Items.Add(name);
            }
            else if (className == "Lớp B")
            {
                listbox_B.Items.Add(name);
            }
        }

        // Chuyen hoc vien dang chon tu Lop B sang Lop A
        private void btn_switch_class_A_Click(object? sender, EventArgs e)
        {
            MoveSelectedStudents(listbox_B, listbox_A);
        }

        // Chuyen hoc vien dang chon tu Lop A sang Lop B
        private void btn_switch_class_B_Click(object? sender, EventArgs e)
        {
            MoveSelectedStudents(listbox_A, listbox_B);
        }

        // Ham dung chung de di chuyen cac hoc vien duoc chon giua hai ListBox
        private static void MoveSelectedStudents(ListBox source, ListBox destination)
        {
            if (source.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn học viên cần chuyển.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Luu cac item dang chon vao mang tam de tranh loi thay doi tap hop khi thao tac
            object[] selectedStudents = new object[source.SelectedItems.Count];
            source.SelectedItems.CopyTo(selectedStudents, 0);

            for (int i = 0; i < selectedStudents.Length; i++)
            {
                destination.Items.Add(selectedStudents[i]);
            }

            // Duyet nguoc de xoa cac phan tu da chuyen khoi danh sach nguon an toan
            for (int i = source.SelectedIndices.Count - 1; i >= 0; i--)
            {
                source.Items.RemoveAt(source.SelectedIndices[i]);
            }
        }

        // Xoa cac hoc vien dang duoc chon o ca hai ListBox
        private void btn_delete_Click(object? sender, EventArgs e)
        {
            if (listbox_A.SelectedItems.Count == 0 && listbox_B.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn học viên cần xóa.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            RemoveSelectedItems(listbox_A);
            RemoveSelectedItems(listbox_B);
        }

        // Ham ho tro xoa cac dong dang chon trong ListBox theo chieu duyet nguoc index
        private static void RemoveSelectedItems(ListBox listBox)
        {
            for (int i = listBox.SelectedIndices.Count - 1; i >= 0; i--)
            {
                listBox.Items.RemoveAt(listBox.SelectedIndices[i]);
            }
        }

        // Hien thi hop thoai xac nhan truoc khi thoat chuong trinh
        private void btn_exit_Click(object? sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn kết thúc chương trình?",
                "Xác nhận kết thúc", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Close();
            }
        }
    }
}