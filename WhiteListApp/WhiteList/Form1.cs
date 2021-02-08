using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;


namespace WhiteList
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void checkWhitelist_Click(object sender, EventArgs e)
        {
            //Networking
            WebClient wc = new WebClient(); //using webclient to receive a string from the web
            string receive = wc.DownloadString("https://pastebin.com/raw/Mbrt6Mng");

            if (receive.Contains(inputValue.Text))
            {
                MessageBox.Show("Welcome to your program", "Whitelist Succeeded");
            }
            else
            {
                MessageBox.Show("closing.", "Whitelist Failed");
                Environment.Exit(1);
            }

            //End Networking
        }
    }
}
