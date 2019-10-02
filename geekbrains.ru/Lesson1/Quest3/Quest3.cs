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

/* 3. 
 * а) Написать программу, которая подсчитывает расстояние между точками с координатами x1, y1 и x2,y2  * по формуле 
 * r=Math.Sqrt(Math.Pow(x2-x1,2)+Math.Pow(y2-y1,2). Вывести результат используя спецификатор формата .2f (с двумя знаками после запятой);
 * б) *Выполните предыдущее задание оформив вычисления расстояния между точками в виде метода; */

namespace Quest3
{
    class Program
    {
        static double GetDistanceBetweenPoints(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
        }

        static void Main(string[] args)
        {
            double x1 = Con.AskForDouble("x1");
            double y1 = Con.AskForDouble("y1");
            double x2 = Con.AskForDouble("x2", ConsoleColor.Blue);
            double y2 = Con.AskForDouble("y2", ConsoleColor.Blue);

            Con.Print(" ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Расстояние между точками: {0:F2}", GetDistanceBetweenPoints(x1, y1, x2, y2));
            Con.Pause();
        }
    }
}
