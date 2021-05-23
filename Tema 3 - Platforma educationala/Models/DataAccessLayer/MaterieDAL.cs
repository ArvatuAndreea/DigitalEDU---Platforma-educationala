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

namespace Tema_3___Platforma_educationala.Models
{
    class MaterieDAL
    {
        public ObservableCollection<Materie> GetAllSubjects()
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetAllSubjects", con);
                ObservableCollection<Materie> result = new ObservableCollection<Materie>();
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Materie m = new Materie();
                    m.Id_materie = (int)(reader[0]);
                    m.Denumire = reader.GetString(1);
                    result.Add(m);
                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }
        }

        public ObservableCollection<Materie> GetAllSubjectsWithNoMaterial()
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("GetAllSubjectsWithNoMaterial", con);
                ObservableCollection<Materie> result = new ObservableCollection<Materie>();
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Materie m = new Materie();
                    m.Id_materie = reader["Id_materie"] as int?;
                    m.Denumire = reader["Denumire"].ToString();
                    result.Add(m);
                }
                reader.Close();
                return result;
            }
        }

        public ObservableCollection<Materie> GetAllSubjectsWithNoSubjectClass()
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("GetAllSubjectsWithNoSubjectClass", con);
                ObservableCollection<Materie> result = new ObservableCollection<Materie>();
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Materie m = new Materie();
                    m.Id_materie = reader["Id_materie"] as int?;
                    m.Denumire = reader["Denumire"].ToString();
                    result.Add(m);
                }
                reader.Close();
                return result;
            }
            
        }

        public ObservableCollection<Materie> GetAllSubjectsWithNoGrade()
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("GetAllSubjectsWithNoGrade", con);
                ObservableCollection<Materie> result = new ObservableCollection<Materie>();
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Materie m = new Materie();
                    m.Id_materie = reader["Id_materie"] as int?;
                    m.Denumire = reader["Denumire"].ToString();
                    result.Add(m);
                }
                reader.Close();
                return result;
            }
        }

        public void AddSubject(Materie materie)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("AddSubject", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramDenumire = new SqlParameter("@denumire", materie.Denumire);
                cmd.Parameters.Add(paramDenumire);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteSubject(Materie materie)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("DeleteSubject", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIdMaterie = new SqlParameter("@id_materie", materie.Id_materie);
                cmd.Parameters.Add(paramIdMaterie);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void ModifySubject(Materie materie)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("ModifySubject", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter paramIdMaterie = new SqlParameter("@id_materie", materie.Id_materie);
                SqlParameter paramDenumire = new SqlParameter("@denumire", materie.Denumire);
                cmd.Parameters.Add(paramIdMaterie);
                cmd.Parameters.Add(paramDenumire);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
