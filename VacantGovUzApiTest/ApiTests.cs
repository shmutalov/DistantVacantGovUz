using System;
using DistantVacantGovUz;
using NUnit.Framework;

namespace VacantGovUzApiTest
{
    [TestFixture]
    public class ApiTests
    {
        private const string TestUserName = "okboss";
        private const string TestUserPassowrd = "man2011";

        [Test]
        public void TestLogin()
        {
            var api = new VacantGovUzApi();

            Assert.IsTrue(api.Login(TestUserName, TestUserPassowrd));
        }

        [Test]
        public void TestLogout()
        {
            var api = new VacantGovUzApi();

            Assert.IsTrue(api.Login(TestUserName, TestUserPassowrd));
            api.Logout();
        }

        [Test]
        public void TestGetOpenVacancies()
        {
            var api = new VacantGovUzApi();

            api.Login(TestUserName, TestUserPassowrd);

            var vacancies = api.GetOpenVacancies();

            Assert.IsNotNull(vacancies);
            Assert.IsTrue(vacancies.Count > 0);

            Console.WriteLine(@"Retreived {0} open vacancies", vacancies.Count);
        }

        [Test]
        public void TestGetClosedVacancies()
        {
            var api = new VacantGovUzApi();

            api.Login(TestUserName, TestUserPassowrd);

            var vacancies = api.GetClosedVacancies();

            Assert.IsNotNull(vacancies);
            Assert.IsTrue(vacancies.Count > 0);

            Console.WriteLine(@"Retreived {0} closed vacancies", vacancies.Count);
        }

        [Test]
        public void TestGetOpenVacancy()
        {
            var api = new VacantGovUzApi();

            api.Login(TestUserName, TestUserPassowrd);

            var vacancy = api.GetVacancy(api.GetOpenVacancies()[0].Id);
            
            Assert.IsNotNull(vacancy);
            Console.WriteLine(vacancy.DescriptionRu);
        }

        [Test]
        public void TestGetClosedVacancy()
        {
            var api = new VacantGovUzApi();

            api.Login(TestUserName, TestUserPassowrd);

            var vacancy = api.GetVacancy(api.GetClosedVacancies()[0].Id);

            Assert.IsNotNull(vacancy);
            Console.WriteLine(vacancy.DescriptionRu);
        }

        [Test]
        public void TestGetCaptcha()
        {
            var api = new VacantGovUzApi();

            api.Login(TestUserName, TestUserPassowrd);

            var captcha = api.GetCapcha();

            Assert.IsNotNull(captcha);
            Assert.IsTrue(captcha.Length > 0);
        }
    }
}
