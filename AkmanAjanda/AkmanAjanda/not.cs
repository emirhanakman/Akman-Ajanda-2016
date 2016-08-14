using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace AkmanAjanda
{
    public partial class not : Form
    {
        public not()
        {
            InitializeComponent();
        }

        private void hakkındaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        bool islem; 
        string dadi = "";
        void DosyaFarkliKaydet()
        {
            SaveFileDialog sf = new SaveFileDialog();
            sf.InitialDirectory = "d:\\";
            sf.Filter = "Text Dosyalar (*.txt)|*.txt|Tüm Dosyalar (*.*)|*.*";
            DialogResult tus = sf.ShowDialog();
            if (tus == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(sf.FileName);
                sw.WriteLine(richTextBox1.Text);
                sw.Close();
                dadi = sf.FileName;
                
            }
            islem = false;
        }
        void DosyaAc()
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Title = "Dosya Seç";
            of.InitialDirectory = "d:\\";
            of.Filter = "Text Dosyalar (*.txt)|*.txt|Tüm Dosyalar (*.*)|*.*";
            DialogResult tus = of.ShowDialog();
            if (tus== DialogResult.OK)
            {
                StreamReader sr = new StreamReader(of.FileName);
            richTextBox1.Text=sr.ReadToEnd();
                sr.Close();
                this.Text=of.SafeFileName+"-Not Defteri";
                islem = false;
                dadi=of.FileName;
                
            }
        }

        void DosyaKaydet()
        {

            if (islem == true)
            {
                if (dadi == "Yeni Metin Belgesi")
                {
                    SaveFileDialog sf = new SaveFileDialog();
                    sf.InitialDirectory = "d:\\";
                    sf.Filter = "Metin Dosyaları (*.txt)|*.txt|Tüm Dosyalar (*.*)|*.*";
                    DialogResult tus = sf.ShowDialog();
                    if (tus == DialogResult.OK)
                    {
                        StreamWriter sw = new StreamWriter(sf.FileName);
                        sw.WriteLine(richTextBox1.Text);
                        sw.Close();
                        dadi = sf.FileName;
                    }
                }

                else
                {
                    StreamWriter sw = new StreamWriter(dadi);
                    sw.WriteLine(richTextBox1.Text);
                    sw.Close();
                }

                islem = false;
            }
        }
        private void yeniToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (islem == true)
            {
                DialogResult tus = MessageBox.Show(" Yaptığınız Değişiklikleri Kaydetmek İstiyor Musunuz ?", "Kayıt İşlemi", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (tus == DialogResult.Yes)
                {
                    DosyaKaydet();
                    richTextBox1.Clear();
                    islem = false;
                    dadi = "Yeni Metin Belgesi";


                }
                else if (tus == DialogResult.No)
                {
                    richTextBox1.Clear();
                    islem = false;
                    dadi = "Yeni Metin Belgesi";


                }

            }
        }

        private void açToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (islem == true)
            {
                DialogResult tus = MessageBox.Show(" Dosya Açmadan Önce Yapğtığınız Değişiklikleri Kaydetmek İstiyor Musunuz ?", "Kayıt İşlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (tus == DialogResult.Yes)
                {
                    DosyaKaydet();

                }

            }
            DosyaAc();
        }

        private void kaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {

            DosyaKaydet();
            islem = false;
        }

        private void farklıKaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DosyaFarkliKaydet();
            islem = false;
        }

        private void yazdırToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintDialog prt = new PrintDialog();
            prt.ShowDialog();
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void geriAlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void ileriAlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Redo();
        }

        private void kesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void kopyalaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void yapıştırToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void tümünüSeçToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void sağaHizalaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Right;
        }

        private void ortalaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void solaHizalaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
        }

        private void renkSeçimiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            DialogResult tus = fd.ShowDialog();
            if (tus == DialogResult.OK)
            {
                richTextBox1.SelectionFont = fd.Font;

            }
        }

        private void renkSeçimiToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            DialogResult tus = cd.ShowDialog();
            if (tus == DialogResult.OK)
            {
                richTextBox1.SelectionColor = cd.Color;

            }
        }

        private void renkSeçimiToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            DialogResult tus = fd.ShowDialog();
            if (tus == DialogResult.OK)
            {
                richTextBox1.SelectionFont = fd.Font;

            }
        }

        private void renkSeçimiToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            DialogResult tus = cd.ShowDialog();
            if (tus == DialogResult.OK)
            {
                richTextBox1.SelectionColor = cd.Color;

            }
        }

        private void ortalaToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void sağaHizalaToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Right;
        }

        private void solaHizalaToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
        }

        private void tümünüSeçToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void yapıştırToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            richTextBox1.Paste();

        }

        private void kopyalaToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void kesToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

    }
}
