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
        private Thread Thread_Repeat;

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

            Init_IDRow();
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
                dataGridView_Command.CellClick += new DataGridViewCellEventHandler(CommandInput_Click);
                dataGridView_Command.Columns.Add(cCell);

                this.dataGridView_Command.Columns["명령어"].Width = (int)(this.dataGridView_Command.Width * 0.6);
                this.dataGridView_Command.Columns["수행"].Width = (int)(this.dataGridView_Command.Width * 0.15);
                this.dataGridView_Command.Columns["ID"].Width = (int)(this.dataGridView_Command.Width * 0.15);
            }
            catch (Exception e)
            {
                Log_move.Format(e.Message.ToString());
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
            catch (Exception e) { Log_move.Format(e.ToString()); }
        }


        public void Init_IDRow()
        {
            if (this.InvokeRequired == false)
            {
                try
                {
                    IDDataTable.Clear();
                    foreach (KeyValuePair<string, Datas> items in IDDatas.getDataTable())
                    {
                        if (items.Value.nPID != -1)
                            IDDataTable.Rows.Add(items.Key, items.Value.nGroup);
                    }
                }
                catch (Exception e)
                {
                    Log_move.Format(e.Message.ToString());
                }
            }
            else
            {
                var d =
                    Invoke((MethodInvoker)delegate () {
                        Init_IDRow();
                    });
            }
        }


        private void CommandInput_Click(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0 || e.ColumnIndex !=
                    dataGridView_Command.Columns["수행"].Index) return;

                int nIndex = e.RowIndex;
                int nIdIndex = dataGridView_IDInfo.CurrentCell.RowIndex;

                object ID = dataGridView_Command.Rows[nIndex].Cells["ID"].Value;//
                
                string strID = ((ID == null) ? GetDataGridSelectID(nIdIndex) : ID.ToString());

                CommandInput(nIndex, strID);//dataGridView_Command.Rows[nIndex].Cells["ID"].Value.ToString());

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

        private void button_AddID_Click(object sender, EventArgs e)
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

                this.dataGridView_Command.DataSource = this.CommandDataTable;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
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
                int nIdIndex = dataGridView_IDInfo.CurrentCell.RowIndex;

                EastMove(nIdIndex);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void EastMove(int nIndex)
        {
            string strID = GetDataGridSelectID(nIndex);

            ProcessControl.Display(IDDatas.getDataTable()[strID].nPID);
            Thread.Sleep(200);

            SendKeys.SendWait("01{enter}");

            Log_move.Format($"{strID} : 동쪽 이동");
        }

        private void button_CommandDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int nIndex = dataGridView_Command.CurrentCell.RowIndex;

                dataGridView_Command.Rows.RemoveAt(nIndex);
                commanddatas.RemoveAt(nIndex);

                this.dataGridView_Command.DataSource = this.CommandDataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button_return_Click(object sender, EventArgs e)
        {
            try
            {
                int nIdIndex = dataGridView_IDInfo.CurrentCell.RowIndex;
                string strID = GetDataGridSelectID(nIdIndex);

                string strGoID = textBox_GoID.Text;

                ProcessControl.Display(IDDatas.getDataTable()[strID].nPID);
                ProcessControl.Display(IDDatas.getDataTable()[strID].nPID);

                Log_move.Format($"{strID} {strGoID}로 출두");

                SendKeys.SendWait("04{enter}9"+strGoID+"{Enter}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button_SelCommand_Click(object sender, EventArgs e)
        {
            Execute_selectCommand();
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
        private void button_repeatExecute_Click(object sender, EventArgs e)
        {
            try
            {
                if (Thread_Repeat == null || Thread_Repeat.IsAlive == false)
                {
                    string strCount = textBox_repeatCount.Text;
                    string strInterval = textBox_repeatInterval.Text;

                    if (strCount.Length == 0 || strInterval.Length == 0)
                        throw new Exception("count or interval 정보가 잘못 입력되었습니다.");
                    
                    Thread_Repeat = new Thread(new ThreadStart(ThreadRepeatFunc));
                    Thread_Repeat.Start();
                }
                else
                {
                    Thread_Repeat.Interrupt();
                    Thread_Repeat = null;
                }
            }
            catch(Exception ex)
            {
                Log_move.Format(ex.ToString());
            }
            finally
            {
                changeUI(Thread_Repeat != null);
            }
        }

        private void changeUI(bool bStart)
        {
            //bStatus - timer가 실행중인지 여부.
            if (this.InvokeRequired == false)
            {
                button_repeatExecute.Text = (bStart) ? "반복실행 중지" : "반복실행";
                button_test.Enabled = !bStart;
                button_return.Enabled = !bStart;
                button_LoadCommandDatas.Enabled = !bStart;
                button_SaveCommandDatas.Enabled = !bStart;
                button_AddCommandData.Enabled = !bStart;
                button_DeleteCommandData.Enabled = !bStart;
                button_SelCommand.Enabled = !bStart;
            }
            else
            {
                var d = Invoke((MethodInvoker)delegate () {
                    changeUI(bStart);
                });
            }
        }

        private object lockobj = new object();
        private void ThreadRepeatFunc()
        {
            
            try
            {
                int nRepeat = 0;

                while(nRepeat++ < int.Parse(textBox_repeatCount.Text))
                {
                    Execute_selectCommand();

                    if(nRepeat != int.Parse(textBox_repeatCount.Text))
                        Thread.Sleep(int.Parse(textBox_repeatInterval.Text));
                }
            }
            catch(Exception ex) { Log_move.Format(ex.ToString()); }
            finally
            {
                changeUI(false);
            }
        }

        private void Execute_selectCommand()
        {
            try
            {
                for (int nIndex = 0; nIndex < dataGridView_Command.SelectedRows.Count; nIndex++)
                {
                    int nI = dataGridView_Command.SelectedRows[nIndex].Index;

                    if (IDDatas.getDataTable()[GetDataGridSelectID(nI)].nPID == -1)
                        continue;

                    CommandInput(nIndex, this.dataGridView_Command.Rows[nI].Cells["ID"].Value.ToString());
                }
            }
            catch (Exception ex)
            {

                Log_move.Format(ex.ToString());
            }
        }

        private void MoveFormClosed(object sender, FormClosedEventArgs e)
        {
            Thread_Repeat = null;
        }
    }
}
