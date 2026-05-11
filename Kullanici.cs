using System;

namespace SecureStock.Entities
{
    public class Kullanici
    {
        public int KullaniciID { get; set; }
        public string KullaniciAdi { get; set; }
        public string SifreHash { get; set; }
        public string Rol { get; set; }
        public bool IsActive { get; set; }
    }
}