namespace DistantVacantGovUz.Constants
{
    /// <summary>
    /// 
    /// </summary>
    public static class VacantGovUzUrls
    {
        public const string IdUzLoginUrl = @"https://www.id.uz/users/login/authenticate?token=";
        public const string VacantGovUzLoginUrl = @"http://vacant.gov.uz/site/login";

        public const string IdUzLogoutUrl = @"https://www.id.uz/users/login/logout";
        public const string VacantGovUzLogoutUrl = @"http://vacant.gov.uz/ru/site/logout";

        public const string MainPageUrl = @"http://vacant.gov.uz";
        public const string IdUzDefaultPageUrl = @"https://www.id.uz/users/personalinfo/edit";

        public const string OpenVacanciesUrl = @"http://vacant.gov.uz/ru/vacancies/admin";
        public const string ClosedVacanciesUrl = @"http://vacant.gov.uz/ru/vacancies/Cadmin";
        public const string CreateVacancyUrl = @"http://vacant.gov.uz/ru/vacancies/create";

        public const string ReceivedResumesUrl = @"http://vacant.gov.uz/ru/request/received";
        public const string ApprovedResumesUrl = @"http://vacant.gov.uz/ru/request/approved";
        public const string ProcessedResumesUrl = @"http://vacant.gov.uz/ru/request/processed";
        public const string ReservedResumesUrl = @"http://vacant.gov.uz/ru/request/reserved";

        public const string AddVacancyUrl = @"http://vacant.gov.uz/ru/vacancies/create";
        public const string EditVacancyUrl = @"http://vacant.gov.uz/ru/vacancies/update";

        public const string RefreshCaptchaUrl = @"http://vacant.gov.uz/ru/site/captcha?refresh=1&_=";
        public const string CaptchaImageUrl = @"http://vacant.gov.uz/ru/site/captcha?v=";
    }
}
