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
        public void Test1()
        {
            
            Sortings sort1 = new Sortings(new int[] { 4, 5, 2, 3, 66, 34, 2, 6 });
            int a = 5;
            int b = 10;
            sort1.Swap(ref a,ref b);
            Assert.AreEqual(10, a);
            Assert.AreEqual(5, b);
            Assert.Pass();
        }


        public void Test2()
        {

            Sortings sort1 = new Sortings(new int[] { 4, 5, 2, 3, 66, 34, 2, 6 });
            int a = 5;
            int b = 10;
            sort1.Swap(ref a, ref b);
            Assert.AreEqual(10, a);
            Assert.AreEqual(5, b);
            Assert.Pass();
        }
    }
}