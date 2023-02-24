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


namespace WindowsFormsApp1
{
    public partial class frmistatistik : Form
    {
        public frmistatistik()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source = YusufDemir; Initial Catalog = PersonelVeriTabani; Integrated Security = True");

        private void frmistatistik_Load(object sender, EventArgs e)
        {
            // Toplam Personel sayısı
            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("select COUNT(*) From Tbl_Personel",baglanti);
            SqlDataReader dr1 = komut1.ExecuteReader();
            while(dr1.Read()){
                lbltoplampersonel.Text = dr1[0].ToString();
            }
            baglanti.Close();

            //Evli Personel Sayısı
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("select COUNT(*) From Tbl_Personel where Perdurum=1", baglanti);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                lblevlipersonel.Text = dr2[0].ToString();
            }
            baglanti.Close();

            //Bekar Personel Sayısı
            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("select COUNT(*) From Tbl_Personel where Perdurum=0", baglanti);
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                lblbekarpersonel.Text = dr3[0].ToString();
            }
            baglanti.Close();
            //Şehir Sayısı
            baglanti.Open();
            SqlCommand komut4 = new SqlCommand("select count(distinct(persehir)) From Tbl_Personel ", baglanti);
            SqlDataReader dr4 = komut4.ExecuteReader();
            while (dr4.Read())
            {
                lblsehirsayısı.Text = dr4[0].ToString();
            }
            baglanti.Close();

            //Toplam maaş
            baglanti.Open();
            SqlCommand komut5 = new SqlCommand("select sum(permaas) From Tbl_Personel ", baglanti);
            SqlDataReader dr5 = komut5.ExecuteReader();
            while (dr5.Read())
            {
                lbltoplamaas.Text = dr5[0].ToString();
            }
            baglanti.Close();

            //Ortalama Maaş
            baglanti.Open();
            SqlCommand komut6 = new SqlCommand("select avg(permaas) From Tbl_Personel ", baglanti);
            SqlDataReader dr6 = komut6.ExecuteReader();
            while (dr6.Read())
            {
                lblortmaas.Text = dr6[0].ToString();
            }
            baglanti.Close();
        }
    }
}
