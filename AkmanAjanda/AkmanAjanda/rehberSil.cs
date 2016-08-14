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
    public partial class rehberSil : Form
    {
        public rehberSil()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=" + Application.StartupPath + "/akmanVT.accdb");

        private void rehberSil_Load(object sender, EventArgs e)
        {
            soyadi.Text = "";
            adi.Text = "";
            tel.Text = "";
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

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
        OleDbCommand komut = new OleDbCommand();
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DialogResult tus = MessageBox.Show("Seçili Alandaki Kayıtı Silmek İstiyor Musunuz ? ", " - Silme İşlemi - ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (tus == DialogResult.Yes)
            {
                komut.Connection = baglanti;
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                }
                komut.CommandText = "delete * from rehber where adi=@adi";
                komut.Parameters.AddWithValue("@adi", dataGridView1.SelectedCells[0].Value.ToString());
                komut.ExecuteNonQuery();
                dataGridView1.Refresh();
                rehberSil_Load(null,null);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
