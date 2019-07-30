using System;
using System.Collections.Generic;
using System.Linq;
using AlgorithmsLibrary.Transpositions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmsTests.TranspositionsTests
{
    [TestClass]
    public class FastPermutatorTests
    {
        private IPermutator<int> _permutator;

        [TestInitialize]
        public void Setup()
        {
            _permutator = new FastPermutator<int>();
        }

        [TestMethod]
        public void FastPermutator_Permutate_NullList_ThrowException()
        {
            // Arrange
            var exceptionThrown = false;

            // Act
            try
            {
                var actual = _permutator.Permutate(null);
            }
            catch (ArgumentNullException)
            {
                exceptionThrown = true;
            }

            // Assert
            Assert.IsTrue(exceptionThrown);
        }

        [TestMethod]
        public void FastPermutator_Permutate_EmptyList_ReturnsEmptyList()
        {
            // Arrange
            var list = new List<int>();

            // Act
            var actual = _permutator.Permutate(list);

            // Assert
            Assert.AreEqual(0, actual.Count);
        }

        [TestMethod]
        public void FastPermutator_Permutate_OneElementList_ReturnsSameList()
        {
            // Arrange
            var list = new List<int>
            {
                1
            };

            // Act
            var actual = _permutator.Permutate(list);

            // Assert
            Assert.AreEqual(1, actual[0][0]);
        }

        [TestMethod]
        public void FastPermutator_Permutate_TwoElementList_ReturnsPermutations()
        {
            // Arrange
            var list = new List<int>
            {
                1, 2
            };

            // Act
            var actual = _permutator.Permutate(list);

            // Assert
            Assert.AreEqual(1, actual[0][0]);
            Assert.AreEqual(2, actual[0][1]);
            Assert.AreEqual(2, actual[1][0]);
            Assert.AreEqual(1, actual[1][1]);
        }

        [TestMethod]
        public void FastPermutator_Permutate_MoreElementList_ReturnsPermutations()
        {
            // Arrange
            var list = new List<int>
            {
                1, 2, 3, 4
            };

            // Act
            var actual = _permutator.Permutate(list);

            // Assert
            Assert.AreEqual(24, actual.Count);

            actual = actual.OrderBy(l => l[0]).ThenBy(l => l[1]).ThenBy(l => l[2]).ToList();
            
            Assert.IsTrue(Enumerable.SequenceEqual(actual[0], new List<int> { 1, 2, 3, 4 }));
            Assert.IsTrue(Enumerable.SequenceEqual(actual[1], new List<int> { 1, 2, 4, 3 }));
            Assert.IsTrue(Enumerable.SequenceEqual(actual[2], new List<int> { 1, 3, 2, 4 }));
            Assert.IsTrue(Enumerable.SequenceEqual(actual[3], new List<int> { 1, 3, 4, 2 }));
            Assert.IsTrue(Enumerable.SequenceEqual(actual[4], new List<int> { 1, 4, 2, 3 }));
            Assert.IsTrue(Enumerable.SequenceEqual(actual[5], new List<int> { 1, 4, 3, 2 }));
            Assert.IsTrue(Enumerable.SequenceEqual(actual[6], new List<int> { 2, 1, 3, 4 }));
            Assert.IsTrue(Enumerable.SequenceEqual(actual[7], new List<int> { 2, 1, 4, 3 }));
            Assert.IsTrue(Enumerable.SequenceEqual(actual[8], new List<int> { 2, 3, 1, 4 }));
            Assert.IsTrue(Enumerable.SequenceEqual(actual[9], new List<int> { 2, 3, 4, 1 }));
            Assert.IsTrue(Enumerable.SequenceEqual(actual[10], new List<int> { 2, 4, 1, 3 }));
            Assert.IsTrue(Enumerable.SequenceEqual(actual[11], new List<int> { 2, 4, 3, 1 }));
            Assert.IsTrue(Enumerable.SequenceEqual(actual[12], new List<int> { 3, 1, 2, 4 }));
            Assert.IsTrue(Enumerable.SequenceEqual(actual[13], new List<int> { 3, 1, 4, 2 }));
            Assert.IsTrue(Enumerable.SequenceEqual(actual[14], new List<int> { 3, 2, 1, 4 }));
            Assert.IsTrue(Enumerable.SequenceEqual(actual[15], new List<int> { 3, 2, 4, 1 }));
            Assert.IsTrue(Enumerable.SequenceEqual(actual[16], new List<int> { 3, 4, 1, 2 }));
            Assert.IsTrue(Enumerable.SequenceEqual(actual[17], new List<int> { 3, 4, 2, 1 }));
            Assert.IsTrue(Enumerable.SequenceEqual(actual[18], new List<int> { 4, 1, 2, 3 }));
            Assert.IsTrue(Enumerable.SequenceEqual(actual[19], new List<int> { 4, 1, 3, 2 }));
            Assert.IsTrue(Enumerable.SequenceEqual(actual[20], new List<int> { 4, 2, 1, 3 }));
            Assert.IsTrue(Enumerable.SequenceEqual(actual[21], new List<int> { 4, 2, 3, 1 }));
            Assert.IsTrue(Enumerable.SequenceEqual(actual[22], new List<int> { 4, 3, 1, 2 }));
            Assert.IsTrue(Enumerable.SequenceEqual(actual[23], new List<int> { 4, 3, 2, 1 }));
        }
    }
}
