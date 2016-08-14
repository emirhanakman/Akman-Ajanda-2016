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
    public partial class anaForm : Form
    {
        public anaForm()
        {
            InitializeComponent();
        }

        private void eklemeİşlemleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rehberEkle ekle = new rehberEkle();
            ekle.Show();
        }

        private void anaForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void sorgulamaİşlemleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rehberSorgu sorgu = new rehberSorgu();
            sorgu.Show();
        }

        private void anaForm_Load(object sender, EventArgs e)
        {
            timer1.Start();
            pictureBox2.BackColor = Color.Transparent;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Text = "- Akman Ajanda -     Saat :  "+DateTime.Now.ToLongTimeString()+"     -    Tarih :   "+DateTime.Now.ToShortDateString();
            
        }

        private void silmeİşlemleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rehberSil sil = new rehberSil();
            sil.Show();
        }

        private void canlıRadyoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            canliRadyo radyo = new canliRadyo();
            radyo.Show();
        }

        private void notDefteriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            not not = new not();
            not.Show();
        }

        private void günlükProgramcığıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gunluk gunluk = new gunluk();
            gunluk.Show();
        }

        private void kullanıcıEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            k_ekle ekle = new k_ekle();
            ekle.Show();
        }

        private void kullanıcıSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            k_sil sil = new k_sil();
            sil.Show();
        }

        private void kullanıcıGüncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            k_guncelle guncel = new k_guncelle();
            guncel.Show();
        }

        private void webTarayıcıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tarayici t = new tarayici();
            t.Show();
        }

        private void gazetelerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gazete g = new gazete();
            g.Show();
        }

        private void button49_Click(object sender, EventArgs e)
        {

        }

        private void programHakkındaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hakkinda h = new hakkinda();
            h.Show();
        }
    }
}
