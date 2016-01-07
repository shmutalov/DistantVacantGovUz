using System;
using System.Windows.Forms;
using System.Reflection;
using System.Threading;
using System.Xml;
using System.IO;

namespace DistantVacantGovUzLauncher
{
    static class Program
    {
        public static string[] Argv;

        public static bool ProxyEnabled;

        public static string ProxyHost = "http://192.168.0.1";
        public static string ProxyPort = "3128";
        public static string ProxyUser = string.Empty;
        public static string ProxyPassword = string.Empty;

        public static string UpdateServer = @"";

        private static string _strLanguage = "en";

        /// <summary>
        /// Метод для получение настроек программы
        /// из файла settings.xml
        /// </summary>
        private static void LoadSettings()
        {
            var document = new XmlDocument();
            var useProxy = false;

            try
            {
                document.Load(GetApplicationDirectory() + "\\" + "settings.xml");

                var root = document.DocumentElement;

                if (root == null)
                    return;

                foreach (XmlElement element in root.ChildNodes)
                {
                    switch (element.Name)
                    {
                        case "UseProxy":
                            useProxy = (element.GetAttribute("value") == "True");
                            continue;
                        case "ProxyHost":
                            ProxyHost = element.GetAttribute("value");
                            continue;
                        case "ProxyPort":
                            ProxyPort = element.GetAttribute("value");
                            continue;
                        case "ProxyUserName":
                            ProxyUser = element.GetAttribute("value");
                            continue;
                        case "ProxyPassword":
                            ProxyPassword = element.GetAttribute("value");
                            continue;
                        case "UpdateServer":
                            UpdateServer = element.GetAttribute("value");
                            continue;
                        case "Language":
                            _strLanguage = element.GetAttribute("value");
                            break;
                    }
                }
                    
                ProxyEnabled = useProxy;

                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(_strLanguage);
            }
            catch (Exception)
            {
                // ignore
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
        static void Main(string[] args)
        {
            Argv = args;

            LoadSettings();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow());
        }
    }
}
