using NUnit.Framework;
using Parallel_sortings;

namespace UnitTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void BubbleSortTest()
        {
            
            Sortings sort1 = new Sortings(new int[] { 4, 5, 2, 3, 66, 34, 2, 6 });
            int[] sortedArray = new int[] {2, 2, 3, 4, 5, 6, 34, 66 };
            sort1.bubbleSort();
            for(int i = 0; i < sortedArray.Length; i++)
            {
                Assert.AreEqual(sortedArray[i], sort1.array[i]);
            }
            Assert.Pass();
        }

        [Test]
        public void QuickSortTest()
        {

            Sortings sort1 = new Sortings(new int[] { 4, 5, 2, 3, 66, 34, 2, 6 });
            int[] sortedArray = new int[] { 2, 2, 3, 4, 5, 6, 34, 66 };
            sort1.quickSort();
            for (int i = 0; i < sortedArray.Length; i++)
            {
                Assert.AreEqual(sortedArray[i], sort1.array[i]);
            }
            Assert.Pass();
        }

        [Test]
        public void ShellSortTest()
        {

            Sortings sort1 = new Sortings(new int[] { 4, 5, 2, 3, 66, 34, 2, 6 });
            int[] sortedArray = new int[] { 2, 2, 3, 4, 5, 6, 34, 66 };
            sort1.shellSort();
            for (int i = 0; i < sortedArray.Length; i++)
            {
                Assert.AreEqual(sortedArray[i], sort1.array[i]);

            }
            Assert.Pass();
        }
    }
}