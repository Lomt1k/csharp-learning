using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_Theme_04
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Задание 1: Учёт финансов");
                Console.WriteLine("Задание 2: Матрицы\n");

                switch (AskForInt("Введите номер задания: ", 1, 2, ConsoleColor.DarkYellow))
                {
                    case 1: TaskFinance(); break;
                    case 2: TaskMatrix();  break;
                    default: break;
                }
            }            
        }

        // Запрос числовых данных от игрока Int
        static int AskForInt(string request, int min = int.MinValue, int max = int.MaxValue, ConsoleColor requestColor = ConsoleColor.DarkGreen)
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



        // Задание 1.
        // Заказчик просит вас написать приложение по учёту финансов
        // и продемонстрировать его работу.
        // Суть задачи в следующем: 
        // Руководство фирмы по 12 месяцам ведет учет расходов и поступлений средств. 
        // За год получены два массива – расходов и поступлений.
        // Определить прибыли по месяцам
        // Количество месяцев с положительной прибылью.
        // Добавить возможность вывода трех худших показателей по месяцам, с худшей прибылью, 
        // если есть несколько месяцев, в некоторых худшая прибыль совпала - вывести их все.
        // Организовать дружелюбный интерфейс взаимодействия и вывода данных на экран

        // Пример
        //       
        // Месяц      Доход, тыс. руб.  Расход, тыс. руб.     Прибыль, тыс. руб.
        //     1              100 000             80 000                 20 000
        //     2              120 000             90 000                 30 000
        //     3               80 000             70 000                 10 000
        //     4               70 000             70 000                      0
        //     5              100 000             80 000                 20 000
        //     6              200 000            120 000                 80 000
        //     7              130 000            140 000                -10 000
        //     8              150 000             65 000                 85 000
        //     9              190 000             90 000                100 000
        //    10              110 000             70 000                 40 000
        //    11              150 000            120 000                 30 000
        //    12              100 000             80 000                 20 000
        // 
        // Худшая прибыль в месяцах: 7, 4, 1, 5, 12
        // Месяцев с положительной прибылью: 10
        static void TaskFinance()
        {
            Console.Clear();
            // За год получены два массива – расходов и поступлений.
            // Определить прибыли по месяцам
            int[] income = new int[13]; //доходы
            int[] costs = new int[13]; //расходы
            int[] profit = new int[13]; //прибыль

            //задаем данные
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Месяц   | {"Доходы",10} {"Расходы",10} {"Прибыль",10}");
            Console.ForegroundColor = ConsoleColor.White;

            Random rand = new Random();
            int goodMonth = 0; // Количество месяцев с положительной прибылью.
            for (int i = 1; i <= 12; i++)
            {
                income[i] = rand.Next(15) * 10_000; //задаем доходы
                costs[i] = rand.Next(10) * 10_000 + 10_000; //задаем расходы
                profit[i] = income[i] - costs[i]; //считаем прибыль
                if (profit[i] > 0) goodMonth++;

                // Организовать дружелюбный интерфейс взаимодействия и вывода данных на экран
                string date = (i < 10) ? "2018.0" + i : "2018." + i;
                Console.WriteLine($"{date} | {income[i],10} {costs[i],10} {profit[i],10}");
            }

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"\nКоличество месяцев с положительной прибылью: {goodMonth}");

            // Добавить возможность вывода трех худших показателей по месяцам, с худшей прибылью, 
            // если есть несколько месяцев, в некоторых худшая прибыль совпала - вывести их все.
            int[] tempArray = profit;
            Console.WriteLine("\nТри худших показателя по прибыли:");
            for (int i = 0; i < 3; i++)
            {
                int badValue = tempArray.Min();
                Console.Write(badValue + " в месяцах: ");

                for (int month = 1; month <= 12; month++)
                {
                    if (tempArray[month] == badValue)
                    {
                        tempArray[month] = int.MaxValue; //ставим макс значение, чтобы в следующей итерации i цикла этот месяц не обрабатывался снова
                        Console.Write(month + " ");
                    }
                }
                Console.WriteLine(""); //переход на новую строку после перечисления всех месяцев
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\nДля продолжения нажмите любую клавишу...");
            Console.ReadKey();
        }




        // * Задание 3.1
        // Заказчику требуется приложение позволяющщее умножать математическую матрицу на число
        // Справка https://ru.wikipedia.org/wiki/Матрица_(математика)
        // Справка https://ru.wikipedia.org/wiki/Матрица_(математика)#Умножение_матрицы_на_число
        // Добавить возможность ввода количество строк и столцов матрицы и число,
        // на которое будет производиться умножение.
        // Матрицы заполняются автоматически. 
        // Если по введённым пользователем данным действие произвести невозможно - сообщить об этом
        //
        // Пример
        //
        //      |  1  3  5  |   |  5  15  25  |
        //  5 х |  4  5  7  | = | 20  25  35  |
        //      |  5  3  1  |   | 25  15   5  |
        //
        //
        // ** Задание 3.2
        // Заказчику требуется приложение позволяющщее складывать и вычитать математические матрицы
        // Справка https://ru.wikipedia.org/wiki/Матрица_(математика)
        // Справка https://ru.wikipedia.org/wiki/Матрица_(математика)#Сложение_матриц
        // Добавить возможность ввода количество строк и столцов матрицы.
        // Матрицы заполняются автоматически
        // Если по введённым пользователем данным действие произвести невозможно - сообщить об этом
        //
        // Пример
        //  |  1  3  5  |   |  1  3  4  |   |  2   6   9  |
        //  |  4  5  7  | + |  2  5  6  | = |  6  10  13  |
        //  |  5  3  1  |   |  3  6  7  |   |  8   9   8  |
        //  
        //  
        //  |  1  3  5  |   |  1  3  4  |   |  0   0   1  |
        //  |  4  5  7  | - |  2  5  6  | = |  2   0   1  |
        //  |  5  3  1  |   |  3  6  7  |   |  2  -3  -6  |
        static void TaskMatrix()
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Размерность матриц");
            int rows = AskForInt("Введите количество строк: ", 1, 10);
            int cols = AskForInt("Введите количество столбцов: ", 1, 10);
            int[,] mA = AskForMatrix("Введите матрицу А", rows, cols, ConsoleColor.DarkYellow);            

            switch (AskForInt("Что вы хотите сделать? \n1 - Умножить матрицу на число \n2 - Сложить с другой матрицей \n3 - Вычесть другую матрицу \nВведите: ", 1, 3))
            {
                case 1: 
                    {
                        //умножение на число
                        int numb = AskForInt("Введите число: ");
                        for (int row = 0; row < rows; row++)
                        {
                            for (int col = 0; col < cols; col++)
                            {
                                mA[row, col] *= numb;
                            }
                        }                        
                    }
                    break;
                case 2: 
                    {
                        //сложение с другой матрицей
                        int[,] mB = AskForMatrix("Введите матрицу B", rows, cols, ConsoleColor.DarkYellow);
                        for (int row = 0; row < rows; row++)
                        {
                            for (int col = 0; col < cols; col++)
                            {
                                mA[row, col] += mB[row, col];
                            }
                        }
                    }
                    break;
                default:
                    {
                        //вычитание другой матрицы
                        int[,] mB = AskForMatrix("Введите матрицу B", rows, cols, ConsoleColor.DarkYellow);
                        for (int row = 0; row < rows; row++)
                        {
                            for (int col = 0; col < cols; col++)
                            {
                                mA[row, col] -= mB[row, col];
                            }
                        }
                    }
                    break;
            }

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Результат");
            Console.ForegroundColor = ConsoleColor.White;
            PrintMatrix(mA);            

            Console.Write("\nДля продолжения нажмите любую клавишу...");
            Console.ReadKey();
        }

        //запрос матрицы от пользователя
        static int[,] AskForMatrix(string request, int rows, int cols, ConsoleColor requestColor = ConsoleColor.DarkGreen)
        {
            int[,] result = new int[rows, cols];
            Console.ForegroundColor = requestColor;
            Console.WriteLine(request);
            Console.ForegroundColor = ConsoleColor.White;

            for (int row = 0; row < rows; row++)
            {

                for (int col = 0; col < cols; col++)
                {
                    result[row, col] = AskForInt($"Элемент {row} x {col}: ");
                }
            }

            PrintMatrix(result);
            return result;
        }

        //метод для вывода матрицы на экран
        static void PrintMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                Console.Write("|| ");
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col],9}");
                }
                Console.WriteLine("         ||");
            }
        }
    }
}
