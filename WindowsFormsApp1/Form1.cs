using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parallel_sortings
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private List<int[]> arrList;
        private List<Sortings> SortingsList;

        private void button1_Click(object sender, EventArgs e)
        {
            arrList = new List<int[]>();
            

            int[] arr = createRandomArrayWithUsersInputs();

            makeUnsortArrays(arr);

            Sort.bubbleSort(arrList[1]);
            Sort.quickSort(arrList[2]); 
            Sort.shellSort(arrList[3]);

            printArr(arrList[0], textBox7);
            printArr(arrList[1], textBox4);
            printArr(arrList[2], textBox5); 
            printArr(arrList[3], textBox6);
        }

        private int[] createRandomArrayWithUsersInputs()
        {
            int n, left, right;

            readUserInputs(out n, out left, out right);


            return createArray(n, left, right);
        }
        private void readUserInputs(out int n, out int left, out int right)
        {
            bool result;

            result = int.TryParse(textBox1.Text, out n);
            if (!result) throw new Exception();
            result = int.TryParse(textBox2.Text, out left);
            if (!result) throw new Exception();
            result = int.TryParse(textBox3.Text, out right);
            if (!result) throw new Exception();
        }


        public void makeUnsortArrays(int[] array)
        {
            arrList.Add(array);
            arrList.Add(makeCopy(array));
            arrList.Add(makeCopy(array));  
            arrList.Add(makeCopy(array));
        }
        public void sortArrays(List<int[]> listOfUnsortedArrays)
        {
            SortingsList = new List<Sortings>();
            fillSortings(SortingsList,listOfUnsortedArrays);
            sortAllArrays();
        }
        private void fillSortings(List<Sortings> listToFill, List<int[]> listOfUnsortedArrays)
        {

            foreach(int[] i in listOfUnsortedArrays)
            {
                listToFill.Add(new Sortings(i));
                
            }
        }
        private void sortAllArrays()
        {
            chooseSortingsForArrays();
            runTreadsWithSortings();

        }
        public void chooseSortingsForArrays()
        {
            for (int i = 0; i < SortingsList.Count; i++)
            {
                if (i % 3 == 0)
                {
                    SortingsList[i].Name = SortingsNames.BubbleSort;
                    continue;
                }
                if (i % 3 == 1)
                {
                    SortingsList[i].Name = SortingsNames.QuickSort;
                    continue;
                }
                if (i % 3 == 2)
                {
                    SortingsList[i].Name = SortingsNames.ShellSort;
                    continue;
                }
            }
        }
        private void runTreadsWithSortings()
        {
            foreach (Sortings sortingManager in SortingsList)
            {
                createTreadWithFeedback(sortingManager);
            }
        }
        private void createTreadWithFeedback(Sortings sortingManager)
        {
            Thread tr = new Thread(sortWithFeedback);
         
            tr.Start(sortingManager);
        }
        private void sortWithFeedback(object sortObject)
        {
            Sortings sortingManager = (Sortings)sortObject;

            feedback(sortingManager);

        }
        private void feedback(Sortings sortingManager)
        {
            MessageBox.Show("Сортировка " + sortingManager.Name + " выполнена"); 
        }
     
        private int[] createArray(int length,int left,int right)
        {
            Random rng = new Random();
            int[] arr = new int[length];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rng.Next(left, right); 
            }
            return arr;

        }

        private void printArr(int[] arr,TextBox tb)
        {
            for(int i = 0; i < arr.Length; i++)
            {
                tb.Text += arr[i].ToString() + " ";
            }
        }

        private int[] makeCopy(int[] array)
        {
            int[] newArray = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                newArray[i] = array[i];
            }
            return newArray;
        }
    }
}

