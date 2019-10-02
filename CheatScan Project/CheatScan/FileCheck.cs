using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;

namespace CheatScan
{
    class FileCheck
    {
        public enum PluginType
        {
            CLEO = 0,
            ASI = 1,
            SF = 2
        }
        enum SignatureType
        {
            CodeSection = 0, //проверка по сверке участка кода
            MD5Hash = 1 //проверка по MD5 сумме
        }

        SignatureType signatureType;
        string signature;
        string cheatName;
        public static List<FileCheck> CheatList_CLEO;
        public static List<FileCheck> CheatList_ASI;
        public static List<FileCheck> CheatList_SF;

        //конструктор
        FileCheck(PluginType pluginType, SignatureType signatureType, string signature, string cheatName)
        {
            this.signatureType = signatureType;
            this.signature = signature;
            this.cheatName = cheatName;

            if (pluginType == PluginType.CLEO) CheatList_CLEO.Add(this);
            else if (pluginType == PluginType.ASI) CheatList_ASI.Add(this);
            else if (pluginType == PluginType.SF) CheatList_SF.Add(this);
        }

        //пробиваем файл по базе читов
        public static string Check(List<FileCheck> list, string filename)
        {
            foreach (FileCheck element in list)
            {
                if (element.signatureType == SignatureType.CodeSection) //сравнение по участку кода
                {
                    string filetext = File.ReadAllText(filename);
                    if (filetext.Contains(element.signature))
                    {
                        return element.cheatName;
                    }
                }
                else if (element.signatureType == SignatureType.MD5Hash)
                {
                    if (CalculateMD5(filename) == element.signature)
                    {
                        return element.cheatName;
                    }
                }
            }
            return null;
            //Log.mainLog.WriteLine(filename.Replace(Program.gta_path, "") + " MD5: " + CalculateMD5(filename));            
        }

        //посчитать MD5 сумму файла
        static string CalculateMD5(string filename)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(filename))
                {
                    var hash = md5.ComputeHash(stream);
                    return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                }
            }
        }



        //--- База CLEO читов
        static public void LoadCheatList_CLEO()
        {
            CheatList_CLEO = new List<FileCheck>();
            //Лист читов | тип файла, тип сигнатуры (участок кода или MD5), сигнатура, название чита

            //Aim
            new FileCheck(PluginType.CLEO, SignatureType.CodeSection, "AIMBOT by p", "AIMBOT by p1cador");
            new FileCheck(PluginType.CLEO, SignatureType.CodeSection, "~y~Silent AIM ~w~by ~p~0pc0d3R", "Silent AIM by 0pc0d3R");
            new FileCheck(PluginType.CLEO, SignatureType.CodeSection, "~r~[~w~~h~Aimbot~r~] ~w~~h~:: Activated", "HeadShot AIM");
            new FileCheck(PluginType.CLEO, SignatureType.CodeSection, "}Smurf aim{", "Smurf AIM by Izd4T");
            new FileCheck(PluginType.CLEO, SignatureType.CodeSection, "Aimbot ~g~enabled", "Skin Aimbot");
            new FileCheck(PluginType.CLEO, SignatureType.CodeSection, "THROUGH WALL ~G~ACTIVATED", "Through WallShot");
            new FileCheck(PluginType.CLEO, SignatureType.CodeSection, "ProAim by sandyyb", "ProAim by sandyyb");
            new FileCheck(PluginType.CLEO, SignatureType.CodeSection, "thread \"nospread\"", "NoSpread (стрельба без разброса)");
            new FileCheck(PluginType.CLEO, SignatureType.CodeSection, "[HideAim] {", "Hide AIM");
            new FileCheck(PluginType.CLEO, SignatureType.CodeSection, "Silent Aim ~g", "Silent AIM by 0pc0d3R");
            new FileCheck(PluginType.CLEO, SignatureType.CodeSection, "CLEO AIMBOT ~G~ LOADED", "AimBot by 0X688 and Opcode.EXE");
            new FileCheck(PluginType.CLEO, SignatureType.CodeSection, "0ACC:  \"~y~Sphere~w~: Created\"  2000", "Smart Aimbot");
            new FileCheck(PluginType.CLEO, SignatureType.CodeSection, ".::~B~SniperZoom.ini not found~W~::.", "x32 Sniper Zoom");
            new FileCheck(PluginType.CLEO, SignatureType.CodeSection, "PRO-AIM ENABLED", "PRO AIM");
            new FileCheck(PluginType.CLEO, SignatureType.CodeSection, "(PoorAim)~w~ got ~y~ENABLED", "PoorAim");
            new FileCheck(PluginType.CLEO, SignatureType.CodeSection, "{*Silent AIM*}", "Silent AIM by 0pc0d3R");
            new FileCheck(PluginType.CLEO, SignatureType.CodeSection, "~B~AIMBOT BY WALE, POKE, EDGE LOADED", "AimBot by WALE");
            new FileCheck(PluginType.CLEO, SignatureType.CodeSection, "AIM BY SAMPHACK", "AIM by SAMPHACK");
            new FileCheck(PluginType.CLEO, SignatureType.CodeSection, "AIM by SampHack", "AIM by SAMPHACK");
            new FileCheck(PluginType.CLEO, SignatureType.CodeSection, "noSPREAD on.", "NoSpread by Opcode.EXE");
            new FileCheck(PluginType.CLEO, SignatureType.CodeSection, "Aimbot ~g~Enabled", "AimBot by Opcode.EXE");
            new FileCheck(PluginType.CLEO, SignatureType.CodeSection, "/aim{ffffff}", "AIM with GOD");

            //WallHack
            new FileCheck(PluginType.CLEO, SignatureType.CodeSection, "[WallHack]: {EAEAEA}", "WallHack");
            new FileCheck(PluginType.CLEO, SignatureType.CodeSection, "nametaghack on!", "WallHack");
            new FileCheck(PluginType.CLEO, SignatureType.CodeSection, "WallHack PLUS - 0.3.7", "WallHack");
            new FileCheck(PluginType.CLEO, SignatureType.CodeSection, "Don't use wallhack solid/wireframe", "WallHack");
            new FileCheck(PluginType.CLEO, SignatureType.CodeSection, "0A8C: write_memory 1@ size 6 value -1869574000 virtual_protect 1", "WallHack");
            new FileCheck(PluginType.CLEO, SignatureType.CodeSection, "RENDER WH OPEN SOURCE.CS", "Render WallHack by p1cador");
            new FileCheck(PluginType.CLEO, SignatureType.CodeSection, "Wallcock by Izd4T", "WallHack (Wallcock) by Izd4T");
            new FileCheck(PluginType.CLEO, SignatureType.CodeSection, "Wallhack {c60000}special{c60000}", "WallHack by anonim37");
            new FileCheck(PluginType.CLEO, SignatureType.CodeSection, "0ADC:   test_cheat \"CKWH\"", "Bone WallHack by CheatKey");
            new FileCheck(PluginType.CLEO, SignatureType.CodeSection, "{00BAED}Custom WH", "WallHack by D3.Pheonix");

            //GM и коллизии
            new FileCheck(PluginType.CLEO, SignatureType.CodeSection, "show_text_highpriority \"GM car\" time 50", "Зажимной GM Car");
            new FileCheck(PluginType.CLEO, SignatureType.CodeSection, "No collision hack by FYP", "NoCollisions hack by FYP");
            new FileCheck(PluginType.CLEO, SignatureType.CodeSection, "0ACD: show_text_highpriority \"NO COLLISION ON\" time 2000", "NoCarCollisions");
            new FileCheck(PluginType.CLEO, SignatureType.CodeSection, "CLEO : Full GM", "Full GM");

            //FlyHack, SpeedHack, TP, AirBreak
            new FileCheck(PluginType.CLEO, SignatureType.CodeSection, "SAFE FLY $ELLINES", "FlyHack by Ellines");
            new FileCheck(PluginType.CLEO, SignatureType.CodeSection, "HANCOCKP2", "HANCOCK MODE (FlyHack)");
            new FileCheck(PluginType.CLEO, SignatureType.CodeSection, "MISTER_FYP.ini", "MISTER FYP AirBreak");
            new FileCheck(PluginType.CLEO, SignatureType.CodeSection, "*COORDMASTER DRP BY ALEX WIDE", "CoordMaster (TP)");
            new FileCheck(PluginType.CLEO, SignatureType.CodeSection, "thread \"PrimeHackSH\"", "PrimeHack SpeedHack");

            //Прочее
            new FileCheck(PluginType.CLEO, SignatureType.CodeSection, "MultiHack\\DialogSettings", "SAMP 0.3.7 MultiHack");
            new FileCheck(PluginType.CLEO, SignatureType.CodeSection, "FAST PED TURN", "Fast Ped Turn");
            new FileCheck(PluginType.CLEO, SignatureType.CodeSection, "TSlapperb", "TSlapper by Gabriel");
            new FileCheck(PluginType.CLEO, SignatureType.CodeSection, "[CLEO] Slap by SampHack", "Slapper by SAMPHACK");
            new FileCheck(PluginType.CLEO, SignatureType.CodeSection, "~W~ANTI-STUNSHOT ~G~ENABLED", "AntiStun");
            new FileCheck(PluginType.CLEO, SignatureType.CodeSection, "07DA: set_car 1@ rotation_velocity_XYZ 0.0 1.5 0.0 through_center_of_body", "Переворот авто");





            //MD5
            new FileCheck(PluginType.CLEO, SignatureType.MD5Hash, "a7c85f5d3770d40c53d517b5e01e4141", "WallHack");
            new FileCheck(PluginType.CLEO, SignatureType.MD5Hash, "1b98de3ab116bd2e254bc40415ffec31", "Метла");
            new FileCheck(PluginType.CLEO, SignatureType.MD5Hash, "d5212f32421fea5a96641047d4772d99", "Метла");
            new FileCheck(PluginType.CLEO, SignatureType.MD5Hash, "8892cf1c969c1249ec250d6af4a47fc1", "Perfect Silent Aim");
            new FileCheck(PluginType.CLEO, SignatureType.MD5Hash, "bde6c18723410b78e1e922a6a979f644", "Silent AIM by 0pc0d3R");
            new FileCheck(PluginType.CLEO, SignatureType.MD5Hash, "79c337622f08a36cafc584b6207a5029", "Silent AIM by 0pc0d3R");
            new FileCheck(PluginType.CLEO, SignatureType.MD5Hash, "3ada233ffc63615f87fac21099b06aed", "NoSpread (Стрельба без разброса)");
            new FileCheck(PluginType.CLEO, SignatureType.MD5Hash, "ef03d1afeea46ea468c74a5a7f62b849", "AimBot FAMOZiN");
            new FileCheck(PluginType.CLEO, SignatureType.MD5Hash, "201c41f192b7e64e64843002a7b06273", "SpeedHack");
            
            new FileCheck(PluginType.CLEO, SignatureType.MD5Hash, "aca283ebfb661f09eede1bcdba159d1c", "Бесконечный Бег");
            new FileCheck(PluginType.CLEO, SignatureType.MD5Hash, "2b04acabc19c997d2d6650df7412a96e", "AimBot by OPCODEXE");
            new FileCheck(PluginType.CLEO, SignatureType.MD5Hash, "2d1d8b899831b60246e0097d20673937", "AutoShot");
            new FileCheck(PluginType.CLEO, SignatureType.MD5Hash, "4118ea1132b165ad615a7f247ec15004", "Fast Animations");
            new FileCheck(PluginType.CLEO, SignatureType.MD5Hash, "e64876473096343537497c1e816d6a71", "Fast Animations");
            new FileCheck(PluginType.CLEO, SignatureType.MD5Hash, "1403fd9997d5a81348eb7e4a59f645ac", "WallHack");
            new FileCheck(PluginType.CLEO, SignatureType.MD5Hash, "339e28bc9f5d1feb39af346ca38e4ce1", "Extra Weapon Zoom");
            new FileCheck(PluginType.CLEO, SignatureType.MD5Hash, "fe7cbcf12945ecbf92004593ea07e55d", "ProAim by Opcode");
            new FileCheck(PluginType.CLEO, SignatureType.MD5Hash, "7d1cdea595884f93fa38fd372b99dca2", "AutoShot");
            new FileCheck(PluginType.CLEO, SignatureType.MD5Hash, "9b902117db9b4d94bab2c2009022fbfb", "B6 (Ped SpeedHack)");
            new FileCheck(PluginType.CLEO, SignatureType.MD5Hash, "0130b3b786e600de66a2d251cb7cf544", "Ходьба по воде");
            new FileCheck(PluginType.CLEO, SignatureType.MD5Hash, "6945440a20756fc3695bdd3746b1db01", "Anti Fall Of Bike");
        }



        //--- База ASI читов
        static public void LoadCheatList_ASI()
        {
            CheatList_ASI = new List<FileCheck>();
            //Лист читов | тип файла, тип сигнатуры (участок кода или MD5), сигнатура, название чита

            new FileCheck(PluginType.ASI, SignatureType.CodeSection, "Ultra WallHack by SlonoBoyko", "Ultra WallHack by SlonoBoyko");
            new FileCheck(PluginType.ASI, SignatureType.CodeSection, "damager.asi", "Damager");
            new FileCheck(PluginType.ASI, SignatureType.CodeSection, "NoCarCollision.ini", "NoCarCollisions");
            new FileCheck(PluginType.ASI, SignatureType.CodeSection, "OP-HaX.ini", "OP-HaX MultiHack by Opcode.eXe");


            //MD5
            new FileCheck(PluginType.ASI, SignatureType.MD5Hash, "ea34b0c3696570bca742cbc39c444ee0", "AimBot FAMOZiN");
        }



        //--- База SAMPFUNCS читов
        static public void LoadCheatList_SF()
        {
            CheatList_SF = new List<FileCheck>();
            //Лист читов | тип файла, тип сигнатуры (участок кода или MD5), сигнатура, название чита

            new FileCheck(PluginType.SF, SignatureType.CodeSection, "Multihack v2", "Multihack v2");
            new FileCheck(PluginType.SF, SignatureType.CodeSection, "NoSpread/NoRecoil by BLOOM", "NoSpread/NoRecoil by BLOOM");
            new FileCheck(PluginType.SF, SignatureType.CodeSection, "[ExtremeCheats] Smooth aimbot", "Smooth AIMBOT");
            new FileCheck(PluginType.SF, SignatureType.CodeSection, "SilentAIM {FFCC00}by 0pc0d3R", "Silent AIM by 0pc0d3R");


            //MD5
            new FileCheck(PluginType.SF, SignatureType.MD5Hash, "98c5425240b5ff324b81ddddf9be2e1b", "Silent Aim");      
        }


    }
}
