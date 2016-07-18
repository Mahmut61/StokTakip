using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using wfStokTakibi.Model;

namespace wfStokTakibi
{
    public partial class UrunIslemleri : Form
    {
        public UrunIslemleri()
        {
            InitializeComponent();
        }
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        BindingSource bs;

        private void UrunIslemleri_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;

            DataBagla();
            Konum();

            Urun u = new Urun();
            u.UrunleriGetir(lvUrunler);

            Kategori k = new Kategori();
            k.KategorileriGetir(cbKategoriler);
            k.KategorileriGetir(cbKategori);

            tabControl1.SelectedIndex = Genel.urunsayfano;
        }
        private void DataBagla()
        {
            Urun u = new Urun();
            ds = u.UrunleriGetir();
            bs = new BindingSource();
            bs.DataSource = ds.Tables["Urunler"];

            txtUrunKodu.DataBindings.Clear();
            txtUrunAdi.DataBindings.Clear();
            txtUrunID.DataBindings.Clear();
            txtKategori.DataBindings.Clear();
            txtKategoriNo.DataBindings.Clear();
            txtMiktar.DataBindings.Clear();
            txtFiyat.DataBindings.Clear();
            txtKritik.DataBindings.Clear();

            txtUrunKodu.DataBindings.Add("Text", bs, "UrunKodu");
            txtUrunAdi.DataBindings.Add("Text", bs, "UrunAd");
            txtUrunID.DataBindings.Add("Text", bs, "UrunID");
            txtKategori.DataBindings.Add("Text", bs, "KategoriAd");
            txtKategoriNo.DataBindings.Add("Text", bs, "KategoriNo");
            txtMiktar.DataBindings.Add("Text", bs, "Miktar");
            txtFiyat.DataBindings.Add("Text", bs, "BirimFiyat");
            txtKritik.DataBindings.Add("Text", bs, "KritikSeviye");

            txtUrunKodu2.DataBindings.Clear();
            txtUrunAdi2.DataBindings.Clear();
            txtUrunID2.DataBindings.Clear();

            txtUrunKodu2.DataBindings.Add("Text", bs, "UrunKodu");
            txtUrunAdi2.DataBindings.Add("Text", bs, "UrunAd");
            txtUrunID2.DataBindings.Add("Text", bs, "UrunID");
        }
        private void Konum()
        {
            lblKonum.Text = (bs.Position + 1) + " / " + bs.Count;
            UrunHareket uh = new UrunHareket();
            uh.UrunHareketleriGetir(lvHareketler, Convert.ToInt32(txtUrunID.Text));
        }
        private void btnFirst_Click(object sender, EventArgs e)
        {
            bs.Position = 0;
            Konum();
        }
        private void btnPrev_Click(object sender, EventArgs e)
        {
            bs.Position -= 1;
            Konum();
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            bs.Position += 1;
            Konum();
        }
        private void btnLast_Click(object sender, EventArgs e)
        {
            bs.Position = bs.Count - 1;
            Konum();
        }

        private void cbKategoriler_SelectedIndexChanged(object sender, EventArgs e)
        {
            Kategori k = (Kategori)cbKategoriler.SelectedItem;
            txtKategori.Text = k.KategoriAd;
            txtKategoriNo.Text = k.KategoriNo.ToString();
            txtKritik.Focus();
        }

        private void tsYeni_Click(object sender, EventArgs e)
        {
            tsKaydet.Enabled = true;
            tsDegistir.Enabled = false;
            tsSil.Enabled = false;
            bs.AddNew();
            txtUrunKodu.Focus();
        }

        private void tsKaydet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUrunKodu.Text) || string.IsNullOrEmpty(txtUrunAdi.Text) || string.IsNullOrEmpty(txtKategori.Text))
            {
                MessageBox.Show("Ürün Kodu, Adı ve Kategori boş bırakılamaz.");
                txtUrunKodu.Focus();
            }
            else
            {
                Urun u = new Urun();
                if (u.UrunKontrol(txtUrunKodu.Text, txtUrunAdi.Text))
                {
                    MessageBox.Show("Bu ürün zaten stokta kayıtlı!");
                    txtUrunKodu.Focus();
                }
                else
                {
                    bs.EndEdit();
                    u.UrunKodu = txtUrunKodu.Text;
                    u.UrunAd = txtUrunAdi.Text;
                    u.KategoriNo = Convert.ToInt32(txtKategoriNo.Text);
                    if(string.IsNullOrEmpty(txtKritik.Text))txtKritik.Text = "0";
                    u.KritikSeviye = Convert.ToInt32(txtKritik.Text);
                    if (string.IsNullOrEmpty(txtFiyat.Text)) txtFiyat.Text = "0";
                    u.BirimFiyat = Convert.ToDouble(txtFiyat.Text);
                    if (u.UrunEkle(u))
                    {
                        MessageBox.Show("Ürün Bilgileri kayıt edildi.");
                        u.UrunleriGetir(lvUrunler);
                        DataBagla();
                        Konum();
                        tsDegistir.Enabled = true;
                        tsSil.Enabled = true;
                    }
                    else { MessageBox.Show("Kayıt işleminde sorunla karşılaşıldı!"); }
                }
            }
        }

        private void tsVazgec_Click(object sender, EventArgs e)
        {
            bs.CancelEdit();
            tsDegistir.Enabled = true;
            tsSil.Enabled = true;
            tsKaydet.Enabled = false;
            Konum();
        }

        private void lvUrunler_DoubleClick(object sender, EventArgs e)
        {
            Urun u = new Urun();
            int kacinci = u.KacinciKayit(Convert.ToInt32(lvUrunler.SelectedItems[0].SubItems[7].Text));
            bs.Position = kacinci;
            Konum();
        }

        private void txtKodaGore_TextChanged(object sender, EventArgs e)
        {
            Urun u = new Urun();
            u.UrunleriGetirByKodaGore(txtKodaGore.Text, lvUrunler);
        }

        private void txtAdaGore_TextChanged(object sender, EventArgs e)
        {
            Urun u = new Urun();
            u.UrunleriGetirByAdaGore(txtAdaGore.Text, lvUrunler);
        }

        private void tsDegistir_Click(object sender, EventArgs e)
        {
            Urun u = new Urun();
            if (u.UrunKontrol(txtUrunKodu.Text, txtUrunAdi.Text, Convert.ToInt32(txtUrunID.Text)))
            {
                MessageBox.Show("Önceden Tanımlı Böyle Bir Ürün Zaten Mevcut!");
                txtUrunKodu.Focus();
            }
            else
            {
                bs.EndEdit();
                u.UrunID = Convert.ToInt32(txtUrunID.Text);
                u.UrunKodu = txtUrunKodu.Text;
                u.UrunAd = txtUrunAdi.Text;
                u.KategoriNo = Convert.ToInt32(txtKategoriNo.Text);
                if (string.IsNullOrEmpty(txtKritik.Text)) txtKritik.Text = "0";
                u.KritikSeviye = Convert.ToInt32(txtKritik.Text);
                if (string.IsNullOrEmpty(txtFiyat.Text)) txtFiyat.Text = "0";
                u.BirimFiyat = Convert.ToDouble(txtFiyat.Text);
                if (u.UrunGuncelle(u))
                {
                    MessageBox.Show("Ürün Bilgileri değiştirildi.");
                    u.UrunleriGetir(lvUrunler);
                    DataBagla();
                    Konum();
                }
                else { MessageBox.Show("Kayıt işleminde sorunla karşılaşıldı!"); }
            }
        }

        private void tsSil_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Silmek İstiyor musunuz?", "SİLİNSİN Mİ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Urun u = new Urun();
                bool Sonuc = u.UrunSil(Convert.ToInt32(txtUrunID.Text));
                if (Sonuc)
                {
                    MessageBox.Show("Ürün Bilgileri silindi.");
                    u.UrunleriGetir(lvUrunler);
                    DataBagla();
                    Konum();
                }
                else { MessageBox.Show("Silme işleminde sorunla karşılaşıldı!"); }
            }
        }

        private void dtpTarih_ValueChanged(object sender, EventArgs e)
        {
            txtTarih.Text = dtpTarih.Value.ToShortDateString();
        }

        private void cbIslemTurleri_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtIslemTuru.Text = cbIslemTurleri.SelectedItem.ToString();
        }

        private void txtBirimFiyat_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtAdet.Text)) { txtAdet.Text = "1"; txtAdet.Select(0, txtAdet.Text.Length); }
            if (string.IsNullOrEmpty(txtBirimFiyat.Text)) { txtBirimFiyat.Text = "0"; txtBirimFiyat.Select(0, txtBirimFiyat.Text.Length); }
            txtTutar.Text = (Convert.ToInt32(txtAdet.Text) * Convert.ToDouble(txtBirimFiyat.Text)).ToString();
        }

        private void txtAdet_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtAdet.Text)) { txtAdet.Text = "1"; txtAdet.Select(0, txtAdet.Text.Length); }
            if (string.IsNullOrEmpty(txtBirimFiyat.Text)) { txtFiyat.Text = "0"; txtBirimFiyat.Select(0, txtBirimFiyat.Text.Length); }
            txtTutar.Text = (Convert.ToInt32(txtAdet.Text) * Convert.ToDouble(txtBirimFiyat.Text)).ToString();
        }

        private void btnFirmaBul_Click(object sender, EventArgs e)
        {
            CariSorgulama frm = new CariSorgulama();
            frm.StartPosition = FormStartPosition.CenterScreen;
            if (txtIslemTuru.Text == "Stok Giriş")
                Genel.caritipi = "Satıcı";
            else
                Genel.caritipi = "Alıcı";
            frm.ShowDialog();
            txtCariNo.Text = Genel.carino.ToString();
            txtFirma.Text = Genel.cariunvan;
        }
        private void Temizle()
        {
            txtBelge.Clear();
            txtBirim.Text = "Adet";
            txtAdet.Text = "1";
        }
        private void btnYeni_Click(object sender, EventArgs e)
        {
            btnKaydet.Enabled = true;
            btnDegistir.Enabled = false;
            btnSil.Enabled = false;
            txtTarih.Text = DateTime.Now.ToShortDateString();
            cbIslemTurleri.SelectedIndex = 1;
            txtBirimFiyat.Text = txtFiyat.Text;
            Temizle();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (txtFirma.Text.Trim() != "")
            {
                if (txtIslemTuru.Text == "Stok Çıkış" && Convert.ToInt32(txtAdet.Text) > Convert.ToInt32(txtMiktar.Text))
                {
                    MessageBox.Show("Stok Yeterli değil!");
                }
                else
                {
                    //UrunHareket bilgileri kayıt edilecek...(UrunHareketler)
                    UrunHareket uh = new UrunHareket();
                    uh.Tarih = Convert.ToDateTime(txtTarih.Text);
                    uh.IslemTuru = txtIslemTuru.Text;
                    uh.FirmaNo = Convert.ToInt32(txtCariNo.Text);
                    uh.UrunID = Convert.ToInt32(txtUrunID2.Text);
                    uh.Belge = txtBelge.Text;
                    uh.Birim = txtBirim.Text;
                    uh.Adet = Convert.ToInt32(txtAdet.Text);
                    uh.BirimFiyat = Convert.ToDouble(txtBirimFiyat.Text);
                    int kayitno = uh.UrunHareketEkle(uh);
                    if (kayitno > 0)
                    {
                        MessageBox.Show("Ürün Hareket bilgisi eklendi.");
                        uh.UrunHareketleriGetir(lvHareketler, uh.UrunID);
                        //Alınan yada satılan ürünün stok miktarı güncellenecek...(Urunler)
                        Urun u = new Urun();
                        bool Sonuc = u.UrunStokGuncelleFromUrunHareketEkle(uh.UrunID, uh.Adet, uh.IslemTuru);
                        if (Sonuc)
                        {
                            MessageBox.Show("Stok güncellendi!");
                            //Ürünü aldığımız yada sattığımız cariye carihareket bilgisi kayıt edilecek...(CariHareketler)
                            CariHareket ch = new CariHareket();
                            ch.Tarih = Convert.ToDateTime(txtTarih.Text);
                            ch.IslemTuru = txtIslemTuru.Text;
                            ch.CariNo = Convert.ToInt32(txtCariNo.Text);
                            ch.Belge = txtBelge.Text;
                            if (txtIslemTuru.Text == "Stok Giriş")
                            {
                                ch.Borc = 0;
                                ch.Alacak = Convert.ToDouble(txtTutar.Text);
                            }
                            else
                            {
                                ch.Borc = Convert.ToDouble(txtTutar.Text);
                                ch.Alacak = 0;
                            }
                            ch.KasaHareketID = 0;
                            ch.UrunHareketID = kayitno;
                            if (ch.CariHareketEkle(ch))
                            {
                                MessageBox.Show("Cari Hareket Bilgisi eklendi!");
                                //Ürünü aldığımız yada sattığımız carinin toplam bakiyelerini düzenlenecek...(Cariler)
                                Cari c = new Cari();
                                Sonuc = c.CariToplamlariGuncelle(ch.CariNo, ch.Borc, ch.Alacak);
                                if (Sonuc)
                                    MessageBox.Show("Cari Bakiyeler güncellendi!");
                                else
                                    MessageBox.Show("Cari Bakiyeler değiştirilemedi!");
                            }
                            else MessageBox.Show("Cari Hareketler eklenemedi!");
                        }
                        else MessageBox.Show("Stok güncellenemedi!");
                    }
                    else MessageBox.Show("Ürün Hareket eklenemedi!");
                }
            }
            else MessageBox.Show("Firma seçmelisiniz!");
        }

        private void lvHareketler_DoubleClick(object sender, EventArgs e)
        {
            btnSil.Enabled = true;
            btnKaydet.Enabled = false;
            txtTarih.Text = lvHareketler.SelectedItems[0].SubItems[0].Text;
            txtIslemTuru.Text = lvHareketler.SelectedItems[0].SubItems[1].Text;
            txtFirma.Text = lvHareketler.SelectedItems[0].SubItems[2].Text;
            txtBelge.Text = lvHareketler.SelectedItems[0].SubItems[3].Text;
            txtBirimFiyat.Text = lvHareketler.SelectedItems[0].SubItems[4].Text;
            txtAdet.Text = lvHareketler.SelectedItems[0].SubItems[5].Text;
            txtTutar.Text = lvHareketler.SelectedItems[0].SubItems[6].Text;
            txtHareketID.Text = lvHareketler.SelectedItems[0].SubItems[8].Text;
            txtCariNo.Text = lvHareketler.SelectedItems[0].SubItems[9].Text;
            txtBirim.Text = lvHareketler.SelectedItems[0].SubItems[10].Text;
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Ürün Hareketi İptal etmek istiyor musunuz?", "SİLİNSİN Mİ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                //UrunHareket bilgileri iptal edilecek...(UrunHareketler)
                UrunHareket uh = new UrunHareket();
                bool Sonuc = uh.UrunHareketSil(Convert.ToInt32(txtHareketID.Text));
                if (Sonuc)
                {
                    MessageBox.Show("Ürün Hareket bilgisi silindi.");
                    uh.UrunHareketleriGetir(lvHareketler, Convert.ToInt32(txtUrunID2.Text));
                    //İade edilen ürünün stok miktarı güncellenecek...(Urunler)
                    Urun u = new Urun();
                    Sonuc = u.UrunStokGuncelleFromUrunHareketSil(Convert.ToInt32(txtUrunID2.Text), Convert.ToInt32(txtAdet.Text), txtIslemTuru.Text);
                    if (Sonuc)
                    {
                        MessageBox.Show("Stok güncellendi!");
                        //Önceden kayıt edilen carihareket bilgisi iptal edilecek...(CariHareketler)
                        CariHareket ch = new CariHareket();
                        Sonuc = ch.CariHareketSilByUrunHareket(Convert.ToInt32(txtHareketID.Text));
                        double Borc = 0;
                        double Alacak = 0;
                        if (Sonuc)
                        {
                            MessageBox.Show("Cari Hareket Silindi!");
                            if (txtIslemTuru.Text == "Stok Giriş")
                            {
                                Borc = 0;
                                Alacak = (-1) * Convert.ToDouble(txtTutar.Text);
                            }
                            else
                            {
                                Borc = (-1) * Convert.ToDouble(txtTutar.Text);
                                Alacak = 0;
                            }
                            //Ürünü aldığımız yada sattığımız carinin toplam bakiyeleri düzenlenecek...(Cariler)
                            Cari c = new Cari();
                            Sonuc = c.CariToplamlariGuncelle(Convert.ToInt32(txtCariNo.Text), Borc, Alacak);
                            if (Sonuc)
                                MessageBox.Show("Cari Bakiyeler güncellendi!");
                            else
                                MessageBox.Show("Cari Bakiyeler değiştirilemedi!");
                        }
                        else MessageBox.Show("Cari Hareketler eklenemedi!");
                    }
                    else MessageBox.Show("Stok güncellenemedi!");
                }
                else MessageBox.Show("Ürün Hareket eklenemedi!");
            }
        }

        private void rbTumUrunler_CheckedChanged(object sender, EventArgs e)
        {
            Urun u = new Urun();
            ds = u.UrunleriGetirByTumu();
            dgvUrunler.DataSource = ds.Tables["Urunler"];
            int ToplamMiktar = 0;
            double ToplamTutar = 0;
            foreach (DataRow dr in ds.Tables["Urunler"].Rows)
            {
                ToplamMiktar += Convert.ToInt32(dr["Miktar"]);
                ToplamTutar += Convert.ToDouble(dr["Tutar"]);
            }
            txtToplamMiktar.Text = ToplamMiktar.ToString();
            //txtToplamTutar.Text = ToplamTutar.ToString();
            txtToplamTutar.Text = string.Format("{0:C}", ToplamTutar);
            GridViewDuzenle();
            dgvUrunler.Columns["UrunAd"].Width = 240;
            dgvUrunler.Columns["Tutar"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void rbKritikSeviye_CheckedChanged(object sender, EventArgs e)
        {
            Urun u = new Urun();
            ds = u.UrunleriGetirByKritikSeviye();
            dgvUrunler.DataSource = ds.Tables["Urunler"];
            int ToplamMiktar = 0;
            double ToplamTutar = 0;
            foreach (DataRow dr in ds.Tables["Urunler"].Rows)
            {
                ToplamMiktar += Convert.ToInt32(dr["SiparisMiktar"]);
                ToplamTutar += Convert.ToDouble(dr["SiparisTutar"]);
            }
            txtToplamMiktar.Text = ToplamMiktar.ToString();
            //txtToplamTutar.Text = ToplamTutar.ToString();
            txtToplamTutar.Text = string.Format("{0:C}", ToplamTutar);
            GridViewDuzenle();
            dgvUrunler.Columns["SiparisMiktar"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvUrunler.Columns["SiparisTutar"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void cbKategori_SelectedIndexChanged(object sender, EventArgs e)
        {
            Urun u = new Urun();
            ds = u.UrunleriGetirByKategori(cbKategori.SelectedItem.ToString());
            dgvUrunler.DataSource = ds.Tables["Urunler"];
            int ToplamMiktar = 0;
            double ToplamTutar = 0;
            foreach (DataRow dr in ds.Tables["Urunler"].Rows)
            {
                ToplamMiktar += Convert.ToInt32(dr["Miktar"]);
                ToplamTutar += Convert.ToDouble(dr["Tutar"]);
            }
            txtToplamMiktar.Text = ToplamMiktar.ToString();
            //txtToplamTutar.Text = ToplamTutar.ToString();
            txtToplamTutar.Text = string.Format("{0:C}", ToplamTutar);
            GridViewDuzenle();
            dgvUrunler.Columns["UrunAd"].Width = 240;
            dgvUrunler.Columns["Tutar"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }
        private void GridViewDuzenle()
        {
            dgvUrunler.Columns["UrunAd"].Width = 130;
            dgvUrunler.Columns["Miktar"].Width = 70;
            dgvUrunler.Columns["Miktar"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvUrunler.Columns["BirimFiyat"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvUrunler.Columns["KritikSeviye"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


        }
    }
}
