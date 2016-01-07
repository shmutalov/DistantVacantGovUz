using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DistantVacantGovUz.Enums;
using SeasideResearch.LibCurlNet;

namespace DistantVacantGovUz.Http
{
    public class CurlHttpEngine : IHttpEngine
    {
        private readonly Easy _curl;
        private readonly Easy.WriteFunction _wf;
        private readonly Easy.DebugFunction _df;

        //string p_data;
        private readonly List<byte[]> _bytes = new List<byte[]>();

        private string _strLastError;

        /// <summary>
        /// Конструктор класса CurlHttpRequests
        /// </summary>
        public CurlHttpEngine()
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
            _df = DebugFunction;
            _wf = WriteFunction;

            _curl.SetOpt(CURLoption.CURLOPT_WRITEFUNCTION, _wf);
            _curl.SetOpt(CURLoption.CURLOPT_DEBUGFUNCTION, _df);
        }

        /// <summary>
        /// Деструктор класса CurlHttpRequests
        /// </summary>
        ~CurlHttpEngine()
        {
            _curl?.Cleanup();

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

        public byte[] GetBytes(string requestUrl, HttpRequestMethod requestMethod = HttpRequestMethod.Get, string requestData = "")
        {
            _bytes.Clear();

            _curl.SetOpt(CURLoption.CURLOPT_URL, requestUrl);

            _curl.SetOpt(CURLoption.CURLOPT_REFERER, requestUrl);

            if (requestMethod == HttpRequestMethod.Post)
            {
                _curl.SetOpt(CURLoption.CURLOPT_POST, true);
                _curl.SetOpt(CURLoption.CURLOPT_POSTFIELDS, requestData);
                //c = _curl.SetOpt(CURLoption.CURLOPT_POSTFIELDSIZE, requestData.Length);
                //c = _curl.SetOpt(CURLoption.CURLOPT_POSTREDIR, CURLRedir.ALL);
            }
            else
            {
                _curl.SetOpt(CURLoption.CURLOPT_POST, false);
                _curl.SetOpt(CURLoption.CURLOPT_POSTFIELDS, null);
            }

            _curl.Perform();

            var dataLen = _bytes.Sum(b => b.Length);

            var ret = new byte[dataLen];
            var curPos = 0;

            foreach (var b in _bytes)
            {
                Array.Copy(b, 0, ret, curPos, b.Length);
                curPos += b.Length;
            }

            return ret;
        }


        public string GetLastErrorMessage()
        {
            return _strLastError;
        }

        /// <summary>
        /// Внутренняя функция записи получаеммых данных (результата запроса) cURL
        /// </summary>
        /// <param name="buf"></param>
        /// <param name="size"></param>
        /// <param name="nmemb"></param>
        /// <param name="extraData"></param>
        /// <returns></returns>
        private int WriteFunction(byte[] buf, int size, int nmemb, object extraData)
        {
            _bytes.Add(buf);
            
            return size * nmemb;
        }

        /// <summary>
        /// Внутренняя функция вывода отладочных данных cURL
        /// </summary>
        /// <param name="infoType"></param>
        /// <param name="message"></param>
        /// <param name="extraData"></param>
        private void DebugFunction(CURLINFOTYPE infoType, string message, object extraData)
        {
            _strLastError = message;
        }

        public void SetTimeout(int seconds)
        {
            _curl.SetOpt(CURLoption.CURLOPT_TIMEOUT, seconds);
        }


        public byte[] GetBytesEx(string requestUrl, HttpRequestMethod requestMethod = HttpRequestMethod.Get, string requestData = "")
        {
            return GetBytes(requestUrl, requestMethod, requestData);
        }
    }
}
