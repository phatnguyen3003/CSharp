using Classlibrary_for_database;
using System.Data;
using System.Globalization;

namespace Bai8
{
    public partial class Form1 : Form
    {
        // Khai bao cac thong so ket noi SQL Server trong Docker
        private static readonly string Server = "localhost,1433";
        private static readonly string Database = "QLSinhVien";
        private static readonly string User_ID = "sa";
        private static readonly string Password = "SqlServer@2026";
        private static readonly string TrustServer = "True";

        // Khai bao bien DatabaseHelper dung chung va chuoi ket noi hoan chinh
        private readonly DatabaseHelper helper;
        string connectionString = $"Server={Server};Database={Database};User Id={User_ID};Password={Password};TrustServerCertificate={TrustServer};";

        // Phuong thuc khoi tao Form, thiet lap ket noi va dang ky cac su kien
        public Form1()
        {
            helper = new DatabaseHelper(connectionString);
            InitializeComponent();
            Load += Form_Load;
            btn_loc.Click += btn_loc_Click;
        }

        // Su kien khi Form duoc tai: Kiem tra ket noi CSDL va nap danh sach MaMonHoc vao ComboBox
        private async void Form_Load(object? sender, EventArgs e)
        {
            bool isConnected = await helper.TestConnectionAsync();

            if (!isConnected)
            {
                MessageBox.Show(
                    "Không thể kết nối đến cơ sở dữ liệu.",
                    "Lỗi kết nối",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                Close();
                return;
            }
            else
            {
                try
                {
                    // Truy van danh sach MaMonHoc tu bang MonHoc sap xep theo ma
                    DataTable subjects = await helper.GetDataTableAsync(
                        "USE QLSinhVien; SELECT MaMonHoc FROM MonHoc ORDER BY MaMonHoc;");

                    combobox_MaMH.Items.Clear();
                    // Them mot muc trong (tuy chon xem tat ca cac mon) vao dau ComboBox
                    combobox_MaMH.Items.Add(string.Empty);

                    // Duyet qua tung dong va nap MaMonHoc vao ComboBox
                    foreach (DataRow row in subjects.Rows)
                    {
                        string? subjectID = row["MaMonHoc"].ToString();
                        if (!string.IsNullOrEmpty(subjectID))
                        {
                            combobox_MaMH.Items.Add(subjectID);
                        }
                    }

                    // Dat lua chon mac định la muc dau trong va tai toan bo danh sach diem
                    combobox_MaMH.SelectedIndex = 0;
                    await LoadGradesAsync(null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Không thể tải dữ liệu: {ex.Message}",
                        "Lỗi cơ sở dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Su kien khi nhan nut Loc theo MaMonHoc da chon trong ComboBox
        private async void btn_loc_Click(object? sender, EventArgs e)
        {
            // Lay gia tri mon hoc duoc chon, neu la trong thi gan bang null
            string? selectedSubject = combobox_MaMH.SelectedItem?.ToString();
            string? subjectID = string.IsNullOrWhiteSpace(selectedSubject) ? null : selectedSubject;

            try
            {
                // Goi ham tai va hien thi danh sach diem theo ma mon hoc da chon
                await LoadGradesAsync(subjectID);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Không thể lọc dữ liệu: {ex.Message}",
                    "Lỗi cơ sở dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Ham phu tro: Truy van CSDL va do du lieu bang Diem, SinhVien, MonHoc len DataGridView
        private async Task LoadGradesAsync(string? subjectID)
        {
            // Cau lenh SQL ket noi 3 bang (Diem, SinhVien, MonHoc) de lay thong tin chi tiet
            string query = @"
                USE QLSinhVien;
                SELECT sv.HoTen, sv.NgaySinh, mh.TenMonHoc, d.Diem
                FROM Diem AS d
                INNER JOIN SinhVien AS sv ON sv.MaSinhVien = d.MaSinhVien
                INNER JOIN MonHoc AS mh ON mh.MaMonHoc = d.MaMonHoc";

            var parameters = new Dictionary<string, object?>();
            // Neu co chon mon hoc cu the, them dieu kien WHERE vao truy van
            if (subjectID is not null)
            {
                query += " WHERE d.MaMonHoc = @MaMonHoc";
                parameters["@MaMonHoc"] = subjectID;
            }

            query += " ORDER BY sv.HoTen, mh.TenMonHoc;";

            // Thuc thi truy van lay DataTable
            DataTable grades = await helper.GetDataTableAsync(query, parameters);
            datagridview_dulieu.Rows.Clear();

            double total = 0;
            // Duyet qua tung dong ket qua de hien thi len DataGridView va tinh tong diem
            foreach (DataRow grade in grades.Rows)
            {
                // Dinh dang lai ngay sinh thanh chuoi dd/MM/yyyy
                string birthDate = grade["NgaySinh"] is DateTime date
                    ? date.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)
                    : string.Empty;

                object score = grade["Diem"];
                // Neu diem khac null thi cong don vao tong diem
                if (score != DBNull.Value)
                {
                    total += Convert.ToDouble(score, CultureInfo.InvariantCulture);
                }

                // Them dong du lieu vao DataGridView
                datagridview_dulieu.Rows.Add(
                    datagridview_dulieu.Rows.Count + 1, // STT tu tang
                    grade["HoTen"],                       // Ho ten sinh vien
                    birthDate,                            // Ngay sinh da dinh dang
                    grade["TenMonHoc"],                   // Ten mon hoc
                    score == DBNull.Value ? string.Empty : score // Diem so
                );
            }

            // Hien thi tong diem len textbox tuong ung
            textbox_tongdiem.Text = total.ToString("0.##", CultureInfo.CurrentCulture);
        }
    }
}