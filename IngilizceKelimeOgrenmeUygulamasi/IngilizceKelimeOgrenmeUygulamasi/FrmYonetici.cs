using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace IngilizceKelimeOgrenmeUygulamasi
{
    public partial class FrmYonetici : Form
    {
        public FrmYonetici()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("server=localhost; Initial Catalog=Kelime;Integrated Security=SSPI");
        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from YONETICIPANELI where KULLANICIADI=@p1 and SIFRE=@p2", baglanti);
            komut.Parameters.AddWithValue("@p1", TxtKullaniciAdi.Text);
            komut.Parameters.AddWithValue("@p2", TxtSifre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                MessageBox.Show("Tebrikler! Başarılı bir şekilde giriş yaptınız");
                FrmSoruEkleme frm = new FrmSoruEkleme();
                frm.Yonetici = TxtKullaniciAdi.Text;
                frm.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Kullanıcı Adı ya da Şifre Yanlış");
            }
            baglanti.Close();
        }
    }
}
