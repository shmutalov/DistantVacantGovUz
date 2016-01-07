using System.Security.Principal;
using System.Reflection;
using System.IO;

namespace DistantVacantGovUzDocAssociate
{
    public static class Program
    {
        /// <summary>
        /// Получить путь к директории где распаложено приложение DistantVacantGovUz.exe
        /// </summary>
        /// <returns>Возвратит полный путь без завершающего слеша в конце имени</returns>
        private static string GetApplicationDirectory()
        {
            return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        }

        public static void Main(string[] args)
        {
            var pricipal = new WindowsPrincipal(WindowsIdentity.GetCurrent());
            var hasAdministrativeRight = pricipal.IsInRole(WindowsBuiltInRole.Administrator);

            if (!hasAdministrativeRight)
                return;

            FileAssociation.Associate(".vac", "DISTANT.VACANCIES", "Distant Vacancies document", null, GetApplicationDirectory() + "\\DistantVacantGovUzLauncher.exe");
            FileAssociation.Associate(".vacx", "DISTANT.VACANCIESX", "Distant Vacancies document", null, GetApplicationDirectory() + "\\DistantVacantGovUzLauncher.exe");
        }
    }
}
