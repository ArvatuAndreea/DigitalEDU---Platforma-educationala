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
    class NotaDAL
    {
        public ObservableCollection<Nota> GetAllGradesForStudent(Elev elev)
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetAllGradesStudent", con);
                ObservableCollection<Nota> result = new ObservableCollection<Nota>();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIdElev = new SqlParameter("@id_elev", elev.Id_elev);
                cmd.Parameters.Add(paramIdElev);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Nota n = new Nota();
                    n.Id_nota = (int)(reader[0]);
                    n.Id_elev = (int)(reader[1]);
                    n.Id_materie = (int)(reader[2]);
                    n.Punctaj = (int)(reader[3]);
                    n.Data = reader.GetString(4);
                    n.Semestru = (int)(reader[5]);
                    n.E_teza = reader.GetString(6);
                    result.Add(n);
                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }
        }

        public ObservableCollection<Nota> GetAllGradesForSubject(Materie materie)
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetAllGradesSubject", con);
                ObservableCollection<Nota> result = new ObservableCollection<Nota>();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIdMaterie = new SqlParameter("@id_materie", materie.Id_materie);
                cmd.Parameters.Add(paramIdMaterie);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Nota n = new Nota();
                    n.Id_nota = (int)(reader[0]);
                    n.Id_elev = (int)(reader[1]);
                    n.Id_materie = (int)(reader[2]);
                    n.Punctaj = (int)(reader[3]);
                    n.Data = reader.GetString(4);
                    n.Semestru = (int)(reader[5]);
                    n.E_teza = reader.GetString(6);
                    result.Add(n);
                }
                reader.Close();
                return result;
            }
            finally
            {
                con.Close();
            }
        }



        public void AddGrade(Nota nota)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("AddGrade", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIdElev = new SqlParameter("@id_elev", nota.Id_elev);
                SqlParameter paramIdMaterie = new SqlParameter("@id_materie", nota.Id_materie);
                SqlParameter paramPunctaj = new SqlParameter("@punctaj", nota.Punctaj);
                SqlParameter paramData = new SqlParameter("@data", nota.Data);
                SqlParameter paramSemestru = new SqlParameter("@semestru", nota.Semestru);
                SqlParameter paramETeza = new SqlParameter("@e_teza", nota.E_teza);
                cmd.Parameters.Add(paramIdElev);
                cmd.Parameters.Add(paramIdMaterie);
                cmd.Parameters.Add(paramPunctaj);
                cmd.Parameters.Add(paramData);
                cmd.Parameters.Add(paramSemestru);
                cmd.Parameters.Add(paramETeza);
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteGrade(Nota nota)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("DeleteGrade", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIdNota = new SqlParameter("@id_nota", nota.Id_nota);
                cmd.Parameters.Add(paramIdNota);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void ModifyGrade(Nota nota)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("ModifyGrade", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter paramIdNota = new SqlParameter("@id_nota", nota.Id_nota);
                SqlParameter paramIdElev = new SqlParameter("@id_Elev", nota.Id_elev);
                SqlParameter paramIdMaterie = new SqlParameter("@id_materie", nota.Id_materie);
                SqlParameter paramPunctaj = new SqlParameter("@punctaj", nota.Punctaj);
                SqlParameter paramData = new SqlParameter("@data", nota.Data);
                SqlParameter paramSemestru = new SqlParameter("@semestru", nota.Semestru);
                SqlParameter paramETeza = new SqlParameter("@e_teza", nota.E_teza);
                cmd.Parameters.Add(paramIdNota);
                cmd.Parameters.Add(paramIdElev);
                cmd.Parameters.Add(paramIdMaterie);
                cmd.Parameters.Add(paramPunctaj);
                cmd.Parameters.Add(paramData);
                cmd.Parameters.Add(paramSemestru);
                cmd.Parameters.Add(paramETeza);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
