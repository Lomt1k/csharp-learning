using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace CheatScan
{
    static class ModuleFucs
    {
        //Получить модули, подключенные к процессу игры
        public static void GetModules()
        {
            Program.Modules_SF = new List<ProcessModule>();
            Program.Modules_ASI = new List<ProcessModule>();
            Program.Modules_OTHER = new List<ProcessModule>();

            foreach (ProcessModule module in Program.gta_process.Modules)
            {
                bool showThisModule = true;
                foreach (string IgnoreModule in IgroreModuleNames)
                {
                    if (module.FileName.Contains(IgnoreModule))
                    {
                        showThisModule = false;
                        break;
                    }
                }
                if (showThisModule == true)
                {
                    if (module.ModuleName == "CLEO.asi" && module.FileName == Program.gta_path + "\\CLEO.asi") Program.Using_CLEO = true;
                    else if (module.ModuleName == "SAMPFUNCS.asi" && module.FileName == Program.gta_path + "\\SAMPFUNCS.asi") Program.Using_SAMPFUNCS = true;
                    else if (module.ModuleName == "d3d9.dll" && module.FileName == Program.gta_path + "\\d3d9.dll") Program.Using_D3D9 = true;
                    else if (module.ModuleName.Contains(".sf") && module.FileName == Program.gta_path + "\\SAMPFUNCS\\" + module.ModuleName) Program.Modules_SF.Add(module);
                    else if (module.ModuleName.Contains(".asi") && module.FileName == Program.gta_path + "\\" + module.ModuleName) { Program.Using_ASI = true; Program.Modules_ASI.Add(module); }
                    else { Program.Using_OTHER = true; Program.Modules_OTHER.Add(module); }
                }
            }
        }

        //Список игнорируемых модулей
        static string[] IgroreModuleNames =
        {
            "\\WINDOWS\\",
            "\\Windows\\",
            "gta_sa.exe",
            "vorbis.dll",
            "vorbisfile.dll",
            "vorbishooked.DLL",
            "vorbisHooked.DLL",
            "EAX.DLL",
            "samp.dll",
            "BASS.dll",
            "ogg.dll",
            ".cleo"
        };
    }
}
