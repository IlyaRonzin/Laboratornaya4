using Laboratornaya4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratornaya4Tests.WorkerTests
{
    [TestClass]
    public class CountElementsWithEqualNeighborsTests
    {
        [TestMethod]
        public void CountElementsWithEqualNeighbors_EmptyList_ReturnsZero()
        {
            // Arrange
            var linkedList = new LinkedList<string>();

            // Act
            var result = Worker.CountElementsWithEqualNeighbors(linkedList);

            // Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void CountElementsWithEqualNeighbors_ListWithLessThanThreeElements_ReturnsZero()
        {
            // Arrange
            var linkedList = new LinkedList<string>();
            linkedList.AddLast("a");
            linkedList.AddLast("b");

            // Act
            var result = Worker.CountElementsWithEqualNeighbors(linkedList);

            // Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void CountElementsWithEqualNeighbors_ListWithEqualNeighbors_ReturnsCorrectCount()
        {
            // Arrange
            var linkedList = new LinkedList<string>();
            linkedList.AddLast("a");
            linkedList.AddLast("b");
            linkedList.AddLast("c");
            linkedList.AddLast("b");
            linkedList.AddLast("c");
            linkedList.AddLast("b");

            // Act
            var result = Worker.CountElementsWithEqualNeighbors(linkedList);

            // Assert
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void CountElementsWithEqualNeighbors_ListWithNoEqualNeighbors_ReturnsZero()
        {
            // Arrange
            var linkedList = new LinkedList<string>();
            linkedList.AddLast("a");
            linkedList.AddLast("b");
            linkedList.AddLast("c");
            linkedList.AddLast("d");

            // Act
            var result = Worker.CountElementsWithEqualNeighbors(linkedList);

            // Assert
            Assert.AreEqual(0, result);
        }
    }
}
