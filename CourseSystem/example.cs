using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mysqlx.Connection;
using MySql.Data.MySqlClient;

namespace CourseSystem
{
    public partial class example : Form
    {
        public example()
        {
            InitializeComponent();
        }

        string connectionString = "Server=servername;Database=dbname;User ID=username;Password=password;";


        private void button1_Click(object sender, EventArgs e)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try

                {
                    connection.Open();
                    MessageBox.Show("Bağlanıldı");
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "HATA");

                }
                connection.Close();

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {

                try
                {
                    connection.Open();
                    string command = "CREATE TABLE IF NOT EXISTS ogrenciler (id INT AUTO_INCREMENT PRIMARY KEY,name VARCHAR(255),surname VARCHAR(255));";

                    string command2 = "CREATE TABLE IF NOT EXISTS okul(id INT AUTO_INCREMENT PRIMARY KEY,name VARCHAR(255),city VARCHAR(255));";




                    using (MySqlCommand commandx = new MySqlCommand(command, connection))
                    {

                        commandx.ExecuteNonQuery();
                        MessageBox.Show("Ogrenci Tablosu Oluşturuldu.");
                    }

                    using (MySqlCommand commandy = new MySqlCommand(command2, connection))
                    {
                        commandy.ExecuteNonQuery();
                        MessageBox.Show("Okul Tablosu Oluşturuldu");
                    }

                }

                catch
                {
                    MessageBox.Show("HATA");
                }

                connection.Close();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM ogrenciler";
                string query2 = "SELECT * FROM okul";


                // Veri seti oluşturma
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // DataGridView'e veriyi bağlama
                    dataGridView1.DataSource = dataTable;
                }

                using (MySqlCommand command2 = new MySqlCommand(query2, connection))
                {
                    MySqlDataAdapter adapter = new MySqlDataAdapter(command2);
                    DataTable dataTable2 = new DataTable();
                    adapter.Fill(dataTable2);

                    // DataGridView'e veriyi bağlama
                    dataGridView2.DataSource = dataTable2;
                }
                connection.Close();
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {


            string query = @"INSERT INTO ogrenciler(id,name,surname) VALUES(@val1,@val2,@val3);";



            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    if (textBox1.Text == "" && textBox2.Text == "" && textBox3.Text == "")
                    {
                        MessageBox.Show("Hata Var");
                        textBox1.Focus();

                    }
                    else
                    {
                        using (MySqlCommand cmd = new MySqlCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("@val2", textBox1.Text);
                            cmd.Parameters.AddWithValue("@val3", textBox2.Text);
                            cmd.Parameters.AddWithValue("@val1", textBox3.Text);
                            cmd.ExecuteNonQuery();

                            MessageBox.Show("Eklendi");

                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Hata");
                }

                connection.Close();


            }





        }

        private void example_Load(object sender, EventArgs e)
        {

        }
    }
}
