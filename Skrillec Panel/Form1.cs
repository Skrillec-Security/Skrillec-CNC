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
using System.Threading;

namespace Skrillec_Panel
{
    public partial class Form1 : Form
    {
        // Tids for Thread IDs 
        // we still store all threads in an array
        public Thread server_thread = null;
        public Thread logs_thread = null;

        // 'Extra Tools' dropdown panel postion    0, 234
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

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

        private void label11_Click(object sender, EventArgs e)
        {
            tab_changer(4);
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {
        }

        private void label13_Click(object sender, EventArgs e)
        {
            tab_changer(5);
        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {
        }

        private void panel6_Click(object sender, EventArgs e)
        {
            tab_changer(4);
        }

        private void panel10_Click(object sender, EventArgs e)
        {

            tab_changer(5);
        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Skrillec_NET.server_on == true)
            { 
                server_thread.Abort();
                label22.Text = "Skrillec Server Stopped";
            } else {
                label22.Text = "Last Action: Error, Skrillec server is not running!";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Skrillec_NET.server_on == false)
            {
                Skrillec_NET.port = Convert.ToInt32(textBox1.Text);
                server_thread = new Thread(Skrillec_NET.start_skrillec);
                server_thread.Start();
                //Skrillec_NET.start_skrillec();
                label22.Text = "Last Action: Skrillec server started";
            } else
            {
                label22.Text = "Last Action: Error, Skrillec server is already running!";
            }
        }

        public void listen_to_logs()
        {
            while(true)
            {
                richTextBox3.Text = Skrillec_NET.server_logs;
                Thread.Sleep(1);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                logs_thread = new Thread(listen_to_logs);
                logs_thread.Start();
            } else
            {
                logs_thread.Abort();
            }
        }
    }
}
