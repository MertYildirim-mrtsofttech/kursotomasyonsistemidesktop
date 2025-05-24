using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Mysqlx.Connection;

namespace CourseSystem
{
    public partial class adminlogin : Form
    {
        public adminlogin()
        {
            InitializeComponent();
            textBox2.PasswordChar = '*';

        }

        
        string connectionString = "Server=servername;Database=databasename;User ID=username;Password=password;";


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void InternetKontrolEt()
        {
            if (InternetVarMi())
            {

            }
            else
            {
                MessageBox.Show("İnternet bağlantısı yok!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private bool InternetVarMi()
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead("http://www.google.com"))
                    return true;
            }
            catch
            {
                return false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {

                    connection.Open();
                    string query = "SELECT COUNT(*) FROM admin WHERE username=@username AND password=@password;";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@username", textBox1.Text);
                        command.Parameters.AddWithValue("@password", textBox2.Text);

                        int log = Convert.ToInt32(command.ExecuteScalar());

                        if (log > 0)
                        {
                            admin admin = new admin();
                            OpenFormWithFade(admin);
                        }
                        else
                        {
                            MessageBox.Show("Kullanıcı adınız ya da şifreniz hatalı.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }


                }

                catch (MySqlException ex)
                {

                    MessageBox.Show("Sunucu Hatası", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
        }

        private void OpenFormWithFade(Form nextForm)
        {
            nextForm.Opacity = 0;
            nextForm.StartPosition = FormStartPosition.CenterScreen;
            nextForm.Show();

            System.Windows.Forms.Timer fadeTimer = new System.Windows.Forms.Timer();
            fadeTimer.Interval = 5;
            fadeTimer.Tick += (s, e) =>
            {
                if (nextForm.Opacity < 1.0)
                {
                    nextForm.Opacity += 0.05;
                }
                else
                {
                    fadeTimer.Stop();
                    this.Hide();
                }
            };
            fadeTimer.Start();
        }

        private void adminlogin_Load(object sender, EventArgs e)
        {
            InternetKontrolEt();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            login log = new login();
            OpenFormWithFade(log);
        }

        private void adminlogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
