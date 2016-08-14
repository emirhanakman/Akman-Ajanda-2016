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
    public partial class canliRadyo : Form
    {
        public canliRadyo()
        {
            InitializeComponent();
        }
        WebBrowser web = new WebBrowser();
        private void canliRadyo_Load(object sender, EventArgs e)
        {
            listBox1.Items.Add("PowerTurk FM");
            listBox1.Items.Add("Kral POP");
            listBox1.Items.Add("Damar FM");
            listBox1.Items.Add("Radyo Viva");
            listBox1.Items.Add("PowerTurk Akustik");
            listBox1.Items.Add("Radyo Doğa");
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (listBox1.SelectedItem.ToString() == "PowerTurk FM")
            {
                web.Navigate("google.com");
                axWindowsMediaPlayer1.URL = "http://195.142.3.50/power/PowerTurk_mpeg_128_tunein/icecast.audio?type=.mp3/;stream.mp3";
            }

            else if (listBox1.SelectedItem.ToString() == "Slow Turk")
            {
                web.Navigate("google.com");
                axWindowsMediaPlayer1.URL = "http://live.netd.com.tr/S2/HLS_LIVE/slowturk/64/prog_index.m3u8?key=c05f1a43bc4ab63268c4f3b4559dd47c&live=true&app=com.radyolar.slowturk";
            }
            else if (listBox1.SelectedItem.ToString() == "Kral POP")
            {
                axWindowsMediaPlayer1.Ctlcontrols.stop();
                web.Navigate("http://www.canli-radyo.biz/2013/09/kral-pop.html");

                web.ScriptErrorsSuppressed = true;
            }
            else if (listBox1.SelectedItem.ToString() == "Damar FM")
            {
                axWindowsMediaPlayer1.Ctlcontrols.stop();
                web.Navigate("http://www.canli-radyo.biz/2013/09/damar-fm.html");

                web.ScriptErrorsSuppressed = true;
            }
            else if (listBox1.SelectedItem.ToString() == "Radyo Viva")
            {
                axWindowsMediaPlayer1.Ctlcontrols.stop();
                web.Navigate("http://www.canli-radyo.biz/2013/07/radyo-viva.html");

                web.ScriptErrorsSuppressed = true;
            }
            else if (listBox1.SelectedItem.ToString() == "PowerTurk Akustik")
            {
                axWindowsMediaPlayer1.Ctlcontrols.stop();
                web.Navigate("http://canliradyodinle.web.tr/power-turk-akustik.html");

                web.ScriptErrorsSuppressed = true;
            }
            else if (listBox1.SelectedItem.ToString() == "Radyo Doğa")
            {
                axWindowsMediaPlayer1.Ctlcontrols.stop();
                web.Navigate("http://www.canli-radyo.biz/2013/08/radyo-doga.html");

                web.ScriptErrorsSuppressed = true;
            }
            label1.Text = listBox1.SelectedItem.ToString();

            }
            catch (Exception)
            {

                MessageBox.Show("Bir Hata Oluştu !");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
            listBox1.SetSelected(0, false); // Her seferinde listbox'ta değer seçilmemiş haline getiriyor
            if (listBox1.FindString(textBox1.Text) != -1) // Eğer değer listbox'ta var ise
            {
                listBox1.SetSelected(listBox1.FindString(textBox1.Text), true);
            }
            }
            catch (Exception)
            {
                MessageBox.Show("Bir Hata Oluştu.!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }

        private void button5_Click(object sender, EventArgs e)
        {
             axWindowsMediaPlayer1.Ctlcontrols.pause();
        }

        private void button6_Click(object sender, EventArgs e)
        {
                        axWindowsMediaPlayer1.Ctlcontrols.stop();

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
        
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
                    

        }
        }
    }
