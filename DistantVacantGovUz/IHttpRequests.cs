using System;
using System.Collections.Generic;
using System.Text;

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

    public interface IHttpRequests
    {
        /// <summary>
        /// Включить проксификацию запросов
        /// </summary>
        /// <param name="strProxyHost">Адрес прокси-сервера</param>
        void SetProxy(string proxyHost, string proxyUserName = "", string proxyPassword = "");

        /// <summary>
        /// Отключить проксификацию запросов
        /// </summary>
        void UnsetProxy();

        /// <summary>
        /// Метод для отправки HTTP-запроса
        /// </summary>
        /// <param name="strUrl">URL-адрес запроса</param>
        /// <param name="method">Метод отправки запроса</param>
        /// <param name="data">POST-данные</param>
        /// <returns>Возратит результат запроса ввиде последовательности байтов</returns>
        byte[] GetBytes(string requestUrl, RequestMethod requestMethod = RequestMethod.GET, string requestData = "");

        /// <summary>
        /// Метод для отправки HTTP-запроса
        /// </summary>
        /// <param name="strUrl">URL-адрес запроса</param>
        /// <param name="method">Метод отправки запроса</param>
        /// <param name="data">POST-данные</param>
        /// <returns>Возратит результат запроса ввиде последовательности байтов</returns>
        byte[] GetBytesEx(string requestUrl, RequestMethod requestMethod = RequestMethod.GET, string requestData = "");

        /// <summary>
        /// Получение последнего сообщения ошибки
        /// </summary>
        /// <returns>Строка с описанием ошибки</returns>
        string GetLastErrorMessage();

        /// <summary>
        /// Установка время ожидания на запрос
        /// </summary>
        /// <param name="seconds">Количество секунд ожидания (по-умолчанию 20 секунд)</param>
        void SetTimeout(int seconds);
    }
}
