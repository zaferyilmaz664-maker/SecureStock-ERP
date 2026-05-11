using System;
using SecureStock.Entities;
using SecureStock.DataAccess;

namespace SecureStock.BusinessLogic
{
    public class KullaniciBLL
    {
        private KullaniciDAL _kullaniciDAL = new KullaniciDAL();

        // 1. MEVCUT METOD: GİRİŞ KURALLARI VE YÖNLENDİRME
        public Kullanici GirisKontrol(string kullaniciAdi, string düzSifre)
        {
            if (string.IsNullOrWhiteSpace(kullaniciAdi) || string.IsNullOrWhiteSpace(düzSifre))
            {
                throw new Exception("Kullanıcı adı veya şifre boş bırakılamaz!");
            }

            string hashliSifre = SifrelemeHelper.SHA256Sifrele(düzSifre);

            Kullanici girisYapanKullanici = _kullaniciDAL.GirisYap(kullaniciAdi, hashliSifre);

            if (girisYapanKullanici == null)
            {
                throw new Exception("Hatalı kullanıcı adı veya şifre!");
            }

            return girisYapanKullanici;
        }

        // 2. YENİ EKLENEN METOD: KAYIT KURALLARI VE ŞİFRELEME
        public bool YeniPersonelKaydet(string islemYapanRol, string yeniKullaniciAdi, string düzSifre, string yeniRol)
        {
            // GÜVENLİK DUVARI: Kasiyerler sisteme adam ekleyemez!
            if (islemYapanRol != "Patron" && islemYapanRol != "Admin" && islemYapanRol != "Yönetici")
            {
                throw new Exception("Güvenlik İhlali: Yeni personel ekleme yetkiniz bulunmamaktadır!");
            }

            if (string.IsNullOrWhiteSpace(yeniKullaniciAdi) || string.IsNullOrWhiteSpace(düzSifre))
            {
                throw new Exception("Kullanıcı adı veya şifre boş bırakılamaz!");
            }

            // Arayüzden gelen "123456" gibi düz metni veritabanına atmadan önce eziyoruz
            string hashliSifre = SifrelemeHelper.SHA256Sifrele(düzSifre);

            Kullanici yeniPersonel = new Kullanici
            {
                KullaniciAdi = yeniKullaniciAdi,
                SifreHash = hashliSifre,
                Rol = yeniRol
            };

            return _kullaniciDAL.KullaniciEkle(yeniPersonel);
        }
    }
}