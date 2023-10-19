using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace esinav
{
    public partial class not_görüntlüleme : Form
    {
        public not_görüntlüleme()
        {
            InitializeComponent();
        }
        public int ogr_no = 0;
        private NpgsqlConnection connection;
        private void not_görüntlüleme_Load(object sender, EventArgs e)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
                NpgsqlConnection connection = new NpgsqlConnection(connectionString);
                connection.Open();
                string sorgu = "SELECT lessons.lesson_name, exams.exam_names, exam_student.exam_not FROM exams INNER JOIN exam_student ON exams.exam_id = exam_student.exam_id INNER JOIN lessons ON exams.lesson_id = lessons.lesson_id WHERE exam_student.ogrenci_no = "+ogr_no+" AND exam_student.cozme_drm = true";
                NpgsqlDataAdapter datapter = new NpgsqlDataAdapter(sorgu, connection);
                DataSet ds = new DataSet();
                datapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                connection.Close();


                dataGridView1.Columns[0].HeaderText = "DERS ADI";
                dataGridView1.Columns[1].HeaderText = "SINAV ADI";
                dataGridView1.Columns[2].HeaderText = "NOT";
            }
            catch (Exception hata)
            {
                MessageBox.Show("Hata : ", hata.Message);
            }
        }
    }
}
