using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Net;
using System.Web;
using SeasideResearch.LibCurlNet;

namespace DistantVacantGovUz
{
    /// <summary>
    /// Метод HTTP-запроса
    /// </summary>
    public enum RequestMethod
    {
        GET,
        POST
    }

    /// <summary>
    /// Класс для работы с HTTP-запросами
    /// </summary>
    public class HttpRequest
    {
        Easy _curl;
        Easy.ProgressFunction pf;
        Easy.WriteFunction wf;
        Easy.DebugFunction df;

        string p_data;
        List<byte[]> bytes = new List<byte[]>();

        string strDebug;
        string strLastError;

        /// <summary>
        /// Получение последнего сообщения ошибки
        /// </summary>
        /// <returns>Строка с описанием ошибки</returns>
        public string GetLastErrorMessage()
        {
            return strLastError;
        }

        /// <summary>
        /// Включить проксификацию запросов
        /// </summary>
        /// <param name="strProxyHost">Адрес прокси-сервера</param>
        public void SetProxy(string p_strProxyHost, string p_strProxyUserName = "", string p_strProxyPassword = "")
        {
            _curl.SetOpt(CURLoption.CURLOPT_PROXY, p_strProxyHost);
            
            if (p_strProxyUserName != "")
            {
                //_curl.SetOpt(CURLoption.CURLOPT_PROXYUSERPWD, WebUtility.HtmlEncode(p_strProxyUserName) + ":" + WebUtility.HtmlEncode(p_strProxyPassword));
                _curl.SetOpt(CURLoption.CURLOPT_PROXYUSERPWD, HttpUtility.HtmlEncode(p_strProxyUserName) + ":" + HttpUtility.HtmlEncode(p_strProxyPassword));
            }
            else
            {
                _curl.SetOpt(CURLoption.CURLOPT_PROXYUSERPWD, "");
            }
        }

        /// <summary>
        /// Отключить проксификацию запросов
        /// </summary>
        public void UnsetProxy()
        {
            _curl.SetOpt(CURLoption.CURLOPT_PROXY, null);
        }

        /// <summary>
        /// Установка время ожидания на запрос
        /// </summary>
        /// <param name="seconds">Количество секунд ожидания (по-умолчанию 20 секунд)</param>
        public void SetTimeout(int seconds)
        {
            _curl.SetOpt(CURLoption.CURLOPT_TIMEOUT, seconds);
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
            this.p_data += Encoding.UTF8.GetString(buf);
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

        /// <summary>
        /// Конструктор класса HttpRequest
        /// </summary>
        public HttpRequest()
        {
            // Инициализация библиотеки cURL
            Curl.GlobalInit((int)CURLinitFlag.CURL_GLOBAL_ALL);
            _curl = new Easy();

            // Установка загаловков запроса по-умолчанию
            //_curl.SetOpt(CURLoption.CURLOPT_HEADER, "");
            //_curl.SetOpt(CURLoption.CURLOPT_ENCODING, "gzip");
            _curl.SetOpt(CURLoption.CURLOPT_USERAGENT, "Mozilla/4.0");
            _curl.SetOpt(CURLoption.CURLOPT_AUTOREFERER, 1);
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
        /// Деструктор класса HttpRequest
        /// </summary>
        ~HttpRequest()
        {
            if (_curl != null)
                _curl.Cleanup();

            Curl.GlobalCleanup();
        }

        /// <summary>
        /// Метод для отправки HTTP-запроса
        /// </summary>
        /// <param name="strUrl">URL-адрес запроса</param>
        /// <param name="method">Метод отправки запроса</param>
        /// <param name="data">POST-данные</param>
        /// <returns>Возратит результат запроса ввиде последовательности символов</returns>
        public string GetUrl(string strUrl, RequestMethod method = RequestMethod.GET, string data = "")
        {
            this.p_data = "";

            CURLcode c;
            
            c = _curl.SetOpt(CURLoption.CURLOPT_URL, strUrl);

            if (method == RequestMethod.POST)
            {
                c = _curl.SetOpt(CURLoption.CURLOPT_POSTFIELDS, data);
            }
            else
            {
                c = _curl.SetOpt(CURLoption.CURLOPT_POSTFIELDS, null);
            }

            c = _curl.Perform();

            return this.p_data;
        }

        /// <summary>
        /// Метод для отправки HTTP-запроса
        /// </summary>
        /// <param name="strUrl">URL-адрес запроса</param>
        /// <param name="method">Метод отправки запроса</param>
        /// <param name="data">POST-данные</param>
        /// <returns>Возратит результат запроса ввиде последовательности байтов</returns>
        public byte[] GetBytes(string strUrl, RequestMethod method = RequestMethod.GET, string data = "")
        {
            this.bytes.Clear();

            CURLcode c;

            c = _curl.SetOpt(CURLoption.CURLOPT_URL, strUrl);

            if (method == RequestMethod.POST)
            {
                c = _curl.SetOpt(CURLoption.CURLOPT_POSTFIELDS, data);
            }
            else
            {
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
            //return this.bytes.SelectMany(a => a).ToArray();
        }
    }
}
