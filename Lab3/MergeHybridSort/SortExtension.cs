using System;
using System.Linq;

namespace MergeHybridSort
{
    public class SortExtension
    {
        public static void InsertionSort(int[] array, int start, int end)
        {
            int value;
            var i = start;
            int j;
            while (i <= end)
            {
                value = array[i];
                j = i;
                while (j > start && array[j - 1] > value)
                {
                    array[j] = array[j - 1];
                    j--;
                }
        
                array[j] = value; 
                i++;
            }
        }

        public static void HybridMergeSort(int[] array, int start, int end, int k)
        {
            if (start < end)
            {
                if (end - start > k)
                {
                    var middle = (start + end) / 2;
                    HybridMergeSort(array, start, middle, k);
                    HybridMergeSort(array, middle + 1, end, k);
                    Merge(array, start, end, middle);
                }
                else
                {
                    InsertionSort(array, start, end);
                }
            }
        }

        public static void MergeSort(int[] array, int start, int end)
        {
            if (start < end)
            {
                var middle = (start + end) / 2;
                MergeSort(array, start, middle);
                MergeSort(array, middle + 1, end);
                Merge(array, start, end, middle);
            }
        }

        public static void Merge(int[] array, int start, int end, int middle)
        {
            var ptr1 = 0;
            var ptr2 = 0;
            int[] arr1 = array.Skip(start).Take(middle - start + 1).ToArray();
            int[] arr2 = array.Skip(middle + 1).Take(end - middle).ToArray();

            for (var i = start; i <= end; i++)
            {
                if (ptr1 < arr1.Length && ptr2 < arr2.Length)
                {
                    array[i] = arr1[ptr1] > arr2[ptr2] ? arr2[ptr2++] : arr1[ptr1++];
                }
                else
                {
                    array[i] = ptr2 < arr2.Length ? arr2[ptr2++] : arr1[ptr1++];
                }
            }
        }
    }
}
