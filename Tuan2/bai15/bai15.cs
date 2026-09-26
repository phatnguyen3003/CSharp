using System;

namespace Tuan2
{
    // delegate tu tao 
    public delegate int SoSanhDelegate<T>(T x, T y);

    public static class CustomArrayDelegate
    {
        // bubble sort dung delegate tu dinh nghia o tren
        public static void Sort<T>(T[] array, SoSanhDelegate<T> comparer)
        {
            if (array == null || array.Length <= 1 || comparer == null) return;

            int n = array.Length;
            for (int i = 0; i < n - 1; i++)
            {
                bool swapped = false;

                for (int j = 0; j < n - i - 1; j++)
                {
                    // neu phan tu dung truoc lon hon phan tu dung sau no thi doi cho
                    if (comparer(array[j], array[j + 1]) > 0)
                    {
                        T temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                        swapped = true;
                    }
                }

                // neu xong 1 vong lap ma khong co hoan doi xay ra thi mang da sap xep
                if (!swapped) break;
            }
        }

        // 2. BubbleSort dung delegate tich hop san (.NET System.Comparison<T>)
        public static void Sort<T>(T[] array, Comparison<T> comparer)
        {
            if (array == null || array.Length <= 1 || comparer == null) return;

            int n = array.Length;
            for (int i = 0; i < n - 1; i++)
            {
                bool swapped = false;

                for (int j = 0; j < n - i - 1; j++)
                {
                    if (comparer(array[j], array[j + 1]) > 0)
                    {
                        T temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                        swapped = true;
                    }
                }

                if (!swapped) break;
            }
        }
    }
}