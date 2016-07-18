using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wfStokTakibi.Model
{
    class CariHareket
    {
        private int _hareketID;
        private DateTime _tarih;
        private string _islemTuru;
        private int _cariNo;
        private string _belge;
        private double _borc;
        private double _alacak;
        private int _kasaHareketID;
        private int _urunHareketID;

        #region Properties
        public int HareketID
        {
            get { return _hareketID; }
            set { _hareketID = value; }
        }

        public DateTime Tarih
        {
            get { return _tarih; }
            set { _tarih = value; }
        }

        public string IslemTuru
        {
            get { return _islemTuru; }
            set { _islemTuru = value; }
        }

        public int CariNo
        {
            get { return _cariNo; }
            set { _cariNo = value; }
        }

        public string Belge
        {
            get { return _belge; }
            set { _belge = value; }
        }

        public double Borc
        {
            get { return _borc; }
            set { _borc = value; }
        }


        public double Alacak
        {
            get { return _alacak; }
            set { _alacak = value; }
        }

        public int KasaHareketID
        {
            get { return _kasaHareketID; }
            set { _kasaHareketID = value; }
        }
        public int UrunHareketID
        {
            get { return _urunHareketID; }
            set { _urunHareketID = value; }
        }
        #endregion

        SqlConnection conn = new SqlConnection(Genel.connStr);

        public bool CariHareketEkle(CariHareket ch)
        {
            bool Sonuc = false;
            SqlCommand comm = new SqlCommand("insert into CariHareketler (Tarih, IslemTuru, CariNo, Belge, Borc, Alacak, KasaHareketID, UrunHareketID) values(@Tarih, @IslemTuru, @CariNo, @Belge, @Borc, @Alacak, @KasaHareketID, @UrunHareketID)", conn);
            comm.Parameters.Add("@Tarih", SqlDbType.DateTime).Value = ch._tarih;
            comm.Parameters.Add("@IslemTuru", SqlDbType.VarChar).Value = ch._islemTuru;
            comm.Parameters.Add("@CariNo", SqlDbType.Int).Value = ch._cariNo;
            comm.Parameters.Add("@Belge", SqlDbType.VarChar).Value = ch._belge;
            comm.Parameters.Add("@Borc", SqlDbType.Money).Value = ch._borc;
            comm.Parameters.Add("@Alacak", SqlDbType.Money).Value = ch._alacak;
            comm.Parameters.Add("@KasaHareketID", SqlDbType.Int).Value = ch._kasaHareketID;
            comm.Parameters.Add("@UrunHareketID", SqlDbType.Int).Value = ch._urunHareketID;
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
        public bool CariHareketSilByUrunHareket(int UrunHareketID)
        {
            bool Sonuc = false;
            SqlCommand comm = new SqlCommand("Update CariHareketler Set Silindi=1 where UrunHareketID=@UrunHareketID", conn);
            comm.Parameters.Add("@UrunHareketID", SqlDbType.Int).Value = UrunHareketID;
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
        public bool CariHareketSilByKasaHareket(int KasaHareketID)
        {
            bool Sonuc = false;
            SqlCommand comm = new SqlCommand("Update CariHareketler Set Silindi=1 where KasaHareketID=@KasaHareketID", conn);
            comm.Parameters.Add("@KasaHareketID", SqlDbType.Int).Value = KasaHareketID;
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

        internal DataSet HareketleriGetirByCariAndTarih(int CariNo, DateTime Tarih1, DateTime Tarih2)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("Select Convert(Date, Tarih, 104) as Tarih, IslemTuru, Belge, Borc, Alacak from CariHareketler where Silindi=0 and CariNo=@CariNo and Convert(Date, Tarih, 104) Between Convert(Date, @Tarih1, 104) and Convert(Date, @Tarih2, 104)", conn);
            da.SelectCommand.Parameters.Add("@CariNo", SqlDbType.Int).Value = CariNo;
            da.SelectCommand.Parameters.Add("@Tarih1", SqlDbType.DateTime).Value = Tarih1;
            da.SelectCommand.Parameters.Add("@Tarih2", SqlDbType.DateTime).Value = Tarih2;
            try
            {
                da.Fill(ds, "CariHareketler");
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }
            return ds;
        }
    }
}
