using System;
using System.Collections.Generic;

namespace Tuan2
{
    public static class CustomArray
    {
        // cach 1, su dung IComparable, nhu cach bai 13 da dung, cach nay phan tu muon so sanh phai trien khai IComparable mo idung duoc so sanh
        public static void Sort<T>(T[] array) where T : IComparable<T> // implement IComparable
        {
            if (array == null || array.Length <= 1)
                return; // kiem tra mang rong 
            QuickSort(array, 0, array.Length - 1); // truyen tiep mang vao ham
        }

        private static void QuickSort<T>(T[] array, int left, int right) where T : IComparable<T>
        {
            int i = left, j = right;
            T pivot = array[(left + right) / 2];

            while (i <= j)
            {
                // dung phuong thuc compareto cua interface IComparable<T>
                while (array[i].CompareTo(pivot) < 0) i++;
                while (array[j].CompareTo(pivot) > 0) j--;

                if (i <= j)
                {
                    T temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                    i++;
                    j--;
                }
            }

            if (left < j) QuickSort(array, left, j);//goi de quy lai phuong thuc den khi xong
            if (i < right) QuickSort(array, i, right);
        }


        // dung 1 lop so sanh ben ngoai cua lop can dung, cach nay ve thuat toan thi tuong tu cach truoc nhung khong can implement phuong thuc vao lop can dung
        public static void Sort<T>(T[] array, IComparer<T> comparer)
        {
            if (array == null || array.Length <= 1 || comparer == null) return;
            QuickSort(array, 0, array.Length - 1, comparer);
        }

        private static void QuickSort<T>(T[] array, int left, int right, IComparer<T> comparer)
        {
            int i = left, j = right;
            T pivot = array[(left + right) / 2];

            while (i <= j)
            {
                // dung phuong thuc Compare() cua interface IComparer<T>
                while (comparer.Compare(array[i], pivot) < 0) i++;
                while (comparer.Compare(array[j], pivot) > 0) j--;

                if (i <= j)
                {
                    T temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                    i++;
                    j--;
                }
            }

            if (left < j) QuickSort(array, left, j, comparer);
            if (i < right) QuickSort(array, i, right, comparer);
        }
    }
}