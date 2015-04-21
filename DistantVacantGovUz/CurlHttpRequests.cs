using System;
using System.Collections.Generic;
using System.Text;
using SeasideResearch.LibCurlNet;
using System.Web;

namespace DistantVacantGovUz
{
    public class CurlHttpRequests : IHttpRequests
    {
        Easy _curl;
        Easy.WriteFunction wf;
        Easy.DebugFunction df;
        
        //string p_data;
        List<byte[]> bytes = new List<byte[]>();

        string strDebug;
        string strLastError;

        /// <summary>
        /// Конструктор класса CurlHttpRequests
        /// </summary>
        public CurlHttpRequests()
        {
            // Инициализация библиотеки cURL
            Curl.GlobalInit((int)CURLinitFlag.CURL_GLOBAL_ALL);
            _curl = new Easy();

            // Установка загаловков запроса по-умолчанию
            //_curl.SetOpt(CURLoption.CURLOPT_HEADER, "");
            //_curl.SetOpt(CURLoption.CURLOPT_ENCODING, "gzip");
            _curl.SetOpt(CURLoption.CURLOPT_USERAGENT, "	Mozilla/5.0 (Windows NT 6.3; WOW64; rv:34.0) Gecko/20100101 Firefox/34.0");
            //_curl.SetOpt(CURLoption.CURLOPT_HEADER, "");
            //_curl.SetOpt(CURLoption.CURLOPT_AUTOREFERER, 1);
            _curl.SetOpt(CURLoption.CURLOPT_FOLLOWLOCATION, 1);
            _curl.SetOpt(CURLoption.CURLOPT_SSL_VERIFYPEER, false);
            //_curl.SetOpt(CURLoption.CURLOPT_COOKIEJAR, Environment.CurrentDirectory + @"\" + "cookie.txt");
            _curl.SetOpt(CURLoption.CURLOPT_COOKIEJAR, Program.GetApplicationDirectory() + @"\" + "cookie.txt");
            _curl.SetOpt(CURLoption.CURLOPT_TIMEOUT, 30);
            
            // Назначение внутренних служебных функций cURL
            df = new Easy.DebugFunction(DebugFunction);
            wf = new Easy.WriteFunction(WriteFunction);

            _curl.SetOpt(CURLoption.CURLOPT_WRITEFUNCTION, wf);
            _curl.SetOpt(CURLoption.CURLOPT_DEBUGFUNCTION, df);
        }

        /// <summary>
        /// Деструктор класса CurlHttpRequests
        /// </summary>
        ~CurlHttpRequests()
        {
            if (_curl != null)
                _curl.Cleanup();

            Curl.GlobalCleanup();
        }

        public void SetProxy(string proxyHost, string proxyUserName = "", string proxyPassword = "")
        {
            _curl.SetOpt(CURLoption.CURLOPT_PROXY, proxyHost);

            if (proxyUserName != "")
            {
                //_curl.SetOpt(CURLoption.CURLOPT_PROXYUSERPWD, WebUtility.HtmlEncode(p_strProxyUserName) + ":" + WebUtility.HtmlEncode(p_strProxyPassword));
                _curl.SetOpt(CURLoption.CURLOPT_PROXYUSERPWD
                    , HttpUtility.HtmlEncode(proxyUserName) + ":" + HttpUtility.HtmlEncode(proxyPassword));
            }
            else
            {
                _curl.SetOpt(CURLoption.CURLOPT_PROXYUSERPWD, "");
            }
        }

        public void UnsetProxy()
        {
            _curl.SetOpt(CURLoption.CURLOPT_PROXY, null);
        }

        public byte[] GetBytes(string requestUrl, RequestMethod requestMethod = RequestMethod.GET, string requestData = "")
        {
            this.bytes.Clear();

            CURLcode c;

            c = _curl.SetOpt(CURLoption.CURLOPT_URL, requestUrl);

            c = _curl.SetOpt(CURLoption.CURLOPT_REFERER, requestUrl);

            if (requestMethod == RequestMethod.POST)
            {
                c = _curl.SetOpt(CURLoption.CURLOPT_POST, true);
                c = _curl.SetOpt(CURLoption.CURLOPT_POSTFIELDS, requestData);
                //c = _curl.SetOpt(CURLoption.CURLOPT_POSTFIELDSIZE, requestData.Length);
                //c = _curl.SetOpt(CURLoption.CURLOPT_POSTREDIR, CURLRedir.ALL);
            }
            else
            {
                c = _curl.SetOpt(CURLoption.CURLOPT_POST, false);
                c = _curl.SetOpt(CURLoption.CURLOPT_POSTFIELDS, null);
            }

            c = _curl.Perform();

            int dataLen = 0;

            foreach (byte[] b in bytes)
            {
                dataLen += b.Length;
            }

            byte[] ret = new byte[dataLen];
            int curPos = 0;

            foreach (byte[] b in bytes)
            {
                Array.Copy(b, 0, ret, curPos, b.Length);
                curPos += b.Length;
            }

            return ret;
        }


        public string GetLastErrorMessage()
        {
            return strLastError;
        }

        /// <summary>
        /// Внутренняя функция записи получаеммых данных (результата запроса) cURL
        /// </summary>
        /// <param name="buf"></param>
        /// <param name="size"></param>
        /// <param name="nmemb"></param>
        /// <param name="extraData"></param>
        /// <returns></returns>
        private Int32 WriteFunction(byte[] buf, Int32 size, Int32 nmemb, Object extraData)
        {
            bytes.Add(buf);
            //this.p_data += Encoding.UTF8.GetString(buf);
            return size * nmemb;
        }

        /// <summary>
        /// Внутренняя функция вывода отладочных данных cURL
        /// </summary>
        /// <param name="infoType"></param>
        /// <param name="message"></param>
        /// <param name="extraData"></param>
        public void DebugFunction(CURLINFOTYPE infoType, string message, object extraData)
        {
            strDebug += message;
            strLastError = message;
        }

        public void SetTimeout(int seconds)
        {
            _curl.SetOpt(CURLoption.CURLOPT_TIMEOUT, seconds);
        }


        public byte[] GetBytesEx(string requestUrl, RequestMethod requestMethod = RequestMethod.GET, string requestData = "")
        {
            return GetBytes(requestUrl, requestMethod, requestData);
        }
    }
}
