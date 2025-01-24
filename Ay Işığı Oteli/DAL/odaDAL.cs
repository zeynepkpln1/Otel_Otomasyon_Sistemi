using Ay_Işığı_Oteli.DOMAİN;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ay_Işığı_Oteli.DAL
{
    public class OdaDAL
    {
        private readonly Baglanti _baglanti;

        public OdaDAL()
        {
            _baglanti = new Baglanti();
        }

        // Odaları getiren metod
        public List<Oda> GetirOdalar()
        {
            List<Oda> odalar = new List<Oda>(); // 'OdaL' yerine 'Oda' olmalı
            using (var conn = _baglanti.baglantiGetir())
            {
                var query = "SELECT oda_id, oda_no, oda_fiyat, oda_tip, oda_durum FROM oda";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        odalar.Add(new Oda
                        {
                            oda_id = reader.GetInt32("oda_id"),
                            oda_no = reader.GetString("oda_no"),
                            oda_fiyat = reader.GetDecimal("oda_fiyat"),
                            oda_tip = reader.GetString("oda_tip"),
                            oda_durum = reader.GetBoolean("oda_durum")
                        });
                    }
                }
            }
            return odalar;
        }

        // Oda ekleyen metod
        public void EkleOda(Oda oda) // 'OdaDAL' yerine 'Oda' olmalı
        {
            using (var conn = _baglanti.baglantiGetir())
            {
                var query = "INSERT INTO oda (oda_no, oda_fiyat, oda_tip, oda_durum) VALUES (@no, @fiyat, @tip, @durum)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@no", oda.oda_no);
                cmd.Parameters.AddWithValue("@fiyat", oda.oda_fiyat);
                cmd.Parameters.AddWithValue("@tip", oda.oda_tip);
                cmd.Parameters.AddWithValue("@durum", oda.oda_durum);
                cmd.ExecuteNonQuery();
            }
        }

        // Oda silen metod
        public void SilOda(int odaId)
        {
            using (var conn = _baglanti.baglantiGetir())
            {
                var query = "DELETE FROM oda WHERE oda_id = @id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", odaId);
                cmd.ExecuteNonQuery();
            }
        }
    }
}

