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

        public void quickSort()
        {
            numberOfShifts = 0;
            numberOfComparsions = 0;
            quick(array, 0, array.Length - 1);
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

        public void shellSort()
        {
            numberOfComparsions = 0;
            numberOfShifts = 0;
            int n = array.Length;

            for (int gap = n / 2; gap > 0; gap /= 2)
            {
                for (int i = gap; i < n; i++)
                {
                    int temp = array[i];
                    int j;
                    for ( j = i; j >= gap && array[j - gap] > temp; j -= gap)
                    {
                        array[j] = array[j - gap];
                        numberOfShifts++;
                        numberOfComparsions++;
                    }

                    array[j] = temp;
                    numberOfShifts++;
                }
            }
        }




        private void Swap(ref int firstNumber,ref int secondNumber)
        {
            int temp = firstNumber;
            firstNumber = secondNumber;
            secondNumber = temp;
        }
    }
}
