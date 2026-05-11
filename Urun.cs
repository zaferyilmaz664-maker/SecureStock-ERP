using System;

namespace SecureStock.Entities
{
    public class Urun
    {
        public int UrunID { get; set; }
        public int KategoriID { get; set; }
        public string Barkod { get; set; }
        public string UrunAdi { get; set; }
        public int StokMiktari { get; set; }
        public decimal BirimFiyat { get; set; }
        public bool IsActive { get; set; }
    }
}