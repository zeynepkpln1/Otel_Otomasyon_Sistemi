using Ay_Işığı_Oteli.DAL;
using Ay_Işığı_Oteli.DOMAİN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ay_Işığı_Oteli.SERVİS
{
    public class OdaService
    {
        private readonly OdaDAL _odaDAL;

        public OdaService()
        {
            _odaDAL = new OdaDAL();
        }

        // Tüm odaları getir
        public List<Oda> OdalariGetir()
        {
            return _odaDAL.GetirOdalar();
        }

        // Yeni oda ekle
        public void OdaEkle(Oda oda)
        {
            if (oda == null)
            {
                throw new ArgumentNullException(nameof(oda), "Oda bilgileri boş olamaz.");
            }

            if (string.IsNullOrWhiteSpace(oda.oda_no))
            {
                throw new ArgumentException("Oda numarası boş olamaz.");
            }

            if (oda.oda_fiyat <= 0)
            {
                throw new ArgumentException("Oda fiyatı sıfır veya daha küçük olamaz.");
            }

            if (string.IsNullOrWhiteSpace(oda.oda_tip))
            {
                throw new ArgumentException("Oda tipi boş olamaz.");
            }

            _odaDAL.EkleOda(oda);
        }

        // Oda sil
        public bool OdaSil(int odaId)
        {
            if (odaId <= 0)
            {
                throw new ArgumentException("Geçersiz oda ID.", nameof(odaId));
            }

            try
            {
                _odaDAL.SilOda(odaId);
                return true;
            }
            catch (Exception ex)
            {
                // Hata loglama yapılabilir
                Console.WriteLine($"Hata: {ex.Message}");
                return false;
            }
        }
    }
}



