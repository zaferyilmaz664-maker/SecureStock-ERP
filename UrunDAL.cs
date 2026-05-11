using System;
using System.Data.SqlClient;
using SecureStock.Entities;

namespace SecureStock.DataAccess
{
    public class UrunDAL
    {
        public Urun GetirBarkodIle(string barkod)
        {
            Urun bulunanUrun = null;

            using (SqlConnection conn = DbHelper.GetConnection())
            {
                // Sadece silinmemiş (IsActive=1) ürünleri getiriyoruz.
                string query = "SELECT * FROM Urunler WHERE Barkod = @Barkod AND IsActive = 1";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Barkod", barkod);
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            bulunanUrun = new Urun
                            {
                                UrunID = Convert.ToInt32(reader["UrunID"]),
                                KategoriID = Convert.ToInt32(reader["KategoriID"]),
                                Barkod = reader["Barkod"].ToString(),
                                UrunAdi = reader["UrunAdi"].ToString(),
                                StokMiktari = Convert.ToInt32(reader["StokMiktari"]),
                                BirimFiyat = Convert.ToDecimal(reader["BirimFiyat"]),
                                IsActive = Convert.ToBoolean(reader["IsActive"])
                            };
                        }
                    }
                }
            }
            return bulunanUrun;
        }
    }
}