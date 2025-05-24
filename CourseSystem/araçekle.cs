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

namespace CourseSystem
{
    public partial class araçekle : Form
    {
        public araçekle()
        {
            InitializeComponent();
        }

        string connectionString = "Server=servername;Database=databasename;User ID=username;Password=password;";
        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

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
    }

}
