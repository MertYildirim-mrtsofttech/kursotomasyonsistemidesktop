using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using static CourseSystem.araçbak;

namespace CourseSystem
{
    public partial class araçekle : Form
    {
        public araçekle()
        {
            InitializeComponent();

        }

        [DllImport("gdi32.dll")]
        private static extern IntPtr CreateRoundRectRgn(int x1, int y1, int x2, int y2, int cx, int cy);


        string connectionString = ConnectionInformation.connectionString;
        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

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
            lblYukleniyor.Text = "Kaydediliyor...";
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

        private void YukleniyorGosterExit()
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

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {

                if (string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    MessageBox.Show("Plaka alanı boş olamaz!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();


                    byte[] resimVerisi = null;
                    if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        string resimYolu = openFileDialog1.FileName;
                        resimVerisi = File.ReadAllBytes(resimYolu);


                    }




                    string save = @"INSERT INTO Araçlar (Plaka, Marka, Model, Yil, Renk, Kilometre, Durum, SonBakimTarihi, SonSigortaTarihi, SonVergiTarihi, YakitTipi, Resim) 
                            VALUES (@Plaka, @Marka, @Model, @Yıl, @Renk, @Kilometre, @Durum, @SonBakımTarihi, @SonSigortaTarihi, @SonVergiTarihi, @YakıtTipi, @Resim)";

                    using (MySqlCommand cmd = new MySqlCommand(save, conn))
                    {

                        cmd.Parameters.AddWithValue("@Plaka", textBox1.Text);
                        cmd.Parameters.AddWithValue("@Marka", textBox2.Text);
                        cmd.Parameters.AddWithValue("@Model", textBox3.Text);
                        cmd.Parameters.AddWithValue("@Yıl", textBox4.Text);
                        cmd.Parameters.AddWithValue("@Renk", textBox5.Text);
                        cmd.Parameters.AddWithValue("@Kilometre", textBox6.Text);
                        cmd.Parameters.AddWithValue("@Durum", textBox7.Text);
                        cmd.Parameters.AddWithValue("@SonBakımTarihi", dateTimePicker1.Value);
                        cmd.Parameters.AddWithValue("@SonSigortaTarihi", dateTimePicker2.Value);
                        cmd.Parameters.AddWithValue("@SonVergiTarihi", dateTimePicker3.Value);
                        cmd.Parameters.AddWithValue("@YakıtTipi", textBox11.Text);


                        if (resimVerisi != null)
                        {
                            cmd.Parameters.AddWithValue("@Resim", resimVerisi);
                        }
                        else
                        {
                            MessageBox.Show("Resim Verisi Ekleyim");
                        }


                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            YukleniyorGoster();
                            MessageBox.Show("Araç ve Resim başarıyla kaydedildi.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Araç kaydı sırasında hata oluştu.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Araç Ekleme Hatası", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void button1_Click(object sender, EventArgs e)
        {
            YukleniyorGosterExit();
            admin admin = new admin();
            OpenFormWithFade(admin);
        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {

        }

        private void araçekle_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }



        private void araçekle_Load(object sender, EventArgs e)
        {

            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Multiline = true;
            textBox1.Size = new Size(150, 30);
            textBox1.Padding = new Padding(15, 15, 15, 15);
            textBox1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, textBox1.Width, textBox1.Height, 20, 20));
            textBox2.BorderStyle = BorderStyle.None;
            textBox2.Multiline = true;
            textBox2.Size = new Size(150, 30);
            textBox2.Padding = new Padding(15, 15, 15, 15);
            textBox2.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, textBox2.Width, textBox2.Height, 20, 20));
            textBox3.BorderStyle = BorderStyle.None;
            textBox3.Multiline = true;
            textBox3.Size = new Size(150, 30);
            textBox3.Padding = new Padding(15, 15, 15, 15);
            textBox3.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, textBox3.Width, textBox3.Height, 20, 20));
            textBox4.BorderStyle = BorderStyle.None;
            textBox4.Multiline = true;
            textBox4.Size = new Size(150, 30);
            textBox4.Padding = new Padding(15, 15, 15, 15);
            textBox4.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, textBox4.Width, textBox4.Height, 20, 20));
            textBox5.BorderStyle = BorderStyle.None;
            textBox5.Multiline = true;
            textBox5.Size = new Size(150, 30);
            textBox5.Padding = new Padding(15, 15, 15, 15);
            textBox5.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, textBox5.Width, textBox5.Height, 20, 20));
            textBox6.BorderStyle = BorderStyle.None;
            textBox6.Multiline = true;
            textBox6.Size = new Size(150, 30);
            textBox6.Padding = new Padding(15, 15, 15, 15);
            textBox6.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, textBox6.Width, textBox6.Height, 20, 20));
            textBox7.BorderStyle = BorderStyle.None;
            textBox7.Multiline = true;
            textBox7.Size = new Size(150, 30);
            textBox7.Padding = new Padding(15, 15, 15, 15);
            textBox7.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, textBox7.Width, textBox7.Height, 20, 20));
            textBox11.BorderStyle = BorderStyle.None;
            textBox11.Multiline = true;
            textBox11.Size = new Size(150, 30);
            textBox11.Padding = new Padding(15, 15, 15, 15);
            textBox11.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, textBox11.Width, textBox11.Height, 20, 20));


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_Click(object sender, EventArgs e)
        {

        }
    }

}
