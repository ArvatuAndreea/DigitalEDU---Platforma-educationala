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
    class ProfesorDAL
    {
        public ObservableCollection<Profesor> GetAllProfessors()
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetAllProfessors", con);
                ObservableCollection<Profesor> result = new ObservableCollection<Profesor>();
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Profesor p = new Profesor();
                    p.Id_prof = (int)(reader[0]);
                    p.Nume = reader.GetString(1);
                    p.Telefon = reader.GetString(2);
                    p.Email = reader.GetString(3);
                    p.Id_utilizator = (int)(reader[4]);
                    result.Add(p);
                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }
        }

        public void AddProfessor(Profesor prof)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("AddProfessor", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramNume = new SqlParameter("@nume", prof.Nume);
                SqlParameter paramTelefon = new SqlParameter("@telefon", prof.Telefon);
                SqlParameter paramEmail = new SqlParameter("@email", prof.Email);
                SqlParameter paramIdUtilizator = new SqlParameter("@id_utilizator", prof.Id_utilizator);
                cmd.Parameters.Add(paramNume);
                cmd.Parameters.Add(paramTelefon);
                cmd.Parameters.Add(paramEmail);
                cmd.Parameters.Add(paramIdUtilizator);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteProfessor(Profesor prof)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("DeleteProfessor", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIdProf = new SqlParameter("@id_prof", prof.Id_prof);
                cmd.Parameters.Add(paramIdProf);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void ModifyProfessor(Profesor prof)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("ModifyProfessor", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter paramIdProf = new SqlParameter("@id_prof", prof.Id_prof);
                SqlParameter paramNume = new SqlParameter("@nume", prof.Nume);
                SqlParameter paramTelefon = new SqlParameter("@telefon", prof.Telefon);
                SqlParameter paramEmail = new SqlParameter("@email", prof.Email);
                SqlParameter paramIdUtilizator = new SqlParameter("@id_utilizator", prof.Id_utilizator);
                cmd.Parameters.Add(paramIdProf);
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
