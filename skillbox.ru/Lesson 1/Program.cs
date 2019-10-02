﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_01
{
    class Program
    {
        static void Main(string[] args)
        {
            // Создание базы данных из 50 сотрудников
            Repository repository = new Repository(50);

            // Печать в консоль всех сотрудников
            repository.Print("База данных до преобразования");

            //увольняем тех, у кого зп более 30к
            repository.DeleteWorkerBySalary(30000);

            // Печать в консоль сотрудников, которые не попали под увольнение
            repository.Print("База данных после увольнения высокооплачиваемых сотрудников");
            Console.ReadKey();


            #region Домашнее задание

            // Уровень сложности: просто
            // Задание 1. Переделать программу так, чтобы до первой волны увольнени в отделе было не более 20 сотрудников

            // Уровень сложности: средняя сложность
            // * Задание 2. Создать отдел из 40 сотрудников и реализовать несколько увольнений, по результатам
            //              которых в отделе болжно остаться не более 30 работников

            // Уровень сложности: сложно
            // ** Задание 3. Создать отдел из 50 сотрудников и реализовать увольнение работников
            //               чья зарплата превышает 30000руб



            #endregion

        }
    }
}