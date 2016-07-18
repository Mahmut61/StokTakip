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
    public partial class AnaSayfa : Form
    {
        public AnaSayfa()
        {
            InitializeComponent();
        }

        private void mitmCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mitmUrunKartlari_Click(object sender, EventArgs e)
        {
            Genel.urunsayfano = 0;
            UrunIslemleri frm = new UrunIslemleri();
            FormAcikmi(frm);
        }

        private void FormAcikmi(Form AcilacakForm)
        {
            bool Acikmi = false;
            for (int i = 0; i < this.MdiChildren.Count(); i++)
            {
                if (AcilacakForm.Name == this.MdiChildren[i].Name)
                {
                    this.MdiChildren[i].Focus();
                    Acikmi = true;
                }
            }
            if (Acikmi == false)
            {
                AcilacakForm.MdiParent = this;
                AcilacakForm.Show();
            }
            else { AcilacakForm.Dispose(); }
        }

        private void mitmStokSorgulama_Click(object sender, EventArgs e)
        {
            Genel.urunsayfano = 2;
            UrunIslemleri frm = new UrunIslemleri();
            FormAcikmi(frm);
        }

        private void mitmStokGirisCikis_Click(object sender, EventArgs e)
        {
            Genel.urunsayfano = 1;
            UrunIslemleri frm = new UrunIslemleri();
            FormAcikmi(frm);
        }

        private void mitmGunlukKasa_Click(object sender, EventArgs e)
        {
            KasaIslemleri frm = new KasaIslemleri();
            FormAcikmi(frm);
        }

        private void mitmCariEkstre_Click(object sender, EventArgs e)
        {
            CariEkstre frm = new CariEkstre();
            FormAcikmi(frm);
        }
    }
}
