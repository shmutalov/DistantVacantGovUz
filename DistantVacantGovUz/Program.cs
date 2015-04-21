using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Xml;
using System.Threading;
using System.Net;
using ICSharpCode.SharpZipLib.Zip;
using ICSharpCode.SharpZipLib.Core;
using System.Text;
using System.ServiceModel;

namespace DistantVacantGovUz
{
    static class Program
    {
        public static CVacantGovUz vac;

        public static string strUserName = @"";
        public static string strPassword = @"";

        public static string strProxyHost = "http://192.168.0.1";
        public static string strProxyPort = "3128";
        public static string strProxyUser = "";
        public static string strProxyPassword = "";

        public static string strUpdateServer = @"";
        public static bool bCheckForUpdates = true;

        public static string strLanguage = "en";

        // включить использование прокси
        public static void EnableProxy()
        {
            string strProxyAddress = strProxyHost + ":" + strProxyPort;

            vac.SetHttpProxy(strProxyAddress, strProxyUser, strProxyPassword);
            vac.UseHttpProxy = true;
        }

        // отключить использование прокси
        public static void DisableProxy()
        {
            vac.UseHttpProxy = false;
        }

        /// <summary>
        /// Метод для сохранения настроек программы
        /// в файле settings.xml
        /// </summary>
        public static void SaveSettings()
        {
            XmlDocument xml = new XmlDocument();
            
            XmlElement root = xml.CreateElement("settings");
            xml.AppendChild(root);
            xml.InsertBefore(xml.CreateXmlDeclaration("1.0", "UTF-8", "yes"), root);

            XmlElement el;

            el = xml.CreateElement("UseProxy");
            el.SetAttribute("value", (vac.UseHttpProxy) ? "True" : "False");
            
            root.AppendChild(el);

            el = xml.CreateElement("ProxyHost");
            el.SetAttribute("value", strProxyHost);

            root.AppendChild(el);

            el = xml.CreateElement("ProxyPort");
            el.SetAttribute("value", strProxyPort);

            root.AppendChild(el);

            el = xml.CreateElement("ProxyUserName");
            el.SetAttribute("value", strProxyUser);

            root.AppendChild(el);

            el = xml.CreateElement("ProxyPassword");
            el.SetAttribute("value", strProxyPassword);

            root.AppendChild(el);

            el = xml.CreateElement("CheckForUpdates");
            el.SetAttribute("value", (bCheckForUpdates) ? "True" : "False");

            root.AppendChild(el);

            el = xml.CreateElement("UpdateServer");
            el.SetAttribute("value", strUpdateServer);

            root.AppendChild(el);

            el = xml.CreateElement("Language");
            el.SetAttribute("value", strLanguage);

            root.AppendChild(el);

            try
            {
                xml.Save(GetApplicationDirectory() + "\\" + "settings.xml");
            }
            catch (Exception ex)
            {
            }
        }

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
                        strProxyUser = n.GetAttribute("value");;
                        continue;
                    }

                    if (n.Name == "ProxyPassword")
                    {
                        strProxyPassword = n.GetAttribute("value");
                        continue;
                    }

                    if (n.Name == "CheckForUpdates")
                    {
                        bCheckForUpdates = (n.GetAttribute("value") == "True") ? true : false;
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

                if (bUseProxy)
                {
                    EnableProxy();
                }

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

        private static bool UnpackUpdateFile(String updateFileName, String outputFolder)
        {
            ZipFile zf = null;
            bool ret = false;

            try
            {
                FileStream fs = File.OpenRead(updateFileName);
                zf = new ZipFile(fs);

                foreach (ZipEntry ze in zf)
                {
                    if (!ze.IsFile)
                    {
                        continue;
                    }

                    String entryFileName = ze.Name;

                    byte[] buffer = new byte[4096];     // 4K is optimum
                    Stream zipStream = zf.GetInputStream(ze);

                    String fullZipToPath = Path.Combine(outputFolder, entryFileName);
                    string directoryName = Path.GetDirectoryName(fullZipToPath);

                    if (directoryName.Length > 0)
                        Directory.CreateDirectory(directoryName);

                    using (FileStream streamWriter = File.Create(fullZipToPath))
                    {
                        StreamUtils.Copy(zipStream, streamWriter, buffer);
                    }
                }

                ret = true;
            }
            finally
            {
                if (zf != null)
                {
                    zf.Close();
                }
            }

            return ret;
        }

        /// <summary>
        /// Точка входа потока обновляющего лаунчер
        /// </summary>
        private static void LauncherUpdaterThreadEntryPoint()
        {
            //string urlLauncherUpdateServer = "http://192.168.7.85:8089/vacancy/launcher/importer/";
            string urlLauncherUpdateServer = strUpdateServer + "/vacantgovuz/launcher/";
            string launcherVersionFileName = "launcher_update.ver";
            string currentLauncherVersion = null;
            string newestLauncherVersion = null;

            bool updateAvailable = false;

            string appDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            TextWriter log;

            using (log = new StreamWriter(appDir + "\\" + "launcher_update.log", false, Encoding.UTF8))
            {
                log.WriteLine("Vacancy Importer Launcher update start...");

                try
                {
                    FileVersionInfo fi = FileVersionInfo.GetVersionInfo(appDir + "\\" + "Vacant_AGMK.exe");
                    currentLauncherVersion = fi.ProductVersion;

                    log.WriteLine("Launcher current version: " + currentLauncherVersion);
                }
                catch (FileNotFoundException ex)
                {
                    log.WriteLine("ERROR: " + ex.Message);
                    // Must not reach here (o_O)
                }

                if (currentLauncherVersion != null)
                {
                    using (WebClient webClient = new WebClient())
                    {
                        // Если используется прокси, нужно настроить прокски веб-клиента
                        if (vac.UseHttpProxy)
                        {
                            log.WriteLine("Используется прокси сервер");

                            try
                            {
                                WebProxy proxy = new WebProxy(strProxyHost + ":" + strProxyPort);

                                // если используется авторизация
                                if (strProxyUser != null && strProxyUser.Trim() != "")
                                    proxy.Credentials = new NetworkCredential(strProxyUser, strProxyPassword);

                                webClient.Proxy = proxy;
                            }
                            catch (Exception ex)
                            {
                                log.WriteLine("Не удалось инициализировать прокси: " + strProxyHost + ":" + strProxyPort);
                            }
                        }

                        try
                        {
                            log.WriteLine("Downloading update version file: " + urlLauncherUpdateServer + launcherVersionFileName);
                            webClient.DownloadFile(urlLauncherUpdateServer + launcherVersionFileName, appDir + "\\" + launcherVersionFileName);
                            log.WriteLine("File downloaded");
                        }
                        catch (Exception ex)
                        {
                            log.WriteLine("ERROR: " + ex.Message);
                            return;
                        }

                        TextReader txt;

                        try
                        {
                            using (txt = new StreamReader(appDir + "\\" + launcherVersionFileName))
                            {
                                newestLauncherVersion = txt.ReadLine();
                                log.WriteLine("Launcher version on server: " + newestLauncherVersion);
                            }
                        }
                        catch (Exception ex)
                        {
                            log.WriteLine("ERROR: " + ex.Message);
                            return;
                        }

                        if (newestLauncherVersion != null)
                        {
                            if (newestLauncherVersion.CompareTo(currentLauncherVersion) != 0)
                            {
                                log.WriteLine("New version is available");
                                updateAvailable = true;
                            }
                        }

                        if (updateAvailable)
                        {
                            try
                            {
                                log.WriteLine("Downloading update file: " + urlLauncherUpdateServer + "update/" + newestLauncherVersion + "/" + "launcher_update.pack");
                                webClient.DownloadFile(urlLauncherUpdateServer + "update/" + newestLauncherVersion + "/" + "launcher_update.pack", appDir + "\\" + "launcher_update.pack");
                                log.WriteLine("File downloaded");
                            }
                            catch (Exception ex)
                            {
                                log.WriteLine("Download error: " + ex.Message);
                                return;
                            }

                            if (UnpackUpdateFile(appDir + "\\" + "launcher_update.pack", appDir + "\\"))
                            {
                                log.WriteLine("Launcher successfully updated!");
                            }
                            else
                            {
                                log.WriteLine("Unpack error");
                                return;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Создание и запуск потока для обновления лаунчера
        /// </summary>
        private static void UpdateLauncher()
        {
            Thread t = new Thread(new ThreadStart(LauncherUpdaterThreadEntryPoint));

            t.Start();
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string [] args)
        {
            VacancyApplicationService service = new VacancyApplicationService();
            
            if (args.Length > 0)
            {
                if (VacancySingleApplicationService.IsServiceAlreadyStartedOpenDocument("net.pipe://localhost/VacancyService", args[0]))
                    return;
            }
            else
            {
                if (VacancySingleApplicationService.IsServiceAlreadyStarted("net.pipe://localhost/VacancyService"))
                    return;
            }

            vac = new CVacantGovUz();
            
            LoadSettings();
            //UpdateLauncher();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            frmMain fMain;

            if (args.Length > 0)
                fMain = new frmMain(args[0]);
            else
                fMain = new frmMain();

            VacancySingleApplicationService.StartService(service, "net.pipe://localhost/VacancyService", fMain);
            
            Application.Run(fMain);
        }
    }
}
