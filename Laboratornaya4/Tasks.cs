using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratornaya4
{
    public class Tasks
    {
        public static void ConcatenationOfTwoOrderedLists()
        {
            Console.WriteLine("Создание первого упорядоченного списка:");
            var list1 = ListCreator.CreateOrderedList();

            Console.WriteLine("Создание второго упорядоченного списка:");
            var list2 = ListCreator.CreateOrderedList();

            var resultList = Worker.ConcatenationOfTwoOrderedLists(list1, list2);

            Console.WriteLine("Объединенный список:");
            Console.WriteLine(string.Join(", ", resultList));
        }

        public static void CountElementsWithEqualNeighbors()
        {
            Console.WriteLine("Создание двусвязного списка:");
            var linkedList = ListCreator.CreateLinkedList();

            var k = Worker.CountElementsWithEqualNeighbors(linkedList);

            Console.WriteLine($"В списке {k} элементов, у которых соседи равны");
        }

        public static void AnalyzeOrders()
        {
            OrdersHelper.PrintMenu();
            var numberOfOrders = InputHelper.ReadPositiveInt("Введите количество заказов:");

            List<HashSet<string>> orders = OrdersHelper.CreateListOfOrders(numberOfOrders);

            var result = Worker.AnalyzeOrders(orders);

            Console.WriteLine();
            Console.WriteLine(result);
        }

        public static void FindUniqueConsonantsPerWord()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            var input = "note.txt";
            HashSet<char> consonants = new HashSet<char>("бвгджзйклмнпрстфхцчшщ");

            HashSet<char> result = Worker.FindUniqueConsonantsPerWord(input, consonants);

            FileHelper.PrintFileContent(input);

            Console.Write("Согласные, встречающиеся только в одном слове: ");
            foreach (var ch in result)
            {
                Console.Write(ch + " ");
            }
            Console.WriteLine();
        }
    }
}
