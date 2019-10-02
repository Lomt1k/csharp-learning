using System;
using System.Text;
using YashinLib;

/* Владимир Яшин
 * 2. Разработать методы для решения следующих задач. Дано сообщение:
 * а) Вывести только те слова сообщения, которые содержат не более чем n букв;
 * б) Удалить из сообщения все слова, которые заканчиваются на заданный символ;
 * в) Найти самое длинное слово сообщения;
 * г) Найти все самые длинные слова сообщения.
 * Постараться разработать класс MyString. 
 */

namespace Quest2
{
    class MyString
    {
        private char[] str;

        public MyString(string text)
        {
            str = new char[text.Length];
            for (int i = 0; i < text.Length; i++)
            {
                str[i] = text[i];
            }
        }

        public MyString(int size)
        {
            if (size < 1) size = 1;
            str = new char[size];
        }

        public override string ToString()
        {
            if (str == null) return "NULL";
            StringBuilder sb = new StringBuilder(str.Length);
            sb.Append(str);
            return sb.ToString();
        }

        public int Length
        {
            get { return str.Length; }
        }

        public char this[int i]
        {
            get
            {
                if (i < 0 || i >= str.Length) return ' ';
                return str[i];
            } 
            set
            {
                if (i < 0 || i >= str.Length) return;
                str[i] = value;
            }
        }

        public void Update(string text)
        {
            str = new char[text.Length];
            for (int i = 0; i < text.Length; i++)
            {
                str[i] = text[i];
            }
        }
        public void Update(char[] text)
        {
            str = new char[text.Length];
            for (int i = 0; i < text.Length; i++)
            {
                str[i] = text[i];
            }
        }

        ////////////////////////////// МЕТОДЫ, ТРЕБУЕМЫЕ ПО УСЛОВИЯМ ЗАДАЧИ

        public string GetLongestWord() //в) Найти самое длинное слово сообщения;
        {
            int idxStart = 0;
            int maxLettersInWord = 0;
            int maxWordIdx = 0;
            for (int i = 0; i <= str.Length; i++)
            {
                if (i == str.Length || str[i] == ' ' || str[i] == ',' || str[i] == '.' || str[i] == '!' || str[i] == '?')
                {
                    if (i - idxStart > maxLettersInWord)
                    {//новое самое большое слово
                        maxLettersInWord = i - idxStart;
                        maxWordIdx = idxStart;
                    }//новое самое большое слово
                    idxStart = i + 1;
                }
            }
            StringBuilder sb = new StringBuilder();
            int idx = maxWordIdx;
            while (idx < maxWordIdx + maxLettersInWord)
            {
                sb.Append(str[idx]);
                idx++;
            }
            return sb.ToString();
        }

    }

    class Quest2
    {
        static void Main(string[] args)
        {
            Con.Print("Введите сообщение:");
            MyString mystr = new MyString(Console.ReadLine());
            Console.WriteLine("Самое длинное слово в сообщении: " + mystr.GetLongestWord());

            Con.Pause();
        }
    }
}
