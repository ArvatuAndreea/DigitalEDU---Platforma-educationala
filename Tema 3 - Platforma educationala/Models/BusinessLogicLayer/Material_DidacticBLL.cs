using System;
using System.Collections.ObjectModel;
using Tema_3___Platforma_educationala.Exceptions;
using Platforma_educationala___DigitalEDU.Models.EntityLayer;
using Platforma_educationala___DigitalEDU.Models.DataAccessLayer;
using Platforma_educationala___DigitalEDU.Models;

namespace Tema_3___Platforma_educationala.Models.BusinessLogicLayer
{
    class Material_DidacticBLL
    {
        public ObservableCollection<Material_Didactic> MaterialsList = new ObservableCollection<Material_Didactic>();

        public string ErrorMessage { get; set; }

        Material_DidacticDAL materialDAL = new Material_DidacticDAL();
        public void GetAllMaterialsForClass(Clasa clasa)
        {
            MaterialsList.Clear();
            Material_DidacticDAL materialDAL = new Material_DidacticDAL();
            var materials = materialDAL.GetAllMaterialsForClass(clasa);
            foreach (var m in materials)
            {
                MaterialsList.Add(m);
            }
        }

        public ObservableCollection<Material_Didactic> GetAllMaterials()
        {
            return materialDAL.GetAllMaterials();
        }

        public void GetAllMaterialsForSubject(Materie materie)
        {
            MaterialsList.Clear();
            Material_DidacticDAL materialDAL = new Material_DidacticDAL();
            var materials = materialDAL.GetAllMaterialsForSubject(materie);
            foreach (var m in materials)
            {
                MaterialsList.Add(m);
            }
        }

        public void AddMaterial(Material_Didactic material)
        {
            if(material.Id_materie == null)
            {
                throw new EDUException("Trebuie precizat id-ul materiei.");
            }
            if (String.IsNullOrEmpty(material.Cod_clasa))
            {
                throw new EDUException("Trebuie completat codul clasei.");
            }
            if (String.IsNullOrEmpty(material.Titlu))
            {
                throw new EDUException("Trebuie completat titlul materialului didactic.");
            }
            materialDAL.AddMaterial(material);
            MaterialsList.Add(material);
        }

        public void ModifyMaterial(Material_Didactic material)
        {
            if(material == null)
            {
                throw new EDUException("Trebuie selectat un material");
            }
            if (material.Id_materie == null)
            {
                throw new EDUException("Trebuie precizat id-ul materiei.");
            }
            if (String.IsNullOrEmpty(material.Cod_clasa))
            {
                throw new EDUException("Trebuie completat codul clasei.");
            }
            if (String.IsNullOrEmpty(material.Titlu))
            {
                throw new EDUException("Trebuie completat titlul materialului didactic.");
            }
            materialDAL.ModifyMaterial(material);
        }
        public void DeleteMaterial(Material_Didactic material)
        {
            if(material == null || material.Id_material == null)
            {
                throw new EDUException("Alege un material!");
            }
            materialDAL.DeleteMaterial(material);
            MaterialsList.Remove(material);
        }
    }
}
