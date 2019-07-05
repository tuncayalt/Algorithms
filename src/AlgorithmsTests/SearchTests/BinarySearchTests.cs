using System;
using AlgorithmsLibrary.Searches;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmsTests.SearchTests
{
    [TestClass]
    public class BinarySearchTests
    {
        private BinarySearcher<int> _binarySearcher;
        private int[] _arr;

        [TestInitialize]
        public void Setup()
        {
            _binarySearcher = new BinarySearcher<int>();
            _arr = null;
        }

        [TestMethod]
        public void BinarySearch_Search_NullArray_ReturnsFalse()
        {
            // Arrange, Act
            var actual = _binarySearcher.Search(_arr, 5);

            // Assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void BinarySearch_Search_EmptyArray_ReturnsFalse()
        {
            // Arrange
            _arr = new int[3];
            Array.Sort(_arr);

            // Act
            var actual = _binarySearcher.Search(_arr, 5);

            // Assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void BinarySearch_Search_ArrayWithoutTarget_ReturnsFalse()
        {
            // Arrange
            _arr = new[] { 1, 2, 3 };
            Array.Sort(_arr);

            // Act
            var actual = _binarySearcher.Search(_arr, 5);

            // Assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void BinarySearch_Search_ArrayWithTargetAtTheEnd_ReturnsTrue()
        {
            // Arrange
            _arr = new[] { 1, 2, 3, 5 };
            Array.Sort(_arr);

            // Act
            var actual = _binarySearcher.Search(_arr, 5);

            // Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void BinarySearch_Search_ArrayWithTargetAtTheBeginning_ReturnsTrue()
        {
            // Arrange
            _arr = new[] { 5, 6, 7, 8 };
            Array.Sort(_arr);

            // Act
            var actual = _binarySearcher.Search(_arr, 5);

            // Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void BinarySearch_Search_ArrayWithOnlyTarget_ReturnsTrue()
        {
            // Arrange
            _arr = new[] { 5 };
            Array.Sort(_arr);

            // Act
            var actual = _binarySearcher.Search(_arr, 5);

            // Assert
            Assert.IsTrue(actual);
        }
    }
}
