using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;
using System.Threading;
using Microsoft.Win32;

namespace CheatScan
{
    static class Program
    {
        public static string version = "1.01"; //версия CheatScan

        public static Process gta_process;
        public static string gta_path;
        public static double lifetimeInMinutes;
        public static double lifetimeInSeconds;
        public static Thread threadScan;

        public static bool Using_CLEO = false;
        public static bool Using_SAMPFUNCS = false;
        public static bool Using_D3D9 = false;
        public static bool Using_ASI = false;
        public static bool Using_OTHER = false;

        public static List<ProcessModule> Modules_SF;
        public static List<ProcessModule> Modules_ASI;
        public static List<ProcessModule> Modules_OTHER;

        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            gta_process = FindGTA();
            if (gta_process == null) return;
            gta_path = gta_process.MainModule.FileName.Replace("\\gta_sa.exe", "");
            lifetimeInMinutes = (DateTime.Now - gta_process.StartTime).TotalMinutes;
            lifetimeInSeconds = (DateTime.Now - gta_process.StartTime).TotalSeconds;
            ModuleFucs.GetModules();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form1 mainForm = new Form1();
            threadScan = new Thread(StartScan);
            threadScan.Priority = ThreadPriority.Highest;
            threadScan.Start();
            Application.ApplicationExit += new EventHandler(Program.OnApplicationExit);
            Application.Run(mainForm);
        }

        //Метод для поиска процесса запущенной ГТА
        static Process FindGTA()
        {
            Process[] processes = Process.GetProcessesByName("gta_sa");
            if (processes.Length != 1)
            {
                if (processes.Length == 0) MessageBox.Show("GTA San Andreas не запущена", "CheatScan", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else MessageBox.Show("Запущено сразу несколько окон с GTA San Andreas", "CheatScan", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }
            return processes[0];
        }

        //функция для выявления плохих названий файлов (например, кириллица)
        static bool BadCharsUsed(string str)
        {
            foreach (char c in str)
            {
                if ('a' <= c && c <= 'z') continue;
                if ('A' <= c && c <= 'Z') continue;
                if (Char.IsDigit(c) || Char.IsWhiteSpace(c)) continue;
                if (c == '.' || c == '!' || c == '@' || c == '#' || c == '$' || c == '№' || c == '_' || c == '-') continue;
                if (c == '[' || c == ']' || c == '(' || c == ')' || c == '|' || c == '+' || c == '&' || c == '^') continue;
                return true;
            }
            return false;
        }

        //для изменения текста Label из другого потока
        public static void ChangeLabelText(MetroFramework.Controls.MetroLabel label, string text = "")
        {
            Form1.Instance.BeginInvoke(new ThreadStart(delegate
            {
                label.Text = text;
            }));
        }
        //для изменения текста кнопки из другого потока
        public static void ChangeButtonText(MetroFramework.Controls.MetroButton button, string text = "")
        {
            Form1.Instance.BeginInvoke(new ThreadStart(delegate
            {
                button.Text = text;
            }));
        }

        //при закрытии программы
        static void OnApplicationExit(object sender, EventArgs e)
        {
            //чудо скрипт для самоудаления файла программы после закрытия
            StreamWriter stream = new StreamWriter("killer.vbs", false);
            stream.Write("dim filesys\nSet filesys = CreateObject(\"Scripting.FileSystemObject\")\n" + $"filesys.DeleteFile \"{Application.ExecutablePath.Replace(Application.StartupPath + "\\", "")}\"\n" + "filesys.DeleteFile \"killer.vbs\"\n");
            stream.Close();
            Process.Start("killer.vbs");           
        }

        static void StartScan()
        {
            Log.mainLog.WriteLine("Начинаем сканирование игры... ", "#808080");

            //Проверка изменений файлов и папок
            ChangeLabelText(Form1.Instance.ScanStatus, "Сканируем изменения папок...");
            SCAN_LASTCHANGES();
            //Проверка на s0beit
            ChangeLabelText(Form1.Instance.ScanStatus, "Сканируем на s0beit...");
            if (Using_D3D9) SCAN_D3D9();
            //Проверка CLEO
            ChangeLabelText(Form1.Instance.ScanStatus, "Сканируем CLEO...");
            if (Using_CLEO) SCAN_CLEO();
            //Проверка ASI плагинов
            ChangeLabelText(Form1.Instance.ScanStatus, "Сканируем ASI плагины...");
            if (Using_ASI) SCAN_ASI();
            //Проверка SAMPFUNCS
            ChangeLabelText(Form1.Instance.ScanStatus, "Сканируем SAMPFUNCS...");
            if (Using_SAMPFUNCS) SCAN_SAMPFUNCS();
            //Проверка сторонних модулей
            ChangeLabelText(Form1.Instance.ScanStatus, "Сканируем прочие модули...");
            if (Using_OTHER) SCAN_OTHER();

            //Остальное
            SCAN_GONWIK_AIM(); //Проверка на gonwik aim


            ChangeLabelText(Form1.Instance.ScanStatus, "Сканирование завершено");
            Log.mainLog.WriteLine("Сканирование игры завершено.", "#808080");
        }

        //Метод для сканирования последних изменений (по дате)
        static void SCAN_LASTCHANGES()
        {
            List<string> allDirs = new List<string>();
            allDirs.Add(gta_path);
            allDirs.AddRange(Directory.GetDirectories(gta_path, "*", SearchOption.AllDirectories));
            List<string> allFiles = new List<string>();
            allFiles.AddRange(Directory.GetFiles(gta_path, "*", SearchOption.AllDirectories));

            DateTime dt_startGame = gta_process.StartTime;
            bool ChangesFound = false;

            foreach (string dir in allDirs)
            {
                DateTime lastChange = Directory.GetLastWriteTime(dir);
                if ((lastChange - dt_startGame).TotalSeconds > 60)
                {
                    if (dir == gta_path) Log.mainLog.WriteLine("В папке с игрой обнаружены изменения после запуска игры! | " + lastChange.ToString(), "#FF0000");
                    else Log.mainLog.WriteLine("В папке " + dir.Replace(gta_path + "\\", "") + " обнаружены изменения после запуска игры! | " + lastChange.ToString(), "#FF0000");
                    ChangesFound = true;
                }
            }
            foreach (string file in allFiles)
            {
                DateTime lastChange = File.GetLastWriteTime(file);
                if ((lastChange - dt_startGame).TotalSeconds > 60)
                {
                    if (file == gta_path + "\\cleo.log") Log.cleoLog.WriteLine("Файл " + file.Replace(gta_path + "\\", "") + " был изменен после запуска игры!  | " + lastChange.ToString(), "#FF0000");
                    Log.mainLog.WriteLine("Файл " + file.Replace(gta_path + "\\", "") + " был изменен после запуска игры!  | " + lastChange.ToString(), "#FF8C00");
                    ChangesFound = true;
                }                
            }
            if (ChangesFound == false) Log.mainLog.WriteLine("Файлы и папки после запуска игры не изменялись.", "#808080");
            return;
        }

        //Метод для сканирования на Собейт
        static void SCAN_D3D9()
        {
            if (!File.Exists(gta_path + "\\d3d9.dll"))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Log.mainLog.WriteLine("В памяти игры обнаружен d3d9.dll. Пользователь попытался скрыть его, удалив файл из папки с игрой!", "#FF0000");
                Log.mainLog.WriteLine("");
            }
            else
            {
                string filetext = File.ReadAllText(gta_path + "\\d3d9.dll");
                if (filetext.Contains("s0beit") || filetext.Contains("mod_sa.ini"))
                {
                    Log.mainLog.WriteLine("В памяти игры обнаружен d3d9.dll. По результатам проверки - чит s0beit!", "#FF0000");
                }
                else if (filetext.Contains("enbseries"))
                {
                    Log.mainLog.WriteLine("В памяти игры обнаружен d3d9.dll. По результатам проверки - графический мод ENB Series", "#008000");
                }
                else
                {
                    Log.mainLog.WriteLine("В памяти игры обнаружен d3d9.dll. По результатам проверки - неизвестный модуль (не s0beit и не ENB Series)", "#808080");
                }
                Log.mainLog.WriteLine("");
            }            
            return;
        }

        //Метод для сканирования CLEO скриптов
        static void SCAN_CLEO()
        {
            FileCheck.LoadCheatList_CLEO();
            Log.cleoLog.WriteLine("Установленные CLEO:", "#808080");

            List<string> cleosInMemory = Cleo.GetAllLoadedCleo(); //получаем список клео, загруженных в память игры (из cleo.log)
            List<Cleo> cleos = Cleo.GetAllCleo(); //получаем список клео из папки CLEO
            ChangeButtonText(Form1.Instance.button_CLEO, $"CLEO ({cleos.Count})");

            if (cleosInMemory != null && cleosInMemory.Count != cleos.Count)
            {
                Log.cleoLog.WriteLine("Количество скриптов в папке CLEO не совпадает с количеством скриптов в памяти игры!", "#FF0000", true);
                Log.cleoLog.Write("Скриптов в папке: ", "#FF0000", true);
                Log.cleoLog.Write($"{cleos.Count}&nbsp &nbsp ", "#FFFFFF", true);
                Log.cleoLog.Write("Скриптов в памяти игры: ", "#FF0000", true);
                Log.cleoLog.WriteLine($"{cleosInMemory.Count}", "#FFFFFF", true);
                Log.cleoLog.WriteLine("", "", true);
            }

            foreach (Cleo cleo in cleos)
            {//цикл для всех клео
                Log.cleoLog.Write("* " + cleo.ShortName);

                //--- Скан файла по базе читов
                string findCheat = FileCheck.Check(FileCheck.CheatList_CLEO, cleo.FileName);
                if (findCheat != null)
                {
                    Log.cleoLog.Write($" (чит {findCheat})", "#FF0000");
                    //ручной варн в mainLog
                    Log.mainLog.Write("Обнаружен чит ");
                    Log.mainLog.Write($"{findCheat} ", "#FF0000");
                    Log.mainLog.Write("в папке CLEO (файл ");
                    Log.mainLog.Write($"{cleo.ShortName}", "#AFAFAF");
                    Log.mainLog.WriteLine(")");
                }
                //--- Скан файла по базе читов

                
                if (cleosInMemory != null) 
                {//cleo.log есть
                    bool fileInMenory = false;
                    if (cleosInMemory.Contains(cleo.ShortName))
                    {
                        fileInMenory = true;
                        cleosInMemory.Remove(cleo.ShortName);
                    }
                    if (!fileInMenory) //файл не найден в памяти игры - возможно в назнвании клео были русские символы!
                    {//исправление бага с кириллицей в названии клео   
                        foreach (var memorycleo in cleosInMemory)
                        {
                            if (BadCharsUsed(memorycleo) && memorycleo.Length == cleo.ShortName.Length)
                            {
                                fileInMenory = true;
                                cleosInMemory.Remove(cleo.ShortName);
                            }
                        }
                    }//исправление бага с кириллицей в названии клео
                    if (!fileInMenory)
                    {
                        Log.cleoLog.Write(" (не обнаружен в памяти игры)", "#FF0000");
                        //ручной варн в mainLog
                        Log.mainLog.Write("Обнаружен CLEO скрипт ");
                        Log.mainLog.Write(cleo.ShortName, "#FF0000");
                        Log.mainLog.WriteLine(", которого нет в памяти игры. Пользователь попытался замаскировать его, переименовав файл после запуска игры!");
                    }                    
                }//cleo.log есть  
                Log.cleoLog.WriteLine();
            }//цикл для всех клео

            if (cleosInMemory != null && cleosInMemory.Count > 0)
            {
                //исключаем багнутые названия
                List<string> temp = new List<string>();
                foreach (string cs in cleosInMemory) temp.Add(cs);
                foreach (string cs in temp) if (BadCharsUsed(cs)) cleosInMemory.Remove(cs);

                if (cleosInMemory.Count > 0)
                {
                    Log.cleoLog.WriteLine("", "", true);
                    Log.cleoLog.WriteLine("В памяти обнаружены CLEO, которых нет в папке (были переименованы или удалены):", "#FFFFFF", true);
                    foreach (string script in cleosInMemory)
                    {
                        Log.cleoLog.WriteLine("* " + script, "#FF0000", true);
                    }
                }
            }
            Log.mainLog.WriteLine("Сканирование CLEO завершено.", "#808080");
            return;
        }

        //Метод для сканирования ASI плагинов
        static void SCAN_ASI()
        {
            FileCheck.LoadCheatList_ASI();
            Log.asiLog.WriteLine("В памяти игры обнаружены ASI плагины. Плагинов: " + Modules_ASI.Count, "#808080");
            foreach (ProcessModule module in Modules_ASI)
            {
                Log.asiLog.Write("* " + module.ModuleName);
                if (!File.Exists(gta_path + "\\" + module.ModuleName))
                {
                    Log.asiLog.Write(" (пользователь попытался скрыть его, удалив файл из папки с игрой!)", "#FF0000");
                    //ручной варн в mainLog
                    Log.mainLog.Write("В памяти игры обнаружен ASI плагин ");
                    Log.mainLog.Write($"{module.ModuleName} ", "#FF0000");
                    Log.mainLog.WriteLine(". Пользователь попытался скрыть его, удалив файл из папки с игрой!");
                }
                else
                {
                    //--- Скан файла по базе читов
                    string findCheat = FileCheck.Check(FileCheck.CheatList_ASI, gta_path + "\\" + module.ModuleName);
                    if (findCheat != null)
                    { 
                        Log.asiLog.Write($" (обнаружен чит {findCheat})", "#FF0000");
                        //ручной варн в mainLog
                        Log.mainLog.Write("Обнаружен чит ");
                        Log.mainLog.Write($"{findCheat} ", "#FF0000");
                        Log.mainLog.Write("в папке с игрой (файл ");
                        Log.mainLog.Write(module.ModuleName, "#AFAFAF");
                        Log.mainLog.WriteLine(")");
                    }
                    //--- Скан файла по базе читов
                }
                Log.asiLog.WriteLine("");
            }
            Log.mainLog.WriteLine("Сканирование ASI завершено.", "#808080");
            return;
        }

        //Метод для сканирования SAMPFUNCS
        static void SCAN_SAMPFUNCS()
        {
            FileCheck.LoadCheatList_SF();
            Log.sfLog.WriteLine("В памяти игры обнаружена библиотека SAMPFUNCS. Плагинов: " + Modules_SF.Count, "#808080");
            foreach (ProcessModule module in Modules_SF)
            {
                Log.sfLog.Write("* " + module.ModuleName);
                if (!File.Exists(gta_path + "\\SAMPFUNCS\\" + module.ModuleName))
                {
                    Log.sfLog.Write(" (пользователь попытался скрыть его, удалив файл из папки с игрой!)", "#FF0000");
                    //ручной варн в mainLog
                    Log.mainLog.Write("В памяти игры обнаружен SF плагин ");
                    Log.mainLog.Write($"{module.ModuleName} ", "#FF0000");
                    Log.mainLog.WriteLine(". Пользователь попытался скрыть его, удалив файл из папки SAMPFUNCS!");
                }
                else
                {
                    //--- Скан файла по базе читов
                    string findCheat = FileCheck.Check(FileCheck.CheatList_SF, gta_path + "\\SAMPFUNCS\\" + module.ModuleName);
                    if (findCheat != null)
                    {
                        Log.sfLog.Write($" (обнаружен чит {findCheat})", "#FF0000");
                        //ручной варн в mainLog
                        Log.mainLog.Write("Обнаружен чит ");
                        Log.mainLog.Write($"{findCheat} ", "#FF0000");
                        Log.mainLog.Write("в папке SAMPFUNCS (файл ");
                        Log.mainLog.Write(module.ModuleName, "#AFAFAF");
                        Log.mainLog.WriteLine(")");
                    }
                    //--- Скан файла по базе читов
                }
                Log.sfLog.WriteLine("");
            }
            Log.mainLog.WriteLine("Сканирование SAMPFUNCS завершено.", "#808080");
            return;
        }

        //Метод для сканирования прочих модулей
        static void SCAN_OTHER()
        {
            Log.otherLog.WriteLine("\nВ памяти игры обнаружены неизвестные модули. Модулей: " + Modules_OTHER.Count, "#808080");
            foreach (ProcessModule module in Modules_OTHER)
            {
                Log.otherLog.Write("* " + module.ModuleName);
                if (module.FileName.Contains(gta_path))
                {//модуль должен быть расположен в папке с игрой
                    if (!File.Exists(module.FileName))
                    {
                        Log.otherLog.Write(" (пользователь попытался скрыть его, удалив файл из папки с игрой!)");
                        //ручной варн в mainLog
                        Log.mainLog.Write("В памяти игры обнаружен неизвестный модуль ");
                        Log.mainLog.Write($"{module.ModuleName} ", "#FF0000");
                        Log.mainLog.WriteLine(". Пользователь попытался скрыть его, удалив файл из папки с игрой!");
                    }
                    else Console.Write(" | Путь к файлу: " + module.FileName.Replace(gta_path, ""), "#808080");
                }//модуль должен быть расположен в папке с игрой
                else Log.otherLog.Write(" | Путь к файлу: " + module.FileName, "#808080");

                Log.otherLog.WriteLine("");
            }
            Log.mainLog.WriteLine("Сканирование прочих модулей завершено.", "#808080");
            return;
        }

        //скан на приватный aim gonwik
        static void SCAN_GONWIK_AIM()
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\BlastHack");
            if (key != null)
            {
                string[] names = key.GetValueNames();
                foreach (string name in names)
                {
                    if (name == "aimgonwik") Log.mainLog.WriteLine("Обнаружен чит GONWIK AIM!", "#FF0000");
                }
            }
            return;
        }


    }
}
