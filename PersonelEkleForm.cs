using System;
using System.Windows.Forms;
using SecureStock.BusinessLogic;

namespace SecureStock.UI
{
    public partial class PersonelEkleForm : Form
    {
        private KullaniciBLL _kullaniciBLL = new KullaniciBLL();
        private string _islemYapanRol; // Bu formu açan adamın rütbesi

        public PersonelEkleForm(string rol)
        {
            InitializeComponent();
            _islemYapanRol = rol;

            // Kasiyerlerin sistemi manipüle etmesini önlemek için form açılırken rolleri koda gömüyoruz
            cmbRol.Items.Add("Kasiyer");
            cmbRol.Items.Add("Yönetici");
            cmbRol.SelectedIndex = 0; // Kaza çıkmasın diye varsayılan olarak en düşük yetki (Kasiyer) seçili gelsin
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Arayüzden (TextBox'lardan) verileri topla
                string kAdi = txtKullaniciAdi.Text;
                string sifre = txtSifre.Text;

                // ComboBox'tan seçili rolü al (Seçim yapılmadıysa patlamaması için kontrol eklendi)
                if (cmbRol.SelectedItem == null)
                {
                    MessageBox.Show("Lütfen personele bir rol atayın!", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // İşlemi burada kes
                }
                string yeniRol = cmbRol.SelectedItem.ToString();

                // 2. İş mantığına (BLL) veriyi gönder. Kimin işlem yaptığını (_islemYapanRol) da yolluyoruz ki yetkisi yoksa tokatlasın.
                if (_kullaniciBLL.YeniPersonelKaydet(_islemYapanRol, kAdi, sifre, yeniRol))
                {
                    // 3. Başarılıysa ekranı temizle ve yeni kayıt için hazırla
                    MessageBox.Show("Yeni personel sisteme başarıyla eklendi ve şifresi kriptolandı!", "Kayıt Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtKullaniciAdi.Clear();
                    txtSifre.Clear();
                    txtKullaniciAdi.Focus(); // İmleci tekrar kullanıcı adı kutusuna at
                }
            }
            catch (Exception ex)
            {
                // BLL katmanından fırlatılan tüm hatalar (boş bırakma, yetkisizlik vb.) buraya düşer
                MessageBox.Show(ex.Message, "Kayıt Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}