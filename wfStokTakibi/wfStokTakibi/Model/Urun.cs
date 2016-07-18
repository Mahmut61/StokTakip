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
    class Urun
    {
        private int _urunID;
        private string _urunKodu;
        private string _urunAd;
        private int _kategoriNo;
        private int _miktar;
        private int _kritikSeviye;
        private double _birimFiyat;

        #region Properties
        public int UrunID
        {
            get { return _urunID; }
            set { _urunID = value; }
        }

        public string UrunKodu
        {
            get { return _urunKodu; }
            set { _urunKodu = value; }
        }

        public string UrunAd
        {
            get { return _urunAd; }
            set { _urunAd = value; }
        }

        public int KategoriNo
        {
            get { return _kategoriNo; }
            set { _kategoriNo = value; }
        }

        public int Miktar
        {
            get { return _miktar; }
            set { _miktar = value; }
        }

        public int KritikSeviye
        {
            get { return _kritikSeviye; }
            set { _kritikSeviye = value; }
        }


        public double BirimFiyat
        {
            get { return _birimFiyat; }
            set { _birimFiyat = value; }
        } 
        #endregion

        SqlConnection conn = new SqlConnection(Genel.connStr);
        DataSet ds = new DataSet();

        public DataSet UrunleriGetir()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select UrunKodu, UrunAd, KategoriAd, Miktar, BirimFiyat, KritikSeviye, Urunler.KategoriNo, UrunID from Urunler inner join Kategoriler on Urunler.KategoriNo=Kategoriler.KategoriNo where Urunler.Silindi=0", conn);
            try
            {
                da.Fill(ds, "Urunler");
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }
            return ds;
        }
        public DataSet UrunleriGetirByTumu()
        {
            ds.Clear();
            SqlDataAdapter da = new SqlDataAdapter("Select UrunKodu, UrunAd, KategoriAd, KritikSeviye, BirimFiyat, Miktar, Miktar * BirimFiyat as Tutar  from Urunler inner join Kategoriler on Urunler.KategoriNo=Kategoriler.KategoriNo where Urunler.Silindi=0", conn);
            try
            {
                da.Fill(ds, "Urunler");
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }
            return ds;
        }
        public DataSet UrunleriGetirByKritikSeviye()
        {
            ds.Clear();
            SqlDataAdapter da = new SqlDataAdapter("Select UrunKodu, UrunAd, KategoriAd, BirimFiyat, KritikSeviye, Miktar, KritikSeviye - Miktar as SiparisMiktar, (KritikSeviye - Miktar) * BirimFiyat as SiparisTutar from Urunler inner join Kategoriler on Urunler.KategoriNo=Kategoriler.KategoriNo where Urunler.Silindi=0 and Miktar < KritikSeviye", conn);
            try
            {
                da.Fill(ds, "Urunler");
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }
            return ds;
        }
        public DataSet UrunleriGetirByKategori(string Kategori)
        {
            ds.Clear();
            SqlDataAdapter da = new SqlDataAdapter("Select UrunKodu, UrunAd, KategoriAd, KritikSeviye, BirimFiyat, Miktar, Miktar * BirimFiyat as Tutar from Urunler inner join Kategoriler on Urunler.KategoriNo=Kategoriler.KategoriNo where Urunler.Silindi=0 and KategoriAd=@KategoriAd", conn);
            da.SelectCommand.Parameters.Add("@KategoriAd", SqlDbType.VarChar).Value = Kategori;
            try
            {
                da.Fill(ds, "Urunler");
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }
            return ds;
        }
        public void UrunleriGetir(ListView liste)
        {
            liste.Items.Clear();
            SqlCommand comm = new SqlCommand("Select UrunKodu, UrunAd, KategoriAd, Miktar, BirimFiyat, KritikSeviye, Urunler.KategoriNo, UrunID from Urunler inner join Kategoriler on Urunler.KategoriNo=Kategoriler.KategoriNo where Urunler.Silindi=0", conn);
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
        public bool UrunKontrol(string UrunKodu, string UrunAdi)
        {
            bool Varmi = false;
            SqlCommand comm = new SqlCommand("Select Count(*) from Urunler where Silindi=0 and UrunKodu=@UrunKodu and UrunAd=@UrunAd", conn);
            comm.Parameters.Add("@UrunKodu", SqlDbType.VarChar).Value = UrunKodu;
            comm.Parameters.Add("@UrunAd", SqlDbType.VarChar).Value = UrunAdi;
            if (conn.State == ConnectionState.Closed) conn.Open();
            int Sayisi = Convert.ToInt32(comm.ExecuteScalar());
            if (Sayisi > 0)
            {
                Varmi = true;
            }
            conn.Close();
            return Varmi;
        }
        public bool UrunKontrol(string UrunKodu, string UrunAdi, int ID)
        {
            bool Varmi = false;
            SqlCommand comm = new SqlCommand("Select Count(*) from Urunler where Silindi=0 and UrunKodu=@UrunKodu and UrunAd=@UrunAd and UrunID != @UrunID", conn);
            comm.Parameters.Add("@UrunKodu", SqlDbType.VarChar).Value = UrunKodu;
            comm.Parameters.Add("@UrunAd", SqlDbType.VarChar).Value = UrunAdi;
            comm.Parameters.Add("@UrunID", SqlDbType.Int).Value = ID;
            if (conn.State == ConnectionState.Closed) conn.Open();
            int Sayisi = Convert.ToInt32(comm.ExecuteScalar());
            if (Sayisi > 0)
            {
                Varmi = true;
            }
            conn.Close();
            return Varmi;
        }
        public bool UrunEkle(Urun u)
        {
            bool Sonuc = false;
            SqlCommand comm = new SqlCommand("insert into Urunler (UrunKodu, UrunAd, KategoriNo, KritikSeviye, BirimFiyat) values(@UrunKodu, @UrunAd, @KategoriNo, @KritikSeviye, @BirimFiyat)", conn);
            comm.Parameters.Add("@UrunKodu", SqlDbType.VarChar).Value = u._urunKodu;
            comm.Parameters.Add("@UrunAd", SqlDbType.VarChar).Value = u._urunAd;
            comm.Parameters.Add("@KategoriNo", SqlDbType.Int).Value = u._kategoriNo;
            comm.Parameters.Add("@KritikSeviye", SqlDbType.Int).Value = u._kritikSeviye;
            comm.Parameters.Add("@BirimFiyat", SqlDbType.Money).Value = u._birimFiyat;
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
        public bool UrunGuncelle(Urun u)
        {
            bool Sonuc = false;
            SqlCommand comm = new SqlCommand("Update Urunler Set UrunKodu=@UrunKodu, UrunAd=@UrunAd, KategoriNo=@KategoriNo, KritikSeviye=@KritikSeviye, BirimFiyat=@BirimFiyat where UrunID=@UrunID", conn);
            comm.Parameters.Add("@UrunKodu", SqlDbType.VarChar).Value = u._urunKodu;
            comm.Parameters.Add("@UrunAd", SqlDbType.VarChar).Value = u._urunAd;
            comm.Parameters.Add("@KategoriNo", SqlDbType.Int).Value = u._kategoriNo;
            comm.Parameters.Add("@KritikSeviye", SqlDbType.Int).Value = u._kritikSeviye;
            comm.Parameters.Add("@BirimFiyat", SqlDbType.Money).Value = u._birimFiyat;
            comm.Parameters.Add("@UrunID", SqlDbType.Int).Value = u._urunID;
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
        public bool UrunSil(int ID)
        {
            bool Sonuc = false;
            SqlCommand comm = new SqlCommand("Update Urunler Set Silindi=1 where UrunID=@UrunID", conn);
            comm.Parameters.Add("@UrunID", SqlDbType.Int).Value = ID;
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
        public int KacinciKayit(int ID)
        {
            int kacinci = 0;
            SqlCommand comm = new SqlCommand("Select Count(*) from Urunler where Silindi=0 and UrunID < @UrunID", conn);
            comm.Parameters.Add("@UrunID", SqlDbType.Int).Value = ID;
            if (conn.State == ConnectionState.Closed) conn.Open();
            try
            {
                kacinci = Convert.ToInt32(comm.ExecuteScalar());
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }
            finally { conn.Close();}
            return kacinci;
        }
        public void UrunleriGetirByKodaGore(string KodaGore, ListView liste)
        {
            liste.Items.Clear();
            SqlCommand comm = new SqlCommand("Select UrunKodu, UrunAd, KategoriAd, Miktar, BirimFiyat, KritikSeviye, Urunler.KategoriNo, UrunID from Urunler inner join Kategoriler on Urunler.KategoriNo=Kategoriler.KategoriNo where Urunler.Silindi=0 and UrunKodu like @UrunKodu + '%'", conn);
            comm.Parameters.Add("@UrunKodu", SqlDbType.VarChar).Value = KodaGore;
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
        public void UrunleriGetirByAdaGore(string AdaGore, ListView liste)
        {
            liste.Items.Clear();
            SqlCommand comm = new SqlCommand("Select UrunKodu, UrunAd, KategoriAd, Miktar, BirimFiyat, KritikSeviye, Urunler.KategoriNo, UrunID from Urunler inner join Kategoriler on Urunler.KategoriNo=Kategoriler.KategoriNo where Urunler.Silindi=0 and UrunAd like @UrunAd + '%'", conn);
            comm.Parameters.Add("@UrunAd", SqlDbType.VarChar).Value = AdaGore;
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

        internal bool UrunStokGuncelleFromUrunHareketEkle(int UrunID, int Adet, string IslemTuru)
        {
            bool Sonuc = false;
            SqlCommand comm = new SqlCommand("Update Urunler Set Miktar = Miktar + @Adet where UrunID=@UrunID", conn);
            if (IslemTuru == "Stok Çıkış") Adet = (-1) * Adet;
            comm.Parameters.Add("@Adet", SqlDbType.Int).Value = Adet;
            comm.Parameters.Add("@UrunID", SqlDbType.Int).Value = UrunID;
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
        internal bool UrunStokGuncelleFromUrunHareketSil(int UrunID, int Adet, string IslemTuru)
        {
            bool Sonuc = false;
            SqlCommand comm = new SqlCommand("Update Urunler Set Miktar = Miktar + @Adet where UrunID=@UrunID", conn);
            if (IslemTuru == "Stok Giriş") Adet = (-1) * Adet;
            comm.Parameters.Add("@Adet", SqlDbType.Int).Value = Adet;
            comm.Parameters.Add("@UrunID", SqlDbType.Int).Value = UrunID;
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
