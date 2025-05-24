using MySql.Data.MySqlClient;
using Mysqlx.Connection;
using System.Data;
using System.Data.Common;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace CourseSystem
{


    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }
        string connectionString = "Server=servername;Database=databasename;User ID=username;Password=password;";

        private void Form1_Load(object sender, EventArgs e)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    /*
                    string createtable = @"CREATE TABLE IF NOT EXISTS admin(username VARCHAR(255) NOT NULL,password VARCHAR(255) NOT NULL);";
                    string adddata = @"INSERT INTO admin(username,password) VALUES('admin','user123');";

                    using (MySqlCommand command = new MySqlCommand(createtable, connection))
                    {
                        command.ExecuteNonQuery();
                        MessageBox.Show("Tablo Oluþturuldu");
                    }

                    using (MySqlCommand command2=new MySqlCommand(adddata, connection))
                    {
                        command2.ExecuteNonQuery();
                        MessageBox.Show("Veri eklendi");
                    }
                    

                    string add = @"UPDATE admin SET password='123' WHERE username='admin';";

                    using(MySqlCommand command=new MySqlCommand(add,connection))
                    {
                        command.ExecuteNonQuery();
                        MessageBox.Show("Güncellendi");
                    }

                    string query = "SELECT *FROM admin";
                    MySqlDataAdapter adapter=new MySqlDataAdapter(query,connection);
                    DataTable data = new DataTable();
                    adapter.Fill(data);
                    dataGridView1.DataSource = data;

                    */
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Hata");
                }
            }

        }



        private void button1_Click(object sender, EventArgs e)
        {
            /*
            adminlogin adminlog = new adminlogin();
            adminlog.Show();
            this.Hide();
            */

            adminlogin adminlog = new adminlogin();
            OpenFormWithFade(adminlog);

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

        private void button3_Click(object sender, EventArgs e)
        {
            example ex = new example();
            ex.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            lesson les = new lesson();
            les.Show();
            this.Hide();
        }
    }
}