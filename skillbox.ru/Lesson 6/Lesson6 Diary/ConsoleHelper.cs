using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson6_Diary
{
    static class ConsoleHelper
    {
        /// <summary>
        /// Запрос числовых данных от пользователя Int
        /// </summary>
        /// <param name="request"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <param name="requestColor"></param>
        /// <returns></returns>
        public static int AskForInt(string request, int min = int.MinValue, int max = int.MaxValue, ConsoleColor requestColor = ConsoleColor.DarkYellow)
        {
            int value;
            Console.ForegroundColor = requestColor;
            Console.Write(request);
            Console.ForegroundColor = ConsoleColor.White;

            while (!int.TryParse(Console.ReadLine(), out value) || value < min || value > max)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine($"Введены некорректные данные... Допустимые значения: от {min} до {max}");
                Console.ForegroundColor = requestColor;
                Console.Write(request);
                Console.ForegroundColor = ConsoleColor.White;
            }
            return value;
        }

        /// <summary>
        /// Запрос имени файла, из которого / в который будет сохраняться дневник
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static string AskForFilename(string request, ConsoleColor requestColor = ConsoleColor.DarkYellow)
        {
            string inputtext;
            bool correctText;

            do
            {
                correctText = true;
                Console.ForegroundColor = requestColor;
                Console.Write(request);
                Console.ForegroundColor = ConsoleColor.White;
                inputtext = Console.ReadLine();

                //если введена пустая строка - не принимаем результат
                if (inputtext.Length < 1)
                {
                    correctText = false;
                    continue;
                }

                //в строке допускаются только буквы и цифры
                foreach (char c in inputtext)
                {
                    if (char.IsDigit(c) || char.IsLetter(c)) continue;
                    correctText = false;
                    break;
                }
            } while (!correctText);

            return inputtext;
        }
    }
}
