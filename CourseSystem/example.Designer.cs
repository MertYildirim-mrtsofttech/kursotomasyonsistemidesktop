namespace CourseSystem
{
    partial class example
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
            button1 = new Button();
            button2 = new Button();
            dataGridView1 = new DataGridView();
            label1 = new Label();
            dataGridView2 = new DataGridView();
            label2 = new Label();
            button3 = new Button();
            label3 = new Label();
            label4 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            label5 = new Label();
            textBox3 = new TextBox();
            button4 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(276, 57);
            button1.Name = "button1";
            button1.Size = new Size(179, 109);
            button1.TabIndex = 0;
            button1.Text = "CONNECT TO DB 🌐 ";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(276, 223);
            button2.Name = "button2";
            button2.Size = new Size(179, 109);
            button2.TabIndex = 1;
            button2.Text = "TABLO OLUŞTUR";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(488, 74);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(300, 188);
            dataGridView1.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(588, 41);
            label1.Name = "label1";
            label1.Size = new Size(115, 20);
            label1.TabIndex = 3;
            label1.Text = "Öğrenci Tablosu";
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(12, 74);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersWidth = 51;
            dataGridView2.RowTemplate.Height = 29;
            dataGridView2.Size = new Size(242, 171);
            dataGridView2.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(72, 41);
            label2.Name = "label2";
            label2.Size = new Size(93, 20);
            label2.TabIndex = 5;
            label2.Text = "Okul Tablosu";
            // 
            // button3
            // 
            button3.Location = new Point(316, 356);
            button3.Name = "button3";
            button3.Size = new Size(94, 29);
            button3.TabIndex = 6;
            button3.Text = "VERİ ÇEK";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(527, 312);
            label3.Name = "label3";
            label3.Size = new Size(28, 20);
            label3.TabIndex = 7;
            label3.Text = "Ad";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(527, 356);
            label4.Name = "label4";
            label4.Size = new Size(50, 20);
            label4.TabIndex = 8;
            label4.Text = "Soyad";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(561, 309);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 9;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(583, 353);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(125, 27);
            textBox2.TabIndex = 10;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(519, 405);
            label5.Name = "label5";
            label5.Size = new Size(63, 20);
            label5.TabIndex = 11;
            label5.Text = "Okul No";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(588, 398);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(125, 27);
            textBox3.TabIndex = 12;
            // 
            // button4
            // 
            button4.Location = new Point(316, 398);
            button4.Name = "button4";
            button4.Size = new Size(94, 29);
            button4.TabIndex = 13;
            button4.Text = "VERİ EKLE";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // example
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button4);
            Controls.Add(textBox3);
            Controls.Add(label5);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(button3);
            Controls.Add(label2);
            Controls.Add(dataGridView2);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "example";
            Text = "example";
            Load += example_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private DataGridView dataGridView1;
        private Label label1;
        private DataGridView dataGridView2;
        private Label label2;
        private Button button3;
        private Label label3;
        private Label label4;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label5;
        private TextBox textBox3;
        private Button button4;
    }
}