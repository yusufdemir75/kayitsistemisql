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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

      

        Boolean bayrak;
        String bayrak2;
        String bayrak3;

        public void temizle()
        {
            txtad.Text = "";
            txtsoyad.Text = "";
            txtbxmaas.Text = "";
            txtmeslek.Text = "";
            cmbbxsehir.Text = "";
            txtad.Focus();
            radiobtnbekar.Checked = false;
            radiobtnevli.Checked = false;

        }
        SqlConnection baglanti= new SqlConnection("Data Source = YusufDemir; Initial Catalog = PersonelVeriTabani; Integrated Security = True");



        private void btnlistele_Click(object sender, EventArgs e)
        {
            this.tbl_PersonelTableAdapter.Fill(this.personelVeriTabaniDataSet.Tbl_Personel);

        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into Tbl_Personel(Perad,Persoyad,Persehir,Permaas,permeslek,perdurum) values(@p1,@p2,@p3,@p4,@p5,@p6)",baglanti);
            komut.Parameters.AddWithValue("@p1", txtad.Text);
            komut.Parameters.AddWithValue("@p2", txtsoyad.Text);
            komut.Parameters.AddWithValue("@p3", cmbbxsehir.Text);
            komut.Parameters.AddWithValue("@p4", txtbxmaas.Text);
            komut.Parameters.AddWithValue("@p5", txtmeslek.Text);
            komut.Parameters.AddWithValue("@p6", perdurum());

            komut.ExecuteNonQuery();
            MessageBox.Show("Personel eklendi");

            




            baglanti.Close();
        }
        public Boolean perdurum()
        {
            
            if (radiobtnbekar.Checked)
            {
                bayrak= false;
            }else if (radiobtnevli.Checked)
            {
                bayrak= true;
            }
            return bayrak;
        }

        private void btntemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            

            int secilendeger = dataGridView1.SelectedCells[0].RowIndex;
            txtid.Text= dataGridView1.Rows[secilendeger].Cells[0].Value.ToString();
            txtad.Text = dataGridView1.Rows[secilendeger].Cells[1].Value.ToString();
            txtsoyad.Text = dataGridView1.Rows[secilendeger].Cells[2].Value.ToString();
            cmbbxsehir.Text = dataGridView1.Rows[secilendeger].Cells[3].Value.ToString();
            txtbxmaas.Text = dataGridView1.Rows[secilendeger].Cells[4].Value.ToString();
            bayrak2 = dataGridView1.Rows[secilendeger].Cells[5].Value.ToString();
            if (bayrak2 =="True")
            {
                radiobtnevli.Checked = true;
            }else if(bayrak2 == "False")
            {
                radiobtnbekar.Checked = true;
            }
            txtmeslek.Text = dataGridView1.Rows[secilendeger].Cells[6].Value.ToString();
            

        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutSil = new SqlCommand("Delete From Tbl_Personel Where PerID=@k1", baglanti);
            komutSil.Parameters.AddWithValue("@k1",txtid.Text);
            komutSil.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıt Silindi");
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutguncelle = new SqlCommand("Update Tbl_Personel Set Perad=@a1,persoyad=@a2,persehir=@a3,permaas=@a4,perdurum=@a5,permeslek=@a6 where PerID=@a7",baglanti);
            komutguncelle.Parameters.AddWithValue("@a1", txtad.Text);
            komutguncelle.Parameters.AddWithValue("@a2", txtsoyad.Text);
            komutguncelle.Parameters.AddWithValue("@a3", cmbbxsehir.Text);
            komutguncelle.Parameters.AddWithValue("@a4", txtbxmaas.Text);
            if (radiobtnevli.Checked)
            {
                bayrak3 = "True";


            }
            else if (radiobtnbekar.Checked)
            {
                bayrak3 = "False";
            }
            komutguncelle.Parameters.AddWithValue("@a5", bayrak3);
            komutguncelle.Parameters.AddWithValue("@a6", txtmeslek.Text);
            komutguncelle.Parameters.AddWithValue("@a7", txtid.Text);

            komutguncelle.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıt Güncellendi");

        }

        private void btnistatistik_Click(object sender, EventArgs e)
        {
            frmistatistik fr = new frmistatistik();
            fr.Show();
        }

        private void btngrafik_Click(object sender, EventArgs e)
        {
            frmgrafikler fr2 = new frmgrafikler();
            fr2.Show();
        }
    }
}
