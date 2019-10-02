using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson6_Diary
{
    /// <summary>
    /// Представляет из себя запись в дневнике
    /// </summary>
    class Note
    {
        string title; //заголовок записи
        string text; //текст записи        
        int priority; //приоритетность (важность записи)
        string author; //автор записи  
        DateTime dateTime; //дата - время записи

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        public int Priority
        {
            get { return priority; }
            set { priority = value; }
        }

        public string Author
        {
            get { return author; }
            set { author
 = value; }
        }

        public DateTime DateTime
        {
            get => dateTime;
        }

        //конструктор
        public Note(string _title, string _text, DateTime _dateTime, int _priority, string _author)
        {
            title = _title;
            text = _text;
            dateTime = _dateTime;
            priority = _priority;
            author = _author;
        }
    }
}
