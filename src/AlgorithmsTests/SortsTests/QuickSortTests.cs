using System.Collections.Generic;
using AlgorithmsLibrary.Sorts;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmsTests.SortsTests
{
    [TestClass]
    public class QuickSortTests
    {
        private QuickSorter<int> quickSorter;

        [TestInitialize]
        public void Setup()
        {
            quickSorter = new QuickSorter<int>();
        }

        [TestMethod]
        public void QuickSort_NullList_NullList()
        {
            // Arrange
            IList<int> list = null;

            // Act
            quickSorter.Sort(list);

            // Assert
            Assert.AreEqual(null, list);
        }

        [TestMethod]
        public void QuickSort_EmptyList_EmptyList()
        {
            // Arrange
            var list = new List<int>();

            // Act
            quickSorter.Sort(list);

            // Assert
            Assert.AreEqual(0, list.Count);
        }

        [TestMethod]
        public void QuickSort_ListWith1Element_ListSame()
        {
            // Arrange
            var list = new List<int> { 1 };

            // Act
            quickSorter.Sort(list);

            // Assert
            Assert.AreEqual(1, list.Count);
            Assert.AreEqual(1, list[0]);
        }

        [TestMethod]
        public void QuickSort_ListWith2Elements_ListSorted()
        {
            // Arrange
            var list = new List<int> { 2, 1 };

            // Act
            quickSorter.Sort(list);

            // Assert
            Assert.AreEqual(2, list.Count);
            AssertIfSorted(list);
        }

        [TestMethod]
        public void QuickSort_ListWith3Elements_ListSorted()
        {
            // Arrange
            var list = new List<int> { 0, 1, 0 };

            // Act
            quickSorter.Sort(list);

            // Assert
            Assert.AreEqual(3, list.Count);
            AssertIfSorted(list);
        }

        [TestMethod]
        public void QuickSort_ListWithMoreElements_ListSorted()
        {
            // Arrange
            var list = new List<int> { 0, 1, 0, -2, 10, 22, 22, 11, 12, 5, -2, 1, 0 };

            // Act
            quickSorter.Sort(list);

            // Assert
            Assert.AreEqual(13, list.Count);
            AssertIfSorted(list);
        }

        private static void AssertIfSorted(IList<int> list)
        {
            for (var i = 0; i < list.Count - 2; i++)
            {
                Assert.IsTrue(list[i] <= list[i + 1]);
            }
        }
    }
}
