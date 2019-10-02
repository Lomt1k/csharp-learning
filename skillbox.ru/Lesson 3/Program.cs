using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_Theme_03
{
    // Написать игру, в которою могут играть два игрока.
    // При старте, игрокам предлагается ввести свои никнеймы.
    // Никнеймы хранятся до конца игры.

    // Программа загадывает случайное число gameNumber от 12 до 120 сообщая это число игрокам.
    // Игроки ходят по очереди(игра сообщает о ходе текущего игрока)
    // Игрок, ход которого указан вводит число userTry, которое может принимать значения 1, 2, 3 или 4,
    // введенное число вычитается из gameNumber
    // Новое значение gameNumber показывается игрокам на экране.
    // Выигрывает тот игрок, после чьего хода gameNumber обратилась в ноль.
    // Игра поздравляет победителя, предлагая сыграть реванш
    // 
    // * Бонус:
    // Подумать над возможностью реализации разных уровней сложности.
    // В качестве уровней сложности может выступать настраиваемое, в начале игры,
    // значение userTry, изменение диапазона gameNumber, или указание большего количества игроков (3, 4, 5...)

    // *** Сложный бонус
    // Подумать над возможностью реализации однопользовательской игры
    // т е игрок должен играть с компьютером

    class Program
    {
        static Random rand;
        static int gameNumber;

        static void Main(string[] args)
        {
            while (true)
            {
                //запуск игры (или рестарт)
                int players = AskForInt("Число игроков: ", 1, 8); //от 1 до 8 игроков. 1 игрок - игра с компьютером
                int difficult = AskForInt("Уровень сложности: ", 1, 3); //уровень сложности от 1 до 3
                int playerid = 0; //ID игрока, который ходит сейчас (ID 0 - бот)

                rand = new Random();
                gameNumber = rand.Next(12, 120) * difficult; //уровень сложности влияет на gameNumber                               
                
                while (gameNumber > 0)
                {//до тех пор, пока игра не окончена   
                    Console.WriteLine("\n\tGameNumber: " + gameNumber);
                    //выбираем ID следующего игрока
                    playerid++;
                    if (playerid > players) playerid = 0;
                    if (playerid == 0 && players > 1) playerid++;//бот (ID 0) не участвует в многопользовательской игре
                    
                    NextTurn(playerid); //даём ход следующему игроку (или боту)
                }//до тех пор, пока игра не окончена

                //конец игры
                if (playerid > 0) Console.WriteLine("\n\tИгра окончена! Победил игрок #" + playerid);
                else Console.WriteLine("\n\tИгра окончена! Победил компьютер");

                //предложение о реванше
                if (AskForInt("\nИгра окончена. Что дальше? \n1 - Новая игра \n0 - Выход \nВаш ответ: ", 0, 1) == 0) break;
                Console.Clear();
            }          

        }

        // Запрос числовых данных от игрока Int
        static int AskForInt(string request, int min = int.MinValue, int max = int.MaxValue)
        {
            int value;
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write(request);
            Console.ForegroundColor = ConsoleColor.White;

            while (!int.TryParse(Console.ReadLine(), out value) || value < min || value > max)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine($"Введены некорректные данные... Допустимые значения: от {min} до {max}");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write(request);
                Console.ForegroundColor = ConsoleColor.White;
            }
            return value;
        }

        //следующий ход в игре
        static void NextTurn(int playerid)
        {
            int userTry;

            if (playerid == 0)
            {//ход бота
                userTry = rand.Next(1, 5);
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("Компьютер сделал свой ход. userTry = ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(userTry);
            }//ход бота
            else
            {//ход игрока
                userTry = AskForInt($"Игрок #{playerid}, твой черед! userTry = ", 1, 4);
            }//ход игрока
            gameNumber -= userTry;
        }

    }
}
