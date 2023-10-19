using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Configuration;
using System.Data;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using CheckBox = System.Windows.Forms.CheckBox;

namespace esinav
{
    public partial class sinavhazirlamapanel : Form
    {
        public string sinavisim { get; set; }
        public string exam_id { get; set; }

        public sinavhazirlamapanel()
        {
            InitializeComponent();
        }
        private NpgsqlConnection connection;
        
        public int sorusayisi = 0;
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (numericUpDown1.Value != 0)
                {
                    panel2.Visible = true;
                }
                int buttonCount = (int)numericUpDown1.Value;
                int currentButtonCount = panel3.Controls.Count;

                if (buttonCount > currentButtonCount)
                {
                    for (int i = currentButtonCount; i < buttonCount; i++)
                    {
                        Button button = new Button();
                        button.Text = "Soru " + (i + 1);
                        button.Top = (button.Height + 10) * i;
                        button.Left = 10;
                        button.Size = new Size(240, 30);
                        i += 1;
                        button.Name = "button_" + i;
                        button.Click += DynamicButton_Click;
                        panel3.Controls.Add(button);
                        labelsayac.Text = i.ToString();
                        sorusayisi = i;
                    }
                }
                else if (buttonCount < currentButtonCount)
                {
                    int removeCount = currentButtonCount - buttonCount;
                    for (int i = currentButtonCount - 1; i >= buttonCount; i--)
                    {
                        panel3.Controls.RemoveAt(i);
                        labelsayac.Text = i.ToString();
                    }
                }
                AdjustPanelScroll();
            }
            catch (Exception hata)
            {
                MessageBox.Show("Hata : ", hata.Message);
            }
            
        }
        private void AdjustPanelScroll()
        {
            try
            {
                panel3.AutoScroll = false; // Otomatik kaydırmayı kapat
                int buttonHeight = panel3.Controls[0].Height; // Buton yüksekliği
                int panelHeight = panel3.Height; // Panel yüksekliği

                if (panel3.Controls.Count * (buttonHeight + 5) > panelHeight)
                {
                    panel3.AutoScroll = true; // Otomatik kaydırmayı aç
                }
            }
            catch(Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
        }
        List<string> list = new List<string>() ;
        private void DynamicButton_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
                NpgsqlConnection connection = new NpgsqlConnection(connectionString);

                Button clickedbutton  = (Button)sender;
                string buttonText = clickedbutton.Name;
                list.Clear();
            
                for (int i=1 ; i <= buttonText.Length-1; i++)
                {
                    char k = (char)buttonText[i];
                    if(k<=57 && k >= 48)
                    {
                        list.Add(k.ToString());
                    }
                }
                string result = string.Join("", list);
                labelsayac.Text=result;


                MessageBox.Show("result" + result);
                foreach (Control control in panel2.Controls)
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
                    else if (control is CheckBox)
                    {
                        CheckBox CheckBox = (CheckBox)control;
                        CheckBox.Checked = false;
                    }
                }

                ////////////////////////////
                int sayi = Convert.ToInt32(result);
                MessageBox.Show("Dinanmik Butona Tıklandı " + result);
                connection.Open();
                NpgsqlCommand query = new NpgsqlCommand("SELECT * FROM questions WHERE question_number=@soru_id AND exam_id=@sinav_id" , connection);
                query.Parameters.AddWithValue("@soru_id", Convert.ToInt32(labelsayac.Text));
                query.Parameters.AddWithValue("@sinav_id", sinav_id);
                NpgsqlDataReader reader = query.ExecuteReader();
                while (reader.Read())
                {
                    textBox1.Text = reader["question"].ToString();
                    textBox2.Text = reader["question_a"].ToString();
                    textBox3.Text = reader["question_b"].ToString();
                    textBox4.Text = reader["question_c"].ToString();
                    textBox5.Text = reader["question_d"].ToString();
                    textBox6.Text = reader["question_e"].ToString();
                    pictureBox1.ImageLocation = reader["question_image"].ToString();
                    labelsayac.Text = reader["question_number"].ToString();
                    switch (reader["true_choice"].ToString())
                    {
                        case "A":
                            checkBox1.Checked = true;
                            break;
                        case "B":
                            checkBox2.Checked = true;
                            break;
                        case "C":
                            checkBox3.Checked = true;
                            break;
                        case "D":
                            checkBox4.Checked = true;
                            break;
                        case "E":
                            checkBox5.Checked = true;
                            break;
                    }
                }
                connection.Close();
            }
            catch (Exception hata)
            {
                MessageBox.Show("Hata : ", hata.Message);
            }
            
        }


        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                checkBox5.Checked = false;
                // Diğer checkbox'ların seçimini kaldır
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                checkBox1.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                checkBox5.Checked = false;
                // Diğer checkbox'ların seçimini kaldır
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox4.Checked = false;
                checkBox5.Checked = false;
                // Diğer checkbox'ların seçimini kaldır
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
            {
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox5.Checked = false;
                // Diğer checkbox'ların seçimini kaldır
            }
        }
        
        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked)
            {
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                // Diğer checkbox'ların seçimini kaldır
            }
        }
        public int sinav_id = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Soru Fotoğrafını Seçiniz :";
            openFileDialog.ShowDialog();
            pictureBox1.ImageLocation = openFileDialog.FileName;
        }
        public string dogru_secenek;
        int exam_id1 = 0;
        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                bool check1 = checkBox1.Checked;
                bool check2 = checkBox2.Checked;
                bool check3 = checkBox3.Checked;
                bool check4 = checkBox4.Checked;
                bool check5 = checkBox5.Checked;
            
                switch (true)
                {
                    case bool durum when durum == check1:
                        dogru_secenek = "A";
                    
                        break;
                    case bool durum when durum == check2:
                        dogru_secenek = "B";
                    
                        break;
                    case bool durum when durum == check3:
                        dogru_secenek = "C";
                    
                        break;
                    case bool durum when durum == check4:
                        dogru_secenek = "D";
                    
                        break;
                    case bool durum when durum == check5:
                        dogru_secenek = "E";
                    
                        break;

                }
                ///////////////////////////////////
                if (pictureBox1.ImageLocation == null)
                {
                    pictureBox1.ImageLocation = "";
                }

                string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
                NpgsqlConnection connection = new NpgsqlConnection(connectionString);

                MessageBox.Show(sinavisim);
                connection.Open();

                NpgsqlCommand npgsqlCommand = new NpgsqlCommand("SELECT * FROM exams WHERE exam_names=@sinavisim",connection);
                npgsqlCommand.Parameters.AddWithValue("@sinavisim", sinavisim.ToString());
                NpgsqlDataReader reader = npgsqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    exam_id1 = Convert.ToInt32(reader["exam_id"].ToString());
                    sinav_id = Convert.ToInt32(reader["exam_id"].ToString());
                }
                connection.Close();
            
            
                connection.Open();
                NpgsqlCommand soru_ekle = new NpgsqlCommand("INSERT INTO questions (exam_id, question, question_a, question_b, question_c, question_d, question_e, question_image,true_choice, question_number) values (@exam_id,@question,@question_a,@question_b,@question_c,@question_d,@question_e,@question_image,@true_choice,@ques_number)", connection);
                soru_ekle.Parameters.AddWithValue("@exam_id", exam_id1);
                soru_ekle.Parameters.AddWithValue("@question", textBox1.Text.Trim());
                soru_ekle.Parameters.AddWithValue("@question_a", textBox2.Text.Trim());
                soru_ekle.Parameters.AddWithValue("@question_b", textBox3.Text.Trim());
                soru_ekle.Parameters.AddWithValue("@question_c", textBox4.Text.Trim());
                soru_ekle.Parameters.AddWithValue("@question_d", textBox5.Text.Trim());
                soru_ekle.Parameters.AddWithValue("@question_e", textBox6.Text.Trim());
                soru_ekle.Parameters.AddWithValue("@question_image", pictureBox1.ImageLocation.ToString());
                soru_ekle.Parameters.AddWithValue("@true_choice", dogru_secenek.ToString());
                soru_ekle.Parameters.AddWithValue("@ques_number", Convert.ToInt32(labelsayac.Text));
                soru_ekle.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Soru Kaydedildi");

                int lbsayac = Convert.ToInt32(labelsayac.Text);

                if (lbsayac == sorusayisi)
                {
                    MessageBox.Show("Son Soruyu Eklediniz !!!!!");
                }
                else
                {
                    int sorusayi = Convert.ToInt32(labelsayac.Text);
                    sorusayi += 1;
                    foreach (Control control in panel2.Controls)
                    {
                        if (control is TextBox textBox)
                        {
                            textBox.Text = string.Empty;
                        }
                        else if (control is ComboBox comboBox)
                        {
                            comboBox.SelectedIndex = -1;
                        }
                        else if (control is CheckBox checkBox)
                        {
                            checkBox.Checked = false;
                        }
                        else if (control is PictureBox pictureBox)
                        {
                            pictureBox.ImageLocation = "";
                        }
                    }

                    labelsayac.Text = sorusayi.ToString();
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show("Hata : ", hata.Message);
            }
            ///////////////////////////////////
            


        }
        Boolean sinav_soru_durum = false;
        private void Form11_Load(object sender, EventArgs e)
        {
            try
            {
                panel2.Visible = true;
                string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
                NpgsqlConnection connection = new NpgsqlConnection(connectionString);
                connection.Open();
                NpgsqlCommand query = new NpgsqlCommand("SELECT count(*) FROM questions WHERE exam_id = " + sinav_id + "", connection);
                NpgsqlDataReader reader = query.ExecuteReader();
                while (reader.Read())
                {
                    if (Convert.ToInt32(reader["count"].ToString()) > 0)
                    {
                        sinav_soru_durum = true;
                    }
                    else
                    {
                        sinav_soru_durum = false;
                    }
                }
                connection.Close();

                if (sinav_soru_durum == true)
                {
                    panel2.Visible = true;
                    connection.Open();
                    MessageBox.Show(sinav_id.ToString());
                    NpgsqlCommand soru_sayi = new NpgsqlCommand("SELECT count(*) FROM questions WHERE exam_id = @exam_id", connection);
                    soru_sayi.Parameters.AddWithValue("@exam_id", sinav_id);
                    NpgsqlDataReader sayireader = soru_sayi.ExecuteReader();

                    while (sayireader.Read())
                    {
                        sorusayisi = Convert.ToInt32(sayireader["count"].ToString());
                    }

                    connection.Close();
                    MessageBox.Show(sorusayisi.ToString());

                    for (int i = 1; i <= sorusayisi ; i++)
                    {
                        Button button = new Button();
                        button.Text = "Soru " + (i);
                        button.Top = (button.Height + 10) * i;
                        button.Left = 10;
                        button.Size = new Size(240, 30);
                    
                        button.Name = "button_" + i;
                        button.Click += DynamicButton_Click;
                        panel3.Controls.Add(button);
                        labelsayac.Text = i.ToString();
                    
                    }
                    labelsayac.Text = 1.ToString();
                    connection.Open();
                    NpgsqlCommand query1 = new NpgsqlCommand("SELECT * FROM questions WHERE question_number=@soru_id AND exam_id=@sinav_id", connection);
                    query1.Parameters.AddWithValue("@soru_id", Convert.ToInt32(labelsayac.Text));
                    query1.Parameters.AddWithValue("@sinav_id", sinav_id);
                    NpgsqlDataReader reader1 = query1.ExecuteReader();
                    while (reader1.Read())
                    {
                        textBox1.Text = reader1["question"].ToString();
                        textBox2.Text = reader1["question_a"].ToString();
                        textBox3.Text = reader1["question_b"].ToString();
                        textBox4.Text = reader1["question_c"].ToString();
                        textBox5.Text = reader1["question_d"].ToString();
                        textBox6.Text = reader1["question_e"].ToString();
                        pictureBox1.ImageLocation = reader1["question_image"].ToString();
                        labelsayac.Text = reader1["question_number"].ToString();
                        switch (reader1["true_choice"].ToString())
                        {
                            case "A":
                                checkBox1.Checked = true;
                                break;
                            case "B":
                                checkBox2.Checked = true;
                                break;
                            case "C":
                                checkBox3.Checked = true;
                                break;
                            case "D":
                                checkBox4.Checked = true;
                                break;
                            case "E":
                                checkBox5.Checked = true;
                                break;
                        }
                    }
                    connection.Close();
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show("Hata : ", hata.Message);
            }
            
        }
    }
}
