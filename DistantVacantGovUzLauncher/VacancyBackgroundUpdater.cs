using System;
using System.Text;
using System.ComponentModel;
using System.Net;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;
using ICSharpCode.SharpZipLib.Core;

namespace DistantVacantGovUzLauncher
{
    public class UpdateState
    {
        public string Info;
        public int Status;

        public UpdateState(string info, int status)
        {
            SetUpdateState(info, status);
        }

        public void SetUpdateState(string info, int status)
        {
            Info = info;
            Status = status;
        }
    }

    public class VacancyBackgroundUpdater
    {
        private readonly string _version;
        private readonly UpdateState _state;
        private readonly string _urlUpdateSite; //"http://192.168.7.85:8089/vacancy/importer/";
        private const string UrlUpdateVersionFileName = "update.ver";
        private const string UrlUpdatePackFileName = "update.pack";

        public VacancyBackgroundUpdater(string currentVersion)
        {
            _version = currentVersion;
            _urlUpdateSite = Program.UpdateServer + "/vacantgovuz/application/";

            _state = new UpdateState("", 0);
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

        public void DoWork(BackgroundWorker worker, DoWorkEventArgs e)
        {
            var random = new Random();

            var appDir = Program.GetApplicationDirectory();

            TextWriter log;

            using (log = new StreamWriter(appDir + "\\update.log", false, Encoding.UTF8))
            {
                _state.SetUpdateState(language.strings.stateApplicationCurrentVersion + _version, 0);
                log.WriteLine(_state.Info);
                worker.ReportProgress(5, _state);

                //Thread.Sleep(500);

                _state.SetUpdateState(language.strings.stateGettingVersionInfoDownloadingFile, 0);
                log.WriteLine(_state.Info);
                worker.ReportProgress(10, _state);

                //Thread.Sleep(1000);

                using (var web = new WebClient())
                {
                    _state.SetUpdateState(language.strings.stateUpdateServer + _urlUpdateSite, 0);
                    log.WriteLine(_state.Info);
                    worker.ReportProgress(15, _state);

                    if (Program.ProxyEnabled)
                    {
                        web.Proxy =
                            new WebProxy(Program.ProxyHost +
                                         ((Program.ProxyPort != "") ? ":" + Program.ProxyPort : ""))
                            {
                                Credentials =
                                    new NetworkCredential(Program.ProxyUser, Program.ProxyPassword)
                            };

                        _state.SetUpdateState(language.strings.stateProxyServer + Program.ProxyHost + ((Program.ProxyPort != "") ? ":" + Program.ProxyPort : ""), 0);
                        log.WriteLine(_state.Info);
                        worker.ReportProgress(15, _state);
                    }

                    try
                    {
                        web.DownloadFile(_urlUpdateSite + UrlUpdateVersionFileName + "?random=" + random.Next(), appDir + "\\" + UrlUpdateVersionFileName);
                    }
                    catch (Exception ex)
                    {
                        _state.SetUpdateState(language.strings.stateGettingVersionInfoDownloadFailed, -1);
                        log.WriteLine(_state.Info);
                        log.WriteLine(ex.Message);
                        worker.ReportProgress(100, _state);
                        return;
                    }

                    _state.SetUpdateState(language.strings.stateGettingVersionInfoFileDownloaded, 0);
                    log.WriteLine(_state.Info);
                    worker.ReportProgress(20, _state);

                    string newVersion;

                    try
                    {
                        TextReader txt = new StreamReader(appDir + "\\" + UrlUpdateVersionFileName);
                        newVersion = txt.ReadLine();
                        txt.Close();
                    }
                    catch (Exception ex)
                    {
                        _state.SetUpdateState(language.strings.stateGettingVersionInfoCannotReadFile, -1);
                        log.WriteLine(_state.Info);
                        log.WriteLine(ex.Message);
                        worker.ReportProgress(100, _state);
                        return;
                    }

                    _state.SetUpdateState(language.strings.stateGettingVersionInfoCheckingVersion, 0);
                    log.WriteLine(_state.Info);
                    worker.ReportProgress(30, _state);

                    _state.SetUpdateState(language.strings.stateApplicationVersionOnServer + newVersion, 0);
                    log.WriteLine(_state.Info);
                    worker.ReportProgress(35, _state);

                    if (string.Compare(_version, newVersion, StringComparison.InvariantCultureIgnoreCase) == 0)
                    {
                        _state.SetUpdateState(language.strings.stateThereAreNoUpdates, 1);
                        log.WriteLine(_state.Info);
                        worker.ReportProgress(100, _state);

                        return;
                    }

                    _state.SetUpdateState(language.strings.stateThereIsNewApplicationVersionDownloading, 0);
                    log.WriteLine(_state.Info);
                    worker.ReportProgress(40, _state);

                    try
                    {
                        web.DownloadFile(_urlUpdateSite + "updates/" + newVersion + "/" + UrlUpdatePackFileName + "?random=" + random.Next(), appDir + "\\" + UrlUpdatePackFileName);
                    }
                    catch (Exception ex)
                    {
                        _state.SetUpdateState(language.strings.stateThereIsNewApplicationVersionDownloadFailed, -1);
                        log.WriteLine(_state.Info);
                        log.WriteLine(ex.Message);
                        worker.ReportProgress(100, _state);
                        return;
                    }
                }

                _state.SetUpdateState(language.strings.stateThereIsNewApplicationVersionApplyingUpdates, 0);
                log.WriteLine(_state.Info);
                worker.ReportProgress(75, _state);

                if (UnpackUpdateFile(appDir + "\\" + UrlUpdatePackFileName, appDir + "\\"))
                {
                    _state.SetUpdateState(language.strings.stateUpdatesSuccessfullyApplyed, 0);
                    log.WriteLine(_state.Info);
                    worker.ReportProgress(100, _state);
                }
                else
                {
                    _state.SetUpdateState(language.strings.stateThereIsNewApplicationVersionUnpackError, -1);
                    log.WriteLine(_state.Info);
                    worker.ReportProgress(100, _state);
                }
            }
        }
    }
}
