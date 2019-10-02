using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace CheatScan
{
    public class Log
    {
        string filename;

        public static Log mainLog;
        public static Log cleoLog;
        public static Log asiLog;
        public static Log sfLog;
        public static Log otherLog;

        public static Log openedLog; //хранит экземпляр лога, открытого на данный момент

        //конструктор
        public Log(string filename)
        {
            if (!Directory.Exists("Logs")) Directory.CreateDirectory("Logs");
            filename = "Logs\\" + filename;
            this.filename = filename;
            StreamWriter stream = new StreamWriter(filename, false);
            stream.WriteLine("<meta charset=utf-8> <body bgcolor=\"#303030\"> <font color=\"#FFFFFF\"> \n");
            stream.Close();
        }

        //получить полный путь к файлу лога
        public string Path
        {
            get { return Directory.GetCurrentDirectory() + $"\\{filename}"; }
        }

        public void Write(string text, string color = "#FFFFFF", bool isWarn = false)
        {
            StreamWriter stream = new StreamWriter(filename, true);
            if (color == "#FFFFFF") stream.Write(text);
            else stream.Write($"<font color=\"{color}\">" + text + "</font>");
            stream.Close();

            if (isWarn && this != mainLog) mainLog.Write(text, color);
            if (openedLog == this) //если запись идет в открытый лог - обновляем его в окне
            {
                Form1.NeedScrollToBottom = true;
                Form1.Instance.webBrowser1.Navigate(openedLog.Path); 
            }
        }
        public void WriteLine(string text = "", string color = "#FFFFFF", bool isWarn = false)
        {
            StreamWriter stream = new StreamWriter(filename, true);
            if (color == "#FFFFFF") stream.WriteLine(text + " <br>");
            else stream.WriteLine($"<font color=\"{color}\">" + text + "</font> <br>");
            stream.Close();

            if (isWarn && this != mainLog) mainLog.WriteLine(text, color); //если это варнинг 
            if (openedLog == this) //если запись идет в открытый лог - обновляем его в окне
            {
                Form1.NeedScrollToBottom = true;
                Form1.Instance.webBrowser1.Navigate(openedLog.Path);
            }
        }

    }
}
