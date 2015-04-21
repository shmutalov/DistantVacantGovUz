using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Threading;
using System.Net;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;
using ICSharpCode.SharpZipLib.Core;
using System.Reflection;

namespace DistantVacantGovUzLauncher
{
    public class UpdateState
    {
        public String info;
        public int status;

        public UpdateState(String info, int status)
        {
            SetUpdateState(info, status);
        }

        public void SetUpdateState(String info, int status)
        {
            this.info = info;
            this.status = status;
        }
    }

    class VacancyBackgroundUpdater
    {
        String version;
        UpdateState state;
        String urlUpdateSite = ""; //"http://192.168.7.85:8089/vacancy/importer/";
        String urlUpdateVersionFileName = "update.ver";
        String urlUpdatePackFileName = "update.pack";

        public VacancyBackgroundUpdater(string currentVersion)
        {
            this.version = currentVersion;
            urlUpdateSite = Program.strUpdateServer + "/vacantgovuz/application/";

            state = new UpdateState("", 0);
        }

        private bool UnpackUpdateFile(String updateFileName, String outputFolder)
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

        public void DoWork(BackgroundWorker worker, DoWorkEventArgs e)
        {
            Random random = new Random();

            string appDir = Program.GetApplicationDirectory();

            TextWriter log;

            using (log = new StreamWriter(appDir + "\\update.log", false, Encoding.UTF8))
            {
                state.SetUpdateState(language.strings.stateApplicationCurrentVersion + version, 0);
                log.WriteLine(state.info);
                worker.ReportProgress(5, state);

                //Thread.Sleep(500);

                state.SetUpdateState(language.strings.stateGettingVersionInfoDownloadingFile, 0);
                log.WriteLine(state.info);
                worker.ReportProgress(10, state);

                //Thread.Sleep(1000);

                using (WebClient web = new WebClient())
                {
                    state.SetUpdateState(language.strings.stateUpdateServer + urlUpdateSite, 0);
                    log.WriteLine(state.info);
                    worker.ReportProgress(15, state);

                    if (Program.proxyEnabled)
                    {
                        web.Proxy = new WebProxy(Program.strProxyHost + ((Program.strProxyPort != "") ? ":" + Program.strProxyPort : ""));
                        web.Proxy.Credentials = new NetworkCredential(Program.strProxyUser, Program.strProxyPassword);

                        state.SetUpdateState(language.strings.stateProxyServer + Program.strProxyHost + ((Program.strProxyPort != "") ? ":" + Program.strProxyPort : ""), 0);
                        log.WriteLine(state.info);
                        worker.ReportProgress(15, state);
                    }

                    try
                    {
                        web.DownloadFile(urlUpdateSite + urlUpdateVersionFileName + "?random=" + random.Next().ToString(), appDir + "\\" + urlUpdateVersionFileName);
                    }
                    catch (Exception ex)
                    {
                        state.SetUpdateState(language.strings.stateGettingVersionInfoDownloadFailed, -1);
                        log.WriteLine(state.info);
                        log.WriteLine(ex.Message);
                        worker.ReportProgress(100, state);
                        return;
                    }

                    state.SetUpdateState(language.strings.stateGettingVersionInfoFileDownloaded, 0);
                    log.WriteLine(state.info);
                    worker.ReportProgress(20, state);

                    //Thread.Sleep(500);

                    TextReader txt;
                    String newVer = version;

                    try
                    {
                        txt = new StreamReader(appDir + "\\" + urlUpdateVersionFileName);
                        newVer = txt.ReadLine();
                        txt.Close();
                    }
                    catch (Exception ex)
                    {
                        state.SetUpdateState(language.strings.stateGettingVersionInfoCannotReadFile, -1);
                        log.WriteLine(state.info);
                        log.WriteLine(ex.Message);
                        worker.ReportProgress(100, state);
                        return;
                    }

                    state.SetUpdateState(language.strings.stateGettingVersionInfoCheckingVersion, 0);
                    log.WriteLine(state.info);
                    worker.ReportProgress(30, state);

                    //Thread.Sleep(500);

                    state.SetUpdateState(language.strings.stateApplicationVersionOnServer + newVer, 0);
                    log.WriteLine(state.info);
                    worker.ReportProgress(35, state);

                    //Thread.Sleep(500);

                    if (version.CompareTo(newVer) == 0)
                    {
                        state.SetUpdateState(language.strings.stateThereAreNoUpdates, 1);
                        log.WriteLine(state.info);
                        worker.ReportProgress(100, state);

                        //Thread.Sleep(500);

                        return;
                    }

                    state.SetUpdateState(language.strings.stateThereIsNewApplicationVersionDownloading, 0);
                    log.WriteLine(state.info);
                    worker.ReportProgress(40, state);

                    //Thread.Sleep(1000);

                    try
                    {
                        web.DownloadFile(urlUpdateSite + "updates/" + newVer + "/" + urlUpdatePackFileName + "?random=" + random.Next().ToString(), appDir + "\\" + urlUpdatePackFileName);
                    }
                    catch (Exception ex)
                    {
                        state.SetUpdateState(language.strings.stateThereIsNewApplicationVersionDownloadFailed, -1);
                        log.WriteLine(state.info);
                        log.WriteLine(ex.Message);
                        worker.ReportProgress(100, state);
                        return;
                    }
                }

                state.SetUpdateState(language.strings.stateThereIsNewApplicationVersionApplyingUpdates, 0);
                log.WriteLine(state.info);
                worker.ReportProgress(75, state);

                //Thread.Sleep(1000);

                if (UnpackUpdateFile(appDir + "\\" + urlUpdatePackFileName, appDir + "\\"))
                {
                    state.SetUpdateState(language.strings.stateUpdatesSuccessfullyApplyed, 0);
                    log.WriteLine(state.info);
                    worker.ReportProgress(100, state);
                }
                else
                {
                    state.SetUpdateState(language.strings.stateThereIsNewApplicationVersionUnpackError, -1);
                    log.WriteLine(state.info);
                    worker.ReportProgress(100, state);
                }

                //Thread.Sleep(1000);
            }
        }
    }
}
