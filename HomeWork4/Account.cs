using System;
using System.IO;
using HomeWorkHelpers;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace HomeWork4
{
    public struct Account
    {
        private string _login;
        private string _password;

        private static string _filename = "users.json";

        public string Login
        {
            get => _login;

            set
            {
                if (value.Length < 3)
                    throw new Exception("Логин не может быть короче 3-х символов");
                _login = value;
            }
        }

        public string Password
        {
            get => _password;

            set
            {
                if (value.Length < 3)
                {
                    throw new Exception("Пароль не может быть короче 3-х символов");
                }

                _password = value;
            }
        }

        public Account(string login, string password): this()
        {
            if (login.Length < 3) throw new Exception("Логин не может быть короче 3-х символов");
            if (password.Length < 3) throw new Exception("Пароль не может быть короче 3-х символов");
            Login = login;
            Password = password;
        }
        
        private static int CheckUser(string login)
        {
            try
            {
                Account[] data = GetAllUsers();

                for (int i = 0; i < data.Length; i++)
                {
                    if (data[i].Login != login) continue;
                    return data[i].Login == login ? i : -1;
                }
                return -1;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public bool Auth()
        {
            int index = CheckUser(Login);
            if (index == -1) return false;
            Account[] data = GetAllUsers();
            return data[index].Password == Password;
        }

        public static bool CreateUser(string login, string password, string confirm)
        {
            if (password == confirm)
            {
                return SaveUser(login, password);
            }
            throw new Exception("Пароль и проверка пароля не совпадают");
        }
        

        private static bool SaveUser(string login, string password)
        {
            if (CheckUser(login) != -1) return false;
            
            Account[] data = GetAllUsers();
            Account newUser = new Account(login, password);
            Account[] newData = AddAccountToAccounts(data, newUser);
                
            string json = JsonConvert.SerializeObject(newData);
            
            return SaveFile(json);
        }

        private static Account[] GetAllUsers()
        {
            string json = ConnectFile();
            return JsonConvert.DeserializeObject<Account[]>(json);
        }
        
        private static string ConnectFile()
        {
            string filename = AppDomain.CurrentDomain.BaseDirectory + _filename;
            if (File.Exists(filename)) return File.ReadAllText(filename);
            throw new Exception("Файл с пользователями не найден");
        }

        private static bool SaveFile(string json)
        {
            string filename = AppDomain.CurrentDomain.BaseDirectory + _filename;
            if (!File.Exists(filename)) return false;
            File.WriteAllText(filename, json);
            return true;
        }
        
        private static Account[] AddAccountToAccounts(Account[] array, Account str)
        {
            Account[] newArray = new Account[array.Length + 1];
            for(int i = 0; i < array.Length; i++)
            {
                newArray[i] = array[i];
            }
            newArray[array.Length] = str;
            return newArray;
        }
    }
}

/*
 * 4. Реализовать метод проверки логина и пароля.
 * На вход метода подается логин и пароль.
 * На выходе истина, если прошел авторизацию, и ложь, если не прошел (Логин: root, Password: GeekBrains).
 * Используя метод проверки логина и пароля, написать программу:
 * пользователь вводит логин и пароль, программа пропускает его дальше или не пропускает.
 * С помощью цикла do while ограничить ввод пароля тремя попытками.
 *
 *
 * 
 */