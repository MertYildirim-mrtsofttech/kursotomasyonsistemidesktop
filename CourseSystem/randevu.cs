using MySql.Data.MySqlClient;
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
using static CourseSystem.araçbak;

namespace CourseSystem
{


    public partial class randevu : Form
    {
        private System.Windows.Forms.Timer timer;

        [DllImport("gdi32.dll")]
        private static extern IntPtr CreateRoundRectRgn(int x1, int y1, int x2, int y2, int cx, int cy);


        string connectionString = ConnectionInformation.connectionString;

        private string aracPlaka;

        public randevu(string plaka)
        {
            InitializeComponent();
            aracPlaka = plaka;
            this.Text = $"OTOPLAN/{plaka} Plakalı Araç - Randevu Yönetimi";
            // RandevulariListele();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            CheckAndCleanOldReservations();
        }



        private void RandevularıGetir()
        {
            try
            {

                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM Randevular";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                        DataTable table = new DataTable();
                        adp.Fill(table);
                        dataGridRandevular.DataSource = table;
                    }


                    dataGridRandevular.EnableHeadersVisualStyles = false;
                    dataGridRandevular.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 13, FontStyle.Bold);
                    dataGridRandevular.ColumnHeadersDefaultCellStyle.ForeColor = Color.Red;
                    dataGridRandevular.DefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);

                    foreach (DataGridViewColumn column1 in dataGridRandevular.Columns)
                    {
                        column1.Width = 185;
                    }

                    conn.Close();



                }

            }

            catch
            {
                MessageBox.Show("Hata");
            }
        }


        private void AddAppointment()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM Randevular";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                        DataTable table = new DataTable();
                        adp.Fill(table);
                        dataGridView1.DataSource = table;

                    }

                    dataGridView1.EnableHeadersVisualStyles = false;
                    dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 13, FontStyle.Bold);
                    dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Red;
                    dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);

                    foreach (DataGridViewColumn column in dataGridView1.Columns)
                    {
                        column.Width = 185;
                    }
                }

                //dataGridView1.Columns["RandevuTarihi"].Width = 200;
            }

            catch (Exception ex)
            {
                MessageBox.Show("Randevu Ekleme Hatası", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnRandevuSil_Click(object sender, EventArgs e)
        {

        }

        private void KontrolEtVeAracDurumuGuncelle()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();


                    string query = @"SELECT Durum FROM Randevular 
                                   WHERE AracPlaka = @AracPlaka 
                                   ORDER BY RandevuTarihi DESC LIMIT 1";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@AracPlaka", aracPlaka);
                        object result = cmd.ExecuteScalar();

                        if (result != null)
                        {

                            AracDurumuGuncelle(result.ToString());
                        }
                        else
                        {

                            AracDurumuGuncelle("Müsait");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Araç durumu güncellenirken hata: {ex.Message}", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AracDurumuGuncelle(string durum)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string updateQuery = "UPDATE Araçlar SET Durum = @Durum WHERE Plaka = @Plaka";

                    using (MySqlCommand cmd = new MySqlCommand(updateQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@Durum", durum);
                        cmd.Parameters.AddWithValue("@Plaka", aracPlaka);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Araç durumu güncellenirken hata: {ex.Message}", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridRandevular_SelectionChanged(object sender, EventArgs e)
        {

            if (dataGridRandevular.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridRandevular.SelectedRows[0];


                if (row.Cells["RandevuTarihi"].Value != null)
                {
                    dateTimeRandevu.Value = DateTime.Parse(row.Cells["RandevuTarihi"].Value.ToString());
                }


                /*if (row.Cells["Durum"].Value != null)
                {
                    string durum = row.Cells["Durum"].Value.ToString();
                    int index = cmbDurum.Items.IndexOf(durum);
                    if (index != -1)
                        cmbDurum.SelectedIndex = index;
                }
                */



            }
        }


        private void SelectComboBoxItemByText(ComboBox comboBox, string text)
        {
            if (string.IsNullOrEmpty(text)) return;

            for (int i = 0; i < comboBox.Items.Count; i++)
            {
                KeyValuePair<string, string> item = (KeyValuePair<string, string>)comboBox.Items[i];
                if (item.Value == text)
                {
                    comboBox.SelectedIndex = i;
                    break;
                }
            }
        }

        private void btnRandevuEkle_Click_1(object sender, EventArgs e)
        {

            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Gerekli Alanları Doldurunuz.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else
            {

                try
                {
                    //MessageBox.Show(cmbDurum.ToString());
                    //MessageBox.Show(dateTimeRandevu.ToString());


                    /*if (cmbDurum.SelectedIndex == -1 || dateTimeRandevu.Value == null)
                    {
                        MessageBox.Show("Lütfen durum ve randevu tarihini seçiniz!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    */

                    string ogrenciID = textBox1.Text;
                    string egitmenID = textBox2.Text;





                    using (MySqlConnection conn = new MySqlConnection(connectionString))
                    {
                        conn.Open();


                        string kontrolQuery = @"SELECT COUNT(*) FROM Randevular 
                                          WHERE AracPlaka = @AracPlaka 
                                          AND RandevuTarihi = @RandevuTarihi";

                        using (MySqlCommand kontrolCmd = new MySqlCommand(kontrolQuery, conn))
                        {
                            kontrolCmd.Parameters.AddWithValue("@AracPlaka", aracPlaka);
                            kontrolCmd.Parameters.AddWithValue("@RandevuTarihi", dateTimeRandevu.Value);

                            int cakisma = Convert.ToInt32(kontrolCmd.ExecuteScalar());
                            if (cakisma > 0)
                            {
                                MessageBox.Show("Bu tarih ve saatte başka bir randevu bulunmaktadır!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }

                        string insertQuery = @"INSERT INTO Randevular (AracPlaka, RandevuTarihi, Durum, OgrenciAdi, EgitmenAdi) 
                                      VALUES (@AracPlaka, @RandevuTarihi, @Durum, @OgrenciAdi, @EgitmenAdi)";

                        using (MySqlCommand cmd = new MySqlCommand(insertQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@AracPlaka", aracPlaka);
                            cmd.Parameters.AddWithValue("@RandevuTarihi", dateTimeRandevu.Value);
                            //cmd.Parameters.AddWithValue("@Durum", cmbDurum.SelectedItem.ToString());
                            cmd.Parameters.AddWithValue("@Durum", randevuNot.Text);
                            cmd.Parameters.AddWithValue("@OgrenciAdi", ogrenciID.ToString());
                            cmd.Parameters.AddWithValue("EgitmenAdi", egitmenID.ToString());




                            int result = cmd.ExecuteNonQuery();

                            if (result > 0)
                            {
                                RandevuEkleniyorGoster();
                                MessageBox.Show("Randevu başarıyla eklendi.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                AddAppointment();
                                RandevularıGetir();
                                textBox1.Clear();
                                textBox2.Clear();
                                randevuNot.Clear();
                                dateTimeRandevu.Value = DateTime.Now;


                                //AracDurumuGuncelle(cmbDurum.SelectedItem.ToString());
                            }
                            else
                            {
                                MessageBox.Show("Randevu eklenirken hata oluştu.Zorunlu Yerleri Doldurunuz.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Randevu eklenirken hata: {ex.Message}.Zorunlu Alanları Doldurunuz.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void cmbDurum_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void randevu_Load_1(object sender, EventArgs e)
        {

            CheckAndCleanOldReservations();
            AddAppointment();

            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Multiline = true;
            textBox1.Size = new Size(250, 30);
            textBox1.Padding = new Padding(15, 15, 15, 15);
            textBox1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, textBox1.Width, textBox1.Height, 20, 20));



            textBox2.BorderStyle = BorderStyle.None;
            textBox2.Multiline = true;
            textBox2.Size = new Size(250, 30);
            textBox2.Padding = new Padding(15, 15, 15, 15);
            textBox2.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, textBox2.Width, textBox2.Height, 20, 20));


            randevuNot.BorderStyle = BorderStyle.None;
            randevuNot.Multiline = true;
            randevuNot.Size = new Size(250, 30);
            randevuNot.Padding = new Padding(15, 15, 15, 15);
            randevuNot.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, randevuNot.Width, randevuNot.Height, 20, 20));





            /*if (DateTime.Now.Hour == 17 && DateTime.Now.Minute == 00)
            {
                try
                {
                    using (MySqlConnection conn = new MySqlConnection(connectionString))
                    {
                        conn.Open();
                        string deleteQuery = "DELETE FROM Randevular";


                        using (MySqlCommand cmd = new MySqlCommand(deleteQuery, conn))
                        {
                            int result = cmd.ExecuteNonQuery();

                            if (result > 0)
                            {
                                MessageBox.Show("Günün randevuları temizlendi.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                
                                string idQuery = "ALTER TABLE Randevular AUTO_INCREMENT=1";
                                using (MySqlCommand idreset = new MySqlCommand(idQuery, conn))
                                {
                                    idreset.ExecuteNonQuery();
                                }
                                
                                string updateQuery = "UPDATE Araçlar SET Durum = 'Müsait'";
                                using (MySqlCommand updateCmd = new MySqlCommand(updateQuery, conn))
                                {
                                    updateCmd.ExecuteNonQuery();
                                }

                                
                                RandevularıGetir();
                                MessageBox.Show("Silindi");
                            }
                        }
                        conn.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Randevular temizlenirken hata: {ex.Message}", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            */



            //cmbDurum.Items.AddRange(new string[] { "Müsait", "Randevulu", "Bakımda" });
            RandevularıGetir();



            // DateTimePicker formatını ayarla
            dateTimeRandevu.Format = DateTimePickerFormat.Custom;
            dateTimeRandevu.CustomFormat = "dd.MM.yyyy HH:mm";
            dateTimeRandevu.ShowUpDown = true;

            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            /*timer.Interval = 60000;
            timer.Tick += (s, evt) =>
            {

            };
            timer.Start();
            */
            timer.Interval = 60000;
            timer.Tick += timer1_Tick;
            timer.Start();
        }




        private void cmbOgrenci_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridRandevular_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnRandevuSil_Click_1(object sender, EventArgs e)
        {
            try
            {

                if (dataGridRandevular.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Lütfen silinecek randevuyu seçiniz!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string randevuID = dataGridRandevular.SelectedRows[0].Cells["RandevuID"].Value.ToString();


                DialogResult dr = MessageBox.Show("Seçili randevuyu silmek istediğinize emin misiniz?", "SİLME ONAYI", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dr == DialogResult.Yes)
                {
                    using (MySqlConnection conn = new MySqlConnection(connectionString))
                    {
                        conn.Open();
                        string deleteQuery = "DELETE FROM Randevular WHERE RandevuID = @RandevuID";

                        using (MySqlCommand cmd = new MySqlCommand(deleteQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@RandevuID", randevuID);

                            int result = cmd.ExecuteNonQuery();

                            if (result > 0)
                            {
                                RandevuSiliniyorGoster();
                                MessageBox.Show("Randevu başarıyla silindi.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                RandevularıGetir();
                                AddAppointment();


                                KontrolEtVeAracDurumuGuncelle();
                            }
                            else
                            {
                                MessageBox.Show("Randevu silinirken hata oluştu.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Randevu silinirken hata: {ex.Message}", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRandevuGuncelle_Click_1(object sender, EventArgs e)
        {
            try
            {

                if (dataGridRandevular.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Lütfen güncellenecek randevuyu seçiniz!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                DataGridViewRow selectedRow = dataGridRandevular.SelectedRows[0];


                string randevuID = selectedRow.Cells["RandevuID"].Value?.ToString();
                DateTime randevuTarihi = Convert.ToDateTime(selectedRow.Cells["RandevuTarihi"].Value);
                string durum = selectedRow.Cells["Durum"].Value?.ToString();


                string ogrenciID = selectedRow.Cells["OgrenciAdi"].Value?.ToString();
                string egitmenID = selectedRow.Cells["EgitmenAdi"].Value?.ToString();


                if (string.IsNullOrEmpty(randevuID))
                {
                    MessageBox.Show("Randevu ID'si alınamadı!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();


                    string kontrolQuery = @"SELECT COUNT(*) FROM Randevular 
                                    WHERE AracPlaka = @AracPlaka 
                                    AND RandevuTarihi = @RandevuTarihi
                                    AND RandevuID != @RandevuID";

                    using (MySqlCommand kontrolCmd = new MySqlCommand(kontrolQuery, conn))
                    {
                        kontrolCmd.Parameters.AddWithValue("@AracPlaka", aracPlaka);
                        kontrolCmd.Parameters.AddWithValue("@RandevuTarihi", randevuTarihi);
                        kontrolCmd.Parameters.AddWithValue("@RandevuID", randevuID);

                        int cakisma = Convert.ToInt32(kontrolCmd.ExecuteScalar());
                        if (cakisma > 0)
                        {
                            MessageBox.Show("Bu tarih ve saatte başka bir randevu bulunmaktadır!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }


                    string updateQuery = @"UPDATE Randevular 
                                   SET RandevuTarihi = @RandevuTarihi, 
                                       Durum = @Durum, 
                                       OgrenciAdi = @OgrenciAdi, 
                                       EgitmenAdi = @EgitmenAdi
                                   WHERE RandevuID = @RandevuID";

                    using (MySqlCommand cmd = new MySqlCommand(updateQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@RandevuID", randevuID);
                        cmd.Parameters.AddWithValue("@RandevuTarihi", randevuTarihi);
                        cmd.Parameters.AddWithValue("@Durum", durum);


                        cmd.Parameters.AddWithValue("@OgrenciAdi", string.IsNullOrEmpty(ogrenciID) ? DBNull.Value : (object)ogrenciID);
                        cmd.Parameters.AddWithValue("@EgitmenAdi", string.IsNullOrEmpty(egitmenID) ? DBNull.Value : (object)egitmenID);

                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            RandevuGuncelleniyorGoster();
                            MessageBox.Show("Randevu başarıyla güncellendi.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            RandevularıGetir();
                            AddAppointment();
                        }
                        else
                        {
                            MessageBox.Show("Randevu güncellenirken hata oluştu.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Randevu güncellenirken hata: {ex.Message}", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void CheckAndCleanOldReservations()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();


                    string checkQuery = "SELECT MAX(LastCleanup) FROM SystemSettings";
                    DateTime lastCleanup = DateTime.MinValue;

                    using (MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn))
                    {
                        var result = checkCmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            lastCleanup = Convert.ToDateTime(result);
                        }
                    }


                    DateTime localNow = DateTime.Now;
                    bool isAfter5PM = localNow.Hour >= 17;
                    bool cleanupNotDoneToday = lastCleanup.Date < localNow.Date;


                    if (cleanupNotDoneToday && isAfter5PM)
                    {

                        MessageBox.Show("Günlük randevu temizleme işlemi başlatılıyor.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);


                        string deleteQuery = "DELETE FROM Randevular";
                        using (MySqlCommand cmd = new MySqlCommand(deleteQuery, conn))
                        {
                            int result = cmd.ExecuteNonQuery();
                            Console.WriteLine($"{result} adet randevu silindi.");
                        }


                        string idQuery = "ALTER TABLE Randevular AUTO_INCREMENT=1";
                        using (MySqlCommand idreset = new MySqlCommand(idQuery, conn))
                        {
                            idreset.ExecuteNonQuery();
                        }


                        string updateQuery = "UPDATE Araçlar SET Durum = 'Müsait'";
                        using (MySqlCommand updateCmd = new MySqlCommand(updateQuery, conn))
                        {
                            updateCmd.ExecuteNonQuery();
                        }


                        string updateTimeQuery = "UPDATE SystemSettings SET LastCleanup = @now";
                        using (MySqlCommand updateTimeCmd = new MySqlCommand(updateTimeQuery, conn))
                        {
                            updateTimeCmd.Parameters.AddWithValue("@now", localNow);
                            updateTimeCmd.ExecuteNonQuery();
                        }

                        MessageBox.Show("Randevu temizleme tamamlandı.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        RandevularıGetir();
                    }

                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Kontrol sırasında hata: {ex.Message}", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
            AddAppointment();
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
            YukleniyorGoster();
            admin admin = new admin();
            OpenFormWithFade(admin);
        }

        private void randevu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void RandevuEkleniyorGoster()
        {

            Form yukleniyorForm = new Form();
            yukleniyorForm.Size = new Size(250, 100);
            yukleniyorForm.StartPosition = FormStartPosition.CenterScreen;
            yukleniyorForm.FormBorderStyle = FormBorderStyle.None;
            yukleniyorForm.BackColor = Color.White;
            yukleniyorForm.TopMost = true;

            Label lblYukleniyor = new Label();
            lblYukleniyor.Text = "Randevu Ekleniyor...";
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

        private void RandevuSiliniyorGoster()
        {

            Form yukleniyorForm = new Form();
            yukleniyorForm.Size = new Size(250, 100);
            yukleniyorForm.StartPosition = FormStartPosition.CenterScreen;
            yukleniyorForm.FormBorderStyle = FormBorderStyle.None;
            yukleniyorForm.BackColor = Color.White;
            yukleniyorForm.TopMost = true;

            Label lblYukleniyor = new Label();
            lblYukleniyor.Text = "Randevu Siliniyor...";
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

        private void RandevuGuncelleniyorGoster()
        {

            Form yukleniyorForm = new Form();
            yukleniyorForm.Size = new Size(250, 100);
            yukleniyorForm.StartPosition = FormStartPosition.CenterScreen;
            yukleniyorForm.FormBorderStyle = FormBorderStyle.None;
            yukleniyorForm.BackColor = Color.White;
            yukleniyorForm.TopMost = true;

            Label lblYukleniyor = new Label();
            lblYukleniyor.Text = "Randevu Güncelleniyor...";
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

