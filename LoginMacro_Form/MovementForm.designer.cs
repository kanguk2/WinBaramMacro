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
            this.button_AddCommand = new System.Windows.Forms.Button();
            this.button_IDDataLoad = new System.Windows.Forms.Button();
            this.button_IDDataSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_Log = new System.Windows.Forms.TextBox();
            this.button_test = new System.Windows.Forms.Button();
            this.textBox_place = new System.Windows.Forms.TextBox();
            this.button_CommandDelete = new System.Windows.Forms.Button();
            this.button_return = new System.Windows.Forms.Button();
            this.button_SelCommand = new System.Windows.Forms.Button();
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
            // button_AddCommand
            // 
            this.button_AddCommand.Location = new System.Drawing.Point(426, 331);
            this.button_AddCommand.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_AddCommand.Name = "button_AddCommand";
            this.button_AddCommand.Size = new System.Drawing.Size(72, 34);
            this.button_AddCommand.TabIndex = 21;
            this.button_AddCommand.Text = "추가";
            this.button_AddCommand.UseVisualStyleBackColor = true;
            // 
            // button_IDDataLoad
            // 
            this.button_IDDataLoad.Location = new System.Drawing.Point(348, 331);
            this.button_IDDataLoad.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_IDDataLoad.Name = "button_IDDataLoad";
            this.button_IDDataLoad.Size = new System.Drawing.Size(72, 34);
            this.button_IDDataLoad.TabIndex = 20;
            this.button_IDDataLoad.Text = "불러오기";
            this.button_IDDataLoad.UseVisualStyleBackColor = true;
            this.button_IDDataLoad.Click += new System.EventHandler(this.button_IDDataLoad_Click);
            // 
            // button_IDDataSave
            // 
            this.button_IDDataSave.Location = new System.Drawing.Point(270, 331);
            this.button_IDDataSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_IDDataSave.Name = "button_IDDataSave";
            this.button_IDDataSave.Size = new System.Drawing.Size(72, 34);
            this.button_IDDataSave.TabIndex = 19;
            this.button_IDDataSave.Text = "저장";
            this.button_IDDataSave.UseVisualStyleBackColor = true;
            this.button_IDDataSave.Click += new System.EventHandler(this.button_IDDataSave_Click);
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
            // button_CommandDelete
            // 
            this.button_CommandDelete.Location = new System.Drawing.Point(504, 330);
            this.button_CommandDelete.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_CommandDelete.Name = "button_CommandDelete";
            this.button_CommandDelete.Size = new System.Drawing.Size(72, 34);
            this.button_CommandDelete.TabIndex = 27;
            this.button_CommandDelete.Text = "삭제";
            this.button_CommandDelete.UseVisualStyleBackColor = true;
            this.button_CommandDelete.Click += new System.EventHandler(this.button_CommandDelete_Click);
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
            // MovementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 614);
            this.Controls.Add(this.button_SelCommand);
            this.Controls.Add(this.button_return);
            this.Controls.Add(this.button_CommandDelete);
            this.Controls.Add(this.textBox_place);
            this.Controls.Add(this.button_test);
            this.Controls.Add(this.textBox_Log);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_AddCommand);
            this.Controls.Add(this.button_IDDataLoad);
            this.Controls.Add(this.button_IDDataSave);
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
        private System.Windows.Forms.Button button_AddCommand;
        private System.Windows.Forms.Button button_IDDataLoad;
        private System.Windows.Forms.Button button_IDDataSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_Log;
        private System.Windows.Forms.Button button_test;

        private System.Windows.Forms.TextBox textBox_place;
        private System.Windows.Forms.Button button_CommandDelete;
        private System.Windows.Forms.Button button_return;
        private System.Windows.Forms.Button button_SelCommand;
    }
}