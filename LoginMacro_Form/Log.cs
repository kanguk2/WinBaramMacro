using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginMacro_Form
{
    class Log
    {
        public TextBox text_box;
        ManualResetEvent Event_Log = new ManualResetEvent(true);
        public Log(ref TextBox text_box)
        {
            this.text_box = text_box;
        }

        delegate void clearDelegate(string str);

        public void Format(string str)
        {
            Event_Log.WaitOne();
            Event_Log.Reset();
            if (text_box.InvokeRequired)
            {
                Event_Log.Set();
                var d =
                        text_box.Invoke(new clearDelegate(Format), str);
            }
            else
            {
                text_box.AppendText("[" + System.DateTime.Now.ToString("H/m/ss") + "] : " + str + "\r\n");
            }
            Event_Log.Set();
        }

        public void Clear()
        {
            Event_Log.WaitOne();
            Event_Log.Reset();
            if (text_box.InvokeRequired)
            {
                Event_Log.Set();
                var d =
                        text_box.Invoke(new clearDelegate(Format));
            }
            else
            {
                text_box.Clear();
            }

            Event_Log.Set();
        }
    }
}
