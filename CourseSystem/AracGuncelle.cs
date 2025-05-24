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

namespace CourseSystem
{
    public partial class AracGuncelle : Form
    {
        public AracGuncelle()
        {
            InitializeComponent();
        }
        private string plaka;
        private string connectionString;
        private byte[] currentImageData;
        private string selectedImagePath;

        public AracGuncelle(string plaka, string connectionString)
        {
            InitializeComponent();
            this.plaka = plaka;
            this.connectionString = connectionString;
        }

        private void AracGuncelle_Load(object sender, EventArgs e)
        {
            LoadCarDetails();
        }

        private void LoadCarDetails()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT Plaka, Marka, Model, Renk, Yil, Kilometre, Durum, SonBakimTarihi, SonVergiTarihi, SonSigortaTarihi, YakitTipi, Resim FROM Araçlar WHERE Plaka = @Plaka";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Plaka", plaka);

                try
                {
                    connection.Open();
                    MySqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        
                        txtPlaka.Text = reader["Plaka"].ToString();
                        txtMarka.Text = reader["Marka"].ToString();
                        txtModel.Text = reader["Model"].ToString();
                        txtRenk.Text = reader["Renk"].ToString();
                        txtYil.Text = reader["Yil"].ToString();
                        txtKilometre.Text = reader["Kilometre"].ToString();
                        txtDurum.Text = reader["Durum"].ToString();

                        
                        if (reader["SonBakimTarihi"] != DBNull.Value)
                            dtpSonBakimTarihi.Value = Convert.ToDateTime(reader["SonBakimTarihi"]);

                        if (reader["SonVergiTarihi"] != DBNull.Value)
                            dtpSonVergiTarihi.Value = Convert.ToDateTime(reader["SonVergiTarihi"]);

                        if (reader["SonSigortaTarihi"] != DBNull.Value)
                            dtpSonSigortaTarihi.Value = Convert.ToDateTime(reader["SonSigortaTarihi"]);

                        txtYakitTipi.Text = reader["YakitTipi"].ToString();

                        
                        if (reader["Resim"] != DBNull.Value)
                        {
                            currentImageData = (byte[])reader["Resim"];
                            using (MemoryStream ms = new MemoryStream(currentImageData))
                            {
                                pictureBoxArac.Image = Image.FromStream(ms);
                                pictureBoxArac.SizeMode = PictureBoxSizeMode.Zoom;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Araç bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = @"UPDATE Araçlar 
                                SET Marka = @Marka, 
                                    Model = @Model, 
                                    Renk = @Renk, 
                                    Yil = @Yil, 
                                    Kilometre = @Kilometre, 
                                    Durum = @Durum, 
                                    SonBakimTarihi = @SonBakimTarihi, 
                                    SonVergiTarihi = @SonVergiTarihi, 
                                    SonSigortaTarihi = @SonSigortaTarihi, 
                                    YakitTipi = @YakitTipi";

                
                if (!string.IsNullOrEmpty(selectedImagePath))
                {
                    query += ", Resim = @Resim";
                }

                query += " WHERE Plaka = @Plaka";

                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Plaka", txtPlaka.Text);
                command.Parameters.AddWithValue("@Marka", txtMarka.Text);
                command.Parameters.AddWithValue("@Model", txtModel.Text);
                command.Parameters.AddWithValue("@Renk", txtRenk.Text);
                command.Parameters.AddWithValue("@Yil", txtYil.Text);
                command.Parameters.AddWithValue("@Kilometre", txtKilometre.Text);
                command.Parameters.AddWithValue("@Durum", txtDurum.Text);
                command.Parameters.AddWithValue("@SonBakimTarihi", dtpSonBakimTarihi.Value);
                command.Parameters.AddWithValue("@SonVergiTarihi", dtpSonVergiTarihi.Value);
                command.Parameters.AddWithValue("@SonSigortaTarihi", dtpSonSigortaTarihi.Value);
                command.Parameters.AddWithValue("@YakitTipi", txtYakitTipi.Text);

                
                if (!string.IsNullOrEmpty(selectedImagePath))
                {
                    byte[] imageData = File.ReadAllBytes(selectedImagePath);
                    command.Parameters.AddWithValue("@Resim", imageData);
                }

                try
                {
                    connection.Open();
                    int result = command.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("Araç bilgileri başarıyla güncellendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Güncelleme yapılamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Araç Güncelleme Hatası: " + ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            
            DialogResult result = MessageBox.Show("Bu aracı silmek istediğinize emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    string query = "DELETE FROM Araçlar WHERE Plaka = @Plaka";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Plaka", txtPlaka.Text);

                    try
                    {
                        connection.Open();
                        int affectedRows = command.ExecuteNonQuery();
                        if (affectedRows > 0)
                        {
                            MessageBox.Show("Araç başarıyla silindi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close(); 
                        }
                        else
                        {
                            MessageBox.Show("Araç silinirken bir hata oluştu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Araç Silme Hatası:" + ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnResimSec_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Resim Dosyaları|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
                openFileDialog.Title = "Araç Resmi Seçin";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    selectedImagePath = openFileDialog.FileName;
                    pictureBoxArac.Image = Image.FromFile(selectedImagePath);
                    pictureBoxArac.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Resim seçilmedi", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void btnGeri_Click(object sender, EventArgs e)
        {
            araçbak arac = new araçbak();
            OpenFormWithFade(arac);
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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dtpSonBakimTarihi_ValueChanged(object sender, EventArgs e)
        {
        }

        private void dtpSonVergiTarihi_ValueChanged(object sender, EventArgs e)
        {
        }

        private void dtpSonSigortaTarihi_ValueChanged(object sender, EventArgs e)
        {
        }

        private void AracGuncelle_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
