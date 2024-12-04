using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratornaya4
{
    public class InputHelper
    {
        public static bool InputIsExit(string? input)
        {
            return string.IsNullOrWhiteSpace(input);
        }
        public static int ReadPositiveInt(string message)
        {
            int result;
            while (true)
            {
                Console.Write(message);
                if (int.TryParse(Console.ReadLine(), out result) && result > 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Ошибка: введите корректное число.");
                }
            }
            return result;
        }
    }
}
