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
            this.button_GetImageAxis = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_XStart = new System.Windows.Forms.TextBox();
            this.textBox_YStart = new System.Windows.Forms.TextBox();
            this.textBox_XEnd = new System.Windows.Forms.TextBox();
            this.textBox_YEnd = new System.Windows.Forms.TextBox();
            this.button_ocr = new System.Windows.Forms.Button();
            this.button_convertimg = new System.Windows.Forms.Button();
            this.textBox_Threshold = new System.Windows.Forms.TextBox();
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
            this.picturBox.Size = new System.Drawing.Size(386, 303);
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
            this.textBox_Log.Size = new System.Drawing.Size(668, 164);
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
            // button_GetImageAxis
            // 
            this.button_GetImageAxis.Location = new System.Drawing.Point(400, 31);
            this.button_GetImageAxis.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_GetImageAxis.Name = "button_GetImageAxis";
            this.button_GetImageAxis.Size = new System.Drawing.Size(61, 55);
            this.button_GetImageAxis.TabIndex = 19;
            this.button_GetImageAxis.Text = "이미지 획득후 출력";
            this.button_GetImageAxis.UseVisualStyleBackColor = true;
            this.button_GetImageAxis.Click += new System.EventHandler(this.button_GetImageAxis_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(466, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 12);
            this.label2.TabIndex = 20;
            this.label2.Text = "X_Start";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(574, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 12);
            this.label3.TabIndex = 21;
            this.label3.Text = "Y_Start";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(466, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 22;
            this.label4.Text = "X_End";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(574, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 23;
            this.label5.Text = "Y_End";
            // 
            // textBox_XStart
            // 
            this.textBox_XStart.Location = new System.Drawing.Point(513, 35);
            this.textBox_XStart.Name = "textBox_XStart";
            this.textBox_XStart.Size = new System.Drawing.Size(59, 21);
            this.textBox_XStart.TabIndex = 24;
            this.textBox_XStart.KeyPress += new System.Windows.Forms.KeyPressEventHandler(CommonFunc.TextOnlyNumberInput);
            // 
            // textBox_YStart
            // 
            this.textBox_YStart.Location = new System.Drawing.Point(621, 32);
            this.textBox_YStart.Name = "textBox_YStart";
            this.textBox_YStart.Size = new System.Drawing.Size(59, 21);
            this.textBox_YStart.TabIndex = 25;
            this.textBox_YStart.KeyPress += new System.Windows.Forms.KeyPressEventHandler(CommonFunc.TextOnlyNumberInput);
            // 
            // textBox_XEnd
            // 
            this.textBox_XEnd.Location = new System.Drawing.Point(513, 58);
            this.textBox_XEnd.Name = "textBox_XEnd";
            this.textBox_XEnd.Size = new System.Drawing.Size(59, 21);
            this.textBox_XEnd.TabIndex = 26;
            this.textBox_XEnd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(CommonFunc.TextOnlyNumberInput);
            // 
            // textBox_YEnd
            // 
            this.textBox_YEnd.Location = new System.Drawing.Point(621, 59);
            this.textBox_YEnd.Name = "textBox_YEnd";
            this.textBox_YEnd.Size = new System.Drawing.Size(59, 21);
            this.textBox_YEnd.TabIndex = 27;
            this.textBox_YEnd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(CommonFunc.TextOnlyNumberInput);
            // 
            // button_ocr
            // 
            this.button_ocr.Location = new System.Drawing.Point(489, 405);
            this.button_ocr.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_ocr.Name = "button_ocr";
            this.button_ocr.Size = new System.Drawing.Size(83, 36);
            this.button_ocr.TabIndex = 28;
            this.button_ocr.Text = "문자분석";
            this.button_ocr.UseVisualStyleBackColor = true;
            this.button_ocr.Click += new System.EventHandler(this.button_ocr_Click);
            // 
            // button_convertimg
            // 
            this.button_convertimg.Location = new System.Drawing.Point(359, 404);
            this.button_convertimg.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_convertimg.Name = "button_convertimg";
            this.button_convertimg.Size = new System.Drawing.Size(83, 36);
            this.button_convertimg.TabIndex = 29;
            this.button_convertimg.Text = "이미지변환";
            this.button_convertimg.UseVisualStyleBackColor = true;
            this.button_convertimg.Click += new System.EventHandler(this.button_convertimg_Click);
            // 
            // textBox_Threshold
            // 
            this.textBox_Threshold.Location = new System.Drawing.Point(294, 414);
            this.textBox_Threshold.Name = "textBox_Threshold";
            this.textBox_Threshold.Size = new System.Drawing.Size(59, 21);
            this.textBox_Threshold.TabIndex = 30;
            this.textBox_Threshold.KeyPress += new System.Windows.Forms.KeyPressEventHandler(CommonFunc.TextOnlyNumberInput);
            // 
            // ImageControlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 619);
            this.Controls.Add(this.textBox_Threshold);
            this.Controls.Add(this.button_convertimg);
            this.Controls.Add(this.button_ocr);
            this.Controls.Add(this.textBox_YEnd);
            this.Controls.Add(this.textBox_XEnd);
            this.Controls.Add(this.textBox_YStart);
            this.Controls.Add(this.textBox_XStart);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button_GetImageAxis);
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
        private System.Windows.Forms.Button button_GetImageAxis;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_XStart;
        private System.Windows.Forms.TextBox textBox_YStart;
        private System.Windows.Forms.TextBox textBox_XEnd;
        private System.Windows.Forms.TextBox textBox_YEnd;
        private System.Windows.Forms.Button button_ocr;
        private System.Windows.Forms.Button button_convertimg;
        private System.Windows.Forms.TextBox textBox_Threshold;
    }
}