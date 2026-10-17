namespace Bai4
{
    public partial class Form1 : Form
    {
        // Danh sach tu vung tieng Anh goc
        private readonly List<string> englishWords = new()
        {
            "ability", "about", "above", "accept", "accident", "account", "achieve", "across",
            "action", "active", "activity", "actually", "add", "address", "adult", "advice",
            "afford", "after", "again", "against", "age", "agency", "agent", "agree",
            "air", "all", "allow", "almost", "alone", "along", "already", "also",
            "although", "always", "amazing", "among", "amount", "analysis", "ancient", "and",
            "angry", "animal", "announce", "annual", "another", "answer", "any", "anyone",
            "anything", "appear", "apply", "approach", "area", "argue", "arm", "around",
            "arrive", "art", "article", "artist", "as", "ask", "at", "attack",
            "attention", "audience", "author", "available", "avoid", "away", "baby", "back",
            "bad", "bag", "ball", "bank", "base", "basic", "beautiful", "because"
        };

        // Danh sach nghia tieng Viet tuong ung
        private readonly List<string> vietnameseMeanings = new()
        {
            "khả năng", "về; khoảng", "phía trên", "chấp nhận", "tai nạn", "tài khoản",
            "đạt được", "băng qua", "hành động", "chủ động", "hoạt động", "thực sự",
            "thêm", "địa chỉ", "người trưởng thành", "lời khuyên", "đủ khả năng", "sau",
            "lại; một lần nữa", "chống lại", "tuổi", "cơ quan", "đại lý; đặc vụ", "đồng ý",
            "không khí", "tất cả", "cho phép", "gần như", "một mình", "dọc theo", "đã",
            "cũng", "mặc dù", "luôn luôn", "tuyệt vời", "giữa", "số lượng", "sự phân tích",
            "cổ xưa", "và", "tức giận", "động vật", "thông báo", "hàng năm", "một cái khác",
            "câu trả lời; trả lời", "bất kỳ", "bất cứ ai", "bất cứ điều gì", "xuất hiện",
            "áp dụng", "tiếp cận", "khu vực", "tranh luận", "cánh tay", "xung quanh",
            "đến nơi", "nghệ thuật", "bài viết", "nghệ sĩ", "như; là", "hỏi", "tại; ở",
            "tấn công", "sự chú ý", "khán giả", "tác giả", "có sẵn", "tránh", "xa",
            "em bé", "lưng; quay lại", "xấu", "cái túi", "quả bóng", "ngân hàng", "căn cứ",
            "cơ bản", "xinh đẹp", "bởi vì"
        };

        // Khoi tao form va dang ky cac su kien tuong tac ban dau
        public Form1()
        {
            InitializeComponent();

            // Cau hinh du lieu ban dau cho 2 tab tra cuu
            ConfigureLookup(combobox_tab1, listbox_tab1, englishWords);
            ConfigureLookup(combobox_tab2, listbox_tab2, vietnameseMeanings);

            // Dang ky su kien thay doi van ban, nhan phim Enter va double click
            combobox_tab1.TextChanged += combobox_TextChanged;
            combobox_tab2.TextChanged += combobox_TextChanged;
            combobox_tab1.KeyDown += lookup_KeyDown;
            combobox_tab2.KeyDown += lookup_KeyDown;
            listbox_tab1.KeyDown += lookup_KeyDown;
            listbox_tab2.KeyDown += lookup_KeyDown;
            listbox_tab1.DoubleClick += listbox_tab1_DoubleClick;
            listbox_tab2.DoubleClick += listbox_tab2_DoubleClick;
            btn_exit.Click += btn_exit_Click;
        }

        // Phuong thuc thiet lap du lieu mac dinh cho ComboBox va ListBox
        private void ConfigureLookup(ComboBox comboBox, ListBox listBox, List<string> words)
        {
            comboBox.AutoCompleteMode = AutoCompleteMode.None;
            comboBox.DropDownStyle = ComboBoxStyle.DropDown;
            comboBox.Items.AddRange(words.ToArray());
            listBox.Items.AddRange(words.ToArray());
        }

        // Xu ly su kien TextChanged khi nguoi dung go vao ComboBox
        private void combobox_TextChanged(object? sender, EventArgs e)
        {
            if (ReferenceEquals(sender, combobox_tab1))
            {
                FilterWords(combobox_tab1, listbox_tab1, englishWords);
            }
            else if (ReferenceEquals(sender, combobox_tab2))
            {
                FilterWords(combobox_tab2, listbox_tab2, vietnameseMeanings);
            }
        }

        // Thuat toan loc danh sach tu vung theo tien to (StartsWith) va cap nhat giao dien
        private static void FilterWords(ComboBox comboBox, ListBox listBox, List<string> words)
        {
            string input = comboBox.Text.Trim();
            IEnumerable<string> matches = string.IsNullOrEmpty(input)
                ? words
                : words.Where(word => word.StartsWith(input, StringComparison.CurrentCultureIgnoreCase));

            // Tam dung ve lai giao dien de toi uu hieu nang loc
            listBox.BeginUpdate();
            listBox.Items.Clear();
            listBox.Items.AddRange(matches.ToArray());
            listBox.SelectedIndex = listBox.Items.Count > 0 && !string.IsNullOrEmpty(input) ? 0 : -1;
            listBox.EndUpdate(); // Tiep tuc hien thi giao dien sau khi cap nhat xong
        }

        // Xu ly su kien nhan phim tren ComboBox va ListBox (nhan Enter de tra cuu)
        private void lookup_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
            {
                return;
            }

            e.Handled = true;
            e.SuppressKeyPress = true;

            if (ReferenceEquals(sender, combobox_tab1) || ReferenceEquals(sender, listbox_tab1))
            {
                ShowMeaning(combobox_tab1, listbox_tab1, textbox_tab1, englishWords, vietnameseMeanings);
            }
            else
            {
                ShowMeaning(combobox_tab2, listbox_tab2, textbox_tab2, vietnameseMeanings, englishWords);
            }
        }

        // Su kien double click tren ListBox o tab 1
        private void listbox_tab1_DoubleClick(object? sender, EventArgs e)
        {
            ShowMeaning(combobox_tab1, listbox_tab1, textbox_tab1, englishWords, vietnameseMeanings);
        }

        // Su kien double click tren ListBox o tab 2
        private void listbox_tab2_DoubleClick(object? sender, EventArgs e)
        {
            ShowMeaning(combobox_tab2, listbox_tab2, textbox_tab2, vietnameseMeanings, englishWords);
        }

        // Tim kiem chi so tu vung va hien thi ket qua nghia tuong ung len TextBox
        private static void ShowMeaning(
            ComboBox comboBox,
            ListBox listBox,
            TextBox meaningTextBox,
            List<string> lookupWords,
            List<string> meanings)
        {
            string input = SenderText(comboBox, listBox).Trim();
            if (string.IsNullOrWhiteSpace(input))
            {
                return;
            }

            // Tim chi so tu trung khop chinh xac
            int wordIndex = lookupWords.FindIndex(word =>
                string.Equals(word, input, StringComparison.CurrentCultureIgnoreCase));

            // Neu khong co, tim tu bat dau bang ky tu da nhap
            if (wordIndex < 0)
            {
                wordIndex = lookupWords.FindIndex(word =>
                    word.StartsWith(input, StringComparison.CurrentCultureIgnoreCase));
            }

            // Neu van khong tim thay thi thong bao cho nguoi dung
            if (wordIndex < 0)
            {
                meaningTextBox.Clear();
                MessageBox.Show("Không tìm thấy từ phù hợp.", "Tra từ",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Dong bo ket qua vao ComboBox, ListBox va hien thi nghia len TextBox
            comboBox.SelectedItem = lookupWords[wordIndex];
            listBox.SelectedItem = lookupWords[wordIndex];
            meaningTextBox.Text = meanings[wordIndex];
        }

        // Xac dinh nguon dau vao la tu ComboBox hay tu ListBox dang chon
        private static string SenderText(ComboBox comboBox, ListBox listBox)
        {
            return listBox.Focused && listBox.SelectedItem is string selectedWord
                ? selectedWord
                : comboBox.Text;
        }

        // Xu ly su kien khi bam nut thoat ung dung
        private void btn_exit_Click(object? sender, EventArgs e)
        {
            Close();
        }

        // Lam moi lai bo loc khi nguoi dung chuyen doi giua cac Tab tren giao dien
        private void tabcontrol_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabcontrol.SelectedIndex == 0)
            {
                FilterWords(combobox_tab1, listbox_tab1, englishWords);
            }
            else
            {
                FilterWords(combobox_tab2, listbox_tab2, vietnameseMeanings);
            }
        }
    }
}