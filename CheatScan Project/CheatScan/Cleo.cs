using System;
using System.Collections.Generic;
using System.IO;

namespace CheatScan
{
    class Cleo
    {
        string filename;
        string shortname;

        #region Свойства
        public string FileName
        {
            get { return filename; }
        }
        public string ShortName
        {
            get { return shortname; }
        }
        #endregion

        //конструктор
        Cleo(string filename)
        {
            this.filename = filename;
            this.shortname = filename.Replace(Program.gta_path + "\\cleo\\", "");
        }

        //Получить все клео-скрипты
        public static List<Cleo> GetAllCleo()
        {
            List<Cleo> cleofiles = new List<Cleo>();
            foreach (string file in Directory.GetFiles(Program.gta_path + "\\cleo", "*.cs"))
            {
                cleofiles.Add(new Cleo(file));
            }
            if (cleofiles.Count == 0) return null;
            else return cleofiles;
        }

        //Получить все клео из лога (загруженные в памяти игры)
        public static List<string> GetAllLoadedCleo()
        {
            if (!File.Exists(Program.gta_path + "\\cleo.log")) return null;
            File.Copy(Program.gta_path + "\\cleo.log", "temp.log", true);
            string[] strings = File.ReadAllLines("temp.log");
            File.Delete("temp.log");

            List<string> cleoInMemory = new List<string>();
            string[] separator = { "Loading custom script " };
            foreach (string str in strings)
            {
                if (str == null) continue;
                if (str.Contains("Loading custom script "))
                {
                    string[] data = str.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                    string cleo = data[1].Replace("...", "");
                    cleoInMemory.Add(cleo);
                }
            }

            return cleoInMemory;
        }
    }
}
