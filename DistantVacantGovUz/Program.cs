using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace DistantVacantGovUz
{
    static class Program
    {
        /// <summary>
        /// Получить путь к директории где распаложено приложение DistantVacantGovUz.exe
        /// </summary>
        /// <returns>Возвратит полный путь без завершающего слеша в конце имени</returns>
        public static string GetApplicationDirectory()
        {
            return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        }

        /// <summary>
        /// Получить версию лаунчера
        /// </summary>
        /// <returns>Возвратит версию файла DistantLauncher.exe, или пустую строку, если файл отсутствует.</returns>
        public static string GetLauncherVersion()
        {
            try
            {
                FileVersionInfo fi = FileVersionInfo.GetVersionInfo(GetApplicationDirectory() + "\\" + "Distantlauncher.exe");

                return fi.ProductVersion;
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
        }
    }
}
