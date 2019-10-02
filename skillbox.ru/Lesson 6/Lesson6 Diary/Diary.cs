using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson6_Diary
{
    class Diary
    {
        string filename; //название файла дневника - используется для сохранения в него при выходе из программы
        List<Note> notes; //содержит все записи, имеющиеся в дневнике
        bool diaryIsActive = true; //переключив на false - прекратим работу с текущим дневником ("закроем его")

        /// <summary>
        /// создание нового дневника
        /// </summary>
        public Diary()
        {
            notes = new List<Note>();
            while (diaryIsActive) NextCommand();
        }

        /// <summary>
        /// Загрузка дневника из файла
        /// </summary>
        /// <param name="_filename"></param>
        public Diary(string _filename)
        {
            notes = new List<Note>();
            filename = _filename;
            LoadDiary(filename); //загрузка дненика из файла
            while (diaryIsActive) NextCommand();
        }

        /// <summary>
        /// Запрос следующей команды от пользователя
        /// </summary>
        void NextCommand()
        {
            ShowNotes(); //отображаем записи

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\n Что вы хотите сделать? \n" +
                "1. Дообавить новую запись \n" +
                "2. Отобразить текст записи \n" +
                "3. Редактировать запись \n" +
                "4. Удалить запись \n" +
                "5. Добавить записи из другого дневника \n\n" +
                "6. Сортировка: сначала с наибольшим приоритетом \n" +
                "7. Сортировка: по автору \n" +
                "8. Сортировка: по дате - сначала новые \n" +
                "9. Сортировка: по дате - сначала старые \n" +
                "0. Сохранить дневник в файл и закрыть");


            switch (ConsoleHelper.AskForInt("Введите: ", 0, 9))
            {
                case 1: //добавить новую запись
                    {
                        AddNewNote();
                        break;
                    }
                case 2: //отобразить текст записи
                    {
                        if (notes.Count > 0)
                        {
                            int id = ConsoleHelper.AskForInt("Введите ID записи для отображения: ", 0, notes.Count - 1);
                            Console.Clear();
                            Console.WriteLine(notes[id].Title);
                            Console.WriteLine(notes[id].Text);
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write("\nНажмите любую клавишу для продолжения...");
                            Console.ReadKey();
                        }
                        break;
                    }
                case 3: //редактировать запись
                    {
                        if (notes.Count > 0)
                        {
                            int id = ConsoleHelper.AskForInt("Введите ID записи для редактирования: ", 0, notes.Count - 1);
                            Console.Clear();
                            Console.WriteLine(notes[id].Title + "\n");

                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write("Новый текст: ");
                            Console.ForegroundColor = ConsoleColor.White;
                            notes[id].Text = Console.ReadLine();

                            notes[id].Priority = ConsoleHelper.AskForInt("Новый приоритет: ", 0, 100);
                        }
                        break;
                    }
                case 4: //удалить запись
                    {
                        if (notes.Count > 0)
                        {
                            int id = ConsoleHelper.AskForInt("Введите ID записи для удаления: ", 0, notes.Count - 1);
                            notes.RemoveAt(id);
                        }
                        break;
                    }
                case 5: //добавить записи из другого дневника
                    {
                        string fname = ConsoleHelper.AskForFilename("Введите название дневника: ") + ".diary";
                        if (File.Exists(fname)) LoadDiary(fname);
                        else
                        {
                            Console.WriteLine("Дневник с таким именем не найден");
                            Console.WriteLine("Для продолжения нажмите любую клавишу...");
                            Console.ReadKey();
                        }
                        break;
                    }
                case 6: //Сортировка: сначала с наибольшим приоритетом
                    {
                        notes = notes.OrderByDescending(notes => notes.Priority).ToList();
                        break;
                    }
                case 7: //Сортировка: по автору
                    {
                        notes = notes.OrderBy(notes => notes.Author).ToList();
                        break;
                    }
                case 8: //Сортировка: по дате (сначала новые)
                    {
                        notes = notes.OrderByDescending(notes => notes.DateTime).ToList();
                        break;
                    }
                case 9: //Сортировка: по дате (сначала старые)
                    {
                        notes = notes.OrderBy(notes => notes.DateTime).ToList();
                        break;
                    }

                case 0: //сохранить дневник и закрыть
                    {                        
                        SaveDiary();
                        break;
                    }
            }
        }

        /// <summary>
        /// Ввод новой записи пользователем
        /// </summary>
        /// <returns></returns>
        void AddNewNote()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("Заголовок: ");
            Console.ForegroundColor = ConsoleColor.White;
            string title = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("Текст: ");
            Console.ForegroundColor = ConsoleColor.White;
            string text = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("Имя автора: ");
            Console.ForegroundColor = ConsoleColor.White;
            string author = Console.ReadLine();

            int priority = ConsoleHelper.AskForInt("Введите приоритет: ", 0, 100);

            notes.Add(new Note(title, text, DateTime.Now, priority, author));
        }

        /// <summary>
        /// Метод для вывода списка записей на экран
        /// </summary>
        void ShowNotes()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"{"ID",-3} {"Дата / Время",-20} {"Заголовок",-40} {"Приоритет",-9} {"Автор",-16}");
            Console.ForegroundColor = ConsoleColor.White;

            //отображаем записи (если они есть)
            if (notes.Count > 0) for (int i = 0; i < notes.Count; i++)
                {
                    Console.WriteLine($"{i,-3} {notes[i].DateTime,-20} {notes[i].Title,-40} {notes[i].Priority,-9} {notes[i].Author,-16}");
                }
        }

        /// <summary>
        /// функция для сохранения дневника в файл filename
        /// </summary>
        void SaveDiary()
        {
            diaryIsActive = false; //закрываем днвник после выполнения этой функции
            if (notes.Count == 0) return;
            //если filename не указан - запрашиваем ввод
            if (filename == null) filename = ConsoleHelper.AskForFilename("Введите название дневника: ") + ".diary"; 

            //далее сохраняем все записи в файл
            StreamWriter stream = new StreamWriter(filename, false);
            foreach (Note note in notes)
            {
                stream.WriteLine($"Title: {note.Title}");
                stream.WriteLine($"Text: {note.Text}");
                stream.WriteLine($"Author: {note.Author}");
                stream.WriteLine($"Priority: {note.Priority}");
                stream.WriteLine($"DateTime: {note.DateTime.ToBinary()}");
                stream.WriteLine("---");
            }
            stream.Close();
        }

        /// <summary>
        /// загрузка дневника (или добавление записей в этот дневник из другого дневника)
        /// </summary>
        /// <param name="_filename"></param>
        void LoadDiary(string _filename)
        {
            StreamReader stream = new StreamReader(_filename);
            while (!stream.EndOfStream)
            {
                string line = stream.ReadLine();
                if (line.StartsWith("Title: "))
                {
                    string title = line.Remove(0, 7);
                    string text = stream.ReadLine().Remove(0, 6);
                    string author = stream.ReadLine().Remove(0, 8);
                    int priority = Convert.ToInt32( stream.ReadLine().Remove(0, 10) );
                    DateTime dateTime = DateTime.FromBinary(Convert.ToInt64(stream.ReadLine().Remove(0, 10)));
                    notes.Add(new Note(title, text, dateTime, priority, author));
                }
            }
            stream.Close();            
        }
    }
}
