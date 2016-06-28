using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Win32;

namespace GuessMelody
{
    static class Victorina // класс для передачи данных между формами
    {
        static public List<string> list = new List<string>(); // список песен
        static public int gameDuration = 60; // продожительность игры
        static public int musicDuration = 10;// продолжительность музыки
        static public bool randomStart = false;// откуда стартовать сначала или со случайного места 
        static public string lastFolder = "";// папка которую задаем когда выбираем папку
        static public bool allDirectories = false;// выбираем все папки или только верхние папки
        
        static public void ReadMusic() //считывает музыкальные файлы 
        {
            try
            {
                string[] music_files = Directory.GetFiles(lastFolder, "*.mp3", allDirectories ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);
                list.Clear();
                list.AddRange(music_files);
            }
            catch
            { }
        }
        static string regKeyName = "Software\\MyCompanyName\\Victorina";
        public static void WriteParam()
        {
            RegistryKey rk = null;
            try
            {
                rk = Registry.CurrentUser.CreateSubKey(regKeyName);
                if (rk == null) return;
                rk.SetValue("LastFolder", lastFolder);
                rk.SetValue("RandomStart",randomStart);
                rk.SetValue("GameDuration",gameDuration);
                rk.SetValue("MusicDuration",musicDuration);
                rk.SetValue("AllDirectories",allDirectories);
            }
            finally
            {
                if (rk != null) rk.Close();
            }
        }
        public static void ReadParam()
        {
            RegistryKey rk = null;
            try
            {
                rk = Registry.CurrentUser.OpenSubKey(regKeyName);
                if (rk == null) return;
                lastFolder = (string)rk.GetValue("LastFolder");
                gameDuration = (int)rk.GetValue("GameDuration");
                musicDuration = (int)rk.GetValue("MusicDuration");
                randomStart = Convert.ToBoolean(rk.GetValue("RandomStart"));
                allDirectories = Convert.ToBoolean(rk.GetValue("AllDirectories"));


            }
            finally
            {
                if (rk != null) rk.Close();
            }
        }
    }
}
