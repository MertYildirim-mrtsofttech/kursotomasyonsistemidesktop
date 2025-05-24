namespace CourseSystem
{
    partial class admin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(admin));
            button4 = new Button();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            panel1 = new Panel();
            button6 = new Button();
            panel2 = new Panel();
            label1 = new Label();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            panel3 = new Panel();
            panel4 = new Panel();
            panel5 = new Panel();
            panel6 = new Panel();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            panel6.SuspendLayout();
            SuspendLayout();
            // 
            // button4
            // 
            button4.BackColor = SystemColors.MenuHighlight;
            button4.Font = new Font("Segoe UI", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point);
            button4.ForeColor = SystemColors.Window;
            button4.Location = new Point(63, 167);
            button4.Name = "button4";
            button4.Size = new Size(818, 110);
            button4.TabIndex = 3;
            button4.Text = "👤KULLANICI ADI VE ŞİFRE DEĞİŞTİR";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // button3
            // 
            button3.BackColor = SystemColors.MenuHighlight;
            button3.Font = new Font("Segoe UI", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point);
            button3.ForeColor = SystemColors.Window;
            button3.Location = new Point(67, 167);
            button3.Name = "button3";
            button3.Size = new Size(765, 110);
            button3.TabIndex = 2;
            button3.Text = "🗓️RANDEVU OLUŞTUR";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.BackColor = SystemColors.MenuHighlight;
            button2.Font = new Font("Segoe UI", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point);
            button2.ForeColor = SystemColors.Window;
            button2.Location = new Point(81, 109);
            button2.Name = "button2";
            button2.Size = new Size(765, 110);
            button2.TabIndex = 1;
            button2.Text = "🔍ARAÇLARA BAK/GÜNCELLE/SİL";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.MenuHighlight;
            button1.Font = new Font("Segoe UI", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point);
            button1.ForeColor = SystemColors.Window;
            button1.Location = new Point(67, 109);
            button1.Name = "button1";
            button1.Size = new Size(765, 110);
            button1.TabIndex = 0;
            button1.Text = "🚗ARAÇ KAYIT ET";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Black;
            panel1.Controls.Add(button6);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1924, 125);
            panel1.TabIndex = 2;
            // 
            // button6
            // 
            button6.BackColor = Color.Red;
            button6.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            button6.ForeColor = SystemColors.Window;
            button6.Location = new Point(1723, 47);
            button6.Name = "button6";
            button6.Size = new Size(189, 33);
            button6.TabIndex = 7;
            button6.Text = "👤OTURUMU KAPAT";
            button6.UseVisualStyleBackColor = false;
            button6.Click += button6_Click;
            // 
            // panel2
            // 
            panel2.Location = new Point(3, 156);
            panel2.Name = "panel2";
            panel2.Size = new Size(920, 415);
            panel2.TabIndex = 3;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Impact", 48F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.Window;
            label1.Location = new Point(797, 9);
            label1.Name = "label1";
            label1.Size = new Size(329, 98);
            label1.TabIndex = 0;
            label1.Text = "OTOPLAN";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // panel3
            // 
            panel3.Controls.Add(button1);
            panel3.Location = new Point(12, 170);
            panel3.Name = "panel3";
            panel3.Size = new Size(928, 379);
            panel3.TabIndex = 3;
            // 
            // panel4
            // 
            panel4.Controls.Add(button2);
            panel4.Location = new Point(971, 170);
            panel4.Name = "panel4";
            panel4.Size = new Size(928, 379);
            panel4.TabIndex = 4;
            // 
            // panel5
            // 
            panel5.Controls.Add(button3);
            panel5.Location = new Point(12, 577);
            panel5.Name = "panel5";
            panel5.Size = new Size(928, 405);
            panel5.TabIndex = 5;
            // 
            // panel6
            // 
            panel6.Controls.Add(button4);
            panel6.Location = new Point(971, 577);
            panel6.Name = "panel6";
            panel6.Size = new Size(928, 405);
            panel6.TabIndex = 5;
            // 
            // admin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1902, 1033);
            Controls.Add(panel6);
            Controls.Add(panel5);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "admin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "OTOPLAN/MENU";
            WindowState = FormWindowState.Maximized;
            FormClosed += admin_FormClosed;
            Load += admin_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel3.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel6.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Panel panel1;
        private Label label1;
        private Panel panel2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
        private Panel panel6;
        private Button button6;
    }
}