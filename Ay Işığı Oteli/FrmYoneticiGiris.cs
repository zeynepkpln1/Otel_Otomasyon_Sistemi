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

namespace Ay_Işığı_Oteli
{
    public partial class FrmYoneticiGiris : Form
    {
        public FrmYoneticiGiris()
        {
            InitializeComponent();
        }
        private void BtnGiris_Click(object sender, EventArgs e)
        {
            string yoneticiTc = TxtYoneticiTc.Text.Trim();
            string yoneticiSifre = TxtYoneticiSifre.Text.Trim();

            if (string.IsNullOrEmpty(yoneticiTc) || string.IsNullOrEmpty(yoneticiSifre))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string connectionString = "Server=172.21.54.253;Database=25_132330026;Uid=25_132330026;Pwd=!nif.ogr26KA;";

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT COUNT(*) FROM yonetici WHERE yonetici_tc = @yoneticiTc AND yonetici_sifre = @yoneticiSifre";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@yoneticiTc", yoneticiTc);
                        command.Parameters.AddWithValue("@yoneticiSifre", yoneticiSifre);

                        int count = Convert.ToInt32(command.ExecuteScalar());

                        if (count > 0)
                        {
                            MessageBox.Show("Giriş başarılı!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            FrmMusteriEkle musteriEkleForm = new FrmMusteriEkle();
                            musteriEkleForm.Show();  // Yeni formu aç
                            this.Hide();  // Mevcut formu gizle
                        }
                        else
                        {
                            MessageBox.Show("Hatalı T.C. veya Şifre!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            { 
                MessageBox.Show("Bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
        }

        private void FrmYoneticiGiris_Load(object sender, EventArgs e)
        {

        }
    }
}
