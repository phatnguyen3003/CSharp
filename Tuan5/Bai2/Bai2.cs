namespace Bai2
{
    public partial class Bai2 : Form
    {
        // lop luu thong tin sinh vien
        private class StudentInfo
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public string Address { get; set; }

            public StudentInfo(string id, string name, string address)
            {
                Id = id;
                Name = name;
                Address = address;
            }
        }

        // danh sach ten lop mac dinh ban dau
        private static readonly string[] InitialClasses =
        {
            "Công nghệ thông tin",
            "Kế toán",
            "Quản trị kinh doanh"
        };

        public Bai2()
        {
            InitializeComponent();

            // dang ky cac su kien cho control
            checkbox_add_class.CheckedChanged += checkbox_add_class_CheckedChanged;
            btn_add_class.Click += btn_add_class_Click;
            btn_update.Click += btn_update_Click;
            btn_delete.Click += btn_delete_Click;
            combobox_class.SelectedIndexChanged += combobox_class_SelectedIndexChanged;
            treeview_main.AfterSelect += treeview_main_AfterSelect;

            // thiet lap trang thai giao dien ban dau
            groupBox1.Visible = false;
            combobox_class.DropDownStyle = ComboBoxStyle.DropDownList;

            // them cac lop ban dau vao giao dien
            foreach (string className in InitialClasses)
            {
                AddClassNode(className);
            }

            // chon san lop dau tien neu co
            if (combobox_class.Items.Count > 0)
            {
                combobox_class.SelectedIndex = 0;
            }
        }

        private void checkbox_add_class_CheckedChanged(object? sender, EventArgs e)
        {
            // an hien khung nhap ten lop moi
            groupBox1.Visible = checkbox_add_class.Checked;
            if (!checkbox_add_class.Checked)
            {
                textbox_class_name.Clear();
            }
        }

        private void btn_add_class_Click(object? sender, EventArgs e)
        {
            // kiem tra ten lop hop le va them moi
            string className = textbox_class_name.Text.Trim();
            if (string.IsNullOrWhiteSpace(className))
            {
                MessageBox.Show("Vui lòng nhập tên lớp.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textbox_class_name.Focus();
                return;
            }

            // kiem tra ten lop da ton tai chua
            bool daTonTai = false;

            foreach (TreeNode node in treeview_main.Nodes)
            {
                if (string.Equals(node.Text, className, StringComparison.OrdinalIgnoreCase))
                {
                    daTonTai = true;
                    break;
                }
            }

            if (daTonTai)
            {
                MessageBox.Show("Tên lớp đã tồn tại.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textbox_class_name.Focus();
                textbox_class_name.SelectAll();
                return;
            }

            // them lop vao cay va combobox
            AddClassNode(className);
            combobox_class.SelectedIndex = combobox_class.Items.Count - 1;
            textbox_class_name.Clear();
        }

        private void btn_update_Click(object? sender, EventArgs e)
        {
            // doc thong tin sinh vien tu o nhap
            string studentId = textbox_idnumber.Text.Trim();
            string studentName = textbox_name.Text.Trim();
            string address = textbox_livingplace.Text.Trim();

            if (string.IsNullOrWhiteSpace(studentId) ||
                string.IsNullOrWhiteSpace(studentName) ||
                string.IsNullOrWhiteSpace(address))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ mã sinh viên, họ tên và địa chỉ.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (combobox_class.SelectedItem is not string selectedClass)
            {
                MessageBox.Show("Vui lòng chọn lớp cần thêm sinh viên.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // kiem tra trung ma sinh vien trong toan bo cay
            bool duplicateId = false;

            foreach (TreeNode classItem in treeview_main.Nodes)
            {
                foreach (TreeNode studentItem in classItem.Nodes)
                {
                    if (studentItem.Tag is StudentInfo student)
                    {
                        if (string.Equals(student.Id, studentId,
                            StringComparison.OrdinalIgnoreCase))
                        {
                            duplicateId = true;
                            break;
                        }
                    }
                }

                if (duplicateId)
                {
                    break;
                }
            }

            if (duplicateId)
            {
                MessageBox.Show("Mã sinh viên đã tồn tại.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textbox_idnumber.Focus();
                textbox_idnumber.SelectAll();
                return;
            }

            // tim node lop duoc chi dinh de them sinh vien
            TreeNode? classNode = null;

            foreach (TreeNode node in treeview_main.Nodes)
            {
                if (string.Equals(node.Text, selectedClass,
                    StringComparison.Ordinal))
                {
                    classNode = node;
                    break;
                }
            }

            if (classNode is null)
            {
                MessageBox.Show("Không tìm thấy lớp đã chọn.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // tao node va thong tin chi tiet cho sinh vien
            StudentInfo studentInfo = new StudentInfo(
                studentId, studentName, address);

            TreeNode studentNode = new TreeNode(studentId);
            studentNode.Tag = studentInfo;

            studentNode.Nodes.Add("Họ tên: " + studentName);
            studentNode.Nodes.Add("Địa chỉ: " + address);

            // gan sinh vien vao lop va hien thi
            classNode.Nodes.Add(studentNode);
            classNode.Expand();

            treeview_main.SelectedNode = studentNode;
        }

        private void btn_delete_Click(object? sender, EventArgs e)
        {
            // xoa node sinh vien duoc chon sau khi xac nhan
            TreeNode? selectedNode = treeview_main.SelectedNode;
            if (selectedNode?.Tag is not StudentInfo ||
                selectedNode.Parent?.Parent is not null)
            {
                MessageBox.Show("Vui lòng chọn node mã sinh viên cần xóa.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa sinh viên {selectedNode.Text}?",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                selectedNode.Remove();
                ClearStudentFields();
            }
        }

        private void combobox_class_SelectedIndexChanged(object? sender, EventArgs e)
        {
            // dong bo lua chon lop tu combobox sang treeview
            if (combobox_class.SelectedItem is not string selectedClass)
            {
                return;
            }

            TreeNode classNode = null;

            foreach (TreeNode node in treeview_main.Nodes)
            {
                if (string.Equals(node.Text, selectedClass, StringComparison.Ordinal))
                {
                    classNode = node;
                    break;
                }
            }

            if (classNode is not null)
            {
                treeview_main.SelectedNode = classNode;
            }
        }

        private void treeview_main_AfterSelect(object? sender, TreeViewEventArgs e)
        {
            // hien thi thong tin len o nhap khi chon node sinh vien
            if (e.Node?.Tag is StudentInfo student)
            {
                textbox_idnumber.Text = student.Id;
                textbox_name.Text = student.Name;
                textbox_livingplace.Text = student.Address;
                return;
            }

            ClearStudentFields();
        }

        private void AddClassNode(string className)
        {
            // ham phu tro them lop moi vao treeview va combobox
            treeview_main.Nodes.Add(new TreeNode(className));
            combobox_class.Items.Add(className);
        }

        private void ClearStudentFields()
        {
            // xoa trang cac o nhap thong tin sinh vien
            textbox_idnumber.Clear();
            textbox_name.Clear();
            textbox_livingplace.Clear();
        }
    }
}