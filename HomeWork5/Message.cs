using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using HomeWorkHelpers;

namespace HomeWork5
{
    public static class Message
    {
        private static string[] separators = { ",", ".", "!", "?", ";", ":", " " };
        
        // Вывести только те слова сообщения, которые содержат не более n букв.
        public static void MaxCountSymbol(string message, int n)
        {
            string[] strings = message.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            StringBuilder result = new StringBuilder();
            
            foreach (string item in strings)
            {
                if (item.Length <= n) result.Append($"{item}\n");
            }
            Console.WriteLine(result);
            Helpers.Pause();
        }
        
        // Удалить из сообщения все слова, которые заканчиваются на заданный символ.
        public static string RemovePerLastSymbol(string message, char symbol)
        {
            string[] strings = message.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            StringBuilder removeStrings = new StringBuilder();
            
            foreach (string item in strings)
            {
                if (item[item.Length - 1] == symbol) removeStrings.Append($"{item},");
            }
            
            StringBuilder result = new StringBuilder();
            result.Append(message);
            
            foreach (string item in removeStrings.ToString().Split(separators, StringSplitOptions.RemoveEmptyEntries))
            {
                result = result.Replace(item, "");
            }

            return result.ToString();
        }
        
        
        // Найти самое длинное слово сообщения.
        public static string[] FindMaxCountSymbol(string message)
        {
            string[] strings = message.Split(separators, StringSplitOptions.RemoveEmptyEntries)
                .OrderBy(str => str.Length)
                .ToArray();
            
            Array.Reverse(strings);

            int maxSymbols = strings[0].Length;
            
            StringBuilder result = new StringBuilder();
            
            foreach (string item in strings)
            {
                if (item.Length < maxSymbols) break;
                result.Append($"{item},");
            }

            return result.ToString().Split(separators, StringSplitOptions.RemoveEmptyEntries);

        }
        
        // Сформировать строку с помощью StringBuilder из самых длинных слов сообщения.
        public static string CreateStringFromLongWords(string message)
        {
            return String.Join(" ", FindMaxCountSymbol(message));
        }
        
        
        /*
         * д) ***Создать метод, который производит частотный анализ текста. 
         * В качестве параметра в него передается массив слов и текст, 
         * в качестве результата метод возвращает сколько раз каждое из слов массива входит в этот текст. 
         * Здесь требуется использовать класс Dictionary.
         */

        public static string CountUseString(Dictionary<int, string> dictionary, string message)
        {
            
            StringBuilder result = new StringBuilder();

            foreach (KeyValuePair<int, string> item in dictionary)
            {
                int count = new Regex(item.Value).Matches(message).Count;
                result.Append($"Cлово \"{item.Value}\" встречается {count} раз.\n");
            }
            
            return result.ToString();
        }
    }
}