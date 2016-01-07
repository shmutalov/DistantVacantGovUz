using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using DistantVacantGovUz.Enums;

namespace DistantVacantGovUz.Http
{
    public class NetHttpEngine : IHttpEngine
    {
        int _timeout;

        string _strLastError;

        IWebProxy _proxy;
        readonly CookieContainer _cookies;

        public NetHttpEngine()
        {
            IgnoreBadCertificates();

            _timeout = 20000;
            _proxy = null;
            _cookies = new CookieContainer();
        }

        /// <summary>
        /// Together with the AcceptAllCertifications method right
        /// below this causes to bypass errors caused by SLL-Errors.
        /// </summary>
        private static void IgnoreBadCertificates()
        {
            ServicePointManager.ServerCertificateValidationCallback = AcceptAllCertifications;
        }

        /// <summary>
        /// In Short: the Method solves the Problem of broken Certificates.
        /// Sometime when requesting Data and the sending Webserverconnection
        /// is based on a SSL Connection, an Error is caused by Servers whoes
        /// Certificate(s) have Errors. Like when the Cert is out of date
        /// and much more... So at this point when calling the method,
        /// this behaviour is prevented
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="certification"></param>
        /// <param name="chain"></param>
        /// <param name="sslPolicyErrors"></param>
        /// <returns>true</returns>
        private static bool AcceptAllCertifications(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certification, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }

        public void SetProxy(string proxyHost, string proxyUserName = "", string proxyPassword = "")
        {
            _proxy = new WebProxy(proxyHost)
            {
                Credentials = new NetworkCredential(proxyUserName, proxyPassword)
            };
        }

        public void UnsetProxy()
        {
            _proxy = null;
        }

        public byte[] GetBytes(string requestUrl, HttpRequestMethod requestMethod = HttpRequestMethod.Get, string requestData = "")
        {
            HttpWebRequest request;

            try
            {
                request = (HttpWebRequest)WebRequest.Create(requestUrl);
            }
            catch (Exception ex)
            {
                _strLastError = ex.Message;
                return null;
            }

            if (_proxy != null)
            {
                request.Proxy = _proxy;
            }

            request.AllowAutoRedirect = true;
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.3; WOW64; rv:34.0) Gecko/20100101 Firefox/34.0";
            request.Method = (requestMethod == HttpRequestMethod.Get) ? "GET" : "POST";
            request.Timeout = _timeout;
            request.KeepAlive = true;

            request.CookieContainer = _cookies;

            if (requestMethod == HttpRequestMethod.Post)
            {
                request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
                request.Referer = requestUrl;
                request.ContentType = "application/x-www-form-urlencoded";

                var requestDataBytes = Encoding.UTF8.GetBytes(requestData);

                request.ContentLength = requestDataBytes.Length;

                try
                {
                    var requestDataStream = request.GetRequestStream();

                    requestDataStream.Write(requestDataBytes, 0, requestDataBytes.Length);
                    requestDataStream.Flush();
                    requestDataStream.Close();
                }
                catch (Exception ex)
                {
                    _strLastError = ex.Message;
                    return null;
                }
            }

            try
            {
                var respBytes = new List<byte[]>();
                var dataLength = 0;

                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    using (var responseStream = response.GetResponseStream())
                    {
                        if (responseStream == null)
                            return new byte[0];

                        var buffer = new byte[8192]; // 8k 

                        int bytesRead;

                        do
                        {
                            // fill the buffer with data
                            bytesRead = responseStream.Read(buffer, 0, buffer.Length);

                            // make sure we read some data
                            if (bytesRead == 0)
                                continue;

                            dataLength += bytesRead;

                            var part = new byte[bytesRead];
                            Array.Copy(buffer, part, bytesRead);

                            respBytes.Add(part);
                        } while (bytesRead > 0);

                    }
                }

                var ret = new byte[dataLength];

                var curPos = 0;

                foreach (var b in respBytes)
                {
                    Array.Copy(b, 0, ret, curPos, b.Length);
                    curPos += b.Length;
                }

                return ret;
            }
            catch (Exception ex)
            {
                _strLastError = ex.Message;
                return null;
            }
        }

        public byte[] GetBytesEx(string requestUrl, HttpRequestMethod requestMethod = HttpRequestMethod.Get, string requestData = "")
        {
            HttpWebRequest request;

            try
            {
                // create a new request
                request = (HttpWebRequest)WebRequest.Create(requestUrl);
                // set timeout
                request.Timeout = _timeout;
                request.CookieContainer = _cookies;
            }
            catch (Exception ex)
            {
                _strLastError = ex.Message;
                return null;
            }

            // Set proxy if enabled
            if (_proxy != null)
            {
                request.Proxy = _proxy;
            }

            switch (requestMethod)
            {
                case HttpRequestMethod.Get:
                    request.Method = "GET";
                    break;
                case HttpRequestMethod.Post:
                    request.Method = "POST";
                    request.KeepAlive = true;
                    request.AllowAutoRedirect = true;
                    request.ServicePoint.Expect100Continue = false;
                    var postDataArray = Encoding.UTF8.GetBytes(requestData);
                    request.ContentType = "application/x-www-form-urlencoded";
                    request.ContentLength = postDataArray.Length;

                    // write post data into request stream
                    using (var requestDataStream = request.GetRequestStream())
                    {
                        requestDataStream.Write(postDataArray, 0, postDataArray.Length);
                    }

                    break;
            }

            try
            {
                var totalBytesRead = 0;
                var byteArrayList = new List<byte[]>();

                using (var response = request.GetResponse())
                {
                    using (var responseDataStream = response.GetResponseStream())
                    {
                        if (responseDataStream == null)
                            return null;

                        int bytesRead;

                        do
                        {
                            var buffer = new byte[8192];

                            bytesRead = responseDataStream.Read(buffer, 0, buffer.Length);
                            totalBytesRead += bytesRead;

                            if (bytesRead <= 0)
                                continue;

                            var dataBytesPart = new byte[bytesRead];
                            Array.Copy(buffer, dataBytesPart, bytesRead);

                            byteArrayList.Add(dataBytesPart);
                        } while (bytesRead > 0);
                    }
                }

                if (totalBytesRead <= 0)
                    return null;

                var dataBytes = new byte[totalBytesRead];
                var position = 0;

                foreach (var byteArray in byteArrayList)
                {
                    Array.Copy(byteArray, 0, dataBytes, position, byteArray.Length);
                    position += byteArray.Length;
                }

                return dataBytes;
            }
            catch (Exception ex)
            {
                _strLastError = ex.Message;
                return null;
            }
        }

        public string GetLastErrorMessage()
        {
            return _strLastError;
        }

        public void SetTimeout(int seconds)
        {
            _timeout = seconds * 1000;
        }
    }
}
