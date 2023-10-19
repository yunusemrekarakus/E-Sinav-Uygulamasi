using Npgsql;
using System;
using System.Data;
using System.Windows.Forms;
using System.Configuration;


namespace esinav
{
    public partial class giris : Form
    {
        

        private NpgsqlConnection connection;

        public giris()
        {
            InitializeComponent();
            
        }
        public void captcha()
        {
            try
            {
                Random random = new Random();
                int num = random.Next(6, 8);
                string captcha = "";
                int tot1 = 0;
                do
                {
                    int chr = random.Next(48, 123);
                    if ((chr >= 48 && chr <= 57) || (chr >= 65 && chr <= 90) || (chr >= 97 && chr <= 122))
                    {
                        captcha = captcha + (char)chr;
                        tot1++;
                        if (tot1 == num)
                            break;
                        {

                        }
                    }
                }
                while (true);
                label10.Text = captcha;
                label12.Text = captcha;
                label13.Text = captcha;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata : ", ex.Message);
            }

        }
        


        private void panel7_MouseClick_1(object sender, MouseEventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        

        private void button2_Click(object sender, EventArgs e)
        {
            

            
            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

            
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);

            try
            {
                connection.Open();
                string admincontrol = ("SELECT * FROM manager WHERE username=@username AND password=@password");
                NpgsqlParameter prm1 = new NpgsqlParameter("username", textbox_u_admin.Text);
                NpgsqlParameter prm2 = new NpgsqlParameter("password", textbox_psw_admin.Text);
                NpgsqlCommand control = new NpgsqlCommand(admincontrol, connection);
                control.Parameters.Add(prm1);
                control.Parameters.Add(prm2);
                DataTable dt = new DataTable();
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(control);
                da.Fill(dt);
                string username = textbox_u_admin.Text;
                if (dt.Rows.Count > 0 && label10.Text == textBox1.Text)
                {
                    connection.Close();
                    this.Controls.Clear();
                    this.InitializeComponent();
                    yoneticipanel form2 = new yoneticipanel();
                    form2.label4.Text = username;
                    form2.Show();
                    captcha();
                }
                else if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Hatalı Şifre Veya Kullanıcı Adı...!");
                }
                else
                {
                    MessageBox.Show("Hatalı Captcha Kodu.....!");
                    connection.Close();
                    this.Controls.Clear();
                    this.InitializeComponent();
                    captcha();
                }

            }
            catch (Exception ex)
            {
                
                MessageBox.Show("Hata : ", ex.Message);
            }

            
        }

        private void button5_Click(object sender, EventArgs e)
        {

            /*try
            {*/
                string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
                NpgsqlConnection connection = new NpgsqlConnection(connectionString);

                connection.Open();
                string adminquery = ("SELECT * FROM admin WHERE username=@username AND password=@password");
                NpgsqlParameter prm1 = new NpgsqlParameter("username", textbox_u_admin.Text);
                NpgsqlParameter prm2 = new NpgsqlParameter("password", textbox_psw_admin.Text);
                NpgsqlCommand adquery = new NpgsqlCommand(adminquery, connection);
                adquery.Parameters.Add(prm1);
                adquery.Parameters.Add(prm2);
                DataTable dt = new DataTable();
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(adquery);
                da.Fill(dt);
                string username = textbox_u_admin.Text;
                if (dt.Rows.Count > 0 && label10.Text == textBox1.Text)
                {
                    connection.Close();
                    this.Controls.Clear();
                    this.InitializeComponent();
                    rootpanel form3 = new rootpanel();
                    /*form2.label4.Text = username;*/
                    form3.Show();
                    captcha();
                }
                else if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Hatalı root Şifre Veya Kullanıcı Adı...!");
                }
                else
                {
                    MessageBox.Show("Hatalı Captcha Kodu.....!");
                    connection.Close();
                    this.Controls.Clear();
                    this.InitializeComponent();
                    captcha();
                }
            /*}
            catch (Exception ex)
            {

                MessageBox.Show("Hata : ", ex.Message);
            }*/


        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            captcha();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            captcha();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            captcha();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            ogretmenparolayenileme form8 = new ogretmenparolayenileme();
            form8.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
                NpgsqlConnection connection = new NpgsqlConnection(connectionString);
                connection.Open();
                string sorgu = ("SELECT * FROM teacher WHERE t_username=@u_name AND t_password=@passwd");
                NpgsqlParameter prm1 = new NpgsqlParameter("@u_name", textbox_u_teacher.Text.Trim());
                NpgsqlParameter prm2 = new NpgsqlParameter("@passwd", textbox_pwd_teacher.Text.Trim());
                NpgsqlCommand query = new NpgsqlCommand(sorgu, connection);
                query.Parameters.Add(prm1);
                query.Parameters.Add(prm2);
                DataTable dt = new DataTable();
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(query);
                da.Fill(dt);
                string username = textbox_u_teacher.Text.Trim();

                if (dt.Rows.Count > 0 && label12.Text.Trim() == textBox2.Text.Trim())
                {
                    connection.Close();
                    this.Controls.Clear();
                    this.InitializeComponent();
                    ogretmensayfa form9 = new ogretmensayfa();
                    form9.label4.Text = username;
                    form9.Show();
                    captcha();
                }
                else
                {
                    MessageBox.Show("GİRİŞ BİLGİLERİNİZİ KONTROL EDİNİZ.");
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata : ", ex.Message);
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
                NpgsqlConnection connection = new NpgsqlConnection(connectionString);

                connection.Open();
                string sorgu = ("SELECT * FROM student WHERE ogrenci_no=@u_name AND ogr_parola=@passwd");
                NpgsqlParameter prm1 = new NpgsqlParameter("@u_name", Convert.ToInt32(textBox6.Text.Trim()));
                NpgsqlParameter prm2 = new NpgsqlParameter("@passwd", textBox5.Text.Trim());
                NpgsqlCommand query = new NpgsqlCommand(sorgu, connection);
                query.Parameters.Add(prm1);
                query.Parameters.Add(prm2);
                DataTable dt = new DataTable();
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(query);
                da.Fill(dt);
                /*string username = textbox_u_teacher.Text.Trim();*/
                string ogr_no = textBox6.Text.Trim();

                if (dt.Rows.Count > 0 && label13.Text.Trim() == textBox3.Text.Trim())
                {
                    connection.Close();
                    this.Controls.Clear();
                    this.InitializeComponent();
                    ogrencipanel form10 = new ogrencipanel();
                    form10.str_no = ogr_no;
                    /*form10.label4.Text = username;*/
                    form10.Show();
                    captcha();
                }
                else
                {
                    MessageBox.Show("GİRİŞ BİLGİLERİNİZİ KONTROL EDİNİZ.");
                }
                connection.Close();
            }
            catch (Exception hata)
            {
                MessageBox.Show("Hata : ", hata.Message);
            }

            

        }

        private void button7_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);

            sinavcozme formsinav= new sinavcozme();
            formsinav.Show();
        }

        private void sunucuAyarlarıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sunucu_ayar_form sunucu_Ayar_Form = new sunucu_ayar_form();
            sunucu_Ayar_Form.Show();
        }

        private void giris_Load(object sender, EventArgs e)
        {
            captcha();
        }
    }
}
