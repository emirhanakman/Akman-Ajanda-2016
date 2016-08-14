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
    public partial class rehberEkle : Form
    {
        public rehberEkle()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=" + Application.StartupPath + "/akmanVT.accdb");
        private void rehberEkle_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
                if (adi.Text=="" && soyadi.Text=="")
                {
                    MessageBox.Show("Lütfen İsim ve Soyisim Giriniz..");
                }
                else
                {
                    if (baglanti.State==ConnectionState.Closed)
                    {
                        baglanti.Open();
                    }
                    OleDbCommand komut = new OleDbCommand();
                    
                    komut.Connection = baglanti;
                    komut.CommandText = "INSERT INTO rehber(adi,soyadi,tel,adres,fax) VALUES(@adi,@soyadi,@tel,@adres,@fax)";
                    komut.Parameters.AddWithValue("@adi", adi.Text);
                    komut.Parameters.AddWithValue("@soyadi", soyadi.Text);
                    komut.Parameters.AddWithValue("@tel", tel.Text);
                    komut.Parameters.AddWithValue("@adres", adres.Text);
                    komut.Parameters.AddWithValue("@fax", faks.Text);

                    komut.ExecuteNonQuery();
                    
                    OleDbDataAdapter da = new OleDbDataAdapter("select * from rehber", baglanti);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                    
                }
                baglanti.Close();
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Refresh();
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }
            OleDbDataAdapter da = new OleDbDataAdapter("select * from rehber", baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglanti.Close();
        }
    }
}
