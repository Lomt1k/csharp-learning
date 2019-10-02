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

/* 2. Ввести вес и рост человека. 
 * Рассчитать и вывести индекс массы тела(ИМТ) по формуле I=m/(h*h); 
 * где m-масса тела в килограммах, h - рост в метрах  */

namespace Quest2
{
    class Quest2
    {
        static void Main(string[] args)
        {
            double m = Con.AskForDouble("Вес (кг)");
            double h = Con.AskForDouble("Вес (см)") / 100.0;

            Con.Print(" ");
            double i = m / (h*h);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Индекс Массы Тела: {0:F1}", i);
            Con.Pause();
        }
    }
}
