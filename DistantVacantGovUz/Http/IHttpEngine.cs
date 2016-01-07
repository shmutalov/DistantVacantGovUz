using DistantVacantGovUz.Enums;

namespace DistantVacantGovUz.Http
{
    public interface IHttpEngine
    {
        /// <summary>
        /// Включить проксификацию запросов
        /// </summary>
        /// <param name="proxyHost">Адрес прокси-сервера</param>
        /// <param name="proxyUserName"></param>
        /// <param name="proxyPassword"></param>
        void SetProxy(string proxyHost, string proxyUserName = "", string proxyPassword = "");

        /// <summary>
        /// Отключить проксификацию запросов
        /// </summary>
        void UnsetProxy();

        /// <summary>
        /// Метод для отправки HTTP-запроса
        /// </summary>
        /// <param name="requestUrl">URL-адрес запроса</param>
        /// <param name="requestMethod">Метод отправки запроса</param>
        /// <param name="requestData">POST-данные</param>
        /// <returns>Возратит результат запроса ввиде последовательности байтов</returns>
        byte[] GetBytes(string requestUrl, HttpRequestMethod requestMethod = HttpRequestMethod.Get, string requestData = "");

        /// <summary>
        /// Метод для отправки HTTP-запроса
        /// </summary>
        /// <param name="requestUrl">URL-адрес запроса</param>
        /// <param name="requestMethod">Метод отправки запроса</param>
        /// <param name="requestData">POST-данные</param>
        /// <returns>Возратит результат запроса ввиде последовательности байтов</returns>
        byte[] GetBytesEx(string requestUrl, HttpRequestMethod requestMethod = HttpRequestMethod.Get, string requestData = "");

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
