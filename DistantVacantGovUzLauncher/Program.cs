using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Security.Principal;
using System.Diagnostics;
using System.Reflection;
using System.ComponentModel;

namespace VacancyImporterLauncher
{
    static class Program
    {
        public static String[] argv;
        public static bool isAdmin = false;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(String [] args)
        {
            argv = args;

            /*WindowsPrincipal pricipal = new WindowsPrincipal(WindowsIdentity.GetCurrent());
            bool hasAdministrativeRight = pricipal.IsInRole(WindowsBuiltInRole.Administrator);

            if (!hasAdministrativeRight)
            {
                // relaunch the application with admin rights
                string fileName = Assembly.GetExecutingAssembly().Location;
                ProcessStartInfo processInfo = new ProcessStartInfo();
                processInfo.Verb = "runas";
                processInfo.FileName = fileName;

                foreach (String arg in Program.argv)
                    processInfo.Arguments += "\"" + arg + "\" ";

                try
                {
                    Process.Start(processInfo);
                    return;
                }
                catch (Win32Exception)
                {
                    isAdmin = false;
                    // This will be thrown if the user cancels the prompt
                }

                //
            }
            else
            {
                isAdmin = true;
            }*/

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
        }
    }
}
