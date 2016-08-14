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
    public partial class rehberSorgu : Form
    {
        public rehberSorgu()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=" + Application.StartupPath + "/akmanVT.accdb");
        private void button1_Click(object sender, EventArgs e)
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

        private void adi_TextChanged(object sender, EventArgs e)
        {
            soyadi.Text = "";
            tel.Text = "";
            dataGridView1.Refresh();
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }
            OleDbDataAdapter da = new OleDbDataAdapter("select * from rehber where adi lIKE '%" + adi.Text + "%'", baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglanti.Close();
        }

        private void soyadi_TextChanged(object sender, EventArgs e)
        {
            adi.Text = "";
            tel.Text = "";
            dataGridView1.Refresh();
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }
            OleDbDataAdapter da = new OleDbDataAdapter("select * from rehber where soyadi lIKE '%" + soyadi.Text + "%'", baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglanti.Close();
        }

        private void tel_TextChanged(object sender, EventArgs e)
        {
            soyadi.Text = "";
            adi.Text = "";
            dataGridView1.Refresh();
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }
            OleDbDataAdapter da = new OleDbDataAdapter("select * from rehber where tel lIKE '%" + tel.Text + "%'", baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglanti.Close();
        }
        
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}
