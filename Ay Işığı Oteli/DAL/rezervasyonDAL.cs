using Ay_Işığı_Oteli.DOMAİN;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ay_Işığı_Oteli.DAL
{
    public class RezervasyonDAL
    {
        private readonly Baglanti _baglanti;

        public RezervasyonDAL()
        {
            _baglanti = new Baglanti();
        }

        public List<Rezervasyon> GetirRezervasyonlar()
        {
            List<Rezervasyon> rezervasyonlar = new List<Rezervasyon>();
            using (var conn = _baglanti.baglantiGetir())
            {
                var query = "SELECT rezervasyon_id, musteri_tc, giris_tarih, cikis_tarih, toplam_tutar FROM rezervasyon";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        rezervasyonlar.Add(new Rezervasyon
                        {
                            rezervasyon_id = reader.GetInt32("rezervasyon_id"),
                            musteri_tc = reader.GetString("musteri_tc"),
                            giris_tarih = reader.GetDateTime("giris_tarih"),
                            cikis_tarih = reader.GetDateTime("cikis_tarih"),
                            toplam_tutar = reader.GetDecimal("toplam_tutar")
                        });
                    }
                }
            }
            return rezervasyonlar;
        }

        public void EkleRezervasyon(Rezervasyon rezervasyon)
        {
            using (var conn = _baglanti.baglantiGetir())
            {
                var query = "INSERT INTO rezervasyon (musteri_tc, giris_tarih, cikis_tarih, toplam_tutar) VALUES (@tc, @giris, @cikis, @tutar)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@tc", rezervasyon.musteri_tc);
                cmd.Parameters.AddWithValue("@giris", rezervasyon.giris_tarih);
                cmd.Parameters.AddWithValue("@cikis", rezervasyon.cikis_tarih);
                cmd.Parameters.AddWithValue("@tutar", rezervasyon.toplam_tutar);
                cmd.ExecuteNonQuery();
            }
        }

        public void SilRezervasyon(int rezervasyonId)
        {
            using (var conn = _baglanti.baglantiGetir())
            {
                var query = "DELETE FROM rezervasyon WHERE rezervasyon_id = @id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", rezervasyonId);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
