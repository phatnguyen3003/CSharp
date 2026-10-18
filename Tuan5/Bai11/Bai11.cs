namespace Bai11
{
    public partial class Bai11 : Form
    {
        public Bai11()
        {
            InitializeComponent();

            for (int exerciseNumber = 1; exerciseNumber <= 10; exerciseNumber++)
            {
                var menuItem = new ToolStripMenuItem($"Bài {exerciseNumber}")
                {
                    Name = $"menu_bai_{exerciseNumber}",
                    Tag = exerciseNumber
                };
                menuItem.Click += exerciseMenuItem_Click;
                menu_baitap.Items.Add(menuItem);
            }

            Text = "Danh sách bài tập";
        }

        private void exerciseMenuItem_Click(object? sender, EventArgs e)
        {
            if (sender is not ToolStripMenuItem menuItem || menuItem.Tag is not int exerciseNumber)
            {
                return;
            }

            Form exerciseForm;
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

            exerciseForm.Show(this);
        }

    }
}
