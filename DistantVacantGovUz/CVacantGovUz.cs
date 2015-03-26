using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Collections.Specialized;
using System.Net;
using System.Threading;
using System.Web;
//using HtmlAgilityPack;
using Majestic12;

namespace DistantVacantGovUz
{
    /// <summary>
    /// Элемент списка вакансий (для работы со актуальными/закрытыми списками
    /// вакансий, возвращаемым vacant.gov.uz)
    /// </summary>
    public class CVacancyListElement
    {
        /// <summary>
        /// Номер вакансии
        /// </summary>
        public int iID;
        /// <summary>
        /// Наименование вакансии
        /// </summary>
        public string strDescription;

        public CVacancyListElement(int p_iID, string p_strDescription)
        {
            this.iID = p_iID;
            this.strDescription = p_strDescription;
        }
    }

    /// <summary>
    /// Класс для работы с системой публикации вакансий vacant.gov.uz
    /// </summary>
    public class CVacantGovUz
    {
        /// <summary>
        /// Класс для работы с HTTP-запросами
        /// </summary>
        private HttpRequest http;

        /// <summary>
        /// Класс для парсинга HTML-данных
        /// </summary>
        private HTMLparser parser;

        //private string strIDUzLoginUrl = @"http://www.id.uz/users/login/authenticate?token=";
        //private string strVacantGovUzLoginUrl = @"http://vacant.gov.uz/site/login";
        private string strLoginUrl;
        private const string strLogoutUrl = @"http://vacant.gov.uz/ru/site/logout";
        private const string strVacantUrl = @"http://vacant.gov.uz";
        private const string strOpenedUrl = @"http://vacant.gov.uz/ru/vacancies/admin";
        private const string strClosedUrl = @"http://vacant.gov.uz/ru/vacancies/Cadmin";
        private const string strCreateUrl = @"http://vacant.gov.uz/ru/vacancies/create";
        private const string _strReceivedUrl = @"http://vacant.gov.uz/uz/request/received";
        private const string strReceivedUrl = @"http://vacant.gov.uz/ru/request/received";
        private const string strApprovedUrl = @"http://vacant.gov.uz/ru/request/approved";
        private const string strProcessedUrl = @"http://vacant.gov.uz/ru/request/processed";
        private const string strReservedUrl = @"http://vacant.gov.uz/ru/request/reserved";
        private const string strAddVacancyUrl = @"http://vacant.gov.uz/ru/vacancies/create";
        private const string strEditVacancyUrl = @"http://vacant.gov.uz/ru/vacancies/update";
        private const string strRefreshCaptchaUrl = @"http://vacant.gov.uz/ru/vacancies/captcha?refresh=1&_=";
        private const string strCaptchaImageUrl = @"http://vacant.gov.uz/ru/vacancies/captcha?v=";
        
        public string strVacancyUserName = "";

        private bool bIsLogged = false;

        /// <summary>
        /// Свойство для установки и проверки статуса
        /// подключения к vacant.gov.uz
        /// </summary>
        public bool IsLogged
        {
            get
            {
                return this.bIsLogged;
            }
            set
            {
                bIsLogged = value;
            }
        }

        private bool bUseHttpProxy = false;
        private string strProxyHost;
        private string strProxyUserName;
        private string strProxyPassword;

        private string strCaptchaText = "";

        /// <summary>
        /// Удаление HTML-тегов в строке
        /// </summary>
        /// <param name="p_strInput">Строка для анализа</param>
        /// <returns>Возрватит строку без HTML-тегов</returns>
        private string StripHtmlTags(string p_strInput)
        {
            if (p_strInput.Length == 0)
                return "";

            char[] array = new char[p_strInput.Length]; 
            int arrayIndex = 0; 
            bool inside = false;

            for (int i = 0; i < p_strInput.Length; i++) 
            {
                char let = p_strInput[i]; 
                
                if (let == '<') 
                { 
                    inside = true; 
                    continue; 
                } 
                
                if (let == '>') 
                { 
                    inside = false; 
                    continue; 
                } 
                
                if (!inside) 
                { 
                    array[arrayIndex] = let; 
                    arrayIndex++; 
                } 
            } 
            
            return new string(array, 0, arrayIndex);
        }

        /// <summary>
        /// Очистка строки от лишних пробелов и HTML-тэгов
        /// </summary>
        /// <param name="p_srcString">Входящая строка для анализа</param>
        /// <returns>Возратит "очищенную" строку</returns>
        private string ClearString(string p_srcString)
        {
            return StripHtmlTags(p_srcString).Trim().Replace("\r\n\r\n", "\r\n").Replace("\t", "");
        }

        /// <summary>
        /// Использование HTTP-прокси
        /// </summary>
        public bool UseHttpProxy
        {
            get
            {
                return this.bUseHttpProxy;
            }
            set
            {
                this.bUseHttpProxy = value;

                if (this.bUseHttpProxy)
                {
                    http.SetProxy(this.strProxyHost, this.strProxyUserName, this.strProxyPassword);

                    /*if ((strProxyUserName != null) && (strProxyUserName.Trim() != ""))
                    {
                        // set proxy credentials
                    }*/
                }
                else
                {
                    http.UnsetProxy();
                }
            }
        }

        private string strVacUserName;
        private string strVacPassword;

        /// <summary>
        /// Конструктор класса CVacantGovUz
        /// </summary>
        /// <param name="p_Browser">Объект WebBrowser</param>
        public CVacantGovUz()
        {
            http = new HttpRequest();

            parser = new HTMLparser();

            // parser parameters
            parser.bAutoKeepComments = false;
            parser.bAutoKeepScripts = false;
            parser.bAutoMarkClosedTagsWithParamsAsOpen = true;
            parser.bCompressWhiteSpaceBeforeTag = true;
            parser.bKeepRawHTML = false;
            parser.bDecodeEntities = true;
            parser.bDecodeMiniEntities = true;
            parser.InitMiniEntities();
            
            parser.SetEncoding(Encoding.UTF8);
        }

        /// <summary>
        /// Установка значений прокси-сервера
        /// </summary>
        /// <param name="p_strProxyHost">Адрес прокси-сервера</param>
        /// <param name="p_strProxyUserName">Пользователь</param>
        /// <param name="p_strProxyPassword">Пароль</param>
        public void SetHttpProxy(string p_strProxyHost, string p_strProxyUserName, string p_strProxyPassword)
        {
            this.strProxyHost = p_strProxyHost;
            this.strProxyUserName = p_strProxyUserName;
            this.strProxyPassword = p_strProxyPassword;
        }

        /// <summary>
        /// Метод входа в систему vacant.gov.uz
        /// </summary>
        /// <param name="p_strUserName">имя пользователя</param>
        /// <param name="p_strPassword">пароль пользователя</param>
        /// <returns>При успешном входе в систему возвращает результат true</returns>
        public bool Login(string p_strUserName, string p_strPassword)
        {
            bIsLogged = false;

            if ((p_strPassword == "") || (p_strUserName == ""))
                return bIsLogged;

            this.strVacUserName = p_strUserName;
            this.strVacPassword = p_strPassword;

            // FIXED BUG: url corrected
            strLoginUrl = @"https://www.id.uz/openid/authenticate?openid.return_to=http%3A%2F%2Fvacant.gov.uz%2Fsite%2Flogin%3Fopenid.claimed_id%3Dhttp%3A%2F%2F" + Uri.EscapeDataString(strVacUserName) + ".id.uz%2F&openid.mode=checkid_setup&openid.identity=https%3A%2F%2F" + Uri.EscapeDataString(strVacUserName) + ".id.uz%2F&openid.trust_root=http%3A%2F%2Fvacant.gov.uz&openid.ns.sreg=http%3A%2F%2Fopenid.net%2Fextensions%2Fsreg%2F1.1&openid.sreg.required=nickname%2Cemail%2Cphone%2Cfullname%2Cpublic_id%2Cstatus";

            string post_data = @"password=" + Uri.EscapeDataString(this.strVacPassword);

            string page = http.GetUrl(strLoginUrl, RequestMethod.POST, post_data);

            if (page.Contains(@"/uz/site/logout"))
            {
                string strDbg;

                int iUserNameStart = page.IndexOf(@", hurmatli") + 11;
                
                strDbg = page.Substring(iUserNameStart);

                int iUserNameLength = page.IndexOf(@"<", iUserNameStart) - iUserNameStart;

                strVacancyUserName = page.Substring(iUserNameStart, iUserNameLength).Trim();

                bIsLogged = true;
            }
            else
            {
                bIsLogged = false;
            }

            return bIsLogged;
        }

        /// <summary>
        /// Выход из системы vacant.gov.uz
        /// </summary>
        public void Logout()
        {
            if (bIsLogged)
                http.GetUrl(strLogoutUrl);

            bIsLogged = false;
        }

        /// <summary>
        /// Добавление новой вакансии
        /// </summary>
        /// <returns>При успешном добавлении возвратит <b>true</b></returns>
        public bool AddVacancy(CVacancy p_Vacancy)
        {
            if (bIsLogged)
            {
                //string post_data = @"Vacancies[name_ru]=#VACANCIES_NAME_RU#&Vacancies[name_uz]=#VACANCIES_NAME_UZ#&Vacancies[category_id]=#VACANCIES_CATEGORY_ID#&Vacancies[salary]=#VACANCIES_SALARY#&Vacancies[employment]=#VACANCIES_EMPLOYMENT#&Vacancies[gender]=#VACANCIES_GENDER#&Vacancies[exp_period]=#VACANCIES_EXP_PERIOD#&Vacancies[education]=#VACANCIES_EDUCATION#&Vacancies[exp_date]=#VACANCIES_EXP_DATE#&Vacancies[status]=#VACANCIES_STATUS#&Vacancies[department_ru]=#VACANCIES_DEPARTMENT_RU#&Vacancies[specialization_ru]=#VACANCIES_SPECIALIZATION_RU#&Vacancies[requarements_ru]=#VACANCIES_REQUAREMENTS_RU#&Vacancies[information_ru]=#VACANCIES_INFORMATION_RU#&Vacancies[department_uz]=#VACANCIES_DEPARTMENT_UZ#&Vacancies[specialization_uz]=#VACANCIES_SPECIALIZATION_UZ#&Vacancies[requarements_uz]=#VACANCIES_REQUAREMENTS_UZ#&Vacancies[information_uz]=#VACANCIES_INFORMATION_UZ#";
                string post_data = "";
                post_data += "Vacancies[category_id]=#VACANCIES_CATEGORY_ID#";
                post_data += "&Vacancies[department_ru]=#VACANCIES_DEPARTMENT_RU#";
                post_data += "&Vacancies[department_uz]=#VACANCIES_DEPARTMENT_UZ#";
                post_data += "&Vacancies[education]=#VACANCIES_EDUCATION#";
                post_data += "&Vacancies[employment]=#VACANCIES_EMPLOYMENT#";
                post_data += "&Vacancies[exp_date]=#VACANCIES_EXP_DATE#";
                post_data += "&Vacancies[exp_period]=#VACANCIES_EXP_PERIOD#";
                post_data += "&Vacancies[gender]=#VACANCIES_GENDER#";
                post_data += "&Vacancies[information_ru]=#VACANCIES_INFORMATION_RU#";
                post_data += "&Vacancies[information_uz]=#VACANCIES_INFORMATION_UZ#";
                post_data += "&Vacancies[name_ru]=#VACANCIES_NAME_RU#";
                post_data += "&Vacancies[name_uz]=#VACANCIES_NAME_UZ#";
                post_data += "&Vacancies[requarements_ru]=#VACANCIES_REQUAREMENTS_RU#";
                post_data += "&Vacancies[requarements_uz]=#VACANCIES_REQUAREMENTS_UZ#";
                post_data += "&Vacancies[salary]=#VACANCIES_SALARY#";
                post_data += "&Vacancies[specialization_ru]=#VACANCIES_SPECIALIZATION_RU#";
                post_data += "&Vacancies[specialization_uz]=#VACANCIES_SPECIALIZATION_UZ#";
                post_data += "&Vacancies[status]=#VACANCIES_STATUS#";
                // captcha
                post_data += "&Vacancies[verifyCode]=#VACANCIES_CAPTCHA#";

                post_data = post_data.Replace(@"#VACANCIES_NAME_RU#", Uri.EscapeDataString(p_Vacancy.strDescriptionRU));
                post_data = post_data.Replace(@"#VACANCIES_NAME_UZ#", Uri.EscapeDataString(p_Vacancy.strDescriptionUZ));
                post_data = post_data.Replace(@"#VACANCIES_CATEGORY_ID#", CVacancy.CategoryId(p_Vacancy.vacCategory).ToString());
                post_data = post_data.Replace(@"#VACANCIES_SALARY#", Uri.EscapeDataString(p_Vacancy.strSalary));
                post_data = post_data.Replace(@"#VACANCIES_EMPLOYMENT#", CVacancy.EmploymentId(p_Vacancy.vacEmployment));
                post_data = post_data.Replace(@"#VACANCIES_GENDER#", CVacancy.GenderId(p_Vacancy.vacGender));
                post_data = post_data.Replace(@"#VACANCIES_EXP_PERIOD#", CVacancy.ExperienceId(p_Vacancy.vacExperience));
                post_data = post_data.Replace(@"#VACANCIES_EDUCATION#", CVacancy.EducationId(p_Vacancy.vacEducaton));
                post_data = post_data.Replace(@"#VACANCIES_EXP_DATE#", Uri.EscapeDataString(p_Vacancy.strExpireDate));
                post_data = post_data.Replace(@"#VACANCIES_STATUS#", CVacancy.StatusId(p_Vacancy.vacStatus));
                post_data = post_data.Replace(@"#VACANCIES_DEPARTMENT_RU#", Uri.EscapeDataString(p_Vacancy.strDepartmentRU));
                post_data = post_data.Replace(@"#VACANCIES_SPECIALIZATION_RU#", Uri.EscapeDataString(p_Vacancy.strSpecializationRU));
                post_data = post_data.Replace(@"#VACANCIES_REQUAREMENTS_RU#", Uri.EscapeDataString(p_Vacancy.strRequirementsRU));
                post_data = post_data.Replace(@"#VACANCIES_INFORMATION_RU#", Uri.EscapeDataString(p_Vacancy.strInformationRU));
                post_data = post_data.Replace(@"#VACANCIES_DEPARTMENT_UZ#", Uri.EscapeDataString(p_Vacancy.strDepartmentUZ));
                post_data = post_data.Replace(@"#VACANCIES_SPECIALIZATION_UZ#", Uri.EscapeDataString(p_Vacancy.strSpecializationUZ));
                post_data = post_data.Replace(@"#VACANCIES_REQUAREMENTS_UZ#", Uri.EscapeDataString(p_Vacancy.strRequirementsUZ));
                post_data = post_data.Replace(@"#VACANCIES_INFORMATION_UZ#", Uri.EscapeDataString(p_Vacancy.strInformationUZ));
                post_data = post_data.Replace(@"#VACANCIES_CAPTCHA#", this.strCaptchaText);

                string page = http.GetUrl(strAddVacancyUrl, RequestMethod.POST, post_data);

                string str_search = "a class=\"brand pull-right\" href=\"/ru/vacancies/admin/";

                int vac_id_str_index = page.IndexOf(str_search);

                if (vac_id_str_index > 0)
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        /// <summary>
        /// Редактирование вакансии
        /// </summary>
        /// <returns>При успешном редактировании возвратит <b>true</b></returns>
        public bool EditVacancy(int p_vac_id, CVacancy p_Vacancy)
        {
            if (bIsLogged)
            {
                string post_data = "";
                post_data += @"Vacancies[name_ru]=#VACANCIES_NAME_RU#";
                post_data += "&Vacancies[name_uz]=#VACANCIES_NAME_UZ#";
                post_data += "&Vacancies[category_id]=#VACANCIES_CATEGORY_ID#";
                post_data += "&Vacancies[salary]=#VACANCIES_SALARY#";
                post_data += "&Vacancies[employment]=#VACANCIES_EMPLOYMENT#";
                post_data += "&Vacancies[gender]=#VACANCIES_GENDER#";
                post_data += "&Vacancies[exp_period]=#VACANCIES_EXP_PERIOD#";
                post_data += "&Vacancies[education]=#VACANCIES_EDUCATION#";
                post_data += "&Vacancies[exp_date]=#VACANCIES_EXP_DATE#";
                post_data += "&Vacancies[status]=#VACANCIES_STATUS#";
                post_data += "&Vacancies[department_ru]=#VACANCIES_DEPARTMENT_RU#";
                post_data += "&Vacancies[specialization_ru]=#VACANCIES_SPECIALIZATION_RU#";
                post_data += "&Vacancies[requarements_ru]=#VACANCIES_REQUAREMENTS_RU#";
                post_data += "&Vacancies[information_ru]=#VACANCIES_INFORMATION_RU#";
                post_data += "&Vacancies[department_uz]=#VACANCIES_DEPARTMENT_UZ#";
                post_data += "&Vacancies[specialization_uz]=#VACANCIES_SPECIALIZATION_UZ#";
                post_data += "&Vacancies[requarements_uz]=#VACANCIES_REQUAREMENTS_UZ#";
                post_data += "&Vacancies[information_uz]=#VACANCIES_INFORMATION_UZ#";
                // captcha
                post_data += "&Vacancies[verifyCode]=#VACANCIES_CAPTCHA#";

                post_data = post_data.Replace(@"#VACANCIES_NAME_RU#", Uri.EscapeDataString(p_Vacancy.strDescriptionRU));
                post_data = post_data.Replace(@"#VACANCIES_NAME_UZ#", Uri.EscapeDataString(p_Vacancy.strDescriptionUZ));
                post_data = post_data.Replace(@"#VACANCIES_CATEGORY_ID#", CVacancy.CategoryId(p_Vacancy.vacCategory).ToString());
                post_data = post_data.Replace(@"#VACANCIES_SALARY#", Uri.EscapeDataString(p_Vacancy.strSalary));
                post_data = post_data.Replace(@"#VACANCIES_EMPLOYMENT#", CVacancy.EmploymentId(p_Vacancy.vacEmployment));
                post_data = post_data.Replace(@"#VACANCIES_GENDER#", CVacancy.GenderId(p_Vacancy.vacGender));
                post_data = post_data.Replace(@"#VACANCIES_EXP_PERIOD#", CVacancy.ExperienceId(p_Vacancy.vacExperience));
                post_data = post_data.Replace(@"#VACANCIES_EDUCATION#", CVacancy.EducationId(p_Vacancy.vacEducaton));
                post_data = post_data.Replace(@"#VACANCIES_EXP_DATE#", Uri.EscapeDataString(p_Vacancy.strExpireDate));
                post_data = post_data.Replace(@"#VACANCIES_STATUS#", CVacancy.StatusId(p_Vacancy.vacStatus));
                post_data = post_data.Replace(@"#VACANCIES_DEPARTMENT_RU#", Uri.EscapeDataString(p_Vacancy.strDepartmentRU));
                post_data = post_data.Replace(@"#VACANCIES_SPECIALIZATION_RU#", Uri.EscapeDataString(p_Vacancy.strSpecializationRU));
                post_data = post_data.Replace(@"#VACANCIES_REQUAREMENTS_RU#", Uri.EscapeDataString(p_Vacancy.strRequirementsRU));
                post_data = post_data.Replace(@"#VACANCIES_INFORMATION_RU#", Uri.EscapeDataString(p_Vacancy.strInformationRU));
                post_data = post_data.Replace(@"#VACANCIES_DEPARTMENT_UZ#", Uri.EscapeDataString(p_Vacancy.strDepartmentUZ));
                post_data = post_data.Replace(@"#VACANCIES_SPECIALIZATION_UZ#", Uri.EscapeDataString(p_Vacancy.strSpecializationUZ));
                post_data = post_data.Replace(@"#VACANCIES_REQUAREMENTS_UZ#", Uri.EscapeDataString(p_Vacancy.strRequirementsUZ));
                post_data = post_data.Replace(@"#VACANCIES_INFORMATION_UZ#", Uri.EscapeDataString(p_Vacancy.strInformationUZ));
                post_data = post_data.Replace(@"#VACANCIES_CAPTCHA#", this.strCaptchaText);

                string page = http.GetUrl(strEditVacancyUrl + @"/" + p_vac_id.ToString(), RequestMethod.POST, post_data);

                string str_search = "a class=\"brand pull-right\" href=\"/ru/vacancies/admin/";

                int vac_id_str_index = page.IndexOf(str_search);

                if (vac_id_str_index > 0)
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        public CVacancy GetVacancy(int p_vac_id)
        {
            bIsLogged = true;

            if (bIsLogged)
            {
                CVacancy v = null;

                // test
                string page = http.GetUrl(strEditVacancyUrl + "/" + p_vac_id.ToString());

                if (page.IndexOf(@"Редактировать вакансию") > 0)
                //if (true)
                {
                    parser.Init(Encoding.UTF8.GetBytes(page));
                    //parser.Init(htmlData);
                    parser.SetEncoding(Encoding.UTF8);

                    HTMLchunk chunk = null;
                    HTMLchunk o_chunk = null;
                    HTMLchunk t_chunk = null;

                    // input box
                    string Vacancies_name_ru = "";
                    string Vacancies_name_uz = "";
                    string Vacancies_salary = "";
                    string Vacancies_exp_date = "";
                    string Vacancies_department_ru = "";
                    string Vacancies_department_uz = "";

                    // option
                    string Vacancies_category_id = "";
                    string Vacancies_employment = "";
                    string Vacancies_gender = "";
                    string Vacancies_exp_period = "";
                    string Vacancies_education = "";
                    string Vacancies_status = "";

                    // textarea
                    string Vacancies_specialization_ru = "";
                    string Vacancies_specialization_uz = "";
                    string Vacancies_requarements_ru = "";
                    string Vacancies_requarements_uz = "";
                    string Vacancies_information_ru = "";
                    string Vacancies_information_uz = "";

                    while ((chunk = parser.ParseNext()) != null)
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
                                                Vacancies_name_ru = chunk.GetParamValue("value");
                                                break;
                                            case "Vacancies_name_uz":
                                                Vacancies_name_uz = chunk.GetParamValue("value");
                                                break;
                                            case "Vacancies_salary":
                                                Vacancies_salary = chunk.GetParamValue("value");
                                                break;
                                            case "Vacancies_exp_date":
                                                Vacancies_exp_date = chunk.GetParamValue("value");
                                                break;
                                            case "Vacancies_department_ru":
                                                Vacancies_department_ru = chunk.GetParamValue("value");
                                                break;
                                            case "Vacancies_department_uz":
                                                Vacancies_department_uz = chunk.GetParamValue("value");
                                                break;
                                            default:
                                                continue;
                                        }
                                        break;
                                    case "select":
                                        switch (chunk.GetParamValue("id"))
                                        {
                                            case "Vacancies_category_id":
                                                while ((o_chunk = parser.ParseNextTag()).sTag == "option")
                                                {
                                                    if (o_chunk.GetParamValue("selected") == "selected")
                                                    {
                                                        Vacancies_category_id = o_chunk.GetParamValue("value");
                                                        break;
                                                    }
                                                }
                                                break;
                                            case "Vacancies_employment":
                                                while ((o_chunk = parser.ParseNextTag()).sTag == "option")
                                                {
                                                    if (o_chunk.GetParamValue("selected") == "selected")
                                                    {
                                                        Vacancies_employment = o_chunk.GetParamValue("value");
                                                        break;
                                                    }
                                                }
                                                break;
                                            case "Vacancies_gender":
                                                while ((o_chunk = parser.ParseNextTag()).sTag == "option")
                                                {
                                                    if (o_chunk.GetParamValue("selected") == "selected")
                                                    {
                                                        Vacancies_gender = o_chunk.GetParamValue("value");
                                                        break;
                                                    }
                                                }
                                                break;
                                            case "Vacancies_exp_period":
                                                while ((o_chunk = parser.ParseNextTag()).sTag == "option")
                                                {
                                                    if (o_chunk.GetParamValue("selected") == "selected")
                                                    {
                                                        Vacancies_exp_period = o_chunk.GetParamValue("value");
                                                        break;
                                                    }
                                                }
                                                break;
                                            case "Vacancies_education":
                                                while ((o_chunk = parser.ParseNextTag()).sTag == "option")
                                                {
                                                    if (o_chunk.GetParamValue("selected") == "selected")
                                                    {
                                                        Vacancies_education = o_chunk.GetParamValue("value");
                                                        break;
                                                    }
                                                }
                                                break;
                                            case "Vacancies_status":
                                                while ((o_chunk = parser.ParseNextTag()).sTag == "option")
                                                {
                                                    if (o_chunk.GetParamValue("selected") == "selected")
                                                    {
                                                        Vacancies_status = o_chunk.GetParamValue("value");
                                                        break;
                                                    }
                                                }
                                                break;
                                            default:
                                                continue;
                                        }
                                        break;
                                    case "textarea":
                                        switch (chunk.GetParamValue("id"))
                                        {
                                            case "Vacancies_specialization_ru":
                                                t_chunk = parser.ParseNext();

                                                if (t_chunk.oType == HTMLchunkType.Text)
                                                {
                                                    Vacancies_specialization_ru = t_chunk.oHTML;
                                                }
                                                break;
                                            case "Vacancies_specialization_uz":
                                                t_chunk = parser.ParseNext();

                                                if (t_chunk.oType == HTMLchunkType.Text)
                                                {
                                                    Vacancies_specialization_uz = t_chunk.oHTML;
                                                }
                                                break;
                                            case "Vacancies_requarements_ru":
                                                t_chunk = parser.ParseNext();

                                                if (t_chunk.oType == HTMLchunkType.Text)
                                                {
                                                    Vacancies_requarements_ru = t_chunk.oHTML;
                                                }
                                                break;
                                            case "Vacancies_requarements_uz":
                                                t_chunk = parser.ParseNext();

                                                if (t_chunk.oType == HTMLchunkType.Text)
                                                {
                                                    Vacancies_requarements_uz = t_chunk.oHTML;
                                                }
                                                break;
                                            case "Vacancies_information_ru":
                                                t_chunk = parser.ParseNext();

                                                if (t_chunk.oType == HTMLchunkType.Text)
                                                {
                                                    Vacancies_information_ru = t_chunk.oHTML;
                                                }
                                                break;
                                            case "Vacancies_information_uz":
                                                t_chunk = parser.ParseNext();

                                                if (t_chunk.oType == HTMLchunkType.Text)
                                                {
                                                    Vacancies_information_uz = t_chunk.oHTML;
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

                    v = new CVacancy(HttpUtility.HtmlDecode(Vacancies_name_ru)
                            , HttpUtility.HtmlDecode(Vacancies_name_uz)
                            , CVacancy.CategoryIdFromOptionValue(Vacancies_category_id)
                            , HttpUtility.HtmlDecode(Vacancies_salary)
                            , CVacancy.EmploymentIdFromOptionValue(Vacancies_employment)
                            , CVacancy.GenderFromOptionValue(Vacancies_gender)
                            , CVacancy.ExperienceIdFromOptionValue(Vacancies_exp_period)
                            , CVacancy.EducationIdFromOptionValue(Vacancies_education)
                            , HttpUtility.HtmlDecode(Vacancies_exp_date)
                            , CVacancy.StatusIdFromValue(Vacancies_status)
                            , HttpUtility.HtmlDecode(Vacancies_department_ru)
                            , HttpUtility.HtmlDecode(Vacancies_department_uz)
                            , HttpUtility.HtmlDecode(Vacancies_specialization_ru)
                            , HttpUtility.HtmlDecode(Vacancies_specialization_uz)
                            , HttpUtility.HtmlDecode(Vacancies_requarements_ru)
                            , HttpUtility.HtmlDecode(Vacancies_requarements_uz)
                            , HttpUtility.HtmlDecode(Vacancies_information_ru)
                            , HttpUtility.HtmlDecode(Vacancies_information_uz)
                            /*
                            , ClearString(HttpUtility.HtmlDecode(html.GetElementbyId(@"Vacancies_specialization_ru").InnerHtml))
                            , ClearString(HttpUtility.HtmlDecode(html.GetElementbyId(@"Vacancies_specialization_uz").InnerHtml))
                            , ClearString(HttpUtility.HtmlDecode(html.GetElementbyId(@"Vacancies_requarements_ru").InnerHtml))
                            , ClearString(HttpUtility.HtmlDecode(html.GetElementbyId(@"Vacancies_requarements_uz").InnerHtml))
                            , ClearString(HttpUtility.HtmlDecode(html.GetElementbyId(@"Vacancies_information_ru").InnerHtml))
                            , ClearString(HttpUtility.HtmlDecode(html.GetElementbyId(@"Vacancies_information_uz").InnerHtml))
                             * */
                        );

                    v.strPortalVacID = p_vac_id.ToString();

                    return v;
                }
                else
                    return null;
            }

            return null;
        }

        /// <summary>
        /// Изменение статуса вакансии
        /// </summary>
        /// <param name="p_iVacancyID">Идентификатор вакансии</param>
        /// <param name="p_Status">Статус вакансии (закрытая/открытая)</param>
        /// <returns>При успешном изменении статуса возвратит <b>true</b></returns>
        public bool SetVacancyStatus(int p_iVacancyID, VACANCY_STATUS p_vacStatus)
        {
            if (bIsLogged)
            {
                if (p_iVacancyID > 0)
                {
                    CVacancy v = GetVacancy(p_iVacancyID);

                    if (v != null)
                    {
                        v.vacStatus = p_vacStatus;
                        return EditVacancy(p_iVacancyID, v); ;
                    }
                    else
                    {
                        return false;
                    }
                }

                return false;
            }
            else
                return false;
        }

        /// <summary>
        /// Получение списка открытых (актуальных) вакансий
        /// </summary>
        /// <returns></returns>
        public List<CVacancyListElement> GetActualVacancies()
        {
            //bIsLogged = true;

            if (bIsLogged)
            {
                List<CVacancyListElement> vacs = null;

                string page = http.GetUrl(strOpenedUrl);
                //string page = null;

                /*TextReader reader;
                using (reader = new StreamReader(Program.GetApplicationDirectory() + "\\" + "closed.htm", Encoding.UTF8))
                {
                    try
                    {
                        page = reader.ReadToEnd();
                    }
                    catch (Exception ex)
                    {
                        page = "";
                    }
                }*/

                vacs = new List<CVacancyListElement>();

                // Проверка количество страниц с вакансиями
                if (page.IndexOf("<div class=\"pagination\">") > 0)
                {
                    string strNextPageUrl = "";
                    bool lastPage = false;

                    while (!lastPage)
                    {
                        if (page.IndexOf("<li class=\"next\">") > 0)
                            lastPage = false;
                        else
                            lastPage = true;

                        parser.Init(Encoding.UTF8.GetBytes(page));
                        parser.SetEncoding(Encoding.UTF8);

                        HTMLchunk chunk;
                        HTMLchunk tr_chunk;
                        HTMLchunk td_chunk;
                        HTMLchunk li_chunk;

                        string sVacancyId = "";
                        string sVacancyDescription = "";

                        while ((chunk = parser.ParseNext()) != null)
                        {
                            switch (chunk.sTag)
                            {
                                case "tbody":
                                    while ((tr_chunk = parser.ParseNextTag()) != null && tr_chunk.sTag == "tr")
                                    {
                                        // VAC ID
                                        td_chunk = parser.ParseNextTag(); // td open
                                        //td_chunk = parser.ParseNext(); 
                                        td_chunk = parser.ParseNext();
                                        sVacancyId = td_chunk.oHTML;
                                        td_chunk = parser.ParseNext(); // td close

                                        // VAC DESC
                                        td_chunk = parser.ParseNextTag(); // td open
                                        td_chunk = parser.ParseNext();
                                        sVacancyDescription = td_chunk.oHTML;
                                        td_chunk = parser.ParseNextTag(); // td close

                                        td_chunk = parser.ParseNextTag(); // td open
                                        td_chunk = parser.ParseNextTag(); // a open
                                        td_chunk = parser.ParseNextTag(); // a close
                                        td_chunk = parser.ParseNextTag(); // td close

                                        td_chunk = parser.ParseNextTag(); // tr close

                                        vacs.Add(new CVacancyListElement(int.Parse(sVacancyId), sVacancyDescription));
                                    }
                                    break;
                                case "ul":
                                    if (chunk.GetParamValue("id") == "yw0")
                                    {
                                        while ((li_chunk = parser.ParseNextTag()) != null && li_chunk.sTag == "li")
                                        {
                                            if (li_chunk.GetParamValue("class") == "next")
                                            {
                                                HTMLchunk a_chunk = parser.ParseNextTag();

                                                if (a_chunk.sTag == "a")
                                                    strNextPageUrl = a_chunk.GetParamValue("href");

                                                if (strNextPageUrl != "")
                                                    strNextPageUrl = strVacantUrl + strNextPageUrl;

                                                a_chunk = parser.ParseNextTag();
                                            }
                                            else
                                            {
                                                li_chunk = parser.ParseNextTag();
                                                li_chunk = parser.ParseNextTag();
                                            }

                                            li_chunk = parser.ParseNextTag();
                                        }
                                    }
                                    else
                                        continue;
                                    break;
                            }
                        }

                        if (lastPage || (strNextPageUrl == ""))
                            break;

                        page = http.GetUrl(strNextPageUrl);
                    }
                }
                else
                {
                    parser.Init(Encoding.UTF8.GetBytes(page));
                    parser.SetEncoding(Encoding.UTF8);

                    HTMLchunk chunk;
                    HTMLchunk tr_chunk;
                    HTMLchunk td_chunk;

                    string sVacancyId = "";
                    string sVacancyDescription = "";

                    while ((chunk = parser.ParseNext()) != null)
                    {
                        switch (chunk.sTag)
                        {
                            case "tbody":
                                while ((tr_chunk = parser.ParseNextTag()) != null && tr_chunk.sTag == "tr")
                                {
                                    // VAC ID
                                    td_chunk = parser.ParseNextTag(); // td open
                                    //td_chunk = parser.ParseNext(); 
                                    td_chunk = parser.ParseNext();
                                    sVacancyId = td_chunk.oHTML;
                                    td_chunk = parser.ParseNext(); // td close

                                    // VAC DESC
                                    td_chunk = parser.ParseNextTag(); // td open
                                    td_chunk = parser.ParseNext();
                                    sVacancyDescription = td_chunk.oHTML;
                                    td_chunk = parser.ParseNextTag(); // td close

                                    td_chunk = parser.ParseNextTag(); // td open
                                    td_chunk = parser.ParseNextTag(); // a open
                                    td_chunk = parser.ParseNextTag(); // a close
                                    td_chunk = parser.ParseNextTag(); // td close

                                    td_chunk = parser.ParseNextTag(); // tr close

                                    vacs.Add(new CVacancyListElement(int.Parse(sVacancyId), sVacancyDescription));
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
        public List<CVacancyListElement> GetClosedVacancies()
        {
            //bIsLogged = true;

            if (bIsLogged)
            {
                List<CVacancyListElement> vacs = null;

                string page = http.GetUrl(strClosedUrl);
                //string page = null;

                TextReader reader;
                using (reader = new StreamReader(Program.GetApplicationDirectory() + "\\" + "closed.htm", Encoding.UTF8))
                {
                    try
                    {
                        page = reader.ReadToEnd();
                    }
                    catch (Exception ex)
                    {
                        page = "";
                    }
                }

                vacs = new List<CVacancyListElement>();

                // Проверка количество страниц с вакансиями
                if (page.IndexOf("<div class=\"pagination\">") > 0)
                {
                    string strNextPageUrl = "";
                    bool lastPage = false;

                    while (!lastPage)
                    {
                        if (page.IndexOf("<li class=\"next\">") > 0)
                            lastPage = false;
                        else
                            lastPage = true;

                        parser.Init(Encoding.UTF8.GetBytes(page));
                        parser.SetEncoding(Encoding.UTF8);

                        HTMLchunk chunk;
                        HTMLchunk tr_chunk;
                        HTMLchunk td_chunk;
                        HTMLchunk li_chunk;

                        string sVacancyId = "";
                        string sVacancyDescription = "";

                        while ((chunk = parser.ParseNext()) != null)
                        {
                            switch (chunk.sTag)
                            {
                                case "tbody":
                                    while ((tr_chunk = parser.ParseNextTag()) != null && tr_chunk.sTag=="tr") 
                                    {
                                        // VAC ID
                                        td_chunk = parser.ParseNextTag(); // td open
                                        //td_chunk = parser.ParseNext(); 
                                        td_chunk = parser.ParseNext();
                                        sVacancyId = td_chunk.oHTML;
                                        td_chunk = parser.ParseNext(); // td close

                                        // VAC DESC
                                        td_chunk = parser.ParseNextTag(); // td open
                                        td_chunk = parser.ParseNext();
                                        sVacancyDescription = td_chunk.oHTML;
                                        td_chunk = parser.ParseNextTag(); // td close

                                        td_chunk = parser.ParseNextTag(); // td open
                                        td_chunk = parser.ParseNextTag(); // a open
                                        td_chunk = parser.ParseNextTag(); // a close
                                        td_chunk = parser.ParseNextTag(); // td close

                                        td_chunk = parser.ParseNextTag(); // tr close

                                        vacs.Add(new CVacancyListElement(int.Parse(sVacancyId), sVacancyDescription));
                                    }
                                    break;
                                case "ul":
                                    if (chunk.GetParamValue("id") == "yw0")
                                    {
                                        while ((li_chunk = parser.ParseNextTag()) != null && li_chunk.sTag == "li")
                                        {
                                            if (li_chunk.GetParamValue("class") == "next")
                                            {
                                                HTMLchunk a_chunk = parser.ParseNextTag();

                                                if (a_chunk.sTag == "a")
                                                    strNextPageUrl = a_chunk.GetParamValue("href");

                                                if (strNextPageUrl != "")
                                                    strNextPageUrl = strVacantUrl + strNextPageUrl;

                                                a_chunk = parser.ParseNextTag();
                                            }
                                            else
                                            {
                                                li_chunk = parser.ParseNextTag();
                                                li_chunk = parser.ParseNextTag();
                                            }

                                            li_chunk = parser.ParseNextTag();
                                        }
                                    }
                                    else
                                        continue;
                                    break;
                            }
                        }

                        if (lastPage || (strNextPageUrl == ""))
                            break;

                        page = http.GetUrl(strNextPageUrl);
                    }
                }
                else
                {
                    parser.Init(Encoding.UTF8.GetBytes(page));
                    parser.SetEncoding(Encoding.UTF8);

                    HTMLchunk chunk;
                    HTMLchunk tr_chunk;
                    HTMLchunk td_chunk;

                    string sVacancyId = "";
                    string sVacancyDescription = "";

                    while ((chunk = parser.ParseNext()) != null)
                    {
                        switch (chunk.sTag)
                        {
                            case "tbody":
                                while ((tr_chunk = parser.ParseNextTag()) != null && tr_chunk.sTag == "tr")
                                {
                                    // VAC ID
                                    td_chunk = parser.ParseNextTag(); // td open
                                    //td_chunk = parser.ParseNext(); 
                                    td_chunk = parser.ParseNext();
                                    sVacancyId = td_chunk.oHTML;
                                    td_chunk = parser.ParseNext(); // td close

                                    // VAC DESC
                                    td_chunk = parser.ParseNextTag(); // td open
                                    td_chunk = parser.ParseNext();
                                    sVacancyDescription = td_chunk.oHTML;
                                    td_chunk = parser.ParseNextTag(); // td close

                                    td_chunk = parser.ParseNextTag(); // td open
                                    td_chunk = parser.ParseNextTag(); // a open
                                    td_chunk = parser.ParseNextTag(); // a close
                                    td_chunk = parser.ParseNextTag(); // td close

                                    td_chunk = parser.ParseNextTag(); // tr close

                                    vacs.Add(new CVacancyListElement(int.Parse(sVacancyId), sVacancyDescription));
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
        /// Метод обращяется к серверу для генерации нового изображения с капчей
        /// </summary>
        /// <returns>При успешном вызове возвратит последовательность байтов PNG-изображения капчи, в другом случае <value>null</value></returns>
        public byte[] GetCapcha()
        {
            if (bIsLogged)
            {
                Random rnd = new Random(DateTime.Now.Millisecond);

                string newCapcthaUrl = strRefreshCaptchaUrl + rnd.Next().ToString();

                string newCaptchaResponse = http.GetUrl(newCapcthaUrl);

                int parse_pos = newCaptchaResponse.IndexOf("v=");

                if (parse_pos > 0)
                {
                    string newCaptchaId = newCaptchaResponse.Substring(parse_pos+2);

                    byte[] ret = http.GetBytes(strCaptchaImageUrl + newCaptchaId);

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

        public void SetCaptchaText(string captchaText)
        {
            this.strCaptchaText = captchaText;
        }
    }
}
