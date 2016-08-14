using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
namespace AkmanAjanda
{
    public partial class gunluk : Form
    {
        public gunluk()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=" + Application.StartupPath + "/akmanVT.accdb");

        private void gunluk_Load(object sender, EventArgs e)
        {
            
            veri_oku();
        }
        int id = 0;
        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                }
                id = Convert.ToInt32(listView2.SelectedItems[0].SubItems[0].Text);
                OleDbCommand veri = new OleDbCommand("select icerik from gunluk where baslik='" + listView2.SelectedItems[0].SubItems[1].Text + "' and id=" + id + "", baglanti);
                OleDbDataReader oku = null;
                OleDbCommand veri2 = new OleDbCommand("select baslik from gunluk where baslik='" + listView2.SelectedItems[0].SubItems[1].Text + "' and id=" + id + "", baglanti);
                OleDbDataReader oku2 = null;
                oku2 = veri2.ExecuteReader();
                while (oku2.Read())
                {
                    richTextBox2.Text = oku2.GetString(0).ToString();
                }
               
                oku = veri.ExecuteReader();
                while (oku.Read())
                {
                    richTextBox1.Text = oku.GetString(0).ToString();

                }
                oku.Close();
                oku2.Close();
                baglanti.Close();
            }
            catch
            {


            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed) baglanti.Open();
            string sorgu = "select id,baslik from gunluk where baslik like'" + textBox3.Text + "%' order by baslik";
            OleDbCommand komut = new OleDbCommand(sorgu, baglanti);
            OleDbDataReader oku = komut.ExecuteReader();
            listView2.Items.Clear();
            while (oku.Read())
            {
                ListViewItem kayit = new ListViewItem(oku["id"].ToString());
                kayit.SubItems.Add(oku["baslik"].ToString());

                listView2.Items.Add(kayit);
            }
            baglanti.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                //Textboxlara girilen değerleri veritabanımıza kaydetme kodları
                OleDbCommand kaydet = new OleDbCommand("insert into gunluk (baslik,icerik) values('" + richTextBox2.Text + "','" + richTextBox1.Text + "')", baglanti);
                if (baglanti.State==ConnectionState.Closed)
                {
                    baglanti.Open();
                }
                kaydet.ExecuteNonQuery();
                baglanti.Close();
                gunluk_Load(null,null);

            }
            catch
            {
                MessageBox.Show("Kayıt Yapılamadı Lütfen Tekrar Deneyiniz...");
            }
        }

        private void richTextBox2_MouseHover(object sender, EventArgs e)
        {
            label2.Text = "Başlık Bölümü";
        }

        private void richTextBox2_MouseLeave(object sender, EventArgs e)
        {
            label2.Text = ".";
        }

        private void richTextBox1_MouseHover(object sender, EventArgs e)
        {
            label2.Text = "Günlük Yazı Bölümü";
        }

        private void richTextBox1_MouseLeave(object sender, EventArgs e)
        {
            label2.Text = ".";
        }
        private void veri_oku()
        {

            OleDbCommand veri = new OleDbCommand("select * from gunluk order by id", baglanti);
            OleDbDataReader oku = null;
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();

            }
            oku = veri.ExecuteReader();
            listView2.Items.Clear();
            while (oku.Read())
            {
                ListViewItem kayit = new ListViewItem(oku["id"].ToString());
                kayit.SubItems.Add(oku["baslik"].ToString());

                listView2.Items.Add(kayit);
            }
            oku.Close();
            baglanti.Close();
        }
        int a;
        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
               
                a = int.Parse(listView2.SelectedItems[0].Text);
                OleDbCommand sil = new OleDbCommand("delete from gunluk where id =" + a + "", baglanti);
                if (baglanti.State==ConnectionState.Closed)
                {
                    baglanti.Open();

                }
                sil.ExecuteNonQuery();
                baglanti.Close();
                veri_oku();
                richTextBox2.Text = "";
                richTextBox1.Text = "";
                gunluk_Load(null,null);
            }
            catch
            {
                MessageBox.Show("Lütfen Silmek İstediğiniz Kayıtı Seçiniz.");
            }
        }
        
               
        private void button1_Click(object sender, EventArgs e)
        {
            OleDbCommand guncelle = new OleDbCommand("update gunluk set icerik=@icerik,baslik=@baslik where id=@id", baglanti);
            guncelle.Parameters.AddWithValue("@icerik",richTextBox1.Text);
            guncelle.Parameters.AddWithValue("@baslik", richTextBox2.Text);
            guncelle.Parameters.AddWithValue("@id", a = int.Parse(listView2.SelectedItems[0].Text));
            if (baglanti.State==ConnectionState.Closed)
            {
                baglanti.Open();   
            }
            guncelle.ExecuteNonQuery();
            baglanti.Close();
            gunluk_Load(null,null);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox2.Text = "";
            richTextBox1.Text = "";
        }
    }
}
