using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LoginMacro_Form
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Rect
    {
        public int left;
        public int top;
        public int right;
        public int bottom;
    }
    
    public class Datas
    {
        public string strPW
        {
            set;
            get;
        }
        public string strSTATE
        {
            set;
            get;
        }

        public int nPID
        {
            set;
            get;
        }

        public Rect rect;
        public int nGroup
        {
            set;
            get;
        }
    }

    public class IDData_KANG
    {
        private DataTable dataTable = new DataTable();
        // 컬럼 생성
        public IDData_KANG()
        {
            dataTable = new DataTable();
        }

        public Dictionary<string, Datas> getDataTable() { return Dic_Datas; }

        public Dictionary<string, Datas> Dic_Datas = new Dictionary<string, Datas>();

        public bool Add(string strID, Datas data)
        {
            if (Dic_Datas.ContainsKey(strID))
                return false;

            Dic_Datas.Add(strID, data);

            return true;
        }
        
        public void Delete(string strID)
        {
            if (Dic_Datas.Count() == 0 || Dic_Datas.ContainsKey(strID) == false)
                return;

            Dic_Datas.Remove(strID);
        }

        public void LoadData(ref Datas data)
        {
            CheckState(ProcessControl.CheckProcess(data.nPID), ref data);
        }

        public void CheckState(Boolean bConnect, ref Datas data)
        {
            data.strSTATE = bConnect ? "연결됨" : "연결안됨";
            if (bConnect == false)
                data.nPID = -1;
        }
    }
}