using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Mysqlx.Connection;
using static CourseSystem.araçbak;

namespace CourseSystem
{
    public partial class adminlogin : Form
    {
        public adminlogin()
        {
            InitializeComponent();
            textBox2.PasswordChar = '*';



        }

        string connectionString = ConnectionInformation.connectionString;


        [DllImport("gdi32.dll")]
        private static extern IntPtr CreateRoundRectRgn(int x1, int y1, int x2, int y2, int cx, int cy);

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
                            YukleniyorGoster();
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

            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Multiline = true;
            textBox1.Size = new Size(471, 65);
            textBox1.Padding = new Padding(60, 60, 60, 60);
            textBox1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, textBox1.Width, textBox1.Height, 60, 60));

            textBox2.BorderStyle = BorderStyle.None;
            textBox2.Multiline = true;
            textBox2.Size = new Size(471, 65);
            textBox2.Padding = new Padding(60, 60, 60, 60);
            textBox2.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, textBox2.Width, textBox2.Height, 60, 60));
        }

       


        private void button2_Click(object sender, EventArgs e)
        {


            
            login log = new login();
            OpenFormWithFade(log);
        }

        private void YukleniyorGoster()
        {
            
            Form yukleniyorForm = new Form();
            yukleniyorForm.Size = new Size(250, 100);
            yukleniyorForm.StartPosition = FormStartPosition.CenterScreen;
            yukleniyorForm.FormBorderStyle = FormBorderStyle.None;
            yukleniyorForm.BackColor = Color.White;
            yukleniyorForm.TopMost = true;

            Label lblYukleniyor = new Label();
            lblYukleniyor.Text = "Yükleniyor...";
            lblYukleniyor.Font = new Font("Arial", 12, FontStyle.Bold);
            lblYukleniyor.ForeColor = Color.Blue;
            lblYukleniyor.TextAlign = ContentAlignment.MiddleCenter;
            lblYukleniyor.Dock = DockStyle.Fill;
            yukleniyorForm.Controls.Add(lblYukleniyor);

            
            yukleniyorForm.Paint += (s, pe) =>
            {
                using (Pen pen = new Pen(Color.Blue, 2))
                {
                    pe.Graphics.DrawRectangle(pen, 0, 0, yukleniyorForm.Width - 1, yukleniyorForm.Height - 1);
                }
            };

            
            yukleniyorForm.Show();
            yukleniyorForm.Refresh();

            
            Thread.Sleep(3000);

            
            yukleniyorForm.Close();

           
        }

        private void adminlogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
