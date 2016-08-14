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
    public partial class k_ekle : Form
    {
        public k_ekle()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=" + Application.StartupPath + "/akmanVT.accdb");

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
              
                OleDbCommand kaydet = new OleDbCommand("insert into admin (kadi,sifre) values(@kadi,@sifre)", baglanti);
                kaydet.Parameters.AddWithValue("@kadi",textBox1.Text);
                kaydet.Parameters.AddWithValue("@sifre",textBox2.Text);
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                }
                kaydet.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Yeni Kullanıcı Sisteme Eklendi !");
                textBox2.Text = "";
                textBox1.Text = "";
                

            }
            catch
            {
                MessageBox.Show("Kayıt Yapılamadı Lütfen Tekrar Deneyiniz...");
            }
        }
    }
}
