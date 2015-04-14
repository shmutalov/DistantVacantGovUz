using System;
using System.Collections.Generic;
using System.Text;

namespace DistantVacantGovUz
{
    /// <summary>
    /// Статус вакансии
    /// </summary>
    public enum VACANCY_STATUS
    {
        OPEN = 0, // open
        CLOSED = 1, // closed
        UNKNOWN = -1
    }

    /// <summary>
    /// Категория вакансии
    /// </summary>
    public enum VACANCY_CATEGORY
    {
        IT_INTERNET_TELEKOM = 1,
        GOSUDARSTVENNAYA_SLUJBA = 2,
        ISKUSSTVO_KULTURA = 3,
        KORPORATIVNIYE_USLUGI = 4,
        MARKETING_REKLAMA = 5,
        MEDIA = 6,
        MEDICINA_ZDRAVOOXRANENIYE_FARMACEVTIKA = 7,
        NEDVIJIMOST = 8,
        NEKOMMERCHESKIYE_ORGANIZACII = 9,
        OBRAZOVANIYE_NAUKA = 10,
        POLEZNIYE_ISKOPAYEMIYE_DOBICHA_SIRYA = 11,
        PROMISHLENNOST = 12,
        RAZVLECHENIYA_OTDIX_SPORT_KRASOTA = 13,
        SELSKOYE_XOZYAYSTVO = 14,
        STROITELSTVO = 15,
        TOVARI_NARODNOGO_POTREBLENIYA = 16,
        TORGOVLYA = 17,
        TRANSPORT_LOGISTIKA_AVTOMOBILNIY_BIZNES = 18,
        FINANSI_BANKI_INVESTICII_LIZING = 19,
        EKOLOGIYA_ZASHITA_OKRUJAYUSHEY_SREDI = 20,
        YURIDICHESKAYA_SLUJBA = 21,
        ANTIKVARIAT = 22,
        BUXGALTERIYA_UPRAVLENCHESKIY_UCHET_FINANSI_PREDPRIYATIYA = 23,
        ADMINISTRATIVNIY_PERSONAL = 24,
        UPRAVLENIYE_PERSONALOM_TRENINGI = 25,
        BEZOPASNOST = 26,
        VISSHIY_MENEDJMENT = 27,
        KONSULTIROVANIYE = 28,
        STRAXOVANIYE = 29,
        UNKNOWN = -1
    }

    /// <summary>
    /// Занятость
    /// </summary>
    public enum VACANCY_EMPLOYMENT
    {
        NO_MATTER = 0, // "none"
        FULL = 1, // "full"
        PART = 2, // "part"
        FREELANCE = 3, // "freelance"
        COMBINED = 4, // "sov"
        UNKNOWN = -1
    }

    /// <summary>
    /// Пол
    /// </summary>
    public enum VACANCY_GENDER
    {
        NO_MATTER = 0, // "N"
        MALE = 1,  // "M"
        FEMALE = 2, // "F"
        UNKNOWN = -1 // WTF?
    }

    /// <summary>
    /// Стаж работы
    /// </summary>
    public enum VACANCY_EXPERIENCE
    {
        NO_MATTER = 0, // "none"
        ONE_YEAR = 1, // "one year"
        TWO_YEARS = 2, // "two years"
        THREE_YEARS = 3, // "three years"
        //FOUR_YEARS = 4, // "four years"
        //FIVE_AND_MORE_YEARS = 5, // "five etc"
        FIVE_AND_MORE_YEARS = 4, // "five etc"
        UNKNOWN = -1
    }

    /// <summary>
    /// Образование
    /// </summary>
    public enum VACANCY_EDUCATION_LEVEL
    {
        NO_MATTER = 0, //"none"
        MEDIUM = 1, // "school"
        SPECIAL_MEDIUM = 2, // "college"
        HIGH_NOT_ENDED = 3, // "half high"
        HIGH = 4, //"high"
        UNKNOWN = -1
    }

    /// <summary>
    /// Класс объекта "Вакансия"
    /// </summary>
    public class CVacancy
    {
        public string strDescriptionRU;
        public string strDescriptionUZ;
        public VACANCY_CATEGORY vacCategory;
        public string strSalary;
        public VACANCY_EMPLOYMENT vacEmployment;
        public VACANCY_GENDER vacGender;
        public VACANCY_EXPERIENCE vacExperience;
        public VACANCY_EDUCATION_LEVEL vacEducaton;
        public string strExpireDate;
        public VACANCY_STATUS vacStatus;
        public string strDepartmentRU;
        public string strDepartmentUZ;
        public string strSpecializationRU;
        public string strSpecializationUZ;
        public string strRequirementsRU;
        public string strRequirementsUZ;
        public string strInformationRU;
        public string strInformationUZ;
        public string strPortalVacID;

        /// <summary>
        /// Инициализация всех свойств вакансии
        /// </summary>
        /// <param name="p_strDescriptionRU">Русское наименование</param>
        /// <param name="p_strDescriptionUZ">Узбекское наименование (латинскими буквами)</param>
        /// <param name="p_vacCategory">Категория</param>
        /// <param name="p_strSalary">Заработная плата</param>
        /// <param name="p_vacEmployment">Занятость</param>
        /// <param name="p_vacGender">Пол</param>
        /// <param name="p_vacExperience">Необходимый стаж</param>
        /// <param name="p_vacEducation">Образование</param>
        /// <param name="p_strExpireDate">Действителен до</param>
        /// <param name="p_vacStatus">Статус</param>
        /// <param name="p_strDepartmentRU">Отдел / Подразделение (Русский)</param>
        /// <param name="p_strDepartmentUZ">Отдел / Подразделение (Узбекский)</param>
        /// <param name="p_strSpecializationRU">Функциональность (Русский)</param>
        /// <param name="p_strSpecializationUZ">Функциональность (Узбекский)</param>
        /// <param name="p_strRequirementsRU">Требования (Русский)</param>
        /// <param name="p_strRequirementsUZ">Требования (Узбекский)</param>
        /// <param name="p_strInformationRU">Дополнительные информации (Русский)</param>
        /// <param name="p_strInformationUZ">Дополнительные информации (Узбекский)</param>
        /// <param name="p_strPortalVacID">ID вакансии на портале</param>
        public CVacancy(string p_strDescriptionRU
            , string p_strDescriptionUZ
            , VACANCY_CATEGORY p_vacCategory
            , string p_strSalary
            , VACANCY_EMPLOYMENT p_vacEmployment
            , VACANCY_GENDER p_vacGender
            , VACANCY_EXPERIENCE p_vacExperience
            , VACANCY_EDUCATION_LEVEL p_vacEducation
            , string p_strExpireDate
            , VACANCY_STATUS p_vacStatus
            , string p_strDepartmentRU
            , string p_strDepartmentUZ
            , string p_strSpecializationRU
            , string p_strSpecializationUZ
            , string p_strRequirementsRU
            , string p_strRequirementsUZ
            , string p_strInformationRU
            , string p_strInformationUZ
            , string p_strPortalVacID)
        {
            this.strDescriptionRU = p_strDescriptionRU;
            this.strDescriptionUZ = p_strDescriptionUZ;
            this.vacCategory = p_vacCategory;
            this.strSalary = p_strSalary;
            this.vacEmployment = p_vacEmployment;
            this.vacGender = p_vacGender;
            this.vacExperience = p_vacExperience;
            this.vacEducaton = p_vacEducation;
            this.strExpireDate = p_strExpireDate;
            this.vacStatus = p_vacStatus;
            this.strDepartmentRU = p_strDepartmentRU;
            this.strDepartmentUZ = p_strDepartmentUZ;
            this.strSpecializationRU = p_strSpecializationRU;
            this.strSpecializationUZ = p_strSpecializationUZ;
            this.strRequirementsRU = p_strRequirementsRU;
            this.strRequirementsUZ = p_strRequirementsUZ;
            this.strInformationRU = p_strInformationRU;
            this.strInformationUZ = p_strInformationUZ;
            this.strPortalVacID = p_strPortalVacID;
        }

        /// <summary>
        /// Инициализация всех свойств вакансии (без ID вакансии портала)
        /// </summary>
        /// <param name="p_strDescriptionRU">Русское наименование</param>
        /// <param name="p_strDescriptionUZ">Узбекское наименование (латинскими буквами)</param>
        /// <param name="p_vacCategory">Категория</param>
        /// <param name="p_strSalary">Заработная плата</param>
        /// <param name="p_vacEmployment">Занятость</param>
        /// <param name="p_vacGender">Пол</param>
        /// <param name="p_vacExperience">Необходимый стаж</param>
        /// <param name="p_vacEducation">Образование</param>
        /// <param name="p_strExpireDate">Действителен до</param>
        /// <param name="p_vacStatus">Статус</param>
        /// <param name="p_strDepartmentRU">Отдел / Подразделение (Русский)</param>
        /// <param name="p_strDepartmentUZ">Отдел / Подразделение (Узбекский)</param>
        /// <param name="p_strSpecializationRU">Функциональность (Русский)</param>
        /// <param name="p_strSpecializationUZ">Функциональность (Узбекский)</param>
        /// <param name="p_strRequirementsRU">Требования (Русский)</param>
        /// <param name="p_strRequirementsUZ">Требования (Узбекский)</param>
        /// <param name="p_strInformationRU">Дополнительные информации (Русский)</param>
        /// <param name="p_strInformationUZ">Дополнительные информации (Узбекский)</param>
        /// <param name="p_strPortalVacID">ID вакансии на портале</param>
        public CVacancy(string p_strDescriptionRU
            , string p_strDescriptionUZ
            , VACANCY_CATEGORY p_vacCategory
            , string p_strSalary
            , VACANCY_EMPLOYMENT p_vacEmployment
            , VACANCY_GENDER p_vacGender
            , VACANCY_EXPERIENCE p_vacExperience
            , VACANCY_EDUCATION_LEVEL p_vacEducation
            , string p_strExpireDate
            , VACANCY_STATUS p_vacStatus
            , string p_strDepartmentRU
            , string p_strDepartmentUZ
            , string p_strSpecializationRU
            , string p_strSpecializationUZ
            , string p_strRequirementsRU
            , string p_strRequirementsUZ
            , string p_strInformationRU
            , string p_strInformationUZ)
        {
            this.strDescriptionRU = p_strDescriptionRU;
            this.strDescriptionUZ = p_strDescriptionUZ;
            this.vacCategory = p_vacCategory;
            this.strSalary = p_strSalary;
            this.vacEmployment = p_vacEmployment;
            this.vacGender = p_vacGender;
            this.vacExperience = p_vacExperience;
            this.vacEducaton = p_vacEducation;
            this.strExpireDate = p_strExpireDate;
            this.vacStatus = p_vacStatus;
            this.strDepartmentRU = p_strDepartmentRU;
            this.strDepartmentUZ = p_strDepartmentUZ;
            this.strSpecializationRU = p_strSpecializationRU;
            this.strSpecializationUZ = p_strSpecializationUZ;
            this.strRequirementsRU = p_strRequirementsRU;
            this.strRequirementsUZ = p_strRequirementsUZ;
            this.strInformationRU = p_strInformationRU;
            this.strInformationUZ = p_strInformationUZ;
            this.strPortalVacID = "";
        }

        public static string StatusFromIdRu(VACANCY_STATUS s)
        {
            switch (s)
            {
                case VACANCY_STATUS.OPEN:
                    return "Актуальный";
                case VACANCY_STATUS.CLOSED:
                    return "Неактуальный";
                default:
                    return "";
            }
        }

        public static string StatusFromIdUz(VACANCY_STATUS s)
        {
            switch (s)
            {
                case VACANCY_STATUS.OPEN:
                    return "Aktual";
                case VACANCY_STATUS.CLOSED:
                    return "Noaktual";
                default:
                    return "";
            }
        }

        public static string StatusId(VACANCY_STATUS s)
        {
            switch (s)
            {
                case VACANCY_STATUS.OPEN:
                    return "open";
                case VACANCY_STATUS.CLOSED:
                    return "closed";
                default:
                    return "";
            }
        }

        public static VACANCY_STATUS StatusIdFromValue(string s)
        {
            switch (s)
            {
                case "open":
                    return VACANCY_STATUS.OPEN;
                case "closed":
                    return VACANCY_STATUS.CLOSED;
                default:
                    return VACANCY_STATUS.UNKNOWN;
            }
        }

        public static int CategoryId(VACANCY_CATEGORY c)
        {
            switch (c)
            {
                case VACANCY_CATEGORY.IT_INTERNET_TELEKOM: return 1;
                case VACANCY_CATEGORY.GOSUDARSTVENNAYA_SLUJBA: return 2;
                case VACANCY_CATEGORY.ISKUSSTVO_KULTURA: return 3;
                case VACANCY_CATEGORY.KORPORATIVNIYE_USLUGI: return 4;
                case VACANCY_CATEGORY.MARKETING_REKLAMA: return 5;
                case VACANCY_CATEGORY.MEDIA: return 6;
                case VACANCY_CATEGORY.MEDICINA_ZDRAVOOXRANENIYE_FARMACEVTIKA: return 7;
                case VACANCY_CATEGORY.NEDVIJIMOST: return 8;
                case VACANCY_CATEGORY.NEKOMMERCHESKIYE_ORGANIZACII: return 9;
                case VACANCY_CATEGORY.OBRAZOVANIYE_NAUKA: return 10;
                case VACANCY_CATEGORY.POLEZNIYE_ISKOPAYEMIYE_DOBICHA_SIRYA: return 11;
                case VACANCY_CATEGORY.PROMISHLENNOST: return 12;
                case VACANCY_CATEGORY.RAZVLECHENIYA_OTDIX_SPORT_KRASOTA: return 13;
                case VACANCY_CATEGORY.SELSKOYE_XOZYAYSTVO: return 14;
                case VACANCY_CATEGORY.STROITELSTVO: return 15;
                case VACANCY_CATEGORY.TOVARI_NARODNOGO_POTREBLENIYA: return 16;
                case VACANCY_CATEGORY.TORGOVLYA: return 17;
                case VACANCY_CATEGORY.TRANSPORT_LOGISTIKA_AVTOMOBILNIY_BIZNES: return 18;
                case VACANCY_CATEGORY.FINANSI_BANKI_INVESTICII_LIZING: return 19;
                case VACANCY_CATEGORY.EKOLOGIYA_ZASHITA_OKRUJAYUSHEY_SREDI: return 20;
                case VACANCY_CATEGORY.YURIDICHESKAYA_SLUJBA: return 21;
                case VACANCY_CATEGORY.ANTIKVARIAT: return 22;
                case VACANCY_CATEGORY.BUXGALTERIYA_UPRAVLENCHESKIY_UCHET_FINANSI_PREDPRIYATIYA: return 23;
                case VACANCY_CATEGORY.ADMINISTRATIVNIY_PERSONAL: return 24;
                case VACANCY_CATEGORY.UPRAVLENIYE_PERSONALOM_TRENINGI: return 25;
                case VACANCY_CATEGORY.BEZOPASNOST: return 26;
                case VACANCY_CATEGORY.VISSHIY_MENEDJMENT: return 27;
                case VACANCY_CATEGORY.KONSULTIROVANIYE: return 28;
                case VACANCY_CATEGORY.STRAXOVANIYE: return 29;
                default:
                    return 0;
            }
        }

        public static VACANCY_CATEGORY CategoryIdFromOptionValue(string c)
        {
            switch (c)
            {
                case "1":
                    return VACANCY_CATEGORY.IT_INTERNET_TELEKOM;
                case "2":
                    return VACANCY_CATEGORY.GOSUDARSTVENNAYA_SLUJBA;
                case "3":
                    return VACANCY_CATEGORY.ISKUSSTVO_KULTURA;
                case "4":
                    return VACANCY_CATEGORY.KORPORATIVNIYE_USLUGI;
                case "5":
                    return VACANCY_CATEGORY.MARKETING_REKLAMA;
                case "6":
                    return VACANCY_CATEGORY.MEDIA;
                case "7":
                    return VACANCY_CATEGORY.MEDICINA_ZDRAVOOXRANENIYE_FARMACEVTIKA;
                case "8":
                    return VACANCY_CATEGORY.NEDVIJIMOST;
                case "9":
                    return VACANCY_CATEGORY.NEKOMMERCHESKIYE_ORGANIZACII;
                case "10":
                    return VACANCY_CATEGORY.OBRAZOVANIYE_NAUKA;
                case "11":
                    return VACANCY_CATEGORY.POLEZNIYE_ISKOPAYEMIYE_DOBICHA_SIRYA;
                case "12":
                    return VACANCY_CATEGORY.PROMISHLENNOST;
                case "13":
                    return VACANCY_CATEGORY.RAZVLECHENIYA_OTDIX_SPORT_KRASOTA;
                case "14":
                    return VACANCY_CATEGORY.SELSKOYE_XOZYAYSTVO;
                case "15":
                    return VACANCY_CATEGORY.STROITELSTVO;
                case "16":
                    return VACANCY_CATEGORY.TOVARI_NARODNOGO_POTREBLENIYA;
                case "17":
                    return VACANCY_CATEGORY.TORGOVLYA;
                case "18":
                    return VACANCY_CATEGORY.TRANSPORT_LOGISTIKA_AVTOMOBILNIY_BIZNES;
                case "19":
                    return VACANCY_CATEGORY.FINANSI_BANKI_INVESTICII_LIZING;
                case "20":
                    return VACANCY_CATEGORY.EKOLOGIYA_ZASHITA_OKRUJAYUSHEY_SREDI;
                case "21":
                    return VACANCY_CATEGORY.YURIDICHESKAYA_SLUJBA;
                case "22":
                    return VACANCY_CATEGORY.ANTIKVARIAT;
                case "23":
                    return VACANCY_CATEGORY.BUXGALTERIYA_UPRAVLENCHESKIY_UCHET_FINANSI_PREDPRIYATIYA;
                case "24":
                    return VACANCY_CATEGORY.ADMINISTRATIVNIY_PERSONAL;
                case "25":
                    return VACANCY_CATEGORY.UPRAVLENIYE_PERSONALOM_TRENINGI;
                case "26":
                    return VACANCY_CATEGORY.BEZOPASNOST;
                case "27":
                    return VACANCY_CATEGORY.VISSHIY_MENEDJMENT;
                case "28":
                    return VACANCY_CATEGORY.KONSULTIROVANIYE;
                case "29":
                    return VACANCY_CATEGORY.STRAXOVANIYE;
                default:
                    return VACANCY_CATEGORY.UNKNOWN;
            }
        }

        public static string CategoryFromIdRu(VACANCY_CATEGORY c)
        {
            switch (c)
            {
                case VACANCY_CATEGORY.IT_INTERNET_TELEKOM: return @"IT / Интернет / Телеком";
                case VACANCY_CATEGORY.GOSUDARSTVENNAYA_SLUJBA: return @"Государственная служба";
                case VACANCY_CATEGORY.ISKUSSTVO_KULTURA: return @"Искусство / Культура";
                case VACANCY_CATEGORY.KORPORATIVNIYE_USLUGI: return @"Корпоративные услуги";
                case VACANCY_CATEGORY.MARKETING_REKLAMA: return @"Маркетинг / Реклама / PR";
                case VACANCY_CATEGORY.MEDIA: return @"Медиа";
                case VACANCY_CATEGORY.MEDICINA_ZDRAVOOXRANENIYE_FARMACEVTIKA: return @"Медицина / Здравоохранение / Фармацевтика";
                case VACANCY_CATEGORY.NEDVIJIMOST: return @"Недвижимость";
                case VACANCY_CATEGORY.NEKOMMERCHESKIYE_ORGANIZACII: return @"Некоммерческие организации";
                case VACANCY_CATEGORY.OBRAZOVANIYE_NAUKA: return @"Образование / Наука";
                case VACANCY_CATEGORY.POLEZNIYE_ISKOPAYEMIYE_DOBICHA_SIRYA: return @"Полезные ископаемые / Добыча сырья";
                case VACANCY_CATEGORY.PROMISHLENNOST: return @"Промышленность";
                case VACANCY_CATEGORY.RAZVLECHENIYA_OTDIX_SPORT_KRASOTA: return @"Развлечения / Отдых / Спорт / Красота";
                case VACANCY_CATEGORY.SELSKOYE_XOZYAYSTVO: return @"Сельское хозяйство";
                case VACANCY_CATEGORY.STROITELSTVO: return @"Строительство";
                case VACANCY_CATEGORY.TOVARI_NARODNOGO_POTREBLENIYA: return @"Товары народного потребления";
                case VACANCY_CATEGORY.TORGOVLYA: return @"Торговля";
                case VACANCY_CATEGORY.TRANSPORT_LOGISTIKA_AVTOMOBILNIY_BIZNES: return @"Транспорт / Логистика / Автомобильный бизнес";
                case VACANCY_CATEGORY.FINANSI_BANKI_INVESTICII_LIZING: return @"Финансы / Банки / Инвестиции / Лизинг";
                case VACANCY_CATEGORY.EKOLOGIYA_ZASHITA_OKRUJAYUSHEY_SREDI: return @"Экология / Защита окружающей среды";
                case VACANCY_CATEGORY.YURIDICHESKAYA_SLUJBA: return @"Юридическая служба";
                case VACANCY_CATEGORY.ANTIKVARIAT: return @"Антиквариат";
                case VACANCY_CATEGORY.BUXGALTERIYA_UPRAVLENCHESKIY_UCHET_FINANSI_PREDPRIYATIYA: return @"Бухгалтерия / Управленческий учет / Финансы предприятия";
                case VACANCY_CATEGORY.ADMINISTRATIVNIY_PERSONAL: return @"Административный персонал";
                case VACANCY_CATEGORY.UPRAVLENIYE_PERSONALOM_TRENINGI: return @"Управление персоналом / Тренинги";
                case VACANCY_CATEGORY.BEZOPASNOST: return @"Безопасность";
                case VACANCY_CATEGORY.VISSHIY_MENEDJMENT: return @"Высший менеджмент";
                case VACANCY_CATEGORY.KONSULTIROVANIYE: return @"Консультирование";
                case VACANCY_CATEGORY.STRAXOVANIYE: return @"Страхование";
                default:
                    return "";
            }
        }

        public static string CategoryFromIdUz(VACANCY_CATEGORY c)
        {
            switch (c)
            {
                case VACANCY_CATEGORY.IT_INTERNET_TELEKOM: return @"IT / Internet / Telekom";
                case VACANCY_CATEGORY.GOSUDARSTVENNAYA_SLUJBA: return @"Davlat xizmati";
                case VACANCY_CATEGORY.ISKUSSTVO_KULTURA: return @"San'at / Madaniyat";
                case VACANCY_CATEGORY.KORPORATIVNIYE_USLUGI: return @"Korporativ xizmatlar";
                case VACANCY_CATEGORY.MARKETING_REKLAMA: return @"Marketing / Reklama / PR";
                case VACANCY_CATEGORY.MEDIA: return @"Media";
                case VACANCY_CATEGORY.MEDICINA_ZDRAVOOXRANENIYE_FARMACEVTIKA: return @"Tibbiyot / Sog'liqni saqlash / Farmatsevtika";
                case VACANCY_CATEGORY.NEDVIJIMOST: return @"Ko'chmas mulk";
                case VACANCY_CATEGORY.NEKOMMERCHESKIYE_ORGANIZACII: return @"Notijorat tashkilotlar";
                case VACANCY_CATEGORY.OBRAZOVANIYE_NAUKA: return @"Ta'lim / Fan";
                case VACANCY_CATEGORY.POLEZNIYE_ISKOPAYEMIYE_DOBICHA_SIRYA: return @"Foydali qazilmalar / Yer osti boyliklarni qazib olish";
                case VACANCY_CATEGORY.PROMISHLENNOST: return @"Sanoat";
                case VACANCY_CATEGORY.RAZVLECHENIYA_OTDIX_SPORT_KRASOTA: return @"Sayr-tomosha / Dam olish / Sport / Go'zallik";
                case VACANCY_CATEGORY.SELSKOYE_XOZYAYSTVO: return @"Qishloq xo'jaligi";
                case VACANCY_CATEGORY.STROITELSTVO: return @"Qurilish";
                case VACANCY_CATEGORY.TOVARI_NARODNOGO_POTREBLENIYA: return @"Aholi ist'emol mollari";
                case VACANCY_CATEGORY.TORGOVLYA: return @"Savdo sotiq";
                case VACANCY_CATEGORY.TRANSPORT_LOGISTIKA_AVTOMOBILNIY_BIZNES: return @"Transport / Logistika / Avtomobilga oid tadbirkorlik";
                case VACANCY_CATEGORY.FINANSI_BANKI_INVESTICII_LIZING: return @"Moliya / Banklar / Investitsiya / Lizing";
                case VACANCY_CATEGORY.EKOLOGIYA_ZASHITA_OKRUJAYUSHEY_SREDI: return @"Ekologiya / Atrofni muhofaza qilish markazlari";
                case VACANCY_CATEGORY.YURIDICHESKAYA_SLUJBA: return @"Yuridik xizmat";
                case VACANCY_CATEGORY.ANTIKVARIAT: return @"Nodir buyumlar ";
                case VACANCY_CATEGORY.BUXGALTERIYA_UPRAVLENCHESKIY_UCHET_FINANSI_PREDPRIYATIYA: return @"Buxgalteriya / Boshqarmaga oid ro'yxat / Moliya davlat korxonasi";
                case VACANCY_CATEGORY.ADMINISTRATIVNIY_PERSONAL: return @"Ma'muriyat hodimi";
                case VACANCY_CATEGORY.UPRAVLENIYE_PERSONALOM_TRENINGI: return @"Hodimlarni boshqarish / Trening";
                case VACANCY_CATEGORY.BEZOPASNOST: return @"Xavfsizlik";
                case VACANCY_CATEGORY.VISSHIY_MENEDJMENT: return @"Oliy menejment";
                case VACANCY_CATEGORY.KONSULTIROVANIYE: return @"Maslaxatlar";
                case VACANCY_CATEGORY.STRAXOVANIYE: return @"Sugu'urta";
                default:
                    return "";
            }
        }

        public static string GenderId(VACANCY_GENDER g)
        {
            switch (g)
            {
                case VACANCY_GENDER.NO_MATTER:
                    return "N";
                case VACANCY_GENDER.MALE:
                    return "M";
                case VACANCY_GENDER.FEMALE:
                    return "F";
                default:
                    return "";
            }
        }

        public static VACANCY_GENDER GenderFromOptionValue(string g)
        {
            switch (g)
            {
                case "N":
                    return VACANCY_GENDER.NO_MATTER;
                case "M":
                    return VACANCY_GENDER.MALE;
                case "F":
                    return VACANCY_GENDER.FEMALE;
                default:
                    return VACANCY_GENDER.UNKNOWN;
            }
        }

        public static string GenderFromIdRu(VACANCY_GENDER g)
        {
            switch (g)
            {
                case VACANCY_GENDER.NO_MATTER:
                    return "Без разницы";
                case VACANCY_GENDER.MALE:
                    return "Мужской";
                case VACANCY_GENDER.FEMALE:
                    return "Женский";
                default:
                    return "";
            }
        }

        public static string GenderFromIdUz(VACANCY_GENDER g)
        {
            switch (g)
            {
                case VACANCY_GENDER.NO_MATTER:
                    return "Farqsiz";
                case VACANCY_GENDER.MALE:
                    return "Erkak";
                case VACANCY_GENDER.FEMALE:
                    return "Ayol";
                default:
                    return "";
            }
        }

        public static string EmploymentId(VACANCY_EMPLOYMENT e)
        {
            switch (e)
            {
                case VACANCY_EMPLOYMENT.NO_MATTER:
                    return "none";
                case VACANCY_EMPLOYMENT.FULL:
                    return "full";
                case VACANCY_EMPLOYMENT.PART:
                    return "part";
                case VACANCY_EMPLOYMENT.FREELANCE:
                    return "freelance";
                case VACANCY_EMPLOYMENT.COMBINED:
                    return "sov";
                default:
                    return "";
            }
        }

        public static VACANCY_EMPLOYMENT EmploymentIdFromOptionValue(string e)
        {
            switch (e)
            {
                case "none":
                    return VACANCY_EMPLOYMENT.NO_MATTER;
                case "full":
                    return VACANCY_EMPLOYMENT.FULL;
                case "part":
                    return VACANCY_EMPLOYMENT.PART;
                case "freelance":
                    return VACANCY_EMPLOYMENT.FREELANCE;
                case "sov":
                    return VACANCY_EMPLOYMENT.COMBINED;
                default:
                    return VACANCY_EMPLOYMENT.UNKNOWN;
            }
        }

        public static string EmploymentFromIdRu(VACANCY_EMPLOYMENT e)
        {
            switch (e)
            {
                case VACANCY_EMPLOYMENT.NO_MATTER:
                    return "Без разницы";
                case VACANCY_EMPLOYMENT.FULL:
                    return "Полная";
                case VACANCY_EMPLOYMENT.PART:
                    return "Частичная";
                case VACANCY_EMPLOYMENT.FREELANCE:
                    return "Фриланс";
                case VACANCY_EMPLOYMENT.COMBINED:
                    return "Совместительство";
                default:
                    return "";
            }
        }

        public static string EmploymentFromIdUz(VACANCY_EMPLOYMENT e)
        {
            switch (e)
            {
                case VACANCY_EMPLOYMENT.NO_MATTER:
                    return "Farqsiz";
                case VACANCY_EMPLOYMENT.FULL:
                    return "To'liq";
                case VACANCY_EMPLOYMENT.PART:
                    return "To'liqsiz";
                case VACANCY_EMPLOYMENT.FREELANCE:
                    return "Frilans";
                case VACANCY_EMPLOYMENT.COMBINED:
                    return "O'rindoshlik asosida";
                default:
                    return "";
            }
        }

        public static string ExperienceId(VACANCY_EXPERIENCE e)
        {
            switch (e)
            {
                case VACANCY_EXPERIENCE.NO_MATTER:
                    return "none";
                case VACANCY_EXPERIENCE.ONE_YEAR:
                    return "one year";
                case VACANCY_EXPERIENCE.TWO_YEARS:
                    return "two years";
                case VACANCY_EXPERIENCE.THREE_YEARS:
                    //return "three years";                 // Bug on Portal. Someone doesn't know english numbers )
                    return "tree years";
                //case VACANCY_EXPERIENCE.FOUR_YEARS:
                //    return "four years";
                case VACANCY_EXPERIENCE.FIVE_AND_MORE_YEARS:
                    return "five etc";
                default:
                    return "";
            }
        }

        public static VACANCY_EXPERIENCE ExperienceIdFromOptionValue(string e)
        {
            switch (e)
            {
                case "none":
                    return VACANCY_EXPERIENCE.NO_MATTER;
                case "one year":
                    return VACANCY_EXPERIENCE.ONE_YEAR;
                case "two years":
                    return VACANCY_EXPERIENCE.TWO_YEARS;
                case "tree years":                          // Bug on Portal. Someone doesn't know english numbers )
                case "three years":
                    return VACANCY_EXPERIENCE.THREE_YEARS;
                case "five etc":
                    return VACANCY_EXPERIENCE.FIVE_AND_MORE_YEARS;
                default:
                    return VACANCY_EXPERIENCE.UNKNOWN;
            }
        }

        public static string ExperienceFromIdRu(VACANCY_EXPERIENCE e)
        {
            switch (e)
            {
                case VACANCY_EXPERIENCE.NO_MATTER:
                    return "Без разницы";
                case VACANCY_EXPERIENCE.ONE_YEAR:
                    return "От одного года";
                case VACANCY_EXPERIENCE.TWO_YEARS:
                    return "От двух лет";
                case VACANCY_EXPERIENCE.THREE_YEARS:
                    return "От трех лет";
                //case VACANCY_EXPERIENCE.FOUR_YEARS:
                //    return "four years";
                case VACANCY_EXPERIENCE.FIVE_AND_MORE_YEARS:
                    return "Пять и более лет";
                default:
                    return "";
            }
        }

        public static string ExperienceFromIdUz(VACANCY_EXPERIENCE e)
        {
            switch (e)
            {
                case VACANCY_EXPERIENCE.NO_MATTER:
                    return "Farqsiz";
                case VACANCY_EXPERIENCE.ONE_YEAR:
                    return "Bir yil";
                case VACANCY_EXPERIENCE.TWO_YEARS:
                    return "Ikki yil";
                case VACANCY_EXPERIENCE.THREE_YEARS:
                    return "Uch yil";
                //case VACANCY_EXPERIENCE.FOUR_YEARS:
                //    return "four years";
                case VACANCY_EXPERIENCE.FIVE_AND_MORE_YEARS:
                    return "Besh yil va undan ko'p";
                default:
                    return "";
            }
        }

        public static string EducationId(VACANCY_EDUCATION_LEVEL e)
        {
            switch (e)
            {
                case VACANCY_EDUCATION_LEVEL.NO_MATTER:
                    return "none";
                case VACANCY_EDUCATION_LEVEL.MEDIUM:
                    return "school";
                case VACANCY_EDUCATION_LEVEL.SPECIAL_MEDIUM:
                    return "college";
                case VACANCY_EDUCATION_LEVEL.HIGH_NOT_ENDED:
                    return "half high";
                case VACANCY_EDUCATION_LEVEL.HIGH:
                    return "high";
                default:
                    return "";
            }
        }

        public static VACANCY_EDUCATION_LEVEL EducationIdFromOptionValue(string e)
        {
            switch (e)
            {
                case "none":
                    return VACANCY_EDUCATION_LEVEL.NO_MATTER;
                case "school":
                    return VACANCY_EDUCATION_LEVEL.MEDIUM;
                case "college":
                    return VACANCY_EDUCATION_LEVEL.SPECIAL_MEDIUM;
                case "half high":
                    return VACANCY_EDUCATION_LEVEL.HIGH_NOT_ENDED;
                case "high":
                    return VACANCY_EDUCATION_LEVEL.HIGH;
                default:
                    return VACANCY_EDUCATION_LEVEL.UNKNOWN;
            }
        }

        public static string EducationFromIdRu(VACANCY_EDUCATION_LEVEL e)
        {
            switch (e)
            {
                case VACANCY_EDUCATION_LEVEL.NO_MATTER:
                    return "Без разницы";
                case VACANCY_EDUCATION_LEVEL.MEDIUM:
                    return "Среднее";
                case VACANCY_EDUCATION_LEVEL.SPECIAL_MEDIUM:
                    return "Среднее специальное";
                case VACANCY_EDUCATION_LEVEL.HIGH_NOT_ENDED:
                    return "Неоконченное высшее";
                case VACANCY_EDUCATION_LEVEL.HIGH:
                    return "Высшее";
                default:
                    return "";
            }
        }

        public static string EducationFromIdUz(VACANCY_EDUCATION_LEVEL e)
        {
            switch (e)
            {
                case VACANCY_EDUCATION_LEVEL.NO_MATTER:
                    return "Farqsiz";
                case VACANCY_EDUCATION_LEVEL.MEDIUM:
                    return "O'rta";
                case VACANCY_EDUCATION_LEVEL.SPECIAL_MEDIUM:
                    return "O'rta maxsus";
                case VACANCY_EDUCATION_LEVEL.HIGH_NOT_ENDED:
                    return "Tugallanmagan oliy";
                case VACANCY_EDUCATION_LEVEL.HIGH:
                    return "Oliy";
                default:
                    return "";
            }
        }
    }
}
