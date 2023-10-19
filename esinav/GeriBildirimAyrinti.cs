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
    public partial class GeriBildirimAyrinti : Form
    {
        private NpgsqlConnection connection;
        public GeriBildirimAyrinti()
        {
            InitializeComponent();
        }
        public int sinav_id = 0;
        private void GeriBildirimAyrinti_Load(object sender, EventArgs e)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
                NpgsqlConnection connection = new NpgsqlConnection(connectionString);

                connection.Open();
                NpgsqlCommand sinav_isim = new NpgsqlCommand("SELECT * FROM exams WHERE exam_id = "+sinav_id+"", connection);
                NpgsqlDataReader sinavisimreader = sinav_isim.ExecuteReader();
                while (sinavisimreader.Read())
                {
                    textBox3.Text = sinavisimreader["exam_names"].ToString();
                }
                connection.Close();
            }
            catch (Exception hata)
            {
                MessageBox.Show("Hata : ", hata.Message);
            }
            
        }
    }
}
