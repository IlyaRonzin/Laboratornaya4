using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace Laboratornaya4
{
    public class Worker
    {
        // Объединение двух отсортированных списков, сохраняя порядок
        public static List<T> MergeSortedLists<T>(List<T> mainList, List<T> additionalList) where T : IComparable<T>
        {
            // Если оба списка пусты, возвращаем пустой список
            if (mainList.Count == 0 && additionalList.Count == 0)
                return new List<T>();

            // Объединение списков
            List<T> combinedList = new List<T>(mainList);
            combinedList.AddRange(additionalList);

            // Если основной список пуст, сортируем объединённый список по возрастанию
            if (mainList.Count == 0)
            {
                combinedList.Sort();
                return combinedList;
            }

            // Определяем порядок сортировки исходного списка
            bool ascending = mainList.Count > 1 && mainList[0].CompareTo(mainList[^1]) < 0;

            // Сортируем объединённый список в нужном порядке
            combinedList.Sort((a, b) => ascending ? a.CompareTo(b) : b.CompareTo(a));
            return combinedList;
        }


        // Подсчёт количества элементов в LinkedList, где соседние элементы равны
        public static void CountEqualNeighbors<T>(LinkedList<T> numbers) where T : IEquatable<T>
        {
            int count = 0;

            if (numbers.Count < 3)
            {
                Console.WriteLine("0");
                return;
            }

            var current = numbers.First.Next;
            while (current.Next != null)
            {
                if (current.Previous.Value.Equals(current.Next.Value))
                {
                    count++;
                }
                current = current.Next;
            }

            Console.WriteLine(count);
        }

        // Анализ заказов: какие позиции заказывали все, хотя бы раз и не заказывали
        public static void AnalyzeOrders(HashSet<string> menu, List<HashSet<string>> orders)
        {
            // Позиции, которые заказывали все клиенты
            HashSet<string> commonOrders = new HashSet<string>(orders[0]);
            foreach (var order in orders)
            {
                commonOrders.IntersectWith(order);
            }

            // Позиции, которые заказывали хотя бы раз
            HashSet<string> allOrders = new HashSet<string>();
            foreach (var order in orders)
            {
                allOrders.UnionWith(order);
            }

            // Позиции, которые не заказывали
            HashSet<string> notOrdered = new HashSet<string>(menu);
            notOrdered.ExceptWith(allOrders);

            Console.WriteLine("Меню: " + string.Join(", ", menu));
            Console.WriteLine("Позиции, которые заказывали все: " + string.Join(", ", commonOrders));
            Console.WriteLine("Позиции, которые заказывали хотя бы раз: " + string.Join(", ", allOrders));
            Console.WriteLine("Позиции, которые не заказывали: " + string.Join(", ", notOrdered));
        }

        // Нахождение уникальных согласных в текстовом файле
        public static HashSet<char> FindUniqueConsonants(string filePath, HashSet<char> consonants)
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
                    ProcessLine(line, consonants, consonantWordCount);
                }
            }

            return GetUniqueConsonants(consonantWordCount);
        }

        private static HashSet<char> GetUniqueConsonants(Dictionary<char, int> consonantWordCount)
        {
            HashSet<char> uniqueConsonants = new HashSet<char>();
            foreach (var pair in consonantWordCount)
            {
                if (pair.Value == 1)
                {
                    uniqueConsonants.Add(pair.Key);
                }
            }
            return uniqueConsonants;
        }

        private static void ProcessLine(string line, HashSet<char> consonants, Dictionary<char, int> consonantWordCount)
        {
            line = line.ToLower();
            string[] words = line.Split(new[] { ' ', '.', ',', '!', '?', ':', ';', '-', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string word in words)
            {
                HashSet<char> consonantsInWord = new HashSet<char>();

                foreach (char ch in word)
                {
                    if (consonants.Contains(ch))
                    {
                        consonantsInWord.Add(ch);
                    }
                }

                foreach (char ch in consonantsInWord)
                {
                    if (consonantWordCount.ContainsKey(ch))
                    {
                        consonantWordCount[ch]++;
                    }
                    else
                    {
                        consonantWordCount[ch] = 1;
                    }
                }
            }
        }
    }
}
