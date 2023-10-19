using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace esinav
{
    public partial class ogretmenkayit : Form
    {
        public ogretmenkayit()
        {
            InitializeComponent();
        }
        private NpgsqlConnection connection;
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Öğretmenin Fotoğrafını Seçiniz.";
            ofd.ShowDialog();
            string resimyolu = ofd.FileName;
            pictureBox1.ImageLocation = resimyolu;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            try
            {
                connection.Open();
                NpgsqlCommand ogretmenkayit = new NpgsqlCommand("INSERT INTO teacher (t_name,t_surname,t_tc,t_phone_num,t_email,t_username,t_password,t_pictures) VALUES (@t_name,@t_surname,@t_tc,@t_phone_num,@t_email,@t_username,@t_password,@t_pictures)", connection);
                ogretmenkayit.Parameters.AddWithValue("t_name", t_adi.Text.Trim());
                ogretmenkayit.Parameters.AddWithValue("t_surname", t_soyadi.Text.Trim());
                ogretmenkayit.Parameters.AddWithValue("t_tc", t_tc.Text.Trim());
                ogretmenkayit.Parameters.AddWithValue("t_phone_num", t_tel.Text.Trim());
                ogretmenkayit.Parameters.AddWithValue("t_email", t_email.Text.Trim());
                ogretmenkayit.Parameters.AddWithValue("t_username", t_tc.Text.Trim());
                ogretmenkayit.Parameters.AddWithValue("t_password", t_adi.Text.Trim() + t_tc.Text.Trim());
                ogretmenkayit.Parameters.AddWithValue("t_pictures", pictureBox1.ImageLocation);
            
            
                ogretmenkayit.ExecuteNonQuery();
                MessageBox.Show("Öğretmen Kaydedildi KULLANICI ADI : TC ----- PAROLA : İSİM+TC (AHMET12345677123) 'ŞİFRENİZİ DEĞİŞTİRİN'");
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
            
        }
    }
}
