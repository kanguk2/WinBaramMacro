namespace LoginMacro_Form
{
    partial class CaptureImageForm
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
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.label_AXIS = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(3, 7);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(706, 598);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // label_AXIS
            // 
            this.label_AXIS.AutoSize = true;
            this.label_AXIS.Location = new System.Drawing.Point(715, 9);
            this.label_AXIS.Name = "label_AXIS";
            this.label_AXIS.Size = new System.Drawing.Size(30, 12);
            this.label_AXIS.TabIndex = 1;
            this.label_AXIS.Text = "Axis";
            // 
            // CaptureImageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 620);
            this.Controls.Add(this.label_AXIS);
            this.Controls.Add(this.pictureBox);
            this.Name = "CaptureImageForm";
            this.Text = "CaptureImageForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CaptureImageForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label label_AXIS;
    }
}