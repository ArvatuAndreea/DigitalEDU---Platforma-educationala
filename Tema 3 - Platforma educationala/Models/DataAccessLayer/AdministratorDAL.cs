using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Platforma_educationala___DigitalEDU.Models.EntityLayer;
using Platforma_educationala___DigitalEDU.Models.DataAccessLayer;

namespace Platforma_educationala___DigitalEDU.Models
{
    class AdministratorDAL
    {
        public ObservableCollection<Administrator> GetAllAdmins()
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetAllAdmins", con);
                ObservableCollection<Administrator> result = new ObservableCollection<Administrator>();
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    Administrator a = new Administrator();
                    a.Id_administrator = (int)(reader[0]);
                    a.Nume = reader.GetString(1);
                    a.Telefon = reader.GetString(2);
                    a.Email = reader.GetString(3);
                    a.Id_utilizator = (int)(reader[4]);
                    result.Add(a);
                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }
        }

        public void AddAdmin(Administrator admin)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("AddAdmin", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramNume = new SqlParameter("@nume", admin.Nume);
                SqlParameter paramTelefon = new SqlParameter("@telefon", admin.Telefon);
                SqlParameter paramEmail = new SqlParameter("@email", admin.Email);
                SqlParameter paramIdUtilizator = new SqlParameter("@id_utilizator", admin.Id_utilizator);
                cmd.Parameters.Add(paramNume);
                cmd.Parameters.Add(paramTelefon);
                cmd.Parameters.Add(paramEmail);
                cmd.Parameters.Add(paramIdUtilizator);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteAdmin(Administrator admin)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("DeleteAdmin", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIdAdministrator = new SqlParameter("@id_administrator", admin.Id_administrator);
                cmd.Parameters.Add(paramIdAdministrator);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void ModifyAdmin(Administrator admin)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("ModifyAdmin", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter paramIdAdministrator = new SqlParameter("@id_administrator", admin.Id_administrator);
                SqlParameter paramNume = new SqlParameter("@nume", admin.Nume);
                SqlParameter paramTelefon = new SqlParameter("@telefon", admin.Telefon);
                SqlParameter paramEmail = new SqlParameter("@email", admin.Email);
                SqlParameter paramIdUtilizator = new SqlParameter("@id_utilizator", admin.Id_utilizator);
                cmd.Parameters.Add(paramIdAdministrator);
                cmd.Parameters.Add(paramNume);
                cmd.Parameters.Add(paramTelefon);
                cmd.Parameters.Add(paramEmail);
                cmd.Parameters.Add(paramIdUtilizator);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
