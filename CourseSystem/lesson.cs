using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;

namespace CourseSystem
{
    public partial class lesson : Form
    {
        public lesson()
        {
            InitializeComponent();
        }
        string connectionString = "Server=servername;Database=dbname;User ID=username;Password=password;";

        private void lesson_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Kumaş");
            comboBox1.Items.Add("Kot");
            comboBox1.Items.Add("İpek");

            comboBox2.Items.Add("Paça Dikimi");
            comboBox2.Items.Add("Fermuar Dikimi");
            comboBox2.Items.Add("Düğme Dikimi");




            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                //MessageBox.Show("Bağlanıldı.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            int rand = random.Next(1, 101);

            if (textBox1.Text.Length < 11 || textBox1.Text.Length > 11)
            {
                MessageBox.Show("TC No düzgün formatta değil");
            }
            else
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {

                    string tc = textBox1.Text;
                    string name = textBox2.Text;
                    string surname = textBox3.Text;
                    string type = comboBox1.SelectedItem.ToString();
                    string process = comboBox2.SelectedItem.ToString();
                    MessageBox.Show(process, type);
                    conn.Open();
                    string table = "CREATE TABLE IF NOT EXISTS islemler(ad VARCHAR(255),soyad VARCHAR(255),tc VARCHAR(255),islem VARCHAR(255),tur VARCHAR(255));";
                    string query = "SELECT * FROM islemler";
                    using (MySqlCommand cmd = new MySqlCommand(table, conn))
                    {
                        cmd.ExecuteNonQuery();
                        //MessageBox.Show("Tablo Oluşturuldu.");

                        MySqlDataAdapter adp = new MySqlDataAdapter(query, conn);
                        DataTable table1 = new DataTable();
                        adp.Fill(table1);
                        dataGridView1.DataSource = table1;



                    }

                    string add = "INSERT INTO islemler(tc,ad,soyad,islem,tur) VALUES(@tc,@ad,@soyad,@islem,@tur)";
                    using (MySqlCommand command = new MySqlCommand(add, conn))
                    {
                        command.Parameters.AddWithValue("@tc", tc);
                        command.Parameters.AddWithValue("@ad", name);
                        command.Parameters.AddWithValue("@soyad", surname);
                        command.Parameters.AddWithValue("@islem", process);
                        command.Parameters.AddWithValue("@tur", type);
                        command.ExecuteNonQuery();

                        MessageBox.Show($"{rand.ToString()} numaralı isleminiz eklendi.");

                    }
                }



            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            Random random = new Random();
            int rand = random.Next(1, 101);

            string ad = textBox4.Text;
            int adet = Convert.ToInt32(textBox5.Text);
            int fiyat = Convert.ToInt32(textBox6.Text);


            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string query = "CREATE TABLE IF NOT EXISTS duzenleyen(ad VARCHAR(255),vertar DATETIME,altar DATETIME,adet INT,fiyat INT);";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.ExecuteNonQuery();
                }

                string add = "INSERT INTO duzenleyen(ad,vertar,altar,adet,fiyat) VALUES(@ad,@vertar,@altar,@adet,@fiyat)";


                using (MySqlCommand command = new MySqlCommand(add, conn))
                {
                    command.Parameters.AddWithValue("@ad", ad);
                    command.Parameters.AddWithValue("@vertar", dateTimePicker1.Value);
                    command.Parameters.AddWithValue("@altar", dateTimePicker2.Value);
                    command.Parameters.AddWithValue("@adet", adet.ToString());
                    command.Parameters.AddWithValue("@fiyat", fiyat.ToString());

                    command.ExecuteNonQuery();
                    MessageBox.Show($"{rand.ToString()} numaralı işleminiz eklendi");

                }
                string table = "SELECT *FROM duzenleyen";
                using (MySqlCommand tablecmd = new MySqlCommand(table, conn))
                {
                    MySqlDataAdapter adp = new MySqlDataAdapter(table, conn);
                    DataTable table2 = new DataTable();
                    adp.Fill(table2);
                    dataGridView2.DataSource = table2;

                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(comboBox2.SelectedItem);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Remove(listBox1.SelectedItem);
        }

        private void button5_Click(object sender, EventArgs e)
        {

            try
            {
                string query = "DELETE FROM islemler";
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.ExecuteNonQuery();



                        string table = "SELECT *FROM islemler";
                        MySqlDataAdapter adp = new MySqlDataAdapter(query, conn);
                        DataTable table1 = new DataTable();
                        adp.Fill(table1);
                        dataGridView1.DataSource = table1;
                    }
                }

                string query2 = "DELETE FROM duzenleyen";

                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand(query2, conn))
                    {
                        cmd.ExecuteNonQuery();

                        string table = "SELECT *FROM duzenleyen";
                        MySqlDataAdapter adp = new MySqlDataAdapter(table, conn);
                        DataTable table2 = new DataTable();
                        adp.Fill(table2);
                        dataGridView2.DataSource = table2;
                    }
                }

                MessageBox.Show("Tablolar temizlendi.");
            }

            catch (Exception ex)
            {
                MessageBox.Show("Tablolar temizlenmedi.");
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string table = "SELECT *FROM islemler";
                MySqlDataAdapter adp = new MySqlDataAdapter(table, conn);
                DataTable table1 = new DataTable();
                adp.Fill(table1);
                dataGridView1.DataSource = table1;

            }

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string table = "SELECT *FROM duzenleyen";
                MySqlDataAdapter adp = new MySqlDataAdapter(table, conn);
                DataTable table2 = new DataTable();
                adp.Fill(table2);
                dataGridView2.DataSource = table2;

            }

            MessageBox.Show("Tablolar Getirildi.");

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.Items.Add(comboBox2.SelectedItem.ToString());
        }
    }
}
