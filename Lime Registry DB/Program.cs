using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lime_Registry_DB
{
    class Program
    {
        private static readonly string ID = "ClientID";


        /*
         * Author       : NYAN CAT
         * Name         : Lime Registry DB
         * Contact Me   : https:github.com/NYAN-x-CAT
         * This program is distributed for educational purposes only.
         */


        static void Main()
        {
            //HKEY_CURRENT_USER/ClientID
            SetValue("startup", "1"); // Add new settings
            Console.ReadKey();

            Console.WriteLine(GetValue("startup")); // Read it
            Console.ReadKey();

            DeleteValue("startup"); // Delete it
            Console.ReadKey();

            DeleteSubKey(); // Delete the whole key
            Console.ReadKey();
        }

        public static bool SetValue(string name, string value)
        {
            try
            {
                using (RegistryKey key = Registry.CurrentUser.CreateSubKey(ID, RegistryKeyPermissionCheck.ReadWriteSubTree))
                {
                    key.SetValue(name, value, RegistryValueKind.String);
                    return true;
                }
            }
            catch { }
            return false;
        }

        public static string GetValue(string value)
        {
            try
            {
                using (RegistryKey key = Registry.CurrentUser.CreateSubKey(ID))
                {
                    object o = key.GetValue(value);
                    return (string)o;
                }
            }
            catch { }
            return null;
        }

        public static bool DeleteValue(string name)
        {
            try
            {
                using (RegistryKey key = Registry.CurrentUser.CreateSubKey(ID))
                {
                    key.DeleteValue(name);
                    return true;
                }
            }
            catch { }
            return false;
        }

        public static bool DeleteSubKey()
        {
            try
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey("", true))
                {
                    key.DeleteSubKeyTree(ID);
                    return true;
                }
            }
            catch { }
            return false;
        }
    }
}
