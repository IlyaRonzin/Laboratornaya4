using Laboratornaya4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratornaya4Tests.WorkerTests
{
    [TestClass]
    public class FindUniqueConsonantsTests
    {
        [TestMethod]
        public void FindUniqueConsonantsPerWord_FileExists_ReturnsUniqueConsonants()
        {
            // Arrange
            string filePath = "test1.txt";
            File.WriteAllText("test1.txt", "БАРбекю Робот\r\nТарелка\r\nКом\r\n\r\nПапа", Encoding.UTF8);
            var consonants = new HashSet<char>("бвгджзйклмнпрстфхцчшщм");

            var expected = new HashSet<char> { 'м', 'л', 'п' }; // "м" встречается только в слове "ком".

            // Act
            var result = Worker.FindUniqueConsonantsPerWord(filePath, consonants);

            // Assert
            CollectionAssert.AreEquivalent(expected.ToArray(), result.ToArray());

            // Cleanup
            File.Delete(filePath);
        }

        [TestMethod]
        public void FindUniqueConsonantsPerWord_FileDoesNotExist_ReturnsEmptySet()
        {
            // Arrange
            string filePath = "nonexistent.txt";
            var consonants = new HashSet<char>("бвгджзйклмнпрстфхцчшщм");

            // Act
            var result = Worker.FindUniqueConsonantsPerWord(filePath, consonants);

            // Assert
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void FindUniqueConsonantsPerWord_FileIsEmpty_ReturnsEmptySet()
        {
            // Arrange
            string filePath = "empty.txt";
            File.WriteAllText("empty.txt", "", Encoding.UTF8);
            var consonants = new HashSet<char>("бвгджзйклмнпрстфхцчшщм");

            // Act
            var result = Worker.FindUniqueConsonantsPerWord(filePath, consonants);

            // Assert
            Assert.AreEqual(0, result.Count);

            // Cleanup
            File.Delete(filePath);
        }

        [TestMethod]
        public void FindUniqueConsonantsPerWord_MultipleUniqueConsonantsInFile_ReturnsCorrectConsonants()
        {
            // Arrange
            string filePath = "test2.txt";
            File.WriteAllText("test2.txt", "Жираф КоТ\nСлон БаР", Encoding.UTF8);
            var consonants = new HashSet<char>("бвгджзйклмнпрстфхцчшщм");

            var expected = new HashSet<char> { 'ж', 'ф', 'т', 'к', 'с', 'л', 'н', 'б' }; 

            // Act
            var result = Worker.FindUniqueConsonantsPerWord(filePath, consonants);

            // Assert
            CollectionAssert.AreEquivalent(expected.ToArray(), result.ToArray());

            // Cleanup
            File.Delete(filePath);
        }
    }
}
