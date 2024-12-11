using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace Laboratornaya4
{
    public class Program
    {
        static void Main()
        {
            Console.Write("Введите номер задания: ");
            string task = Console.ReadLine();

            switch (task)
            {
                case "1":
                    List<string> mainList = new List<string> { "a", "a", "b", "d" };
                    List<string> additionalList = new List<string>() { "f", "e", "c" };
                    mainList = Worker.MergeSortedLists(mainList, additionalList);
                    Console.WriteLine("Результат: " + string.Join(", ", mainList));
                    break;

                case "2":
                    LinkedList<int> linkedList = new LinkedList<int>(new int[] { 1, 2, 3, 2, 3, 4 });
                    Worker.CountEqualNeighbors(linkedList);
                    break;

                case "3":
                    HashSet<string> menu = new HashSet<string> { "Пицца", "Салат", "Суп", "Бургер", "Паста", "Суши", "Багет", "Шаурма" };
                    List<HashSet<string>> orders = new List<HashSet<string>>
                    {
                        new HashSet<string> { "Пицца", "Салат", "Суп", "Шаурма" },
                        new HashSet<string> { "Пицца", "Паста", "Суп", "Бургер" },
                        new HashSet<string> { "Пицца", "Салат", "Суп", "Багет" },
                    };
                    Worker.AnalyzeOrders(menu, orders);
                    break;

                case "4":
                    Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                    string filePath = "test1.txt";

                    if (!File.Exists(filePath))
                    {
                        Console.WriteLine("Файл не найден");
                        break;
                    }

                    HashSet<char> consonants = new HashSet<char>("бвгджзйклмнпрстфхцчшщ");
                    HashSet<char> uniqueConsonants = Worker.FindUniqueConsonants(filePath, consonants);

                    Console.WriteLine("Уникальные согласные: " + string.Join(", ", uniqueConsonants));
                    break;

                default:
                    Console.WriteLine("Неверный номер задания");
                    break;
            }
        }
    }
}
