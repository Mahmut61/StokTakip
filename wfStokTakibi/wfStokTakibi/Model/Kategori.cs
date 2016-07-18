using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wfStokTakibi.Model
{
    class Kategori
    {
        private int _kategoriNo;
        private string _kategoriAd;
        private string _aciklama;

        #region Properties
        public int KategoriNo
        {
            get { return _kategoriNo; }
            set { _kategoriNo = value; }
        }

        public string KategoriAd
        {
            get { return _kategoriAd; }
            set { _kategoriAd = value; }
        }


        public string Aciklama
        {
            get { return _aciklama; }
            set { _aciklama = value; }
        } 
        #endregion

        SqlConnection conn = new SqlConnection(Genel.connStr);

        public void KategorileriGetir(ComboBox liste)
        {
            SqlCommand comm = new SqlCommand("Select * from Kategoriler where Silindi=0", conn);
            if (conn.State == System.Data.ConnectionState.Closed) conn.Open();
            SqlDataReader dr;
            try
            {
                dr = comm.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Kategori k = new Kategori();
                        k._kategoriAd = dr["KategoriAd"].ToString();
                        k._kategoriNo = Convert.ToInt32(dr["KategoriNo"]);
                        liste.Items.Add(k);
                    }
                    dr.Close();
                }
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }
            finally { conn.Close(); }
        }
        public override string ToString()
        {
            return _kategoriAd;
        }
    }
}
