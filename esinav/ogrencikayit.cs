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
    public partial class ogrencikayit : Form
    {
        public ogrencikayit()
        {
            InitializeComponent();
        }

        private NpgsqlConnection connection;
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Öğrencinin Fotoğrafını Seçiniz.";
            ofd.ShowDialog();
            string resimyolu = ofd.FileName;
            pictureBox1.ImageLocation = resimyolu;
        }
        int class_id = 0;
        int ogr_no = 0;
        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
                NpgsqlConnection connection = new NpgsqlConnection(connectionString);


                if (pictureBox1.ImageLocation != null && t_tc.Text.Trim() != "" && t_adi.Text.Trim() != "" && t_soyadi.Text.Trim() != "" && t_veli_tel.Text.Trim() != "" && t_adres.Text.Trim() != "" && t_veli_ad.Text.Trim() != "" && t_veli_tc.Text.Trim() != "" && t_veli_email.Text.Trim() != "")
                {

                    connection.Open();
                    NpgsqlCommand veli_kayit = new NpgsqlCommand("INSERT INTO parent (adi,tc,tel_no,email) VALUES (@adi,@tc,@tel_no,@email)", connection);
                    veli_kayit.Parameters.AddWithValue("adi", t_veli_ad.Text.Trim());
                    veli_kayit.Parameters.AddWithValue("tc", t_veli_tc.Text.Trim());
                    veli_kayit.Parameters.AddWithValue("tel_no", t_veli_tel.Text.Trim());
                    veli_kayit.Parameters.AddWithValue("email", t_veli_email.Text.ToLower().Trim());
                    veli_kayit.ExecuteNonQuery();
                    connection.Close();

                    connection.Open();
                    string veli_id = ("SELECT * FROM parent WHERE tc='" + t_veli_tc.Text.Trim() + "'");
                    NpgsqlCommand veli_id_sorgu = new NpgsqlCommand(veli_id, connection);
                    NpgsqlDataReader read = veli_id_sorgu.ExecuteReader();

                    while (read.Read())
                    {
                        label14.Text = read["veli_id"].ToString();
                    }
                    int v_id = Convert.ToInt32(label14.Text);
                    connection.Close();

                    connection.Open();
                    NpgsqlCommand ogrencikayit = new NpgsqlCommand("INSERT INTO student (adi,soyadi,tc,sinif_id,adres,veli_id,ogr_parola,cinsiyet,ogr_resim) VALUES (@adi,@soyadi,@tc,@sinif_id,@adres,@veli_id,@ogr_parola,@cinsiyet,@ogr_resim)");
                    ogrencikayit.Connection = connection;
                    ogrencikayit.Parameters.AddWithValue("adi", t_adi.Text.Trim());
                    ogrencikayit.Parameters.AddWithValue("soyadi", t_soyadi.Text.Trim());
                    ogrencikayit.Parameters.AddWithValue("tc", t_tc.Text.Trim());
                    ogrencikayit.Parameters.AddWithValue("adres", t_adres.Text.Trim());
                    ogrencikayit.Parameters.AddWithValue("veli_id", v_id);
                    ogrencikayit.Parameters.AddWithValue("ogr_parola", t_tc.Text.Trim());
                    ogrencikayit.Parameters.AddWithValue("cinsiyet", c_cinsiyet.Text.Trim());
                    ogrencikayit.Parameters.AddWithValue("ogr_resim", pictureBox1.ImageLocation.ToString());


                    switch (c_cinsiyet.TabIndex)
                    {
                        case 0:
                            c_cinsiyet.Text = "ERKEK";
                            break;
                        case 1:
                            c_cinsiyet.Text = "KIZ";
                            break;
                    }


                    ogrencikayit.Parameters.AddWithValue("sinif_id", c_sinif.SelectedValue);
                    ogrencikayit.ExecuteNonQuery();
                    connection.Close();


                    connection.Open();
                    NpgsqlCommand okulno = new NpgsqlCommand("SELECT * FROM student WHERE tc = @tc", connection);
                    okulno.Parameters.AddWithValue("@tc", t_tc.Text.Trim());
                    NpgsqlDataReader ogrno = okulno.ExecuteReader();
                    while (ogrno.Read())
                    {
                        t_okulno.Text = ogrno["ogrenci_no"].ToString();
                        class_id = Convert.ToInt32(ogrno["sinif_id"].ToString());
                        ogr_no = Convert.ToInt32(ogrno["ogrenci_no"].ToString());
                    }
                    connection.Close();



                    MessageBox.Show("ÖĞRENCİ KAYDEDİLDİ.... SİSTEME GİRİŞ KULLANICI ADI : OKUL NO --------- PAROLA : TC");
                }
                else
                {
                    MessageBox.Show("BİLGİLERİN HEPSİNİ GİRDİĞİNİZDEN EMİN OLUNUZ (FOTOĞRAF YÜKLEMEYİ UNUTMAYINIZ)");
                }

                


                List<int> dersler_id = new List<int>();
                connection.Open();
                NpgsqlCommand qry = new NpgsqlCommand("SELECT * FROM class_lesson WHERE class_id = @class_id", connection);
                qry.Parameters.AddWithValue("@class_id", class_id);
                NpgsqlDataReader reader = qry.ExecuteReader();
                while (reader.Read())
                {
                    int lesson_ids = Convert.ToInt32(reader["lesson_id"].ToString());
                    dersler_id.Add(lesson_ids);
                }

                connection.Close();



                foreach (int lesson_id in dersler_id)
                {
                    connection.Open();

                    NpgsqlCommand ekle = new NpgsqlCommand("INSERT INTO student_lesson (student_id, lesson_id) values (@student_id, @lesson_id)", connection);
                    ekle.Parameters.AddWithValue("@student_id", ogr_no);
                    ekle.Parameters.AddWithValue("@lesson_id", lesson_id);
                    ekle.ExecuteNonQuery();
                    connection.Close();
                    
                }

                MessageBox.Show("Öğrenci Kaydedildi !");
            }
            catch (Exception hata)
            {
                MessageBox.Show($"Error: {hata.Message}");
                connection.Close();
            }
            

            foreach (Control control in panel1.Controls)
            {
                if (control is TextBox)
                {
                    // TextBox kontrolünü temizle
                    TextBox textBox = (TextBox)control;
                    textBox.Text = "";
                }
                else if (control is PictureBox)
                {
                    // PictureBox kontrolünü temizle
                    PictureBox pictureBox = (PictureBox)control;
                    pictureBox.Image = null;
                }
                else if (control is ComboBox)
                {
                    // ComboBox kontrolünü temizle
                    ComboBox comboBox = (ComboBox)control;
                    comboBox.SelectedIndex = -1;
                }
            }

        }
        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }
        private void AttachUpperCaseEventHandlers(Control control)
        {
            try
            {
                foreach (Control Control in control.Controls)
                {
                    if (Control is TextBox)
                    {
                        Control.KeyPress += TextBox_KeyPress;
                    }
                    else if (Control.HasChildren)
                    {
                        AttachUpperCaseEventHandlers(Control);
                    }
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show("Hata : ", hata.Message);
            }
            
        }
        private void Form4_Load(object sender, EventArgs e)
        {
            AttachUpperCaseEventHandlers(this);

            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
                NpgsqlConnection connection = new NpgsqlConnection(connectionString);


                connection.Open();
                string sinif1 = "SELECT * FROM class ";
                NpgsqlCommand sinifsorgu = new NpgsqlCommand(sinif1, connection);
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(sinifsorgu);
                DataTable dataTable = new DataTable();
                da.Fill(dataTable);
                c_sinif.ValueMember = "class_id";
                c_sinif.DisplayMember = "class";
                dataTable.Columns.Add("class", typeof(string), "class_num + ' ' + branch");
                c_sinif.DataSource = dataTable;
                connection.Close();
            }
            catch(Exception hata)
            {
                MessageBox.Show(hata.Message );
            }


            
        }

        
    }
}
