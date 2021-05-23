using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using Platforma_educationala___DigitalEDU.Models.EntityLayer;
using Platforma_educationala___DigitalEDU.Models.DataAccessLayer;

namespace Platforma_educationala___DigitalEDU.Models
{
    class UtilizatorDAL
    {

        public ObservableCollection<Utilizator> GetAllUsers()
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetAllUsers", con);
                ObservableCollection<Utilizator> result = new ObservableCollection<Utilizator>();
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Utilizator u = new Utilizator();
                    u.Id_utilizator = (int)(reader[0]); 
                    u.Tip_utilizator = reader.GetString(1); 
                    result.Add(u);
                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }
        }

        public ObservableCollection<Utilizator> GetAllUsersWithNoAdmins()
        {
            using (SqlConnection con = DALHelper.Connection)  
            {
                SqlCommand cmd = new SqlCommand("GetAllUsersWithNoAdmins", con);
                ObservableCollection<Utilizator> result = new ObservableCollection<Utilizator>();
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Utilizator u = new Utilizator();
                    u.Id_utilizator = reader["Id_utilizator"] as int?;
                    u.Tip_utilizator = reader["Tip_Utilizator"].ToString();
                    result.Add(u);
                }
                reader.Close();
                return result;
            }
                
        }

        public ObservableCollection<Utilizator> GetAllUsersWithNoProfessors()
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("GetAllUsersWithNoProfessors", con);
                ObservableCollection<Utilizator> result = new ObservableCollection<Utilizator>();
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Utilizator u = new Utilizator();
                    u.Id_utilizator = reader["Id_utilizator"] as int?;
                    u.Tip_utilizator = reader["Tip_Utilizator"].ToString();
                    result.Add(u);
                }
                reader.Close();
                return result;
            }

        }

        public ObservableCollection<Utilizator> GetAllUsersWithNoStudents()
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("GetAllUsersWithNoStudents", con);
                ObservableCollection<Utilizator> result = new ObservableCollection<Utilizator>();
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Utilizator u = new Utilizator();
                    u.Id_utilizator = reader["Id_utilizator"] as int?;
                    u.Tip_utilizator = reader["Tip_Utilizator"].ToString();
                    result.Add(u);
                }
                reader.Close();
                return result;
            }

        }

        public void AddUser(Utilizator utilizator)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("AddUser", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramTipUtilizator = new SqlParameter("@tip_utilizator", utilizator.Tip_utilizator);
                cmd.Parameters.Add(paramTipUtilizator);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteUser(Utilizator utilizator)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("DeleteUser", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIdUtilizator = new SqlParameter("@id_utilizator", utilizator.Id_utilizator);
                cmd.Parameters.Add(paramIdUtilizator);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void ModifyUser(Utilizator utilizator)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("ModifyUser", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter paramIdUtilizator = new SqlParameter("@id_utilizator", utilizator.Id_utilizator);
                SqlParameter paramTipUtilizator = new SqlParameter("@tip_utilizator", utilizator.Tip_utilizator);
                cmd.Parameters.Add(paramIdUtilizator);
                cmd.Parameters.Add(paramTipUtilizator);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
