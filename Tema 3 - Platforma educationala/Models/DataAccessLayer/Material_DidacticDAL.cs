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
    class Material_DidacticDAL
    {
        public ObservableCollection<Material_Didactic> GetAllMaterials()
        {
            SqlConnection con = DALHelper.Connection;
            try
            {
                SqlCommand cmd = new SqlCommand("GetAllMaterials", con);
                ObservableCollection<Material_Didactic> result = new ObservableCollection<Material_Didactic>();
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Material_Didactic md = new Material_Didactic();
                    md.Id_material = (int)(reader[0]);
                    md.Id_materie = (int)(reader[1]);
                    md.Cod_clasa = reader.GetString(2);
                    md.Titlu = reader.GetString(3);
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

        public void AddMaterial(Material_Didactic material)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("AddMaterial", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIdMaterie = new SqlParameter("@id_materie", material.Id_materie);
                SqlParameter paramCodClasa = new SqlParameter("@cod_clasa", material.Cod_clasa);
                SqlParameter paramTitlu = new SqlParameter("@titlu", material.Titlu);
                cmd.Parameters.Add(paramIdMaterie);
                cmd.Parameters.Add(paramCodClasa);
                cmd.Parameters.Add(paramTitlu);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteMaterial(Material_Didactic material)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("DeleteMaterial", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIdMaterial = new SqlParameter("@id_material", material.Id_material);
                cmd.Parameters.Add(paramIdMaterial);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void ModifyMaterial(Material_Didactic material)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("ModifyMaterial", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter paramIdMaterial = new SqlParameter("@id_material", material.Id_material);
                SqlParameter paramIdMaterie = new SqlParameter("@id_materie", material.Id_materie);
                SqlParameter paramCodClasa = new SqlParameter("@cod_clasa", material.Cod_clasa);
                SqlParameter paramTitlu = new SqlParameter("@titlu", material.Titlu);
                cmd.Parameters.Add(paramIdMaterial);
                cmd.Parameters.Add(paramIdMaterie);
                cmd.Parameters.Add(paramCodClasa);
                cmd.Parameters.Add(paramTitlu);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
