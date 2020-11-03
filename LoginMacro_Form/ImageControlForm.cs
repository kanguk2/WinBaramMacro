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
        private CaptureImageForm Form_CI;

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
            IDDataTable.Columns.Add("Group");
            IDDataTable.Columns[0].ReadOnly = true;
            IDDataTable.Columns[1].ReadOnly = true;
            this.dataGridView1_IDInfo.DataSource = this.IDDataTable;

            InitRow();

        }

        public void InitRow()
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
                    log_Img.Format(e.Message.ToString());
                }
            }
            else
            {
                var d =
                    Invoke((MethodInvoker)delegate () {
                        InitRow();
                    });
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
                string strFilePath = $"{ImageProc.m_strIDInfo}{GetDataGridSelectID(dataGridView1_IDInfo.CurrentCell.RowIndex)}.bmp";

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

        private void button_getTotalImage_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    int nPID = GetDataGridSelectPID(dataGridView1_IDInfo.CurrentCell.RowIndex);
                    ProcessControl.Display(nPID);
                    Image img_capture = ImageProc.ImageCrop(nPID, eImagetype.total);
                    ProcessControl.MiniMizedProcess(nPID);
                    if (Form_CI != null && Form_CI.IsHandleCreated == true)
                    {
                        ProcessControl.ForegroundProcess(Form_CI.Handle);
                        return;
                    }
                    Form_CI = new CaptureImageForm(img_capture);
                    Form_CI.Show();
                }
                catch (Exception ex)
                {
                    log_Img.Format(ex.ToString());
                }
            }
            catch(Exception ex){ log_Img.Format( ex.ToString()); }
        }

        private void button_GetImageAxis_Click(object sender, EventArgs e)
        {
            try
            {
                int nXStart = int.Parse(textBox_XStart.Text.ToString());
                int nXEnd = int.Parse(textBox_XEnd.Text.ToString());
                int nYStart = int.Parse(textBox_YStart.Text.ToString());
                int nYEnd = int.Parse(textBox_YEnd.Text.ToString());

                if ((nXStart > nXEnd) || (nYStart > nYEnd))
                    throw new Exception("좌표를 확인하고 다시 입력해주세요.");

                int nPID = GetDataGridSelectPID(dataGridView1_IDInfo.CurrentCell.RowIndex);

                ProcessControl.Display(nPID);

                

                picturBox.Image = ImageProc.ImageCrop(nPID, new Rectangle(nXStart, nYStart, nXEnd - nXStart, nYEnd - nYStart));
               
                ProcessControl.MiniMizedProcess(nPID);
            }
            catch (Exception ex) { log_Img.Format(ex.ToString()); };
        }

        private void button_ocr_Click(object sender, EventArgs e)
        {
            if (picturBox.Image != null)
                log_Img.Format(ImageProc.ImageCrop(new Bitmap(picturBox.Image)));

            try
            {
/*                int nXStart = int.Parse(textBox_XStart.Text.ToString());
                int nXEnd = int.Parse(textBox_XEnd.Text.ToString());
                int nYStart = int.Parse(textBox_YStart.Text.ToString());
                int nYEnd = int.Parse(textBox_YEnd.Text.ToString());

                Rectangle rectangle = new Rectangle(nXStart, nYStart, nXEnd - nXStart, nYEnd - nYStart);
*/
                log_Img.Format(ImageProc.ImageCrop(new Bitmap(picturBox.Image)));
            }
            catch (Exception ex) { log_Img.Format(ex.ToString()); };
        }

        private void button_convertimg_Click(object sender, EventArgs e)
        {
            try
            {
                int Threshold = int.Parse(textBox_Threshold.Text);
                
                picturBox.Image = ImageProc.ThresholdImage(new Bitmap(picturBox.Image), Threshold); 
                //                log_Img.Format(ImageProc.ImageCrop(new Bitmap(picturBox.Image)));
            }
            catch (Exception ex) { log_Img.Format(ex.ToString()); };
        }
    }
}