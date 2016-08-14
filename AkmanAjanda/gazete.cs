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
    public partial class gazete : Form
    {
        public gazete()
        {
            InitializeComponent();
        }

        private void akşamGazetesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("http://www.aksam.com.tr/");
        }

        private void cumhuriyetGazetesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("http://www.cumhuriyet.com.tr/");
        }

        private void hürriyetGazetesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("http://www.hurriyet.com.tr/");
        }

        private void milliyetGazetesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("http://www.milliyet.com.tr/");
        }

        private void postaGazetesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("http://www.posta.com.tr/");
        }

        private void sabahGazetesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("http://www.sabah.com.tr/");
        }

        private void sözcüGazetesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("http://www.sozcu.com.tr/");
        }

        private void fotomaçToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("http://www.fotomac.com.tr/");
        }

        private void fanatikToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("http://www.fanatik.com.tr/");
        }

        private void fotosporToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("http://www.fotospor.com/");
        }

        private void gazete_Load(object sender, EventArgs e)
        {
            webBrowser1.ScriptErrorsSuppressed = true;
        }
    }
}
