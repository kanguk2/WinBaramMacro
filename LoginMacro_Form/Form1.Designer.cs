namespace LoginMacro_Form
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView_Info = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_FilePath = new System.Windows.Forms.TextBox();
            this.button_FilePath = new System.Windows.Forms.Button();
            this.button_multiExecute = new System.Windows.Forms.Button();
            this.button_test = new System.Windows.Forms.Button();
            this.button_FornIC = new System.Windows.Forms.Button();
            this.button_Movement = new System.Windows.Forms.Button();
            this.button_IDDataSave = new System.Windows.Forms.Button();
            this.button_IDDataLoad = new System.Windows.Forms.Button();
            this.button_AddID = new System.Windows.Forms.Button();
            this.button_Refresh = new System.Windows.Forms.Button();
            this.textBox_Log = new System.Windows.Forms.TextBox();
            this.button_IDDelete = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_IDFilePath = new System.Windows.Forms.TextBox();
            this.button_LoginStop = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Info)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_Info
            // 
            this.dataGridView_Info.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Info.Location = new System.Drawing.Point(1, 89);
            this.dataGridView_Info.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridView_Info.Name = "dataGridView_Info";
            this.dataGridView_Info.RowTemplate.Height = 23;
            this.dataGridView_Info.Size = new System.Drawing.Size(661, 433);
            this.dataGridView_Info.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 11F);
            this.label2.Location = new System.Drawing.Point(17, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Execute File Path :";
            // 
            // textBox_FilePath
            // 
            this.textBox_FilePath.Location = new System.Drawing.Point(156, 8);
            this.textBox_FilePath.Name = "textBox_FilePath";
            this.textBox_FilePath.ReadOnly = true;
            this.textBox_FilePath.Size = new System.Drawing.Size(496, 24);
            this.textBox_FilePath.TabIndex = 7;
            this.textBox_FilePath.Text = "D:\\";
            // 
            // button_FilePath
            // 
            this.button_FilePath.Location = new System.Drawing.Point(660, 8);
            this.button_FilePath.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_FilePath.Name = "button_FilePath";
            this.button_FilePath.Size = new System.Drawing.Size(104, 24);
            this.button_FilePath.TabIndex = 9;
            this.button_FilePath.Text = "...";
            this.button_FilePath.UseVisualStyleBackColor = true;
            this.button_FilePath.Click += new System.EventHandler(this.button_FilePath_Click);
            // 
            // button_multiExecute
            // 
            this.button_multiExecute.Location = new System.Drawing.Point(668, 89);
            this.button_multiExecute.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_multiExecute.Name = "button_multiExecute";
            this.button_multiExecute.Size = new System.Drawing.Size(101, 55);
            this.button_multiExecute.TabIndex = 11;
            this.button_multiExecute.Text = "선택셀 실행";
            this.button_multiExecute.UseVisualStyleBackColor = true;
            this.button_multiExecute.Click += new System.EventHandler(this.button_multiExecute_Click);
            // 
            // button_test
            // 
            this.button_test.Location = new System.Drawing.Point(480, 530);
            this.button_test.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_test.Name = "button_test";
            this.button_test.Size = new System.Drawing.Size(141, 34);
            this.button_test.TabIndex = 13;
            this.button_test.Text = "테스트";
            this.button_test.UseVisualStyleBackColor = true;
            this.button_test.Click += new System.EventHandler(this.button_test_Click);
            // 
            // button_FornIC
            // 
            this.button_FornIC.Location = new System.Drawing.Point(773, 89);
            this.button_FornIC.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_FornIC.Name = "button_FornIC";
            this.button_FornIC.Size = new System.Drawing.Size(108, 55);
            this.button_FornIC.TabIndex = 14;
            this.button_FornIC.Text = "이미지컨트롤 모달리스";
            this.button_FornIC.UseVisualStyleBackColor = true;
            this.button_FornIC.Click += new System.EventHandler(this.button_FornIC_Click);
            // 
            // button_Movement
            // 
            this.button_Movement.Location = new System.Drawing.Point(887, 89);
            this.button_Movement.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_Movement.Name = "button_Movement";
            this.button_Movement.Size = new System.Drawing.Size(88, 55);
            this.button_Movement.TabIndex = 15;
            this.button_Movement.Text = "명령수행 모달리스";
            this.button_Movement.UseVisualStyleBackColor = true;
            this.button_Movement.Click += new System.EventHandler(this.button_Movement_Click);
            // 
            // button_IDDataSave
            // 
            this.button_IDDataSave.Location = new System.Drawing.Point(1, 530);
            this.button_IDDataSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_IDDataSave.Name = "button_IDDataSave";
            this.button_IDDataSave.Size = new System.Drawing.Size(113, 34);
            this.button_IDDataSave.TabIndex = 16;
            this.button_IDDataSave.Text = "저장";
            this.button_IDDataSave.UseVisualStyleBackColor = true;
            this.button_IDDataSave.Click += new System.EventHandler(this.button_IDDataSave_Click);
            // 
            // button_IDDataLoad
            // 
            this.button_IDDataLoad.Location = new System.Drawing.Point(123, 530);
            this.button_IDDataLoad.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_IDDataLoad.Name = "button_IDDataLoad";
            this.button_IDDataLoad.Size = new System.Drawing.Size(113, 34);
            this.button_IDDataLoad.TabIndex = 17;
            this.button_IDDataLoad.Text = "불러오기";
            this.button_IDDataLoad.UseVisualStyleBackColor = true;
            this.button_IDDataLoad.Click += new System.EventHandler(this.button_IDDataLoad_Click);
            // 
            // button_AddID
            // 
            this.button_AddID.Location = new System.Drawing.Point(242, 530);
            this.button_AddID.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_AddID.Name = "button_AddID";
            this.button_AddID.Size = new System.Drawing.Size(113, 34);
            this.button_AddID.TabIndex = 18;
            this.button_AddID.Text = "추가";
            this.button_AddID.UseVisualStyleBackColor = true;
            this.button_AddID.Click += new System.EventHandler(this.button_AddID_Click);
            // 
            // button_Refresh
            // 
            this.button_Refresh.Location = new System.Drawing.Point(1, 572);
            this.button_Refresh.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_Refresh.Name = "button_Refresh";
            this.button_Refresh.Size = new System.Drawing.Size(150, 34);
            this.button_Refresh.TabIndex = 19;
            this.button_Refresh.Text = "새로고침 활성화";
            this.button_Refresh.UseVisualStyleBackColor = true;
            this.button_Refresh.Click += new System.EventHandler(this.button_Refresh_Click);
            // 
            // textBox_Log
            // 
            this.textBox_Log.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox_Log.Location = new System.Drawing.Point(668, 209);
            this.textBox_Log.Multiline = true;
            this.textBox_Log.Name = "textBox_Log";
            this.textBox_Log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_Log.Size = new System.Drawing.Size(307, 222);
            this.textBox_Log.TabIndex = 25;
            // 
            // button_IDDelete
            // 
            this.button_IDDelete.Location = new System.Drawing.Point(361, 530);
            this.button_IDDelete.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_IDDelete.Name = "button_IDDelete";
            this.button_IDDelete.Size = new System.Drawing.Size(113, 34);
            this.button_IDDelete.TabIndex = 26;
            this.button_IDDelete.Text = "삭제";
            this.button_IDDelete.UseVisualStyleBackColor = true;
            this.button_IDDelete.Click += new System.EventHandler(this.button_IDDelete_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 11F);
            this.label1.Location = new System.Drawing.Point(58, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 15);
            this.label1.TabIndex = 27;
            this.label1.Text = "ID File Path :";
            // 
            // textBox_IDFilePath
            // 
            this.textBox_IDFilePath.Location = new System.Drawing.Point(156, 38);
            this.textBox_IDFilePath.Name = "textBox_IDFilePath";
            this.textBox_IDFilePath.Size = new System.Drawing.Size(496, 24);
            this.textBox_IDFilePath.TabIndex = 28;
            this.textBox_IDFilePath.Text = "D:\\";
            // 
            // button_LoginStop
            // 
            this.button_LoginStop.Location = new System.Drawing.Point(668, 149);
            this.button_LoginStop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_LoginStop.Name = "button_LoginStop";
            this.button_LoginStop.Size = new System.Drawing.Size(101, 55);
            this.button_LoginStop.TabIndex = 29;
            this.button_LoginStop.Text = "로그인 중지";
            this.button_LoginStop.UseVisualStyleBackColor = true;
            this.button_LoginStop.Click += new System.EventHandler(this.button_LoginStop_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(986, 618);
            this.Controls.Add(this.button_LoginStop);
            this.Controls.Add(this.textBox_IDFilePath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_IDDelete);
            this.Controls.Add(this.textBox_Log);
            this.Controls.Add(this.button_Refresh);
            this.Controls.Add(this.button_AddID);
            this.Controls.Add(this.button_IDDataLoad);
            this.Controls.Add(this.button_IDDataSave);
            this.Controls.Add(this.button_Movement);
            this.Controls.Add(this.button_FornIC);
            this.Controls.Add(this.button_test);
            this.Controls.Add(this.button_multiExecute);
            this.Controls.Add(this.button_FilePath);
            this.Controls.Add(this.textBox_FilePath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView_Info);
            this.Font = new System.Drawing.Font("굴림", 11F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Info)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView_Info;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_FilePath;
        private System.Windows.Forms.Button button_FilePath;
        private System.Windows.Forms.Button button_multiExecute;
        private System.Windows.Forms.Button button_test;
        private System.Windows.Forms.Button button_FornIC;
        private System.Windows.Forms.Button button_Movement;
        private System.Windows.Forms.Button button_IDDataSave;
        private System.Windows.Forms.Button button_IDDataLoad;
        private System.Windows.Forms.Button button_AddID;
        private System.Windows.Forms.Button button_Refresh;
        private System.Windows.Forms.TextBox textBox_Log;
        private System.Windows.Forms.Button button_IDDelete;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_IDFilePath;
        private System.Windows.Forms.Button button_LoginStop;
    }
}

