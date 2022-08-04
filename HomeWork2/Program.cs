using System;
using System.Collections.Generic;
using System.Diagnostics;
using HomeWorkHelpers;


namespace HomeWork2
{
    class Program
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Helpers.PrintStudentInfo(2);
                Console.CursorVisible = false;
            
                string[] tasks =
                {
                    "Минимальное значение из 3-х чисел",
                    "Подсчёт количества цифр числа",
                    "Подсчитать сумму всех нечетных положительных чисел",
                    "Логин и Пароль",
                    "Индекс Массы Тела",
                    "Подсчет количества «хороших» чисел"
                };
            
                int number = ConsoleMenu.Select(0, 3, tasks);
                if (number == tasks.Length) Helpers.CloseProgram();

                Console.CursorVisible = true;
                Helpers.Clear();
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
                    case 4:
                        Task5();
                        break;
                    case 5:
                        Task6();
                        break;
                }
                Helpers.Pause();
            }
        }
        
        private static void Task1()
        {
            Console.WriteLine("Задача: Написать метод, возвращающий минимальное из трёх чисел.");
            Helpers.Spacer();
            
            int number1 = int.Parse(Helpers.ConsoleDataInput("Первое число: "));
            int number2 = int.Parse(Helpers.ConsoleDataInput("Второе число: "));
            int number3 = int.Parse(Helpers.ConsoleDataInput("Третье число: "));

            Console.WriteLine($"Минимальное число: {MinNumber(number1, number2, number3)}");
        }
        
        private static void Task2()
        {
            Console.WriteLine("Задача: Написать метод подсчета количества цифр числа.");
            Helpers.Spacer();
            
            int number = int.Parse(Helpers.ConsoleDataInput("Введите число: "));
            
            Console.WriteLine($"Количество цифр числа {number}: {CountNumber(number)}");
        }
        
        private static void Task3()
        {
            Console.WriteLine("Задача: С клавиатуры вводятся числа, пока не будет введен 0. " +
                              "Подсчитать сумму всех нечетных положительных чисел.");
            Helpers.Spacer();

            int sum = 0;
            while (true)
            {
                int number = int.Parse(Helpers.ConsoleDataInput("Введите число: "));
                if (number == 0) break;
                if (number % 2 != 0 && number > 0) sum += number;
            }
            
            Console.WriteLine($"Сумма введённых нечётных положительных чисел: {sum}");
        }
        
        private static void Task4()
        {
            Console.WriteLine("Задача: Реализовать метод проверки логина и пароля.\n" +
                              "На вход метода подается логин и пароль.\n" +
                              "На выходе истина, если прошел авторизацию, и ложь, если не прошел (Логин: root, Password: GeekBrains).\n" +
                              "Используя метод проверки логина и пароля, написать программу: \n" +
                              "пользователь вводит логин и пароль, программа пропускает его дальше или не пропускает.\n" +
                              "С помощью цикла do while ограничить ввод пароля тремя попытками.");
            Helpers.Spacer();

            string login, password;
            
            int attempt = 0;
            bool auth = false;
            
            do
            {
                attempt++;
                
                login = Helpers.ConsoleDataInput("Введите логин: ");
                password = Helpers.ConsoleDataInput("Введите пароль: ");
                
                auth = CheckAuth(login, password);
            } while (attempt < 3 && auth == false);

            if (auth)
            {
                Console.WriteLine("Вы успешно авторизовались");
            }
            else
            {
                Console.WriteLine("Закончились попытки авторизации");
            }
        }
        
        private static void Task5()
        {
            Console.WriteLine("Задача: Написать программу, которая запрашивает массу и рост человека,\n " +
                              "вычисляет его индекс массы и сообщает, нужно ли человеку похудеть, набрать вес или всё в норме.\n " +
                              "*Рассчитать, на сколько кг похудеть или сколько кг набрать для нормализации веса.");
            Helpers.Spacer();
            
            double weight = double.Parse(Helpers.ConsoleDataInput("Введите массу тела в килограммах: "));
            double height = double.Parse(Helpers.ConsoleDataInput("Введите рост в метрах: "));

            BodyMassIndex(weight, height);
        }
        
        private static void Task6()
        {
            Console.WriteLine("Задача: *Написать программу подсчета количества «хороших» чисел в диапазоне от 1 до 1 000 000 000.\n " +
                              "«Хорошим» называется число, которое делится на сумму своих цифр.\n " +
                              "Реализовать подсчёт времени выполнения программы, используя структуру DateTime.");
            Helpers.Spacer();
            
            int i = 0;
            int result = 0;
            DateTime start = DateTime.Now;
            
            do
            {
                i++;
                if (i % CountNumber(i) == 0) result++;
            } while (i < 1000000000);
            
            DateTime end = DateTime.Now;
            TimeSpan res = end - start;

            Console.WriteLine($"Количество хороших чисел: {result}");
            Console.WriteLine($"Время выполнения скрипта: {res}");
            /*
             *  Количество хороших чисел: 112706319
             *  Время выполнения скрипта: 00:00:50.8739999
             */
        }

        private static int MinNumber(int number1, int number2, int number3)
        {
            return number1 < number2
                ? number1 < number3
                    ? number1
                    : number3
                : number2 < number3
                    ? number2
                    : number3;
        }

        private static int CountNumber(int number)
        {
            int i = 0;
            while (number > 0)
            {
                i++;
                number /= 10;
            }

            return i;
        }

        private static bool CheckAuth(string login, string password)
        {
            if (login != "root" && password != "GeekBrains")
            {
                Console.WriteLine("Неверные логин и пароль");
                return false;
            }
            else if (login != "root")
            {
                Console.WriteLine("Неверный логин");
                return false;
            }
            else if (password != "GeekBrains")
            {
                Console.WriteLine("Неверный пароль");
                return false;
            }

            return true;
        }

        private static void BodyMassIndex(double weight, double height)
        {
            double result = Math.Round(weight / (height * height), 2);
            Console.WriteLine($"ИМТ: {result}");

            if (result <= 18.5)
            {
                if (result <= 16) Console.WriteLine("Выраженный дефицит массы тела");
                if (result > 16 && result <= 18.5) Console.WriteLine("Недостаточная (дефицит) масса тела");
                Console.WriteLine($"Вам надо набрать {IdealMass(weight, height, result)} кг.");
            }
           
            if (result > 18.5 && result <= 25) Console.WriteLine("Норма");
            if (result > 25)
            {
                if (result > 25 && result <= 30) Console.WriteLine("Избыточная масса тела (предожирение)");
                if (result > 30 && result <= 35) Console.WriteLine("Ожирение первой степени");
                if (result > 35 && result <= 40) Console.WriteLine("Ожирение второй степени");
                if (result > 40) Console.WriteLine("Ожирение третьей степени (морбидное)");
                Console.WriteLine($"Вам надо похудеть на {IdealMass(weight, height, result)} кг.");
            }
            
        }

        private static double IdealMass(double weight, double height, double bmi)
        {
            return bmi < 18.5
                ? Math.Round(((height * height) * 18.5) - weight, 2)
                : Math.Round(weight - ((height * height) * 25), 2);
        }

        private static int SumNumber(int number)
        {
            int i = 0;
            while (number > 0)
            {
                i += number /= 10;
            }

            return i;
        }
    }
}