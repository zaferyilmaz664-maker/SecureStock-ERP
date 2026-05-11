using System;
using System.Windows.Forms;
using SecureStock.BusinessLogic;

namespace SecureStock.UI
{
    public partial class LogForm : Form
    {
        private LogBLL _logBLL = new LogBLL();
        private string _aktifKullaniciRolu;

        // Form açılırken kimin girmeye çalıştığını (Rolünü) zorla istiyoruz.
        public LogForm(string rol)
        {
            InitializeComponent();
            _aktifKullaniciRolu = rol;
        }

        private void LogForm_Load(object sender, EventArgs e)
        {
            try
            {
                // BLL'ye rolü gönder. Kasiyerse BLL hata fırlatacak ve catch bloğuna düşecek.
                dgvLoglar.DataSource = _logBLL.LoglariListele(_aktifKullaniciRolu);

                // Tablo sütunlarının ekrana tam sığması için görsel bir ayar
                dgvLoglar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                // BLL'den gelen o "Kritik Güvenlik İhlali" tokadını ekrana basıyoruz!
                MessageBox.Show(ex.Message, "Erişim Reddedildi", MessageBoxButtons.OK, MessageBoxIcon.Hand);

                // Ve formun açılmasına izin vermeden anında kapatıp onu kapı dışarı ediyoruz.
                this.Close();
            }
        }
    }
}