using System;
using System.Collections.Generic;
using SecureStock.Entities;
using SecureStock.DataAccess;

namespace SecureStock.BusinessLogic
{
    public class SatisBLL
    {
        private SatisDAL _satisDAL = new SatisDAL();

        public bool SatisOnayla(Satis satis, List<SatisDetay> detaylar)
        {
            if (detaylar.Count == 0)
                throw new Exception("Sepet boşken satış yapılamaz!");

            return _satisDAL.SatisYap(satis, detaylar);
        }
    }
}