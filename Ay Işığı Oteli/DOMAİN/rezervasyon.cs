using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ay_Işığı_Oteli.DOMAİN
{
    public class Rezervasyon
    {
        public int rezervasyon_id { get; set; }
        public string musteri_tc { get; set; }
        public DateTime giris_tarih { get; set; }
        public DateTime cikis_tarih { get; set; }
        public decimal toplam_tutar { get; set; }
    }
}