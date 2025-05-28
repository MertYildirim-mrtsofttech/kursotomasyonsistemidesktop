using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static CourseSystem.araçbak;

namespace CourseSystem
{
    public partial class usernamepassword : Form
    {
        string connectionString = ConnectionInformation.connectionString;

        [DllImport("gdi32.dll")]
        private static extern IntPtr CreateRoundRectRgn(int x1, int y1, int x2, int y2, int cx, int cy);
        public usernamepassword()
        {
            InitializeComponent();
            textBox2.PasswordChar = '*';
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
            {
                GuncelleniyorGoster();
                Guncelle();
            }

            else
            {
                MessageBox.Show("Gerekli yerleri doldurunuz.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Multiline = true;
            textBox1.Size = new Size(290, 38);
            textBox1.Padding = new Padding(15, 15, 15, 15);
            textBox1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, textBox1.Width, textBox1.Height, 20, 20));

            textBox2.BorderStyle = BorderStyle.None;
            textBox2.Multiline = true;
            textBox2.Size = new Size(290, 38);
            textBox2.Padding = new Padding(15, 15, 15, 15);
            textBox2.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, textBox2.Width, textBox2.Height, 20, 20));

            textBox3.BorderStyle = BorderStyle.None;
            textBox3.Multiline = true;
            textBox3.Size = new Size(290, 38);
            textBox3.Padding = new Padding(15, 15, 15, 15);
            textBox3.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, textBox3.Width, textBox3.Height, 20, 20));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            YukleniyorGoster();
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

        private void GuncelleniyorGoster()
        {

            Form yukleniyorForm = new Form();
            yukleniyorForm.Size = new Size(250, 100);
            yukleniyorForm.StartPosition = FormStartPosition.CenterScreen;
            yukleniyorForm.FormBorderStyle = FormBorderStyle.None;
            yukleniyorForm.BackColor = Color.White;
            yukleniyorForm.TopMost = true;

            Label lblYukleniyor = new Label();
            lblYukleniyor.Text = "Güncelleniyor...";
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
    }
}
