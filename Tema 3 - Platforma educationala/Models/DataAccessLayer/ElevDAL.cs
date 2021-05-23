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
    class ElevDAL
    {
        public ObservableCollection<Elev> GetAllStudents()
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetAllStudents", con);
                ObservableCollection<Elev> result = new ObservableCollection<Elev>();
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Elev e = new Elev();
                    e.Id_elev = (int)(reader[0]);//reader.GetInt(0);
                    e.Nume = reader.GetString(1);//reader[1].ToString();
                    e.Cod_clasa = reader.GetString(2);
                    e.Id_utilizator = (int)(reader[3]);
                    result.Add(e);
                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }
        }

        public void AddStudent(Elev elev)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("AddStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramNume = new SqlParameter("@nume", elev.Nume);
                SqlParameter paramCodClasa = new SqlParameter("@cod_clasa", elev.Cod_clasa);
                SqlParameter paramIdUtilizator = new SqlParameter("@id_utilizator", elev.Id_utilizator);
                
                cmd.Parameters.Add(paramNume);
                cmd.Parameters.Add(paramCodClasa);
                cmd.Parameters.Add(paramIdUtilizator);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteStudent(Elev elev)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("DeleteStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIdElev = new SqlParameter("@id_elev", elev.Id_elev);
                cmd.Parameters.Add(paramIdElev);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void ModifyStudent(Elev elev)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("ModifyStudent", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter paramIdElev = new SqlParameter("@id_elev", elev.Id_elev);
                SqlParameter paramNume = new SqlParameter("@nume", elev.Nume);
                SqlParameter paramCodClasa= new SqlParameter("@cod_clasa", elev.Cod_clasa);
                SqlParameter paramIdUtilizator= new SqlParameter("@id_utilizator", elev.Id_utilizator);
                
                cmd.Parameters.Add(paramIdElev);
                cmd.Parameters.Add(paramNume);
                cmd.Parameters.Add(paramCodClasa);
                cmd.Parameters.Add(paramIdUtilizator);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
