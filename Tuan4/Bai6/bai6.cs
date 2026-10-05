using Microsoft.VisualBasic.Logging;

namespace Bai6
{
    public partial class bai6 : Form
    {
        public bai6()
        {
            InitializeComponent();
            this.Load += Form_Load;
            this.FormClosing += Form1_FormClosing;
            TongTien = 0;
            textbox_tongtien.Text = TongTien.ToString();
        }


        // Danh sách chứa 15 nút
        private List<Button> dsNut = new List<Button>();

        private Color mauMacDinh = Color.White; // Màu khi CHƯA CHỌN
        private Color mauDangChon = Color.Blue; // Màu khi ĐANG CHỌN
        private Color MauDaBan = Color.Yellow; // Màu khi ĐÃ BÁN

        private float TongTien = 0; // Biến lưu tổng tiền

        private void Form_Load(object sender, EventArgs e)
        {
            foreach(Control c in tableLayoutPanel1.Controls)
            {
                if (c is Button btn && btn != btn_chon && btn != btn_huy && btn != btn_thoat)
                {
                    dsNut.Add(btn);
                }
            }



            // Thuật toán Bubble Sort 
            for (int i = 0; i < dsNut.Count - 1; i++)
            {
                for (int j = i + 1; j < dsNut.Count; j++)
                {
                    if (dsNut[i].TabIndex > dsNut[j].TabIndex)
                    {
                        Button temp = dsNut[i];
                        dsNut[i] = dsNut[j];
                        dsNut[j] = temp;
                    }
                }
            }

            // Khởi tạo thuộc tính và sự kiện cho 15 nút
            foreach (Button btn in dsNut)
            {
                btn.BackColor = mauMacDinh;
                btn.Tag = false; // false: Chưa chọn, true: Đang chọn
                btn.Click += btn_Click;
            }
        }

        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if(btn==null)
            {
                return;
            }

            bool is_selected = (bool)btn.Tag;

            if(!is_selected)
            {
                btn.BackColor = mauDangChon;
                btn.Tag = true;

                // Lấy chỉ số Index (0 đến 14) trong danh sách
                int index = dsNut.IndexOf(btn);

                // Xác định số hàng (0, 1, 2)
                int hang = index / 5;

                if(hang==0)
                {
                    TongTien +=1000;
                }
                else if(hang==1)
                {
                    TongTien += 1500;
                }
                else if(hang==2)
                {
                    TongTien += 2000;
                }
                textbox_tongtien.Text = TongTien.ToString();
            }
        }

        private void btn_chon_Click(object sender, EventArgs e)
        {
            List<Button> Ds_DangChon = new List<Button>();

            foreach(Button btn in dsNut)
            {
                if ((bool)btn.Tag == true)
                {
                    Ds_DangChon.Add(btn);
                }
            }
            DialogResult r = MessageBox.Show("Bạn có muốn thanh toán?", "Thanh toán",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (r == DialogResult.No)
            {
                return;
            }
            else
            {
                foreach (Button btn in Ds_DangChon)
                {
                    btn.BackColor = MauDaBan;
                }
                TongTien = 0;
                textbox_tongtien.Text = TongTien.ToString();
            }

        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void btn_huy_Click(object sender, EventArgs e)
        {
            foreach (Button btn in dsNut)
            {
                if ((bool)btn.Tag == true && btn.BackColor!=MauDaBan)
                {
                    btn.BackColor = mauMacDinh;
                    btn.Tag = false;
                }
            }
            TongTien = 0;
            textbox_tongtien.Text = TongTien.ToString();
        }


        public void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có muốn thoát?", "Thoát",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (r == DialogResult.No)
                e.Cancel = true;
        }
    }
}
