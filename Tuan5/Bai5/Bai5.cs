namespace Bai5
{
    public partial class Form1 : Form
    {
        // Khoi tao form, cai dat che do chon nhieu va nap du lieu mau vao ListBox
        public Form1()
        {
            InitializeComponent();

            listbox.SelectionMode = SelectionMode.MultiSimple;
            listbox.Items.AddRange(new object[] { -1, 23, 3, 3, 8, 0, 17, 28, 39, 140 });

            // Dang ky su kien cho cac nut bấm chuc nang
            btn_sum_all.Click += btn_sum_all_Click;
            btn_delete_FirstEnd.Click += btn_delete_FirstEnd_Click;
            btn_delete_currentSelected.Click += btn_delete_currentSelected_Click;
            btn_add_2.Click += btn_add_2_Click;
            btn_replace_pow.Click += btn_replace_pow_Click;
            btn_even.Click += btn_even_Click;
            btn_odd.Click += btn_odd_Click;
            btn_exit.Click += btn_exit_Click;
        }

        // Tinh tong tat ca cac phan tu trong ListBox va hien thi ket qua
        private void btn_sum_all_Click(object? sender, EventArgs e)
        {
            long sum = 0;

            for (int i = 0; i < listbox.Items.Count; i++)
            {
                sum += Convert.ToInt32(listbox.Items[i]);
            }

            MessageBox.Show($"Tổng các phần tử trong ListBox là: {sum}", "Kết quả",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Xoa phan tu dau tien va phan tu cuoi cung trong ListBox
        private void btn_delete_FirstEnd_Click(object? sender, EventArgs e)
        {
            if (listbox.Items.Count == 0)
            {
                return;
            }

            listbox.Items.RemoveAt(listbox.Items.Count - 1);
            if (listbox.Items.Count > 0)
            {
                listbox.Items.RemoveAt(0);
            }
        }

        // Xoa cac dong dang duoc chon, duyet nguoc tu cuoi ve dau de tranh loi lech index
        private void btn_delete_currentSelected_Click(object? sender, EventArgs e)
        {
            for (int i = listbox.SelectedIndices.Count - 1; i >= 0; i--)
            {
                listbox.Items.RemoveAt(listbox.SelectedIndices[i]);
            }
        }

        // Cong them 2 vao gia tri cua tat ca cac phan tu
        private void btn_add_2_Click(object? sender, EventArgs e)
        {
            for (int i = 0; i < listbox.Items.Count; i++)
            {
                int value = Convert.ToInt32(listbox.Items[i]);
                listbox.Items[i] = value + 2;
            }
        }

        // Thay the moi phan tu bang binh phuong cua chinh no
        private void btn_replace_pow_Click(object? sender, EventArgs e)
        {
            for (int i = 0; i < listbox.Items.Count; i++)
            {
                int value = Convert.ToInt32(listbox.Items[i]);
                listbox.Items[i] = value * value;
            }
        }

        // Goi ham ho tro de chon cac so chan
        private void btn_even_Click(object? sender, EventArgs e)
        {
            SelectByParity(true);
        }

        // Goi ham ho tro de chon cac so le
        private void btn_odd_Click(object? sender, EventArgs e)
        {
            SelectByParity(false);
        }

        // Ham dung chung de chon phan tu chan hoac le dua tren dieu kien dau vao
        private void SelectByParity(bool selectEven)
        {
            listbox.ClearSelected();

            for (int i = 0; i < listbox.Items.Count; i++)
            {
                int value = Convert.ToInt32(listbox.Items[i]);
                if ((value % 2 == 0) == selectEven)
                {
                    listbox.SetSelected(i, true);
                }
            }
        }

        // Dong ung dung
        private void btn_exit_Click(object? sender, EventArgs e)
        {
            Close();
        }
    }
}