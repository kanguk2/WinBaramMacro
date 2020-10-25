using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginMacro_Form
{
    public partial class ImageControlForm : Form
    {
        private ImageProc imageproc = new ImageProc();
        private DataTable IDDataTable = new DataTable();
        private IDData_KANG IDDatas;

        private ManualResetEvent Event_Log = new ManualResetEvent(true);

        private Log log_Img;
        public ImageControlForm(ref IDData_KANG IDDatas)
        {
            this.IDDatas = IDDatas;
            InitializeComponent();

            InitGridView();

            log_Img = new Log(ref textBox_Log);
        }

        public void InitGridView()
        {
            IDDataTable.Columns.Add("ID");
            IDDataTable.Columns.Add("STATE");
            IDDataTable.Columns[0].ReadOnly = true;
            IDDataTable.Columns[1].ReadOnly = true;
            InitRow();
            this.dataGridView1_IDInfo.DataSource = this.IDDataTable;

        }

        private void InitRow()
        {
            try
            {
                foreach (KeyValuePair<string, Datas> items in IDDatas.getDataTable())
                {
                    IDDataTable.Rows.Add(items.Key, items.Value.strSTATE);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
            }
        }

        private void button_GetText_Click(object sender, EventArgs e)
        {
            string filePath = FileControl.getFilePathFromDialog();

            picturBox.Image = new Bitmap(filePath);
        }

        private void button_GetIDBMP_Click(object sender, EventArgs e)
        {
            try
            {
                Image img = ImageProc.ImageCrop(GetDataGridSelectPID(dataGridView1_IDInfo.CurrentCell.RowIndex), eImagetype.name);

                string strFilePath = ImageProc.m_strIDInfo + GetDataGridSelectID(dataGridView1_IDInfo.CurrentCell.RowIndex) + ".bmp";

                if (new FileInfo(strFilePath).Exists == false)
                {
                    new Bitmap(img).Save(strFilePath);
                    log_Img.Format("file : " + strFilePath + "저장하였습니다.");
                }
                else
                    log_Img.Format("file : " + strFilePath + "가 존재합니다.");

            }
            catch (Exception ex)
            {
                log_Img.Format(ex.ToString());
            }
        }

        private void button_compare_Click(object sender, EventArgs e)
        {
            try
            {
                Image img_capture = ImageProc.ImageCrop(GetDataGridSelectPID(dataGridView1_IDInfo.CurrentCell.RowIndex), eImagetype.name);
                string strFilePath = ImageProc.m_strFilePath + GetDataGridSelectID(dataGridView1_IDInfo.CurrentCell.RowIndex) + ".bmp";

                bool bEqual = true;

                if (new FileInfo(strFilePath).Exists == false)
                {
                    log_Img.Format("file : " + strFilePath + "가 없습니다.");
                    throw new Exception();
                }
                else
                    bEqual = ImageProc.ImageCompare(strFilePath, new Bitmap(img_capture));

                string str = "File : " + strFilePath + " 와 Process ID" + GetDataGridSelectID(dataGridView1_IDInfo.CurrentCell.RowIndex) + "와 비교 "
                                + (bEqual ? "같다" : "다르다");

                log_Img.Format(str);

            }
            catch (Exception ex){ }
        }

        private bool CompareID(int nIndex)
        {
            bool bCheck = false;
            try
            {
                Image img_capture = ImageProc.ImageCrop(GetDataGridSelectPID(dataGridView1_IDInfo.CurrentCell.RowIndex), eImagetype.name);
                string strFilePath = ImageProc.m_strFilePath + GetDataGridSelectID(dataGridView1_IDInfo.CurrentCell.RowIndex) + ".bmp";

                if (new FileInfo(strFilePath).Exists == false)
                    log_Img.Format("file : " + strFilePath + "가 없습니다.");
                else
                    bCheck = ImageProc.ImageCompare(strFilePath, new Bitmap(img_capture));
            }
            catch (Exception) { }

            return bCheck;
        }

        private void button_checkConnection_Click(object sender, EventArgs e)
        {
            try
            {
                int nIndex = 0;

                foreach (var data in IDDatas.getDataTable())
                {
                    if (connectDialog_check(nIndex++) == false)
                    {
                        int nID = IDDatas.getDataTable()[data.Key].nPID;

                        if (nID != -1)
                        {
                            ProcessControl.KillProcess(nID);
                            IDDatas.getDataTable()[data.Key].nPID = -1;
                            log_Img.Format(data.Key.ToString() + "연결해제로 프로세스 종료함.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }            
        }

        private bool connectDialog_check(int nIndex)
        {
            bool bCheck = false;
            try
            {
                Image img_capture = ImageProc.ImageCrop(GetDataGridSelectPID(dataGridView1_IDInfo.CurrentCell.RowIndex), eImagetype.total);
                string strFilePath = ImageProc.m_strFilePath + "연결해제.bmp";

                if (new FileInfo(strFilePath).Exists == false)
                    log_Img.Format("file : " + strFilePath + "가 없습니다.");
                else
                    bCheck = ImageProc.ImageCompare(strFilePath, new Bitmap(img_capture));
            }
            catch (Exception e)
            {
                log_Img.Format(e.ToString());
            }
            return bCheck;
        }
        public string GetDataGridSelectID(int nSel)
        {
            try
            {
                return dataGridView1_IDInfo.Rows[nSel].Cells["ID"].Value.ToString();
            }
            catch (Exception e) { log_Img.Format(e.ToString()) ; }

            return null;
        }

        private int GetDataGridSelectPID(int nSel)
        {
            try
            {
                string strID = dataGridView1_IDInfo.Rows[nSel].Cells["ID"].Value.ToString();
                return IDDatas.getDataTable()[strID].nPID;
            }
            catch (Exception e) { log_Img.Format(e.ToString()); }

            return -1;
        }   
    }
}
