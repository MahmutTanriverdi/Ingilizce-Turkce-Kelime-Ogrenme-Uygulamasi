using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Reflection.Emit;

namespace IngilizceKelimeOgrenmeUygulamasi
{
    public partial class FrmGiris : Form
    {
        public FrmGiris()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("server=localhost; Initial Catalog=Kelime;Integrated Security=SSPI");
        private void button1_Click(object sender, EventArgs e)
        {
            if(TxtAdSoyad.Text == "")
            {
                MessageBox.Show("Ad Soyad Boş Geçilemez");
            }
            else
            {
                FrmAnaform frm = new FrmAnaform();
                frm.mesaj = TxtAdSoyad.Text;
                frm.Show();
                this.Hide();
            }
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Insert into KULLANICIPANELI (ADSOYAD) values (@p1)", baglanti);
            komut.Parameters.AddWithValue("@p1", TxtAdSoyad.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmYonetici frm = new FrmYonetici();
            frm.Show();
            this.Hide();
        }

        
    }
}
