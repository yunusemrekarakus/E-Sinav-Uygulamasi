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
    public partial class geribildirim : Form
    {
        public geribildirim()
        {
            InitializeComponent();
        }
        public int teach_id = 0;
        private void geribildirim_Load(object sender, EventArgs e)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
                NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            
                connection.Open();
                string sorgu = "SELECT * FROM feedbacks WHERE exam_id IN (SELECT exam_id FROM exams WHERE lesson_id IN (SELECT lesson_id FROM teacher_lesson WHERE teacher_id = "+teach_id+")) ";
                NpgsqlDataAdapter datapter = new NpgsqlDataAdapter(sorgu, connection);
                DataSet ds = new DataSet();
                datapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                connection.Close();

            
                    dataGridView1.Columns[0].HeaderText = "Bildiri Numarası";
                    dataGridView1.Columns[1].HeaderText = "Sınav İd";
                    dataGridView1.Columns[2].HeaderText = "Bildiri Başlık";
                    dataGridView1.Columns[3].HeaderText = "Bildiri İçerik";
                    dataGridView1.Columns[4].HeaderText = "Bildiri Tarihi";
                    dataGridView1.Columns[5].HeaderText = "Öğrenci No";
            }
            catch (Exception hata)
            {
                MessageBox.Show("Hata : ", hata.Message);
            }

            
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                MessageBox.Show("Çift Tıklandı");
                GeriBildirimAyrinti geriBildirimAyrinti = new GeriBildirimAyrinti();
                geriBildirimAyrinti.textBox1.Text = dataGridView1.SelectedCells[2].Value.ToString();
                geriBildirimAyrinti.textBox2.Text = dataGridView1.SelectedCells[3].Value.ToString();
                geriBildirimAyrinti.label5.Text = dataGridView1.SelectedCells[5].Value.ToString();
                geriBildirimAyrinti.label6.Text = dataGridView1.SelectedCells[4].Value.ToString();
                geriBildirimAyrinti.sinav_id = Convert.ToInt32(dataGridView1.SelectedCells[1].Value.ToString());
                geriBildirimAyrinti.Show();
            }
            catch (Exception hata)
            {
                MessageBox.Show("Hata : ", hata.Message);
            }
            
        }
    }
}
