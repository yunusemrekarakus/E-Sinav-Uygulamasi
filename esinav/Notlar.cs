using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using Npgsql;

namespace esinav
{
    public partial class Notlar : Form
    {
        public Notlar()
        {
            InitializeComponent();
        }
        public int sinav_id = 0;
        private void Notlar_Load(object sender, EventArgs e)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
                NpgsqlConnection connection = new NpgsqlConnection(connectionString);
                connection.Open();
                string notlar_sorgu = "SELECT lessons.lesson_name, exams.exam_names, exam_student.ogrenci_no, student.adi, student.soyadi, exam_student.exam_not FROM exams INNER JOIN exam_student ON exams.exam_id = exam_student.exam_id INNER JOIN lessons ON exams.lesson_id = lessons.lesson_id INNER JOIN student ON student.ogrenci_no = exam_student.ogrenci_no WHERE exam_student.exam_id = "+sinav_id+" AND exam_student.cozme_drm = true";
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(notlar_sorgu, connection);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            
                connection.Close();

                dataGridView1.Columns[0].HeaderText = "DERS ADI";
                dataGridView1.Columns[1].HeaderText = "SINAV ADI";
                dataGridView1.Columns[2].HeaderText = "ÖĞRENCİ NO";
                dataGridView1.Columns[3].HeaderText = "AD";
                dataGridView1.Columns[4].HeaderText = "SOYAD";
                dataGridView1.Columns[5].HeaderText = "SINAV NOT";
            }
            catch (Exception hata)
            {
                MessageBox.Show("Hata : ", hata.Message);
            }
            


        }
    }
}
