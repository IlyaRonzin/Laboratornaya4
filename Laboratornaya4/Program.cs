using System.ComponentModel.Design;
using System.Security.Cryptography.X509Certificates;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;

namespace Laboratornaya4
{
    public class Program
    {
        public static void Main()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Добро пожаловать в систему работы с матрицами!");
                Console.WriteLine("1. Создать и объединить два упорядоченных списка.");
                Console.WriteLine("2. Создать двусвязный список и посчитать количество элементов, у которых равные «соседи».");
                Console.WriteLine("3. Создать список заказов и определить самые популярные блюда.");
                Console.WriteLine("4. Напечатать в алфавитном порядке все согласные буквы из файла, которые входят ровно в одно слово.");
                Console.WriteLine("0. Выйти");
                Console.Write("Выберите действие: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Tasks.ConcatenationOfTwoOrderedLists();
                        break;
                    case "2":
                        Tasks.CountElementsWithEqualNeighbors();
                        break;
                    case "3":
                        Tasks.AnalyzeOrders();
                        break;
                    case "4":
                        Tasks.FindUniqueConsonantsPerWord();
                        break;
                    case "0":
                        Console.WriteLine("Выход...");
                        return;
                    default:
                        Console.WriteLine("Неверный выбор. Попробуйте снова.");
                        break;
                }

                Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                Console.ReadKey();
            }
        }
    }
}