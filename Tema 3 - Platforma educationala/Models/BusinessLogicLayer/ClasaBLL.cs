using System;
using System.Collections.ObjectModel;
using Tema_3___Platforma_educationala.Exceptions;
using Platforma_educationala___DigitalEDU.Models.EntityLayer;
using Platforma_educationala___DigitalEDU.Models.DataAccessLayer;
using Platforma_educationala___DigitalEDU.Models;

namespace Tema_3___Platforma_educationala.Models.BusinessLogicLayer
{
    class ClasaBLL
    {
        public ObservableCollection<Clasa> ClassesList { get; set; }

        public string ErrorMessage { get; set; }
        
        ClasaDAL clasaDAL = new ClasaDAL();

        public ObservableCollection<Clasa> GetAllClasses()
        {
            return clasaDAL.GetAllClasses();
        }

        public ObservableCollection<Clasa> GetAllClassesWithoutStudents()
        {
            return clasaDAL.GetAllClassesWithNoStudents();
        }

        public ObservableCollection<Clasa> GetAllClassesWithoutSubjectClass()
        {
            return clasaDAL.GetAllClassesWithNoSubjectClass();
        }

        public ObservableCollection<Clasa> GetAllClassesWithoutMaterial()
        {
            return clasaDAL.GetAllClassesWithNoMaterial();
        }

        public void AddClass(Clasa clasa)
        {
            if(String.IsNullOrEmpty(clasa.Cod_clasa))
            { 
                throw new EDUException("Trebuie completat codul clasei."); 
            }
            if (String.IsNullOrEmpty(clasa.Sala))
            {
                throw new EDUException("Trebuie completata sala.");
            }
            if (clasa.Id_prof == null)
            {
                throw new EDUException("Trebuie precizat id-ul profesorului diriginte.");
            }
            clasaDAL.AddClass(clasa);
            ClassesList.Add(clasa);
        }

        public void ModifyClass(Clasa clasa)
        {
            if(clasa==null)
            {
                throw new EDUException("Trebuie selectata o clasa");
            }
            if (String.IsNullOrEmpty(clasa.Cod_clasa))
            {
                throw new EDUException("Trebuie completat codul clasei.");
            }
            if (String.IsNullOrEmpty(clasa.Sala))
            {
                throw new EDUException("Trebuie completata sala.");
            }
            if (clasa.Id_prof == null)
            {
                throw new EDUException("Trebuie precizat id-ul profesorului diriginte.");
            }
            clasaDAL.ModifyClass(clasa);
        }

        public void DeleteClass(Clasa clasa)
        {
            if(clasa==null || clasa.Cod_clasa==null)
            {
                throw new EDUException("Alege o clasa!");
            }
            clasaDAL.DeleteClass(clasa);
            ClassesList.Remove(clasa);
        }
    }
}
