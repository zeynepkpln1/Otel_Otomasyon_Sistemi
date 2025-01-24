using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ay_Işığı_Oteli.DOMAİN
{
    public class Oda
    {
        public int oda_id { get; set; }
        public string oda_no { get; set; }
        public decimal oda_fiyat { get; set; }
        public string oda_tip { get; set; }
        public bool oda_durum { get; set; }
    }
}


