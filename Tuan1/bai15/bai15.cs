using SharedLibs;


namespace Tuan1
{
    public class Bai15
    {
        public static void Run()
        {
            int choose = 0;
            int n = 0;
            int[]? NumsArray = null;
            do
            {
                Console.WriteLine("\n================ MENU ================");
                Console.WriteLine("1. Nhap mang gom n phan tu");
                Console.WriteLine("2. In mang ra man hinh");
                Console.WriteLine("3. Tim min/max cua mang");
                Console.WriteLine("4. Tra ve mang cac so nguyen to trong mang");
                Console.WriteLine("5. Thoat");

                Console.Write("Chon chuc nang: ");

                choose = InputHelper.InputNatural("Cua lua chon");
                switch (choose)
                {
                    case 1:
                        n = InputHelper.InputNatural("n");
                        NumsArray = new int[n];

                        for (int i = 0; i < n; i++)
                        {
                            NumsArray[i] = InputHelper.InputInt($"phan tu thu {i + 1}");
                        }
                        Console.WriteLine("Da nhap xong mang");
                        break;
                    case 2:
                        if (NumsArray != null)
                        {
                            Console.WriteLine("Cac phan tu cua mang la: ");
                            for (int i = 0; i < n; i++)
                            {
                                Console.Write($"{NumsArray[i]} | ");
                            }
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine("Vui long chon chuc nang 1 de nhap mang vao truoc");
                        }
                        break;
                    case 3:
                        if (NumsArray != null)
                        {
                            int max = int.MinValue;
                            int min = int.MaxValue;

                            for (int i = 0; i < n; i++)
                            {
                                if (max < NumsArray[i])
                                {
                                    max = NumsArray[i];
                                }
                                if (min > NumsArray[i])
                                {
                                    min = NumsArray[i];
                                }
                            }

                            Console.WriteLine($"Gia tri lon nhat cua mang la: {max}");
                            Console.WriteLine($"Gia tri nho nhat cua mang la: {min}");

                        }
                        else
                        {
                            Console.WriteLine("Vui long chon chuc nang 1 de nhap mang vao truoc");
                        }
                        break;
                    case 4:
                        if (NumsArray != null)
                        {
                            int[] PrimesArray = new int[0];

                            for (int i = 0; i < n; i++)
                            {
                                if (Bai7.Bai7_Prime_checking(NumsArray[i]))
                                {
                                    //PrimesArray[PrimesArray.Length - 1] = NumsArray[i];
                                    Array.Resize(ref PrimesArray, PrimesArray.Length + 1);
                                    PrimesArray[PrimesArray.Length - 1] = NumsArray[i];


                                }
                            }

                            if (PrimesArray.Length > 0)
                            {
                                Console.WriteLine("Mang cac so nguyen to la:");
                                for (int i = 0; i < PrimesArray.Length; i++)
                                {
                                    Console.Write($"{PrimesArray[i]} | ");
                                }
                                Console.WriteLine();
                            }
                            else
                            {
                                Console.WriteLine("Khong tim thay so nguyen to nao trong mang.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Vui long chon chuc nang 1 de nhap mang vao truoc");
                        }
                        break;
                }
            }
            while (choose != 5);
        }
    }
}