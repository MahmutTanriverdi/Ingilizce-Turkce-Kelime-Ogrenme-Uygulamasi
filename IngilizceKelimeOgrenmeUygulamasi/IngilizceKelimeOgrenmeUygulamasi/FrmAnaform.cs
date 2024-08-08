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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Windows.Forms.VisualStyles;
using System.Security.Cryptography.X509Certificates;

namespace IngilizceKelimeOgrenmeUygulamasi
{
    public partial class FrmAnaform : Form
    {
        public FrmAnaform()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("server=localhost; Initial Catalog=Kelime;Integrated Security=SSPI");
        Random rast = new Random();
        int sure = 90;
        int kelime = 0;

        void getir()
        {

            int sayi;
            sayi = rast.Next(1, 16);

            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from KELIMELER where id=@p1", baglanti);
            komut.Parameters.AddWithValue("@p1", sayi);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                TxtIngilizce.Text = dr[1].ToString();
                LblCevap.Text = dr[2].ToString();
                LblCevap.Text = LblCevap.Text.ToLower();
            }
            baglanti.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            getir();
            timer1.Start();
            label5.Text = mesaj;
        }
        public string mesaj;
        private void TxtTurkce_TextChanged(object sender, EventArgs e)
        {
            if(TxtTurkce.Text == LblCevap.Text)
            {
                kelime++;
                LblKelime.Text = kelime.ToString();
                getir();
                TxtTurkce.Clear();

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            sure--;
            LblSure.Text = sure.ToString();
            if (sure == 0)
            {
                TxtTurkce.Enabled = false;
                TxtIngilizce.Enabled = false;
                timer1.Stop();
                MessageBox.Show("Tebrikler '"+ LblKelime.Text + "' doğru cevabınız var","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }
    }
}
