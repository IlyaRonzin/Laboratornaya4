using System;
using System.Collections.Generic;
using System.Linq;

namespace Laboratornaya4
{
    public class OrdersHelper
    {
        private static HashSet<string> menu = new HashSet<string>
        {
            NormalizeDish("Суп"),
            NormalizeDish("Паста"),
            NormalizeDish("Салат"),
            NormalizeDish("Пицца"),
            NormalizeDish("Торт")
        };

        public static HashSet<string> GetMenu()
        {
            return new HashSet<string>(menu);
        }
        public static void PrintMenu()
        {
            Console.WriteLine("Меню:");
            foreach (var dish in menu)
            {
                Console.WriteLine($"- {dish}");
            }
            Console.WriteLine();
        }

        public static List<HashSet<string>> CreateListOfOrders(int numberOfOrders)
        {
            var listOfOrders = new List<HashSet<string>>();
            for (int i = 0; i < numberOfOrders; i++)
            {
                Console.WriteLine($"Введите заказ {i + 1} (через запятую):");
                string input = Console.ReadLine();

                var order = ParseOrder(input!);
                listOfOrders.Add(order);
            }
            return listOfOrders;
        }

        private static HashSet<string> ParseOrder(string input)
        {
            var dishes = input.Split(',', StringSplitOptions.RemoveEmptyEntries)
                              .Select(dish => NormalizeDish(dish.Trim()));

            var validOrder = FilterOrder(dishes);

            return validOrder;
        }

        private static HashSet<string> FilterOrder(IEnumerable<string> dishes)
        {
            var validOrder = new HashSet<string>();
            foreach (var dish in dishes)
            {
                if (menu.Contains(dish))
                {
                    validOrder.Add(dish);
                }
                else
                {
                    Console.WriteLine($"Блюдо \"{dish}\" отсутствует в меню и не будет добавлено в заказ.");
                }
            }
            return validOrder;
        }

        private static string NormalizeDish(string dish)
        {
            if (string.IsNullOrWhiteSpace(dish)) return dish;

            dish = dish.Trim();
            return char.ToUpper(dish[0]) + dish.Substring(1).ToLower();
        }
    }
}
