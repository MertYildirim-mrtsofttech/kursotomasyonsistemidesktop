namespace CourseSystem
{
    partial class usernamepassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(usernamepassword));
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            button1 = new Button();
            textBox3 = new TextBox();
            label3 = new Label();
            groupBox1 = new GroupBox();
            panel1 = new Panel();
            label4 = new Label();
            button2 = new Button();
            pictureBox1 = new PictureBox();
            groupBox1.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            textBox1.Location = new Point(92, 241);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(290, 38);
            textBox1.TabIndex = 0;
            textBox1.TextAlign = HorizontalAlignment.Center;
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            textBox2.Location = new Point(92, 334);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(290, 38);
            textBox2.TabIndex = 1;
            textBox2.TextAlign = HorizontalAlignment.Center;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(139, 207);
            label1.Name = "label1";
            label1.Size = new Size(202, 31);
            label1.TabIndex = 2;
            label1.Text = "Yeni Kullanıcı Adı";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(209, 300);
            label2.Name = "label2";
            label2.Size = new Size(64, 31);
            label2.TabIndex = 3;
            label2.Text = "Şifre";
            // 
            // button1
            // 
            button1.BackColor = SystemColors.MenuHighlight;
            button1.ForeColor = SystemColors.Window;
            button1.Location = new Point(167, 418);
            button1.Name = "button1";
            button1.Size = new Size(141, 47);
            button1.TabIndex = 4;
            button1.Text = "GÜNCELLE";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // textBox3
            // 
            textBox3.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            textBox3.Location = new Point(92, 144);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(290, 38);
            textBox3.TabIndex = 5;
            textBox3.TextAlign = HorizontalAlignment.Center;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(148, 110);
            label3.Name = "label3";
            label3.Size = new Size(183, 31);
            label3.TabIndex = 6;
            label3.Text = "Kullanıcı Adınız";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(textBox3);
            groupBox1.Controls.Add(textBox2);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox1.Location = new Point(295, 251);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(484, 558);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            groupBox1.Text = "KULLANICI ADI VE ŞİFRE DEĞİŞTİR";
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.MenuText;
            panel1.Controls.Add(label4);
            panel1.Location = new Point(1, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1926, 125);
            panel1.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = SystemColors.MenuText;
            label4.Font = new Font("Impact", 36F, FontStyle.Bold, GraphicsUnit.Point);
            label4.ForeColor = SystemColors.Window;
            label4.Location = new Point(547, 26);
            label4.Name = "label4";
            label4.Size = new Size(828, 75);
            label4.TabIndex = 0;
            label4.Text = "KULLANICI ADI VE ŞİFRE DEĞİŞTİR";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // button2
            // 
            button2.BackColor = SystemColors.MenuHighlight;
            button2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button2.ForeColor = SystemColors.Window;
            button2.Location = new Point(1838, 142);
            button2.Name = "button2";
            button2.Size = new Size(65, 43);
            button2.TabIndex = 9;
            button2.Text = "☰";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.Location = new Point(1120, 321);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(673, 466);
            pictureBox1.TabIndex = 10;
            pictureBox1.TabStop = false;
            // 
            // usernamepassword
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1902, 1033);
            Controls.Add(pictureBox1);
            Controls.Add(button2);
            Controls.Add(panel1);
            Controls.Add(groupBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "usernamepassword";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "OTOPLAN/KULLANICI ADI VE ŞİFRE DEĞİŞTİRME";
            WindowState = FormWindowState.Maximized;
            FormClosed += usernamepassword_FormClosed;
            Load += usernamepassword_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TextBox textBox1;
        private TextBox textBox2;
        private Label label1;
        private Label label2;
        private Button button1;
        private TextBox textBox3;
        private Label label3;
        private GroupBox groupBox1;
        private Panel panel1;
        private Label label4;
        private Button button2;
        private PictureBox pictureBox1;
    }
}