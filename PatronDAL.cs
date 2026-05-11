using System;
using System.Data;
using System.Data.SqlClient;

namespace SecureStock.DataAccess
{
    public class PatronDAL
    {
        // 1. Bugünkü Toplam Ciro (TL)
        public decimal GetBugunkuCiro()
        {
            decimal ciro = 0;
            using (SqlConnection conn = DbHelper.GetConnection())
            {
                // Satış tarihi bugüne eşit olanların ToplamTutarlarını topla
                string query = "SELECT ISNULL(SUM(ToplamTutar), 0) FROM Satislar WHERE DATEDIFF(day, SatisTarihi, GETDATE()) = 0";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    object result = cmd.ExecuteScalar(); // Tek bir değer döndüğü için Scalar kullanıyoruz
                    if (result != null && result != DBNull.Value)
                    {
                        ciro = Convert.ToDecimal(result);
                    }
                }
            }
            return ciro;
        }

        // 2. Kritik Stok Uyarısı (Stoğu 10'dan az kalan ürün sayısı)
        public int GetKritikStokSayisi()
        {
            int sayi = 0;
            using (SqlConnection conn = DbHelper.GetConnection())
            {
                string query = "SELECT COUNT(*) FROM Urunler WHERE StokMiktari < 10 AND IsActive = 1";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    sayi = (int)cmd.ExecuteScalar();
                }
            }
            return sayi;
        }

        // 3. En Çok Satan 5 Ürün (Bu Hafta)
        public DataTable GetEnCokSatanUrunler()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = DbHelper.GetConnection())
            {
                // SatışDetaylari ve Urunler tablolarını birleştir, miktarları topla, en çok satan ilk 5'i al
                string query = @"
                    SELECT TOP 5
                        U.UrunAdi,
                        SUM(SD.Miktar) AS ToplamSatilanAdet
                    FROM SatisDetaylari SD
                    INNER JOIN Urunler U ON SD.UrunID = U.UrunID
                    GROUP BY U.UrunAdi
                    ORDER BY ToplamSatilanAdet DESC";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }
    }
}