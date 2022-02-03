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

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void sidetoolsdrop_Paint(object sender, PaintEventArgs e)
        {
            
        }

        public void tab_changer(int tab)
        {
            if(tab == 0) {
                dashboard.Visible = true;
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
