using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace esinav
{
    public partial class dersekleme : Form
    {
        public dersekleme()
        {
            InitializeComponent();
        }
        public NpgsqlConnection connection;
        int lesson_id = 0;
        List<int> student_id_list = new List<int>();
        
        int les_id = 0;
        private void button2_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            try
            {
                connection.Open();
                NpgsqlCommand ekle = new NpgsqlCommand("INSERT INTO lessons (lesson_name, lesson_code, lesson_coefficient, teacher_id) values (@ls_name, @ls_code, @ls_cf, @tc_id)", connection);
                ekle.Parameters.AddWithValue("@ls_name", t_dersadi.Text.ToString());
                ekle.Parameters.AddWithValue("@ls_code", textBox1.Text.ToString());
                ekle.Parameters.AddWithValue("@ls_cf", Convert.ToInt32(textBox2.Text.ToString()));
                ekle.Parameters.AddWithValue("@tc_id", comboBox1.SelectedValue);
                ekle.ExecuteNonQuery();
                connection.Close();

                connection.Open();
                NpgsqlCommand qry = new NpgsqlCommand("SELECT * FROM lessons WHERE lesson_code = @derskod ", connection);
                qry.Parameters.AddWithValue("@derskod", textBox1.Text.Trim());
                NpgsqlDataReader reader = qry.ExecuteReader();
                while (reader.Read())
                {
                    lesson_id = Convert.ToInt32(reader["lesson_id"].ToString());
                }
                connection.Close();


                connection.Open();
                NpgsqlCommand ekleme = new NpgsqlCommand("INSERT INTO class_lesson (class_id, lesson_id, teacher_id) values (@class_id, @lesson_id, @teacher_id)", connection);
                ekleme.Parameters.AddWithValue("@class_id", comboBox2.SelectedValue);
                ekleme.Parameters.AddWithValue("@lesson_id", lesson_id);
                ekleme.Parameters.AddWithValue("@teacher_id", comboBox1.SelectedValue);
                ekleme.ExecuteNonQuery();
                connection.Close();




                connection.Open();
                NpgsqlCommand ogrekle = new NpgsqlCommand("INSERT INTO teacher_lesson (teacher_id, lesson_id) values (@ogr_id,@lesson_id)", connection);
                ogrekle.Parameters.AddWithValue("@ogr_id", comboBox1.SelectedValue);
                ogrekle.Parameters.AddWithValue("@lesson_id", lesson_id);
                ogrekle.ExecuteNonQuery();
                connection.Close();


                connection.Open();
                NpgsqlCommand kosul_deger = new NpgsqlCommand("SELECT * FROM student WHERE sinif_id = @sinif_id", connection);
                kosul_deger.Parameters.AddWithValue("@sinif_id", comboBox2.SelectedValue);
                NpgsqlDataReader reader3 = kosul_deger.ExecuteReader();
                while (reader3.Read())
                {
                    student_id_list.Add(Convert.ToInt32(reader3["ogrenci_no"].ToString()));
                }
                connection.Close();

                foreach (int i in student_id_list)
                {
                    MessageBox.Show(i.ToString());
                }
                foreach (int i in student_id_list)
                {
                    connection.Open();
                    NpgsqlCommand qry1 = new NpgsqlCommand("SELECT * FROM student_lesson WHERE lesson_id=@lesson_id AND student_id = @student_id", connection);
                    qry1.Parameters.AddWithValue("@lesson_id", les_id);
                    qry1.Parameters.AddWithValue("@student_id", i);
                    DataTable dt = new DataTable();
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(qry1);
                    da.Fill(dt);

                    if (dt.Rows.Count == 0)
                    {
                        connection.Close();
                        connection.Open();
                        NpgsqlCommand l_s_ekle = new NpgsqlCommand("INSERT INTO student_lesson (student_id, lesson_id) values (@st_id, @ls_id)", connection);
                        l_s_ekle.Parameters.AddWithValue("st_id", i);
                        l_s_ekle.Parameters.AddWithValue("ls_id", les_id);
                        l_s_ekle.ExecuteNonQuery();
                        connection.Close();

                    }
                    else
                    {

                        connection.Close();
                    }
                }

                MessageBox.Show("Ders Eklendi");
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }

}

        private void Form6_Load(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);


            try
            {
                connection.Open();
                NpgsqlCommand teachs = new NpgsqlCommand("SELECT * FROM teacher",connection);
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(teachs);
                DataTable dataTable = new DataTable();
                da.Fill(dataTable);
                comboBox1.ValueMember = "ogretmen_id";
                comboBox1.DisplayMember = "namesurname";
                dataTable.Columns.Add("namesurname", typeof(string), "t_name + ' ' + t_surname");
                comboBox1.DataSource = dataTable;
                connection.Close();



                connection.Open();
                NpgsqlCommand sinif = new NpgsqlCommand("SELECT * FROM class", connection);
                NpgsqlDataAdapter da2 = new NpgsqlDataAdapter(sinif);
                DataTable dataTable2 = new DataTable();
                da2.Fill(dataTable2);
                comboBox2.ValueMember = "class_id";
                comboBox2.DisplayMember = "class";
                dataTable2.Columns.Add("class", typeof(string), "class_num + ' ' + branch");
                comboBox2.DataSource = dataTable2;

                connection.Close();


            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
            
        }
    }
}
