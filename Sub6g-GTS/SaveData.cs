using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Sub6g_GTS
{
    class SaveData
    {

        public struct SaveData_Str
        {
            public string UEInfo_cboxs;
            public string Conf_Dl;
            public string Conf_Ul;
            public string Conf_Channel1;
            public string Conf_Channel2;
            public string Conf_Fre1;
            public string Conf_Fre2;
            public string Conf_BWl;
            public string Conf_BW2;
            public string Conf_RSER;
            public string Conf_BWPow;
            public string Conf_PushPow;
            public string Conf_ClosePow;

        }

        public static SaveData_Str savedata_g;

        public static void Save()
        {

        }
        public static void Display()
        {

        }
    }
    public class INI

    {


        [DllImport("kernel32")]

        private static extern long WritePrivateProfileString(string section, string key, string value, string filePath);


        [DllImport("kernel32")]

        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);


        /// 读ini文件

        public static string ReadIni(string section, string key)

        {

            string IniFilePath = "..//Debug//Setting.ini";

            StringBuilder temp = new StringBuilder(255);

            int i = GetPrivateProfileString(section, key, "", temp, 255, IniFilePath);

            return temp.ToString();

        }

        /// 写入ini文件

        public static void WriteIni(string section, string key, string value)

        {

            string IniFilePath = "..//Debug//Setting.ini";

            WritePrivateProfileString(section, key, value, IniFilePath);

        }
    }
}
