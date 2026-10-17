namespace Bai7
{
    public partial class Form1 : Form
    {
        private readonly ContextMenuStrip studentContextMenu = new();

        public Form1()
        {
            InitializeComponent();

            Combo_dantoc.DropDownStyle = ComboBoxStyle.DropDownList;
            Combo_dantoc.Items.AddRange(new object[]
            {
                "Kinh", "Tày", "Thái", "Hoa", "Khmer", "Mường", "Nùng",
                "H'Mông", "Dao", "Gia Rai", "Ê Đê", "Ba Na", "Chăm"
            });

            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.MultiSelect = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.ContextMenuStrip = studentContextMenu;

            studentContextMenu.Items.Add("Xóa sinh viên", null, context_delete_Click);
            dataGridView1.CellMouseDown += dataGridView1_CellMouseDown;
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
            btn_them.Click += btn_them_Click;
            btn_sua.Click += btn_sua_Click;
            btn_xoa.Click += btn_xoa_Click;
            FormClosing += Form1_FormClosing;
        }

        private void btn_them_Click(object? sender, EventArgs e)
        {
            string name = TextBox_name.Text.Trim();
            string studentId = TextBox_mssv.Text.Trim();

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(studentId))
            {
                MessageBox.Show("Vui lòng nhập họ tên và mã sinh viên.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                string existingId = Convert.ToString(dataGridView1.Rows[i].Cells["MaSV"].Value) ?? "";
                if (string.Equals(existingId, studentId, StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("Mã sinh viên đã tồn tại.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    TextBox_mssv.Focus();
                    TextBox_mssv.SelectAll();
                    return;
                }
            }

            string gender = GetSelectedGender();
            string languages = GetSelectedLanguages();
            string ethnicity = Combo_dantoc.SelectedItem?.ToString() ?? "";

            dataGridView1.Rows.Add(name, studentId, gender, languages, ethnicity);
            ClearInputs();
        }

        private void btn_sua_Click(object? sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn sinh viên cần sửa.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(TextBox_name.Text))
            {
                MessageBox.Show("Vui lòng nhập họ tên.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TextBox_name.Focus();
                return;
            }

            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
            selectedRow.Cells["HoTen"].Value = TextBox_name.Text.Trim();
            selectedRow.Cells["GioiTinh"].Value = GetSelectedGender();
            selectedRow.Cells["NgoaiNgu"].Value = GetSelectedLanguages();
            selectedRow.Cells["DanToc"].Value = Combo_dantoc.SelectedItem?.ToString() ?? "";

            MessageBox.Show("Đã cập nhật thông tin sinh viên.", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_xoa_Click(object? sender, EventArgs e)
        {
            DeleteSelectedStudent();
        }

        private void context_delete_Click(object? sender, EventArgs e)
        {
            DeleteSelectedStudent();
        }

        private void DeleteSelectedStudent()
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn sinh viên cần xóa.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string studentId = Convert.ToString(
                dataGridView1.SelectedRows[0].Cells["MaSV"].Value) ?? "";
            DialogResult result = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa sinh viên có mã {studentId}?",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                dataGridView1.Rows.Remove(dataGridView1.SelectedRows[0]);
                ClearInputs();
            }
        }

        private void dataGridView1_CellMouseDown(object? sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                dataGridView1.ClearSelection();
                dataGridView1.Rows[e.RowIndex].Selected = true;
                dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells[0];
            }
        }

        private void dataGridView1_SelectionChanged(object? sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                return;
            }

            DataGridViewRow row = dataGridView1.SelectedRows[0];
            TextBox_name.Text = Convert.ToString(row.Cells["HoTen"].Value) ?? "";
            TextBox_mssv.Text = Convert.ToString(row.Cells["MaSV"].Value) ?? "";

            string gender = Convert.ToString(row.Cells["GioiTinh"].Value) ?? "";
            Radio_Nam.Checked = gender == Radio_Nam.Text;
            Radio_nu.Checked = gender == Radio_nu.Text;

            string languages = Convert.ToString(row.Cells["NgoaiNgu"].Value) ?? "";
            CheckBox_anh.Checked = languages.Contains(CheckBox_anh.Text);
            CheckBox_phap.Checked = languages.Contains(CheckBox_phap.Text);
            CheckBox_hoa.Checked = languages.Contains(CheckBox_hoa.Text);

            string ethnicity = Convert.ToString(row.Cells["DanToc"].Value) ?? "";
            Combo_dantoc.SelectedItem = ethnicity;
        }

        private void Form1_FormClosing(object? sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn đóng chương trình?",
                "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
            {
                e.Cancel = true;
            }
        }

        private string GetSelectedGender()
        {
            if (Radio_Nam.Checked)
            {
                return Radio_Nam.Text;
            }

            if (Radio_nu.Checked)
            {
                return Radio_nu.Text;
            }

            return "";
        }

        private string GetSelectedLanguages()
        {
            string languages = "";

            if (CheckBox_anh.Checked)
            {
                languages += CheckBox_anh.Text + ", ";
            }

            if (CheckBox_phap.Checked)
            {
                languages += CheckBox_phap.Text + ", ";
            }

            if (CheckBox_hoa.Checked)
            {
                languages += CheckBox_hoa.Text + ", ";
            }

            if (languages.Length > 0)
            {
                languages = languages.Substring(0, languages.Length - 2);
            }

            return languages;
        }

        private void ClearInputs()
        {
            TextBox_name.Clear();
            TextBox_mssv.Clear();
            Radio_Nam.Checked = false;
            Radio_nu.Checked = false;
            CheckBox_anh.Checked = false;
            CheckBox_phap.Checked = false;
            CheckBox_hoa.Checked = false;
            Combo_dantoc.SelectedIndex = -1;
            dataGridView1.ClearSelection();
        }
    }
}
