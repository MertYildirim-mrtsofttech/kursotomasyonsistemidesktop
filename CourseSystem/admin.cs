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
    public partial class admin : Form
    {
        public admin()
        {
            InitializeComponent();
        }




        private void button1_Click(object sender, EventArgs e)
        {
            YukleniyorGoster();
            araçekle araç = new araçekle();
            OpenFormWithFade(araç);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            YukleniyorGoster();
            araçbak araç = new araçbak();
            OpenFormWithFade(araç);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            YukleniyorGoster();
            AracYonetimi rand = new AracYonetimi();
            OpenFormWithFade(rand);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            YukleniyorGoster();
            usernamepassword usernamepassword = new usernamepassword();
            OpenFormWithFade(usernamepassword);
        }

        private void admin_Load(object sender, EventArgs e)
        {


        }


        private void groupBox1_Enter(object sender, EventArgs e)
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

        private void YukleniyorGosterExit()
        {

            Form yukleniyorForm = new Form();
            yukleniyorForm.Size = new Size(250, 100);
            yukleniyorForm.StartPosition = FormStartPosition.CenterScreen;
            yukleniyorForm.FormBorderStyle = FormBorderStyle.None;
            yukleniyorForm.BackColor = Color.White;
            yukleniyorForm.TopMost = true;

            Label lblYukleniyor = new Label();
            lblYukleniyor.Text = "Çıkış Yapılıyor...";
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

        private void button5_Click(object sender, EventArgs e)
        {
            adminlogin log = new adminlogin();
            OpenFormWithFade(log);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            YukleniyorGosterExit();
            adminlogin log = new adminlogin();
            System.Threading.Thread.Sleep(2000);
            OpenFormWithFade(log);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void admin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }
    }




}

