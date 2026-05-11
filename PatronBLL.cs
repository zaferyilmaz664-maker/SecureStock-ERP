using System;
using System.Data;
using SecureStock.DataAccess;

namespace SecureStock.BusinessLogic
{
    public class PatronBLL
    {
        private PatronDAL _patronDAL = new PatronDAL();

        // Ortak yetki kontrol metodu
        private void YetkiKontrol(string rol)
        {
            // Sadece Yönetici veya Patron bu verileri görebilir!
            if (rol != "Yönetici" && rol != "Patron")
                throw new Exception("Yetkisiz Erişim: Finansal raporları görüntüleme yetkiniz yok!");
        }

        public decimal GunlukCiroGetir(string rol)
        {
            YetkiKontrol(rol);
            return _patronDAL.GetBugunkuCiro();
        }

        public int KritikStokSayisiGetir(string rol)
        {
            YetkiKontrol(rol);
            return _patronDAL.GetKritikStokSayisi();
        }

        public DataTable EnCokSatanlariGetir(string rol)
        {
            YetkiKontrol(rol);
            return _patronDAL.GetEnCokSatanUrunler();
        }
    }
}