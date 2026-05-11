using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using SecureStock.Entities;

namespace SecureStock.DataAccess
{
    public class SatisDAL
    {
        public bool SatisYap(Satis yeniSatis, List<SatisDetay> detaylar)
        {
            using (SqlConnection conn = DbHelper.GetConnection())
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction(); // Mühürleme başlıyor!

                try
                {
                    // 1. Satislar Tablosuna Ekle ve yeni SatisID'yi al
                    string satisQuery = "INSERT INTO Satislar (KullaniciID, ToplamTutar, SatisTarihi, IsCancelled) OUTPUT INSERTED.SatisID VALUES (@Kid, @Tutar, @Tarih, 0)";
                    SqlCommand cmdSatis = new SqlCommand(satisQuery, conn, trans);
                    cmdSatis.Parameters.AddWithValue("@Kid", yeniSatis.KullaniciID);
                    cmdSatis.Parameters.AddWithValue("@Tutar", yeniSatis.ToplamTutar);
                    cmdSatis.Parameters.AddWithValue("@Tarih", DateTime.Now);
                    int yeniSatisID = (int)cmdSatis.ExecuteScalar();

                    foreach (var kalem in detaylar)
                    {
                        // 2. SatisDetaylari Tablosuna Ekle
                        string detayQuery = "INSERT INTO SatisDetaylari (SatisID, UrunID, Miktar, BirimFiyat) VALUES (@Sid, @Uid, @Miktar, @Fiyat)";
                        SqlCommand cmdDetay = new SqlCommand(detayQuery, conn, trans);
                        cmdDetay.Parameters.AddWithValue("@Sid", yeniSatisID);
                        cmdDetay.Parameters.AddWithValue("@Uid", kalem.UrunID);
                        cmdDetay.Parameters.AddWithValue("@Miktar", kalem.Miktar);
                        cmdDetay.Parameters.AddWithValue("@Fiyat", kalem.BirimFiyat);
                        cmdDetay.ExecuteNonQuery();

                        // 3. Stoktan Düş (İç tehdit koruması: Stok eksiye düşmemeli ama onu BLL'de kontrol edeceğiz)
                        string stokQuery = "UPDATE Urunler SET StokMiktari = StokMiktari - @Miktar WHERE UrunID = @Uid";
                        SqlCommand cmdStok = new SqlCommand(stokQuery, conn, trans);
                        cmdStok.Parameters.AddWithValue("@Miktar", kalem.Miktar);
                        cmdStok.Parameters.AddWithValue("@Uid", kalem.UrunID);
                        cmdStok.ExecuteNonQuery();
                    }

                    // 4. İşlem Logunu At (İşte senin o değiştirilemez denetim izin!)
                    string logQuery = "INSERT INTO IslemLoglari (KullaniciID, IslemTipi, TabloAdi, Aciklama, Tarih) VALUES (@Kid, 'SATIS', 'Satislar', @Aciklama, @Tarih)";
                    SqlCommand cmdLog = new SqlCommand(logQuery, conn, trans);
                    cmdLog.Parameters.AddWithValue("@Kid", yeniSatis.KullaniciID);
                    cmdLog.Parameters.AddWithValue("@Aciklama", $"{yeniSatisID} nolu satış başarıyla tamamlandı.");
                    cmdLog.Parameters.AddWithValue("@Tarih", DateTime.Now);
                    cmdLog.ExecuteNonQuery();

                    trans.Commit(); // Her şey tamamsa imzayı at, veritabanına işle!
                    return true;
                }
                catch (Exception)
                {
                    trans.Rollback(); // Bir hata varsa, hiçbir şey olmamış gibi her şeyi geri al!
                    throw;
                }
            }
        }
    }
}