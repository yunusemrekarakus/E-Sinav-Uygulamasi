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
    public partial class sinavlar : Form
    {
        public sinavlar()
        {
            InitializeComponent();
        }
        private NpgsqlCommand connection;
        public int teach_id = 0;
        void yenile()
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
                NpgsqlConnection connection = new NpgsqlConnection(connectionString);

                connection.Open();
                string sorgu = "SELECT * FROM exams WHERE lesson_id IN(SELECT lesson_id FROM lessons WHERE teacher_id = " + teach_id + ")";
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, connection);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];

                connection.Close();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dataGridView1.Columns[0].HeaderText = "Sınav Numarası";
                    dataGridView1.Columns[1].HeaderText = "Sınav Adı";
                    dataGridView1.Columns[2].HeaderText = "Ders Numarası";
                    dataGridView1.Columns[3].HeaderText = "Sınav Tarihi";
                    dataGridView1.Columns[4].HeaderText = "Başlama Saati";
                    dataGridView1.Columns[5].HeaderText = "Son Başlama Saati";
                    dataGridView1.Columns[6].HeaderText = "Sınav Süresi (dk)";


                }
            }
            catch (Exception hata)
            {
                MessageBox.Show("Hata : ", hata.Message);
            }
            
        }

        private void sinavlar_Load(object sender, EventArgs e)
        {
            yenile();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
                NpgsqlConnection connection = new NpgsqlConnection(connectionString);

                sinavhazirlamapanel sinavhazirlamapanell = new sinavhazirlamapanel();
                sinavhazirlamapanell.sinav_id = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
            
                sinavhazirlamapanell.Show();
            }
            catch (Exception hata)
            {
                MessageBox.Show("Hata : ", hata.Message);
            }
            
        }
        int ex_id = 0;
        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right) // Sağ tıklama kontrolü
                {
                    DialogResult result = MessageBox.Show(dataGridView1.SelectedCells[1].Value.ToString() + " Sınavını Kaldırmak İstiyormusunuz ?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
                        NpgsqlConnection connection = new NpgsqlConnection(connectionString);
                        connection.Open();
                        // reply tablosundan kayıtları sil
                        string deleteReplyQuery = "DELETE FROM reply WHERE questions_id IN(SELECT question_id FROM questions WHERE exam_id = @examId)";
                        using (NpgsqlCommand command = new NpgsqlCommand(deleteReplyQuery, connection))
                        {
                            command.Parameters.AddWithValue("@examId", dataGridView1.SelectedCells[0].Value);
                            command.ExecuteNonQuery();
                        }

                        // questions tablosundan kayıtları sil
                        string deleteQuestionsQuery = "DELETE FROM questions WHERE exam_id = @examId";
                        using (NpgsqlCommand command = new NpgsqlCommand(deleteQuestionsQuery, connection))
                        {
                            command.Parameters.AddWithValue("@examId", dataGridView1.SelectedCells[0].Value);
                            command.ExecuteNonQuery();
                        }


                        // exam_student tablosundan kayıtları sil
                        string deleteExamStudentQuery = "DELETE FROM exam_student WHERE exam_id = @examId";
                        using (NpgsqlCommand command = new NpgsqlCommand(deleteExamStudentQuery, connection))
                        {
                            command.Parameters.AddWithValue("@examId", dataGridView1.SelectedCells[0].Value);
                            command.ExecuteNonQuery();
                        }

                        // feedbacks tablosundan kayıtları sil
                        string deleteFeedbacksQuery = "DELETE FROM feedbacks WHERE exam_id = @examId";
                        using (NpgsqlCommand command = new NpgsqlCommand(deleteFeedbacksQuery, connection))
                        {
                            command.Parameters.AddWithValue("@examId", dataGridView1.SelectedCells[0].Value);
                            command.ExecuteNonQuery();
                        }

                        // exams tablosundan tekrar kayıtları sil
                        string deleteExamsAgainQuery = "DELETE FROM exams WHERE exam_id = @examId";
                        using (NpgsqlCommand command = new NpgsqlCommand(deleteExamsAgainQuery, connection))
                        {
                            command.Parameters.AddWithValue("@examId", dataGridView1.SelectedCells[0].Value);
                            command.ExecuteNonQuery();
                        }

                        connection.Close();
                        MessageBox.Show("Sınavınız Silinmiştir....!");
                        yenile();
                    }
                    else if (result == DialogResult.No)
                    {
                        // Hayır seçeneği seçildiğinde yapılacak işlemler
                        // ...
                    }
                }
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
                string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
                NpgsqlConnection connection = new NpgsqlConnection(connectionString);

                Notlar notlar = new Notlar();
                notlar.sinav_id = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
                notlar.ShowDialog();
            }
            catch (Exception hata)
            {
                MessageBox.Show("Hata : ", hata.Message);
            }
            
        }
    }
}
