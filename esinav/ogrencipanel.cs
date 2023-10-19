using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Security.Authentication.ExtendedProtection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace esinav
{
    public partial class ogrencipanel : Form
    {
        public ogrencipanel()
        {
            InitializeComponent();
        }
        private NpgsqlConnection connection;
        public string str_no = "0";
        int sinif_id = 0;
        private void Form10_Load(object sender, EventArgs e)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
                NpgsqlConnection connection = new NpgsqlConnection(connectionString);
                int ogrno = Convert.ToInt32(str_no);

                connection.Open();
                NpgsqlCommand ogr_bilgi = new NpgsqlCommand("SELECT * FROM student WHERE ogrenci_no = @ogr_no",connection);
                ogr_bilgi.Parameters.AddWithValue("ogr_no", ogrno);
                NpgsqlDataReader reader = ogr_bilgi.ExecuteReader();
                while (reader.Read())
                {
                    label4.Text = reader["ogrenci_no"].ToString();
                    label5.Text = reader["adi"].ToString();
                    label6.Text = reader["soyadi"].ToString();
                    sinif_id = Convert.ToInt32(reader["sinif_id"].ToString());
                    label13.Text = reader["tc"].ToString();
                    pictureBox1.ImageLocation = reader["ogr_resim"].ToString();
                }
            
                connection.Close();
                connection.Open();
                NpgsqlCommand sinif_sorgu = new NpgsqlCommand("SELECT * FROM class WHERE class_id = @cl_id", connection);
                sinif_sorgu.Parameters.AddWithValue("@cl_id", sinif_id);
                NpgsqlDataReader rdr = sinif_sorgu.ExecuteReader();
                while (rdr.Read())
                {
                    label8.Text = rdr["class_num"].ToString() + " " + rdr["branch"].ToString();
                }
                connection.Close();
                connection.Open();
                string sinavlar = "SELECT * FROM exams WHERE lesson_id IN (SELECT lesson_id FROM student_lesson WHERE student_id="+ogrno+" ) ";
                NpgsqlDataAdapter datapter = new NpgsqlDataAdapter(sinavlar, connection);
                DataSet ds = new DataSet();
                datapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            
                connection.Close();

                    dataGridView1.Columns[0].HeaderText = "Sınav Numarası";
                    dataGridView1.Columns[1].HeaderText = "Sınav Adı";
                    dataGridView1.Columns[2].HeaderText = "Ders Numarası";
                    dataGridView1.Columns[3].HeaderText = "Sınav Tarihi";
                    dataGridView1.Columns[4].HeaderText = "Başlama Saati";
                    dataGridView1.Columns[5].HeaderText = "Bitiş Saati";
            
            
                std_id = ogrno;
            
            
            }
            catch (Exception hata)
            {
                MessageBox.Show("Hata : ", hata.Message);
            }
            
        }
        int examid = 0;
        int std_id = 0;
        int lesson_id = 0;
        int drm = 0;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
                NpgsqlConnection connection = new NpgsqlConnection(connectionString);

                MessageBox.Show(dataGridView1.SelectedCells[0].Value.ToString());
                connection.Open();
                NpgsqlCommand sinavaktifmi = new NpgsqlCommand("SELECT count(*) FROM exam_student WHERE ogrenci_no = @ogr_no AND exam_id = @ex_id AND cozme_drm = @drm", connection);
                sinavaktifmi.Parameters.AddWithValue("@ogr_no", Convert.ToInt32(label4.Text));
                sinavaktifmi.Parameters.AddWithValue("@ex_id", Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString()));
                sinavaktifmi.Parameters.AddWithValue("@drm", true);
                NpgsqlDataReader npgsqlDataReader = sinavaktifmi.ExecuteReader();
                while (npgsqlDataReader.Read())
                {
                    drm = Convert.ToInt32(npgsqlDataReader["count"].ToString());
                }

                connection.Close();
                if (drm == 0)
                {
                    DateTime sınavTarihi = (DateTime)dataGridView1.Rows[e.RowIndex].Cells[3].Value;
                    string baslamaSaati = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                    string bitisSaati = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();

                    // Bugünün tarihini ve saatini alın
                    DateTime bugununTarihi = DateTime.Today;
                    DateTime suankiSaat = DateTime.Now;

                    // Sınavın tarihini bugünün tarihine eşitleyin (saat kısmını yok sayarak)
                    sınavTarihi = sınavTarihi.Date;

                    // Sınavın tarihini ve saatini kontrol edin
                    if (sınavTarihi == bugununTarihi && suankiSaat >= Convert.ToDateTime(baslamaSaati) && suankiSaat <= Convert.ToDateTime(bitisSaati))
                    {
                        // Sınav çözme formunu açın
                        try
                        {
                            if (e.RowIndex >= 0) // Satırın tıklanıp tıklanmadığını kontrol eder
                            {
                                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                                // Verileri alıp MessageBox'a yazdırma
                                examid = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
                                lesson_id = Convert.ToInt32(dataGridView1.SelectedCells[2].Value.ToString());

                                MessageBox.Show(examid.ToString());
                            }

                            sinavcozme sinavcozme = new sinavcozme();
                            sinavcozme.exam_id = examid;
                            sinavcozme.ogrenci_no = std_id;
                            sinavcozme.ders_id = lesson_id;
                            sinavcozme.Show();
                        }
                        catch (Exception hata)
                        {
                            MessageBox.Show(hata.Message);
                        }
                    }
                    else if (sınavTarihi != bugununTarihi)
                    {
                        MessageBox.Show("Sınav Çözme Tarihiniz : " + sınavTarihi.ToString() + "Suan Sınavı Çözemezsiniz !");
                    }
                    else if (suankiSaat < Convert.ToDateTime(baslamaSaati))
                    {
                        MessageBox.Show("Sınav Saatiniz Gelmedi !");
                    }
                    else if (suankiSaat > Convert.ToDateTime(bitisSaati))
                    {
                        MessageBox.Show("Sınav Saatini Kaçırdınız Sınavı Çözemezsiniz. Öğretmeniniz ile iletişime geçin !!");
                    }
                }
                else
                {
                    MessageBox.Show("Sınavınız Zaten Çözülmüş Durumdadır ....!");
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show("Hata : ", hata.Message);
            }
            
        }

        private void sınavToolStripMenuItem_Click(object sender, EventArgs e)
        {
            not_görüntlüleme not_Görüntlüleme = new not_görüntlüleme();
            not_Görüntlüleme.ogr_no = Convert.ToInt32(label4.Text.Trim());
            not_Görüntlüleme.Show();
        }

        private void geriBildirimToolStripMenuItem_Click(object sender, EventArgs e)
        {
            geribildirimolustur geriBildirimolustur = new geribildirimolustur();
            geriBildirimolustur.ogr_no = Convert.ToInt32(label4.Text);
            geriBildirimolustur.Show();
        }
    }
}
