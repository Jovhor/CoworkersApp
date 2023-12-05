using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CoworkersApp
{
    class Program
    {

        static void RightHere()
        {
            using (StreamWriter dataBase = new StreamWriter("DataBase.csv", true, Encoding.Unicode))
            {
                Console.Write("Начнём?");

                char key = 'д';

                do
                {
                    string note = string.Empty;
                    Console.Write("\nВведите номер сотрудника: ");
                    note += $"{Console.ReadLine()}#";

                    string now = DateTime.Now.ToString();
                    Console.Write($"Время добавление записи: {now} ");
                    note += $"{now}#";

                    Console.Write("\nВведите Ф.И.О. сотрудника:  ");
                    note += $"{Console.ReadLine()}#";
                    dataBase.WriteLine(now);

                    Console.WriteLine("Продолжить? д/н");
                    key = Console.ReadKey(true).KeyChar;
                } while (char.ToLower(key) == 'д');

            }
        }


        static void RightNow()
        {
            using (StreamReader dataBaseRead = new StreamReader("Database.csv", Encoding.Unicode))
            {
                string line;
                Console.WriteLine($"{"Номер сотрудника",15}{"Время",8} {"Ф.И.О. сотрудника"}");

                while ((line = dataBaseRead.ReadLine()) != null)
                {
                    string[] data = line.Split('#');
                    Console.WriteLine($"{data[0],15}{data[1],8} {data[2]}");
                }
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Приветствую. \nСегодня я попытааюсь впарить Вам свою домашку. " +
                "\nДля начала давайте определимся: \n Вы хотите вписать кого-то (1) или про кого-то узнать? (2)");

            while (true)
            {
                string choise = Console.ReadLine();

                switch (choise)
                {
                    case "1":
                        RightHere();
                        break;
                    case "2":
                        RightNow();
                        break;
                    default:
                        Console.WriteLine("Введите 1 или 2. Я на большее не запрограммирован.");
                        break;
                }
            }

            Console.ReadKey();
        }
    }
}
