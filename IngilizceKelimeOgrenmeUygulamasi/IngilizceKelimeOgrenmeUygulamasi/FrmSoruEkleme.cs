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
using System.Linq.Expressions;
namespace IngilizceKelimeOgrenmeUygulamasi
{
    public partial class FrmSoruEkleme : Form
    {
        public FrmSoruEkleme()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("server=localhost; Initial Catalog=Kelime;Integrated Security=SSPI");

        public string Yonetici;
        private void FrmSoruEkleme_Load(object sender, EventArgs e)
        {
            label5.Text = Yonetici;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Insert into KELIMELER (INGILIZCE, TURKCE) values (@p1, @p2)" ,baglanti);
            komut.Parameters.AddWithValue("@p1", TxtIngilizce.Text);
            komut.Parameters.AddWithValue("@p2", TxtTurkce.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kelime başarılı bir şekilde eklenmiştir");
            TxtIngilizce.Clear();
            TxtTurkce.Clear();

        }
    }
}
