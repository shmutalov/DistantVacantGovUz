using System;
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
using DistantVacantGovUz.Services;
using DistantVacantGovUz.Windows;

namespace DistantVacantGovUz
{
    static class Program
    {
        public static VacantGovUzApi VacancyApi;

        public static string ProxyHost = "http://192.168.0.1";
        public static string ProxyPort = "3128";
        public static string ProxyUser = string.Empty;
        public static string ProxyPassword = string.Empty;

        public static string UpdateServer = @"";
        public static bool CheckForUpdates = true;

        public static string StrLanguage = "en";

        // включить использование прокси
        public static void EnableProxy()
        {
            var strProxyAddress = ProxyHost + ":" + ProxyPort;

            VacancyApi.SetHttpProxy(strProxyAddress, ProxyUser, ProxyPassword);
            VacancyApi.UseProxy = true;
        }

        // отключить использование прокси
        public static void DisableProxy()
        {
            VacancyApi.UseProxy = false;
        }

        /// <summary>
        /// Метод для сохранения настроек программы
        /// в файле settings.xml
        /// </summary>
        public static void SaveSettings()
        {
            var xml = new XmlDocument();
            
            var root = xml.CreateElement("settings");
            xml.AppendChild(root);
            xml.InsertBefore(xml.CreateXmlDeclaration("1.0", "UTF-8", "yes"), root);

            var el = xml.CreateElement("UseProxy");
            el.SetAttribute("value", (VacancyApi.UseProxy) ? "True" : "False");
            
            root.AppendChild(el);

            el = xml.CreateElement("ProxyHost");
            el.SetAttribute("value", ProxyHost);

            root.AppendChild(el);

            el = xml.CreateElement("ProxyPort");
            el.SetAttribute("value", ProxyPort);

            root.AppendChild(el);

            el = xml.CreateElement("ProxyUserName");
            el.SetAttribute("value", ProxyUser);

            root.AppendChild(el);

            el = xml.CreateElement("ProxyPassword");
            el.SetAttribute("value", ProxyPassword);

            root.AppendChild(el);

            el = xml.CreateElement("CheckForUpdates");
            el.SetAttribute("value", (CheckForUpdates) ? "True" : "False");

            root.AppendChild(el);

            el = xml.CreateElement("UpdateServer");
            el.SetAttribute("value", UpdateServer);

            root.AppendChild(el);

            el = xml.CreateElement("Language");
            el.SetAttribute("value", StrLanguage);

            root.AppendChild(el);

            try
            {
                xml.Save(GetApplicationDirectory() + "\\" + "settings.xml");
            }
            catch (Exception)
            {
                // ignore
            }
        }

        /// <summary>
        /// Метод для получение настроек программы
        /// из файла settings.xml
        /// </summary>
        public static void LoadSettings()
        {
            var xml = new XmlDocument();
            var bUseProxy = false;

            try
            {
                xml.Load(GetApplicationDirectory() + "\\" + "settings.xml");

                var root = xml.DocumentElement;

                if (root == null)
                    return;

                foreach (XmlElement n in root.ChildNodes)
                {
                    switch (n.Name)
                    {
                        case "UseProxy":
                            bUseProxy = (n.GetAttribute("value") == "True");
                            continue;
                        case "ProxyHost":
                            ProxyHost = n.GetAttribute("value");
                            continue;
                        case "ProxyPort":
                            ProxyPort = n.GetAttribute("value");
                            continue;
                        case "ProxyUserName":
                            ProxyUser = n.GetAttribute("value");
                            continue;
                        case "ProxyPassword":
                            ProxyPassword = n.GetAttribute("value");
                            continue;
                        case "CheckForUpdates":
                            CheckForUpdates = (n.GetAttribute("value") == "True");
                            continue;
                        case "UpdateServer":
                            UpdateServer = n.GetAttribute("value");
                            continue;
                        case "Language":
                            StrLanguage = n.GetAttribute("value");
                            continue;
                    }
                }

                if (bUseProxy)
                {
                    EnableProxy();
                }

                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(StrLanguage);
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
        /// Получить версию лаунчера
        /// </summary>
        /// <returns>Возвратит версию файла DistantLauncher.exe, или пустую строку, если файл отсутствует.</returns>
        public static string GetLauncherVersion()
        {
            try
            {
                var fi = FileVersionInfo.GetVersionInfo(GetApplicationDirectory() + "\\" + "DistantVacantGovUzLauncher.exe");

                return fi.ProductVersion;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        private static bool UnpackUpdateFile(string updateFileName, string outputFolder)
        {
            ZipFile zf = null;

            try
            {
                var fs = File.OpenRead(updateFileName);
                zf = new ZipFile(fs);

                foreach (ZipEntry ze in zf)
                {
                    if (!ze.IsFile)
                    {
                        continue;
                    }

                    var entryFileName = ze.Name;

                    var buffer = new byte[4096];     // 4K is optimum
                    var zipStream = zf.GetInputStream(ze);

                    var fullZipToPath = Path.Combine(outputFolder, entryFileName);
                    var directoryName = Path.GetDirectoryName(fullZipToPath);

                    if (!string.IsNullOrEmpty(directoryName))
                        Directory.CreateDirectory(directoryName);

                    using (var streamWriter = File.Create(fullZipToPath))
                    {
                        StreamUtils.Copy(zipStream, streamWriter, buffer);
                    }
                }
            }
            finally
            {
                zf?.Close();
            }

            return true;
        }

        /// <summary>
        /// Точка входа потока обновляющего лаунчер
        /// </summary>
        private static void LauncherUpdaterThreadEntryPoint()
        {
            var random = new Random();

            //string urlLauncherUpdateServer = "http://192.168.7.85:8089/vacancy/launcher/importer/";
            var urlLauncherUpdateServer = UpdateServer + "/vacantgovuz/launcher/";
            var launcherVersionFileName = "launcher_update.ver";

            var updateAvailable = false;

            var appDir = GetApplicationDirectory();

            TextWriter log;

            using (log = new StreamWriter(appDir + "\\" + "launcher_update.log", false, Encoding.UTF8))
            {
                log.WriteLine(language.strings.stateLauncherUpdateStart);

                var currentLauncherVersion = GetLauncherVersion();

                if (currentLauncherVersion != "")
                {
                    log.WriteLine(language.strings.stateLauncherCurrentVersion + currentLauncherVersion);
                }
                else
                {
                    log.WriteLine(language.strings.stateErrorLauncherNotFound);
                }

                if (string.IsNullOrEmpty(currentLauncherVersion))
                    return;

                using (var webClient = new WebClient())
                {
                    // Если используется прокси, нужно настроить прокски веб-клиента
                    if (VacancyApi.UseProxy)
                    {
                        log.WriteLine(language.strings.stateUsingProxyServer);

                        try
                        {
                            var proxy = new WebProxy(ProxyHost + ":" + ProxyPort);

                            // если используется авторизация
                            if (ProxyUser != null && ProxyUser.Trim() != "")
                                proxy.Credentials = new NetworkCredential(ProxyUser, ProxyPassword);

                            webClient.Proxy = proxy;
                        }
                        catch (Exception)
                        {
                            log.WriteLine(language.strings.stateCannotInitializeProxy + ProxyHost + ":" + ProxyPort);
                        }
                    }

                    try
                    {
                        log.WriteLine(language.strings.stateDownloadingUpdateVersionFile + urlLauncherUpdateServer + launcherVersionFileName);
                        webClient.DownloadFile(urlLauncherUpdateServer + launcherVersionFileName + "?random=" + random.Next(), appDir + "\\" + launcherVersionFileName);
                        log.WriteLine(language.strings.stateFileDownloaded);
                    }
                    catch (Exception ex)
                    {
                        log.WriteLine(language.strings.stateError + ex.Message);
                        return;
                    }

                    string latestLauncherVersion;

                    try
                    {
                        TextReader txt;
                        using (txt = new StreamReader(appDir + "\\" + launcherVersionFileName))
                        {
                            latestLauncherVersion = txt.ReadLine();
                            log.WriteLine(language.strings.stateLauncherVersionOnServer + latestLauncherVersion);
                        }
                    }
                    catch (Exception ex)
                    {
                        log.WriteLine(language.strings.stateError + ex.Message);
                        return;
                    }

                    if (latestLauncherVersion != null)
                    {
                        if (string.Compare(latestLauncherVersion, currentLauncherVersion, StringComparison.InvariantCultureIgnoreCase) != 0)
                        {
                            log.WriteLine(language.strings.stateNewVersionIsAvailable);
                            updateAvailable = true;
                        }
                    }

                    if (!updateAvailable)
                        return;

                    try
                    {
                        log.WriteLine(language.strings.stateDownloadingUpdateFile + urlLauncherUpdateServer + "update/" + latestLauncherVersion + "/" + "launcher_update.pack");
                        webClient.DownloadFile(urlLauncherUpdateServer + "update/" + latestLauncherVersion + "/" + "launcher_update.pack" + "?random=" + random.Next(), appDir + "\\" + "launcher_update.pack");
                        log.WriteLine(language.strings.stateFileDownloaded);
                    }
                    catch (Exception ex)
                    {
                        log.WriteLine(language.strings.stateDownloadError + ex.Message);
                        return;
                    }

                    log.WriteLine(UnpackUpdateFile(appDir + "\\" + "launcher_update.pack", appDir + "\\")
                        ? language.strings.stateLauncherSuccessfullyUpdated
                        : language.strings.stateUnpackError);
                }
            }
        }

        /// <summary>
        /// Создание и запуск потока для обновления лаунчера
        /// </summary>
        private static void UpdateLauncher()
        {
            var t = new Thread(LauncherUpdaterThreadEntryPoint);

            t.Start();
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string [] args)
        {
            var service = new VacancyApplicationService();
            
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

            VacancyApi = new VacantGovUzApi();
            
            LoadSettings();
            UpdateLauncher();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var mainWindow = args.Length > 0 
                ? new MainWindow(args[0]) 
                : new MainWindow();

            VacancySingleApplicationService.StartService(service, "net.pipe://localhost/VacancyService", mainWindow);
            
            Application.Run(mainWindow);
        }
    }
}
