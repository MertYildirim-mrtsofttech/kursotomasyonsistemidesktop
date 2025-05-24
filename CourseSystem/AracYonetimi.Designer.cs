namespace CourseSystem
{
    partial class AracYonetimi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AracYonetimi));
            flowLayoutPanel1 = new FlowLayoutPanel();
            btnGeriDon = new Button();
            panel1 = new Panel();
            label1 = new Label();
            label2 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Location = new Point(60, 183);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(1821, 860);
            flowLayoutPanel1.TabIndex = 0;
            flowLayoutPanel1.Paint += flowLayoutPanel1_Paint;
            // 
            // btnGeriDon
            // 
            btnGeriDon.BackColor = SystemColors.MenuHighlight;
            btnGeriDon.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnGeriDon.ForeColor = SystemColors.Window;
            btnGeriDon.Location = new Point(1848, 132);
            btnGeriDon.Name = "btnGeriDon";
            btnGeriDon.Size = new Size(64, 44);
            btnGeriDon.TabIndex = 1;
            btnGeriDon.Text = "☰";
            btnGeriDon.UseVisualStyleBackColor = false;
            btnGeriDon.Click += btnGeriDon_Click_1;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Desktop;
            panel1.Controls.Add(label1);
            panel1.Location = new Point(1, 1);
            panel1.Name = "panel1";
            panel1.Size = new Size(1923, 125);
            panel1.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Impact", 48F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.Window;
            label1.Location = new Point(736, 8);
            label1.Name = "label1";
            label1.Size = new Size(533, 98);
            label1.TabIndex = 0;
            label1.Text = "ARAÇ YÖNETİMİ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label2.ForeColor = Color.Red;
            label2.Location = new Point(60, 157);
            label2.Name = "label2";
            label2.Size = new Size(299, 23);
            label2.TabIndex = 3;
            label2.Text = "*Randevu tanımlanacak aracı seçiniz";
            // 
            // AracYonetimi
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1902, 1033);
            Controls.Add(label2);
            Controls.Add(panel1);
            Controls.Add(btnGeriDon);
            Controls.Add(flowLayoutPanel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "AracYonetimi";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "OTOPLAN/ARAÇ YÖNETİMİ";
            WindowState = FormWindowState.Maximized;
            FormClosed += AracYonetimi_FormClosed;
            Load += AracYonetimi_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel1;
        private Button btnGeriDon;
        private Panel panel1;
        private Label label1;
        private Label label2;
    }
}