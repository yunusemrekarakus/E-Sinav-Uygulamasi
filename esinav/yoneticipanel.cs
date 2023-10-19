using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace esinav
{
    public partial class yoneticipanel : Form
    {
        
        public yoneticipanel()
        {
            InitializeComponent();
        }
        private NpgsqlConnection connection;
        private void panel7_MouseClick(object sender, MouseEventArgs e)
        {
            this.Close();
            
        }
        private void Form2_Load(object sender, EventArgs e)
        {

            try
            {
                AttachUpperCaseEventHandlers(this);

                string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
                NpgsqlConnection connection = new NpgsqlConnection(connectionString);


                connection.Open();
                NpgsqlCommand ad = new NpgsqlCommand("SELECT * FROM manager WHERE username='"+label4.Text+"'", connection);
                NpgsqlDataReader read = ad.ExecuteReader();
                while (read.Read())
                {
                    label5.Text = read["name"].ToString();
                    label6.Text = read["surname"].ToString();
                    label8.Text = read["phone_num"].ToString();
                    label10.Text = read["email"].ToString();
                    label13.Text = read["tc"].ToString();
                    pictureBox1.ImageLocation = read["pictures"].ToString();
                }
                connection.Close();

                connection.Open();
                string sorgu = "SELECT * FROM student";
                NpgsqlDataAdapter datapter = new NpgsqlDataAdapter(sorgu, connection);
                DataSet ds = new DataSet();
                datapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                connection.Close();


                connection.Open();

                string mevcut = ("SELECT count(*) FROM student");

                NpgsqlCommand mevcutsayi = new NpgsqlCommand(mevcut, connection);
                NpgsqlDataReader readmevcut = mevcutsayi.ExecuteReader();

                while (readmevcut.Read())
                {
                    labelMevcut.Text = readmevcut["count"].ToString();
                }

                connection.Close();
                dataGridView1.Columns[0].HeaderText = "ÖĞRENCİ NO";
                dataGridView1.Columns[1].HeaderText = "AD";
                dataGridView1.Columns[2].HeaderText = "SOYAD";
                dataGridView1.Columns[3].HeaderText = "TC";
                dataGridView1.Columns[4].HeaderText = "SINIF NUMARASI";
                dataGridView1.Columns[5].HeaderText = "CİNSİYET";
                dataGridView1.Columns[6].HeaderText = "ADRES";
                dataGridView1.Columns[7].HeaderText = "VELİ İD";
                dataGridView1.Columns[8].HeaderText = "ÖĞRENCİ PAROLA";
                dataGridView1.Columns[9].HeaderText = "ÖĞRENCİ RESİM YOLU";
            }
            catch (Exception hata)
            {
                MessageBox.Show("Hata : ", hata.Message);
            }
            


        }
        private void öğrenciKayıtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            ogrencikayit frm4 = new ogrencikayit();
            frm4.Show();
        }
        private void öğretmenEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            ogretmenkayit frm5 = new ogretmenkayit();
            frm5.Show();
        }
        private void dersEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            dersekleme frm6 = new dersekleme();
            frm6.Show();
        }
        private void öğrenciBilgiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            ogrencibilgi frm7 = new ogrencibilgi();
            frm7.Show();
        }
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            sinif_ekle sinif_Ekle = new sinif_ekle();
            sinif_Ekle.Show();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
                NpgsqlConnection connection = new NpgsqlConnection(connectionString);


                connection.Open();
                DataTable veri = new DataTable();
                NpgsqlDataAdapter da = new NpgsqlDataAdapter("SELECT * FROM student", connection);
                da.Fill(veri);
                dataGridView1.DataSource = veri;
                connection.Close();

                connection.Open();
                string mevcut = ("SELECT count(*) FROM student");

                NpgsqlCommand mevcutsayi = new NpgsqlCommand(mevcut, connection);
                NpgsqlDataReader readmevcut = mevcutsayi.ExecuteReader();

                while (readmevcut.Read())
                {
                    labelMevcut.Text = readmevcut["count"].ToString();
                }

                connection.Close();
            }
            catch (Exception hata)
            {
                MessageBox.Show("Hata : ", hata.Message);
            }
            

        }
        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }
        private void AttachUpperCaseEventHandlers(Control control)
        {
            try
            {
                foreach (Control childControl in control.Controls)
                {
                    if (childControl is System.Windows.Forms.TextBox)
                    {
                        childControl.KeyPress += TextBox_KeyPress;
                    }
                    else if (childControl.HasChildren)
                    {
                        AttachUpperCaseEventHandlers(childControl);
                    }
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show("Hata : ", hata.Message);
            }
            
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
                NpgsqlConnection connection = new NpgsqlConnection(connectionString);
                connection.Open();
                
                string sorgu = "SELECT * FROM student WHERE adi LIKE '%"+textBox1.Text.Trim()+"%'";
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, connection);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                connection.Close();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
                NpgsqlConnection connection = new NpgsqlConnection(connectionString);
                connection.Open();

                string sorgu = "SELECT * FROM student WHERE soyadi LIKE '%" + textBox2.Text.Trim() + "%'";
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, connection);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                connection.Close();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
                NpgsqlConnection connection = new NpgsqlConnection(connectionString);
                connection.Open();

                string sorgu = "SELECT * FROM student WHERE tc LIKE '%" + textBox4.Text.Trim() + "%'";
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, connection);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                connection.Close();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
        }
    }
}
