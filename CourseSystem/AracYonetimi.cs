using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using static CourseSystem.araçbak;

namespace CourseSystem
{
    public partial class AracYonetimi : Form
    {
        string connectionString = ConnectionInformation.connectionString;

        private string secilenPlaka = "";

        public AracYonetimi()
        {
            InitializeComponent();
            AraclariListele();
        }

        private void AracYonetimi_Load(object sender, EventArgs e)
        {
            
            AraclariListele();
        }

        
        private void AraclariListele()
        {
            flowLayoutPanel1.Controls.Clear();

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT Plaka, Resim FROM Araçlar";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {

                                
                                flowLayoutPanel1.FlowDirection = FlowDirection.LeftToRight;
                                flowLayoutPanel1.WrapContents = true;
                                flowLayoutPanel1.AutoScroll = true;
                                flowLayoutPanel1.Width = this.ClientSize.Width - 40; 
                                this.Width = 800;

                                
                                Panel panel = new Panel
                                {
                                    Width = 350,
                                    Height = 300,
                                    Margin = new Padding(5, 10, 100, 10), 
                                    BorderStyle = BorderStyle.FixedSingle
                                };




                                
                                Label lblPlaka = new Label
                                {
                                    Text = reader["Plaka"].ToString(),
                                    Width = 150,
                                    TextAlign = ContentAlignment.MiddleCenter,
                                    Dock = DockStyle.Bottom,
                                    Font = new Font("Segoe UI", 10, FontStyle.Bold)

                                };

                                
                                PictureBox pictureBox = new PictureBox
                                {
                                    Width = 250,
                                    Height = 250,
                                    SizeMode = PictureBoxSizeMode.Zoom,
                                    Dock = DockStyle.Top
                                };

                                
                                if (!reader.IsDBNull(reader.GetOrdinal("Resim")))
                                {
                                    byte[] resimData = (byte[])reader["Resim"];
                                    using (MemoryStream ms = new MemoryStream(resimData))
                                    {
                                        pictureBox.Image = Image.FromStream(ms);
                                    }
                                }

                                
                                string plaka = reader["Plaka"].ToString();
                                panel.Click += (s, args) => AracSecildi(plaka);
                                pictureBox.Click += (s, args) => AracSecildi(plaka);
                                lblPlaka.Click += (s, args) => AracSecildi(plaka);

                                
                                panel.Controls.Add(pictureBox);
                                panel.Controls.Add(lblPlaka);

                                
                                flowLayoutPanel1.Controls.Add(panel);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Araçlar listelenirken hata oluştu: {ex.Message}", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        
        private void AracSecildi(string plaka)
        {
            secilenPlaka = plaka;
            YukleniyorGoster();
            randevu randevuForm = new randevu(secilenPlaka);
            OpenFormWithFade(randevuForm);

            
            AraclariListele();
        }

        private void btnGeriDon_Click(object sender, EventArgs e)
        {
            admin adminForm = new admin();
            adminForm.Show();
            this.Hide();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnGeriDon_Click_1(object sender, EventArgs e)
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

        private void AracYonetimi_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
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


            Thread.Sleep(5000);


            yukleniyorForm.Close();


        }
    }
}