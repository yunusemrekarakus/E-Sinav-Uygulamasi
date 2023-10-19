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
    public partial class sinavolustur : Form
    {
        public string AlinanVeri { get; set; }
        public sinavolustur()
        {
            InitializeComponent();
        }
        int sinav_id = 0;
        List<int> ogr_id_list = new List<int>();
        private NpgsqlConnection connection;
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
                NpgsqlConnection connection = new NpgsqlConnection(connectionString);
                /////////////////////////////
                DateTime selectedDate = dateTimePicker1.Value.Date;
                string formattedDate = selectedDate.ToString("dd/MM/yyyy");

                TimeSpan selectedTime = timePicker.Value.TimeOfDay;
                string formattedTime = selectedTime.ToString("hh\\:mm");

                TimeSpan selectedTime2 = timePicker2.Value.TimeOfDay;
                string formattedTime2 = selectedTime2.ToString("hh\\:mm");

            
                connection.Open();

                string sinav_isim = textBox7.Text.Trim();
                NpgsqlCommand sinavolustur = new NpgsqlCommand("INSERT INTO exams (exam_names, lesson_id, exam_date, exam_start_time, exam_finish_time, exam_duration) values (@name, @lesson_id, @date, @starttime, @finishtime, @ex_duration)", connection);
                sinavolustur.Parameters.AddWithValue("@name", sinav_isim.Trim());
                sinavolustur.Parameters.AddWithValue("@lesson_id", comboBox1.SelectedValue);
                sinavolustur.Parameters.AddWithValue("@date", NpgsqlDbType.Date).Value = DateTime.Now.Date;
                sinavolustur.Parameters.AddWithValue("@starttime", NpgsqlDbType.TimeTZ).Value = formattedTime;
                sinavolustur.Parameters.AddWithValue("@finishtime", NpgsqlDbType.TimeTZ).Value = formattedTime2;
                sinavolustur.Parameters.AddWithValue("@ex_duration", numericUpDown1.Value);
                sinavolustur.ExecuteNonQuery();
                /////////////////////////////
                connection.Close();

                connection.Open();
                NpgsqlCommand exam_id = new NpgsqlCommand("SELECT * FROM exams WHERE exam_names = @name AND lesson_id = @l_id AND exam_date = @ex_date", connection);
                exam_id.Parameters.AddWithValue("@name", sinav_isim.Trim());
                exam_id.Parameters.AddWithValue("@l_id", comboBox1.SelectedValue);
                exam_id.Parameters.AddWithValue("@ex_date", NpgsqlDbType.Date).Value = DateTime.Now.Date;
                NpgsqlDataReader reader = exam_id.ExecuteReader();
                while (reader.Read())
                {
                    sinav_id = Convert.ToInt32(reader["exam_id"].ToString());
                }
                connection.Close();

                connection.Open();
                NpgsqlCommand ogr_id = new NpgsqlCommand("SELECT * FROM student WHERE sinif_id = (SELECT class_id FROM class_lesson WHERE lesson_id = @l_i )", connection);
                ogr_id.Parameters.AddWithValue("@l_i", comboBox1.SelectedValue);
                NpgsqlDataReader reader3 = ogr_id.ExecuteReader();
                while (reader3.Read())
                {
                    int ogr_no = Convert.ToInt32(reader3["ogrenci_no"].ToString());
                    ogr_id_list.Add(ogr_no);
                
                }
                connection.Close();
                foreach(int i  in ogr_id_list)
                {
                    try
                    {
                        connection.Open();
                        NpgsqlCommand exam_student = new NpgsqlCommand("INSERT INTO exam_student (exam_id, ogrenci_no, cozme_drm) values (@ex_id, @ls_id, @czm_drm)", connection);
                        exam_student.Parameters.AddWithValue("@ex_id", sinav_id);
                        exam_student.Parameters.AddWithValue("@ls_id", i);
                        exam_student.Parameters.AddWithValue("@czm_drm", false);
                        exam_student.ExecuteNonQuery();

                        connection.Close();
                        MessageBox.Show("sınav durum eklendi");
                    }
                    catch (Exception hata)
                    {
                        MessageBox.Show(hata.Message);
                    }
                }
            
                sinavhazirlamapanel form11 = new sinavhazirlamapanel();
                form11.sinavisim = sinav_isim;
                form11.Show();
            }
            catch (Exception hata)
            {
                MessageBox.Show("Hata : ", hata.Message);
            }
            

        }

        private DateTimePicker timePicker = new DateTimePicker();
        private DateTimePicker timePicker2 = new DateTimePicker();
        
        
        private void sinavolustur_Load_1(object sender, EventArgs e)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
                NpgsqlConnection connection = new NpgsqlConnection(connectionString);


                int teach_id = Convert.ToInt32(AlinanVeri);
            
                MessageBox.Show(teach_id.ToString());
                connection.Open();
                NpgsqlCommand ders = new NpgsqlCommand("SELECT * FROM lessons WHERE lesson_id IN(SELECT lesson_id FROM teacher_lesson WHERE teacher_id =@teacher_id)", connection);
                ders.Parameters.AddWithValue("@teacher_id", teach_id);
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(ders);
                DataTable dataTable = new DataTable();
                da.Fill(dataTable);
                comboBox1.ValueMember = "lesson_id";
                comboBox1.DisplayMember = "lesson_name";
                comboBox1.DataSource = dataTable;
                connection.Close();


                timePicker.Format = DateTimePickerFormat.Custom;
                timePicker.CustomFormat = "HH:mm";
                timePicker.ShowUpDown = true;
                timePicker.Location = new Point(246, 102);
                timePicker.Value = DateTime.Now.Date; // Varsayılan olarak bugünün tarihini ayarlar

                // Form üzerine timePicker'ı ekleyin veya bir panel gibi bir nesneye ekleyin
                panel5.Controls.Add(timePicker);

                // Kullanıcıdan saat bilgisini almak için
                TimeSpan selectedTime = timePicker.Value.TimeOfDay;



                timePicker2.Format = DateTimePickerFormat.Custom;
                timePicker2.CustomFormat = "HH:mm";
                timePicker2.ShowUpDown = true;
                timePicker2.Location = new Point(246, 138);
                timePicker2.Value = DateTime.Now.Date; // Varsayılan olarak bugünün tarihini ayarlar

                // Form üzerine timePicker'ı ekleyin veya bir panel gibi bir nesneye ekleyin
                panel5.Controls.Add(timePicker2);

                // Kullanıcıdan saat bilgisini almak için
                TimeSpan selectedTime2 = timePicker2.Value.TimeOfDay;
            }
            catch (Exception hata)
            {
                MessageBox.Show("Hata : ", hata.Message);
            }
            
        }
    }
}
