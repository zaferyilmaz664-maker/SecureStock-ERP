using System;
using System.Data;
using SecureStock.DataAccess;

namespace SecureStock.BusinessLogic
{
    public class LogBLL
    {
        private LogDAL _logDAL = new LogDAL();

        public DataTable LoglariListele(string kullaniciRolu)
        {
            // BİRİNCİ KURAL: Kasiyer bu verileri göremez!
            if (kullaniciRolu != "Yönetici" && kullaniciRolu != "Admin")
            {
                throw new Exception("Kritik Güvenlik İhlali: Bu ekranı görüntülemeye yetkiniz bulunmamaktadır!");
            }

            return _logDAL.TumLoglariGetir();
        }
    }
}