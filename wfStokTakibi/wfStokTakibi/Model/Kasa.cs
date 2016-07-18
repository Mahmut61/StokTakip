using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wfStokTakibi.Model
{
    class Kasa
    {
        private int _ID;
        private string _kasaTuru;
        private DateTime _tarih;
        private string _islemTuru;
        private int _cariNo;
        private string _belge;
        private double _giren;
        private double _cikan;
        private string _paraBirimi;

        #region Properties
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        public string KasaTuru
        {
            get { return _kasaTuru; }
            set { _kasaTuru = value; }
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
        public double Giren
        {
            get { return _giren; }
            set { _giren = value; }
        }
        public double Cikan
        {
            get { return _cikan; }
            set { _cikan = value; }
        }
        public string ParaBirimi
        {
            get { return _paraBirimi; }
            set { _paraBirimi = value; }
        }
        #endregion

        SqlConnection conn = new SqlConnection(Genel.connStr);

        internal void KasaDevirleriGetir(string Tarih, TextBox DevirGiren, TextBox DevirCikan, TextBox DevirBakiye)
        {
            SqlCommand comm = new SqlCommand("select sum(Giren) as ToplamGiren, sum(Cikan) as ToplamCikan, sum(Giren - Cikan) as Bakiye from KasaHareketler where Silindi=0 and Tarih < @Tarih", conn);
            comm.Parameters.Add("@Tarih", SqlDbType.DateTime).Value = Convert.ToDateTime(Tarih);
            if (conn.State == ConnectionState.Closed) conn.Open();
            SqlDataReader dr;
            try
            {
                dr = comm.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        //DevirGiren.Text = dr["ToplamGiren"].ToString();
                        //DevirCikan.Text = dr["ToplamCikan"].ToString();
                        //DevirBakiye.Text = dr["Bakiye"].ToString();
                        DevirGiren.Text = String.Format("{0:#,##0.00}", Convert.ToDouble(dr["ToplamGiren"]));
                        DevirCikan.Text = String.Format("{0:#,##0.00}", Convert.ToDouble(dr["ToplamCikan"]));
                        DevirBakiye.Text = String.Format("{0:#,##0.00}", Convert.ToDouble(dr["Bakiye"]));
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

        internal void KasaHareketleriGetirByTarih(string Tarih, ListView liste, TextBox ToplamGiren, TextBox ToplamCikan, TextBox Bakiye)
        {
            liste.Items.Clear();
            SqlCommand comm = new SqlCommand("select ID, Convert(Date, Tarih, 104) as Tarih, IslemTuru, Unvan, Belge, Giren, Cikan, ParaBirimi, kh.CariNo from KasaHareketler kh inner join Cariler c on kh.CariNo=c.CariNo where kh.Silindi=0 and Convert(Date, Tarih, 104) = Convert(Date, @Tarih, 104)", conn);
            comm.Parameters.Add("@Tarih", SqlDbType.DateTime).Value = Convert.ToDateTime(Tarih);
            if (conn.State == ConnectionState.Closed) conn.Open();
            SqlDataReader dr;
            try
            {
                dr = comm.ExecuteReader();
                if (dr.HasRows)
                {
                    double TopGiren = 0;
                    double TopCikan = 0;
                    int i = 0;
                    while (dr.Read())
                    {
                        liste.Items.Add(dr[0].ToString());
                        liste.Items[i].SubItems.Add(dr[1].ToString());
                        liste.Items[i].SubItems.Add(dr[2].ToString());
                        liste.Items[i].SubItems.Add(dr[3].ToString());
                        liste.Items[i].SubItems.Add(dr[4].ToString());
                        liste.Items[i].SubItems.Add(dr[5].ToString());
                        liste.Items[i].SubItems.Add(dr[6].ToString());
                        liste.Items[i].SubItems.Add(dr[7].ToString());
                        liste.Items[i].SubItems.Add(dr[8].ToString());
                        TopGiren += Convert.ToDouble(dr[5]);
                        TopCikan += Convert.ToDouble(dr[6]);
                        i++;
                    }
                    dr.Close();
                    ToplamGiren.Text = TopGiren.ToString();
                    ToplamCikan.Text = TopCikan.ToString();
                    Bakiye.Text = (TopGiren - TopCikan).ToString();
                }
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }
            finally { conn.Close(); }
        }
        public int KasaHareketEkle(Kasa k)
        {
            int sonkayitno = 0;
            SqlCommand comm = new SqlCommand("insert into KasaHareketler (Tarih, IslemTuru, CariNo, Belge, Giren, Cikan) values(@Tarih, @IslemTuru, @CariNo, @Belge, @Giren, @Cikan); Select Scope_Identity()", conn);
            comm.Parameters.Add("@Tarih", SqlDbType.DateTime).Value = k._tarih;
            comm.Parameters.Add("@IslemTuru", SqlDbType.VarChar).Value = k._islemTuru;
            comm.Parameters.Add("@CariNo", SqlDbType.Int).Value = k._cariNo;
            comm.Parameters.Add("@Belge", SqlDbType.VarChar).Value = k._belge;
            comm.Parameters.Add("@Giren", SqlDbType.Money).Value = k._giren;
            comm.Parameters.Add("@Cikan", SqlDbType.Money).Value = k._cikan;
            if (conn.State == ConnectionState.Closed) conn.Open();
            try
            {
                sonkayitno = Convert.ToInt32(comm.ExecuteScalar());
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }
            finally { conn.Close(); }
            return sonkayitno;
        }
        public bool KasaHareketSil(int ID)
        {
            bool Sonuc = false;
            SqlCommand comm = new SqlCommand("Update KasaHareketler Set Silindi=1 where ID=@ID", conn);
            comm.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
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
