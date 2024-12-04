using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Laboratornaya4
{
    public class ListCreator
    {
        public static List<int> CreateOrderedList()
        {
            var orderedList = new List<int>();
            bool? isAscending = null;

            Console.WriteLine("Введите числа (по одному на строке). Для завершения ввода нажмите Enter на пустой строке:");

            while (true)
            {
                var input = Console.ReadLine();

                if (InputHelper.InputIsExit(input))
                {
                    break;
                }

                if (!int.TryParse(input, out int number))
                {
                    Console.WriteLine("Ошибка: введите корректное число.");
                    continue;
                }

                if (orderedList.Count == 0)
                {
                    orderedList.Add(number);
                }
                else
                {
                    AddItem(number, orderedList, ref isAscending);
                }
            }
            return orderedList;
        }

        private static bool? AddElementAndCheckOrder(int element, List<int> resultList)
        {
            bool? isAscending = null;
            if (element > resultList[^1])
                isAscending = true;
            else if (element < resultList[^1])
                isAscending = false;
            resultList.Add(element);
            return isAscending;
        }

        private static void AddItem(int number, List<int> resultList, ref bool? isAscending)
        {
            if (isAscending == null)
            {
                isAscending = AddElementAndCheckOrder(number, resultList);
            }
            else if (isAscending == true && number >= resultList[^1])
                resultList.Add(number);
            else if (isAscending == false && number <= resultList[^1])
                resultList.Add(number);
            else
                Console.WriteLine($"Ошибка: число {number} нарушает порядок списка.");
        }

        public static LinkedList<string> CreateLinkedList()
        {
            var linkedList = new LinkedList<string>();
            Console.WriteLine("Введите числа (по одному на строке). Для завершения ввода нажмите Enter на пустой строке:");
            while (true)
            {
                var input = Console.ReadLine();

                if (InputHelper.InputIsExit(input))
                {
                    return linkedList;
                }
                linkedList.AddLast(input!);
            }
        }
    }
}
