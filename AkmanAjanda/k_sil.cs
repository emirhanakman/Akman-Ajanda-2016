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
    public partial class k_sil : Form
    {
        public k_sil()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=" + Application.StartupPath + "/akmanVT.accdb");

        private void k_sil_Load(object sender, EventArgs e)
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
        }
        OleDbCommand komut = new OleDbCommand();
        private void button1_Click(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }
            komut.CommandText = "delete * from admin where kadi=@kadi";
            komut.Connection = baglanti;
            komut.Parameters.AddWithValue("@kadi", comboBox1.Text);
            
            komut.ExecuteNonQuery();
            MessageBox.Show("Kullanıcı Başarı İle Silindi !");
            comboBox1.Refresh();
            k_sil_Load(null,null);
        }
    }
}