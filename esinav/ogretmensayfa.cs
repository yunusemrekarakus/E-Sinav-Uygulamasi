using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace esinav
{
    public partial class ogretmensayfa : Form
    {
        private NpgsqlConnection connection;
        public ogretmensayfa()
        {
            InitializeComponent();
        }
        string lesson_id = "";
        int teach_id = 0;
        private void Form9_Load(object sender, EventArgs e)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
                NpgsqlConnection connection = new NpgsqlConnection(connectionString);

                connection.Open();
                NpgsqlCommand ad = new NpgsqlCommand("SELECT * FROM teacher WHERE t_username='" + label4.Text + "'", connection);
                NpgsqlDataReader read = ad.ExecuteReader();
                while (read.Read())
                {
                    label5.Text = read["t_name"].ToString();
                    label6.Text = read["t_surname"].ToString();
                    label8.Text = read["t_phone_num"].ToString();
                    label10.Text = read["t_email"].ToString();
                    label13.Text = read["t_tc"].ToString();
                    pictureBox1.ImageLocation = read["t_pictures"].ToString();
                    teach_id = Convert.ToInt32(read["ogretmen_id"].ToString());
                }
                connection.Close();
            }
            catch (Exception hata)
            {
                MessageBox.Show("Hata : ", hata.Message);
            }

        }

        private void sınavOluşturToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
                NpgsqlConnection connection = new NpgsqlConnection(connectionString);

                string labelVeri = teach_id.ToString();

                sinavolustur sinavolustur = new sinavolustur();
                sinavolustur.AlinanVeri = labelVeri;
                sinavolustur.Show();
            }
            catch (Exception hata)
            {
                MessageBox.Show("Hata : ", hata.Message);
            }
        }

        private void sınavGeriBildirimlerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            geribildirim geribildirimler = new geribildirim();
            geribildirimler.teach_id = Convert.ToInt32(teach_id.ToString());
            geribildirimler.Show();
        }

        private void sınavlarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sinavlar  sinavlarr = new sinavlar();
            sinavlarr.teach_id = teach_id;
            sinavlarr.Show();
        }
    }
}
