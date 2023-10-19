using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ComboBox = System.Windows.Forms.ComboBox;

namespace esinav
{
    public partial class ogrencibilgi : Form
    {
        public ogrencibilgi()
        {
            InitializeComponent();
        }
        private NpgsqlConnection connection;
        void refresh()
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
                NpgsqlConnection connection = new NpgsqlConnection(connectionString);


                connection.Open();
                DataTable veri = new DataTable();
                NpgsqlDataAdapter da = new NpgsqlDataAdapter("SELECT * FROM student", connection);
                da.Fill(veri);
                dataGridView1.DataSource = veri;
                connection.Close();
            }
            catch (Exception hata)
            {
                MessageBox.Show("Hata : ", hata.Message);
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
                    if (Control is System.Windows.Forms.TextBox)
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
        private void Form7_Load(object sender, EventArgs e)
        {
            try
            {
                AttachUpperCaseEventHandlers(this);

                string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
                NpgsqlConnection connection = new NpgsqlConnection(connectionString);

            

                connection.Open();
                string sorgu = "SELECT * FROM student";
                NpgsqlDataAdapter datapter = new NpgsqlDataAdapter(sorgu, connection);
                DataSet ds = new DataSet();
                datapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                connection.Close();
                dataGridView1.Columns[0].HeaderText = "ÖĞRENCİ NO";
                dataGridView1.Columns[1].HeaderText = "AD";
                dataGridView1.Columns[2].HeaderText = "SOYAD";
                dataGridView1.Columns[3].HeaderText = "TC";
                dataGridView1.Columns[4].HeaderText = "SINIF NUMARASI";
                dataGridView1.Columns[5].HeaderText = "CİNSİYET";
                dataGridView1.Columns[6].HeaderText = "ADRES";
                dataGridView1.Columns[7].HeaderText = "VELİ İD";
                dataGridView1.Columns[8].HeaderText = "ÖĞRENCİ PAROLA";
                dataGridView1.Columns[9].HeaderText = "ÖĞRENCİ RESİM YOLU";
            }
            catch (Exception hata)
            {
                MessageBox.Show("Hata : ", hata.Message);
            }
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
                NpgsqlConnection connection = new NpgsqlConnection(connectionString);

                connection.Open();
                NpgsqlCommand guncelle = new NpgsqlCommand("UPDATE student SET adi=@ad, soyadi=@soyad, tc=@tc , cinsiyet=@cnsyet,adres=@adrs,ogr_resim=@img WHERE ogrenci_no=@ogr_no",connection);
                switch (c_cinsiyet.TabIndex)
                {
                    case 0:
                        c_cinsiyet.Text = "ERKEK";
                        break;
                    case 1:
                        c_cinsiyet.Text = "KIZ";
                        break;
                }
                guncelle.Parameters.AddWithValue("@ad", t_adi.Text.Trim());
                guncelle.Parameters.AddWithValue("@soyad", t_soyadi.Text.Trim());
                guncelle.Parameters.AddWithValue("@tc", Convert.ToInt64(t_tc.Text.Trim()));
                guncelle.Parameters.AddWithValue("@cnsyet", c_cinsiyet.Text.Trim());
                guncelle.Parameters.AddWithValue("@adrs", t_adres.Text.Trim());
                guncelle.Parameters.AddWithValue("@img", pictureBox1.ImageLocation.ToString());
                guncelle.Parameters.AddWithValue("@ogr_no", Convert.ToInt32(t_okulno.Text.Trim()));


            
            
                guncelle.ExecuteNonQuery();
                connection.Close();
                refresh();
            }
            catch (Exception hata)
            {
                MessageBox.Show("Hata : ", hata.Message);
            }
            
        }
        
        
        int sinif_id = 0;
        

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Öğrencinin Fotoğrafını Seçiniz.";
            ofd.ShowDialog();
            string resimyolu = ofd.FileName;
            pictureBox1.ImageLocation = resimyolu;
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
                NpgsqlConnection connection = new NpgsqlConnection(connectionString);

                int secilisatır = dataGridView1.SelectedCells[0].RowIndex;
                t_okulno.Text = dataGridView1.Rows[secilisatır].Cells[0].Value.ToString();//okul no
                t_adi.Text = dataGridView1.Rows[secilisatır].Cells[1].Value.ToString();//ad
                t_soyadi.Text = dataGridView1.Rows[secilisatır].Cells[2].Value.ToString();//soyad
                t_tc.Text = dataGridView1.Rows[secilisatır].Cells[3].Value.ToString();//tc

                c_cinsiyet.Text = dataGridView1.Rows[secilisatır].Cells[5].Value.ToString();//cisiyet
                t_adres.Text = dataGridView1.Rows[secilisatır].Cells[6].Value.ToString();//adres
                int veli_id = Convert.ToInt32(dataGridView1.Rows[secilisatır].Cells[7].Value.ToString());//veli_id
                connection.Open();
                NpgsqlCommand velisorgu = new NpgsqlCommand("SELECT * FROM parent WHERE veli_id='" + veli_id + "'", connection);
                /*NpgsqlParameter v_id = new NpgsqlParameter("@v_id", Convert.ToInt32(veli_id).ToString());*/
                NpgsqlDataReader reader = velisorgu.ExecuteReader();
                while (reader.Read())
                {
                    t_veli_ad.Text = reader["adi"].ToString();
                    t_veli_email.Text = reader["email"].ToString();
                    t_veli_tc.Text = reader["tc"].ToString();
                    t_veli_tel.Text = reader["tel_no"].ToString();
                }
                connection.Close();

                pictureBox1.ImageLocation = dataGridView1.Rows[secilisatır].Cells[9].Value.ToString();//resim
                sinif_id = Convert.ToInt32(dataGridView1.Rows[secilisatır].Cells[4].Value.ToString());//sınf

           

                connection.Close();
            }
            catch (Exception hata)
            {
                MessageBox.Show("Hata : ", hata.Message);
            }
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
                NpgsqlConnection connection = new NpgsqlConnection(connectionString);
                connection.Open();

                string sorgu = "SELECT * FROM student WHERE adi LIKE '%" + textBox1.Text.Trim() + "%'";
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, connection);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                connection.Close();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
                NpgsqlConnection connection = new NpgsqlConnection(connectionString);
                connection.Open();

                string sorgu = "SELECT * FROM student WHERE soyadi LIKE '%" + textBox4.Text.Trim() + "%'";
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, connection);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                connection.Close();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
                NpgsqlConnection connection = new NpgsqlConnection(connectionString);
                connection.Open();

                string sorgu = "SELECT * FROM student WHERE tc LIKE '%" + textBox2.Text.Trim() + "%'";
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, connection);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                connection.Close();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show(t_okulno.Text.Trim()+ " " + t_adi.Text.Trim() + " " + t_soyadi.Text.Trim() +" Bu Öğrenciyi Silmek istiyor musunuz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
                    NpgsqlConnection connection = new NpgsqlConnection(connectionString);
                    connection.Open();
                    NpgsqlCommand ogr_sil = new NpgsqlCommand("DELETE FROM student_lesson WHERE student_id = @ogr_no", connection);
                    ogr_sil.Parameters.AddWithValue("@ogr_no", Convert.ToInt32(t_okulno.Text.Trim())); 
                    ogr_sil.ExecuteNonQuery();
                    
                    NpgsqlCommand ogr_sil2 = new NpgsqlCommand("DELETE FROM exam_student WHERE ogrenci_no = @ogr_no", connection);
                    ogr_sil2.Parameters.AddWithValue("@ogr_no", Convert.ToInt32(t_okulno.Text.Trim()));
                    ogr_sil2.ExecuteNonQuery();

                    NpgsqlCommand ogr_sil3 = new NpgsqlCommand("DELETE FROM reply WHERE ogrenci_no = @ogr_no", connection);
                    ogr_sil3.Parameters.AddWithValue("@ogr_no", Convert.ToInt32(t_okulno.Text.Trim()));
                    ogr_sil3.ExecuteNonQuery();

                    NpgsqlCommand ogr_sil4 = new NpgsqlCommand("DELETE FROM feedbacks WHERE ogrenci_no = @ogr_no", connection);
                    ogr_sil4.Parameters.AddWithValue("@ogr_no", Convert.ToInt32(t_okulno.Text.Trim()));
                    ogr_sil4.ExecuteNonQuery();

                    NpgsqlCommand ogr_sil5 = new NpgsqlCommand("DELETE FROM student WHERE ogrenci_no = @ogr_no", connection);
                    ogr_sil5.Parameters.AddWithValue("@ogr_no", Convert.ToInt32(t_okulno.Text.Trim()));
                    ogr_sil5.ExecuteNonQuery();


                    connection.Close();
                    MessageBox.Show("Öğrenci Silindi ....!");

                    refresh();

                    foreach (Control control in panel1.Controls)
                    {
                        if (control is System.Windows.Forms.TextBox)
                        {
                            // TextBox kontrolünü temizle
                            System.Windows.Forms.TextBox textBox = (System.Windows.Forms.TextBox)control;
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
                else if (result == DialogResult.No)
                {
                    // Hayır seçeneği seçildiğinde yapılacak işlemler
                    // ...
                }
                
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
        }

        
    }
}
