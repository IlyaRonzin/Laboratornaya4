using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Laboratornaya4
{
    public class Worker
    {
        public static List<int> ConcatenationOfTwoOrderedLists(List<int> list1, List<int> list2)
        {
            var result = new List<int>();
            var iterators = new Iterators();

            if (IfHelper.IsAscending(list1) != IfHelper.IsAscending(list2))
            {
                list2.Reverse();
            }

            while (iterators.i < list1.Count && iterators.j < list2.Count)
            {
                if (IfHelper.IsAscending(list1))
                {
                    ListMergerHelper.FillTheListInAscendingOrder(result, list1, list2, iterators);
                }
                else
                {
                    ListMergerHelper.FillTheListInDescendingOrder(result, list1, list2, iterators);
                }
            }

            ListMergerHelper.AddElementsToTheEnd(result, list1, iterators.i);
            ListMergerHelper.AddElementsToTheEnd(result, list2, iterators.j);

            return result;
        }

        public static int CountElementsWithEqualNeighbors(LinkedList<string> linkedList)
        {
            var count = 0;

            if (linkedList.Count < 3)
            {
                Console.WriteLine("В списке меньше 3 элементов");
                return count;
            }

            var current = linkedList.First?.Next;

            while (current?.Next != null)
            {
                if (current.Previous!.Value == current.Next.Value)
                {
                    count++;
                }

                current = current.Next;
            }

            return count;
        }

        public static string AnalyzeOrders(List<HashSet<string>> orders)
        {
            var menu = OrdersHelper.GetMenu();
            var resultBuilder = new StringBuilder();

            foreach (var dish in menu)
            {
                bool orderedByAll = orders.All(order => order.Contains(dish));
                bool orderedBySome = orders.Any(order => order.Contains(dish));
                bool orderedByNone = !orderedBySome;

                if (orderedByAll)
                {
                    resultBuilder.AppendLine($"Блюдо '{dish}' заказали все посетители.");
                }
                else if (orderedBySome)
                {
                    resultBuilder.AppendLine($"Блюдо '{dish}' заказали некоторые посетители.");
                }
                else if (orderedByNone)
                {
                    resultBuilder.AppendLine($"Блюдо '{dish}' не заказал никто.");
                }
            }

            return resultBuilder.ToString();
        }

        public static HashSet<char> FindUniqueConsonantsPerWord(string filePath, HashSet<char> consonants)
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("Файл не найден.");
                return new HashSet<char>();
            }

            Dictionary<char, int> consonantWordCount = new Dictionary<char, int>();

            using (StreamReader reader = new StreamReader(filePath, Encoding.GetEncoding("UTF-8")))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    FileHelper.ProcessLine(line, consonants, consonantWordCount);
                }
            }

            return FileHelper.GetUniqueConsonants(consonantWordCount);
        }
    }
}
