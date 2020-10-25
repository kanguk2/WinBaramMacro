using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace LoginMacro_Form
{
    class RegistryControl
    {
        static string m_strSubKey;
        static RegistryControl()
        {
            m_strSubKey = "Software\\KangUkReg";
            RegistryKey rKey = Registry.CurrentUser.OpenSubKey(m_strSubKey);
            
            if (rKey == null)
                rKey = Registry.CurrentUser.CreateSubKey(m_strSubKey, true);
        }

        public static void writeReg(string strSubKey, string strKeyName, string value)
        {
            RegistryKey rKey = Registry.CurrentUser.OpenSubKey(m_strSubKey).OpenSubKey(strSubKey, true);

            if (rKey == null)
            {
                rKey = Registry.CurrentUser.OpenSubKey(m_strSubKey, true).CreateSubKey(strSubKey, true);
            }
            rKey.SetValue(strKeyName, value);
        }

        public static string readReg(string strSubkey, string strKeyName)
        {
            RegistryKey rKey = Registry.CurrentUser.OpenSubKey(m_strSubKey).OpenSubKey(strSubkey, true);

            if (rKey == null || rKey.GetValue(strKeyName) == null)
                return "";

            return rKey.GetValue(strKeyName).ToString();
        }

    }
}
