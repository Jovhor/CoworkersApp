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


        static void Main(string[] args)
        {
            using (StreamWriter dataBase = new StreamWriter ("DataBase.csv", true, Encoding.Unicode))
            {
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

            using (StreamReader dataBaseRead = new StreamReader ("Database.csv", Encoding.Unicode))
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
    }
}
