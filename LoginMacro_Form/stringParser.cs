using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginMacro_Form
{
    class stringParser
    {
        public static void DivideFileFullPath(string str, ref string strPath, ref string strFileName)
        {
            int nPos = 0;
            int nLength = str.Length;

            nPos = str.LastIndexOf('\\');

            strPath = str.Substring(0, nPos);
            strFileName = str.Substring(nPos+1, nLength - nPos -1);
        }

        public static bool CommandJudge(string str)
        {
            int n = 0;
            foreach (char ch in str)
            {
                if (ch == '{') n++;
                if (ch == '}') n--;
            }

            return n == 0;
        }
    }
}
