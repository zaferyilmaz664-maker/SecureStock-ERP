using System;
using System.Data.SqlClient;
using SecureStock.Entities;

namespace SecureStock.DataAccess
{
    public class KullaniciDAL
    {
        // 1. MEVCUT METOD: SİSTEME GİRİŞ YAPMA (LOGIN)
        public Kullanici GirisYap(string kullaniciAdi, string sifreHash)
        {
            Kullanici aktifKullanici = null;

            using (SqlConnection conn = DbHelper.GetConnection())
            {
                string query = "SELECT * FROM Kullanicilar WHERE KullaniciAdi = @Kadi AND SifreHash = @Sifre AND IsActive = 1";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Kadi", kullaniciAdi);
                    cmd.Parameters.AddWithValue("@Sifre", sifreHash);

                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            aktifKullanici = new Kullanici
                            {
                                KullaniciID = Convert.ToInt32(reader["KullaniciID"]),
                                KullaniciAdi = reader["KullaniciAdi"].ToString(),
                                SifreHash = reader["SifreHash"].ToString(),
                                Rol = reader["Rol"].ToString(),
                                IsActive = Convert.ToBoolean(reader["IsActive"])
                            };
                        }
                    }
                }
            }

            return aktifKullanici;
        }

        // 2. YENİ EKLENEN METOD: SİSTEME YENİ PERSONEL KAYDETME
        public bool KullaniciEkle(Kullanici yeniKullanici)
        {
            using (SqlConnection conn = DbHelper.GetConnection())
            {
                // Yeni kayıt atarken IsActive varsayılan olarak 1 (Aktif) gönderiliyor
                string query = "INSERT INTO Kullanicilar (KullaniciAdi, SifreHash, Rol, IsActive) VALUES (@Kadi, @Sifre, @Rol, 1)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Kadi", yeniKullanici.KullaniciAdi);
                    cmd.Parameters.AddWithValue("@Sifre", yeniKullanici.SifreHash);
                    cmd.Parameters.AddWithValue("@Rol", yeniKullanici.Rol);

                    conn.Open();
                    int etkilenenSatir = cmd.ExecuteNonQuery();
                    return etkilenenSatir > 0;
                }
            }
        }
    }
}