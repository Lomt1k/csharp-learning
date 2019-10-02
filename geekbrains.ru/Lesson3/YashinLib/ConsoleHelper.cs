using System;

namespace YashinLib
{
    public class Con
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
            int readInt;
            if (int.TryParse(Console.ReadLine(), out readInt) == false)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Значение введено неверно. Попробуйте еще раз...");
                return AskForInt(text, color);
            }
            return Convert.ToInt32(readInt);
        }
        public static double AskForDouble(string text, ConsoleColor color = ConsoleColor.Green)
        {
            Console.ForegroundColor = color;
            Console.Write(text + ": ");
            Console.ForegroundColor = ConsoleColor.White; //возвращаем консоли изначальный белый цвет
            double readDouble;
            if (double.TryParse(Console.ReadLine(), out readDouble) == false)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Значение введено неверно. Попробуйте еще раз...");
                return AskForDouble(text, color);
            }
            return Convert.ToDouble(Console.ReadLine());
        }
    }
}
