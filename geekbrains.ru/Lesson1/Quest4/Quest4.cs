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

/* 4. Написать программу обмена значениями двух переменных
а) с использованием третьей переменной;
б) *без использования третьей переменной. */

namespace Quest4
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = Con.AskForInt("A");
            int b = Con.AskForInt("B");

            Con.Print("\nКручу верчу, запутать хочу...", ConsoleColor.Blue);
            a = a * b;
            b = a / b;
            a /= b;
            Console.WriteLine($"A: {a} \nB: {b}");
            Con.Pause();
        }
    }
}
