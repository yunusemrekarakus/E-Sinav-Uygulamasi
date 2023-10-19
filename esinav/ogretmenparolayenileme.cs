using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace esinav
{
    public partial class ogretmenparolayenileme : Form
    {
        private NpgsqlConnection connection;
        public ogretmenparolayenileme()
        {
            InitializeComponent();
        }

        MailMessage eposta = new MailMessage();

        public void codesend()
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
                NpgsqlConnection connection = new NpgsqlConnection(connectionString);

                connection.Open();
                NpgsqlCommand mail = new NpgsqlCommand("SELECT * FROM teacher WHERE t_username='" + textBox1.Text.Trim() + "'", connection);
                DataTable dt = new DataTable();
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(mail);
                da.Fill(dt);


                if (dt.Rows.Count > 0)
                {

                    NpgsqlDataReader reader = mail.ExecuteReader();
                    while (reader.Read())
                    {
                        try
                        {
                            Random random = new Random();
                            int num = random.Next(6, 8);
                            string d_kod = "";
                            int tot1 = 0;
                            do
                            {
                                int chr = random.Next(48, 123);
                                if ((chr >= 48 && chr <= 57) || (chr >= 97 && chr <= 122))
                                {
                                    d_kod = d_kod + (char)chr;
                                    tot1++;
                                    if (tot1 == num)
                                        break;
                                    {

                                    }
                                }
                            } while (true);
                            string dogrulama_kodu = d_kod;
                            label3.Text = dogrulama_kodu;
                            string email = reader["t_email"].ToString();
                            MessageBox.Show(email);
                            eposta.From = new MailAddress("esinavproje@outlook.com");
                            eposta.To.Add(email);
                            eposta.Subject = "ŞİFRE YENİLEME";
                            eposta.Body = d_kod;
                            SmtpClient smtp = new SmtpClient("outlook.com");
                            smtp.Credentials = new System.Net.NetworkCredential("esinavproje@outlook.com", "e_sinavproje55");
                            smtp.Host = "smtp.outlook.com";
                            smtp.EnableSsl = true;
                            smtp.Port = 587;
                            smtp.Send(eposta);
                            MessageBox.Show("Doğrulama Kodu Gönderildi.");
                            label4.Visible = true;
                            label5.Visible = true;
                            label6.Visible = true;
                            label7.Visible = true;
                            textBox2.Visible = true;
                            textBox3.Visible = true;
                            textBox4.Visible = true;
                            textBox5.Visible = true;
                            button2.Visible = true;

                        }
                        catch (Exception hata)
                        {
                            MessageBox.Show(hata.Message);
                        }


                    }

                }
                else
                {
                    MessageBox.Show("KULLANICI MEVCUT DEĞİL");
                }

                connection.Close();
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
                codesend();
                textBox1.ReadOnly = true;
                
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }


        }

        private void Form8_Load(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
                NpgsqlConnection connection = new NpgsqlConnection(connectionString);

                connection.Open();
                NpgsqlCommand eskiparolasorgu = new NpgsqlCommand("SELECT * FROM teacher WHERE t_password='"+textBox3.Text.Trim()+"'",connection);
                NpgsqlDataReader reader = eskiparolasorgu.ExecuteReader();

                while (reader.Read())
                {
                    label8.Text = reader["t_password"].ToString();
                    label9.Text = reader["t_tc"].ToString();
                }
                connection.Close();
                if (label8.Text.Trim() == textBox3.Text.Trim() && textBox2.Text.Trim() == textBox4.Text.Trim() && textBox5.Text.Trim() == label3.Text.Trim())
                {
                
                    connection.Open();
                    NpgsqlCommand passwd_update = new NpgsqlCommand("UPDATE teacher SET t_password='" + textBox4.Text.Trim() + "' WHERE t_tc='" + label9.Text.Trim() + "'", connection);
                    passwd_update.ExecuteNonQuery();
                    MessageBox.Show("PAROLANIZ DEĞİŞTİRİLMİŞTİR");

                    this.Close();
                
                }
                else
                {
                    MessageBox.Show("GİRİLEN BİLGİLERİ KONTROL EDİNİZ");
                }

                connection.Close();
            }
            catch (Exception hata)
            {
                MessageBox.Show("Hata : ", hata.Message);
            }
            


        }

        
    }
}
