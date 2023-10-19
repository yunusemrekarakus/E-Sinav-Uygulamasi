using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;


namespace esinav
{
    public partial class sunucu_ayar_form : Form
    {
        public sunucu_ayar_form()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionStringName = "MyConnectionString";

                // TextBox'lardan girişleri alın
                string server = t_sunucu_ip.Text;
                string port = t_port.Text;
                string userId = t_vt_username.Text;
                string password = t_vt_passwd.Text;

                // Connection string'i oluşturun
                string connectionString = $"Server={server}; Port={port}; Database=mydatabase; User Id={userId}; Password={password};";

                // Connection string'i App.config dosyasında güncelleyin
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.ConnectionStrings.ConnectionStrings[connectionStringName].ConnectionString = connectionString;
                config.Save(ConfigurationSaveMode.Modified);

                // Connection string'i yeniden yükle (gerekli olduğunda)
                ConfigurationManager.RefreshSection("connectionStrings");
            }
            catch (Exception hata)
            {
                MessageBox.Show("Hata : ", hata.Message);
            }

            

        }

        
    }
}
