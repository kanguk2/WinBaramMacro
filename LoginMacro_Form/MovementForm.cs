using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginMacro_Form
{
    public partial class MovementForm : Form
    {
        private IDData_KANG IDDatas;
        private FileControl FC;
        private DataTable IDDataTable = new DataTable();
        private DataTable CommandDataTable = new DataTable();
        private List<CommandDatas> commanddatas = new List<CommandDatas>();

        private Log Log_move;

        public MovementForm(ref IDData_KANG IDDatas)
        {
            this.IDDatas = IDDatas;
            InitializeComponent();
            FC = new FileControl();
            InitIDInfo_Grid();
            InitCommand_Grid();
            Log_move = new Log(ref textBox_Log);
        }
        
        private void InitIDInfo_Grid()
        {
            IDDataTable.Columns.Add("ID");
            IDDataTable.Columns.Add("Group");
            IDDataTable.Columns[0].ReadOnly = true;
            IDDataTable.Columns[1].ReadOnly = true;

            DataGridViewButtonColumn BTDisplay = new DataGridViewButtonColumn();
            BTDisplay.HeaderText = "";
            BTDisplay.Name = "BTDisplay";
            BTDisplay.Text = "보기";
            BTDisplay.UseColumnTextForButtonValue = true;

            dataGridView_IDInfo.CellClick += new DataGridViewCellEventHandler(BTDisplay_Click);

            try
            {
                foreach (KeyValuePair<string, Datas> items in IDDatas.getDataTable())
                {
                    if(items.Value.strSTATE == "연결됨")
                        IDDataTable.Rows.Add(items.Key, items.Value.nGroup);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
            }

            this.dataGridView_IDInfo.DataSource = this.IDDataTable;

            this.dataGridView_IDInfo.Columns.Add(BTDisplay);
            this.dataGridView_IDInfo.Columns["ID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridView_IDInfo.Columns["Group"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridView_IDInfo.Columns["BTDisplay"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        }

        private void BTDisplay_Click(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0 || e.ColumnIndex !=
                    dataGridView_IDInfo.Columns["BTDisplay"].Index) return;

                int nIndex = e.RowIndex;

                string strID = GetDataGridSelectID(nIndex);

                ProcessControl.Display(GetDataGridSelectPID(nIndex));

                //This is the code which will show the button click row data. Thank you.
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void InitCommand_Grid()
        {
            try
            {
                CommandDataTable.Columns.Add("명령어");

                DataGridViewButtonColumn BTSingle = new DataGridViewButtonColumn();
                BTSingle.HeaderText = "";
                BTSingle.Name = "수행";
                BTSingle.Text = "명령수행";
                BTSingle.UseColumnTextForButtonValue = true;

                DataGridViewComboBoxColumn  cCell = new DataGridViewComboBoxColumn();
                cCell.HeaderText = "ID";
                cCell.Name = "ID";
                cCell.DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton;

                foreach (string strID in this.IDDatas.getDataTable().Keys)
                    cCell.Items.Add(strID);


                this.dataGridView_Command.DataSource = this.CommandDataTable;

                Init_CommandRow();

                dataGridView_Command.Columns.Add(BTSingle);
                dataGridView_Command.CellClick += new DataGridViewCellEventHandler(CommandInput);
                dataGridView_Command.Columns.Add(cCell);

                this.dataGridView_Command.Columns["명령어"].Width = (int)(this.dataGridView_Command.Width * 0.6);
                this.dataGridView_Command.Columns["수행"].Width = (int)(this.dataGridView_Command.Width * 0.15);
                this.dataGridView_Command.Columns["ID"].Width = (int)(this.dataGridView_Command.Width * 0.15);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
            }
        }

        private void Init_CommandRow()
        {
            try
            {
                this.CommandDataTable.Clear();

                if (FC.LoadData(ref commanddatas) == true)
                {
                    foreach (CommandDatas data in commanddatas)
                    {
                        CommandDataTable.Rows.Add(data.strCommand);
                    }
                }
                else
                    commanddatas = new List<CommandDatas>();
            }
            catch(Exception e) { Log_move.Format(e.ToString()); }            
        }


        private void CommandInput(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0 || e.ColumnIndex !=
                    dataGridView_Command.Columns["수행"].Index) return;

                int nIndex = e.RowIndex;
                int nIdIndex = dataGridView_IDInfo.CurrentCell.RowIndex;

                CommandInput(nIndex, dataGridView_Command.Rows[nIndex].Cells["ID"].Value.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void CommandInput(int nIndex, string strID)
        {
            if (strID == "" || IDDatas.getDataTable()[strID].nPID == -1)
                return;

            string strInput = dataGridView_Command.Rows[nIndex].Cells["명령어"].Value.ToString();

            ProcessControl.Display(IDDatas.getDataTable()[strID].nPID);

            if (stringParser.CommandJudge(strInput) == false)
                return;

            SendKeys.SendWait(strInput);

            Log_move.Format(strID + ": " + strInput + "수행");
        }


        public string GetDataGridSelectID(int nSel)
        {
            try
            {
                return dataGridView_IDInfo.Rows[nSel].Cells["ID"].Value.ToString();
            }
            catch (Exception) { }

            return null;
        }

        private int GetDataGridSelectPID(int nSel)
        {
            try
            {
                string strID = dataGridView_IDInfo.Rows[nSel].Cells["ID"].Value.ToString();
                return IDDatas.getDataTable()[strID].nPID;
            }
            catch (Exception) { }

            return -1;
        }


        private void button_IDDataSave_Click(object sender, EventArgs e)
        {
            TableToCommandData();
            FC.SaveData(commanddatas);
        }

        private void TableToCommandData()
        {
            try
            {
                commanddatas.Clear();
                for (int i = 0; i < CommandDataTable.Rows.Count; i++)
                {
                    commanddatas.Add(new CommandDatas { strCommand = dataGridView_Command.Rows[i].Cells["명령어"].Value.ToString() });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button_test_Click(object sender, EventArgs e)
        {
            try
            {
                for (int nIndex = 0; nIndex < dataGridView_IDInfo.Rows.Count; nIndex++)
                {
                    if (dataGridView_IDInfo.Rows[nIndex].Selected == false)
                        continue;

                    if (IDDatas.getDataTable()[GetDataGridSelectID(nIndex)].nPID == -1)
                        continue;

                    eventMove(nIndex);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void eventMove(int nIndex)
        {
            string strID = GetDataGridSelectID(nIndex);

            string strPlace = textBox_place.Text;

            int iPos = 0;
            for (iPos = 0; iPos < PLACE.strPLACE.Length; iPos++)
            {
                if (strPlace == PLACE.strPLACE[iPos])
                    break;
            }

            if (iPos >= PLACE.strPLACE.Length)
            {
                Log_move.Format($"{strID} 이동실패 : 장소를 잘못 입력하셨습니다");
                return;
            }

            ProcessControl.Display(IDDatas.getDataTable()[strID].nPID);

            if (iPos >= 10)
            {
                SendKeys.SendWait("01{enter}");
                SendKeys.SendWait("ZX");

                iPos -= 10;
            }

            SendKeys.SendWait("{enter}귀환{enter}");
            Thread.Sleep(300);

            for (int i = 0; i < iPos + 1; i++)
            {
                ProcessControl.keyInput(Keys.Down, 10);
            }

            SendKeys.SendWait("{enter}01{enter}");

            Log_move.Format($"{strID} : {strPlace} 이동완료.");
        }

        private void button_CommandDelete_Click(object sender, EventArgs e)
        {
            CommandRowDelete(dataGridView_Command.CurrentCell.RowIndex);
        }

        private void CommandRowDelete(int nIndex)
        {
            try
            {
                dataGridView_Command.Rows.RemoveAt(nIndex);
                commanddatas.RemoveAt(nIndex);
            }
            catch (Exception ex)
            {
                Log_move.Format(ex.ToString());
            }
        }

        private void button_return_Click(object sender, EventArgs e)
        {
            try
            {
                int nIdIndex = dataGridView_IDInfo.CurrentCell.RowIndex;
                string strID = GetDataGridSelectID(nIdIndex);

                string strPlace = textBox_place.Text;

                int iPos = 0;
                for (iPos = 0; iPos < PLACE.strPLACE.Length; iPos++)
                {
                    if (strPlace == PLACE.strPLACE[iPos])
                        break;
                }

                if (iPos >= PLACE.strPLACE.Length)
                {
                    Log_move.Format($"{strID} 복귀실패 : 장소를 잘못 입력하셨습니다.");
                    throw new Exception();
                }

                ProcessControl.Display(IDDatas.getDataTable()[strID].nPID);

                Log_move.Format($"{strID} : {PLACE.strPLACE[iPos]} 에서 복귀시작");

                SendKeys.SendWait("04{enter}");

                if (iPos >= 10)
                {
                    string str = $"9굴{PLACE.strPLACE[iPos][0]}"+ "{enter}";
                    SendKeys.SendWait(str);
                }
                else
                {
                    SendKeys.SendWait("9조그만삐삐{enter}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button_SelCommand_Click(object sender, EventArgs e)
        {
            try
            {
                string strPreID = "", strCurID = "";
                for (int nIndex = 0; nIndex < dataGridView_Command.Rows.Count; nIndex++)
                {
                    if (dataGridView_Command.Rows[nIndex].Selected == false)
                        continue;

                    if (IDDatas.getDataTable()[GetDataGridSelectID(nIndex)].nPID == -1)
                        continue;

                    strCurID = dataGridView_Command.Rows[nIndex].Cells["ID"].Value.ToString();

                    if (strPreID == strCurID)
                        Thread.Sleep(300);

                    CommandInput(nIndex, strCurID);
                    strPreID = strCurID;
                }
            }
            catch (Exception)
            {
            }
        }

        private void button_IDDataLoad_Click(object sender, EventArgs e)
        {
            string strFileFullName = FileControl.getFilePathFromDialog();

            if (strFileFullName == null)
                return;

            CommandDataTable.Rows.Clear();

            FC.ChangeFileCommand(strFileFullName);
            Init_CommandRow();
        }

        private void button_AddCommand_Click(object sender, EventArgs e)
        {
            try
            {
                int nIndex = CommandDataTable.Rows.Count - 1;

                string strCommand;
                strCommand = CommandDataTable.Rows[nIndex]["명령어"].ToString();

                if (strCommand == "" || stringParser.CommandJudge(strCommand) == false)
                {
                    MessageBox.Show("명령어를 다시 확인해주세요.");
                    return;
                }
                commanddatas.Add(new CommandDatas { strCommand = strCommand });
            }
            catch (Exception ex)
            {
                Log_move.Format(ex.ToString());
            }
        }
    }
}
