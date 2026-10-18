namespace Bai10
{
    public partial class Bai10 : Form
    {
        // Khoi tao doi tuong Timer de thuc hien dem nguoc
        private readonly System.Windows.Forms.Timer countdownTimer = new();

        // Thiet lap thoi gian dem nguoc ban dau la 30 phut
        private TimeSpan remainingTime = TimeSpan.FromMinutes(30);

        // Khoi tao form, hien thi thoi gian mac dinh, cau hinh timer va dang ky cac su kien
        public Bai10()
        {
            InitializeComponent();

            clock.Text = FormatTime(remainingTime);
            countdownTimer.Interval = 1000; // Thiet lap chu ky 1 giay (1000ms)
            countdownTimer.Tick += countdownTimer_Tick;
            btn_start.Click += btn_start_Click;
            FormClosed += Bai10_FormClosed;
        }

        // Xu ly su kien khi nguoi dung bam nut Bat dau: vo hieu hoa nut va kich hoat timer
        private void btn_start_Click(object? sender, EventArgs e)
        {
            btn_start.Enabled = false;
            countdownTimer.Start();
        }

        // Su kien lap lai moi giay khi timer dang chay: giam thoi gian va cap nhat giao dien
        private void countdownTimer_Tick(object? sender, EventArgs e)
        {
            if (remainingTime > TimeSpan.Zero)
            {
                remainingTime -= TimeSpan.FromSeconds(1);
            }

            if (remainingTime < TimeSpan.Zero)
            {
                remainingTime = TimeSpan.Zero;
            }

            clock.Text = FormatTime(remainingTime);

            // Dung timer khi thoi gian dem nguoc ve 0
            if (remainingTime == TimeSpan.Zero)
            {
                countdownTimer.Stop();
            }
        }

        // Dinh dang doi tuong TimeSpan thanh chuoi hien thi dang phut:giay (mm:ss)
        private static string FormatTime(TimeSpan time)
        {
            return time.ToString(@"mm\:ss");
        }

        // Dung chuong trinh
        private void Bai10_FormClosed(object? sender, FormClosedEventArgs e)
        {
            countdownTimer.Stop();
            countdownTimer.Dispose();
        }
    }
}