namespace LoginMacro_Form
{
    partial class ImageControlForm
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
            this.button_compare = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button_GetIDBMP = new System.Windows.Forms.Button();
            this.button_GetText = new System.Windows.Forms.Button();
            this.picturBox = new System.Windows.Forms.PictureBox();
            this.dataGridView1_IDInfo = new System.Windows.Forms.DataGridView();
            this.textBox_Log = new System.Windows.Forms.TextBox();
            this.button_getTotalImage = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picturBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1_IDInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // button_compare
            // 
            this.button_compare.Location = new System.Drawing.Point(195, 31);
            this.button_compare.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_compare.Name = "button_compare";
            this.button_compare.Size = new System.Drawing.Size(92, 55);
            this.button_compare.TabIndex = 15;
            this.button_compare.Text = "선택한 아이디 비교";
            this.button_compare.UseVisualStyleBackColor = true;
            this.button_compare.Click += new System.EventHandler(this.button_compare_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 12);
            this.label1.TabIndex = 14;
            this.label1.Text = "Image Analyze";
            // 
            // button_GetIDBMP
            // 
            this.button_GetIDBMP.Location = new System.Drawing.Point(95, 31);
            this.button_GetIDBMP.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_GetIDBMP.Name = "button_GetIDBMP";
            this.button_GetIDBMP.Size = new System.Drawing.Size(87, 55);
            this.button_GetIDBMP.TabIndex = 13;
            this.button_GetIDBMP.Text = "아이디 획득 저장";
            this.button_GetIDBMP.UseVisualStyleBackColor = true;
            this.button_GetIDBMP.Click += new System.EventHandler(this.button_GetIDBMP_Click);
            // 
            // button_GetText
            // 
            this.button_GetText.Location = new System.Drawing.Point(12, 31);
            this.button_GetText.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_GetText.Name = "button_GetText";
            this.button_GetText.Size = new System.Drawing.Size(70, 55);
            this.button_GetText.TabIndex = 12;
            this.button_GetText.Text = "파일선택 획득";
            this.button_GetText.UseVisualStyleBackColor = true;
            this.button_GetText.Click += new System.EventHandler(this.button_GetText_Click);
            // 
            // picturBox
            // 
            this.picturBox.Location = new System.Drawing.Point(294, 93);
            this.picturBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.picturBox.Name = "picturBox";
            this.picturBox.Size = new System.Drawing.Size(377, 347);
            this.picturBox.TabIndex = 11;
            this.picturBox.TabStop = false;
            // 
            // dataGridView1_IDInfo
            // 
            this.dataGridView1_IDInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1_IDInfo.Location = new System.Drawing.Point(12, 93);
            this.dataGridView1_IDInfo.Name = "dataGridView1_IDInfo";
            this.dataGridView1_IDInfo.RowTemplate.Height = 23;
            this.dataGridView1_IDInfo.Size = new System.Drawing.Size(276, 348);
            this.dataGridView1_IDInfo.TabIndex = 16;
            // 
            // textBox_Log
            // 
            this.textBox_Log.Location = new System.Drawing.Point(12, 447);
            this.textBox_Log.Multiline = true;
            this.textBox_Log.Name = "textBox_Log";
            this.textBox_Log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_Log.Size = new System.Drawing.Size(659, 164);
            this.textBox_Log.TabIndex = 17;
            // 
            // button_getTotalImage
            // 
            this.button_getTotalImage.Location = new System.Drawing.Point(294, 31);
            this.button_getTotalImage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_getTotalImage.Name = "button_getTotalImage";
            this.button_getTotalImage.Size = new System.Drawing.Size(100, 55);
            this.button_getTotalImage.TabIndex = 18;
            this.button_getTotalImage.Text = "전체이미지획득";
            this.button_getTotalImage.UseVisualStyleBackColor = true;
            this.button_getTotalImage.Click += new System.EventHandler(this.button_getTotalImage_Click);
            // 
            // ImageControlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 619);
            this.Controls.Add(this.button_getTotalImage);
            this.Controls.Add(this.textBox_Log);
            this.Controls.Add(this.dataGridView1_IDInfo);
            this.Controls.Add(this.button_compare);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_GetIDBMP);
            this.Controls.Add(this.button_GetText);
            this.Controls.Add(this.picturBox);
            this.Name = "ImageControlForm";
            this.Text = "ImageControlForm";
            ((System.ComponentModel.ISupportInitialize)(this.picturBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1_IDInfo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_compare;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_GetIDBMP;
        private System.Windows.Forms.Button button_GetText;
        private System.Windows.Forms.PictureBox picturBox;
        private System.Windows.Forms.DataGridView dataGridView1_IDInfo;
        private System.Windows.Forms.TextBox textBox_Log;
        private System.Windows.Forms.Button button_getTotalImage;
    }
}