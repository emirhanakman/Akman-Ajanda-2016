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
    public partial class k_guncelle : Form
    {
        public k_guncelle()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=" + Application.StartupPath + "/akmanVT.accdb");
        OleDbCommand komut = new OleDbCommand();
        private void k_guncelle_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }
            OleDbCommand cmd = new OleDbCommand("select kadi from admin", baglanti);
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["kadi"]);
            }
            baglanti.Close();
            textBox1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            comboBox1.Enabled = false;
            textBox1.Enabled = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }
            OleDbCommand cmd = new OleDbCommand("update admin set kadi=@kadi,sifre=@sifre where kadi=@kadi", baglanti);
            cmd.Parameters.AddWithValue("@kadi",comboBox1.Text);
            cmd.Parameters.AddWithValue("@sifre",textBox1.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show(comboBox1.Text+" İsimli Kullanıcının Şifresi Başarı İle Güncellendi");
            baglanti.Close();
        }
    }
}
