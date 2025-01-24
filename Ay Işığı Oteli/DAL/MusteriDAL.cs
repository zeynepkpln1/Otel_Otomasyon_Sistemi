using Ay_Işığı_Oteli.DOMAİN;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    namespace Ay_Işığı_Oteli.DAL
    {
    public class MusteriDAL
    {
        private readonly Baglanti _baglanti;

        public MusteriDAL()
        {
            _baglanti = new Baglanti();
        }

        // Tüm müşterileri getir
        public List<Musteri> GetirMusteriler()
        {
            List<Musteri> musteriler = new List<Musteri>();

            try
            {
                using (var conn = _baglanti.baglantiGetir())
                {
                    var query = "SELECT musteri_id, musteri_adi, musteri_soyadi, musteri_telefon, musteri_tc FROM musteri";
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            musteriler.Add(new Musteri
                            {
                                musteri_id = reader.GetInt32("musteri_id"),
                                musteri_adi = reader.GetString("musteri_adi"),
                                musteri_soyadi = reader.GetString("musteri_soyadi"),
                                musteri_telefon = reader.GetString("musteri_telefon"),
                                musteri_tc = reader.GetString("musteri_tc")
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Hata loglaması yapabilirsiniz
                Console.WriteLine($"Hata: {ex.Message}");
                throw new Exception("Veritabanı hatası! Müşteriler getirilemedi.");
            }

            return musteriler;
        }

        // Yeni müşteri ekle
        public void EkleMusteri(Musteri musteri)
        {
            if (musteri == null)
            {
                throw new ArgumentNullException(nameof(musteri), "Müşteri bilgileri boş olamaz.");
            }

            try
            {
                using (var conn = _baglanti.baglantiGetir())
                {
                    var query = "INSERT INTO musteri (musteri_adi, musteri_soyadi, musteri_telefon, musteri_tc) VALUES (@adi, @soyadi, @telefon, @tc)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@adi", musteri.musteri_adi);
                    cmd.Parameters.AddWithValue("@soyadi", musteri.musteri_soyadi);
                    cmd.Parameters.AddWithValue("@telefon", musteri.musteri_telefon);
                    cmd.Parameters.AddWithValue("@tc", musteri.musteri_tc);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                // Hata loglaması yapılabilir
                Console.WriteLine($"Hata: {ex.Message}");
                throw new Exception("Veritabanı hatası! Müşteri eklenemedi.");
            }
        }

        // Müşteri sil
        public void SilMusteri(int musteriId)
        {
            if (musteriId <= 0)
            {
                throw new ArgumentException("Geçersiz müşteri ID.", nameof(musteriId));
            }

            try
            {
                using (var conn = _baglanti.baglantiGetir())
                {
                    var query = "DELETE FROM musteri WHERE musteri_id = @id";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", musteriId);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                // Hata loglaması yapılabilir
                Console.WriteLine($"Hata: {ex.Message}");
                throw new Exception("Veritabanı hatası! Müşteri silinemedi.");
            }
        }
    }
}