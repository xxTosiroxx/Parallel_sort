using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parallel_sortings
{
    public static class Sort
    {
        public static void bubbleSort(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
                for (int j = 0; j < n - i - 1; j++)
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
        }

        public static void quickSort(int[] arr)
        {
            quick(arr, 0, arr.Length - 1);
        }
        private static void quick(int[] arr, int low, int high)
        {
            if (low < high)
            {
                int pi = partition(arr, low, high);
                quick(arr, low, pi - 1);
                quick(arr, pi + 1, high);
            }
        }
        private static int partition(int[] arr, int low, int high)
        {
            int pivot = arr[high];
            int i = (low - 1);
            int tmp = 0;

            for (int j = low; j <= high - 1; j++)
            {
                if (arr[j] < pivot)
                {
                    i++;
                    tmp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = tmp;
                }
            }
            tmp = arr[i + 1];
            arr[i + 1] = arr[high];
            arr[high] = tmp;

            return (i + 1);
        }
        public static void shellSort(int[] arr)
        {
            int n = arr.Length;

            for (int gap = n / 2; gap > 0; gap /= 2)
            {
                for (int i = gap; i < n; i += 1)
                {
                    int temp = arr[i];

                    int j;
                    for (j = i; j >= gap && arr[j - gap] > temp; j -= gap)
                        arr[j] = arr[j - gap];

                    arr[j] = temp;
                    
                }
            }
        }
    }
}
