using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Platforma_educationala___DigitalEDU.Models.EntityLayer;
using Platforma_educationala___DigitalEDU.Models.DataAccessLayer;

namespace Platforma_educationala___DigitalEDU.Models
{
    class ClasaDAL
    {

        public ObservableCollection<Clasa> GetAllClasses()
        {
            SqlConnection con = DALHelper.Connection;
         try
            {
                ObservableCollection<Clasa> result = new ObservableCollection<Clasa>();
                SqlCommand cmd = new SqlCommand("GetAllClasses", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Clasa c = new Clasa();
                    c.Cod_clasa = reader.GetString(0);
                    c.Sala = reader.GetString(1);
                    c.Id_prof = (int)(reader[2]);
                    result.Add(c);
                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }
        }

        public void AddClass(Clasa clasa)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("AddClass", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramCodClasa = new SqlParameter("@cod_clasa", clasa.Cod_clasa);
                SqlParameter paramSala = new SqlParameter("@sala", clasa.Sala);
                SqlParameter paramIdProf = new SqlParameter("@id_prof", clasa.Id_prof);
                cmd.Parameters.Add(paramCodClasa);
                cmd.Parameters.Add(paramSala);
                cmd.Parameters.Add(paramIdProf);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteClass(Clasa clasa)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("DeleteClasa", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramCodClasa = new SqlParameter("@cod_clasa", clasa.Cod_clasa);
                cmd.Parameters.Add(paramCodClasa);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void ModifyClass(Clasa clasa)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("ModifyCLass", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter paramCodClasa = new SqlParameter("@cod_clasa", clasa.Cod_clasa);
                SqlParameter paramSala = new SqlParameter("@sala", clasa.Sala);
                SqlParameter paramIdProf = new SqlParameter("@id_prof", clasa.Id_prof);
                
                cmd.Parameters.Add(paramCodClasa);
                cmd.Parameters.Add(paramSala);
                cmd.Parameters.Add(paramIdProf);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
