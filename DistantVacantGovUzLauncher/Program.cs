using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Security.Principal;
using System.Diagnostics;
using System.Reflection;
using System.ComponentModel;
using System.Threading;
using System.Xml;
using System.IO;

namespace DistantVacantGovUzLauncher
{
    static class Program
    {
        public static String[] argv;
        public static bool isAdmin = false;

        public static bool proxyEnabled = false;

        public static string strProxyHost = "http://192.168.0.1";
        public static string strProxyPort = "3128";
        public static string strProxyUser = "";
        public static string strProxyPassword = "";

        public static string strUpdateServer = @"";
        public static bool checkForUpdates = true;

        public static string strLanguage = "en";

        /// <summary>
        /// Метод для получение настроек программы
        /// из файла settings.xml
        /// </summary>
        public static void LoadSettings()
        {
            XmlDocument xml = new XmlDocument();
            bool bUseProxy = false;

            try
            {
                xml.Load(GetApplicationDirectory() + "\\" + "settings.xml");

                XmlElement root = xml.DocumentElement;

                foreach (XmlElement n in root.ChildNodes)
                {
                    if (n.Name == "UseProxy")
                    {
                        bUseProxy = (n.GetAttribute("value") == "True") ? true : false;
                        continue;
                    }

                    if (n.Name == "ProxyHost")
                    {
                        strProxyHost = n.GetAttribute("value");
                        continue;
                    }

                    if (n.Name == "ProxyPort")
                    {
                        strProxyPort = n.GetAttribute("value");
                        continue;
                    }

                    if (n.Name == "ProxyUserName")
                    {
                        strProxyUser = n.GetAttribute("value"); ;
                        continue;
                    }

                    if (n.Name == "ProxyPassword")
                    {
                        strProxyPassword = n.GetAttribute("value");
                        continue;
                    }

                    if (n.Name == "CheckForUpdates")
                    {
                        checkForUpdates = (n.GetAttribute("value") == "True") ? true : false;
                        continue;
                    }

                    if (n.Name == "UpdateServer")
                    {
                        strUpdateServer = n.GetAttribute("value");
                        continue;
                    }

                    if (n.Name == "Language")
                    {
                        strLanguage = n.GetAttribute("value");
                        continue;
                    }
                }
                    
                proxyEnabled = bUseProxy;

                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(strLanguage);
            }
            catch (Exception ex)
            {
            }
        }

        /// <summary>
        /// Получить путь к директории где распаложено приложение DistantVacantGovUz.exe
        /// </summary>
        /// <returns>Возвратит полный путь без завершающего слеша в конце имени</returns>
        public static string GetApplicationDirectory()
        {
            return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(String [] args)
        {
            argv = args;

            LoadSettings();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
        }
    }
}
