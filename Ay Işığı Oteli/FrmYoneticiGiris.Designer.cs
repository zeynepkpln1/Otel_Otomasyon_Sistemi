namespace Ay_Işığı_Oteli
{
    partial class FrmYoneticiGiris
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmYoneticiGiris));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtYoneticiTc = new System.Windows.Forms.TextBox();
            this.TxtYoneticiSifre = new System.Windows.Forms.TextBox();
            this.BtnGiris = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(135, 176);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "T.C.:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(124, 241);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Şifre:";
            // 
            // TxtYoneticiTc
            // 
            this.TxtYoneticiTc.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtYoneticiTc.Location = new System.Drawing.Point(185, 178);
            this.TxtYoneticiTc.Name = "TxtYoneticiTc";
            this.TxtYoneticiTc.Size = new System.Drawing.Size(214, 31);
            this.TxtYoneticiTc.TabIndex = 2;
            // 
            // TxtYoneticiSifre
            // 
            this.TxtYoneticiSifre.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtYoneticiSifre.Location = new System.Drawing.Point(185, 238);
            this.TxtYoneticiSifre.Name = "TxtYoneticiSifre";
            this.TxtYoneticiSifre.Size = new System.Drawing.Size(214, 31);
            this.TxtYoneticiSifre.TabIndex = 3;
            // 
            // BtnGiris
            // 
            this.BtnGiris.BackColor = System.Drawing.Color.MidnightBlue;
            this.BtnGiris.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnGiris.ForeColor = System.Drawing.Color.White;
            this.BtnGiris.Location = new System.Drawing.Point(185, 298);
            this.BtnGiris.Name = "BtnGiris";
            this.BtnGiris.Size = new System.Drawing.Size(90, 43);
            this.BtnGiris.TabIndex = 4;
            this.BtnGiris.Text = "Giriş";
            this.BtnGiris.UseVisualStyleBackColor = false;
            this.BtnGiris.Click += new System.EventHandler(this.BtnGiris_Click);
            // 
            // FrmYoneticiGiris
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(551, 439);
            this.Controls.Add(this.BtnGiris);
            this.Controls.Add(this.TxtYoneticiSifre);
            this.Controls.Add(this.TxtYoneticiTc);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmYoneticiGiris";
            this.Text = "        ";
            this.Load += new System.EventHandler(this.FrmYoneticiGiris_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtYoneticiTc;
        private System.Windows.Forms.TextBox TxtYoneticiSifre;
        private System.Windows.Forms.Button BtnGiris;
    }
}