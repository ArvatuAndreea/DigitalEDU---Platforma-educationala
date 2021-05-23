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
    class Materie_ClasaDAL
    {
        public ObservableCollection<Materie_Clasa> GetAllSubjectsClassForSubject(Materie materie)
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetAllSubjectsClassForSubject", con);
                ObservableCollection<Materie_Clasa> result = new ObservableCollection<Materie_Clasa>();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIdMaterie = new SqlParameter("@id_materie", materie.Id_materie);
                cmd.Parameters.Add(paramIdMaterie);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Materie_Clasa mc = new Materie_Clasa();
                    mc.Cod = (int)(reader[0]);
                    mc.Id_materie = (int)(reader[1]);
                    mc.Id_prof = (int)(reader[2]);
                    mc.Cod_clasa = reader.GetString(3);
                    mc.Are_teza = reader.GetString(4);
                    result.Add(mc);
                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }
        }

        public ObservableCollection<Materie_Clasa> GetAllSubjectsClassForProfessor(Profesor prof)
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetAllSubjectsClassForProfessor", con);
                ObservableCollection<Materie_Clasa> result = new ObservableCollection<Materie_Clasa>();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIdProf = new SqlParameter("@id_prof", prof.Id_prof);
                cmd.Parameters.Add(paramIdProf);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Materie_Clasa mc = new Materie_Clasa();
                    mc.Cod = (int)(reader[0]);
                    mc.Id_materie = (int)(reader[1]);
                    mc.Id_prof = (int)(reader[2]);
                    mc.Cod_clasa = reader.GetString(3);
                    mc.Are_teza = reader.GetString(4);
                    result.Add(mc);
                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }
        }

        public ObservableCollection<Materie_Clasa> GetAllSubjectClassForClass(Clasa clasa)
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetAllSubjectClassForClass", con);
                ObservableCollection<Materie_Clasa> result = new ObservableCollection<Materie_Clasa>();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramCodClasa = new SqlParameter("@cod_clasa", clasa.Cod_clasa);
                cmd.Parameters.Add(paramCodClasa);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Materie_Clasa md = new Materie_Clasa();
                    md.Cod = (int)(reader[0]);
                    md.Id_materie = (int)(reader[1]);
                    md.Id_prof = (int)(reader[2]);
                    md.Cod_clasa = reader.GetString(3);
                    md.Are_teza = reader.GetString(4);
                    result.Add(md);
                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }
        }

        public void AddSubjectClass(Materie_Clasa materieClasa)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("AddSubjectClass", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIdMaterie = new SqlParameter("@id_materie", materieClasa.Id_materie);
                SqlParameter paramIdProf = new SqlParameter("@id_prof", materieClasa.Id_prof);
                SqlParameter paramCodClasa = new SqlParameter("@cod_clasa", materieClasa.Cod_clasa);
                SqlParameter paramAreTeza = new SqlParameter("@are_teza", materieClasa.Are_teza);
                cmd.Parameters.Add(paramIdMaterie);
                cmd.Parameters.Add(paramIdProf);
                cmd.Parameters.Add(paramCodClasa);
                cmd.Parameters.Add(paramAreTeza);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteSubjectClass(Materie_Clasa materieClasa)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("DeleteSubjectClass", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramCod = new SqlParameter("@cod", materieClasa.Cod);
                cmd.Parameters.Add(paramCod);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void ModifySubjectClass(Materie_Clasa materieClasa)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("ModifySubjectClass", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter paramCod = new SqlParameter("@cod", materieClasa.Cod);
                SqlParameter paramIdMaterie = new SqlParameter("@id_materie", materieClasa.Id_materie);
                SqlParameter paramIdProf = new SqlParameter("@id_prof", materieClasa.Id_prof);
                SqlParameter paramCodClasa = new SqlParameter("@cod_clasa", materieClasa.Cod_clasa);
                SqlParameter paramAreTeza = new SqlParameter("@are_teza", materieClasa.Are_teza);
                cmd.Parameters.Add(paramCod);
                cmd.Parameters.Add(paramIdMaterie);
                cmd.Parameters.Add(paramIdProf);
                cmd.Parameters.Add(paramCodClasa);
                cmd.Parameters.Add(paramAreTeza);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
