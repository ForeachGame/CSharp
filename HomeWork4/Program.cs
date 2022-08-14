using System;
using HomeWorkHelpers;
using HomeWorkArray;

namespace HomeWork4
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                string[] tasks =
                {
                    "Работа с массивом",
                    "Логины и пароли"
                };
                int number = Helpers.StartProgram(4, tasks);
                switch (number)
                {
                    case 0:
                        Task1();
                        break;
                    case 1:
                        Task2();
                        break;
                }
                Helpers.Pause();
            }
        }

        private static void Task1()
        {
            Helpers.Header("Демонстрация работы с массивом");

            string[] methods =
            {
                "Конструктор",
                "Свойство Sum",
                "Метод Inverse",
                "Метод Multi",
                "Свойство MaxCount"
            };
            
            Console.CursorVisible = false;
            int menu = ConsoleMenu.Select(0, 3, methods);
            if (menu == methods.Length) Helpers.CloseProgram();
            Console.CursorVisible = true;
            Helpers.Clear();
            switch (menu)
            {
                case 0:
                    Task1_1();
                    break;
                case 1:
                    Task1_2();
                    break;
                case 2:
                    Task1_3();
                    break;
                case 3:
                    Task1_4();
                    break;
                case 4:
                    Task1_5();
                    break;
                default:
                    Console.WriteLine("Программа будет закрыта");
                    Helpers.Pause();
                    Helpers.CloseProgram();
                    break;
            }
        }

        private static void Task2()
        {
            Helpers.Header("Демонстрация работы с Логином и Паролем");
            
            string[] methods =
            {
                "Регистрация",
                "Авторизация",
            };
            
            Console.CursorVisible = false;
            int menu = ConsoleMenu.Select(0, 3, methods);
            if (menu == methods.Length) Helpers.CloseProgram();
            Console.CursorVisible = true;
            Helpers.Clear();
            switch (menu)
            {
                case 0:
                    Registration();
                    break;
                case 1:
                    Auth();
                    break;
                default:
                    Console.WriteLine("Программа будет закрыта");
                    Helpers.Pause();
                    Helpers.CloseProgram();
                    break;
            }
        }

        private static void Task1_1()
        {
            Helpers.Header("Демонстрация работы нового конструктора");

            Helpers.CheckParse(out int size, "Размер массива: ");
            Helpers.CheckParse(out int start, "Начальное значение: ");
            Helpers.CheckParse(out int step, "Размер шага: ");

            MyArray array = new MyArray(size, start, step);
            
            array.PrintArray();
        }
        
        private static void Task1_2()
        {
            Helpers.Header("Демонстрация свойства Sum");
            
            Helpers.CheckParse(out int size, "Размер массива: ");

            MyArray array = new MyArray(size);
            
            Console.WriteLine("Содержимое массива");
            array.PrintArray();

            Console.WriteLine($"Сумма всех элементов массива: {array.Sum}");
        }
        
        private static void Task1_3()
        {
            Helpers.Header("Демонстрация метода Inverse");
            
            Helpers.CheckParse(out int size, "Размер массива: ");

            MyArray array = new MyArray(size);
            MyArray inverseArray = new MyArray(array.Inverse());
            
            Console.WriteLine("Содержимое массива");
            array.PrintArray();
            
            Console.WriteLine("Новое содержимое массива: ");
            inverseArray.PrintArray();
        }
        
        private static void Task1_4()
        {
            Helpers.Header("Демонстрация метода Multi");
            
            Helpers.CheckParse(out int size, "Размер массива: ");
            Helpers.CheckParse(out int number, "Умножаем на: ");

            MyArray array = new MyArray(size);
            
            Console.WriteLine("Содержимое массива");
            array.PrintArray();
            
            array.Multi(number);
            Console.WriteLine("Новое содержимое массива");
            array.PrintArray();
        }
        
        private static void Task1_5()
        {
            Helpers.Header("Демонстрация свойства MaxCount");
            
            Helpers.CheckParse(out int size, "Размер массива: ");

            MyArray array = new MyArray(size);
            
            Console.WriteLine("Содержимое массива");
            array.PrintArray();

            Console.WriteLine($"Количество максимальных элементов: {array.MaxCount} ({array.Max})");
        }

        private static void Registration()
        {
            try
            {
                Console.WriteLine("Регистрация нового пользователя");
                string login = Helpers.ConsoleDataInput("Логин: ");
                string password = Helpers.ConsoleDataInput("Пароль: ");
                string confirm = Helpers.ConsoleDataInput("Повторите пароль: ");

                if (Account.CreateUser(login, password, confirm))
                {
                    Console.WriteLine("Пользователь успешно создан!");   
                }
                else
                {
                    Console.WriteLine("Пользователь уже существует");
                }
                Helpers.Pause();
                Helpers.Clear();
                Task2();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Helpers.Pause();
                Helpers.Clear();
                Task2();
            }
        }
        
        private static void Auth()
        {
            try
            {
                int attempt = 0;
                bool auth;
                
                do
                {
                    Console.WriteLine("Авторизация пользователя");
                    string login = Helpers.ConsoleDataInput("Логин: ");
                    string password = Helpers.ConsoleDataInput("Пароль: ");
                    Account user = new Account(login, password);
                    
                    if (user.Auth()) Console.WriteLine("Пользователь успешно авторизован");
                    else Console.WriteLine("Неверные данные авторизации");

                    auth = user.Auth();
                    attempt++;
                } while (attempt < 3 && !auth);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}