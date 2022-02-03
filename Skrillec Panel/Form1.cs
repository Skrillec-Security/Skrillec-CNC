using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using Skrillec_Panel;

namespace Skrillec_Panel
{
    public partial class Form1 : Form
    {

        // 'Extra Tools' dropdown panel postion    0, 234
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Skrillec_NET.start_skrillec();
        }

        public void tab_changer(int tab)
        {
            dashboard.Visible = false;
            cnc_settings.Visible = false;
            db_manager.Visible = false;
            logs.Visible = false;
            lookup.Visible = false;
            settings.Visible = false;
            if (tab == 0)
            {
                dashboard.Visible = true;
                label1.Text = "Dashboard";
            }
            else if (tab == 1)
            {
                cnc_settings.Visible = true;
                label1.Text = "CNC Settings";
            }
            else if (tab == 2)
            {
                db_manager.Visible = true;
                label1.Text = "Users CP";
            }
            else if (tab == 4)
            {
                logs.Visible = true;
                label1.Text = "Logs";
            }
            else if (tab == 5)
            {
                lookup.Visible = true;
                label1.Text = "Lookup Tools";
            }
            else if (tab == 6)
            {
                settings.Visible = true;
                label1.Text = "Settings";
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void sidetoolsdrop_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void label5_Click(object sender, EventArgs e)
        {
            tab_changer(0);
        }

        private void label6_Click(object sender, EventArgs e)
        {
            tab_changer(1);
        }

        private void label7_Click(object sender, EventArgs e)
        {
            tab_changer(2);
        }

        private void label10_Click(object sender, EventArgs e)
        {
            panel5.BringToFront();
            if (label8.Text == "●")
            {
                label8.Text = "◌";
                panel5.Visible = true;
            }
            else
            {
                label8.Text = "●";
                panel5.Visible = false;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            tab_changer(6);
        }

        private void label8_Click(object sender, EventArgs e)
        {
            panel5.BringToFront();
            if(label8.Text == "●")
            {
                label8.Text = "◌";
                panel5.Visible = true;
            } else
            {
                label8.Text = "●";
                panel5.Visible = false;
            }
        }

        private void panel14_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {
            tab_changer(2);
        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {
            tab_changer(1);
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {
            tab_changer(0);
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            tab_changer(6);
        }

        private void panel14_Click(object sender, EventArgs e)
        {
            panel5.BringToFront();
            if (label8.Text == "●")
            {
                label8.Text = "◌";
                panel5.Visible = true;
            }
            else
            {
                label8.Text = "●";
                panel5.Visible = false;
            }
        }
    }
}
