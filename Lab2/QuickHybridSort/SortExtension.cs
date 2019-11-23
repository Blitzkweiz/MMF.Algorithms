using System;
using System.Threading;

namespace QuickHybridSort
{
    public static class SortExtension
    {
        public static void RightQuickSort(int[] array, int start, int end)
        {
            if (start < end)
            {
                var pivot = RightPartition(array, start, end);
                RightQuickSort(array, start, pivot - 1);
                RightQuickSort(array, pivot + 1, end);
            }
        }

        public static void RandomQuickSort(int[] array, int start, int end)
        {
            if (start < end)
            {
                var pivot = RandomPartition(array, start, end);
                RandomQuickSort(array, start, pivot - 1);
                RandomQuickSort(array, pivot + 1, end);
            }
        }

        public static int RightPartition (int[] array, int start, int end) 
        {
            int temp;
            var marker = start;
            for ( var i = start; i < end; i++ ) 
            {
                if ( array[i] < array[end] ) 
                {
                    temp = array[marker]; 
                    array[marker] = array[i];
                    array[i] = temp;
                    marker += 1;
                }
            }
            temp = array[marker];
            array[marker] = array[end];
            array[end] = temp; 
            return marker;
        }

        public static int RandomPartition(int[] array, int start, int end)
        {
            var rand = new Random();
            var pivot = array[rand.Next(start, end)];

            int temp;
            var i = start;
            var j = end;

            while (true)
            {
                while (array[i] < pivot)
                {
                    i++;
                }

                while (array[j] > pivot)
                {
                    j--;
                }

                if (i >= j)
                {
                    return j;
                }

                if (array[i] != array[j])
                {
                    temp = array[i];
                    array[i] = array[j]; 
                    array[j] = temp;
                }
                else
                {
                    i++;
                }
            }
        }

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

        public static void HybridSort(int[] array, int start, int end, int k)
        {
            if (start < end)
            {
                if (end - 1 > k)
                {
                    var sep = RightPartition(array, start, end);
                    HybridSort(array, start, sep - 1, k);
                    HybridSort(array, sep + 1, end, k);
                }
                else
                {
                    InsertionSort(array, start, end);
                }
            }
        }
    }
}
