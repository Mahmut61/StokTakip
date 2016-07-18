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
    public partial class CariEkstre : Form
    {
        public CariEkstre()
        {
            InitializeComponent();
        }

        Cari c = new Cari();
        CariHareket ch = new CariHareket();
        DataSet ds = new DataSet();

        private void CariEkstre_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            dtpIlkTarih.Value = DateTime.Now.AddMonths(-1);
            rbTumFirmalar.Checked = true;
        }

        private void rbAlicilar_CheckedChanged(object sender, EventArgs e)
        {
            Genel.caritipi = "Alıcı";
            ds = c.CarileriGetirByCariTipi(Genel.caritipi);
            dgvCariler.DataSource = ds.Tables["Cariler"];
            dgvCariler.Columns[0].Visible = false;
        }

        private void rbSaticilar_CheckedChanged(object sender, EventArgs e)
        {
            Genel.caritipi = "Satıcı";
            ds = c.CarileriGetirByCariTipi(Genel.caritipi);
            dgvCariler.DataSource = ds.Tables["Cariler"];
            dgvCariler.Columns[0].Visible = false;
        }

        private void rbTumFirmalar_CheckedChanged(object sender, EventArgs e)
        {
            Genel.caritipi = "";
            ds = c.CarileriGetirByCariTipi(Genel.caritipi);
            dgvCariler.DataSource = ds.Tables["Cariler"];
            dgvCariler.Columns[0].Visible = false;
        }
        private void dgvCariler_DoubleClick(object sender, EventArgs e)
        {
            Genel.carino = Convert.ToInt32(dgvCariler.SelectedRows[0].Cells[0].Value);
            ds = ch.HareketleriGetirByCariAndTarih(Genel.carino, dtpIlkTarih.Value, dtpSonTarih.Value);
            dgvHareketler.DataSource = ds.Tables["CariHareketler"];
        }

        private void btnFirmaBul_Click(object sender, EventArgs e)
        {
            CariSorgulama frm = new CariSorgulama();
            frm.StartPosition = FormStartPosition.CenterScreen;
            Genel.caritipi = "";
            frm.ShowDialog();
            txtCariNo.Text = Genel.carino.ToString();
            txtFirma.Text = Genel.cariunvan;
            ds = ch.HareketleriGetirByCariAndTarih(Genel.carino, dtpIlkTarih.Value, dtpSonTarih.Value);
            dgvHareketler.DataSource = ds.Tables["CariHareketler"];
        }

        private void dtpIlkTarih_ValueChanged(object sender, EventArgs e)
        {
            if (Genel.carino != 0)
            {
                ds = ch.HareketleriGetirByCariAndTarih(Genel.carino, dtpIlkTarih.Value, dtpSonTarih.Value);
                dgvHareketler.DataSource = ds.Tables["CariHareketler"];
            }
        }

        private void dtpSonTarih_ValueChanged(object sender, EventArgs e)
        {
            if (Genel.carino != 0)
            {
                ds = ch.HareketleriGetirByCariAndTarih(Genel.carino, dtpIlkTarih.Value, dtpSonTarih.Value);
                dgvHareketler.DataSource = ds.Tables["CariHareketler"];
            }
        }
    }
}
