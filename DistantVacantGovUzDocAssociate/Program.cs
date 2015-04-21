using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Principal;
using System.Diagnostics;
using System.Reflection;
using System.ComponentModel;
using System.IO;

namespace DistantVacantGovUzDocAssociate
{
    class Program
    {
        /// <summary>
        /// Получить путь к директории где распаложено приложение DistantVacantGovUz.exe
        /// </summary>
        /// <returns>Возвратит полный путь без завершающего слеша в конце имени</returns>
        public static string GetApplicationDirectory()
        {
            return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        }

        static void Main(string[] args)
        {
            WindowsPrincipal pricipal = new WindowsPrincipal(WindowsIdentity.GetCurrent());
            bool hasAdministrativeRight = pricipal.IsInRole(WindowsBuiltInRole.Administrator);

            if (hasAdministrativeRight)
            {
                FileAssociation.Associate(".vac", "DISTANT.VACANCIES", "Distant Vacancies document", null, GetApplicationDirectory() + "\\DistantVacantGovUzLauncher.exe");
                FileAssociation.Associate(".vacx", "DISTANT.VACANCIESX", "Distant Vacancies document", null, GetApplicationDirectory() + "\\DistantVacantGovUzLauncher.exe");
            }
            else
                return;
        }
    }
}
