namespace Bai1;
using ClassLibrary;
using SharedLibs;

public partial class Bai1 : Form
{
    // khoi tao doi tuong ho tro winforms
    ClassLibrary.winforms_helper helper = new ClassLibrary.winforms_helper();

    // danh sach luu uoc so
    List<int> DsUocSo = new List<int>();

    // danh sach luu cac so da nhap
    List<int> DsSo = new List<int>();

    public Bai1()
    {
        InitializeComponent();

        // dang ky su kien va cap nhat giao dien ban dau
        textbox_input.KeyPress += textbox_keyPress;
        update();
    }

    private void textbox_keyPress(object sender, KeyPressEventArgs e)
    {
        // gioi han ky tu nhap vao textbox
        TextBox textBox = sender as TextBox;
        if (textBox != null)
        {
            helper.txt_KeyPress(sender, e, true, false);
        }
    }

    private List<int> Find_divisor(int so)
    {
        // tim danh sach cac uoc so cua mot so
        List<int> Ds_so = new List<int>();
        for (int i = 1; i <= so; i++)
        {
            if (so % i == 0)
            {
                Ds_so.Add(i);
            }
        }
        return Ds_so;
    }

    private int Sum_Prime_Divisor(List<int> Ds_so)
    {
        // tinh tong cac uoc so la so nguyen to
        int sum = 0;
        for (int i = 0; i < Ds_so.Count; i++)
        {
            if (SharedLibs.calculating_helper.IsPrime(Ds_so[i]))
            {
                sum += Ds_so[i];
            }
        }
        return sum;
    }

    private int Sum_Divisor(List<int> Ds_so, bool isEven = false)
    {
        // tinh tong cac uoc so, ho tro tinh tong uoc chan
        int sum = 0;
        if (!isEven)
        {
            for (int i = 0; i < Ds_so.Count; i++)
            {
                sum += Ds_so[i];
            }
        }
        else
        {
            for (int i = 0; i < Ds_so.Count; i++)
            {
                if (Ds_so[i] % 2 == 0)
                {
                    sum += Ds_so[i];
                }
            }
        }
        return sum;
    }

    private void update()
    {
        // bat hoac tat cac nut chuc nang tuy thuoc vao combobox
        if (combobox_list_numbers.SelectedIndex == -1)
        {
            btn_sum.Enabled = false;
            btn_sum_even.Enabled = false;
            btn_count_prime.Enabled = false;
        }
        else
        {
            btn_sum.Enabled = true;
            btn_sum_even.Enabled = true;
            btn_count_prime.Enabled = true;
        }
    }

    private void btn_update_Click(object sender, EventArgs e)
    {
        // them so nguyen duong vao danh sach va combobox
        string text = textbox_input.Text.Trim();
        int so = 0;
        if (!string.IsNullOrEmpty(text))
        {
            while ((so = int.Parse(text)) < 0)
            {
                MessageBox.Show("Vui lòng nhập số nguyên dương!");
                return;
            }
        }

        if (!DsSo.Contains(so))
        {
            DsSo.Add(so);
            combobox_list_numbers.Items.Add(so);
        }
        update();
    }

    private void combobox_list_numbers_SelectedIndexChanged(object sender, EventArgs e)
    {
        // xu ly khi chon so de tim uoc va hien thi len listbox
        string text = combobox_list_numbers.SelectedItem.ToString();
        if (!string.IsNullOrEmpty(text))
        {
            DsUocSo = Find_divisor(int.Parse(text));
        }
        listbox_result.Items.Clear();
        for (int i = 0; i < DsUocSo.Count; i++)
        {
            listbox_result.Items.Add(DsUocSo[i]);
        }
        update();
    }

    private void btn_sum_Click(object sender, EventArgs e)
    {
        // hien thi tong cac uoc so
        if (DsSo.Count > 0)
        {
            int sum = Sum_Divisor(DsUocSo, false);
            MessageBox.Show($"Tổng các ước số của {combobox_list_numbers.SelectedItem} là: {sum}");
        }
    }

    private void btn_sum_even_Click(object sender, EventArgs e)
    {
        // hien thi tong cac uoc so chan
        if (DsSo.Count > 0)
        {
            int sum = Sum_Divisor(DsUocSo, true);
            MessageBox.Show($"Tổng các ước số chẵn của {combobox_list_numbers.SelectedItem} là: {sum}");
        }
    }

    private void btn_count_prime_Click(object sender, EventArgs e)
    {
        // hien thi tong cac uoc so nguyen to
        if (DsSo.Count > 0)
        {
            int sum = Sum_Prime_Divisor(DsUocSo);
            MessageBox.Show($"Tổng các ước số nguyên tố của {combobox_list_numbers.SelectedItem} là: {sum}");
        }
    }
}