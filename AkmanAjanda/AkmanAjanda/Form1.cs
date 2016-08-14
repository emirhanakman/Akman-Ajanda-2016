using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.OleDb;
namespace AkmanAjanda
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=" + Application.StartupPath + "/akmanVT.accdb");
        OleDbCommand komut = new OleDbCommand();
        OleDbDataAdapter adaptor = new OleDbDataAdapter();
        DataSet ds = new DataSet();
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                checkBox1.Text = "Şifreyi Gizle";
                textBox2.PasswordChar = '*';
            }
            else
            {
                checkBox1.Text = "Şifreyi Göster";
                textBox2.PasswordChar = '\0';
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        anaForm form = new anaForm();
        private void button1_Click(object sender, EventArgs e)
        {
            
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }
            komut.Connection = baglanti;
            komut.CommandText = "Select * from admin where kAdi=@kadi and sifre=@sifre";
            komut.Parameters.AddWithValue("@kadi", textBox1.Text);
            komut.Parameters.AddWithValue("@sifre", textBox2.Text);
            object sonuc = komut.ExecuteScalar(); // admin yanıt geliyor mu ?
            OleDbDataReader oku = komut.ExecuteReader();
            if (sonuc == null)
            {
                DialogResult tus=MessageBox.Show("Kullanıcı Adınız veya Şifreniz Hatalı !", "Hata ! ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                textBox1.Text = "";  // Eğer kullanıcı adı ve şifre doğru değilse, textboxları temizle.
                textBox2.Text = "";
                if (DialogResult.OK==tus)
                {
                    Application.Exit();
                }
               
            }
            else
            {
                this.Hide(); // şifre ve kullanıcı adı doğruysa ana sayfaya yönlendir.     
                form.Show();
                baglanti.Close();  // kullanıcı adı ve şifre doğruysa ve sayfaya yönlendirdiyse bağlantıyı kapat.
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
