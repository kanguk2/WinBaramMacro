using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dashboardUI
{
    partial class Form1
    {
        private void button1_Click(object sender, EventArgs e)
        {
            showSubMenu(panel_1);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            showSubMenu(panel_2);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openChildForm(new Form_1());
            hideSubMenu();

        }
    }
}
