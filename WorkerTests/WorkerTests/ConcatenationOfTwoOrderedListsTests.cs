using System;
using System.Collections.Generic;
using Laboratornaya4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Laboratornaya4Tests.WorkerTests
{
    [TestClass]
    public class ConcatenationOfTwoOrderedListsTests
    {
        [TestMethod]
        public void ConcatenationOfTwoOrderedLists_ShouldMergeAscendingLists()
        {
            // Arrange
            var list1 = new List<int> { 1, 3, 5 };
            var list2 = new List<int> { 2, 4, 6 };
            var expected = new List<int> { 1, 2, 3, 4, 5, 6 };

            // Act
            var result = Worker.ConcatenationOfTwoOrderedLists(list1, list2);

            // Assert
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ConcatenationOfTwoOrderedLists_ShouldMergeDescendingLists()
        {
            // Arrange
            var list1 = new List<int> { 5, 3, 1 };
            var list2 = new List<int> { 10, 5, 2 };
            var expected = new List<int> { 10, 5, 5, 3, 2, 1 };

            // Act
            var result = Worker.ConcatenationOfTwoOrderedLists(list1, list2);

            // Assert
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ConcatenationOfTwoOrderedLists_ShouldHandleReversedList2()
        {
            // Arrange
            var list1 = new List<int> { 1, 2, 3 };
            var list2 = new List<int> { 3, 2, 1 };
            var expected = new List<int> { 1, 1, 2, 2, 3, 3 };

            // Act
            var result = Worker.ConcatenationOfTwoOrderedLists(list1, list2);

            // Assert
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ConcatenationOfTwoOrderedLists_ShouldHandleEmptyList1()
        {
            // Arrange
            var list1 = new List<int>();
            var list2 = new List<int> { 1, 2, 3 };
            var expected = new List<int> { 1, 2, 3 };

            // Act
            var result = Worker.ConcatenationOfTwoOrderedLists(list1, list2);

            // Assert
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ConcatenationOfTwoOrderedLists_ShouldHandleEmptyList2()
        {
            // Arrange
            var list1 = new List<int> { 5, 3, 1 };
            var list2 = new List<int>();
            var expected = new List<int> { 5, 3, 1 };

            // Act
            var result = Worker.ConcatenationOfTwoOrderedLists(list1, list2);

            // Assert
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ConcatenationOfTwoOrderedLists_ShouldNotModifyInputs()
        {
            // Arrange
            var list1 = new List<int> { 5, 3, 1 };
            var list2 = new List<int> { 1, 2, 3 };
            var expected = new List<int> { 5, 3, 3, 2, 1, 1 };

            // Act
            var result = Worker.ConcatenationOfTwoOrderedLists(list1, list2);

            // Assert
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ConcatenationOfTwoOrderedLists_TheFirstTwoAreEqual()
        {
            var list1 = new List<int> { 5, 5, 3, 1 };
            var list2 = new List<int> { 1, 2, 3 };
            var expected = new List<int> { 5, 5, 3, 3, 2, 1, 1 };

            // Act
            var result = Worker.ConcatenationOfTwoOrderedLists(list1, list2);

            // Assert
            CollectionAssert.AreEqual(expected, result);
        }
    }
}
