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
    public partial class frmgrafikler : Form
    {
        public frmgrafikler()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source = YusufDemir; Initial Catalog = PersonelVeriTabani; Integrated Security = True");

        private void frmgrafikler_Load(object sender, EventArgs e)
        {
            //Grafik 1
            baglanti.Open();
            SqlCommand komutg1 = new SqlCommand("Select Persehir,count(*) From Tbl_Personel Group By Persehir",baglanti);
            SqlDataReader dr1 = komutg1.ExecuteReader();
            while (dr1.Read())
            {
                chart1.Series["Sehirler"].Points.AddXY(dr1[0], dr1[1]);
            }
            baglanti.Close();

            //Grafik 2
            //Grafik 1
            baglanti.Open();
            SqlCommand komutg2 = new SqlCommand("Select Permeslek,avg(Permaas) From Tbl_Personel Group By permeslek", baglanti);
            SqlDataReader dr2 = komutg2.ExecuteReader();
            while (dr2.Read())
            {
                chart2.Series["Meslek-Maas"].Points.AddXY(dr2[0], dr2[1]);
            }
            baglanti.Close();


        }
    }
}
