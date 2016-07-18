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
    class UrunHareket
    {
        private int _hareketID;
        private DateTime _tarih;
        private string _islemTuru;
        private int _firmaNo;
        private int _urunID;
        private string _belge;
        private string _birim;
        private int _adet;
        private double _birimFiyat;
        private double _tutar;

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

        public int FirmaNo
        {
            get { return _firmaNo; }
            set { _firmaNo = value; }
        }

        public int UrunID
        {
            get { return _urunID; }
            set { _urunID = value; }
        }

        public string Belge
        {
            get { return _belge; }
            set { _belge = value; }
        }

        public string Birim
        {
            get { return _birim; }
            set { _birim = value; }
        }

        public int Adet
        {
            get { return _adet; }
            set { _adet = value; }
        }

        public double BirimFiyat
        {
            get { return _birimFiyat; }
            set { _birimFiyat = value; }
        }


        public double Tutar
        {
            get { return _tutar; }
            set { _tutar = value; }
        } 
        #endregion

        SqlConnection conn = new SqlConnection(Genel.connStr);
        DataSet ds = new DataSet();

        public int UrunHareketEkle(UrunHareket uh)
        {
            //bool Sonuc = false;
            int sonkayitno = 0;
            SqlCommand comm = new SqlCommand("insert into UrunHareketler (Tarih, IslemTuru, FirmaNo, UrunID, Belge, Birim, Adet, BirimFiyat) values(@Tarih, @IslemTuru, @FirmaNo, @UrunID, @Belge, @Birim, @Adet, @BirimFiyat); Select Scope_Identity()", conn);
            comm.Parameters.Add("@Tarih", SqlDbType.DateTime).Value = uh._tarih;
            comm.Parameters.Add("@IslemTuru", SqlDbType.VarChar).Value = uh._islemTuru;
            comm.Parameters.Add("@FirmaNo", SqlDbType.Int).Value = uh._firmaNo;
            comm.Parameters.Add("@UrunID", SqlDbType.Int).Value = uh._urunID;
            comm.Parameters.Add("@Belge", SqlDbType.VarChar).Value = uh._belge;
            comm.Parameters.Add("@Birim", SqlDbType.VarChar).Value = uh._birim;
            comm.Parameters.Add("@Adet", SqlDbType.Int).Value = uh._adet;
            comm.Parameters.Add("@BirimFiyat", SqlDbType.Money).Value = uh._birimFiyat;
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
        public void UrunHareketleriGetir(ListView liste, int UrunID)
        {
            liste.Items.Clear();
            SqlCommand comm = new SqlCommand("Select Tarih, IslemTuru, Unvan, Belge, BirimFiyat, Adet,  Tutar, UrunID, HareketID, FirmaNo, Birim from UrunHareketler uh inner join Cariler c on uh.FirmaNo=c.CariNo where uh.Silindi=0 and uh.UrunID=@UrunID", conn);
            comm.Parameters.Add("@UrunID", SqlDbType.Int).Value = UrunID;
            if (conn.State == ConnectionState.Closed) conn.Open();
            SqlDataReader dr;
            try
            {
                dr = comm.ExecuteReader();
                if (dr.HasRows)
                {
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
                        liste.Items[i].SubItems.Add(dr[9].ToString());
                        liste.Items[i].SubItems.Add(dr[10].ToString());
                        i++;
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
        public bool UrunHareketSil(int HareketID)
        {
            bool Sonuc = false;
            SqlCommand comm = new SqlCommand("Update UrunHareketler Set Silindi=1 where HareketID=@HareketID", conn);
            comm.Parameters.Add("@HareketID", SqlDbType.Int).Value = HareketID;
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
