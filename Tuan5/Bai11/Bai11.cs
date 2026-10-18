namespace Bai11
{
    public partial class Bai11 : Form
    {
        // Khoi tao form va tu dong tao danh sach menu item tu Bai 1 den Bai 10
        public Bai11()
        {
            InitializeComponent();

            for (int exerciseNumber = 1; exerciseNumber <= 10; exerciseNumber++)
            {
                // Tao menu item, dat ten va luu so thu tu bai tap vao thuoc tinh Tag
                var menuItem = new ToolStripMenuItem($"Bài {exerciseNumber}")
                {
                    Name = $"menu_bai_{exerciseNumber}",
                    Tag = exerciseNumber
                };

                // Dang ky su kien Click va them vao thanh menu chinh
                menuItem.Click += exerciseMenuItem_Click;
                menu_baitap.Items.Add(menuItem);
            }

            // Thiet lap tieu de cho form chinh
            Text = "Danh sách bài tập";
        }

        // Xu ly su kien khi nguoi dung chon mot muc bai tap tren menu
        private void exerciseMenuItem_Click(object? sender, EventArgs e)
        {
            // Kiem tra tinh hop le cua sender va lay so thu tu bai tap tu Tag
            if (sender is not ToolStripMenuItem menuItem || menuItem.Tag is not int exerciseNumber)
            {
                return;
            }

            Form exerciseForm;

            // Su dung cau truc switch de khoi tao form tuong ung cua tung namespace bai tap
            switch (exerciseNumber)
            {
                case 1:
                    exerciseForm = new global::Bai1.Bai1();
                    break;
                case 2:
                    exerciseForm = new global::Bai2.Bai2();
                    break;
                case 3:
                    exerciseForm = new global::Bai3.Bai3();
                    break;
                case 4:
                    exerciseForm = new global::Bai4.Form1();
                    break;
                case 5:
                    exerciseForm = new global::Bai5.Form1();
                    break;
                case 6:
                    exerciseForm = new global::Bai6.Form1();
                    break;
                case 7:
                    exerciseForm = new global::Bai7.Form1();
                    break;
                case 8:
                    exerciseForm = new global::Bai8.Bai8();
                    break;
                case 9:
                    exerciseForm = new global::Bai9.Bai9();
                    break;
                case 10:
                    exerciseForm = new global::Bai10.Bai10();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(exerciseNumber));
            }

            // Hien thi form bai tap duoc chon theo dang khong chan (Modeless)
            exerciseForm.Show(this);
        }
    }
}