using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wfStokTakibi.Model
{
    class Cari
    {
        private int _cariNo;
        private string _cariTipi;
        private string _unvan;
        private string _yetkili;
        private string _telefon;
        private string _adres;
        private string _ilce;
        private string _il;
        private string _vergiNo;
        private string _vergiDairesi;
        private double _toplamBorc;
        private double _toplamAlacak;
        private double _bakiye;

        #region Properties
        public int CariNo
        {
            get { return _cariNo; }
            set { _cariNo = value; }
        }

        public string CariTipi
        {
            get { return _cariTipi; }
            set { _cariTipi = value; }
        }

        public string Unvan
        {
            get { return _unvan; }
            set { _unvan = value; }
        }

        public string Yetkili
        {
            get { return _yetkili; }
            set { _yetkili = value; }
        }

        public string Telefon
        {
            get { return _telefon; }
            set { _telefon = value; }
        }

        public string Adres
        {
            get { return _adres; }
            set { _adres = value; }
        }

        public string Ilce
        {
            get { return _ilce; }
            set { _ilce = value; }
        }

        public string Il
        {
            get { return _il; }
            set { _il = value; }
        }

        public string VergiNo
        {
            get { return _vergiNo; }
            set { _vergiNo = value; }
        }

        public string VergiDairesi
        {
            get { return _vergiDairesi; }
            set { _vergiDairesi = value; }
        }

        public double ToplamBorc
        {
            get { return _toplamBorc; }
            set { _toplamBorc = value; }
        }

        public double ToplamAlacak
        {
            get { return _toplamAlacak; }
            set { _toplamAlacak = value; }
        }


        public double Bakiye
        {
            get { return _bakiye; }
            set { _bakiye = value; }
        } 
        #endregion

        SqlConnection conn = new SqlConnection(Genel.connStr);
        DataSet ds = new DataSet();

        public DataSet CarileriGetir()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * from Cariler where Silindi=0",conn);
            try
            {
                da.Fill(ds, "Cariler");
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }
            return ds;
        }
        public DataSet CarileriGetirByCariTipi(string CariTipi)
        {
            ds.Clear();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Cariler where Silindi=0 and CariTipi like @CariTipi + '%'", conn);
            da.SelectCommand.Parameters.Add("@CariTipi", SqlDbType.VarChar).Value = CariTipi;
            try
            {
                da.Fill(ds, "Cariler");
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }
            return ds;
        }

        public DataSet CarileriGetirByUnvanaGore(string UnvanaGore)
        {

            return ds;
        }

        internal bool CariToplamlariGuncelle(int CariNo, double Borc, double Alacak)
        {
            bool Sonuc = false;
            SqlCommand comm = new SqlCommand("Update Cariler Set ToplamBorc = ToplamBorc + @Borc, ToplamAlacak = ToplamAlacak + @Alacak where CariNo=@CariNo", conn);
            comm.Parameters.Add("@Borc", SqlDbType.Money).Value = Borc;
            comm.Parameters.Add("@Alacak", SqlDbType.Money).Value = Alacak;
            comm.Parameters.Add("@CariNo", SqlDbType.Int).Value = CariNo;
            if (conn.State == ConnectionState.Closed) conn.Open();
            try
            {
                Sonuc = Convert.ToBoolean(comm.ExecuteNonQuery());
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }
            finally { conn.Close(); }
            return Sonuc;
        }
    }
}
