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
        public ObservableCollection<Elev> GetAllStudentsForClass(Clasa clasa)
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetAllStudentsForClass", con);
                ObservableCollection<Elev> result = new ObservableCollection<Elev>();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramCodClasa = new SqlParameter("@cod_clasa", clasa.Cod_clasa);
                cmd.Parameters.Add(paramCodClasa);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Elev e = new Elev();
                    e.Id_elev = (int)(reader[0]);
                    e.Nume = reader.GetString(1);
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

        public ObservableCollection<Elev> GetAllStudentsForUser(Utilizator user)
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetAllStudentsForUser", con);
                ObservableCollection<Elev> result = new ObservableCollection<Elev>();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIdUtilizator = new SqlParameter("@id_utilizator", user.Id_utilizator);
                cmd.Parameters.Add(paramIdUtilizator);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Elev e = new Elev();
                    e.Id_elev = (int)(reader[0]);
                    e.Nume = reader.GetString(1);
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

        public ObservableCollection<Elev> GetAllStudentWithNoGrades()
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("GetAllStudentsWithNoGrades", con);
                ObservableCollection<Elev> result = new ObservableCollection<Elev>();
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Elev e = new Elev();
                    e.Id_elev = reader["Id_elev"] as int?;
                    e.Nume = reader["Nume"].ToString();
                    e.Cod_clasa = reader["Cod_clasa"].ToString();
                    e.Id_utilizator = reader["Id_utilizator"] as int?;
                    result.Add(e);
                }
                reader.Close();
                return result;
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
