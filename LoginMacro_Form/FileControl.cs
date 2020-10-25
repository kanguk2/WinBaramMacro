using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.IO;
using System.Web.Script.Serialization;

namespace LoginMacro_Form
{
    class FileControl
    {
        private string strFileName_ID;
        private string strFileName_Command;

        private const string strRegSubKey = "FilePath";

        public FileControl()
        {
            strFileName_ID = RegistryControl.readReg(strRegSubKey, "ID");
            if (strFileName_ID == "")
            {
                strFileName_ID = "D:\\Kanguk\\Game\\IDDatas.json";
            }

            strFileName_Command = RegistryControl.readReg(strRegSubKey, "Command");
            if (strFileName_Command == "")
            {
                strFileName_Command = "D:\\Kanguk\\Game\\CommandDatas.json";
            }
        }

        public void ChangeFileID(string strID)
        {
            strFileName_ID = strID;
        }

        public void ChangeFileCommand(string strCommand)
        {
            strFileName_Command = strCommand;
        }

        public string GetIDFilePath()
        {
            return strFileName_ID;
        }

        public void LoadData(ref IDData_KANG idData)
        {
            try
            {
                idData.getDataTable().Clear();

                string json = File.ReadAllText(strFileName_ID);

                JObject applyJObj = JObject.Parse(json);

                foreach (var data in applyJObj)
                {
                    Datas tmp = new Datas { strPW = data.Value["strPW"].ToString(), nPID = (int)data.Value["nPID"], nGroup = (int)data.Value["nGroup"] };

                    idData.LoadData(ref tmp);

                    idData.Add(data.Key, tmp);
                }

                RegistryControl.writeReg(strRegSubKey, "ID", strFileName_ID);
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
            }

        }

        public void SaveData(IDData_KANG iDData)
        {
            try
            {
                string json = JsonConvert.SerializeObject(iDData.getDataTable(), Newtonsoft.Json.Formatting.Indented);

                File.WriteAllText(strFileName_ID, json);
            }
            catch (Exception)
            {

            }
        }

        public bool LoadData(ref List<CommandDatas> commanddatas)
        {
            bool bRet = true;
            try
            {
                commanddatas.Clear();

                string strFullPath = strFileName_Command;

                if (File.Exists(strFullPath) == false)
                {
                    throw new Exception();
                }
                string json = File.ReadAllText(strFullPath);

                commanddatas = JsonConvert.DeserializeObject<List<CommandDatas>>(json);

                RegistryControl.writeReg(strRegSubKey, "Command", strFileName_Command);
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
                bRet = false;
            }

            return bRet;
        }

        public void SaveData(List<CommandDatas> commanddatas)
        {
            try
            {
                string json = JsonConvert.SerializeObject(commanddatas, Newtonsoft.Json.Formatting.Indented);

                File.WriteAllText(strFileName_Command, json);

            }
            catch (Exception)
            {

            }
        }

        public static string getFilePathFromDialog()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.DefaultExt = "bmp";
            ofd.ShowDialog();
            if(ofd.FileName.Length > 0)
            {
                return ofd.FileName;
            }

            return null;
        }
    }
}
