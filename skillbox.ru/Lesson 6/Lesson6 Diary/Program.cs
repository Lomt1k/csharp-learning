using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson6_Diary
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("Рекомендую загрузить дневник из файла ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("test\n");
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("Консольный Дневник. Выберите действие: \n 1. Создать новый дневник \n 2. Загрузить дневник из файла");
            int entered = ConsoleHelper.AskForInt("Введите: ", 1, 2);

            switch (entered)
            {
                case 1: new Diary(); break; //создаём пустой дневник
                case 2: //загрузка дневника из файла
                    {
                        string filename = "";
                        while (!File.Exists(filename))
                        {
                            Console.Write("Введите название файла: ");
                            filename = Console.ReadLine() + ".diary";
                            if (!File.Exists(filename)) Console.WriteLine("Файл с таким названием не найден.");
                        }
                        new Diary(filename); //создаём дневник, загружая записи из существующего файла
                        break;
                    }
            }

        }
       
    }
}
