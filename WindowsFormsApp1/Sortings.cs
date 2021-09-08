using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parallel_sortings
{
    public class Sortings 
    {
        public int[] array;
        public int numberOfShifts;
        public int numberOfComparsions;
        public DateTime time;

        public Sortings(int[] array)
        {
            this.array = array;
        }

        public void BubbleSort() 
        {
            numberOfShifts = 0;
            numberOfComparsions = 0;
            int temp;
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - i - 1; j++)
                {   
                    if (array[j] > array[j + 1])
                    {
                        temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                        numberOfShifts++;
                    }
                    numberOfComparsions++;
                }
            }
        }

        public void quickSort(int[] arr)
        {
            numberOfShifts = 0;
            numberOfComparsions = 0;
            quick(arr, 0, arr.Length - 1);
        }
        private  void quick(int[] arr, int low, int high)
        {
            if (low < high)
            {
                int pi = partition(arr, low, high);
                quick(arr, low, pi - 1);
                quick(arr, pi + 1, high);
            }
        }

        private  int partition(int[] arr, int low, int high)
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
                    numberOfShifts++;
                }
                numberOfComparsions++;
            }
            tmp = arr[i + 1];
            arr[i + 1] = arr[high];
            arr[high] = tmp;
            return (i + 1);
        }

        public void shellSort(int[] arr)
        {
            numberOfComparsions = 0;
            numberOfShifts = 0;
            int n = arr.Length;

            for (int gap = n / 2; gap > 0; gap /= 2)
            {
                for (int i = gap; i < n; i++)
                {
                    int temp = arr[i];

                    for (int j = i; j >= gap && arr[j - gap] > temp; j -= gap)
                    {
                        arr[j] = arr[j - gap];
                        numberOfShifts++;
                        numberOfComparsions++;
                    }

                    arr[j] = temp;
                    numberOfShifts++;
                }
            }
        }




        public void Swap(ref int firstNumber,ref int secondNumber)
        {
            int temp = firstNumber;
            firstNumber = secondNumber;
            secondNumber = temp;
        }
    }
}
