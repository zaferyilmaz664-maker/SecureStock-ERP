using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SecureStock.Entities;
using SecureStock.BusinessLogic;

namespace SecureStock.UI
{
    public partial class AnaForm : Form
    {
        // 1. SINIF SEVİYESİNDEKİ GLOBAL NESNELER (SCOPE BURASI!)
        private Kullanici _girisYapanKullanici;
        private UrunBLL _urunBLL = new UrunBLL();
        private SatisBLL _satisBLL = new SatisBLL(); // O patlayan nesnenin doğru yeri burasıdır.

        // 2. YAPICI METOD (CONSTRUCTOR)
        public AnaForm(Kullanici aktifKullanici)
        {
            InitializeComponent();
            _girisYapanKullanici = aktifKullanici;
            SepetSutunlariniAyarla();
        }

        // 3. SEPET TASARIMINI KODLA ÇİZME
        private void SepetSutunlariniAyarla()
        {
            dgvSepet.ColumnCount = 5;
            dgvSepet.Columns[0].Name = "UrunID";
            dgvSepet.Columns[0].Visible = false; // Kasiyer ID falan görmez.
            dgvSepet.Columns[1].Name = "Ürün Adı";
            dgvSepet.Columns[2].Name = "Adet";
            dgvSepet.Columns[3].Name = "Birim Fiyat";
            dgvSepet.Columns[4].Name = "Toplam";

            // İç tehdit koruması: Kasiyer fiyatlarla veya adetlerle oynayamaz!
            dgvSepet.AllowUserToAddRows = false;
            dgvSepet.ReadOnly = true;
        }

        // 4. FORM AÇILIRKEN ÇALIŞACAK KOD
        private void AnaForm_Load(object sender, EventArgs e)
        {
            this.Text = $"SecureStock Ana Kasa | Aktif Personel: {_girisYapanKullanici.KullaniciAdi} - Yetki: {_girisYapanKullanici.Rol}";
        }

        // 5. BARKOD OKUYUCU DİNLENİYOR (ENTER TUŞU TETİĞİ)
        private void txtBarkod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Bip sesini yut

                try
                {
                    string okunanBarkod = txtBarkod.Text;

                    // BLL'den ürünü çek (Stok yoksa BLL hata fırlatacak)
                    Urun satilacakUrun = _urunBLL.SatisIcinUrunGetir(okunanBarkod);

                    // Ürünü sepete bas
                    dgvSepet.Rows.Add(satilacakUrun.UrunID, satilacakUrun.UrunAdi, 1, satilacakUrun.BirimFiyat, satilacakUrun.BirimFiyat);

                    ToplamTutariHesapla();
                    txtBarkod.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "İşlem Reddedildi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBarkod.SelectAll();
                }
            }
        }

        // 6. ANLIK TOPLAM TUTAR HESAPLAYICI
        private void ToplamTutariHesapla()
        {
            decimal genelToplam = 0;
            foreach (DataGridViewRow row in dgvSepet.Rows)
            {
                genelToplam += Convert.ToDecimal(row.Cells["Toplam"].Value);
            }
            lblToplamTutar.Text = genelToplam.ToString("0.00") + " TL";
        }

        // 7. SATIŞI BİTİRME VE SQL TRANSACTION TETİĞİ
        private void btnSatisTamamla_Click(object sender, EventArgs e)
        {
            try
            {
                // Satis nesnesini hazırla
                Satis yeniSatis = new Satis
                {
                    KullaniciID = _girisYapanKullanici.KullaniciID,
                    // Ekranda "15.50 TL" yazıyorsa " TL" kısmını atıp decimele çevirir
                    ToplamTutar = Convert.ToDecimal(lblToplamTutar.Text.Replace(" TL", "").Trim())
                };

                // Sepetteki ürünleri liste (koleksiyon) haline getir
                List<SatisDetay> detaylar = new List<SatisDetay>();
                foreach (DataGridViewRow row in dgvSepet.Rows)
                {
                    detaylar.Add(new SatisDetay
                    {
                        UrunID = (int)row.Cells["UrunID"].Value,
                        Miktar = (int)row.Cells["Adet"].Value,
                        BirimFiyat = (decimal)row.Cells["Birim Fiyat"].Value
                    });
                }

                // Asıl beyne (BLL) veriyi fırlat. SQL'e o yazacak.
                if (_satisBLL.SatisOnayla(yeniSatis, detaylar))
                {
                    MessageBox.Show("Satış Başarıyla Tamamlandı! Stoklar güncellendi ve log kaydı atıldı.", "Kasa İşlemi Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Yeni müşteri için kasayı temizle
                    dgvSepet.Rows.Clear();
                    lblToplamTutar.Text = "0.00 TL";
                    txtBarkod.Focus(); // İmleci tekrar barkod okuyucuya konumlandır
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Satış Hatası: " + ex.Message, "Kritik Sistem Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLoglariGor_Click(object sender, EventArgs e)
        {
            // Giriş yapan adamın rolünü kimlik kartı gibi yeni forma fırlatıyoruz
            LogForm logEkrani = new LogForm(_girisYapanKullanici.Rol);

            // DİKKAT: .Show() değil .ShowDialog() kullanıyoruz! 
            // ShowDialog, log ekranı açıkken arka planda kasada işlem yapılmasını kilitler. Profesyonel standart budur.
            logEkrani.ShowDialog();
        }

        private void btnPatronEkranı_Click(object sender, EventArgs e)
        {
            // Giriş yapan kullanıcının rolünü (Örn: "Admin") patron formuna fırlatıyoruz
            PatronForm patronEkrani = new PatronForm(_girisYapanKullanici.Rol);
            patronEkrani.ShowDialog();
        }
    }
}