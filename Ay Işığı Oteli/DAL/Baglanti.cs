using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ay_Işığı_Oteli.DAL
{
    internal class Baglanti
    {
        public MySqlConnection baglantiGetir()
        {
            MySqlConnection baglanti = new MySqlConnection("Server=172.21.54.253; Database=25_132330026; User=25_132330026; Password=!nif.ogr26KA");
            baglanti.Open();
            return baglanti;
        }
    }
}
