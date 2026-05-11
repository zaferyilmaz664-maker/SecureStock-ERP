using System;

namespace SecureStock.Entities
{
    public class Satis
    {
        public int SatisID { get; set; }
        public int KullaniciID { get; set; }
        public decimal ToplamTutar { get; set; }
        public DateTime SatisTarihi { get; set; }
        public bool IsCancelled { get; set; }
    }
}