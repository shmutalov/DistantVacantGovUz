using DistantVacantGovUz.Enums;

namespace DistantVacantGovUz.Models
{
    /// <summary>
    /// Класс объекта "Вакансия"
    /// </summary>
    public class Vacancy
    {
        public readonly string StrDescriptionRu;
        public readonly string StrDescriptionUz;
        public readonly VacancyCategory Category;
        public readonly string StrSalary;
        public readonly VacancyEmployment Employment;
        public readonly VacancyGender Gender;
        public readonly VacancyExperience Experience;
        public readonly VacancyEducationLevel EducatonLevel;
        public readonly string ExpireDate;
        public VacancyStatus Status;
        public readonly string DepartmentRu;
        public readonly string DepartmentUz;
        public readonly string SpecializationRu;
        public readonly string SpecializationUz;
        public readonly string RequirementsRu;
        public readonly string RequirementsUz;
        public readonly string InformationRu;
        public readonly string InformationUz;
        public string Id;

        /// <summary>
        /// Инициализация всех свойств вакансии
        /// </summary>
        /// <param name="descriptionRu">Русское наименование</param>
        /// <param name="descriptionUz">Узбекское наименование (латинскими буквами)</param>
        /// <param name="category">Категория</param>
        /// <param name="salary">Заработная плата</param>
        /// <param name="employment">Занятость</param>
        /// <param name="gender">Пол</param>
        /// <param name="experience">Необходимый стаж</param>
        /// <param name="education">Образование</param>
        /// <param name="expireDate">Действителен до</param>
        /// <param name="status">Статус</param>
        /// <param name="departmentRu">Отдел / Подразделение (Русский)</param>
        /// <param name="departmentUz">Отдел / Подразделение (Узбекский)</param>
        /// <param name="specializationRu">Функциональность (Русский)</param>
        /// <param name="specializationUz">Функциональность (Узбекский)</param>
        /// <param name="requirementsRu">Требования (Русский)</param>
        /// <param name="requirementsUz">Требования (Узбекский)</param>
        /// <param name="informationRu">Дополнительные информации (Русский)</param>
        /// <param name="informationUz">Дополнительные информации (Узбекский)</param>
        /// <param name="id">ID вакансии на портале</param>
        private Vacancy(string descriptionRu
            , string descriptionUz
            , VacancyCategory category
            , string salary
            , VacancyEmployment employment
            , VacancyGender gender
            , VacancyExperience experience
            , VacancyEducationLevel education
            , string expireDate
            , VacancyStatus status
            , string departmentRu
            , string departmentUz
            , string specializationRu
            , string specializationUz
            , string requirementsRu
            , string requirementsUz
            , string informationRu
            , string informationUz
            , string id)
        {
            StrDescriptionRu = descriptionRu;
            StrDescriptionUz = descriptionUz;
            Category = category;
            StrSalary = salary;
            Employment = employment;
            Gender = gender;
            Experience = experience;
            EducatonLevel = education;
            ExpireDate = expireDate;
            Status = status;
            DepartmentRu = departmentRu;
            DepartmentUz = departmentUz;
            SpecializationRu = specializationRu;
            SpecializationUz = specializationUz;
            RequirementsRu = requirementsRu;
            RequirementsUz = requirementsUz;
            InformationRu = informationRu;
            InformationUz = informationUz;
            Id = id;
        }

        /// <summary>
        /// Инициализация всех свойств вакансии (без ID вакансии портала)
        /// </summary>
        /// <param name="descriptionRu">Русское наименование</param>
        /// <param name="descriptionUz">Узбекское наименование (латинскими буквами)</param>
        /// <param name="category">Категория</param>
        /// <param name="salary">Заработная плата</param>
        /// <param name="employment">Занятость</param>
        /// <param name="gender">Пол</param>
        /// <param name="experience">Необходимый стаж</param>
        /// <param name="education">Образование</param>
        /// <param name="expireDate">Действителен до</param>
        /// <param name="status">Статус</param>
        /// <param name="departmentRu">Отдел / Подразделение (Русский)</param>
        /// <param name="departmentUz">Отдел / Подразделение (Узбекский)</param>
        /// <param name="specializationRu">Функциональность (Русский)</param>
        /// <param name="specializationUz">Функциональность (Узбекский)</param>
        /// <param name="requirementsRu">Требования (Русский)</param>
        /// <param name="requirementsUz">Требования (Узбекский)</param>
        /// <param name="informationRu">Дополнительные информации (Русский)</param>
        /// <param name="informationUz">Дополнительные информации (Узбекский)</param>
        public Vacancy(string descriptionRu, string descriptionUz, 
            VacancyCategory category, 
            string salary, 
            VacancyEmployment employment,
            VacancyGender gender, 
            VacancyExperience experience,
            VacancyEducationLevel education, 
            string expireDate, 
            VacancyStatus status, 
            string departmentRu, string departmentUz, 
            string specializationRu, string specializationUz, 
            string requirementsRu, string requirementsUz, 
            string informationRu, string informationUz)
            : this(descriptionRu, descriptionUz,
                 category,
                 salary,
                 employment,
                 gender,
                 experience,
                 education,
                 expireDate,
                 status,
                 departmentRu, departmentUz,
                 specializationRu, specializationUz,
                 requirementsRu, requirementsUz,
                 informationRu, informationUz,
                 string.Empty)
        {

        }

        public static string StatusFromIdRu(VacancyStatus s)
        {
            switch (s)
            {
                case VacancyStatus.Open:
                    return "Актуальный";
                case VacancyStatus.Closed:
                    return "Неактуальный";
                default:
                    return string.Empty;
            }
        }

        public static string StatusFromIdUz(VacancyStatus s)
        {
            switch (s)
            {
                case VacancyStatus.Open:
                    return "Aktual";
                case VacancyStatus.Closed:
                    return "Noaktual";
                default:
                    return string.Empty;
            }
        }

        public static string StatusId(VacancyStatus s)
        {
            switch (s)
            {
                case VacancyStatus.Open:
                    return "open";
                case VacancyStatus.Closed:
                    return "closed";
                default:
                    return string.Empty;
            }
        }

        public static VacancyStatus StatusIdFromValue(string s)
        {
            switch (s)
            {
                case "open":
                    return VacancyStatus.Open;
                case "closed":
                    return VacancyStatus.Closed;
                default:
                    return VacancyStatus.Unknown;
            }
        }

        public static int CategoryId(VacancyCategory c)
        {
            switch (c)
            {
                case VacancyCategory.ItInternetTelekom: return 1;
                case VacancyCategory.GosudarstvennayaSlujba: return 2;
                case VacancyCategory.IskusstvoKultura: return 3;
                case VacancyCategory.KorporativniyeUslugi: return 4;
                case VacancyCategory.MarketingReklama: return 5;
                case VacancyCategory.Media: return 6;
                case VacancyCategory.MedicinaZdravooxraneniyeFarmacevtika: return 7;
                case VacancyCategory.Nedvijimost: return 8;
                case VacancyCategory.NekommercheskiyeOrganizacii: return 9;
                case VacancyCategory.ObrazovaniyeNauka: return 10;
                case VacancyCategory.PolezniyeIskopayemiyeDobichaSirya: return 11;
                case VacancyCategory.Promishlennost: return 12;
                case VacancyCategory.RazvlecheniyaOtdixSportKrasota: return 13;
                case VacancyCategory.SelskoyeXozyaystvo: return 14;
                case VacancyCategory.Stroitelstvo: return 15;
                case VacancyCategory.TovariNarodnogoPotrebleniya: return 16;
                case VacancyCategory.Torgovlya: return 17;
                case VacancyCategory.TransportLogistikaAvtomobilniyBiznes: return 18;
                case VacancyCategory.FinansiBankiInvesticiiLizing: return 19;
                case VacancyCategory.EkologiyaZashitaOkrujayusheySredi: return 20;
                case VacancyCategory.YuridicheskayaSlujba: return 21;
                case VacancyCategory.Antikvariat: return 22;
                case VacancyCategory.BuxgalteriyaUpravlencheskiyUchetFinansiPredpriyatiya: return 23;
                case VacancyCategory.AdministrativniyPersonal: return 24;
                case VacancyCategory.UpravleniyePersonalomTreningi: return 25;
                case VacancyCategory.Bezopasnost: return 26;
                case VacancyCategory.VisshiyMenedjment: return 27;
                case VacancyCategory.Konsultirovaniye: return 28;
                case VacancyCategory.Straxovaniye: return 29;
                default:
                    return 0;
            }
        }

        public static VacancyCategory CategoryIdFromOptionValue(string c)
        {
            switch (c)
            {
                case "1":
                    return VacancyCategory.ItInternetTelekom;
                case "2":
                    return VacancyCategory.GosudarstvennayaSlujba;
                case "3":
                    return VacancyCategory.IskusstvoKultura;
                case "4":
                    return VacancyCategory.KorporativniyeUslugi;
                case "5":
                    return VacancyCategory.MarketingReklama;
                case "6":
                    return VacancyCategory.Media;
                case "7":
                    return VacancyCategory.MedicinaZdravooxraneniyeFarmacevtika;
                case "8":
                    return VacancyCategory.Nedvijimost;
                case "9":
                    return VacancyCategory.NekommercheskiyeOrganizacii;
                case "10":
                    return VacancyCategory.ObrazovaniyeNauka;
                case "11":
                    return VacancyCategory.PolezniyeIskopayemiyeDobichaSirya;
                case "12":
                    return VacancyCategory.Promishlennost;
                case "13":
                    return VacancyCategory.RazvlecheniyaOtdixSportKrasota;
                case "14":
                    return VacancyCategory.SelskoyeXozyaystvo;
                case "15":
                    return VacancyCategory.Stroitelstvo;
                case "16":
                    return VacancyCategory.TovariNarodnogoPotrebleniya;
                case "17":
                    return VacancyCategory.Torgovlya;
                case "18":
                    return VacancyCategory.TransportLogistikaAvtomobilniyBiznes;
                case "19":
                    return VacancyCategory.FinansiBankiInvesticiiLizing;
                case "20":
                    return VacancyCategory.EkologiyaZashitaOkrujayusheySredi;
                case "21":
                    return VacancyCategory.YuridicheskayaSlujba;
                case "22":
                    return VacancyCategory.Antikvariat;
                case "23":
                    return VacancyCategory.BuxgalteriyaUpravlencheskiyUchetFinansiPredpriyatiya;
                case "24":
                    return VacancyCategory.AdministrativniyPersonal;
                case "25":
                    return VacancyCategory.UpravleniyePersonalomTreningi;
                case "26":
                    return VacancyCategory.Bezopasnost;
                case "27":
                    return VacancyCategory.VisshiyMenedjment;
                case "28":
                    return VacancyCategory.Konsultirovaniye;
                case "29":
                    return VacancyCategory.Straxovaniye;
                default:
                    return VacancyCategory.Unknown;
            }
        }

        public static string CategoryFromIdRu(VacancyCategory c)
        {
            switch (c)
            {
                case VacancyCategory.ItInternetTelekom: return @"IT / Интернет / Телеком";
                case VacancyCategory.GosudarstvennayaSlujba: return @"Государственная служба";
                case VacancyCategory.IskusstvoKultura: return @"Искусство / Культура";
                case VacancyCategory.KorporativniyeUslugi: return @"Корпоративные услуги";
                case VacancyCategory.MarketingReklama: return @"Маркетинг / Реклама / PR";
                case VacancyCategory.Media: return @"Медиа";
                case VacancyCategory.MedicinaZdravooxraneniyeFarmacevtika: return @"Медицина / Здравоохранение / Фармацевтика";
                case VacancyCategory.Nedvijimost: return @"Недвижимость";
                case VacancyCategory.NekommercheskiyeOrganizacii: return @"Некоммерческие организации";
                case VacancyCategory.ObrazovaniyeNauka: return @"Образование / Наука";
                case VacancyCategory.PolezniyeIskopayemiyeDobichaSirya: return @"Полезные ископаемые / Добыча сырья";
                case VacancyCategory.Promishlennost: return @"Промышленность";
                case VacancyCategory.RazvlecheniyaOtdixSportKrasota: return @"Развлечения / Отдых / Спорт / Красота";
                case VacancyCategory.SelskoyeXozyaystvo: return @"Сельское хозяйство";
                case VacancyCategory.Stroitelstvo: return @"Строительство";
                case VacancyCategory.TovariNarodnogoPotrebleniya: return @"Товары народного потребления";
                case VacancyCategory.Torgovlya: return @"Торговля";
                case VacancyCategory.TransportLogistikaAvtomobilniyBiznes: return @"Транспорт / Логистика / Автомобильный бизнес";
                case VacancyCategory.FinansiBankiInvesticiiLizing: return @"Финансы / Банки / Инвестиции / Лизинг";
                case VacancyCategory.EkologiyaZashitaOkrujayusheySredi: return @"Экология / Защита окружающей среды";
                case VacancyCategory.YuridicheskayaSlujba: return @"Юридическая служба";
                case VacancyCategory.Antikvariat: return @"Антиквариат";
                case VacancyCategory.BuxgalteriyaUpravlencheskiyUchetFinansiPredpriyatiya: return @"Бухгалтерия / Управленческий учет / Финансы предприятия";
                case VacancyCategory.AdministrativniyPersonal: return @"Административный персонал";
                case VacancyCategory.UpravleniyePersonalomTreningi: return @"Управление персоналом / Тренинги";
                case VacancyCategory.Bezopasnost: return @"Безопасность";
                case VacancyCategory.VisshiyMenedjment: return @"Высший менеджмент";
                case VacancyCategory.Konsultirovaniye: return @"Консультирование";
                case VacancyCategory.Straxovaniye: return @"Страхование";
                default:
                    return string.Empty;
            }
        }

        public static string CategoryFromIdUz(VacancyCategory c)
        {
            switch (c)
            {
                case VacancyCategory.ItInternetTelekom: return @"IT / Internet / Telekom";
                case VacancyCategory.GosudarstvennayaSlujba: return @"Davlat xizmati";
                case VacancyCategory.IskusstvoKultura: return @"San'at / Madaniyat";
                case VacancyCategory.KorporativniyeUslugi: return @"Korporativ xizmatlar";
                case VacancyCategory.MarketingReklama: return @"Marketing / Reklama / PR";
                case VacancyCategory.Media: return @"Media";
                case VacancyCategory.MedicinaZdravooxraneniyeFarmacevtika: return @"Tibbiyot / Sog'liqni saqlash / Farmatsevtika";
                case VacancyCategory.Nedvijimost: return @"Ko'chmas mulk";
                case VacancyCategory.NekommercheskiyeOrganizacii: return @"Notijorat tashkilotlar";
                case VacancyCategory.ObrazovaniyeNauka: return @"Ta'lim / Fan";
                case VacancyCategory.PolezniyeIskopayemiyeDobichaSirya: return @"Foydali qazilmalar / Yer osti boyliklarni qazib olish";
                case VacancyCategory.Promishlennost: return @"Sanoat";
                case VacancyCategory.RazvlecheniyaOtdixSportKrasota: return @"Sayr-tomosha / Dam olish / Sport / Go'zallik";
                case VacancyCategory.SelskoyeXozyaystvo: return @"Qishloq xo'jaligi";
                case VacancyCategory.Stroitelstvo: return @"Qurilish";
                case VacancyCategory.TovariNarodnogoPotrebleniya: return @"Aholi ist'emol mollari";
                case VacancyCategory.Torgovlya: return @"Savdo sotiq";
                case VacancyCategory.TransportLogistikaAvtomobilniyBiznes: return @"Transport / Logistika / Avtomobilga oid tadbirkorlik";
                case VacancyCategory.FinansiBankiInvesticiiLizing: return @"Moliya / Banklar / Investitsiya / Lizing";
                case VacancyCategory.EkologiyaZashitaOkrujayusheySredi: return @"Ekologiya / Atrofni muhofaza qilish markazlari";
                case VacancyCategory.YuridicheskayaSlujba: return @"Yuridik xizmat";
                case VacancyCategory.Antikvariat: return @"Nodir buyumlar ";
                case VacancyCategory.BuxgalteriyaUpravlencheskiyUchetFinansiPredpriyatiya: return @"Buxgalteriya / Boshqarmaga oid ro'yxat / Moliya davlat korxonasi";
                case VacancyCategory.AdministrativniyPersonal: return @"Ma'muriyat hodimi";
                case VacancyCategory.UpravleniyePersonalomTreningi: return @"Hodimlarni boshqarish / Trening";
                case VacancyCategory.Bezopasnost: return @"Xavfsizlik";
                case VacancyCategory.VisshiyMenedjment: return @"Oliy menejment";
                case VacancyCategory.Konsultirovaniye: return @"Maslaxatlar";
                case VacancyCategory.Straxovaniye: return @"Sugu'urta";
                default:
                    return string.Empty;
            }
        }

        public static string GenderId(VacancyGender g)
        {
            switch (g)
            {
                case VacancyGender.NoMatter:
                    return "N";
                case VacancyGender.Male:
                    return "M";
                case VacancyGender.Female:
                    return "F";
                default:
                    return string.Empty;
            }
        }

        public static VacancyGender GenderFromOptionValue(string g)
        {
            switch (g)
            {
                case "N":
                    return VacancyGender.NoMatter;
                case "M":
                    return VacancyGender.Male;
                case "F":
                    return VacancyGender.Female;
                default:
                    return VacancyGender.Unknown;
            }
        }

        public static string GenderFromIdRu(VacancyGender g)
        {
            switch (g)
            {
                case VacancyGender.NoMatter:
                    return "Без разницы";
                case VacancyGender.Male:
                    return "Мужской";
                case VacancyGender.Female:
                    return "Женский";
                default:
                    return string.Empty;
            }
        }

        public static string GenderFromIdUz(VacancyGender g)
        {
            switch (g)
            {
                case VacancyGender.NoMatter:
                    return "Farqsiz";
                case VacancyGender.Male:
                    return "Erkak";
                case VacancyGender.Female:
                    return "Ayol";
                default:
                    return string.Empty;
            }
        }

        public static string EmploymentId(VacancyEmployment e)
        {
            switch (e)
            {
                case VacancyEmployment.NoMatter:
                    return "none";
                case VacancyEmployment.Full:
                    return "full";
                case VacancyEmployment.Part:
                    return "part";
                case VacancyEmployment.Freelance:
                    return "freelance";
                case VacancyEmployment.Combined:
                    return "sov";
                default:
                    return string.Empty;
            }
        }

        public static VacancyEmployment EmploymentIdFromOptionValue(string e)
        {
            switch (e)
            {
                case "none":
                    return VacancyEmployment.NoMatter;
                case "full":
                    return VacancyEmployment.Full;
                case "part":
                    return VacancyEmployment.Part;
                case "freelance":
                    return VacancyEmployment.Freelance;
                case "sov":
                    return VacancyEmployment.Combined;
                default:
                    return VacancyEmployment.Unknown;
            }
        }

        public static string EmploymentFromIdRu(VacancyEmployment e)
        {
            switch (e)
            {
                case VacancyEmployment.NoMatter:
                    return "Без разницы";
                case VacancyEmployment.Full:
                    return "Полная";
                case VacancyEmployment.Part:
                    return "Частичная";
                case VacancyEmployment.Freelance:
                    return "Фриланс";
                case VacancyEmployment.Combined:
                    return "Совместительство";
                default:
                    return string.Empty;
            }
        }

        public static string EmploymentFromIdUz(VacancyEmployment e)
        {
            switch (e)
            {
                case VacancyEmployment.NoMatter:
                    return "Farqsiz";
                case VacancyEmployment.Full:
                    return "To'liq";
                case VacancyEmployment.Part:
                    return "To'liqsiz";
                case VacancyEmployment.Freelance:
                    return "Frilans";
                case VacancyEmployment.Combined:
                    return "O'rindoshlik asosida";
                default:
                    return string.Empty;
            }
        }

        public static string ExperienceId(VacancyExperience e)
        {
            switch (e)
            {
                case VacancyExperience.NoMatter:
                    return "none";
                case VacancyExperience.OneYear:
                    return "one year";
                case VacancyExperience.TwoYears:
                    return "two years";
                case VacancyExperience.ThreeYears:
                    //return "three years";                 // Bug on Portal. Someone doesn't know english numbers )
                    return "tree years";
                //case VACANCY_EXPERIENCE.FOUR_YEARS:
                //    return "four years";
                case VacancyExperience.FiveAndMoreYears:
                    return "five etc";
                default:
                    return string.Empty;
            }
        }

        public static VacancyExperience ExperienceIdFromOptionValue(string e)
        {
            switch (e)
            {
                case "none":
                    return VacancyExperience.NoMatter;
                case "one year":
                    return VacancyExperience.OneYear;
                case "two years":
                    return VacancyExperience.TwoYears;
                case "tree years":                          // Bug on Portal. Someone doesn't know english numbers )
                case "three years":
                    return VacancyExperience.ThreeYears;
                case "five etc":
                    return VacancyExperience.FiveAndMoreYears;
                default:
                    return VacancyExperience.Unknown;
            }
        }

        public static string ExperienceFromIdRu(VacancyExperience e)
        {
            switch (e)
            {
                case VacancyExperience.NoMatter:
                    return "Без разницы";
                case VacancyExperience.OneYear:
                    return "От одного года";
                case VacancyExperience.TwoYears:
                    return "От двух лет";
                case VacancyExperience.ThreeYears:
                    return "От трех лет";
                //case VACANCY_EXPERIENCE.FOUR_YEARS:
                //    return "four years";
                case VacancyExperience.FiveAndMoreYears:
                    return "Пять и более лет";
                default:
                    return string.Empty;
            }
        }

        public static string ExperienceFromIdUz(VacancyExperience e)
        {
            switch (e)
            {
                case VacancyExperience.NoMatter:
                    return "Farqsiz";
                case VacancyExperience.OneYear:
                    return "Bir yil";
                case VacancyExperience.TwoYears:
                    return "Ikki yil";
                case VacancyExperience.ThreeYears:
                    return "Uch yil";
                //case VACANCY_EXPERIENCE.FOUR_YEARS:
                //    return "four years";
                case VacancyExperience.FiveAndMoreYears:
                    return "Besh yil va undan ko'p";
                default:
                    return string.Empty;
            }
        }

        public static string EducationId(VacancyEducationLevel e)
        {
            switch (e)
            {
                case VacancyEducationLevel.NoMatter:
                    return "none";
                case VacancyEducationLevel.Medium:
                    return "school";
                case VacancyEducationLevel.SpecialMedium:
                    return "college";
                case VacancyEducationLevel.HighNotEnded:
                    return "half high";
                case VacancyEducationLevel.High:
                    return "high";
                default:
                    return string.Empty;
            }
        }

        public static VacancyEducationLevel EducationIdFromOptionValue(string e)
        {
            switch (e)
            {
                case "none":
                    return VacancyEducationLevel.NoMatter;
                case "school":
                    return VacancyEducationLevel.Medium;
                case "college":
                    return VacancyEducationLevel.SpecialMedium;
                case "half high":
                    return VacancyEducationLevel.HighNotEnded;
                case "high":
                    return VacancyEducationLevel.High;
                default:
                    return VacancyEducationLevel.Unknown;
            }
        }

        public static string EducationFromIdRu(VacancyEducationLevel e)
        {
            switch (e)
            {
                case VacancyEducationLevel.NoMatter:
                    return "Без разницы";
                case VacancyEducationLevel.Medium:
                    return "Среднее";
                case VacancyEducationLevel.SpecialMedium:
                    return "Среднее специальное";
                case VacancyEducationLevel.HighNotEnded:
                    return "Неоконченное высшее";
                case VacancyEducationLevel.High:
                    return "Высшее";
                default:
                    return string.Empty;
            }
        }

        public static string EducationFromIdUz(VacancyEducationLevel e)
        {
            switch (e)
            {
                case VacancyEducationLevel.NoMatter:
                    return "Farqsiz";
                case VacancyEducationLevel.Medium:
                    return "O'rta";
                case VacancyEducationLevel.SpecialMedium:
                    return "O'rta maxsus";
                case VacancyEducationLevel.HighNotEnded:
                    return "Tugallanmagan oliy";
                case VacancyEducationLevel.High:
                    return "Oliy";
                default:
                    return string.Empty;
            }
        }
    }
}
