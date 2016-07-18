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
    public partial class KasaIslemleri : Form
    {
        public KasaIslemleri()
        {
            InitializeComponent();
        }

        private void KasaIslemleri_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            txtTarih.Text = DateTime.Now.ToShortDateString();
        }
        private void dtpTarih_ValueChanged(object sender, EventArgs e)
        {
            txtTarih.Text = dtpTarih.Value.ToShortDateString();
        }

        private void txtTarih_TextChanged(object sender, EventArgs e)
        {
            Kasa k = new Kasa();
            k.KasaDevirleriGetir(txtTarih.Text, txtDevirGiren, txtDevirCikan, txtDevirBakiye);
            k.KasaHareketleriGetirByTarih(txtTarih.Text, lvHareketler, txtToplamGiren, txtToplamCikan, txtBakiye);
        }

        private void btnYeni_Click(object sender, EventArgs e)
        {
            btnKaydet.Enabled = true;
            btnDegistir.Enabled = false;
            btnSil.Enabled = false;
            Temizle();
        }
        private void Temizle()
        {
            txtID.Clear();
            txtIslemTarihi.Text = txtTarih.Text;
            txtIslemTuru.Clear();
            txtCariUnvan.Clear();
            txtCariNo.Clear();
            txtBelge.Clear();
            txtGiren.Text = "0";
            txtCikan.Text = "0";
            txtPara.Text = "TL";
            txtIslemTuru.Focus();
        }

        private void cbIslemTurleri_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtIslemTuru.Text = cbIslemTurleri.SelectedItem.ToString();
            CariSorgulama frm = new CariSorgulama();
            frm.StartPosition = FormStartPosition.CenterScreen;
            if (txtIslemTuru.Text == "Tahsilat")
            {
                Genel.caritipi = "Alıcı";
                txtGiren.ReadOnly = false;
                txtCikan.ReadOnly = true;
            }
            else if (txtIslemTuru.Text == "Ödeme")
            {
                Genel.caritipi = "Satıcı";
                txtGiren.ReadOnly = true;
                txtCikan.ReadOnly = false;
            }
            frm.ShowDialog();
            txtCariNo.Text = Genel.carino.ToString();
            txtCariUnvan.Text = Genel.cariunvan;
            txtBelge.Focus();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (txtIslemTuru.Text.Trim() != "" && txtCariUnvan.Text.Trim() != "")
            {
                if (txtGiren.Text == "0" && txtCikan.Text == "0")
                {
                    MessageBox.Show("Mutlaka Tutar girmelisiniz!"); txtGiren.Focus();
                }
                else
                {
                    Kasa k = new Kasa();
                    k.IslemTuru = txtIslemTuru.Text;
                    k.Tarih = Convert.ToDateTime(txtIslemTarihi.Text);
                    k.CariNo = Convert.ToInt32(txtCariNo.Text);
                    k.Belge = txtBelge.Text;
                    k.Giren = Convert.ToDouble(txtGiren.Text);
                    k.Cikan = Convert.ToDouble(txtCikan.Text);
                    int kayitno = k.KasaHareketEkle(k);
                    if (kayitno > 0)
                    {
                        MessageBox.Show("Kasa Hareketi eklendi.");
                        k.KasaHareketleriGetirByTarih(txtTarih.Text, lvHareketler, txtToplamGiren, txtToplamCikan, txtBakiye);
                        //CariHareket eklenecek...
                        CariHareket ch = new CariHareket();
                        ch.Tarih = k.Tarih;
                        ch.IslemTuru = k.IslemTuru;
                        ch.CariNo = k.CariNo;
                        ch.Belge = k.Belge;
                        if (txtIslemTuru.Text == "Tahsilat")
                        {
                            ch.Borc = 0;
                            ch.Alacak = k.Giren;
                        }
                        else if (txtIslemTuru.Text == "Ödeme")
                        {
                            ch.Borc = k.Cikan;
                            ch.Alacak = 0;
                        }
                        ch.KasaHareketID = kayitno;
                        ch.UrunHareketID = 0;
                        if (ch.CariHareketEkle(ch))
                        {
                            MessageBox.Show("Cari Hareket Bilgisi eklendi!");
                            //carinin toplam bakiyelerini düzenlenecek...(Cariler)
                            Cari c = new Cari();
                            bool Sonuc = c.CariToplamlariGuncelle(ch.CariNo, ch.Borc, ch.Alacak);
                            if (Sonuc)
                            {
                                MessageBox.Show("Cari Bakiyeler güncellendi!");
                                btnKaydet.Enabled = false;
                                Temizle();
                            }
                            else
                                MessageBox.Show("Cari Bakiyeler değiştirilemedi!");
                        }
                        else MessageBox.Show("Cari Hareketler eklenemedi!");
                    }
                }
            }
            else { MessageBox.Show("İşlem Türü ve Cari mutlaka seçilmelidir!", "Eksik Bilgi!"); txtIslemTuru.Focus(); }
        }

        private void lvHareketler_DoubleClick(object sender, EventArgs e)
        {
            btnKaydet.Enabled = false;
            btnSil.Enabled = true;
            txtID.Text = lvHareketler.SelectedItems[0].SubItems[0].Text;
            txtIslemTarihi.Text = lvHareketler.SelectedItems[0].SubItems[1].Text;
            txtIslemTuru.Text = lvHareketler.SelectedItems[0].SubItems[2].Text;
            txtCariUnvan.Text = lvHareketler.SelectedItems[0].SubItems[3].Text;
            txtBelge.Text = lvHareketler.SelectedItems[0].SubItems[4].Text;
            txtGiren.Text = lvHareketler.SelectedItems[0].SubItems[5].Text;
            txtCikan.Text = lvHareketler.SelectedItems[0].SubItems[6].Text;
            txtPara.Text = lvHareketler.SelectedItems[0].SubItems[7].Text;
            txtCariNo.Text = lvHareketler.SelectedItems[0].SubItems[8].Text;
        }
        private void btnSil_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Kasa Hareketi İptal etmek istiyor musunuz?", "SİLİNSİN Mİ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                Kasa k = new Kasa();
                bool Sonuc = k.KasaHareketSil(Convert.ToInt32(txtID.Text));
                if (Sonuc)
                {
                    MessageBox.Show("Kasa Hareket bilgisi silindi.");
                    k.KasaHareketleriGetirByTarih(txtTarih.Text, lvHareketler, txtToplamGiren, txtToplamCikan, txtBakiye);
                    CariHareket ch = new CariHareket();
                    Sonuc = ch.CariHareketSilByKasaHareket(Convert.ToInt32(txtID.Text));
                    double Borc = 0;
                    double Alacak = 0;
                    if (Sonuc)
                    {
                        MessageBox.Show("Cari Hareket Silindi!");
                        if (txtIslemTuru.Text == "Tahsilat")
                        {
                            Borc = 0;
                            Alacak = (-1) * Convert.ToDouble(txtGiren.Text);
                        }
                        else if (txtIslemTuru.Text == "Ödeme")
                        {
                            Borc = (-1) * Convert.ToDouble(txtCikan.Text);
                            Alacak = 0;
                        }
                        //Carinin toplam bakiyeleri düzenlenecek...(Cariler)
                        Cari c = new Cari();
                        Sonuc = c.CariToplamlariGuncelle(Convert.ToInt32(txtCariNo.Text), Borc, Alacak);
                        if (Sonuc)
                        {
                            MessageBox.Show("Cari Bakiyeler güncellendi!");
                            btnSil.Enabled = false;
                            Temizle();
                        }
                        else
                            MessageBox.Show("Cari Bakiyeler değiştirilemedi!");
                    }
                    else MessageBox.Show("Cari Hareketler silinemedi!");
                }
                else MessageBox.Show("Kasa Hareket silinemedi!");
            }
        }
    }
}
