using System.Globalization;
using ClassLibrary;

namespace Bai8
{
    public partial class Bai8 : Form
    {

        ClassLibrary.winforms_helper helper = new ClassLibrary.winforms_helper();

        // Bien co trang thai kiem tra co dang o che do them moi hay khong
        private bool isAdding;

        // Khoi tao form va thiet lap trang thai ban dau cho DataGridView va cac nut bam
        public Bai8()
        {
            InitializeComponent();

            datagridview.AllowUserToAddRows = false;
            datagridview.MultiSelect = false;
            datagridview.ReadOnly = true;
            datagridview.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            textbox_total.ReadOnly = true;
            SetInputFieldsReadOnly(true);
            btn_save.Enabled = false;
            btn_delete.Enabled = false;

            // Dang ky cac su kien tuong tac cho button va datagridview
            btn_add.Click += btn_add_Click;
            btn_save.Click += btn_save_Click;
            btn_delete.Click += btn_delete_Click;
            btn_exit.Click += btn_exit_Click;
            datagridview.SelectionChanged += datagridview_SelectionChanged;
        }

        // Xu ly su kien nut Them / Huy khi nguoi dung muon them tai khoan moi
        private void btn_add_Click(object? sender, EventArgs e)
        {
            if (isAdding)
            {
                CancelAdding();
                return;
            }

            isAdding = true;
            btn_add.Text = "Hủy";
            btn_save.Enabled = true;
            btn_delete.Enabled = false;
            SetInputFieldsReadOnly(false);
            datagridview.ClearSelection();
            ClearInputs();
            textbox_number.Focus();
        }

        // Xu ly su kien luu thong tin tai khoan moi vao DataGridView sau khi kiem tra hop le
        private void btn_save_Click(object? sender, EventArgs e)
        {
            if (!isAdding)
            {
                return;
            }

            string accountNumber = textbox_number.Text.Trim();
            string customerName = textbox_name.Text.Trim();
            string address = textbox_living_place.Text.Trim();
            string amountText = textbox_number_of_cash.Text.Trim();

            // Kiem tra du lieu dau vao khong duoc de trong
            if (string.IsNullOrWhiteSpace(accountNumber) ||
                string.IsNullOrWhiteSpace(customerName) ||
                string.IsNullOrWhiteSpace(address) ||
                string.IsNullOrWhiteSpace(amountText))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin tài khoản.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiem tra so tien phai la so hop le va khong am
            if (!decimal.TryParse(amountText, NumberStyles.Number, CultureInfo.CurrentCulture, out decimal amount) ||
                amount < 0)
            {
                MessageBox.Show("Số tiền phải là một số hợp lệ không âm.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textbox_number_of_cash.Focus();
                textbox_number_of_cash.SelectAll();
                return;
            }

            // Kiem tra trung lap so tai khoan da ton tai trong bang chua
            for (int i = 0; i < datagridview.Rows.Count; i++)
            {
                string existingAccount = Convert.ToString(
                    datagridview.Rows[i].Cells["SoTaiKhoan"].Value) ?? "";
                if (string.Equals(existingAccount, accountNumber, StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("Số tài khoản đã tồn tại.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textbox_number.Focus();
                    textbox_number.SelectAll();
                    return;
                }
            }

            // Them dong moi vao DataGridView
            datagridview.Rows.Add(
                datagridview.Rows.Count + 1,
                accountNumber,
                customerName,
                address,
                amount.ToString(CultureInfo.CurrentCulture));

            // Cap nhat tong tien va dua form ve trang thai binh thuong
            UpdateTotal();
            isAdding = false;
            btn_add.Text = "Thêm";
            btn_save.Enabled = false;
            SetInputFieldsReadOnly(true);
            datagridview.ClearSelection();
            ClearInputs();
        }

        // Xu ly xoa dong dang duoc chon trong DataGridView
        private void btn_delete_Click(object? sender, EventArgs e)
        {
            if (datagridview.SelectedRows.Count == 0)
            {
                return;
            }

            datagridview.Rows.Remove(datagridview.SelectedRows[0]);
            RenumberRows();
            UpdateTotal();
            datagridview.ClearSelection();
            ClearInputs();
            btn_delete.Enabled = false;
        }

        // Tu dong dien thong tin len cac TextBox khi nguoi dung chon mot dong tren DataGridView
        private void datagridview_SelectionChanged(object? sender, EventArgs e)
        {
            if (isAdding)
            {
                return;
            }

            bool hasSelection = datagridview.SelectedRows.Count > 0;
            btn_delete.Enabled = hasSelection;

            if (!hasSelection)
            {
                return;
            }

            DataGridViewRow row = datagridview.SelectedRows[0];
            textbox_number.Text = Convert.ToString(row.Cells["SoTaiKhoan"].Value) ?? "";
            textbox_name.Text = Convert.ToString(row.Cells["TenKhachHang"].Value) ?? "";
            textbox_living_place.Text = Convert.ToString(row.Cells["DiaChi"].Value) ?? "";
            textbox_number_of_cash.Text = Convert.ToString(row.Cells["SoTien"].Value) ?? "";
        }

        // Danh so thu tu lai cho cac dong trong DataGridView sau khi xoa
        private void RenumberRows()
        {
            for (int i = 0; i < datagridview.Rows.Count; i++)
            {
                datagridview.Rows[i].Cells["STT"].Value = i + 1;
            }
        }

        // Tinh tong so tien cua tat ca cac tai khoan trong bang va hien thi len textbox_total
        private void UpdateTotal()
        {
            decimal total = 0;

            for (int i = 0; i < datagridview.Rows.Count; i++)
            {
                string amountText = Convert.ToString(datagridview.Rows[i].Cells["SoTien"].Value) ?? "0";
                if (decimal.TryParse(amountText, NumberStyles.Number, CultureInfo.CurrentCulture, out decimal amount))
                {
                    total += amount;
                }
            }

            textbox_total.Text = total.ToString("N", CultureInfo.CurrentCulture);
        }

        // Huy qua trinh them moi va khoi phuc lai trang thai ban dau
        private void CancelAdding()
        {
            isAdding = false;
            btn_add.Text = "Thêm";
            btn_save.Enabled = false;
            SetInputFieldsReadOnly(true);
            datagridview.ClearSelection();
            ClearInputs();
        }

        // Thiet lap trang thai chi doc hoac cho phep nhap lieu cho cac o TextBox
        private void SetInputFieldsReadOnly(bool readOnly)
        {
            textbox_number.ReadOnly = readOnly;
            textbox_name.ReadOnly = readOnly;
            textbox_living_place.ReadOnly = readOnly;
            textbox_number_of_cash.ReadOnly = readOnly;
        }

        // Xoa trang noi dung tat ca cac o TextBox nhap lieu
        private void ClearInputs()
        {
            textbox_number.Clear();
            textbox_name.Clear();
            textbox_living_place.Clear();
            textbox_number_of_cash.Clear();
        }

        private void textbox_number_of_cash_KeyPress(object sender, KeyPressEventArgs e)// su dung lai ham key press
        {
            helper.txt_KeyPress(sender, e, true, false);
        }


        // Dong ung dung
        private void btn_exit_Click(object? sender, EventArgs e)
        {
            Close();
        }

        
    }
}