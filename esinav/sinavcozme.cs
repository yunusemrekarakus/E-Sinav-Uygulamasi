using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace esinav
{
    public partial class sinavcozme : Form
    {
        private Timer timer;
        private int dakika, saniye;
        public sinavcozme()
        {
            InitializeComponent();
            // Timer oluşturma ve ayarları
            
        }
        public void timerfonk()
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
                NpgsqlConnection connection = new NpgsqlConnection(connectionString);

                timer = new Timer();
                timer.Interval = 1000; // 1 saniyede bir tetiklenecek
                timer.Tick += Timer_Tick;
                connection.Open();
                NpgsqlCommand sure = new NpgsqlCommand("SELECT * FROM exams WHERE exam_id = @ex_id", connection);
                sure.Parameters.AddWithValue("@ex_id", exam_id);
                NpgsqlDataReader datareader = sure.ExecuteReader();
                while (datareader.Read())
                {
                    dakika = Convert.ToInt32(datareader["exam_duration"].ToString());
                }
                connection.Close();

                saniye = 0;
            }
            catch (Exception hata)
            {
                MessageBox.Show("Hata : ", hata.Message);
            }

            
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            try
            {
                if (dakika == 0 && saniye == 0)
                {
                    timer.Stop();
                    MessageBox.Show("Süre doldu! Sayfa Kaydedilip Kapatılıyor !!");
                    this.Close();
                    return;
                }

                if (saniye == 0)
                {
                    dakika--;
                    saniye = 59;
                }
                else
                {
                    saniye--;
                }

                labelDakika1.Text = (dakika / 10).ToString();
                labelDakika2.Text = (dakika % 10).ToString();
                labelSaniye1.Text = (saniye / 10).ToString();
                labelSaniye2.Text = (saniye % 10).ToString();
            }
            catch (Exception hata)
            {
                MessageBox.Show("Hata : ", hata.Message);
            }
            
        }
        
        float soru_sayisi = 0;
        private NpgsqlConnection connection;
        private void sınavçözme_Load(object sender, EventArgs e)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
                NpgsqlConnection connection = new NpgsqlConnection(connectionString);

                timerfonk();
                timer.Start();

            
                label4.Text = 1.ToString();
                connection.Open();
                NpgsqlCommand ss1 = new NpgsqlCommand("SELECT count(*) FROM questions WHERE exam_id=@exam_id", connection);
                ss1.Parameters.AddWithValue("@exam_id", exam_id);
                NpgsqlDataReader reader = ss1.ExecuteReader();
                while (reader.Read())
                {
                    soru_sayisi = Convert.ToInt32(reader[0].ToString());
                }

                connection.Close();
            
                this.WindowState = FormWindowState.Maximized;
                this.FormBorderStyle = FormBorderStyle.None;
                /*this.TopMost = true;*/
            
                for (int i = 1; i <= soru_sayisi; i++)
                {
                    Button button = new Button();
                    button.Text = "Soru " + (i);
                    button.Top = (button.Height + 10) * i;
                    button.Left = 10;
                    button.Size = new Size(275, 30);
                    button.Name = "button_" + i;
                    button.Click += DynamicButton_Click;
                    panel1.Controls.Add(button);
                    AdjustPanelScroll();
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show("Hata : ", hata.Message);
            }
            
            
        }
        public int exam_id = 0;
        private void AdjustPanelScroll()
        {
            try
            {
                panel1.AutoScroll = false; // Otomatik kaydırmayı kapat
                int buttonHeight = panel1.Controls[0].Height; // Buton yüksekliği
                int panelHeight = panel1.Height; // Panel yüksekliği

                if (panel1.Controls.Count * (buttonHeight + 5) > panelHeight)
                {
                    panel1.AutoScroll = true; // Otomatik kaydırmayı aç
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
        }
        List<string> list = new List<string>();
        private void DynamicButton_Click(object sender, EventArgs e)
        {
            try
            {
                Button clickedbutton = (Button)sender;
                string buttonText = clickedbutton.Name;
                list.Clear();

                for (int i = 1; i <= buttonText.Length - 1; i++)
                {
                    char k = (char)buttonText[i];
                    if (k <= 57 && k >= 48)
                    {
                        list.Add(k.ToString());
                    }
                }
                string result = string.Join("", list);
                label4.Text = result;

                if (Convert.ToInt32(label4.Text) == soru_sayisi)
                {
                    button1.Visible = false;
                    button_sonlandır.Visible = true;
                }
                else
                {
                    button1.Visible = true;
                    button_sonlandır.Visible = false;
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show("Hata : ", hata.Message);
            }
            

            
        }
        int ques_id = 0;
        private void sinavcozme_FormClosing(object sender, FormClosingEventArgs e)
        {
            sınavbitir();
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
                NpgsqlConnection connection = new NpgsqlConnection(connectionString);
                connection.Open();
                NpgsqlCommand mailaddress = new NpgsqlCommand("SELECT * FROM parent WHERE veli_id IN (SELECT veli_id FROM student WHERE ogrenci_no = @ogr_no )", connection);
                mailaddress.Parameters.AddWithValue("@ogr_no", ogrenci_no);
                NpgsqlDataReader mailreader = mailaddress.ExecuteReader();
                while (mailreader.Read())
                {
                    veli_mail = mailreader["email"].ToString();
                    veli_ad = mailreader["adi"].ToString();
                }
                connection.Close();

                connection.Open();
                NpgsqlCommand ogr_bilgi = new NpgsqlCommand("SELECT * FROM student WHERE ogrenci_no= " + ogrenci_no + "", connection);
                NpgsqlDataReader bilgi_reader = ogr_bilgi.ExecuteReader();
                while (bilgi_reader.Read())
                {
                    ogr_ad_soyad = bilgi_reader["adi"].ToString() + " " + bilgi_reader["soyadi"].ToString();
                }
                connection.Close();
                connection.Open();
                NpgsqlCommand ders_name = new NpgsqlCommand("SELECT * FROM lessons WHERE lesson_id = " + ders_id + "", connection);
                NpgsqlDataReader ders_reader = ders_name.ExecuteReader();
                while (ders_reader.Read())
                {
                    ders_adi = ders_reader["lesson_name"].ToString();
                }
                connection.Close();

                connection.Open();
                NpgsqlCommand sinav_name = new NpgsqlCommand("SELECT * FROM exams WHERE exam_id = " + exam_id + "", connection);
                NpgsqlDataReader sinav_reader = sinav_name.ExecuteReader();
                while (sinav_reader.Read())
                {
                    sinav_adi = sinav_reader["exam_names"].ToString();
                }
                connection.Close();



                connection.Open();
                
                // Geri kalan kodlar...
                NpgsqlCommand sonuc_dorgu = new NpgsqlCommand("SELECT * FROM exam_student WHERE ogrenci_no = @st_id AND exam_id = @ex_id", connection);
                sonuc_dorgu.Parameters.AddWithValue("@st_id", ogrenci_no);
                sonuc_dorgu.Parameters.AddWithValue("@ex_id", exam_id);
                NpgsqlDataReader sonreader = sonuc_dorgu.ExecuteReader();
                while (sonreader.Read())
                {
                    sinav_sonuc = Convert.ToInt32(sonreader["exam_not"].ToString());
                }
                connection.Close();
                

                string mail_body = "Merhaba Sayın " + veli_ad + ". Velisi Olduğunuz " + ogr_ad_soyad + " " + ders_adi + " Dersi " + sinav_adi + " Sınavından " + sinav_sonuc + " Puan Almıştır. Bilginize ....!";
                eposta.From = new MailAddress("esinavproje@outlook.com");
                eposta.To.Add(veli_mail);
                eposta.Subject = "Sınav Sonuç Bilgilendirme";
                eposta.Body = mail_body;
                SmtpClient smtp = new SmtpClient("outlook.com");
                smtp.Credentials = new System.Net.NetworkCredential("esinavproje@outlook.com", "e_sinavproje55");
                smtp.Host = "smtp.outlook.com";
                smtp.EnableSsl = true;
                smtp.Port = 587;
                smtp.Send(eposta);
            }
            catch (Exception hata)
            {
                MessageBox.Show("Hata: " + hata.Message);
            }



            // Kullanıcının sınavı bitirme niyetinde olduğunu doğrulamak için bir ileti kutusu gösterin
            DialogResult result = MessageBox.Show("Sınavı bitirmek istediğinize emin misiniz?", "Sınavı Bitir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Kullanıcı "Hayır" seçeneğini seçerse, formun kapanmasını engelleyin
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
            
        }
        string ogr_cevap = null;
        string dogru_cevap = null;
        private void label4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
                NpgsqlConnection connection = new NpgsqlConnection(connectionString);


                int soru_number = Convert.ToInt32(label4.Text);
                connection.Open();
                NpgsqlCommand soru_cekme = new NpgsqlCommand("SELECT * FROM questions WHERE exam_id=@exam_id AND question_number=@soru_num", connection);
                soru_cekme.Parameters.AddWithValue("@exam_id", exam_id);
                soru_cekme.Parameters.AddWithValue("@soru_num", soru_number);
                NpgsqlDataReader reader = soru_cekme.ExecuteReader();

                while (reader.Read())
                {
                    textBox6.Text = reader["question"].ToString();
                    textBox1.Text = reader["question_a"].ToString();
                    textBox2.Text = reader["question_b"].ToString();
                    textBox3.Text = reader["question_c"].ToString();
                    textBox4.Text = reader["question_d"].ToString();
                    textBox5.Text = reader["question_e"].ToString();
                    dogru_cevap = reader["true_choice"].ToString();
                    ques_id = Convert.ToInt32(reader["question_id"].ToString());
                    pictureBox1.ImageLocation = reader["question_image"].ToString();
                }
                connection.Close();
            }
            catch (Exception hata)
            {
                MessageBox.Show("Hata : ", hata.Message);
            }
            
        }
        public int ogrenci_no = 0;
        public int ders_id = 0;
        int soru_id = 0;
        public int cevap_id = 0;
        public bool cevap = false;
        public bool soru_durum = false;

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
                NpgsqlConnection connection = new NpgsqlConnection(connectionString);


                if (Convert.ToInt32(label4.Text) == soru_sayisi)
                {
                    button1.Visible = false;
                    button_sonlandır.Visible = true;
                }
                if (checkBox1.Checked == true)
                {
                    ogr_cevap = "A";
                }
                else if (checkBox2.Checked == true)
                {
                    ogr_cevap = "B";
                }
                else if (checkBox3.Checked == true)
                {
                    ogr_cevap = "C";
                }
                else if (checkBox4.Checked == true)
                {
                    ogr_cevap = "D";
                }
                else if (checkBox5.Checked == true)
                {
                    ogr_cevap = "E";
                }
                else
                {
                    ogr_cevap = "";
                }
            

                if (ogr_cevap == dogru_cevap)
                {
                    cevap = true;
                }
                else
                {
                    cevap = false;
                }

                MessageBox.Show(soru_durum.ToString());
                connection.Open();
                NpgsqlCommand query = new NpgsqlCommand("SELECT count(*) FROM reply WHERE questions_id=@soru_id AND ogrenci_no=@ogr_no",connection );
                query.Parameters.AddWithValue("@soru_id", ques_id);
                query.Parameters.AddWithValue("@ogr_no", ogrenci_no);
                NpgsqlDataReader reader = query.ExecuteReader();
            
                while( reader.Read() )
                {
                    if(Convert.ToInt32(reader[0].ToString()) != 1)
                    {
                        soru_durum = false; //cevaplanmamış
                    }
                    else
                    {
                        soru_durum=true; // cevaplanmış
                    }
                }
                connection.Close();
            
                if (soru_durum == false)
                {
                
                    connection.Open();
                    NpgsqlCommand cevapekle = new NpgsqlCommand("INSERT INTO reply (ogrenci_no, lesson_id, exam_id, questions_id, is_it_true) values (@student_id, @lesson_id, @exam_id, @question_id, @is_it_true)", connection);
                    cevapekle.Parameters.AddWithValue("@student_id", ogrenci_no);
                    cevapekle.Parameters.AddWithValue("@lesson_id", ders_id);
                    cevapekle.Parameters.AddWithValue("@exam_id", exam_id);
                    cevapekle.Parameters.AddWithValue("@question_id", ques_id);
                    cevapekle.Parameters.AddWithValue("@is_it_true", cevap);
                    cevapekle.ExecuteNonQuery();

                    connection.Close();
                    MessageBox.Show("Cevap Kaydedildi");
                }
                else
                {
                    connection.Open();
                    NpgsqlCommand cevap_guncelle = new NpgsqlCommand("UPDATE reply SET is_it_true=@is_it_true WHERE questions_id = @soru_id", connection);
                    cevap_guncelle.Parameters.AddWithValue("@is_it_true", cevap);
                    cevap_guncelle.Parameters.AddWithValue("@soru_id", ques_id);
                    cevap_guncelle.ExecuteNonQuery();

                    connection.Close();
                    MessageBox.Show("Cevap Güncellendi");
                }
                /////////////////////// if e al ve soru sayısından fazla artmasın
                int sayi = Convert.ToInt32(label4.Text);
                if(soru_sayisi > Convert.ToInt32(label4.Text))
                {
                    label4.Text = (sayi + 1).ToString();
                }
            

                ////////////////////////
                foreach (Control control in panel4.Controls)
                {
                    if (control is CheckBox checkbox)
                    {
                        checkbox.Checked = false;
                    }
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show("Hata : ", hata.Message);
            }
            

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                checkBox5.Checked = false;

            }
        }
       
        
        

        private void checkBox2_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                checkBox1.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                checkBox5.Checked = false;

            }
        }

        private void checkBox3_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                checkBox2.Checked = false;
                checkBox1.Checked = false;
                checkBox4.Checked = false;
                checkBox5.Checked = false;

            }
        }

        private void checkBox4_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
            {
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox1.Checked = false;
                checkBox5.Checked = false;

            }
        }

        private void checkBox5_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox5.Checked)
            {
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                checkBox1.Checked = false;

            }
        }

        private void labelDakika2_TextChanged(object sender, EventArgs e)
        {
            if (labelDakika2.Text == "4")
            {
                labelDakika1.ForeColor = Color.Yellow;
                labelDakika2.ForeColor = Color.Yellow;
                labelSaniye1.ForeColor = Color.Yellow;
                labelSaniye2.ForeColor = Color.Yellow;
                label7.ForeColor = Color.Yellow;
            }
            else if (labelDakika2.Text == "1")
            {
                labelDakika1.ForeColor = Color.Red;
                labelDakika2.ForeColor = Color.Red;
                labelSaniye1.ForeColor = Color.Red;
                labelSaniye2.ForeColor = Color.Red;
                label7.ForeColor = Color.Red;
            }
        }
        int dogru_cevap_sayisi = 0;
        float sinav_sonuc = 0;
        Boolean sinav_durum = false;

        public void sınavbitir()
        {

            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
                NpgsqlConnection connection = new NpgsqlConnection(connectionString);

                connection.Open();
                NpgsqlCommand not_sorgu = new NpgsqlCommand("SELECT count(*) FROM exam_student WHERE ogrenci_no = @ogr_no AND exam_id = @ex_id", connection);
                not_sorgu.Parameters.AddWithValue("@ogr_no", ogrenci_no);
                not_sorgu.Parameters.AddWithValue("@ex_id", exam_id);
                NpgsqlDataReader r = not_sorgu.ExecuteReader();
                while (r.Read())
                {
                    if (Convert.ToInt32(r["count"]) == 0)
                    {
                        sinav_durum = false;
                    }
                    else
                    {
                        sinav_durum = true;
                    }
                }
                connection.Close();


                MessageBox.Show("Cevaplarınız Kaydedildi Sınav Sonlandırılıyor ......!");


                connection.Open();
                NpgsqlCommand nothesapla = new NpgsqlCommand("SELECT count(*) FROM reply WHERE ogrenci_no = @ogr_no AND exam_id = @ex_id AND is_it_true = " + true + " ", connection);
                nothesapla.Parameters.AddWithValue("@ogr_no", ogrenci_no);
                nothesapla.Parameters.AddWithValue("@ex_id", exam_id);
                NpgsqlDataReader notreader = nothesapla.ExecuteReader();
                while (notreader.Read())
                {
                    dogru_cevap_sayisi = Convert.ToInt32(notreader["count"].ToString());
                }

                sinav_sonuc = (100f / soru_sayisi) * dogru_cevap_sayisi;

                

                connection.Close();

                if (sinav_durum == false)
                {
                    connection.Open();
                    NpgsqlCommand npgsqlCommand = new NpgsqlCommand("INSERT INTO exam_student (exam_id, ogrenci_no, cozme_drm, exam_not) values (@ex_id, @ogrenci_no, @cozme_drm, @not)", connection);
                    npgsqlCommand.Parameters.AddWithValue("@ex_id", exam_id);
                    npgsqlCommand.Parameters.AddWithValue("@ogrenci_no", ogrenci_no);
                    npgsqlCommand.Parameters.AddWithValue("@cozme_drm", true);
                    npgsqlCommand.Parameters.AddWithValue("@not", sinav_sonuc);
                    npgsqlCommand.ExecuteNonQuery();
                }
                else
                {
                    connection.Open();
                    NpgsqlCommand sonucgir = new NpgsqlCommand("UPDATE exam_student SET cozme_drm = @drm, exam_not =@nt  WHERE ogrenci_no = @ogr_no AND exam_id = @ex_id", connection);
                    sonucgir.Parameters.AddWithValue("@ogr_no", ogrenci_no);
                    sonucgir.Parameters.AddWithValue("@ex_id", exam_id);
                    sonucgir.Parameters.AddWithValue("@nt", sinav_sonuc);
                    sonucgir.Parameters.AddWithValue("@drm", true);
                    sonucgir.ExecuteNonQuery();

                }


                connection.Close();
            }
            catch(Exception hata)
            {
                MessageBox.Show("Hata" + hata.Message);
            }
            
            
        }
        MailMessage eposta = new MailMessage();
        string veli_mail = "";
        string veli_ad = "";
        string ogr_ad_soyad = "";
        string ders_adi = "";
        string sinav_adi = "";
        
        private void button_sonlandır_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }
    }

}
