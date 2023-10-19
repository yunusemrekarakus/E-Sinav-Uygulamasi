using Npgsql;
using NpgsqlTypes;
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
    public partial class geribildirimolustur : Form
    {
        private NpgsqlConnection connection;
        public geribildirimolustur()
        {
            InitializeComponent();
        }
        public int ogr_no = 0;
        private void geribildirimolustur_Load(object sender, EventArgs e)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
                NpgsqlConnection connection = new NpgsqlConnection(connectionString);


                connection.Open();
                NpgsqlCommand teachs = new NpgsqlCommand("SELECT * FROM exams", connection);
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(teachs);
                DataTable dataTable = new DataTable();
                da.Fill(dataTable);
                comboBox1.ValueMember = "exam_id";
                comboBox1.DisplayMember = "exam_names";
                comboBox1.DataSource = dataTable;
                connection.Close();
            }
            catch (Exception hata)
            {
                MessageBox.Show("Hata : ", hata.Message);
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                

                DateTime currentTime = DateTimeOffset.Now.DateTime;

                
                MessageBox.Show("Current Timestamp: " + currentTime);


                string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
                NpgsqlConnection connection = new NpgsqlConnection(connectionString);

                connection.Open();
                NpgsqlCommand geribildirimekle = new NpgsqlCommand("INSERT INTO feedbacks (exam_id, feedback_title, feedback_body, feedback_date, ogrenci_no) values (@ex_id, @fb_title, @fb_body, @fb_date, @ogr_no)", connection);
                geribildirimekle.Parameters.AddWithValue("@ex_id", comboBox1.SelectedValue);
                geribildirimekle.Parameters.AddWithValue("@fb_title", textBox1.Text);
                geribildirimekle.Parameters.AddWithValue("@fb_body", textBox2.Text);
                geribildirimekle.Parameters.AddWithValue("@fb_date", NpgsqlDbType.TimeTZ).Value = currentTime;
                geribildirimekle.Parameters.AddWithValue("@ogr_no", ogr_no);
                geribildirimekle.ExecuteNonQuery();
                MessageBox.Show("Geri Bildiriminiz Eklendi !");
                connection.Close();
            }
            catch(Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
            
        }
    }
}
