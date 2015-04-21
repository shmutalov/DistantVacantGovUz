using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Net;
using System.IO;
using System.Windows.Forms;

namespace DistantVacantGovUz
{
    public class NetHttpRequests : IHttpRequests
    {
        int timeout = 20000;

        string strLastError;

        IWebProxy proxy;
        CookieContainer cookies;

        public NetHttpRequests()
        {
            IgnoreBadCertificates();

            timeout = 20000;
            proxy = null;
            cookies = new CookieContainer();
        }

        /// <summary>
        /// Together with the AcceptAllCertifications method right
        /// below this causes to bypass errors caused by SLL-Errors.
        /// </summary>
        public static void IgnoreBadCertificates()
        {
            System.Net.ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications);
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
            proxy = new WebProxy(proxyHost);
            proxy.Credentials = new NetworkCredential(proxyUserName, proxyPassword);
        }

        public void UnsetProxy()
        {
            proxy = null;
        }

        public byte[] GetBytes(string requestUrl, RequestMethod requestMethod = RequestMethod.GET, string requestData = "")
        {
            HttpWebRequest request = null;

            try
            {
                request = (HttpWebRequest)WebRequest.Create(requestUrl);
            }
            catch (Exception ex)
            {
                strLastError = ex.Message;
                return null;
            }

            if (proxy != null)
            {
                request.Proxy = proxy;
            }

            request.AllowAutoRedirect = true;
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.3; WOW64; rv:34.0) Gecko/20100101 Firefox/34.0";
            request.Method = (requestMethod == RequestMethod.GET) ? "GET" : "POST";
            request.Timeout = timeout;
            //request.ReadWriteTimeout = timeout;
            request.KeepAlive = true;

            request.CookieContainer = cookies;

            if (requestMethod == RequestMethod.POST)
            {
                request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
                //request.Connection = "keep-alive";
                request.Referer = requestUrl;
                request.ContentType = "application/x-www-form-urlencoded";

                byte[] requestDataBytes = Encoding.UTF8.GetBytes(requestData);

                request.ContentLength = requestDataBytes.Length;

                Stream requestDataStream = request.GetRequestStream();

                requestDataStream.Write(requestDataBytes, 0, requestDataBytes.Length);
                requestDataStream.Flush();
                requestDataStream.Close();
            }

            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                Stream responseStream = response.GetResponseStream();

                List<byte[]> respBytes = new List<byte[]>();

                byte[] buffer = new byte[8192]; // 8k 

                int bytesRead = 0;
                int dataLength = 0;

                do
                {
                    // fill the buffer with data
                    bytesRead = responseStream.Read(buffer, 0, buffer.Length);

                    // make sure we read some data
                    if (bytesRead != 0)
                    {
                        dataLength += bytesRead;

                        byte[] part = new byte[bytesRead];
                        Array.Copy(buffer, part, bytesRead);

                        respBytes.Add(part);
                    }
                }
                while (bytesRead > 0);

                responseStream.Close();

                byte [] ret = new byte[dataLength];

                int curPos = 0;

                foreach (byte[] b in respBytes)
                {
                    Array.Copy(b, 0, ret, curPos, b.Length);
                    curPos += b.Length;
                }

                return ret;
            }
            catch (Exception ex)
            {
                strLastError = ex.Message;
                return null;
            }
        }

        public byte[] GetBytesEx(string requestUrl, RequestMethod requestMethod = RequestMethod.GET, string requestData = "")
        {
            HttpWebRequest request = null;

            try
            {
                // create a new request
                request = (HttpWebRequest)WebRequest.Create(requestUrl);
                // set timeout
                request.Timeout = timeout;
                request.CookieContainer = cookies;
            }
            catch (Exception ex)
            {
                strLastError = ex.Message;
                return null;
            }

            // Set proxy if enabled
            if (proxy != null)
            {
                request.Proxy = proxy;
            }

            switch (requestMethod)
            {
                case RequestMethod.GET:
                    request.Method = "GET";
                    break;
                case RequestMethod.POST:
                    request.Method = "POST";
                    request.KeepAlive = true;
                    request.AllowAutoRedirect = true;
                    request.ServicePoint.Expect100Continue = false;
                    byte[] postDataArray = Encoding.UTF8.GetBytes(requestData);
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
                using (var response = request.GetResponse())
                {
                    using (var responseDataStream = response.GetResponseStream())
                    {
                        int bytesRead = 0;
                        int totalBytesRead = 0;

                        List<byte[]> byteArrayList = new List<byte[]>();

                        do
                        {
                            byte[] buffer = new byte[8192];

                            bytesRead = responseDataStream.Read(buffer, 0, buffer.Length);
                            totalBytesRead += bytesRead;

                            if (bytesRead > 0)
                            {
                                byte[] dataBytesPart = new byte[bytesRead];
                                Array.Copy(buffer, dataBytesPart, bytesRead);

                                byteArrayList.Add(dataBytesPart);
                            }
                        }
                        while (bytesRead > 0);

                        if (totalBytesRead > 0)
                        {
                            byte[] dataBytes = new byte[totalBytesRead];
                            int position = 0;

                            for (int i = 0; i < byteArrayList.Count; i++)
                            {
                                Array.Copy(byteArrayList[i], 0, dataBytes, position, byteArrayList[i].Length);
                                position += byteArrayList[i].Length;
                            }

                            return dataBytes;
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                strLastError = ex.Message;
                return null;
            }
        }

        public string GetLastErrorMessage()
        {
            return strLastError;
        }

        public void SetTimeout(int seconds)
        {
            timeout = seconds * 1000;
        }
    }
}
