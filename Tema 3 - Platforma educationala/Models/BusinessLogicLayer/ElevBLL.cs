using System;
using System.Collections.ObjectModel;
using Tema_3___Platforma_educationala.Exceptions;
using Platforma_educationala___DigitalEDU.Models.EntityLayer;
using Platforma_educationala___DigitalEDU.Models.DataAccessLayer;
using Platforma_educationala___DigitalEDU.Models;

namespace Tema_3___Platforma_educationala.Models.BusinessLogicLayer
{
    class ElevBLL
    {
        public ObservableCollection<Elev> StudentsList { get; set; }

        public string ErrorMessage { get; set; }

        ElevDAL elevDAL = new ElevDAL();
        public ObservableCollection<Elev> GetAllStudents()
        {
            return elevDAL.GetAllStudents();
        }

        public void AddElev(Elev elev)
        {
            if (String.IsNullOrEmpty(elev.Nume))
            {
                throw new EDUException("Numele elevului trebuie sa fie precizat.");
            }
            if (String.IsNullOrEmpty(elev.Cod_clasa))
            {
                throw new EDUException("Trebuie completat codul clasei.");
            }
            if (elev.Id_utilizator == null)
            {
                throw new EDUException("Trebuie precizat id-ul utilizatorului.");
            }
        }

        public void ModifyStudent(Elev elev)
        {
            if(elev == null)
            {
                throw new EDUException("Trebuie selectat un elev.");
            }
            if (String.IsNullOrEmpty(elev.Nume))
            {
                throw new EDUException("Numele elevului trebuie sa fie precizat.");
            }
            if (String.IsNullOrEmpty(elev.Cod_clasa))
            {
                throw new EDUException("Trebuie completat codul clasei.");
            }
            if (elev.Id_utilizator == null)
            {
                throw new EDUException("Trebuie precizat id-ul utilizatorului.");
            }
            elevDAL.ModifyStudent(elev);
        }

        public void DeleteStudent(Elev elev)
        {
            if (elev == null || elev.Id_elev == null)
            {
                throw new EDUException("Alege un elev");
            }
            elevDAL.DeleteStudent(elev);
            StudentsList.Remove(elev);
        }
    }
}
