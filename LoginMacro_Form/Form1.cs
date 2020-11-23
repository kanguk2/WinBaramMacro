
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenCvSharp;
using Tesseract;

namespace LoginMacro_Form
{
    public partial class Form1 : Form
    {
        private static IDData_KANG IDDatas = new IDData_KANG();
        private DataTable IDDataTable = new DataTable();

        private static FileControl FC = new FileControl();
        private static ImageProc imageproc = new ImageProc();
        private object lockObject = new object();
        private Thread Thread_LE;
        private Thread Thread_MultiLE;
        private Thread Thread_Refresh;
        private Log logs;

        private MovementForm Form_MF;
        private ImageControlForm Form_ICF;

        public Form1()
        {
            InitializeComponent();

            textBox_FilePath.Text = "C:\\Program Files(x86)\\boolhongserver\\winbaram.exe";

            InitGridDataView();

            logs = new Log(ref textBox_Log);

            Thread_Refresh = new Thread(new ThreadStart(ThreadRefresh));
            Thread_Refresh.Start();

            button_LoginStop.Enabled = false;
        }
        
        private void UICheck()
        {
            try
            {
                if (this.InvokeRequired == false)
                {
                    bool bStatus = (Thread_LE == null && Thread_MultiLE == null);

                    if ((Thread_LE != null && Thread_LE.IsAlive) && (Thread_MultiLE == null || Thread_MultiLE.IsAlive == false))
                        button_LoginStop.Enabled = true;

                    if (Thread_LE == null || Thread_LE.IsAlive == false)
                        button_LoginStop.Enabled = false;

                    if (Thread_LE != null)
                        bStatus = !Thread_LE.IsAlive;

                    if (Thread_MultiLE != null)
                        bStatus = !Thread_MultiLE.IsAlive;

                    this.button_multiExecute.Text = bStatus ? "선택셀 실행" : "전체 중지";

                    dataGridView_Info.Enabled = bStatus;
                    button_FilePath.Enabled = bStatus;
                    button_test.Enabled = bStatus;
                    button_FornIC.Enabled = bStatus;
                    button_test.Enabled = bStatus;
                }
                else
                {
                    var d =
                        Invoke((MethodInvoker)delegate () {
                            UICheck();
                        });
                }
            }
            catch (Exception ex)
            {
                logs.Format(ex.ToString());
            }
            
        }

        private void button_FilePath_Click(object sender, EventArgs e)
        {
            string filePath = FileControl.getFilePathFromDialog();

            if (filePath != null)
                textBox_FilePath.Text = filePath;
        }

        private void InitGridDataView()
        {
            DataGridViewButtonColumn BTSingle = new DataGridViewButtonColumn();
            BTSingle.HeaderText = "개별실행";
            BTSingle.Name = "Single Execute";
            BTSingle.Text = "실행";
            BTSingle.UseColumnTextForButtonValue = true;

            DataGridViewButtonColumn BTExit = new DataGridViewButtonColumn();
            BTExit.HeaderText = "개별종료";
            BTExit.Name = "Exit Program";
            BTExit.Text = "종료";
            BTExit.UseColumnTextForButtonValue = true;

            IDDataTable.Columns.Add("ID");
            IDDataTable.Columns.Add("PW");
            IDDataTable.Columns.Add("STATE");
            IDDataTable.Columns["STATE"].ReadOnly = true;
            IDDataTable.Columns.Add("GROUP", typeof(int));

            InitIDInfoRow();

            this.dataGridView_Info.DataSource = this.IDDataTable;
            this.dataGridView_Info.Columns["GROUP"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            dataGridView_Info.Columns.Add(BTSingle);
            dataGridView_Info.Columns.Add(BTExit);

            dataGridView_Info.CellClick += new DataGridViewCellEventHandler(SingleExecute);
            dataGridView_Info.CellClick += new DataGridViewCellEventHandler(SingleKillProcess);
        }

        private void InitIDInfoRow()
        {
            try
            {
                FC.LoadData(ref IDDatas);
                textBox_IDFilePath.Text = FC.GetIDFilePath();
                foreach (KeyValuePair<string, Datas> items in IDDatas.getDataTable())
                {
                    IDDataTable.Rows.Add(items.Key, items.Value.strPW, items.Value.strSTATE, items.Value.nGroup);
                }
            }
            catch (Exception e)
            {
                logs.Format(e.ToString());
            }
        }

        public void ThreadNewSequence(int nIndex, eSeq_Login eSL = eSeq_Login.LoginExecute, Boolean bSingle = false)
        {
            lock (lockObject)
            {
                string strID = GetDataGridSelectID(nIndex);
                Thread_Refresh.Suspend();
                logs.Format($"{strID} : 로그인 시작");
                
                int nID = -1;
                bool bRet = true;
                int nTry = 0;
                try
                {
                    string strError = "Error!! : ";
                    while (eSL != eSeq_Login.LoginComplete)
                    {
                        switch (eSL)
                        {
                            case eSeq_Login.LoginExecute:
                                bRet = ExecuteProgram(ref nID);
                                break;
                            case eSeq_Login.LoginConnect:
                                bRet = ConnectProgram(nID);
                                break;
                            case eSeq_Login.LoginSelectServer:
                                bRet = SelectSeverProgram(nID);
                                break;
                            case eSeq_Login.LoginAgree:
                                bRet = AgreeProgram(nID);
                                break;
                            case eSeq_Login.LoginInputInfo:
                                bRet = InputInfoProgram(nIndex, nID);
                                break;
                            case eSeq_Login.LoginFinalCheck:
                                Thread.Sleep(200);
                                bRet = !ReconnectCheck(nID);
                                break;
                            case eSeq_Login.LoginError:
                                throw new Exception(strError);
                        }
                        if (bRet == false)
                        {
                            if(eSL != eSeq_Login.LoginError && nTry++ < 2)
                                eSL = ErrorCheck(nID, strID);
                            else
                            {
                                strError += eSL.ToString();
                                eSL = eSeq_Login.LoginError;
                                ProcessControl.KillProcess(nID);
                            }
                        }
                        else
                            eSL++;
                    }

                    if (eSL == eSeq_Login.LoginComplete)
                    {
                        IDDatas.getDataTable()[strID].nPID = nID;
                        DataTableToDicData();

                        ProcessControl.MiniMizedProcess(nID);
                    }
                }
                catch (ThreadInterruptedException e)
                {
                    ProcessControl.KillProcess(nID);
                    logs.Format($"{strID} : 로그인 중지");
                }
                catch (Exception e)
                {
                    ProcessControl.KillProcess(nID);
                    logs.Format(e.ToString());
                }
                finally
                {
                    Thread_Refresh.Resume();
                    logs.Format($"{strID} : 로그인 {((bRet) ? "성공" : "실패")}");
                }
            }
        }

        private eSeq_Login ErrorCheck(int nID, string strID)
        {
            eSeq_Login retSeq = eSeq_Login.LoginError;

            try
            {
                if (ReconnectCheck(nID))
                {
                    ProcessControl.keyInput(Keys.Enter, 100);
                    logs.Format($"{strID} : Reconnect 확인 재시도..");
                    Thread.Sleep(3000);
                    bool bCheck = ImageCompareSeq($"{ImageProc.m_strLogin}2.bmp", eImagetype.total, nID, 5, 500);
                    retSeq = bCheck ? eSeq_Login.LoginSelectServer : eSeq_Login.LoginError;

                    return retSeq;
                }

                if (Connectingcheck(nID))
                {
                    ProcessControl.keyInput(Keys.Enter, 250);
                    ProcessControl.keyInput(Keys.Escape, 250);
                    ProcessControl.keyInput(Keys.Enter, 100);

                    logs.Format($"{strID} : Input 정보 재입력..");

                    return eSeq_Login.LoginInputInfo;
                }
            }
            catch (Exception ex)
            {
                retSeq = eSeq_Login.LoginError;
            }

            return retSeq;
        }

        private bool ExecuteProgram(ref int nID, bool bNew = false)
        {
            bool bRet = false;
            try
            {
                Process temp = new Process();
                ProcessControl.executeFile(ref temp, textBox_FilePath.Text.ToString());
                nID = temp.Id;

                if(bNew == false)
                    bRet = ImageCompareSeq($"{ImageProc.m_strLogin}1.bmp", eImagetype.total, nID);
            }
            catch (Exception e) 
            { 
                bRet = false;
            }
            return bRet;
        }

        private bool ConnectProgram(int nID, bool bNew = false)
        {
            bool bRet = true;
            try
            {
                int nTry = 0;

                if (bNew == false)
                    Thread.Sleep(1200); // 어떻게 할수가없음.

                ProcessControl.Display(nID, true);
                do
                {
                    ProcessControl.keyInput(Keys.Tab);
                    ProcessControl.keyInput(Keys.Tab);

                    if (bNew == false)
                    {
                        ProcessControl.keyInput(Keys.Enter, 1500);
                        bRet = ImageProc.ImageCompare($"{ImageProc.m_strLogin}2.bmp", new Bitmap(ImageProc.ImageCrop(nID, eImagetype.total)));
                    }
                    else
                        ProcessControl.keyInput(Keys.Enter, 100);

                    if (bRet == true)
                        break;
                } while (nTry++ < 5);
            }
            catch (Exception e) 
            {
                bRet = false; 
            }

            return bRet;
        }
        private bool SelectSeverProgram(int nID, bool bNew = false)
        {
            bool bRet = true;
            try
            {
                ProcessControl.keyInput(Keys.Down);
                if (bNew == false)
                {
                    ProcessControl.keyInput(Keys.Enter, 1000);
                    bRet = ImageCompareSeq($"{ImageProc.m_strLogin}3.bmp", eImagetype.total, nID);
                }
                else
                    ProcessControl.keyInput(Keys.Enter, 100);
            }
            catch (Exception e) { bRet = false; }

            return bRet;
        }

        private bool AgreeProgram(int nID, bool bNew = false)
        {
            bool bRet = false;
            try
            {
                ProcessControl.keyInput(Keys.Enter, 100);
                ProcessControl.keyInput(Keys.A, 100);

                if (bNew == false && ImageCompareSeq($"{ImageProc.m_strLogin}이미접속중.bmp", eImagetype.total, nID, 2, 100))
                    ProcessControl.keyInput(Keys.Enter, 100);

                ProcessControl.keyInput(Keys.Enter, 100);

                if (bNew == false)
                   bRet = ImageCompareSeq($"{ImageProc.m_strLogin}4.bmp", eImagetype.total, nID);
            }
            catch (Exception e) 
            {
                bRet = false; 
            }

            return bRet;
        }

        private bool ImageCompareSeq(string strPath, eImagetype imagetype, int nID, int nTry = 10, int nSleepTime = 100)
        {
            bool bRet = false;

            try
            {
                int n =0;

                do
                {
                    bRet = ImageProc.ImageCompare(strPath, new Bitmap(ImageProc.ImageCrop(nID, imagetype)));

                    if (bRet == true)
                        break;
                    Thread.Sleep(nSleepTime);//Task.Delay(1000);
                } while (n++ < nTry);
            }
            catch(Exception e) { bRet = false; }

            return bRet;
        }

        private bool InputInfoProgram(int nIndex, int nID, bool bNew = false)
        {
            bool bRet = false;
            try
            {
                string strID = GetDataGridSelectID(nIndex);

                SendKeys.SendWait(dataGridView_Info.Rows[nIndex].Cells["ID"].Value.ToString());
                ProcessControl.keyInput(Keys.Tab, 250);

                SendKeys.SendWait(dataGridView_Info.Rows[nIndex].Cells["PW"].Value.ToString());

                ProcessControl.keyInput(Keys.Enter);

                int nTry = 0;

                do
                {
                    Image img_capture = ImageProc.ImageCrop(nID, eImagetype.name);
                    string strFilePath = $"{ImageProc.m_strIDInfo}{GetDataGridSelectID(nIndex)}.bmp";
                    if (File.Exists(strFilePath) == false)
                    {
                        logs.Format("이미지 없음 저장필요");
                        bRet = true;

                        Thread.Sleep(500);
                        Connectingcheck(nID);
                        Thread.Sleep(500);
                    }
                    else if (bNew == false)
                        bRet = ImageProc.ImageCompare(strFilePath, new Bitmap(img_capture));
                    else if (bNew == true)
                        bRet = true;

                    if (bRet == true)
                        break;
                    else
                        Connectingcheck(nID);

                    Thread.Sleep(200);//Task.Delay(1000);
                } while (nTry++ < 13);
            }
            catch (Exception e)
            {
                bRet = false;
            }

            return bRet;
        }

        private bool ReconnectCheck(int nID)
        {
            bool bReconnect = true;
            try
            {
                Image img_capture = ImageProc.ImageCrop(nID, eImagetype.total);
                string strFilePath = $"{ImageProc.m_strLogin}연결해제.bmp";

                bReconnect = ImageProc.ImageCompare(strFilePath, new Bitmap(img_capture));
            }
            catch (Exception e) { }

            return bReconnect;
        }

        private bool Connectingcheck(int nID)
        {
            bool bConnecting = false;
            try
            {
                string strFilePath = $"{ImageProc.m_strLogin}6.bmp";
                Image img_Connecting = ImageProc.ImageCrop(nID, eImagetype.isconnected);
                bConnecting = ImageProc.ImageCompare(strFilePath, new Bitmap(img_Connecting));

                if (bConnecting)
                {
                    ProcessControl.keyInput(Keys.Enter);
                    ProcessControl.keyInput(Keys.Enter, 400);
                }
            }
            catch (Exception e) { }

            return bConnecting;
        }

        private void ChangeTextRow(int nIndex, Boolean bConnect)
        {
            if (this.InvokeRequired == false)
            {
                IDDataTable.Columns["STATE"].ReadOnly = false;
                IDDataTable.Rows[nIndex]["STATE"] = bConnect ? "연결됨" : "연결안됨";
                IDDatas.getDataTable()[GetDataGridSelectID(nIndex)].strSTATE = bConnect ? "연결됨" : "연결안됨";
                IDDataTable.Columns["STATE"].ReadOnly = true;

                if (Form_MF != null && Form_MF.IsHandleCreated == true)
                {
                    Form_MF.Init_IDRow();
                }
                if (Form_ICF != null && Form_ICF.IsHandleCreated == true)
                {
                    Form_ICF.InitRow();
                }
            }
            else
            {
                var d =
                    Invoke((MethodInvoker)delegate () {
                        ChangeTextRow(nIndex, bConnect);
                    });
            }
        }

        private void ThreadMultiExecute()
        {
            try
            {
                for (int nIndex = 0; nIndex < IDDatas.getDataTable().Count; nIndex++)
                {
                    if (dataGridView_Info.Rows[nIndex].Selected == false)
                        continue;

                    if (IDDatas.getDataTable()[GetDataGridSelectID(nIndex)].nPID != -1)
                        ProcessControl.Display(IDDatas.getDataTable()[GetDataGridSelectID(nIndex)].nPID);
                    else
                    {
                        Thread_LE = new Thread(() => ThreadNewSequence(nIndex)) { IsBackground = false };
                        Thread_LE.Start();
                        Thread_LE.Join();
                    }
                }
            }
            catch (ThreadInterruptedException ex)
            {
                Thread_LE.Interrupt();
                Thread_LE = null;
                logs.Format("멀티실행 중지");
            }
            catch (Exception)
            {
            }
        }

        private void NewMultiThread()
        {
            try
            {
                List<int> list_ID = new List<int>();
                List<string> list_strID = new List<string>();
                for (int n = 0; n < dataGridView_Info.SelectedRows.Count; n++)
                {
                    int nIndex = dataGridView_Info.SelectedRows[n].Index; 
                    if (IDDatas.getDataTable()[GetDataGridSelectID(nIndex)].nPID != -1)
                        continue;

                    list_ID.Add(nIndex);
                    list_strID.Add(GetDataGridSelectID(nIndex));
                }

                Thread_MultiLE = new Thread(() => ThreadNewSequence(list_ID, list_strID)) { IsBackground = false };
                Thread_MultiLE.Start();
            }
            catch (ThreadInterruptedException ex)
            {
                if(Thread_MultiLE != null && Thread_MultiLE.IsAlive)
                    Thread_MultiLE.Interrupt();

                Thread_MultiLE = null;
                logs.Format("멀티실행 중지");
            }
            catch (Exception)
            {
            }
        }

        public void ThreadNewSequence(List<int> list_ID, List<string> list_strID)
        {
            lock (lockObject)
            {
                Thread_Refresh.Suspend();
                logs.Format("멀티로그인 시작");

                eSeq_Login eSL = eSeq_Login.LoginExecute;
                int[] nNeedTime = { 1500, 1500, 1200, 500, 700, 0};

                Stopwatch sw;
                try
                {
                    while (eSL != eSeq_Login.LoginComplete)
                    {
                        sw = Stopwatch.StartNew();
                        string strID;
                        int nID;
                        for (int n = 0; n < list_ID.Count(); n++)
                        {
                            strID = list_strID[n];
                            nID = IDDatas.getDataTable()[strID].nPID;
                            if (eSL != eSeq_Login.LoginExecute)
                            {
                                ProcessControl.Display(nID);
                                Thread.Sleep(450);
                            }
                            else
                                Thread.Sleep(1400);

                            switch (eSL)
                            {
                                case eSeq_Login.LoginExecute:
                                    ExecuteProgram(ref nID, true);
                                    IDDatas.getDataTable()[strID].nPID = nID;
                                    break;
                                case eSeq_Login.LoginConnect:
                                    ConnectProgram(nID, true);
                                    break;
                                case eSeq_Login.LoginSelectServer:
                                    SelectSeverProgram(nID, true);
                                    break;
                                case eSeq_Login.LoginAgree:
                                    AgreeProgram(nID, true);
                                    InputInfoProgram(list_ID[n], nID, true);
                                    break;
                                case eSeq_Login.LoginFinalCheck:
                                    if (ReconnectCheck(nID) || Connectingcheck(nID) || 
                                        !ImageCompareSeq($"{ImageProc.m_strIDInfo}{strID}.bmp", eImagetype.name, nID, 1, 50))
                                    {
                                        ProcessControl.KillProcess(nID);
                                        IDDatas.getDataTable()[strID].nPID = -1;
                                        logs.Format($"{strID} : 로그인실패");
                                    }
                                    else
                                        ProcessControl.MiniMizedProcess(nID);
                                    break;
                            }
                        }

                        sw.Stop();
                        long lTime = sw.ElapsedMilliseconds;
                        int nDelay = (int)(nNeedTime[(int)eSL] - lTime);
                        Thread.Sleep((int)Math.Max(0, nDelay));
                        sw.Reset();
                        if (eSL == eSeq_Login.LoginAgree)
                            eSL++;
                        eSL++;
                    }
                }
                catch (Exception e)
                {
                    logs.Format(e.ToString());
                }
                finally
                {
                    Thread_Refresh.Resume();
                    logs.Format($"멀티로그인 완료");
                }
            }
        }

        private void ThreadRefresh()
        {
            try
            {
                while (true)
                {
                    lock (lockObject)
                    {
                        
                        int nIndex = 0;
                        foreach (var data in IDDatas.getDataTable())
                        {
                            Refresh(nIndex++);
                        }

                        UICheck();

                    }
                    Thread.Sleep(50);
                }
            }
            catch (Exception)
            {

            }
        }

        private void Refresh(int nIndex)
        {
            try
            {
                Datas tmp_data = IDDatas.getDataTable()[IDDataTable.Rows[nIndex]["ID"].ToString()];

                //현재 Process Check.
                bool bCheck = ProcessControl.CheckProcess(tmp_data.nPID);

                //이전 Process Check.
                bool preProcessCheck = (IDDataTable.Rows[nIndex]["STATE"].ToString() == "연결됨");

                if (bCheck != preProcessCheck)
                {
                    ChangeTextRow(nIndex, bCheck);

                    if (bCheck == false)
                    {
                        IDDatas.getDataTable()[IDDataTable.Rows[nIndex]["ID"].ToString()].nPID = -1;
                    }
                }
            }
            catch (Exception){ }
        }

        private void SingleExecute(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0 || e.ColumnIndex !=
                    dataGridView_Info.Columns["Single Execute"].Index) return;

                int nIndex = e.RowIndex;

                if (IDDatas.getDataTable()[GetDataGridSelectID(nIndex)].nPID != -1)
                    ProcessControl.Display(IDDatas.getDataTable()[GetDataGridSelectID(nIndex)].nPID);
                else
                {
                    Thread_LE = new Thread(() => ThreadNewSequence(nIndex, eSeq_Login.LoginExecute, true));
                    Thread_LE.Start();
                }
                //This is the code which will show the button click row data. Thank you.
            }
            catch (Exception ex)
            {
                logs.Format(ex.ToString());
            }
        }

        private void SingleKillProcess(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0 || e.ColumnIndex !=
                    dataGridView_Info.Columns["Exit Program"].Index) return;

                int nIndex = e.RowIndex;
                string strID = dataGridView_Info.Rows[nIndex].Cells["ID"].Value.ToString();

                int nID = IDDatas.getDataTable()[strID].nPID;

                if (nID != -1)
                {
                    ProcessControl.KillProcess(nID);
                    IDDatas.getDataTable()[strID].nPID = -1;
                    ChangeTextRow(nIndex, false);
                }

                //This is the code which will show the button click row data. Thank you.
            }
            catch (Exception ex)
            {
                logs.Format(ex.ToString()); 
            }
        }

        public  string GetDataGridSelectID(int nSel)
        {
            try
            {
                return dataGridView_Info.Rows[nSel].Cells["ID"].Value.ToString(); 
            }
            catch (Exception) { }

            return null;
        }

        private int GetDataGridSelectPID(int nSel)
        {
            try
            {
                string strID = dataGridView_Info.Rows[nSel].Cells["ID"].Value.ToString();
                return IDDatas.getDataTable()[strID].nPID;
            }
            catch (Exception) { }

            return -1;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Thread_LE != null && Thread_LE.IsAlive)
                Thread_LE.Interrupt();

            Thread_LE = null;

            if (Thread_MultiLE != null && Thread_MultiLE.IsAlive)
                Thread_MultiLE.Interrupt();
            Thread_MultiLE = null;

            if (Thread_Refresh != null && Thread_Refresh.IsAlive)
                Thread_Refresh.Interrupt();

            Thread_Refresh = null;

            Thread_LE = null;
        }

        private void button_multiExecute_Click(object sender, EventArgs e)
        {
            try
            {
                if (Thread_MultiLE == null || Thread_MultiLE.IsAlive == false)
                {
                    Thread_MultiLE = new Thread(() => ThreadMultiExecute());
                    Thread_MultiLE.Start();
                }
                else
                {
                    Thread_MultiLE.Interrupt();
                    Thread_MultiLE = null;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
            }
        }
  
        private void button_test_Click(object sender, EventArgs e)
        {
            NewMultiThread();
        }

        private void button_FornIC_Click(object sender, EventArgs e)
        {

            if (Form_ICF != null && Form_ICF.IsHandleCreated == true)
            {
                ProcessControl.ForegroundProcess(Form_ICF.Handle);
                return;
            }

            Form_ICF = new ImageControlForm(ref IDDatas);
            Form_ICF.Show();
        }

        private void button_Movement_Click(object sender, EventArgs e)
        {
            if (Form_MF != null && Form_MF.IsHandleCreated == true)
            {
                ProcessControl.ForegroundProcess(Form_MF.Handle);
                return;
            }

            Form_MF = new MovementForm(ref IDDatas);
            Form_MF.Show();
        }

        private void button_IDDataSave_Click(object sender, EventArgs e)
        {
            DataTableToDicData();
            FC.SaveData(IDDatas);
        }
        private void DataTableToDicData()
        {
            int nIndex = 0;

            string strID, strPW;
            int nGroup;

            foreach (var data in IDDatas.getDataTable())
            {
                strID = IDDataTable.Rows[nIndex]["ID"].ToString();
                strPW = IDDataTable.Rows[nIndex]["PW"].ToString();
                nGroup = int.Parse(IDDataTable.Rows[nIndex]["GROUP"].ToString());

                IDDatas.getDataTable()[strID].strPW = strPW;
                IDDatas.getDataTable()[strID].nGroup = nGroup;

                nIndex++;
            }

            FC.SaveData(IDDatas);
        }

        private void button_IDDataLoad_Click(object sender, EventArgs e)
        {
            try
            {
                string strFileFullName = FileControl.getFilePathFromDialog();

                if (strFileFullName == null)
                    return;

                IDDataTable.Rows.Clear();

                FC.ChangeFileID(strFileFullName);

                InitIDInfoRow();
            }
            catch (Exception ex) { logs.Format(ex.ToString()); }
        }

        private void button_AddID_Click(object sender, EventArgs e)
        {
            try
            {
                int nIndex = IDDataTable.Rows.Count - 1;

                string strID, strPW, strGroup;

                strID = IDDataTable.Rows[nIndex]["ID"].ToString();
                strPW = IDDataTable.Rows[nIndex]["PW"].ToString();

                if (IDDatas.getDataTable().ContainsKey(strID))
                {
                    logs.Format(strID + " 가 현재 저장되어있습니다.");
                }

                if (strID == "" || strPW == "")
                {
                    MessageBox.Show("정보를 잘못입력하셨습니다.");
                    return;
                }

                strGroup = IDDataTable.Rows[nIndex]["GROUP"].ToString();

                if (strGroup == "")
                {
                    IDDataTable.Rows[nIndex]["GROUP"] = "0";
                    strGroup = "0";
                }

                IDDatas.Add(strID, new Datas { strPW = strPW, strSTATE = "연결안됨", nPID = -1, nGroup = int.Parse(strGroup) });
            }
            catch(Exception ex)
            {
                logs.Format(ex.ToString());
            }
        }

        private void button_Refresh_Click(object sender, EventArgs e)
        {
            try
            {
                if (Thread_Refresh.IsAlive == false)
                    return;

                if (this.InvokeRequired == false)
                {
                    if (button_Refresh.Text == "새로고침 활성화")
                    {
                        Thread_Refresh.Suspend();
                        button_Refresh.Text = "새로고침 비활성화";
                    }
                    else
                    {
                        Thread_Refresh.Resume();
                        button_Refresh.Text = "새로고침 활성화";
                    }
                }
                else
                {
                    var d =
                        Invoke((MethodInvoker)delegate () {
                            button_Refresh_Click(sender, e);
                        });
                }
            }
            catch (Exception ex)
            {
                logs.Format(ex.ToString());
            }
        }


        private void button_IDDelete_Click(object sender, EventArgs e)
        {
            FuncIDDelete(dataGridView_Info.CurrentCell.RowIndex);
        }

        private void FuncIDDelete(int nIndex)
        {
            try
            {
                IDDatas.Delete(GetDataGridSelectID(nIndex));
                IDDataTable.Rows.RemoveAt(nIndex);
            }
            catch (Exception ex)
            {
                logs.Format(ex.ToString());
            }
        }

        private void button_LoginStop_Click(object sender, EventArgs e)
        {
            try
            {
                if (Thread_LE == null)
                    return;

                if (Thread_LE.IsAlive)
                {
                    Thread_LE.Interrupt();
                    Thread_LE = null;
                }
            }
            catch (Exception ex)
            {
                logs.Format(ex.ToString());
            }
        }
    }
}