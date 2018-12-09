using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;
namespace IPSS
{
    class Util
    {
        public static RegistryKey g_regKey = Registry.CurrentUser.OpenSubKey("Software\\IPSS", true);
        /////////////////////////////////////////////////////////////////////////////////////////////////
        public static void CheckRegistry()
        {
            g_regKey = Registry.CurrentUser.OpenSubKey("Software\\IPSS", true);
            if(g_regKey == null)
            {
                Registry.CurrentUser.OpenSubKey("SOFTWARE", true).CreateSubKey("IPSS");
                g_regKey = Registry.CurrentUser.OpenSubKey("Software\\IPSS", true);
            }
        }        
        /////////////////////////////////////////////////////////////////////////////////////////////////        
        public static void WriteReg(string key, object value)
        {
            CheckRegistry();
            g_regKey.SetValue(key, value);
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////        
        public static object ReadReg(string key)
        {
            if (g_regKey.GetValue(key) == null)
                return "";
            else
                return g_regKey.GetValue(key);
        }
    }
}
