using System.Windows.Forms;

namespace Bai3
{
    public partial class Bai3 : Form
    {


        /*
            HO = {"Lê", "Nguyễn", "Lý", "Trần", "Lâm", "Hồ", "Lai", "Huỳnh", "La"}

            TENLOT = {"Quang", "Thành", "Ngọc", "Anh", Xuân", "Bảo", "Cẩm", "Thị", "Kim", "Thái", "Hồng"}

            TEN = {"Hà", "Danh", "Sơn", "Mai", "Thắng", "Kỳ", "Thành", "Lâm", "Tâm", "Phụng", "Thắm"}
         
         */

        string[] surname = { "Lê", "Nguyễn", "Lý", "Trần", "Lâm", "Hồ", "Lai", "Huỳnh", "La" };
        string[] middle_name = { "Quang", "Thành", "Ngọc", "Anh", "Xuân", "Bảo", "Cẩm", "Thị", "Kim", "Thái", "Hồng" };
        string[] name = { "Hà", "Danh", "Sơn", "Mai", "Thắng", "Kỳ", "Thành", "Lâm", "Tâm", "Phụng", "Thắm" };


        List<string> name_list = new List<string>();


        public Bai3()
        {
            InitializeComponent();
            listbox.SelectionMode = SelectionMode.MultiSimple;
        }

        private string random_name()
        {
            string fullname = null;

            Random rd = new Random();

            int index_surname = rd.Next(surname.Length);
            int index_middle_name = rd.Next(middle_name.Length);
            int index_name = rd.Next(name.Length);

            fullname = $"{surname[index_surname]} {middle_name[index_middle_name]} {name[index_name]}";
            return fullname;
        }

        private void btn_random_name_Click(object sender, EventArgs e)
        {
            string name;
            name_list.Clear();
            for (int i = 0; i<50; i++)
            {
                name = random_name();
                name_list.Add(name);
            }
            listbox.Items.Clear();
            listbox.Items.AddRange(name_list.ToArray());
        }

        private void btn_delete_current_selected_Click(object sender, EventArgs e)
        {
            List<string> selectedNames = new List<string>();

            foreach (var item in listbox.SelectedItems)
            {
                selectedNames.Add(item.ToString());
            }

            foreach (string name in selectedNames)
            {
                name_list.Remove(name);
                listbox.Items.Remove(name);
            }

        }

        private void btn_delete_name_Son_Click(object sender, EventArgs e)
        {
            string delete_name = "Sơn";
            List<string> delete_name_list = new List<string>();
            foreach (string name in name_list)
            {
                if (name.EndsWith(delete_name))
                {
                    delete_name_list.Add(name);
                }
            }

            foreach (string name in delete_name_list)
            {
                name_list.Remove(name);
                listbox.Items.Remove(name);
            }
        }

        private void ben_delete_surname_Le_Click(object sender, EventArgs e)
        {
            string delete_surname = "Lê";
            List<string> delete_name_list = new List<string>();
            foreach (string name in name_list)
            {
                if (name.StartsWith(delete_surname))
                {
                    delete_name_list.Add(name);
                }
            }

            foreach (string name in delete_name_list)
            {
                name_list.Remove(name);
                listbox.Items.Remove(name);
            }
        }

        private void btn_upper_current_Click(object sender, EventArgs e)
        {
            List<int> selectedIndex = new List<int>();

            foreach (int index in listbox.SelectedIndices)
            {
                selectedIndex.Add(index);
            }

            foreach (int index in selectedIndex)
            {
                string currentText = listbox.Items[index].ToString();
                string upperText = currentText.ToUpper();

                name_list[index] = upperText;

                // dùng RemoveAt + Insert để thay thế
                listbox.Items.RemoveAt(index);
                listbox.Items.Insert(index, upperText);
            }
        }

        private void btn_lower_current_Click(object sender, EventArgs e)
        {
            List<int> selectedIndex = new List<int>();

            foreach (int index in listbox.SelectedIndices)
            {
                selectedIndex.Add(index);
            }

            foreach (int index in selectedIndex)
            {
                string currentText = listbox.Items[index].ToString();
                string lowerText = currentText.ToLower();

                name_list[index] = lowerText;

                // dùng RemoveAt + Insert để thay thế
                listbox.Items.RemoveAt(index);
                listbox.Items.Insert(index, lowerText);
            }
        }

        private void btn_upper_current_each_Click(object sender, EventArgs e)
        {
            List<int> selectedIndex = new List<int>();

            foreach (int index in listbox.SelectedIndices)
            {
                selectedIndex.Add(index);
            }

            foreach (int index in selectedIndex)
            {
                string currentText = listbox.Items[index].ToString();
                //string upperText = currentText.ToLower();

                string[] words = currentText.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                List<string> strings = new List<string>();
                foreach (string word in words)
                {
                    string word_processed = char.ToUpper(word[0]) + word.Substring(1).ToLower();
                    strings.Add(word_processed);
                }

                string processedText = string.Join(" ", strings);

                // dùng RemoveAt + Insert để thay thế
                listbox.Items.RemoveAt(index);
                listbox.Items.Insert(index, processedText);
            }
        }

        private void btn_delete_all_Click(object sender, EventArgs e)
        {
            name_list.Clear();
            listbox.Items.Clear();
        }

        private void listbox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = listbox.SelectedIndex;

            if (index != -1)
            {
                string currentText = listbox.Items[index].ToString();

                using (FormDetail frm = new FormDetail(currentText))
                {
                    if (frm.ShowDialog(this) == DialogResult.OK)
                    {
                        string newText = frm.UpdatedText;

                        // cap nhat danh sach goc
                        name_list[index] = newText;

                        // cap nhat listbox
                        listbox.Items.RemoveAt(index);
                        listbox.Items.Insert(index, newText);

                        // giu lai selection tai vi tri vua sua
                        listbox.SelectedIndex = index;
                    }
                }
            }
        }

    }

    public class FormDetail : Form
    {
        public string UpdatedText { get; private set; } = string.Empty;

        private TextBox textbox_detail;
        private Button btn_Save;

        public FormDetail(string currentText)
        {
            // Thiet lap thuoc tinh cho Form
            this.Text = "Chỉnh sửa tên";
            this.Width = 350;
            this.Height = 180;
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // Khoi tao TextBox nhap lieu
            textbox_detail = new TextBox();
            textbox_detail.Location = new System.Drawing.Point(20, 25);
            textbox_detail.Width = 290;
            textbox_detail.Text = currentText;

            // Khoi tao Button Luu
            btn_Save = new Button();
            btn_Save.Text = "Lưu";
            btn_Save.Location = new System.Drawing.Point(135, 75);
            btn_Save.Width = 80;
            btn_Save.Height = 30;
            btn_Save.Click += btn_Save_Click;

            // Them cac control vao Form
            this.Controls.Add(textbox_detail);
            this.Controls.Add(btn_Save);
            this.AcceptButton = btn_Save; // Cho phep an Enter de luu nhanh
        }

        private void btn_Save_Click(object? sender, EventArgs e)
        {
            UpdatedText = textbox_detail.Text.Trim();

            // Dong form va tra ve ket qua thanh cong
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
