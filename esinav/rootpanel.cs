using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace esinav
{
    public partial class rootpanel : Form
    {
        public Boolean usernameonay = false;
        public rootpanel()
        {
            InitializeComponent();
        }
        private NpgsqlConnection connection;

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Title = "Yöneticinin Fotoğrafını Seçiniz.";
                ofd.ShowDialog();
                textBox7.Text = ofd.FileName;
                pictureBox1.ImageLocation = textBox7.Text;
            }
            catch (Exception hata)
            {
                MessageBox.Show("Hata : ", hata.Message);
            }
        }

        private void textusername_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
                NpgsqlConnection connection = new NpgsqlConnection(connectionString);
                connection.Open();
                string adminquery = ("SELECT * FROM manager WHERE username=@username");
                NpgsqlParameter prm1 = new NpgsqlParameter("username", textusername.Text);
                NpgsqlCommand adquery = new NpgsqlCommand(adminquery, connection);
                adquery.Parameters.Add(prm1);
                DataTable dt = new DataTable();
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(adquery);
                da.Fill(dt);
                if (textusername.Text.Length > 5 && dt.Rows.Count == 0)
                {
                    pictureBox2.Image = ımageList1.Images[1];
                }
                else
                {
                    pictureBox2.Image = ımageList1.Images[0];
                    usernameonay = true;
                }
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
                foreach (Control childControl in control.Controls)
                {
                    if (childControl is System.Windows.Forms.TextBox)
                    {
                        childControl.KeyPress += TextBox_KeyPress;
                    }
                    else if (childControl.HasChildren)
                    {
                        AttachUpperCaseEventHandlers(childControl);
                    }
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show("Hata : ", hata.Message);
            }
           
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            AttachUpperCaseEventHandlers(this);


            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            
        }
        

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (textusername.Text == "" || textpasswd.Text == "" || textad.Text == "" || textsoyad.Text == "" || textphonenum.Text == "" || textboxtc.Text == "" || textboxemail.Text == "" || textBox7.Text == "")
                {
                    MessageBox.Show("Zorunlu Alanları Boş Bırakmayınız...!");
                }
                else
                {
                    connection.Open();
                    NpgsqlCommand veriekle = new NpgsqlCommand("INSERT INTO MANAGER (name,surname,tc,phone_num,email,username,password,pictures) VALUES (@name,@surname,@tc,@phone_num,@email,@username,@password,@pictures)");
                    veriekle.Connection = connection;
                    veriekle.Parameters.AddWithValue("name", textad.Text.Trim());
                    veriekle.Parameters.AddWithValue("surname", textsoyad.Text.Trim());
                    veriekle.Parameters.AddWithValue("tc", textboxtc.Text.Trim());
                    veriekle.Parameters.AddWithValue("phone_num", textphonenum.Text.Trim());
                    veriekle.Parameters.AddWithValue("email", textboxemail.Text.Trim());
                    veriekle.Parameters.AddWithValue("username", textusername.Text.Trim());
                    veriekle.Parameters.AddWithValue("password", textpasswd.Text.Trim());
                    veriekle.Parameters.AddWithValue("pictures", textBox7.Text.Trim());
                    veriekle.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("Yönetici Kaydedildi !");
                    MessageBox.Show("Yönetici" + textusername.Text + "Kullanıcı Adı İle Oluşturuldu");
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show("Hata : ", hata.Message);
            }

            
               

            
        }

        
    }
}
