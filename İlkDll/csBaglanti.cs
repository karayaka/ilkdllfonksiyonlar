using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace Personel_Puantaj.cs
{
    class csBaglanti
    {
        public static SqlConnection baglanti;
        public static SqlConnection baglatiGetir()
        {
            if (baglanti == null)
            {
                baglanti = new SqlConnection(Properties.Settings.Default.DBConstr);

            }
            if (baglanti.State == ConnectionState.Closed)
                baglanti.Open();
            return baglanti;
        }
        public static DataTable girdDoldur(string select)
        {
           
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            using (da.SelectCommand=new SqlCommand(select,baglatiGetir()))
            {
                dt.Clear();
                da.Fill(dt);
            }
            return dt;
        }
        public static DataTable dtTekParametreSelect(string select, string KontrolKolan, string KontrolDeger)
        {
            //data table işlemlerinde tekpaeametreli select sorguları için kullanılacak fonsiyon
            //Örnek kullanım cs.csBaglanti.dtTekParametreSelect(@"SELECT * FROM TabloAdı WHERE (ID = @ID)", "@ID)",_gelenID);
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            using (da.SelectCommand = new SqlCommand(select, baglatiGetir()))
            {
                da.SelectCommand.Parameters.Add(KontrolKolan, SqlDbType.Int).Value = KontrolDeger;
                dt.Clear();
                da.Fill(dt);
            }
            return dt;
        }
        //public static SqlDataReader drTekParametreInt(string select,string konrolKolon,string kolonDeger)
        //{
        //    SqlDataReader _dr;
        //    using (SqlCommand cmd=new SqlCommand(select,baglatiGetir()) )
        //    {

        //        cmd.Parameters.Add(konrolKolon, SqlDbType.Int).Value = kolonDeger;
        //        using (SqlDataReader dr=cmd.ExecuteReader(CommandBehavior.SingleResult))
        //        {
        //            _dr = dr;

        //        }

        //    }
        //    return _dr;
        //}

    }
}
