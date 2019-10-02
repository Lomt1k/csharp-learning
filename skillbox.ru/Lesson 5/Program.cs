using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example_005
{
    class Program
    {
        // Домашнее задание
        // Требуется написать несколько методов
        // Весь код должен быть откоммментирован

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("Задание 1: Матрицы");
                Console.WriteLine("Задание 2: Слова в тексте");
                Console.WriteLine("Задание 3: Удаление кратных символов");
                Console.WriteLine("Задание 4: Прогрессия");
                Console.WriteLine("Задание 5: Функция Аккермана\n");

                switch (AskForInt("Введите номер задания: ", 1, 5, ConsoleColor.DarkYellow))
                {
                    case 1: TastkMatrix(); break;
                    case 2: TaskWords(); break;
                    case 3: TaskFixString(); break;
                    case 4: TaskProgresion(); break;                        
                    default: TaskAckerman(); break;
                }
            }
            
        }

        /// <summary>
        /// Запрос числовых данных от игрока Int
        /// </summary>
        /// <param name="request"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <param name="requestColor"></param>
        /// <returns></returns>
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
        // Воспользовавшись решением задания 3 четвертого модуля
        // 1.1. Создать метод, принимающий число и матрицу, возвращающий матрицу умноженную на число
        // 1.2. Создать метод, принимающий две матрицу, возвращающий их сумму
        // 1.3. Создать метод, принимающий две матрицу, возвращающий их произведение
        /// <summary>
        /// Запрос матрицы от игрока (вводит её размерность, после чего её содержимое генерируется случайным образом)
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        static int[,] AskForMatrix(string request)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(request);
            int rows = AskForInt("Введите количество строк: ", 1, 10);
            int cols = AskForInt("Введите количество столбцов: ", 1, 10);

            int[,] result = new int[rows, cols];
            Random rand = new Random();

            //заполняем матрицу случайными числами
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    result[i, j] = rand.Next(10);
                }
            }

            PrintMatrix(result);
            return result;
        }

        /// <summary>
        /// Вывод матрицы на экран
        /// </summary>
        /// <param name="matrix"></param>
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

        /// <summary>
        /// Умножение матрицы на число
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        static int[,] MatrixMultNumber(int[,] matrix, int number)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] *= number;
                }
            }
            return matrix;
        }

        /// <summary>
        /// Сложение матриц
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        static bool TryMatrixSum(int[,] a, int[,] b, out int[,] result)
        {
            result = new int[0,0];
            if (a.GetLength(0) != b.GetLength(0) || a.GetLength(1) != b.GetLength(1)) return false; //матрицы не равны по размеру

            result = new int[ a.GetLength(0), a.GetLength(1) ];
            for (int i = 0; i < result.GetLength(0); i++)
            {
                for (int j = 0; j < result.GetLength(1); j++)
                {
                    result[i, j] = a[i, j] + b[i, j];
                }
            }
            return true;
        }

        /// <summary>
        /// Умножение матриц
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        static bool TryMatrixMult(int[,] a, int[,] b, out int[,] result)
        {
            result = new int[a.GetLength(0), b.GetLength(1)];
            if (a.GetLength(1) != b.GetLength(0)) return false; //матрицы нельзя перемножить
            
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < b.GetLength(1); j++)
                {
                    for (int k = 0; k < b.GetLength(0); k++)
                    {
                        result[i, j] += a[i, k] * b[k, j];
                    }
                }
            }
            return true;
        }

        static void TastkMatrix()
        {
            Console.Clear();

            int[,] a = AskForMatrix("Матрица А");

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Действие 1: Умножить матрицу на число");
            Console.WriteLine("Действие 2: Сложить с другой матрицей");
            Console.WriteLine("Действие 2: Умножить на другую матрицу\n");
            switch (AskForInt("Введите номер действия: ", 1, 3, ConsoleColor.DarkYellow))
            {
                case 1: //умножение матрицы на число
                    {
                        int number = AskForInt("Введите число: ");
                        PrintMatrix(MatrixMultNumber(a, number));
                        break;
                    }
                case 2:
                    {
                        int[,] b = AskForMatrix("Матрица B");
                        int[,] result;
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        if (TryMatrixSum(a, b, out result))
                        {
                            Console.Clear();
                            Console.WriteLine("Сложение матриц");
                            Console.ForegroundColor = ConsoleColor.White;
                            PrintMatrix(a);
                            Console.WriteLine("\n + \n");
                            PrintMatrix(b);
                            Console.WriteLine("\n = \n");
                            PrintMatrix(result);
                        }
                        else Console.WriteLine("Данные матрицы нельзя сложить");
                        break;
                    }
                case 3:
                    {
                        int[,] b = AskForMatrix("Матрица B");
                        int[,] result;
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        if (TryMatrixMult(a, b, out result))
                        {
                            Console.Clear();
                            Console.WriteLine("Умножение матриц");
                            Console.ForegroundColor = ConsoleColor.White;
                            PrintMatrix(a);
                            Console.WriteLine("\n * \n");
                            PrintMatrix(b);
                            Console.WriteLine("\n = \n");
                            PrintMatrix(result);
                        }
                        else Console.WriteLine("Данные матрицы нельзя перемножить");
                        break;
                    }

            }

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("\nДля продолжения нажмите любую клавишу...");
            Console.ReadKey();
        }

        // Задание 2.
        // 1. Создать метод, принимающий  текст и возвращающий слово, содержащее минимальное количество букв
        // 2.* Создать метод, принимающий  текст и возвращающий слово(слова) с максимальным количеством букв 
        // Примечание: слова в тексте могут быть разделены символами (пробелом, точкой, запятой) 
        // Пример: Текст: "A ББ ВВВ ГГГГ ДДДД  ДД ЕЕ ЖЖ ЗЗЗ"
        // 1. Ответ: А
        // 2. ГГГГ, ДДДД

        /// <summary>
        /// метод, принимающий  текст и возвращающий слово, содержащее минимальное количество букв
        /// </summary>
        /// <returns></returns>
        static string FindShortWord(string text)
        {
            string[] words = text.Split(' ', '.', ',');

            int findedIndex = 0;
            for (int i = 1; i < words.Length; i++)
            {
                if (words[i].Length < words[findedIndex].Length && words[i].Length > 0) findedIndex = i;
            }
            return words[findedIndex];
        }

        /// <summary>
        /// Создать метод, принимающий  текст и возвращающий слово(слова) с максимальным количеством букв
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        static string[] FindLongWords(string text)
        {
            string[] words = text.Split(' ', '.', ',');

            //считаем количество слов с самым большим количеством букв и создаем массив для хранения этих слов
            int maxWordLength = 0, count = 0;
            foreach (string word in words)
            {
                //нашли более длинное слово
                if (word.Length > maxWordLength)
                {
                    maxWordLength = word.Length;
                    count = 1;
                }
                else if (word.Length == maxWordLength) count++;
            }
            string[] result = new string[count];

            //заполняем созданный массив самыми длинными словами
            count = 0;
            foreach (string word in words)
            {
                if (word.Length == maxWordLength)
                {
                    result[count] = word;
                    count++;
                }
            }

            return result;
        }

        static void TaskWords()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("Введите текст: ");
            Console.ForegroundColor = ConsoleColor.White;
            string str = Console.ReadLine();

            Console.WriteLine("\nСамое короткое слово: " + FindShortWord(str));
            string longWords = "";
            foreach (string word in FindLongWords(str) )
            {
                longWords += word + " ";
            }
            Console.WriteLine("Самые длинные слова: " + longWords);

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("\nДля продолжения нажмите любую клавишу...");
            Console.ReadKey();
        }

        // Задание 3. Создать метод, принимающий текст. 
        // Результатом работы метода должен быть новый текст, в котором
        // удалены все кратные рядом стоящие символы, оставив по одному 
        // Пример: ПППОООГГГООООДДДААА >>> ПОГОДА
        // Пример: Ххххоооорррооошшшиий деееннннь >>> хороший день

        /// <summary>
        /// Метод, удаляющий из строки все кратные рядом стоящие символы, оставив по одному 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        static string FixString(string source)
        {
            StringBuilder sb = new StringBuilder(); //сюда сохраним "исправленную" строку
            sb.Append(source[0]); //в исправленной строке в любом случае будет первый символ из исходной

            //остальные символы строки проверяем через цикл и добавляем их в "исправленную", если это не повтор прежнего символа
            for (int i = 1; i < source.Length; i++)
            {
                if (char.ToLower(source[i]) !=  char.ToLower(source[i-1])) 
                {
                    sb.Append(source[i]);
                }
            }

            return sb.ToString();
        }

        static void TaskFixString()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Пример: Ххххоооорррооошшшиий деееннннь >>> хороший день\n");
            
            Console.Write("Введите текст: ");
            Console.ForegroundColor = ConsoleColor.White;
            string str = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("Результат: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(FixString(str));

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("\nДля продолжения нажмите любую клавишу...");
            Console.ReadKey();
        }

        // Задание 4. Написать метод принимающий некоторое количесво чисел, выяснить
        // является заданная последовательность элементами арифметической или геометрической прогрессии
        // 
        // Примечание
        //             http://ru.wikipedia.org/wiki/Арифметическая_прогрессия
        //             http://ru.wikipedia.org/wiki/Геометрическая_прогрессия
        //

        /// <summary>
        /// Метод определяет, является ли массив чисел арифметической или геометрической прогрессией
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        static bool IsProgression(double[] arr)
        {
            //--- арифметическая прогресссия
            double d = arr[2] - arr[1]; //находим разницу между 3 и 2 числами прогрессии
            //дальше проверяем в цикле - совпадают ли последующие d (между 4 и 3 числами, между 5 и 4 и тд..)
            int i = 3;
            for (; i < arr.Length; i++)
            {                
                if (arr[i] - arr[i - 1] != d) break; //прекращаем цикл если стало понятно, что это не арифм. прогрессия
            }
            if (i == arr.Length) return true; //если цикл полностью отработал - значит арифм. прогрессия

            //--- геометрическая прогрессия
            d = arr[2] / arr[1]; //находим знаменатель между 3 и 2 числами прогрессии
            //дальше проверяем в цикле - совпадают ли последующие знаменатели (между 4 и 3 числами, между 5 и 4 и тд..)
            i = 3;
            for (; i < arr.Length; i++)
            {
                if (arr[i] / arr[i - 1] != d) break; //прекращаем цикл если стало понятно, что это не геометр. прогрессия
            }
            if (i == arr.Length) return true; //если цикл полностью отработал - значит геометр. прогрессия

            return false;
        }

        static void TaskProgresion()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Поочередно вводите элементы последовательности (целые числа). Введите '0' чтобы завершить ввод...\n");
            List<double> arr = new List<double>();
            int value = -1;
            while (true)
            {
                value = AskForInt("Введите число: ");
                if (value == 0) break;
                arr.Add(value);
            }

            //выводим последовательность на экран в более наглядном виде
            Console.Clear();
            foreach (double e in arr)
            {
                Console.Write(e + " ");
            }


            if ( IsProgression(arr.ToArray()) )
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("\nДанная последовательность чисел является прогрессией");
            }                
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\nДанная последовательность чисел НЕ является прогрессией");
            }            

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\nДля продолжения нажмите любую клавишу...");
            Console.ReadKey();
        }

        // *Задание 5
        // Вычислить, используя рекурсию, функцию Аккермана:
        // A(2, 5), A(1, 2)
        // A(n, m) = m + 1, если n = 0,
        //         = A(n - 1, 1), если n <> 0, m = 0,
        //         = A(n - 1, A(n, m - 1)), если n> 0, m > 0.
        // 

        //Функция Аккермана
        static uint Ackerman(uint n, uint m)
        {
            if (n == 0) return m + 1;
            if (m == 0) return Ackerman(n - 1, 1);
            return Ackerman(n - 1, Ackerman(n, m - 1));
        }

        /// <summary>
        /// Запрос числовых данных от игрока UInt
        /// </summary>
        /// <param name="request"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <param name="requestColor"></param>
        /// <returns></returns>
        static uint AskForUInt(string request, uint min = uint.MinValue, uint max = uint.MaxValue, ConsoleColor requestColor = ConsoleColor.DarkGreen)
        {
            uint value;
            Console.ForegroundColor = requestColor;
            Console.Write(request);
            Console.ForegroundColor = ConsoleColor.White;

            while (!uint.TryParse(Console.ReadLine(), out value) || value < min || value > max)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine($"Введены некорректные данные... Допустимые значения: от {min} до {max}");
                Console.ForegroundColor = requestColor;
                Console.Write(request);
                Console.ForegroundColor = ConsoleColor.White;
            }
            return value;
        }

        static void TaskAckerman()
        {
            Console.Clear();
            uint n = AskForUInt("Введите n: ");
            uint m = AskForUInt("Введите m: ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\nРезультат: " + Ackerman(m, n));

            Console.WriteLine("\nДля продолжения нажмите любую клавишу...");
            Console.ReadKey();
        }
    }
}
