namespace LoginMacro_Form
{
    partial class MovementForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView_Command = new System.Windows.Forms.DataGridView();
            this.dataGridView_IDInfo = new System.Windows.Forms.DataGridView();
            this.button_AddCommandData = new System.Windows.Forms.Button();
            this.button_LoadCommandDatas = new System.Windows.Forms.Button();
            this.button_SaveCommandDatas = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_Log = new System.Windows.Forms.TextBox();
            this.button_test = new System.Windows.Forms.Button();
            this.textBox_place = new System.Windows.Forms.TextBox();
            this.button_DeleteCommandData = new System.Windows.Forms.Button();
            this.button_return = new System.Windows.Forms.Button();
            this.button_SelCommand = new System.Windows.Forms.Button();
            this.button_repeatExecute = new System.Windows.Forms.Button();
            this.textBox_repeatCount = new System.Windows.Forms.TextBox();
            this.textBox_repeatInterval = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Command)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_IDInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_Command
            // 
            this.dataGridView_Command.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Command.Location = new System.Drawing.Point(270, 24);
            this.dataGridView_Command.Name = "dataGridView_Command";
            this.dataGridView_Command.RowTemplate.Height = 23;
            this.dataGridView_Command.Size = new System.Drawing.Size(600, 303);
            this.dataGridView_Command.TabIndex = 17;
            // 
            // dataGridView_IDInfo
            // 
            this.dataGridView_IDInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_IDInfo.Location = new System.Drawing.Point(12, 24);
            this.dataGridView_IDInfo.Name = "dataGridView_IDInfo";
            this.dataGridView_IDInfo.RowTemplate.Height = 23;
            this.dataGridView_IDInfo.Size = new System.Drawing.Size(252, 303);
            this.dataGridView_IDInfo.TabIndex = 18;
            // 
            // button_AddCommandData
            // 
            this.button_AddCommandData.Location = new System.Drawing.Point(426, 331);
            this.button_AddCommandData.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_AddCommandData.Name = "button_AddCommandData";
            this.button_AddCommandData.Size = new System.Drawing.Size(72, 34);
            this.button_AddCommandData.TabIndex = 21;
            this.button_AddCommandData.Text = "추가";
            this.button_AddCommandData.UseVisualStyleBackColor = true;
            // 
            // button_LoadCommandDatas
            // 
            this.button_LoadCommandDatas.Location = new System.Drawing.Point(348, 331);
            this.button_LoadCommandDatas.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_LoadCommandDatas.Name = "button_LoadCommandDatas";
            this.button_LoadCommandDatas.Size = new System.Drawing.Size(72, 34);
            this.button_LoadCommandDatas.TabIndex = 20;
            this.button_LoadCommandDatas.Text = "불러오기";
            this.button_LoadCommandDatas.UseVisualStyleBackColor = true;
            this.button_LoadCommandDatas.Click += new System.EventHandler(this.button_IDDataLoad_Click);
            // 
            // button_SaveCommandDatas
            // 
            this.button_SaveCommandDatas.Location = new System.Drawing.Point(270, 331);
            this.button_SaveCommandDatas.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_SaveCommandDatas.Name = "button_SaveCommandDatas";
            this.button_SaveCommandDatas.Size = new System.Drawing.Size(72, 34);
            this.button_SaveCommandDatas.TabIndex = 19;
            this.button_SaveCommandDatas.Text = "저장";
            this.button_SaveCommandDatas.UseVisualStyleBackColor = true;
            this.button_SaveCommandDatas.Click += new System.EventHandler(this.button_IDDataSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 12);
            this.label1.TabIndex = 22;
            this.label1.Text = "접속중 아이디";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(268, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 23;
            this.label2.Text = "명령어창";
            // 
            // textBox_Log
            // 
            this.textBox_Log.Location = new System.Drawing.Point(12, 400);
            this.textBox_Log.Multiline = true;
            this.textBox_Log.Name = "textBox_Log";
            this.textBox_Log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_Log.Size = new System.Drawing.Size(858, 213);
            this.textBox_Log.TabIndex = 24;
            // 
            // button_test
            // 
            this.button_test.Location = new System.Drawing.Point(12, 330);
            this.button_test.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_test.Name = "button_test";
            this.button_test.Size = new System.Drawing.Size(72, 34);
            this.button_test.TabIndex = 25;
            this.button_test.Text = "토로라비";
            this.button_test.UseVisualStyleBackColor = true;
            this.button_test.Click += new System.EventHandler(this.button_test_Click);
            // 
            // textBox_place
            // 
            this.textBox_place.Location = new System.Drawing.Point(189, 333);
            this.textBox_place.Name = "textBox_place";
            this.textBox_place.Size = new System.Drawing.Size(75, 21);
            this.textBox_place.TabIndex = 26;
            // 
            // button_DeleteCommandData
            // 
            this.button_DeleteCommandData.Location = new System.Drawing.Point(504, 330);
            this.button_DeleteCommandData.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_DeleteCommandData.Name = "button_DeleteCommandData";
            this.button_DeleteCommandData.Size = new System.Drawing.Size(72, 34);
            this.button_DeleteCommandData.TabIndex = 27;
            this.button_DeleteCommandData.Text = "삭제";
            this.button_DeleteCommandData.UseVisualStyleBackColor = true;
            this.button_DeleteCommandData.Click += new System.EventHandler(this.button_CommandDelete_Click);
            // 
            // button_return
            // 
            this.button_return.Location = new System.Drawing.Point(90, 330);
            this.button_return.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_return.Name = "button_return";
            this.button_return.Size = new System.Drawing.Size(72, 34);
            this.button_return.TabIndex = 28;
            this.button_return.Text = "복귀";
            this.button_return.UseVisualStyleBackColor = true;
            this.button_return.Click += new System.EventHandler(this.button_return_Click);
            // 
            // button_SelCommand
            // 
            this.button_SelCommand.Location = new System.Drawing.Point(779, 330);
            this.button_SelCommand.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_SelCommand.Name = "button_SelCommand";
            this.button_SelCommand.Size = new System.Drawing.Size(91, 34);
            this.button_SelCommand.TabIndex = 29;
            this.button_SelCommand.Text = "선택된 명령어 실행";
            this.button_SelCommand.UseVisualStyleBackColor = true;
            this.button_SelCommand.Click += new System.EventHandler(this.button_SelCommand_Click);
            // 
            // button_repeatExecute
            // 
            this.button_repeatExecute.Location = new System.Drawing.Point(779, 365);
            this.button_repeatExecute.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_repeatExecute.Name = "button_repeatExecute";
            this.button_repeatExecute.Size = new System.Drawing.Size(91, 34);
            this.button_repeatExecute.TabIndex = 30;
            this.button_repeatExecute.Text = "반복 실행";
            this.button_repeatExecute.UseVisualStyleBackColor = true;
            this.button_repeatExecute.Click += new System.EventHandler(this.button_repeatExecute_Click);
            // 
            // textBox_repeatCount
            // 
            this.textBox_repeatCount.Location = new System.Drawing.Point(622, 378);
            this.textBox_repeatCount.Name = "textBox_repeatCount";
            this.textBox_repeatCount.Size = new System.Drawing.Size(75, 21);
            this.textBox_repeatCount.TabIndex = 31;
            // 
            // textBox_repeatInterval
            // 
            this.textBox_repeatInterval.Location = new System.Drawing.Point(700, 378);
            this.textBox_repeatInterval.Name = "textBox_repeatInterval";
            this.textBox_repeatInterval.Size = new System.Drawing.Size(75, 21);
            this.textBox_repeatInterval.TabIndex = 32;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(622, 363);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 12);
            this.label3.TabIndex = 33;
            this.label3.Text = "Count";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(699, 362);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 34;
            this.label4.Text = "Interval (ms)";
            // 
            // MovementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 614);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_repeatInterval);
            this.Controls.Add(this.textBox_repeatCount);
            this.Controls.Add(this.button_repeatExecute);
            this.Controls.Add(this.button_SelCommand);
            this.Controls.Add(this.button_return);
            this.Controls.Add(this.button_DeleteCommandData);
            this.Controls.Add(this.textBox_place);
            this.Controls.Add(this.button_test);
            this.Controls.Add(this.textBox_Log);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_AddCommandData);
            this.Controls.Add(this.button_LoadCommandDatas);
            this.Controls.Add(this.button_SaveCommandDatas);
            this.Controls.Add(this.dataGridView_IDInfo);
            this.Controls.Add(this.dataGridView_Command);
            this.Name = "MovementForm";
            this.Text = "MovementFrom";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Command)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_IDInfo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_Command;
        private System.Windows.Forms.DataGridView dataGridView_IDInfo;
        private System.Windows.Forms.Button button_AddCommandData;
        private System.Windows.Forms.Button button_LoadCommandDatas;
        private System.Windows.Forms.Button button_SaveCommandDatas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_Log;
        private System.Windows.Forms.Button button_test;

        private System.Windows.Forms.TextBox textBox_place;
        private System.Windows.Forms.Button button_DeleteCommandData;
        private System.Windows.Forms.Button button_return;
        private System.Windows.Forms.Button button_SelCommand;
        private System.Windows.Forms.Button button_repeatExecute;
        private System.Windows.Forms.TextBox textBox_repeatCount;
        private System.Windows.Forms.TextBox textBox_repeatInterval;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}