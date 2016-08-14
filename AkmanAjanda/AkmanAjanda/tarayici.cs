using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AkmanAjanda
{
    public partial class tarayici : Form
    {
        public tarayici()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate(comboBox1.Text);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            webBrowser1.GoBack();

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            webBrowser1.GoForward();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate(comboBox1.Text);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            webBrowser1.Stop();
        }

        private void tarayici_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            webBrowser1.Refresh();
        }

        private void googleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("www.google.com.tr");
        }

        private void yahooToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("www.yahoo.com.tr");
        }

        private void bingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("www.bing.com");
        }
    }
}
