using Ay_Işığı_Oteli.DAL;
using Ay_Işığı_Oteli.DOMAİN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ay_Işığı_Oteli.SERVİS
{
    public class RezervasyonService
    {
        private readonly RezervasyonDAL _rezervasyonDAL;

        public RezervasyonService()
        {
            _rezervasyonDAL = new RezervasyonDAL();
        }

        // Tüm rezervasyonları getir
        public List<Rezervasyon> RezervasyonlariGetir()
        {
            return _rezervasyonDAL.GetirRezervasyonlar();
        }

        // Yeni rezervasyon ekle
        public void RezervasyonEkle(Rezervasyon rezervasyon)
        {
            if (rezervasyon == null)
            {
                throw new ArgumentNullException(nameof(rezervasyon), "Rezervasyon bilgileri boş olamaz.");
            }

            if (string.IsNullOrWhiteSpace(rezervasyon.musteri_tc))
            {
                throw new ArgumentException("Müşteri TC boş olamaz.");
            }

            if (rezervasyon.giris_tarih == DateTime.MinValue || rezervasyon.cikis_tarih == DateTime.MinValue)
            {
                throw new ArgumentException("Geçerli bir giriş ve çıkış tarihi belirtmelisiniz.");
            }

            if (rezervasyon.giris_tarih >= rezervasyon.cikis_tarih)
            {
                throw new ArgumentException("Giriş tarihi çıkış tarihinden önce olmalıdır.");
            }

            if (rezervasyon.toplam_tutar <= 0)
            {
                throw new ArgumentException("Toplam tutar sıfır veya daha küçük olamaz.");
            }

            _rezervasyonDAL.EkleRezervasyon(rezervasyon);
        }

        // Rezervasyon sil
        public bool RezervasyonSil(int rezervasyonId)
        {
            if (rezervasyonId <= 0)
            {
                throw new ArgumentException("Geçersiz rezervasyon ID.", nameof(rezervasyonId));
            }

            try
            {
                _rezervasyonDAL.SilRezervasyon(rezervasyonId);
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