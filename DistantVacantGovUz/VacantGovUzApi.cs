using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using DistantVacantGovUz.Enums;
using DistantVacantGovUz.Http;
using DistantVacantGovUz.Models;
using Majestic12;

namespace DistantVacantGovUz
{
    /// <summary>
    /// Класс для работы с системой публикации вакансий vacant.gov.uz
    /// </summary>
    public class VacantGovUzApi
    {
        /// <summary>
        /// Класс для работы с HTTP-запросами
        /// </summary>
        //private HttpRequest http;
        private readonly IHttpEngine _http;

        /// <summary>
        /// Класс для парсинга HTML-данных
        /// </summary>
        private readonly HTMLparser _parser;

        //private string strIDUzLoginUrl = @"http://www.id.uz/users/login/authenticate?token=";
        //private string strVacantGovUzLoginUrl = @"http://vacant.gov.uz/site/login";
        private string _strLoginUrl;
        private const string StrLogoutUrl = @"http://vacant.gov.uz/ru/site/logout";
        private const string StrVacantUrl = @"http://vacant.gov.uz";
        private const string StrOpenedUrl = @"http://vacant.gov.uz/ru/vacancies/admin";
        private const string StrClosedUrl = @"http://vacant.gov.uz/ru/vacancies/Cadmin";
        private const string StrCreateUrl = @"http://vacant.gov.uz/ru/vacancies/create";
        private const string StrReceivedUrlString = @"http://vacant.gov.uz/uz/request/received";
        private const string StrReceivedUrl = @"http://vacant.gov.uz/ru/request/received";
        private const string StrApprovedUrl = @"http://vacant.gov.uz/ru/request/approved";
        private const string StrProcessedUrl = @"http://vacant.gov.uz/ru/request/processed";
        private const string StrReservedUrl = @"http://vacant.gov.uz/ru/request/reserved";
        private const string StrAddVacancyUrl = @"http://vacant.gov.uz/ru/vacancies/create";
        private const string StrEditVacancyUrl = @"http://vacant.gov.uz/ru/vacancies/update";
        //private const string strRefreshCaptchaUrl = @"http://vacant.gov.uz/ru/vacancies/captcha?refresh=1&_=";
        //private const string strCaptchaImageUrl = @"http://vacant.gov.uz/ru/vacancies/captcha?v=";
        private const string StrRefreshCaptchaUrl = @"http://vacant.gov.uz/ru/site/captcha?refresh=1&_=";
        private const string StrCaptchaImageUrl = @"http://vacant.gov.uz/ru/site/captcha?v=";

        private string _vacancyUserName = string.Empty;

        /// <summary>
        /// Свойство для установки и проверки статуса
        /// подключения к vacant.gov.uz
        /// </summary>
        private bool IsLogged { get; set; }

        private bool _useProxy;
        private string _strProxyHost;
        private string _strProxyUserName;
        private string _strProxyPassword;

        private string _strCaptchaText = string.Empty;

        /// <summary>
        /// Удаление HTML-тегов в строке
        /// </summary>
        /// <param name="inputString">Строка для анализа</param>
        /// <returns>Возрватит строку без HTML-тегов</returns>
        private string StripHtmlTags(string inputString)
        {
            if (inputString.Length == 0)
                return string.Empty;

            var array = new char[inputString.Length]; 
            var arrayIndex = 0; 
            var inside = false;

            foreach (var letter in inputString)
            {
                switch (letter)
                {
                    case '<':
                        inside = true; 
                        continue;
                    case '>':
                        inside = false; 
                        continue;
                }

                if (inside)
                    continue;

                array[arrayIndex] = letter; 
                arrayIndex++;
            } 
            
            return new string(array, 0, arrayIndex);
        }

        /// <summary>
        /// Очистка строки от лишних пробелов и HTML-тэгов
        /// </summary>
        /// <param name="pSrcString">Входящая строка для анализа</param>
        /// <returns>Возратит "очищенную" строку</returns>
        private string ClearString(string pSrcString)
        {
            var temp = StripHtmlTags(pSrcString);
            temp = temp.Replace("\r\n\r\n", "\r\n");
            temp = temp.Replace("\r\n\r\n", "\r\n");
            temp = temp.Replace("\t", "");
            temp = temp.Replace("  ", " ");
            temp = temp.Replace("  ", " ");
            temp = temp.Trim();

            return temp;
        }

        /// <summary>
        /// Использование HTTP-прокси
        /// </summary>
        public bool UseProxy
        {
            get
            {
                return _useProxy;
            }
            set
            {
                _useProxy = value;

                if (_useProxy)
                {
                    _http.SetProxy(_strProxyHost, _strProxyUserName, _strProxyPassword);

                    /*if ((strProxyUserName != null) && (strProxyUserName.Trim() != ""))
                    {
                        // set proxy credentials
                    }*/
                }
                else
                {
                    _http.UnsetProxy();
                }
            }
        }

        private string _strVacUserName;
        private string _strVacPassword;

        /// <summary>
        /// Конструктор класса CVacantGovUz
        /// </summary>
        public VacantGovUzApi()
        {
            _http = HttpEngineFactory.GetHttpEngine(HttpRequestsType.Net);

            _parser = new HTMLparser
            {
                bAutoKeepComments = false,
                bAutoKeepScripts = false,
                bAutoMarkClosedTagsWithParamsAsOpen = true,
                bCompressWhiteSpaceBeforeTag = true,
                bKeepRawHTML = false,
                bDecodeEntities = true,
                bDecodeMiniEntities = true
            };

            // parser parameters
            _parser.InitMiniEntities();
            
            _parser.SetEncoding(Encoding.UTF8);
        }

        /// <summary>
        /// Получение последнего сообщения ошибки
        /// </summary>
        /// <returns>Строка с описанием ошибки</returns>
        public string GetLastErrorMessage()
        {
            return _http.GetLastErrorMessage();
        }

        /// <summary>
        /// Установка значений прокси-сервера
        /// </summary>
        /// <param name="pStrProxyHost">Адрес прокси-сервера</param>
        /// <param name="pStrProxyUserName">Пользователь</param>
        /// <param name="pStrProxyPassword">Пароль</param>
        public void SetHttpProxy(string pStrProxyHost, string pStrProxyUserName, string pStrProxyPassword)
        {
            _strProxyHost = pStrProxyHost;
            _strProxyUserName = pStrProxyUserName;
            _strProxyPassword = pStrProxyPassword;
        }

        /// <summary>
        /// Метод входа в систему vacant.gov.uz
        /// </summary>
        /// <param name="userName">имя пользователя</param>
        /// <param name="password">пароль пользователя</param>
        /// <returns>При успешном входе в систему возвращает результат true</returns>
        public bool Login(string userName, string password)
        {
            IsLogged = false;

            if ((password == "") || (userName == ""))
                return IsLogged;

            _strVacUserName = userName;
            _strVacPassword = password;

            _strLoginUrl = @"https://www.id.uz/openid/authenticate?openid.return_to=http%3A%2F%2Fvacant.gov.uz%2Fsite%2Flogin%3Fopenid.claimed_id%3Dhttp%3A%2F%2F" + Uri.EscapeDataString(_strVacUserName) + ".id.uz%2F&openid.mode=checkid_setup&openid.identity=https%3A%2F%2F" + Uri.EscapeDataString(_strVacUserName) + ".id.uz%2F&openid.trust_root=http%3A%2F%2Fvacant.gov.uz&openid.ns.sreg=http%3A%2F%2Fopenid.net%2Fextensions%2Fsreg%2F1.1&openid.sreg.required=nickname%2Cemail%2Cphone%2Cfullname%2Cpublic_id%2Cstatus";

            var postData = @"password=" + Uri.EscapeDataString(_strVacPassword);

            var bytes = _http.GetBytes(_strLoginUrl, HttpRequestMethod.Post, postData);

            var page = string.Empty;

            if (bytes != null)
                page = Encoding.UTF8.GetString(bytes);
            
            if (page.Contains(@"/uz/site/logout"))
            {
                var iUserNameStart = page.IndexOf(@", hurmatli", StringComparison.InvariantCultureIgnoreCase) + 11;

                var iUserNameLength = page.IndexOf(@"<", iUserNameStart, StringComparison.InvariantCultureIgnoreCase) - iUserNameStart;

                _vacancyUserName = page.Substring(iUserNameStart, iUserNameLength).Trim();

                IsLogged = true;
            }
            else
            {
                IsLogged = false;
            }

            return IsLogged;
        }

        /// <summary>
        /// Выход из системы vacant.gov.uz
        /// </summary>
        public void Logout()
        {
            if (IsLogged)
            {
                _http.GetBytes(StrLogoutUrl);
            }

            IsLogged = false;
        }

        /// <summary>
        /// Добавление новой вакансии
        /// </summary>
        /// <returns>При успешном добавлении возвратит <b>true</b></returns>
        public bool AddVacancy(Vacancy pVacancy)
        {
            if (IsLogged)
            {
                //string post_data = @"Vacancies[name_ru]=#VACANCIES_NAME_RU#&Vacancies[name_uz]=#VACANCIES_NAME_UZ#&Vacancies[category_id]=#VACANCIES_CATEGORY_ID#&Vacancies[salary]=#VACANCIES_SALARY#&Vacancies[employment]=#VACANCIES_EMPLOYMENT#&Vacancies[gender]=#VACANCIES_GENDER#&Vacancies[exp_period]=#VACANCIES_EXP_PERIOD#&Vacancies[education]=#VACANCIES_EDUCATION#&Vacancies[exp_date]=#VACANCIES_EXP_DATE#&Vacancies[status]=#VACANCIES_STATUS#&Vacancies[department_ru]=#VACANCIES_DEPARTMENT_RU#&Vacancies[specialization_ru]=#VACANCIES_SPECIALIZATION_RU#&Vacancies[requarements_ru]=#VACANCIES_REQUAREMENTS_RU#&Vacancies[information_ru]=#VACANCIES_INFORMATION_RU#&Vacancies[department_uz]=#VACANCIES_DEPARTMENT_UZ#&Vacancies[specialization_uz]=#VACANCIES_SPECIALIZATION_UZ#&Vacancies[requarements_uz]=#VACANCIES_REQUAREMENTS_UZ#&Vacancies[information_uz]=#VACANCIES_INFORMATION_UZ#";
                var postData = string.Empty;
                postData += "Vacancies[category_id]=#VACANCIES_CATEGORY_ID#";
                postData += "&Vacancies[department_ru]=#VACANCIES_DEPARTMENT_RU#";
                postData += "&Vacancies[department_uz]=#VACANCIES_DEPARTMENT_UZ#";
                postData += "&Vacancies[education]=#VACANCIES_EDUCATION#";
                postData += "&Vacancies[employment]=#VACANCIES_EMPLOYMENT#";
                postData += "&Vacancies[exp_date]=#VACANCIES_EXP_DATE#";
                postData += "&Vacancies[exp_period]=#VACANCIES_EXP_PERIOD#";
                postData += "&Vacancies[gender]=#VACANCIES_GENDER#";
                postData += "&Vacancies[information_ru]=#VACANCIES_INFORMATION_RU#";
                postData += "&Vacancies[information_uz]=#VACANCIES_INFORMATION_UZ#";
                postData += "&Vacancies[name_ru]=#VACANCIES_NAME_RU#";
                postData += "&Vacancies[name_uz]=#VACANCIES_NAME_UZ#";
                postData += "&Vacancies[requarements_ru]=#VACANCIES_REQUAREMENTS_RU#";
                postData += "&Vacancies[requarements_uz]=#VACANCIES_REQUAREMENTS_UZ#";
                postData += "&Vacancies[salary]=#VACANCIES_SALARY#";
                postData += "&Vacancies[specialization_ru]=#VACANCIES_SPECIALIZATION_RU#";
                postData += "&Vacancies[specialization_uz]=#VACANCIES_SPECIALIZATION_UZ#";
                postData += "&Vacancies[status]=#VACANCIES_STATUS#";
                // captcha
                postData += "&Vacancies[verifyCode]=#VACANCIES_CAPTCHA#";

                postData = postData.Replace(@"#VACANCIES_NAME_RU#", Uri.EscapeDataString(pVacancy.StrDescriptionRu));
                postData = postData.Replace(@"#VACANCIES_NAME_UZ#", Uri.EscapeDataString(pVacancy.StrDescriptionUz));
                postData = postData.Replace(@"#VACANCIES_CATEGORY_ID#", Vacancy.CategoryId(pVacancy.Category).ToString());
                postData = postData.Replace(@"#VACANCIES_SALARY#", Uri.EscapeDataString(pVacancy.StrSalary));
                postData = postData.Replace(@"#VACANCIES_EMPLOYMENT#", Vacancy.EmploymentId(pVacancy.Employment));
                postData = postData.Replace(@"#VACANCIES_GENDER#", Vacancy.GenderId(pVacancy.Gender));
                postData = postData.Replace(@"#VACANCIES_EXP_PERIOD#", Vacancy.ExperienceId(pVacancy.Experience));
                postData = postData.Replace(@"#VACANCIES_EDUCATION#", Vacancy.EducationId(pVacancy.EducatonLevel));
                postData = postData.Replace(@"#VACANCIES_EXP_DATE#", Uri.EscapeDataString(pVacancy.ExpireDate));
                postData = postData.Replace(@"#VACANCIES_STATUS#", Vacancy.StatusId(pVacancy.Status));
                postData = postData.Replace(@"#VACANCIES_DEPARTMENT_RU#", Uri.EscapeDataString(pVacancy.DepartmentRu));
                postData = postData.Replace(@"#VACANCIES_SPECIALIZATION_RU#", Uri.EscapeDataString(pVacancy.SpecializationRu));
                postData = postData.Replace(@"#VACANCIES_REQUAREMENTS_RU#", Uri.EscapeDataString(pVacancy.RequirementsRu));
                postData = postData.Replace(@"#VACANCIES_INFORMATION_RU#", Uri.EscapeDataString(pVacancy.InformationRu));
                postData = postData.Replace(@"#VACANCIES_DEPARTMENT_UZ#", Uri.EscapeDataString(pVacancy.DepartmentUz));
                postData = postData.Replace(@"#VACANCIES_SPECIALIZATION_UZ#", Uri.EscapeDataString(pVacancy.SpecializationUz));
                postData = postData.Replace(@"#VACANCIES_REQUAREMENTS_UZ#", Uri.EscapeDataString(pVacancy.RequirementsUz));
                postData = postData.Replace(@"#VACANCIES_INFORMATION_UZ#", Uri.EscapeDataString(pVacancy.InformationUz));
                postData = postData.Replace(@"#VACANCIES_CAPTCHA#", _strCaptchaText);

                //string page = http.GetUrl(strAddVacancyUrl, RequestMethod.POST, post_data);
                var bytes = _http.GetBytesEx(StrAddVacancyUrl, HttpRequestMethod.Post, postData);
                var page = string.Empty;

                if (bytes != null)
                    page = Encoding.UTF8.GetString(bytes);

                var strSearch = "a class=\"brand pull-right\" href=\"/ru/vacancies/admin/";

                var vacIdStrIndex = page.IndexOf(strSearch, StringComparison.InvariantCultureIgnoreCase);

                return vacIdStrIndex > 0;
            }
            else
                return false;
        }

        /// <summary>
        /// Редактирование вакансии
        /// </summary>
        /// <returns>При успешном редактировании возвратит <b>true</b></returns>
        public bool EditVacancy(int pVacId, Vacancy pVacancy)
        {
            if (!IsLogged)
                return false;

            var postData = string.Empty;
            postData += @"Vacancies[name_ru]=#VACANCIES_NAME_RU#";
            postData += "&Vacancies[name_uz]=#VACANCIES_NAME_UZ#";
            postData += "&Vacancies[category_id]=#VACANCIES_CATEGORY_ID#";
            postData += "&Vacancies[salary]=#VACANCIES_SALARY#";
            postData += "&Vacancies[employment]=#VACANCIES_EMPLOYMENT#";
            postData += "&Vacancies[gender]=#VACANCIES_GENDER#";
            postData += "&Vacancies[exp_period]=#VACANCIES_EXP_PERIOD#";
            postData += "&Vacancies[education]=#VACANCIES_EDUCATION#";
            postData += "&Vacancies[exp_date]=#VACANCIES_EXP_DATE#";
            postData += "&Vacancies[status]=#VACANCIES_STATUS#";
            postData += "&Vacancies[department_ru]=#VACANCIES_DEPARTMENT_RU#";
            postData += "&Vacancies[specialization_ru]=#VACANCIES_SPECIALIZATION_RU#";
            postData += "&Vacancies[requarements_ru]=#VACANCIES_REQUAREMENTS_RU#";
            postData += "&Vacancies[information_ru]=#VACANCIES_INFORMATION_RU#";
            postData += "&Vacancies[department_uz]=#VACANCIES_DEPARTMENT_UZ#";
            postData += "&Vacancies[specialization_uz]=#VACANCIES_SPECIALIZATION_UZ#";
            postData += "&Vacancies[requarements_uz]=#VACANCIES_REQUAREMENTS_UZ#";
            postData += "&Vacancies[information_uz]=#VACANCIES_INFORMATION_UZ#";
            // captcha
            postData += "&Vacancies[verifyCode]=#VACANCIES_CAPTCHA#";

            //post_data = post_data.Replace("[", "%5B").Replace("]", "%5D");

            postData = postData.Replace(@"#VACANCIES_NAME_RU#", Uri.EscapeDataString(pVacancy.StrDescriptionRu));
            postData = postData.Replace(@"#VACANCIES_NAME_UZ#", Uri.EscapeDataString(pVacancy.StrDescriptionUz));
            postData = postData.Replace(@"#VACANCIES_CATEGORY_ID#", Vacancy.CategoryId(pVacancy.Category).ToString());
            postData = postData.Replace(@"#VACANCIES_SALARY#", Uri.EscapeDataString(pVacancy.StrSalary));
            postData = postData.Replace(@"#VACANCIES_EMPLOYMENT#", Vacancy.EmploymentId(pVacancy.Employment));
            postData = postData.Replace(@"#VACANCIES_GENDER#", Vacancy.GenderId(pVacancy.Gender));
            postData = postData.Replace(@"#VACANCIES_EXP_PERIOD#", Vacancy.ExperienceId(pVacancy.Experience));
            postData = postData.Replace(@"#VACANCIES_EDUCATION#", Vacancy.EducationId(pVacancy.EducatonLevel));
            postData = postData.Replace(@"#VACANCIES_EXP_DATE#", Uri.EscapeDataString(pVacancy.ExpireDate));
            postData = postData.Replace(@"#VACANCIES_STATUS#", Vacancy.StatusId(pVacancy.Status));
            postData = postData.Replace(@"#VACANCIES_DEPARTMENT_RU#", Uri.EscapeDataString(pVacancy.DepartmentRu));
            postData = postData.Replace(@"#VACANCIES_SPECIALIZATION_RU#", Uri.EscapeDataString(pVacancy.SpecializationRu));
            postData = postData.Replace(@"#VACANCIES_REQUAREMENTS_RU#", Uri.EscapeDataString(pVacancy.RequirementsRu));
            postData = postData.Replace(@"#VACANCIES_INFORMATION_RU#", Uri.EscapeDataString(pVacancy.InformationRu));
            postData = postData.Replace(@"#VACANCIES_DEPARTMENT_UZ#", Uri.EscapeDataString(pVacancy.DepartmentUz));
            postData = postData.Replace(@"#VACANCIES_SPECIALIZATION_UZ#", Uri.EscapeDataString(pVacancy.SpecializationUz));
            postData = postData.Replace(@"#VACANCIES_REQUAREMENTS_UZ#", Uri.EscapeDataString(pVacancy.RequirementsUz));
            postData = postData.Replace(@"#VACANCIES_INFORMATION_UZ#", Uri.EscapeDataString(pVacancy.InformationUz));
            postData = postData.Replace(@"#VACANCIES_CAPTCHA#", _strCaptchaText);

            var bytes = _http.GetBytesEx(StrEditVacancyUrl + @"/" + pVacId, HttpRequestMethod.Post, postData);
            //string page = http.GetUrl(strEditVacancyUrl + @"/" + p_vac_id.ToString(), RequestMethod.POST, post_data);
            var page = string.Empty;

            if (bytes != null)
                page = Encoding.UTF8.GetString(bytes);

            var strSearch = "a class=\"brand pull-right\" href=\"/ru/vacancies/admin/";

            var vacIdStrIndex = page.IndexOf(strSearch, StringComparison.InvariantCultureIgnoreCase);

            return vacIdStrIndex > 0;
        }

        public Vacancy GetVacancy(int pVacId)
        {
            IsLogged = true;

            if (IsLogged)
            {
                var bytes = _http.GetBytes(StrEditVacancyUrl + "/" + pVacId);
                var page = string.Empty;

                if (bytes != null)
                    page = Encoding.UTF8.GetString(bytes);

                if (page.IndexOf(@"Редактировать вакансию", StringComparison.InvariantCultureIgnoreCase) <= 0)
                    return null;

                _parser.Init(Encoding.UTF8.GetBytes(page));
                _parser.SetEncoding(Encoding.UTF8);

                HTMLchunk chunk;

                // input box
                var vacanciesNameRu = string.Empty;
                var vacanciesNameUz = string.Empty;
                var vacanciesSalary = string.Empty;
                var vacanciesExpDate = string.Empty;
                var vacanciesDepartmentRu = string.Empty;
                var vacanciesDepartmentUz = string.Empty;

                // option
                var vacanciesCategoryId = string.Empty;
                var vacanciesEmployment = string.Empty;
                var vacanciesGender = string.Empty;
                var vacanciesExpPeriod = string.Empty;
                var vacanciesEducation = string.Empty;
                var vacanciesStatus = string.Empty;

                // textarea
                var vacanciesSpecializationRu = string.Empty;
                var vacanciesSpecializationUz = string.Empty;
                var vacanciesRequarementsRu = string.Empty;
                var vacanciesRequarementsUz = string.Empty;
                var vacanciesInformationRu = string.Empty;
                var vacanciesInformationUz = string.Empty;

                while ((chunk = _parser.ParseNext()) != null)
                {
                    switch (chunk.oType)
                    {
                        case HTMLchunkType.OpenTag:
                            switch (chunk.sTag)
                            {
                                case "input":
                                    switch (chunk.GetParamValue("id"))
                                    {
                                        case "Vacancies_name_ru":
                                            vacanciesNameRu = chunk.GetParamValue("value");
                                            break;
                                        case "Vacancies_name_uz":
                                            vacanciesNameUz = chunk.GetParamValue("value");
                                            break;
                                        case "Vacancies_salary":
                                            vacanciesSalary = chunk.GetParamValue("value");
                                            break;
                                        case "Vacancies_exp_date":
                                            vacanciesExpDate = chunk.GetParamValue("value");
                                            break;
                                        case "Vacancies_department_ru":
                                            vacanciesDepartmentRu = chunk.GetParamValue("value");
                                            break;
                                        case "Vacancies_department_uz":
                                            vacanciesDepartmentUz = chunk.GetParamValue("value");
                                            break;
                                        default:
                                            continue;
                                    }
                                    break;
                                case "select":
                                    HTMLchunk oChunk;
                                    switch (chunk.GetParamValue("id"))
                                    {
                                        case "Vacancies_category_id":
                                            while ((oChunk = _parser.ParseNextTag()).sTag == "option")
                                            {
                                                if (oChunk.GetParamValue("selected") == "selected")
                                                {
                                                    vacanciesCategoryId = oChunk.GetParamValue("value");
                                                    break;
                                                }
                                            }
                                            break;
                                        case "Vacancies_employment":
                                            while ((oChunk = _parser.ParseNextTag()).sTag == "option")
                                            {
                                                if (oChunk.GetParamValue("selected") == "selected")
                                                {
                                                    vacanciesEmployment = oChunk.GetParamValue("value");
                                                    break;
                                                }
                                            }
                                            break;
                                        case "Vacancies_gender":
                                            while ((oChunk = _parser.ParseNextTag()).sTag == "option")
                                            {
                                                if (oChunk.GetParamValue("selected") == "selected")
                                                {
                                                    vacanciesGender = oChunk.GetParamValue("value");
                                                    break;
                                                }
                                            }
                                            break;
                                        case "Vacancies_exp_period":
                                            while ((oChunk = _parser.ParseNextTag()).sTag == "option")
                                            {
                                                if (oChunk.GetParamValue("selected") == "selected")
                                                {
                                                    vacanciesExpPeriod = oChunk.GetParamValue("value");
                                                    break;
                                                }

                                                if (vacanciesExpPeriod == "")
                                                    vacanciesExpPeriod = "none";
                                            }
                                            break;
                                        case "Vacancies_education":
                                            while ((oChunk = _parser.ParseNextTag()).sTag == "option")
                                            {
                                                if (oChunk.GetParamValue("selected") == "selected")
                                                {
                                                    vacanciesEducation = oChunk.GetParamValue("value");
                                                    break;
                                                }
                                            }
                                            break;
                                        case "Vacancies_status":
                                            while ((oChunk = _parser.ParseNextTag()).sTag == "option")
                                            {
                                                if (oChunk.GetParamValue("selected") == "selected")
                                                {
                                                    vacanciesStatus = oChunk.GetParamValue("value");
                                                    break;
                                                }
                                            }
                                            break;
                                        default:
                                            continue;
                                    }
                                    break;
                                case "textarea":
                                    HTMLchunk tChunk;
                                    switch (chunk.GetParamValue("id"))
                                    {
                                        case "Vacancies_specialization_ru":
                                            tChunk = _parser.ParseNext();

                                            if (tChunk.oType == HTMLchunkType.Text)
                                            {
                                                vacanciesSpecializationRu = ClearString(HttpUtility.HtmlDecode(tChunk.oHTML));
                                            }
                                            break;
                                        case "Vacancies_specialization_uz":
                                            tChunk = _parser.ParseNext();

                                            if (tChunk.oType == HTMLchunkType.Text)
                                            {
                                                vacanciesSpecializationUz = ClearString(HttpUtility.HtmlDecode(tChunk.oHTML));
                                            }
                                            break;
                                        case "Vacancies_requarements_ru":
                                            tChunk = _parser.ParseNext();

                                            if (tChunk.oType == HTMLchunkType.Text)
                                            {
                                                vacanciesRequarementsRu = ClearString(HttpUtility.HtmlDecode(tChunk.oHTML));
                                            }
                                            break;
                                        case "Vacancies_requarements_uz":
                                            tChunk = _parser.ParseNext();

                                            if (tChunk.oType == HTMLchunkType.Text)
                                            {
                                                vacanciesRequarementsUz = ClearString(HttpUtility.HtmlDecode(tChunk.oHTML));
                                            }
                                            break;
                                        case "Vacancies_information_ru":
                                            tChunk = _parser.ParseNext();

                                            if (tChunk.oType == HTMLchunkType.Text)
                                            {
                                                vacanciesInformationRu = ClearString(HttpUtility.HtmlDecode(tChunk.oHTML));
                                            }
                                            break;
                                        case "Vacancies_information_uz":
                                            tChunk = _parser.ParseNext();

                                            if (tChunk.oType == HTMLchunkType.Text)
                                            {
                                                vacanciesInformationUz = ClearString(HttpUtility.HtmlDecode(tChunk.oHTML));
                                            }
                                            break;
                                        default:
                                            continue;
                                    }
                                    break;
                                default:
                                    continue;
                            }

                            break;
                        case HTMLchunkType.CloseTag:
                            continue;
                        case HTMLchunkType.Text:
                            continue;
                        case HTMLchunkType.Comment:
                            continue;
                        case HTMLchunkType.Script:
                            continue;
                    }
                }

                var vacancy = new Vacancy(HttpUtility.HtmlDecode(vacanciesNameRu)
                    , HttpUtility.HtmlDecode(vacanciesNameUz)
                    , Vacancy.CategoryIdFromOptionValue(vacanciesCategoryId)
                    , HttpUtility.HtmlDecode(vacanciesSalary)
                    , Vacancy.EmploymentIdFromOptionValue(vacanciesEmployment)
                    , Vacancy.GenderFromOptionValue(vacanciesGender)
                    , Vacancy.ExperienceIdFromOptionValue(vacanciesExpPeriod)
                    , Vacancy.EducationIdFromOptionValue(vacanciesEducation)
                    , HttpUtility.HtmlDecode(vacanciesExpDate)
                    , Vacancy.StatusIdFromValue(vacanciesStatus)
                    , HttpUtility.HtmlDecode(vacanciesDepartmentRu)
                    , HttpUtility.HtmlDecode(vacanciesDepartmentUz)
                    , HttpUtility.HtmlDecode(vacanciesSpecializationRu)
                    , HttpUtility.HtmlDecode(vacanciesSpecializationUz)
                    , HttpUtility.HtmlDecode(vacanciesRequarementsRu)
                    , HttpUtility.HtmlDecode(vacanciesRequarementsUz)
                    , HttpUtility.HtmlDecode(vacanciesInformationRu)
                    , HttpUtility.HtmlDecode(vacanciesInformationUz)
                    )
                {
                    Id = pVacId.ToString()
                };

                return vacancy;
            }

            return null;
        }

        /// <summary>
        /// Изменение статуса вакансии
        /// </summary>
        /// <param name="id">Идентификатор вакансии</param>
        /// <param name="status">Статус вакансии (закрытая/открытая)</param>
        /// <returns>При успешном изменении статуса возвратит <b>true</b></returns>
        public bool SetVacancyStatus(int id, VacancyStatus status)
        {
            if (!IsLogged || id <= 0)
                return false;

            var v = GetVacancy(id);

            if (v == null)
                return false;

            v.Status = status;

            return EditVacancy(id, v);
        }

        /// <summary>
        /// Получение списка открытых (актуальных) вакансий
        /// </summary>
        /// <returns></returns>
        public List<VacancyListItem> GetActualVacancies()
        {
            //bIsLogged = true;

            if (IsLogged)
            {
                var bytes = _http.GetBytes(StrOpenedUrl);

                var page = string.Empty;

                if (bytes != null)
                 page = Encoding.UTF8.GetString(bytes);

                var vacs = new List<VacancyListItem>();

                // Проверка количество страниц с вакансиями
                if (page.IndexOf("<div class=\"pagination\">", StringComparison.InvariantCultureIgnoreCase) > 0)
                {
                    var strNextPageUrl = string.Empty;

                    while (true)
                    {
                        var lastPage = page.IndexOf("<li class=\"next\">", StringComparison.InvariantCultureIgnoreCase) <= 0;

                        _parser.Init(Encoding.UTF8.GetBytes(page));
                        _parser.SetEncoding(Encoding.UTF8);

                        HTMLchunk chunk;

                        while ((chunk = _parser.ParseNext()) != null)
                        {
                            switch (chunk.sTag)
                            {
                                case "tbody":
                                    HTMLchunk trChunk;
                                    while ((trChunk = _parser.ParseNextTag()) != null && trChunk.sTag == "tr")
                                    {
                                        // VAC ID
                                        var tdChunk = _parser.ParseNext();

                                        var vacancyId = tdChunk.oHTML;

                                        _parser.ParseNext(); // td close

                                        // VAC DESC
                                        _parser.ParseNextTag(); // td open
                                        tdChunk = _parser.ParseNext();

                                        var vacancyDescription = tdChunk.oHTML;

                                        _parser.ParseNextTag(); // td close

                                        _parser.ParseNextTag(); // td open
                                        _parser.ParseNextTag(); // a open
                                        _parser.ParseNextTag(); // a close
                                        _parser.ParseNextTag(); // td close

                                        _parser.ParseNextTag(); // tr close

                                        vacs.Add(new VacancyListItem(int.Parse(vacancyId), vacancyDescription));
                                    }
                                    break;
                                case "ul":
                                    if (chunk.GetParamValue("id") == "yw0")
                                    {
                                        HTMLchunk liChunk;
                                        while ((liChunk = _parser.ParseNextTag()) != null && liChunk.sTag == "li")
                                        {
                                            if (liChunk.GetParamValue("class") == "next")
                                            {
                                                var aChunk = _parser.ParseNextTag();

                                                if (aChunk.sTag == "a")
                                                    strNextPageUrl = aChunk.GetParamValue("href");

                                                if (strNextPageUrl != "")
                                                    strNextPageUrl = StrVacantUrl + strNextPageUrl;

                                                _parser.ParseNextTag();
                                            }
                                            else
                                            {
                                                _parser.ParseNextTag();
                                                _parser.ParseNextTag();
                                            }

                                            _parser.ParseNextTag();
                                        }
                                    }

                                    break;
                            }
                        }

                        if (lastPage || (strNextPageUrl == ""))
                            break;

                        //page = http.GetUrl(strNextPageUrl);
                        page = Encoding.UTF8.GetString(_http.GetBytes(strNextPageUrl));
                    }
                }
                else
                {
                    _parser.Init(Encoding.UTF8.GetBytes(page));
                    _parser.SetEncoding(Encoding.UTF8);

                    HTMLchunk chunk;

                    while ((chunk = _parser.ParseNext()) != null)
                    {
                        switch (chunk.sTag)
                        {
                            case "tbody":
                                HTMLchunk trChunk;
                                while ((trChunk = _parser.ParseNextTag()) != null && trChunk.sTag == "tr")
                                {
                                    // VAC ID
                                    _parser.ParseNextTag(); // td open
                                    var tdChunk = _parser.ParseNext();

                                    var vacancyId = tdChunk.oHTML;

                                    _parser.ParseNext(); // td close

                                    // VAC DESC
                                    _parser.ParseNextTag(); // td open
                                    tdChunk = _parser.ParseNext();

                                    var vacancyDescription = tdChunk.oHTML;

                                    _parser.ParseNextTag(); // td close

                                    _parser.ParseNextTag(); // td open
                                    _parser.ParseNextTag(); // a open
                                    _parser.ParseNextTag(); // a close
                                    _parser.ParseNextTag(); // td close

                                    _parser.ParseNextTag(); // tr close

                                    vacs.Add(new VacancyListItem(int.Parse(vacancyId), vacancyDescription));
                                }
                                break;
                        }
                    }
                }

                return vacs;
            }
            else
                return null;
        }

        /// <summary>
        /// Получение списка закрытых (не актуальных) вакансий
        /// </summary>
        /// <returns></returns>
        public List<VacancyListItem> GetClosedVacancies()
        {
            //bIsLogged = true;

            if (IsLogged)
            {
                //string page = http.GetUrl(strClosedUrl);
                var bytes = _http.GetBytes(StrClosedUrl);
                var page = string.Empty;

                if (bytes != null)
                    page = Encoding.UTF8.GetString(bytes);

                var vacs = new List<VacancyListItem>();

                // Проверка количество страниц с вакансиями
                if (page.IndexOf("<div class=\"pagination\">", StringComparison.InvariantCultureIgnoreCase) > 0)
                {
                    var strNextPageUrl = string.Empty;

                    while (true)
                    {
                        var lastPage = page.IndexOf("<li class=\"next\">", StringComparison.InvariantCultureIgnoreCase) <= 0;

                        _parser.Init(Encoding.UTF8.GetBytes(page));
                        _parser.SetEncoding(Encoding.UTF8);

                        HTMLchunk chunk;

                        while ((chunk = _parser.ParseNext()) != null)
                        {
                            switch (chunk.sTag)
                            {
                                case "tbody":
                                    HTMLchunk trChunk;
                                    while ((trChunk = _parser.ParseNextTag()) != null && trChunk.sTag=="tr") 
                                    {
                                        // VAC ID
                                        _parser.ParseNextTag(); // td open
                                        //td_chunk = parser.ParseNext(); 
                                        var tdChunk = _parser.ParseNext();
                                        var vacancyId = tdChunk.oHTML;
                                        _parser.ParseNext(); // td close

                                        // VAC DESC
                                        _parser.ParseNextTag(); // td open
                                        tdChunk = _parser.ParseNext();
                                        var vacancyDescription = tdChunk.oHTML;
                                        _parser.ParseNextTag(); // td close

                                        _parser.ParseNextTag(); // td open
                                        _parser.ParseNextTag(); // a open
                                        _parser.ParseNextTag(); // a close
                                        _parser.ParseNextTag(); // td close

                                        _parser.ParseNextTag(); // tr close

                                        vacs.Add(new VacancyListItem(int.Parse(vacancyId), vacancyDescription));
                                    }
                                    break;
                                case "ul":
                                    if (chunk.GetParamValue("id") == "yw0")
                                    {
                                        HTMLchunk liChunk;
                                        while ((liChunk = _parser.ParseNextTag()) != null && liChunk.sTag == "li")
                                        {
                                            if (liChunk.GetParamValue("class") == "next")
                                            {
                                                var aChunk = _parser.ParseNextTag();

                                                if (aChunk.sTag == "a")
                                                    strNextPageUrl = aChunk.GetParamValue("href");

                                                if (strNextPageUrl != "")
                                                    strNextPageUrl = StrVacantUrl + strNextPageUrl;

                                                _parser.ParseNextTag();
                                            }
                                            else
                                            {
                                                _parser.ParseNextTag();
                                                _parser.ParseNextTag();
                                            }

                                            _parser.ParseNextTag();
                                        }
                                    }
                                    
                                    break;
                            }
                        }

                        if (lastPage || (strNextPageUrl == ""))
                            break;

                        //page = http.GetUrl(strNextPageUrl);
                        page = Encoding.UTF8.GetString(_http.GetBytes(strNextPageUrl));
                    }
                }
                else
                {
                    _parser.Init(Encoding.UTF8.GetBytes(page));
                    _parser.SetEncoding(Encoding.UTF8);

                    HTMLchunk chunk;

                    while ((chunk = _parser.ParseNext()) != null)
                    {
                        switch (chunk.sTag)
                        {
                            case "tbody":
                                HTMLchunk trChunk;
                                while ((trChunk = _parser.ParseNextTag()) != null && trChunk.sTag == "tr")
                                {
                                    // VAC ID
                                    _parser.ParseNextTag(); // td open
                                    var tdChunk = _parser.ParseNext();

                                    var vacancyId = tdChunk.oHTML;

                                    _parser.ParseNext(); // td close

                                    // VAC DESC
                                    _parser.ParseNextTag(); // td open

                                    tdChunk = _parser.ParseNext();

                                    var vacancyDescription = tdChunk.oHTML;

                                    _parser.ParseNextTag(); // td close

                                    _parser.ParseNextTag(); // td open
                                    _parser.ParseNextTag(); // a open
                                    _parser.ParseNextTag(); // a close
                                    _parser.ParseNextTag(); // td close

                                    _parser.ParseNextTag(); // tr close

                                    vacs.Add(new VacancyListItem(int.Parse(vacancyId), vacancyDescription));
                                }
                                break;
                        }
                    }
                }

                return vacs;
            }

            return null;
        }

        /// <summary>
        /// Получить список "полученных" резюме
        /// </summary>
        /// <returns></returns>
        public List<ResumeItem> GetReceivedResumes(Langugage langugage)
        {
            throw new NotImplementedException("Method GetReceivedResumes is not implemented");
        }

        /// <summary>
        /// Получить список "принятых" резюме
        /// </summary>
        /// <returns></returns>
        public List<ResumeItem> GetApprovedResumes(Langugage langugage)
        {
            throw new NotImplementedException("Method GetApprovedResumes is not implemented");
        }

        /// <summary>
        /// Получить список "рассмотренных" резюме
        /// </summary>
        /// <returns></returns>
        public List<ResumeItem> GetProcessedResumes(Langugage langugage)
        {
            throw new NotImplementedException("Method GetProcessedResumes is not implemented");
        }

        /// <summary>
        /// Получить список "зарезервированных" резюме
        /// </summary>
        /// <returns></returns>
        public List<ResumeItem> GetReservedResumes(Langugage langugage)
        {
            throw new NotImplementedException("Method GetReservedResumes is not implemented");
        }

        /// <summary>
        /// Метод обращяется к серверу для генерации нового изображения с капчей
        /// </summary>
        /// <returns>При успешном вызове возвратит последовательность байтов PNG-изображения капчи, в другом случае <value>null</value></returns>
        public byte[] GetCapcha()
        {
            if (IsLogged)
            {
                var rnd = new Random(DateTime.Now.Millisecond);

                var newCapcthaUrl = StrRefreshCaptchaUrl + rnd.Next();

                //string newCaptchaResponse = http.GetUrl(newCapcthaUrl);
                var newCaptchaResponse = string.Empty;
                var bytes = _http.GetBytes(newCapcthaUrl);

                if (bytes != null)
                    newCaptchaResponse = Encoding.UTF8.GetString(bytes);

                var parsePos = newCaptchaResponse.IndexOf("v=", StringComparison.InvariantCultureIgnoreCase);

                if (parsePos > 0)
                {
                    var newCaptchaId = newCaptchaResponse.Substring(parsePos+2);

                    var ret = _http.GetBytes(StrCaptchaImageUrl + newCaptchaId);

                    return ret;
                }
                else
                {
                    return null;
                }
            }
            else
                return null;
        }

        /// <summary>
        /// Присвоить текст капчи перед передачей запроса на сервер
        /// </summary>
        /// <param name="captchaText"></param>
        public void SetCaptchaText(string captchaText)
        {
            _strCaptchaText = captchaText;
        }
    }
}
