using System;

namespace SecureStock.Entities
{
    public class IslemLog
    {
        public int LogID { get; set; }
        public int KullaniciID { get; set; }
        public string IslemTipi { get; set; }
        public string TabloAdi { get; set; }
        public string Aciklama { get; set; }
        public DateTime Tarih { get; set; }
    }
}