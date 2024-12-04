using Laboratornaya4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratornaya4Tests
{
    [TestClass]
    public class AnalyzeOrdersTests
    {
        [TestMethod]
        public void AnalyzeOrders_AllDishesOrderedByAll_ShouldReturnCorrectString()
        {
            // Arrange
            var orders = new List<HashSet<string>>
            {
                new HashSet<string> { "Суп", "Паста", "Салат" },
                new HashSet<string> { "Суп", "Паста", "Салат" },
                new HashSet<string> { "Суп", "Паста", "Салат" }
            };
            var expectedOutput = @"Блюдо 'Суп' заказали все посетители.
Блюдо 'Паста' заказали все посетители.
Блюдо 'Салат' заказали все посетители.
Блюдо 'Пицца' не заказал никто.
Блюдо 'Торт' не заказал никто.
";

            // Act
            var result = Worker.AnalyzeOrders(orders);

            // Assert
            Assert.AreEqual(expectedOutput, result);
        }

        [TestMethod]
        public void AnalyzeOrders_SomeDishesOrderedBySome_ShouldReturnCorrectString()
        {
            // Arrange
            var orders = new List<HashSet<string>>
            {
                new HashSet<string> { "Суп", "Паста" },
                new HashSet<string> { "Салат", "Пицца" },
                new HashSet<string> { "Паста", "Салат" }
            };
            var expectedOutput = @"Блюдо 'Суп' заказали некоторые посетители.
Блюдо 'Паста' заказали некоторые посетители.
Блюдо 'Салат' заказали некоторые посетители.
Блюдо 'Пицца' заказали некоторые посетители.
Блюдо 'Торт' не заказал никто.
";

            // Act
            var result = Worker.AnalyzeOrders(orders);

            // Assert
            Assert.AreEqual(expectedOutput, result);
        }

        [TestMethod]
        public void AnalyzeOrders_NoDishesOrdered_ShouldReturnCorrectString()
        {
            // Arrange
            var orders = new List<HashSet<string>>
            {
                new HashSet<string>(),
                new HashSet<string>(),
                new HashSet<string>()
            };
            var expectedOutput = @"Блюдо 'Суп' не заказал никто.
Блюдо 'Паста' не заказал никто.
Блюдо 'Салат' не заказал никто.
Блюдо 'Пицца' не заказал никто.
Блюдо 'Торт' не заказал никто.
";

            // Act
            var result = Worker.AnalyzeOrders(orders);

            // Assert
            Assert.AreEqual(expectedOutput, result);
        }
    }
}
