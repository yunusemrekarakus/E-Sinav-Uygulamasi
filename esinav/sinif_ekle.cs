using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace esinav
{
    public partial class sinif_ekle : Form
    {

        private NpgsqlConnection connection;
        public sinif_ekle()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
                NpgsqlConnection connection = new NpgsqlConnection(connectionString);

                connection.Open();
                NpgsqlCommand sınıf_ekle = new NpgsqlCommand("INSERT INTO class (class_num, branch) values (@class_num, @branch)", connection);
                sınıf_ekle.Parameters.AddWithValue("@class_num", Convert.ToInt32(textBox1.Text.Trim()));
                sınıf_ekle.Parameters.AddWithValue("@branch", textBox2.Text.Trim());
                sınıf_ekle.ExecuteNonQuery();
                MessageBox.Show("Sınıf Eklendi ");
                connection.Close();
            }
            catch (Exception hata)
            {
                MessageBox.Show("Hata : ", hata.Message);
            }
            
        }

        
    }
}
