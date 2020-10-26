using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginMacro_Form
{
    public partial class CaptureImageForm : Form
    {
        Timer timer;

        public CaptureImageForm(Image Img_capture)
        {
            InitializeComponent();

            pictureBox.Image = Img_capture;

            timer = new System.Windows.Forms.Timer();
            timer.Interval = 50; // 1초
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (this.InvokeRequired == false)
            {
                Point p = Control.MousePosition;
                Point p1 = pictureBox.PointToClient(p);
                if (p1.X < 0 || p1.X > pictureBox.Image.Width || p1.Y < 0 || p1.Y > pictureBox.Image.Height)
                    return;

                label_AXIS.Text = $"Y:{p1.Y},X;{p1.X}";
            }
            else
            {
                var d = Invoke((MethodInvoker)delegate () {
                        timer_Tick(sender, e);
                        });
            }
        }

        private void CaptureImageForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer.Stop();
        }
    }
}
