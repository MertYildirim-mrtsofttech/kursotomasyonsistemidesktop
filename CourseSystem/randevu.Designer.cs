namespace CourseSystem
{
    partial class randevu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(randevu));
            dataGridRandevular = new DataGridView();
            dateTimeRandevu = new DateTimePicker();
            btnRandevuEkle = new Button();
            btnRandevuGuncelle = new Button();
            btnRandevuSil = new Button();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            randevuNot = new TextBox();
            label5 = new Label();
            panel1 = new Panel();
            label4 = new Label();
            groupBox1 = new GroupBox();
            label6 = new Label();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            button1 = new Button();
            label7 = new Label();
            dataGridView1 = new DataGridView();
            tabPage3 = new TabPage();
            button2 = new Button();
            label8 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridRandevular).BeginInit();
            panel1.SuspendLayout();
            groupBox1.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            tabPage3.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridRandevular
            // 
            dataGridRandevular.BackgroundColor = SystemColors.Window;
            dataGridRandevular.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridRandevular.Location = new Point(379, 75);
            dataGridRandevular.Name = "dataGridRandevular";
            dataGridRandevular.RowHeadersWidth = 51;
            dataGridRandevular.RowTemplate.Height = 29;
            dataGridRandevular.Size = new Size(1166, 646);
            dataGridRandevular.TabIndex = 0;
            dataGridRandevular.CellContentClick += dataGridRandevular_CellContentClick;
            // 
            // dateTimeRandevu
            // 
            dateTimeRandevu.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            dateTimeRandevu.Location = new Point(114, 373);
            dateTimeRandevu.Name = "dateTimeRandevu";
            dateTimeRandevu.Size = new Size(250, 30);
            dateTimeRandevu.TabIndex = 1;
            // 
            // btnRandevuEkle
            // 
            btnRandevuEkle.BackColor = SystemColors.MenuHighlight;
            btnRandevuEkle.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnRandevuEkle.ForeColor = SystemColors.Window;
            btnRandevuEkle.Location = new Point(146, 470);
            btnRandevuEkle.Name = "btnRandevuEkle";
            btnRandevuEkle.Size = new Size(181, 44);
            btnRandevuEkle.TabIndex = 5;
            btnRandevuEkle.Text = "RANDEVU EKLE";
            btnRandevuEkle.UseVisualStyleBackColor = false;
            btnRandevuEkle.Click += btnRandevuEkle_Click_1;
            // 
            // btnRandevuGuncelle
            // 
            btnRandevuGuncelle.BackColor = SystemColors.MenuHighlight;
            btnRandevuGuncelle.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnRandevuGuncelle.ForeColor = SystemColors.Window;
            btnRandevuGuncelle.Location = new Point(707, 756);
            btnRandevuGuncelle.Name = "btnRandevuGuncelle";
            btnRandevuGuncelle.RightToLeft = RightToLeft.No;
            btnRandevuGuncelle.Size = new Size(244, 46);
            btnRandevuGuncelle.TabIndex = 6;
            btnRandevuGuncelle.Text = "RANDEVU GÜNCELLE";
            btnRandevuGuncelle.UseVisualStyleBackColor = false;
            btnRandevuGuncelle.Click += btnRandevuGuncelle_Click_1;
            // 
            // btnRandevuSil
            // 
            btnRandevuSil.BackColor = SystemColors.MenuHighlight;
            btnRandevuSil.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnRandevuSil.ForeColor = SystemColors.Window;
            btnRandevuSil.Location = new Point(1031, 756);
            btnRandevuSil.Name = "btnRandevuSil";
            btnRandevuSil.RightToLeft = RightToLeft.No;
            btnRandevuSil.Size = new Size(172, 46);
            btnRandevuSil.TabIndex = 7;
            btnRandevuSil.Text = "RANDEVU SİL";
            btnRandevuSil.UseVisualStyleBackColor = false;
            btnRandevuSil.Click += btnRandevuSil_Click_1;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            textBox1.Location = new Point(114, 173);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(250, 30);
            textBox1.TabIndex = 14;
            textBox1.TextAlign = HorizontalAlignment.Center;
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            textBox2.Location = new Point(114, 244);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(250, 30);
            textBox2.TabIndex = 15;
            textBox2.TextAlign = HorizontalAlignment.Center;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.Desktop;
            label1.Location = new Point(148, 147);
            label1.Name = "label1";
            label1.Size = new Size(198, 23);
            label1.TabIndex = 16;
            label1.Text = "*Kursiyer Adı ve Soyadı";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = SystemColors.Desktop;
            label2.Location = new Point(146, 218);
            label2.Name = "label2";
            label2.Size = new Size(200, 23);
            label2.TabIndex = 17;
            label2.Text = "*Eğitmen Adı ve Soyadı";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = SystemColors.Desktop;
            label3.Location = new Point(215, 347);
            label3.Name = "label3";
            label3.Size = new Size(58, 23);
            label3.TabIndex = 18;
            label3.Text = "*Tarih";
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // randevuNot
            // 
            randevuNot.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            randevuNot.Location = new Point(114, 307);
            randevuNot.Name = "randevuNot";
            randevuNot.Size = new Size(250, 30);
            randevuNot.TabIndex = 20;
            randevuNot.TextAlign = HorizontalAlignment.Center;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            label5.ForeColor = SystemColors.Desktop;
            label5.Location = new Point(186, 281);
            label5.Name = "label5";
            label5.Size = new Size(124, 23);
            label5.TabIndex = 21;
            label5.Text = "Randevu Notu";
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Desktop;
            panel1.Controls.Add(label4);
            panel1.Location = new Point(0, 1);
            panel1.Name = "panel1";
            panel1.Size = new Size(1925, 125);
            panel1.TabIndex = 22;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Impact", 48F, FontStyle.Bold, GraphicsUnit.Point);
            label4.ForeColor = SystemColors.Window;
            label4.Location = new Point(646, 17);
            label4.Name = "label4";
            label4.Size = new Size(673, 98);
            label4.TabIndex = 0;
            label4.Text = "RANDEVU İŞLEMLERİ";
            // 
            // groupBox1
            // 
            groupBox1.BackColor = SystemColors.Control;
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(randevuNot);
            groupBox1.Controls.Add(btnRandevuEkle);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(dateTimeRandevu);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(textBox2);
            groupBox1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox1.Location = new Point(98, 109);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(492, 655);
            groupBox1.TabIndex = 23;
            groupBox1.TabStop = false;
            groupBox1.Text = "RANDEVU EKLE";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label6.ForeColor = SystemColors.Desktop;
            label6.Location = new Point(6, 592);
            label6.Name = "label6";
            label6.Size = new Size(136, 20);
            label6.TabIndex = 22;
            label6.Text = "*=Zorunlu Alanlar";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            tabControl1.Location = new Point(12, 132);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1900, 911);
            tabControl1.TabIndex = 25;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = SystemColors.Control;
            tabPage1.Controls.Add(button1);
            tabPage1.Controls.Add(label7);
            tabPage1.Controls.Add(dataGridView1);
            tabPage1.Controls.Add(groupBox1);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1892, 878);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "📅RANDEVU EKLE";
            tabPage1.Click += tabPage1_Click;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.MenuHighlight;
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button1.ForeColor = SystemColors.Window;
            button1.Location = new Point(1829, 6);
            button1.Name = "button1";
            button1.Size = new Size(57, 36);
            button1.TabIndex = 25;
            button1.Text = "☰";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click_1;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label7.ForeColor = SystemColors.Desktop;
            label7.Location = new Point(682, 81);
            label7.Name = "label7";
            label7.Size = new Size(206, 28);
            label7.TabIndex = 23;
            label7.Text = "AKTİF RANDEVULAR";
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = SystemColors.Window;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(682, 118);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(1166, 646);
            dataGridView1.TabIndex = 24;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // tabPage3
            // 
            tabPage3.BackColor = SystemColors.Control;
            tabPage3.Controls.Add(button2);
            tabPage3.Controls.Add(btnRandevuSil);
            tabPage3.Controls.Add(btnRandevuGuncelle);
            tabPage3.Controls.Add(dataGridRandevular);
            tabPage3.Controls.Add(label8);
            tabPage3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            tabPage3.Location = new Point(4, 29);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(1892, 878);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "ℹ️RANDEVU GÜNCELLE/SİL";
            tabPage3.Click += tabPage3_Click;
            // 
            // button2
            // 
            button2.BackColor = SystemColors.MenuHighlight;
            button2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button2.ForeColor = SystemColors.Window;
            button2.Location = new Point(1829, 6);
            button2.Name = "button2";
            button2.Size = new Size(57, 36);
            button2.TabIndex = 26;
            button2.Text = "☰";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label8.Location = new Point(379, 44);
            label8.Name = "label8";
            label8.Size = new Size(248, 28);
            label8.TabIndex = 8;
            label8.Text = "RANDEVU GÜNCELLE/SİL";
            // 
            // randevu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1902, 1033);
            Controls.Add(tabControl1);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "randevu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "OTOPLAN/RANDEVU İŞLEMLERİ";
            WindowState = FormWindowState.Maximized;
            FormClosed += randevu_FormClosed;
            Load += randevu_Load_1;
            ((System.ComponentModel.ISupportInitialize)dataGridRandevular).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridRandevular;
        private DateTimePicker dateTimeRandevu;
        private Button btnRandevuEkle;
        private Button btnRandevuGuncelle;
        private Button btnRandevuSil;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label1;
        private Label label2;
        private Label label3;
        private System.Windows.Forms.Timer timer1;
        private TextBox randevuNot;
        private Label label5;
        private Panel panel1;
        private Label label4;
        private GroupBox groupBox1;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private DataGridView dataGridView1;
        private Label label6;
        private Label label7;
        private Label label8;
        private TabPage tabPage3;
        private Button button1;
        private Button button2;
    }
}