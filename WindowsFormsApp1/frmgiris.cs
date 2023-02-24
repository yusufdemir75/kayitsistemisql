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
    public partial class frmgiris : Form
    {
        public frmgiris()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source = YusufDemir; Initial Catalog = PersonelVeriTabani; Integrated Security = True");

        private void btngiris_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * From Tbl_Yonetici where KullaniciAd=@p1 and Sifre=@p2",baglanti);

            komut.Parameters.AddWithValue("@p1", txtkullanici.Text);
            komut.Parameters.AddWithValue("@p2", txtsifre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                Form1 formana = new Form1();
                formana.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı kullanıcı adı veya şifre");
            }
            


            baglanti.Close();

        }

        private void frmgiris_Load(object sender, EventArgs e)
        {
            txtkullanici.Text = "admin34";
            txtsifre.Text = "12345";
        }
    }
}
