using System;
using System.Windows.Forms;
using SecureStock.Entities;
using SecureStock.BusinessLogic; // BLL katmanını kullanabilmek için ekledik

namespace SecureStock.UI
{
    public partial class Form1 : Form
    {
        // UI katmanı, sadece BLL (İş Yöneticisi) ile iletişim kurar
        private KullaniciBLL _kullaniciBLL = new KullaniciBLL();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Ekrandaki verileri al
                string kadi = txtKullaniciAdi.Text;
                string sifre = txtSifre.Text;

                // 2. İş Katmanına (BLL) sor: Bu adam içeri girebilir mi?
                Kullanici aktifKullanici = _kullaniciBLL.GirisKontrol(kadi, sifre);

                // 3. Eğer buraya kadar kod hata (Exception) fırlatmadan geldiyse, giriş başarılıdır!
                MessageBox.Show($"Sisteme Hoşgeldiniz, {aktifKullanici.KullaniciAdi}!\nYetki: {aktifKullanici.Rol}", "Giriş Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // TODO: İleride burada ana sayfayı (Kasa ekranını) açıp, bu login formunu gizleyeceğiz.
                // AnaForm'u yarat ve aktif kullanıcı verisini (kimlik kartını) içine fırlat
                AnaForm anaEkran = new AnaForm(aktifKullanici);
                anaEkran.Show(); // Yeni ekranı göster

                // Eski giriş ekranını (Form1) gizle
                this.Hide();
            }
            catch (Exception ex)
            {
                // BLL'den fırlatılan "Şifre boş", "Kullanıcı bulunamadı" gibi hatalar burada yakalanıp ekrana basılır.
                MessageBox.Show(ex.Message, "Güvenlik Uyarısı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}