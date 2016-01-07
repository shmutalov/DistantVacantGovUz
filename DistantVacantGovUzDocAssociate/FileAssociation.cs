using System;
using System.Text;
using Microsoft.Win32;
using System.Runtime.InteropServices;

namespace DistantVacantGovUzDocAssociate
{
    public static class FileAssociation
    {
        /// <summary>
        /// Associate file extension with progID, description, icon and application
        /// </summary>
        /// <param name="extension"></param>
        /// <param name="progId"></param>
        /// <param name="description"></param>
        /// <param name="icon"></param>
        /// <param name="application"></param>
        public static void Associate(
            string extension, 
            string progId, 
            string description, 
            string icon, 
            string application)
        {
            try
            {
                //key = Registry.CurrentUser.OpenSubKey("Software").OpenSubKey("Classes");
                var key = Registry.ClassesRoot;
                key.CreateSubKey(extension).SetValue("", progId);

                if (string.IsNullOrEmpty(progId))
                    return;

                using (var k = key.CreateSubKey(progId))
                {
                    if (description != null)
                        k.SetValue("", description);
                    if (icon != null)
                        k.CreateSubKey("DefaultIcon").SetValue("", ToShortPathName(icon));
                    if (application != null)
                        k.CreateSubKey(@"Shell\Open\Command").SetValue("",
                            ToShortPathName(application) + " \"%1\"");
                }
            }
            catch (Exception)
            {
                // ignore
            }
        }

        [DllImport("Kernel32.dll")]
        private static extern uint GetShortPathName(string lpszLongPath,
            [Out] StringBuilder lpszShortPath, uint cchBuffer);

        // Return short path format of a file name
        private static string ToShortPathName(string longName)
        {
            var s = new StringBuilder(1000);
            var iSize = (uint)s.Capacity;
            GetShortPathName(longName, s, iSize);

            return s.ToString();
        }
    }
}


