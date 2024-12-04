using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratornaya4
{
    public class FileHelper
    {
        public static HashSet<char> GetUniqueConsonants(Dictionary<char, int> consonantWordCount)
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

        public static void ProcessLine(string line, HashSet<char> consonants, Dictionary<char, int> consonantWordCount)
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
        public static void PrintFileContent(string filePath)
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("Файл не найден.");
                return;
            }

            try
            {
                using (StreamReader reader = new StreamReader(filePath, Encoding.GetEncoding("UTF-8")))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при чтении файла: {ex.Message}");
            }
        }

    }
}
