using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using System.Security.Permissions;

namespace DistantVacantGovUzDocAssociate
{
    public class FileAssociation
    {
        // Associate file extension with progID, description, icon and application
        public static bool Associate(string extension,
               string progID, string description, string icon, string application)
        {
            RegistryKey key;

            try
            {
                //key = Registry.CurrentUser.OpenSubKey("Software").OpenSubKey("Classes");
                key = Registry.ClassesRoot;
                key.CreateSubKey(extension).SetValue("", progID);

                if (progID != null && progID.Length > 0)
                    using (RegistryKey k = key.CreateSubKey(progID))
                    {
                        if (description != null)
                            k.SetValue("", description);
                        if (icon != null)
                            k.CreateSubKey("DefaultIcon").SetValue("", ToShortPathName(icon));
                        if (application != null)
                            k.CreateSubKey(@"Shell\Open\Command").SetValue("",
                                        ToShortPathName(application) + " \"%1\"");

                        return true;
                    }

                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        // Return true if extension already associated in registry
        public static bool IsAssociated(string extension)
        {
            RegistryKey key = null;

            try
            {
                //key = Registry.CurrentUser.OpenSubKey("Software").OpenSubKey("Classes");
                key = Registry.ClassesRoot;
                bool isExists = key.OpenSubKey(extension, false) != null;

                return isExists;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        [DllImport("Kernel32.dll")]
        private static extern uint GetShortPathName(string lpszLongPath,
            [Out] StringBuilder lpszShortPath, uint cchBuffer);

        // Return short path format of a file name
        private static string ToShortPathName(string longName)
        {
            StringBuilder s = new StringBuilder(1000);
            uint iSize = (uint)s.Capacity;
            uint iRet = GetShortPathName(longName, s, iSize);
            return s.ToString();
        }
    }
}


