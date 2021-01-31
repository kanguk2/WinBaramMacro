using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dashboardUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            hideSubMenu();
        }


        private void customizeDesign()
        {
            panel_1.Visible  = false;
            panel_2.Visible = false;
        }

        private void hideSubMenu()
        {
            if (panel_1.Visible = true)
                panel_1.Visible = false;
            if (panel_2.Visible = true)
                panel_2.Visible = false;
        }
        
        private void showSubMenu(Panel submenu)
        {
            if (submenu.Visible == false)
            {

                submenu.Visible = true;
            }
            else
                submenu.Visible = false;
        }

      

        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();

            activeForm = childForm;

            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openChildForm(new Form_2());
            hideSubMenu();
        }
    }

}
