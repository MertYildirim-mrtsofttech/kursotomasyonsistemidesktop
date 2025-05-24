using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace CourseSystem
{
    public partial class usernamepassword : Form
    {
        string connectionString = "Server=servername;Database=databasename;User ID=username;Password=password;";
        public usernamepassword()
        {
            InitializeComponent();
            textBox2.PasswordChar = '*';
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Guncelle();
        }

        public void Guncelle()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "UPDATE admin SET username=@newusername,password=@newpassword WHERE username=@currentusername";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@newusername", textBox1.Text);
                        cmd.Parameters.AddWithValue("@newpassword", textBox2.Text);
                        cmd.Parameters.AddWithValue("@currentusername", textBox3.Text);

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Kullanıcı adı ve şifre güncellendi");


                        adminlogin login = new adminlogin();
                        login.Show();
                        this.Close();


                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kullanıcı adı ve şifre değiştirme hatası", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void usernamepassword_Load(object sender, EventArgs e)
        {
            textBox3.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            admin admin = new admin();
            OpenFormWithFade(admin);
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

        private void usernamepassword_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
