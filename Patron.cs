using System;
using System.Data;
using System.Windows.Forms;
using SecureStock.BusinessLogic;

namespace SecureStock.UI
{
    public partial class PatronForm : Form
    {
        private PatronBLL _patronBLL = new PatronBLL();
        private string _aktifKullaniciRolu;

        public PatronForm(string rol)
        {
            InitializeComponent();
            _aktifKullaniciRolu = rol;
        }

        private void PatronForm_Load(object sender, EventArgs e)
        {
            try
            {
                // 1. Günlük Ciroyu Çek ve Para Formatında Yazdır (Örn: ₺15.850,50)
                decimal ciro = _patronBLL.GunlukCiroGetir(_aktifKullaniciRolu);
                lblGunlukCiro.Text = ciro.ToString("C2");

                // 2. Kritik Stok Sayısını Çek (Eğer tükenen ürün varsa rengi kırmızı yapıp patronu uyar!)
                int kritikStok = _patronBLL.KritikStokSayisiGetir(_aktifKullaniciRolu);
                lblKritikStok.Text = $"{kritikStok} Ürün";
                if (kritikStok > 0)
                {
                    lblKritikStok.ForeColor = System.Drawing.Color.Red;
                }

                // 3. En Çok Satanları Çek ve Modern Grafiğe (Chart) Aktar
                DataTable dtEnCokSatanlar = _patronBLL.EnCokSatanlariGetir(_aktifKullaniciRolu);

                chartEnCokSatanlar.Series.Clear(); // Varsayılan grafiği temizle
                chartEnCokSatanlar.Series.Add("SatisAdedi");
                chartEnCokSatanlar.Series["SatisAdedi"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column; // Sütun grafiği tipi
                chartEnCokSatanlar.Series["SatisAdedi"].IsValueShownAsLabel = true; // Sütunların tepesinde sayılar yazsın

                foreach (DataRow row in dtEnCokSatanlar.Rows)
                {
                    string urunAdi = row["UrunAdi"].ToString();
                    int adet = Convert.ToInt32(row["ToplamSatilanAdet"]);
                    chartEnCokSatanlar.Series["SatisAdedi"].Points.AddXY(urunAdi, adet); // X ekseni Ürün Adı, Y ekseni Adet
                }
            }
            catch (Exception ex)
            {
                // Kasiyer girmeye çalıştıysa tokatla ve ekranı kapat!
                MessageBox.Show(ex.Message, "Güvenlik İhlali", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                this.Close();
            }
        }

        private void PatronForm_Load_1(object sender, EventArgs e)
        {

        }

        private void btnYeniPersonel_Click(object sender, EventArgs e)
        {
            // İşlemi yapan patronun rütbesini yeni forma fırlatıyoruz ki BLL kimin işlem yaptığını bilsin
            PersonelEkleForm personelForm = new PersonelEkleForm(_aktifKullaniciRolu);
            personelForm.ShowDialog();
        }
    }
}