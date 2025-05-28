using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseSystem
{
    public partial class araçbak : Form
    {
        public araçbak()
        {
            InitializeComponent();

        }
        
        
        

        public static class ConnectionInformation
        {
            public static string connectionString = "Server=servername;Database=dbname;User ID=username;Password=password;";
        }

        private void araçbak_Load(object sender, EventArgs e)
        {
            /*
            

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {

                string query = "SELECT * FROM Araçlar";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dataGridView1.DataSource = table;
                }

            }
            */
           


            SetupFlowLayoutPanel();

            
            LoadAllCars();

        }

       

        private void LoadAllCars()
        {

            
            flowLayoutPanel1.Dock = DockStyle.Fill; 
            flowLayoutPanel1.FlowDirection = FlowDirection.LeftToRight;
            flowLayoutPanel1.WrapContents = true;
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Padding = new Padding(10, 150, 10, 10);

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                
                string query = "SELECT Plaka, Marka, Model, Renk, Yil, Kilometre, Durum, SonBakimTarihi, SonVergiTarihi, SonSigortaTarihi, YakitTipi, Resim FROM Araçlar";
                MySqlCommand command = new MySqlCommand(query, connection);

                try
                {
                    connection.Open();
                    MySqlDataReader reader = command.ExecuteReader();

                    

                    while (reader.Read())
                    {
                        
                        Panel carPanel = new Panel
                        {
                            Width = 280, 
                            Height = 500, 
                            BorderStyle = BorderStyle.FixedSingle,
                            Margin = new Padding(10), 
                            BackColor = Color.White
                        };

                        
                        carPanel.Tag = reader["Plaka"].ToString();

                        
                        carPanel.Cursor = Cursors.Hand;
                        carPanel.Click += CarPanel_Click;

                        
                        Label titleLabel = new Label
                        {
                            Text = $"{reader["Marka"]} {reader["Model"]} ({reader["Yil"]})",
                            Font = new Font("Segoe UI", 12, FontStyle.Bold),
                            ForeColor = Color.FromArgb(0, 100, 180),
                            TextAlign = ContentAlignment.MiddleCenter,
                            Dock = DockStyle.Top,
                            Height = 30
                        };
                        titleLabel.Click += (s, e) => CarPanel_Click(carPanel, e); 
                        carPanel.Controls.Add(titleLabel);

                       
                        if (reader["Resim"] != DBNull.Value)
                        {
                            try
                            {
                                byte[] imageData = (byte[])reader["Resim"];
                                using (var ms = new MemoryStream(imageData))
                                {
                                    PictureBox pictureBox = new PictureBox
                                    {
                                        Image = Image.FromStream(ms),
                                        SizeMode = PictureBoxSizeMode.Zoom,
                                        Width = 260,
                                        Height = 150,
                                        Location = new Point(10, 40),
                                        BorderStyle = BorderStyle.FixedSingle
                                    };
                                    pictureBox.Click += (s, e) => CarPanel_Click(carPanel, e); 
                                    carPanel.Controls.Add(pictureBox);
                                }
                            }
                            catch
                            {
                                
                                PictureBox pictureBox = new PictureBox
                                {
                                    Width = 260,
                                    Height = 150,
                                    Location = new Point(10, 40),
                                    BorderStyle = BorderStyle.FixedSingle,
                                    BackColor = Color.LightGray
                                };
                                pictureBox.Click += (s, e) => CarPanel_Click(carPanel, e); 
                                carPanel.Controls.Add(pictureBox);
                            }
                        }

                       
                        Label plakaLabel = new Label
                        {
                            Text = reader["Plaka"].ToString(),
                            Font = new Font("Segoe UI", 12, FontStyle.Bold),
                            TextAlign = ContentAlignment.MiddleCenter,
                            BackColor = Color.FromArgb(240, 240, 240),
                            Location = new Point(10, 200),
                            Size = new Size(260, 30)
                        };
                        plakaLabel.Click += (s, e) => CarPanel_Click(carPanel, e); 
                        carPanel.Controls.Add(plakaLabel);

                        
                        Panel infoPanel = new Panel
                        {
                            Location = new Point(10, 240),
                            Size = new Size(300, 220),
                            BorderStyle = BorderStyle.None
                        };
                        infoPanel.Click += (s, e) => CarPanel_Click(carPanel, e); 
                        carPanel.Controls.Add(infoPanel);

                        
                        string[] fields = { "Renk", "Kilometre", "Durum", "Yakıt Tipi", "Son Bakım", "Son Sigorta", "Son Vergi" };
                        string[] values = {
                    reader["Renk"].ToString(),
                    reader["Kilometre"].ToString() + " km",
                    reader["Durum"].ToString(),
                    reader["YakitTipi"].ToString(),
                    FormatDate(reader["SonBakimTarihi"]),
                    FormatDate(reader["SonSigortaTarihi"]),
                    FormatDate(reader["SonVergiTarihi"])
                };

                        for (int i = 0; i < fields.Length; i++)
                        {
                            Label fieldLabel = new Label
                            {
                                Text = fields[i] + ":",
                                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                                Location = new Point(0, i * 28),
                                Size = new Size(100, 20)
                            };
                            fieldLabel.Click += (s, e) => CarPanel_Click(carPanel, e); 

                            Label valueLabel = new Label
                            {
                                Text = values[i],
                                Font = new Font("Segoe UI", 9, FontStyle.Regular),
                                Location = new Point(100, i * 28),
                                Size = new Size(160, 20)
                            };
                            valueLabel.Click += (s, e) => CarPanel_Click(carPanel, e); 

                            infoPanel.Controls.Add(fieldLabel);
                            infoPanel.Controls.Add(valueLabel);
                        }

                        DateTime sonBakimTarihi;
                        if (DateTime.TryParse(reader["SonBakimTarihi"].ToString(), out sonBakimTarihi))
                        {
                            if ((DateTime.Now - sonBakimTarihi).TotalDays > 365)
                            {
                                
                                NotifyMaintenance(reader["Plaka"].ToString());
                            }
                        }

                        DateTime sonVergiTarihi;
                        if (DateTime.TryParse(reader["SonVergiTarihi"].ToString(), out sonVergiTarihi))
                        {
                            if ((DateTime.Now - sonVergiTarihi).TotalDays > 180)
                            {
                                
                                NotifyMaintenanceVergi(reader["Plaka"].ToString());
                            }
                        }

                        DateTime sonSigortaTarihi;
                        if (DateTime.TryParse(reader["SonSigortaTarihi"].ToString(), out sonSigortaTarihi))
                        {
                            if ((DateTime.Now - sonSigortaTarihi).TotalDays > 365)
                            {
                                
                                NotifyMaintenanceSigorta(reader["Plaka"].ToString());
                            }
                        }

                        
                        flowLayoutPanel1.Controls.Add(carPanel);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Bir hata oluştu: " + ex.Message);
                }
            }
        }

        
        private string FormatDate(object dateObj)
        {
            if (dateObj == DBNull.Value)
                return "Belirtilmedi";

            try
            {
                DateTime date = Convert.ToDateTime(dateObj);
                return date.ToString("dd.MM.yyyy");

            }
            catch
            {
                return "Geçersiz Tarih";
            }
        }

        private void NotifyMaintenance(string plaka)
        {
            NotifyIcon notifyIcon = new NotifyIcon
            {
                Icon = SystemIcons.Warning,
                Visible = true,
                BalloonTipTitle = "Bakım Uyarısı",
                BalloonTipText = $"Araç {plaka}: Bakım yapılması gerekiyor!",
                BalloonTipIcon = ToolTipIcon.Warning
            };

            notifyIcon.ShowBalloonTip(3000); 

            
            Task.Delay(5000).ContinueWith(t => notifyIcon.Dispose());
        }

        private void NotifyMaintenanceVergi(string plaka)
        {
            NotifyIcon notifyIcon = new NotifyIcon
            {
                Icon = SystemIcons.Warning,
                Visible = true,
                BalloonTipTitle = "Vergi Uyarısı",
                BalloonTipText = $"Araç {plaka}: Vergi ödenmesi gerekiyor!",
                BalloonTipIcon = ToolTipIcon.Warning
            };

            notifyIcon.ShowBalloonTip(3000); 

            
            Task.Delay(5000).ContinueWith(t => notifyIcon.Dispose());
        }

        private void NotifyMaintenanceSigorta(string plaka)
        {
            NotifyIcon notifyIcon = new NotifyIcon
            {
                Icon = SystemIcons.Warning,
                Visible = true,
                BalloonTipTitle = "Sigorta Uyarısı",
                BalloonTipText = $"Araç {plaka}: Sigorta yapılması gerekiyor!",
                BalloonTipIcon = ToolTipIcon.Warning
            };

            notifyIcon.ShowBalloonTip(3000); 

            
            Task.Delay(5000).ContinueWith(t => notifyIcon.Dispose());
        }

        
        private void SetupFlowLayoutPanel()
        {
            
            flowLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanel1.AutoSize = false;

           

            //flowLayoutPanel1.BringToFront();
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

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
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



        private void button1_Click(object sender, EventArgs e)
        {
            YukleniyorGoster();
            admin admin = new admin();
            OpenFormWithFade(admin);
        }

        private void CarPanel_Click(object sender, EventArgs e)
        {
            try
            {
                YukleniyorGoster();
                Panel clickedPanel = sender as Panel;
                if (clickedPanel != null && clickedPanel.Tag != null)
                {
                    string plaka = clickedPanel.Tag.ToString();

                    
                    AracGuncelle aracGuncelleForm = new AracGuncelle(plaka, connectionString);
                    aracGuncelleForm.FormClosed += (s, args) =>
                    {
                        this.Show();
                        
                        flowLayoutPanel1.Controls.Clear();
                        LoadAllCars();
                    };
                    OpenFormWithFade(aracGuncelleForm);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veri Hatası", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void araçbak_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
