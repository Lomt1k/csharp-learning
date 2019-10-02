using System;
using Yashin;

namespace Yashin
{
    class Con
    {
        public static void Print(string text, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.White; //возвращаем консоли изначальный белый цвет
        }

        public static void Pause()
        {
            Console.ReadKey();
        }

        public static string AskFor(string text, ConsoleColor color = ConsoleColor.Green)
        {
            Console.ForegroundColor = color;
            Console.Write(text + ": ");
            Console.ForegroundColor = ConsoleColor.White; //возвращаем консоли изначальный белый цвет
            return Console.ReadLine();
        }
        public static int AskForInt(string text, ConsoleColor color = ConsoleColor.Green)
        {
            Console.ForegroundColor = color;
            Console.Write(text + ": ");
            Console.ForegroundColor = ConsoleColor.White; //возвращаем консоли изначальный белый цвет
            return Convert.ToInt32(Console.ReadLine());
        }
        public static double AskForDouble(string text, ConsoleColor color = ConsoleColor.Green)
        {
            Console.ForegroundColor = color;
            Console.Write(text + ": ");
            Console.ForegroundColor = ConsoleColor.White; //возвращаем консоли изначальный белый цвет
            return Convert.ToDouble(Console.ReadLine());
        }
    }
}

/* Написать программу “Анкета”. Последовательно задаются вопросы (имя, фамилия, возраст, рост, вес). В результате вся информация выводится в одну строчку.
а) используя склеивание;
б) используя форматированный вывод;
в) *используя вывод со знаком $.  */

namespace Quest1
{
    class Quest1
    {
        static void Main(string[] args)
        {
            string firstName = Con.AskFor("Имя");
            string secondName = Con.AskFor("Фамилия");
            int age = Con.AskForInt("Возраст");
            int height = Con.AskForInt("Рост (см)");
            int mass = Con.AskForInt("Вес (кг)");

            Con.Print(" ");
            Con.Print("СКЛЕИВАНИЕ \t| " + firstName + " " + secondName + ", " + age + " года, рост " + height + " см, вес " + mass + " кг", ConsoleColor.Yellow);
            //Блин, я не знаю как добавить форматирование в метод Print ))
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("ФОРМАТИРОВАНИЕ \t| {0} {1}, {2} года, рост {3} см, вес {4} кг", firstName, secondName, age, height, mass);
            Console.WriteLine($"ЧЕРЕЗ $ \t| {firstName} {secondName}, {age} года, рост {height} см, вес {mass} кг");
            Console.ForegroundColor = ConsoleColor.White;
            Con.Pause();
        }
    }
}
