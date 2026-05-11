using System;
using SecureStock.Entities;
using SecureStock.DataAccess;

namespace SecureStock.BusinessLogic
{
    public class UrunBLL
    {
        private UrunDAL _urunDAL = new UrunDAL();

        public Urun SatisIcinUrunGetir(string barkod)
        {
            if (string.IsNullOrWhiteSpace(barkod))
                throw new Exception("Barkod boş olamaz!");

            Urun urun = _urunDAL.GetirBarkodIle(barkod);

            if (urun == null)
                throw new Exception("Ürün sistemde bulunamadı veya pasif durumda!");

            // En kritik kurallardan biri: Stok sıfırsa satamazsın.
            if (urun.StokMiktari <= 0)
                throw new Exception($"Kritik Uyarı: {urun.UrunAdi} adlı ürünün stoğu tükenmiş!");

            return urun;
        }
    }
}