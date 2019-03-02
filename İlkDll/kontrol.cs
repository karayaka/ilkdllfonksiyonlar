using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Personel_Puantaj.cs
{
    class kontrol
    {
        public static bool kayitVarmi(string tabloAdi,string kontrolKolon,bool update,SqlConnection baglanti,string kotrolDeger)
        {
            bool cevap = false;
            string sqlcommant =string.Format(@"select * from {0} where {1}=@{2} {3}",tabloAdi,kontrolKolon,kontrolKolon, (update) ? " AND {0}<>{4}" : "");
            using (SqlCommand cmd = new SqlCommand(sqlcommant, baglanti))
            {
                cmd.Parameters.Add("@" + kontrolKolon, SqlDbType.NVarChar).Value = kotrolDeger;
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    cevap = dr.Read();
                }

            }           

            

            return cevap;
        }
        public static bool kayitVarmiint(string tabloAdi, string kontrolKolon, bool update, SqlConnection baglanti, string kotrolDeger)
        {
            bool cevap = false;
            string sqlcommant = string.Format(@"select * from {0} where {1}=@{2} {3}", tabloAdi, kontrolKolon, kontrolKolon, (update) ? " AND {0}<>{4}" : "");
            using (SqlCommand cmd = new SqlCommand(sqlcommant, baglanti))
            {
                cmd.Parameters.Add("@" + kontrolKolon, SqlDbType.Int).Value = kotrolDeger;
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    cevap = dr.Read();
                }

            }



            return cevap;
        }
        public static bool txtBosmu (string txtdeger)
        {
            bool cevap = false;
            return cevap=string.IsNullOrWhiteSpace(txtdeger);

        }
         void FormuAcMdiForm(Form gelenForm)
        {
            bool formVar = false;
            foreach (var item in this.MdiChildren)
            {
                if (gelenForm.Name == item.Name)
                {
                    formVar = true;
                    item.Activate();
                    break;
                }
            }
            if (!formVar)
            {
                gelenForm.MdiParent = this;
                gelenForm.Show();
            }
        }

       

    }
}
