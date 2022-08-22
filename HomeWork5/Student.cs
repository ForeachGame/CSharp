using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace HomeWork5
{
    public class Student
    {

        private string _lastname;
        private string _name;

        private static Regex lastnameChecker = new Regex(@"^[А-Я]{1}[а-я]{0,19}$");
        private static Regex nameChecker = new Regex(@"^[А-Я]{1}[а-я]{0,14}$");
        public static Regex ratingChecker = new Regex(@"[12345]{1}");
        
        public string Lastname
        {
            get => _lastname;
            
            set
            {
                if (!lastnameChecker.IsMatch(value))
                {
                    throw new Exception($"Ошибка в фамилии студента {value}");
                }

                _lastname = value;
            }
        }

        public string Name
        {
            get => _name;
            
            set
            {
                if (!nameChecker.IsMatch(value))
                {
                    throw new Exception($"Ошибка в имени студента {value}");
                }

                _name = value;
            }
        }

        public double Rating { get; set; }

        private static string _filename = "students.txt";
        private static string path = AppDomain.CurrentDomain.BaseDirectory + _filename;

        public Student()
        {
           
        }
        
        public Student(string lastname, string name, double rating)
        {
            Lastname = lastname;
            Name = name;
            Rating = rating;
        }
        
        private static string[] StudentGenerator()
        {
            Random random = new Random();
            int count = random.Next(10, 101);

            string[] lastnames =
            {
                "Иванов",
                "Смирнов",
                "Кузнецов",
                "Попов",
                "Васильев",
                "Петров",
                "Соколов",
                "Михайлов",
                "Новиков",
                "Федоров",
                "Морозов",
                "Волков",
                "Алексеев",
                "Лебедев",
                "Семенов",
                "Егоров",
                "Павлов",
                "Козлов",
                "Степанов",
                "Николаев"
            };

            string[] names =
            {
                "Артем",
                "Михаил", 
                "Александр", 
                "Максим", 
                "Иван", 
                "Тимофей", 
                "Дмитрий", 
                "Матвей", 
                "Егор", 
                "Роман"
            };
            
            string[] result = new string[count];

            Student student = new Student();
            for (int i = 0; i < count; i++)
            {
                student.Lastname = lastnames[random.Next(lastnames.Length)];
                student.Name = names[random.Next(names.Length)];
                result[i] = $"{student.Lastname} {student.Name} {random.Next(1, 6)} {random.Next(1, 6)} {random.Next(1, 6)}";
            }

            return result;
        }

        public static bool SaveStudentToFile()
        {
            try
            {
                string[] students = StudentGenerator();

                if (!File.Exists(path)) return false;
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine($"{students.Length}");
                    foreach (string student in students)
                    {
                        sw.WriteLine($"{student}");
                    }
                }

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static string[] GetStudentsFromFile()
        {
            StringBuilder result = new StringBuilder();
            if (File.Exists(path))
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    while (!sr.EndOfStream)
                    {
                        result.Append($"{sr.ReadLine()},");
                    }
                }
            }

            return result.ToString().Split(',');

        }
    }
}