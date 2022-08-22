using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using HomeWorkHelpers;

namespace HomeWork5
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                string[] tasks =
                {
                    "Корректность ввода логина",
                    "Класс Message",
                    "Проверка перестановки строки",
                    "Задача ЕГЭ"
                };
                
                int number = Helpers.StartProgram(5, tasks);
                
                switch (number)
                {
                    case 0:
                        Task1();
                        break;
                    case 1:
                        Task2();
                        break;
                    case 2:
                        Task3();
                        break;
                    case 3:
                        Task4();
                        break;
                }
                Helpers.Pause();
            }
        }

        private static void Task1()
        {
            /*
             * 1. Создать программу, которая будет проверять корректность ввода логина.
             * Корректным логином будет строка от 2 до 10 символов, содержащая только буквы латинского алфавита
             * или цифры, при этом цифра не может быть первой.
             */

            int count = 0;
            int maxCount = 3;
            Regex regex = new Regex(@"^[A-Za-z]{1}[A-Za-z0-9]{1,9}$");
            do
            {
                count++;
                string login = Helpers.ConsoleDataInput("Введите логин: ");
                if (login != null && regex.IsMatch(login))
                {
                    Console.WriteLine("Логин соответствует формату");
                    break;
                }
                Console.WriteLine("Неверный формат логина");
            } while (count < maxCount);
        }

        private static void Task2()
        {
            /*
             * 2. Разработать статический класс Message, содержащий следующие статические методы для обработки текста:
             * а) Вывести только те слова сообщения, которые содержат не более n букв.
             * б) Удалить из сообщения все слова, которые заканчиваются на заданный символ.
             * в) Найти самое длинное слово сообщения.
             * г) Сформировать строку с помощью StringBuilder из самых длинных слов сообщения.
             * д) ***Создать метод, который производит частотный анализ текста. 
             * В качестве параметра в него передается массив слов и текст, 
             * в качестве результата метод возвращает сколько раз каждое из слов массива входит в этот текст. 
             * Здесь требуется использовать класс Dictionary.
             */
            const string message = "Привет мир, привет мир, привет мир, привет мир.";
            
            Message.MaxCountSymbol(message, 3);
            
            Console.WriteLine(Message.RemovePerLastSymbol(message, 'р'));
            
            Console.WriteLine(Message.CreateStringFromLongWords(message));

            Dictionary<int, string> dictionary = new Dictionary<int, string>();
            dictionary.Add(0, "Привет");
            dictionary.Add(1, "мир");
            Console.WriteLine(Message.CountUseString(dictionary, message));

        }

        private static void Task3()
        {
            /*
             * 3. *Для двух строк написать метод, определяющий, является ли одна строка перестановкой другой.
             * Например: badc являются перестановкой abcd.
             */

            string string1 = Helpers.ConsoleDataInput("Введите первую строку: ");
            string string2 = Helpers.ConsoleDataInput("Введите вторую строку: ");

            int count = string1.Length;
            foreach (char symbol in string1)
            {
                int index = string2.IndexOf(symbol);
                if (index == -1) break;
                string2 = string2.Remove(index, 1);
                count--;
            }

            if (count == 0) Console.WriteLine("Строка2 является перестановкой Строки1");
            else Console.WriteLine("Строка2 не является перестановкой Строки1");
        }

        private static void Task4()
        {
            /*
             * 4. *Задача ЕГЭ.
             * На вход программе подаются сведения о сдаче экзаменов учениками 9-х классов некоторой средней школы.
             * В первой строке сообщается количество учеников N, которое не меньше 10, но не превосходит 100,
             * каждая из следующих N строк имеет следующий формат:
             * <Фамилия> <Имя> <оценки>,
             * где <Фамилия> — строка, состоящая не более чем из 20 символов,
             * <Имя> — строка, состоящая не более чем из 15 символов,
             * <оценки> — через пробел три целых числа, соответствующие оценкам по пятибалльной системе.
             * <Фамилия> и <Имя>, а также <Имя> и <оценки> разделены одним пробелом.
             * Пример входной строки:
             * Иванов Петр 4 5 3
             * Требуется написать как можно более эффективную программу,
             * которая будет выводить на экран фамилии и имена трёх худших по среднему баллу учеников.
             * Если среди остальных есть ученики, набравшие тот же средний балл, что и один из трёх худших,
             * следует вывести и их фамилии и имена.
             */
            
            // Генерируем студентов в файл
            if (!Student.SaveStudentToFile())
            {
                Console.WriteLine("Ошибка создания файла");
                return;
            }

            // Получаем список студентов
            string[] stringStudents = Student.GetStudentsFromFile();

            Console.WriteLine($"Список студентов:");
            

            Student[] students = new Student[int.Parse(stringStudents[0])];
            
            for (int i = 1; i < stringStudents.Length - 1; i++)
            {
                Console.WriteLine($"{stringStudents[i]}");
                string[] std = stringStudents[i].Split(' ');
                
                if (!(Student.ratingChecker.IsMatch(std[2]) && Student.ratingChecker.IsMatch(std[3]) && 
                      Student.ratingChecker.IsMatch(std[4])))
                {
                    throw new Exception($"Ошибка в оценках студента {std[0]} {std[1]}");
                }
                Student student = new Student(std[0], std[1], 
                    (Math.Round(double.Parse(std[2]) + double.Parse(std[3]) + double.Parse(std[4]) / 3, 2)));
                
                students[i - 1] = student;
            }
    
            Console.WriteLine("");
            Console.WriteLine("Студенты с самым низким средним баллом");
            int count = 0;
            double last = 0;
            foreach (Student student in students.OrderBy(item => item.Rating).ToArray())
            {
                if (count >= 3 && last < student.Rating)
                {
                    break;
                }
                Console.WriteLine($"{student.Lastname} {student.Name} {student.Rating}");
                count++;
                if (count == 3) last = student.Rating;
            }
        }
    }
}