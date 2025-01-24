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
    public partial class FrmMusteriEkle : Form
    {
        public FrmMusteriEkle()
        {
            InitializeComponent();
        }

        string connectionString = "Server=172.21.54.253;Database=25_132330024;Uid=25_132330024;Pwd=!nif.ogr24BO;";

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtMusteriAdi.Text) || string.IsNullOrEmpty(TxtMusteriSoyadi.Text) ||
                string.IsNullOrEmpty(TxtMusteriTc.Text) || string.IsNullOrEmpty(TxtMusteriTelefon.Text))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO musteri (musteri_adi, musteri_soyadi, musteri_kimlikno, musteri_telefon) " +
                                   "VALUES (@adi, @soyadi, @kimlikno, @telefon)";
                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    cmd.Parameters.AddWithValue("@adi", TxtMusteriAdi.Text);
                    cmd.Parameters.AddWithValue("@soyadi", TxtMusteriSoyadi.Text);
                    cmd.Parameters.AddWithValue("@kimlikno", TxtMusteriTc.Text);
                    cmd.Parameters.AddWithValue("@telefon", TxtMusteriTelefon.Text);

                    cmd.ExecuteNonQuery();
                }

                LoadMusteriler(); 
                MessageBox.Show("Müşteri başarıyla eklendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Veritabanı hatası: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadMusteriler()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT musteri_id, musteri_adi, musteri_soyadi, musteri_kimlikno, musteri_telefon FROM musteri";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);

                    DataTable dataTable = new DataTable();

                    adapter.Fill(dataTable);

                    DtaGridView.DataSource = dataTable;
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Veritabanı hatası: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void Btnİleri_Click(object sender, EventArgs e)
        {
            try
            {
                FrmRezervasyon frmRezervasyon = new FrmRezervasyon();

                frmRezervasyon.Show();

                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {

        }

        private void FrmMusteriEkle_Load(object sender, EventArgs e)
        {

        }
    }
}
