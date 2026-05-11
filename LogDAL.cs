using System.Data;
using System.Data.SqlClient;

namespace SecureStock.DataAccess
{
    public class LogDAL
    {
        // Arayüze direkt tablo döndürmek için DataTable kullanıyoruz
        public DataTable TumLoglariGetir()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = DbHelper.GetConnection())
            {
                // IslemLoglari tablosunu Kullanicilar tablosuyla birleştiriyoruz (JOIN)
                string query = @"SELECT L.LogID, K.KullaniciAdi, L.IslemTipi, L.TabloAdi, L.Aciklama, L.Tarih 
                                 FROM IslemLoglari L 
                                 INNER JOIN Kullanicilar K ON L.KullaniciID = K.KullaniciID 
                                 ORDER BY L.Tarih DESC"; // En son yapılan işlem en üstte görünsün

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt); // Veritabanından gelen veriyi DataTable'a doldur
                    }
                }
            }
            return dt;
        }
    }
}