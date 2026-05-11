using System;

namespace SecureStock.Entities
{
    public class SatisDetay
    {
        public int SatisDetayID { get; set; }
        public int SatisID { get; set; }
        public int UrunID { get; set; }
        public int Miktar { get; set; }
        public decimal BirimFiyat { get; set; }
    }
}