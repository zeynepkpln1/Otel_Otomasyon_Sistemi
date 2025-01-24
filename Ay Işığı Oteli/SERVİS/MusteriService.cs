using Ay_Işığı_Oteli.DAL;
using Ay_Işığı_Oteli.DOMAİN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ay_Işığı_Oteli.SERVİS
{
    public class musteriService
    {
        private readonly MusteriDAL _musteriDAL;

        public musteriService()
        {
            _musteriDAL = new MusteriDAL();
        }

        // Tüm müşterileri getir
        public List<Musteri> MusterileriGetir()
        {
            return _musteriDAL.GetirMusteriler();
        }

        // Yeni müşteri ekle
        public void MusteriEkle(Musteri musteri)
        {
            if (musteri == null)
            {
                throw new ArgumentNullException(nameof(musteri), "Müşteri bilgileri boş olamaz.");
            }

            if (string.IsNullOrWhiteSpace(musteri.musteri_adi) || string.IsNullOrWhiteSpace(musteri.musteri_soyadi))
            {
                throw new ArgumentException("Müşteri adı ve soyadı boş olamaz.");
            }

            _musteriDAL.EkleMusteri(musteri);
        }

        // Müşteri sil
        public bool MusteriSil(int musteriId)
        {
            if (musteriId <= 0)
            {
                throw new ArgumentException("Geçersiz müşteri ID.", nameof(musteriId));
            }

            try
            {
                _musteriDAL.SilMusteri(musteriId);
                return true;
            }
            catch (Exception ex)
            {
                // Hata loglama yapılabilir
                Console.WriteLine($"Hata: {ex.Message}");
                return false;
            }
        }

        // Buton ile müşteri ekleme
        public void BtnEkle(string musteriAdi, string musteriSoyadi, string musteriTc, string musteriTelefon)
        {
            if (string.IsNullOrWhiteSpace(musteriAdi) || string.IsNullOrWhiteSpace(musteriSoyadi) ||
                string.IsNullOrWhiteSpace(musteriTc) || string.IsNullOrWhiteSpace(musteriTelefon))
            {
                throw new ArgumentException("Tüm müşteri bilgileri doldurulmalıdır.");
            }

            var musteri = new Musteri
            {
                musteri_adi = musteriAdi,
                musteri_soyadi = musteriSoyadi,
                musteri_tc = musteriTc,
                musteri_telefon = musteriTelefon
            };

            MusteriEkle(musteri);
        }
    }
}