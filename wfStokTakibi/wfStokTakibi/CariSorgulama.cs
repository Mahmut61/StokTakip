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
    public partial class CariSorgulama : Form
    {
        public CariSorgulama()
        {
            InitializeComponent();
        }
        DataSet ds = new DataSet();

        private void CariSorgulama_Load(object sender, EventArgs e)
        {
            if (Genel.caritipi == "Alıcı") rbAlicilar.Checked = true;
            else if (Genel.caritipi == "Satıcı") rbSaticilar.Checked = true;
            else { rbTumFirmalar.Checked = true; }
        }

        private void rbAlicilar_CheckedChanged(object sender, EventArgs e)
        {
            Genel.caritipi = "Alıcı";
            Cari c = new Cari();
            ds = c.CarileriGetirByCariTipi(Genel.caritipi);
            dgvCariler.DataSource = ds.Tables["Cariler"];
            dgvCariler.Columns[0].Visible = false;
        }

        private void rbSaticilar_CheckedChanged(object sender, EventArgs e)
        {
            Genel.caritipi = "Satıcı";
            Cari c = new Cari();
            ds = c.CarileriGetirByCariTipi(Genel.caritipi);
            dgvCariler.DataSource = ds.Tables["Cariler"];
            dgvCariler.Columns[0].Visible = false;
        }

        private void rbTumFirmalar_CheckedChanged(object sender, EventArgs e)
        {
            Cari c = new Cari();
            ds = c.CarileriGetir();
            dgvCariler.DataSource = ds.Tables["Cariler"];
            dgvCariler.Columns[0].Visible = false;
        }

        private void dgvCariler_DoubleClick(object sender, EventArgs e)
        {
            Genel.carino = Convert.ToInt32(dgvCariler.SelectedRows[0].Cells[0].Value);
            Genel.cariunvan = dgvCariler.SelectedRows[0].Cells[2].Value.ToString();
            this.Close();
        }


    }
}
