using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Drawing;

namespace LoginMacro_Form
{
    class mouseControl
    {
        [DllImport("user32.dll")]
        static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, int dwExtraInfo);

        private const uint MOUSEEVENTF_LEFTDOWN = 0x0002;      // The left button is down.
        private const uint MOUSEEVENTF_LEFTUP = 0x0004;        // The left button is up.

        public void mouseMoveClick(System.Drawing.Point pos)
        {
            System.Windows.Forms.Cursor.Position = pos;
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
        }

        public void print_mouseAxis(ref int X, ref int Y)
        {
            X = System.Windows.Forms.Cursor.Position.X;
            Y = System.Windows.Forms.Cursor.Position.Y;
        }

        public void print_mouseAxis(ref string strX, ref string strY)
        {
            strX = System.Windows.Forms.Cursor.Position.X.ToString();
            strY = System.Windows.Forms.Cursor.Position.Y.ToString();
        }

    }
}
