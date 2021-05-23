using System;
using System.Collections.ObjectModel;
using Tema_3___Platforma_educationala.Exceptions;
using Platforma_educationala___DigitalEDU.Models.EntityLayer;
using Platforma_educationala___DigitalEDU.Models.DataAccessLayer;
using Platforma_educationala___DigitalEDU.Models;

namespace Tema_3___Platforma_educationala.Models.BusinessLogicLayer
{
    class Materie_ClasaBLL
    {
        public ObservableCollection<Materie_Clasa> SubjectsClassList = new ObservableCollection<Materie_Clasa>();
        public string ErrorMessage { get; set; }

        Materie_ClasaDAL subjectsClassDAL = new Materie_ClasaDAL();

        public ObservableCollection<Materie_Clasa> GetAllSubjectsClass()
        {
            return subjectsClassDAL.GetAllSubjectsClass();
        }

        public void AddSubjectClass(Materie_Clasa materieClasa)
        {
            if (materieClasa.Id_materie == null)
            {
                throw new EDUException("Trebuie precizat id-ul materiei.");
            }
            if (materieClasa.Id_prof == null)
            {
                throw new EDUException("Trebuie precizat id-ul profesorului.");
            }
            if (String.IsNullOrEmpty(materieClasa.Cod_clasa))
            {
                throw new EDUException("Trebuie completat codul clasei.");
            }
            if (String.IsNullOrEmpty(materieClasa.Are_teza))
            {
                throw new EDUException("Trebuie specificat daca are teza.");
            }
            subjectsClassDAL.AddSubjectClass(materieClasa);
            SubjectsClassList.Add(materieClasa);
        }

        public void ModifySubjectClass(Materie_Clasa materieClasa)
        {
            if(materieClasa == null)
            {
                throw new EDUException("Trebuie selectata o materie a clasei");
            }
            if (materieClasa.Id_materie == null)
            {
                throw new EDUException("Trebuie precizat id-ul materiei.");
            }
            if (materieClasa.Id_prof == null)
            {
                throw new EDUException("Trebuie precizat id-ul profesorului.");
            }
            if (String.IsNullOrEmpty(materieClasa.Cod_clasa))
            {
                throw new EDUException("Trebuie completat codul clasei.");
            }
            if (String.IsNullOrEmpty(materieClasa.Are_teza))
            {
                throw new EDUException("Trebuie specificat daca are teza.");
            }
            subjectsClassDAL.ModifySubjectClass(materieClasa);
        }

        public void DeleteSubjectClass(Materie_Clasa materieClasa)
        {
            if (materieClasa == null || materieClasa.Cod == null)
            {
                throw new EDUException("Alege o materie a unei clase!");
            }
            subjectsClassDAL.DeleteSubjectClass(materieClasa);
            SubjectsClassList.Remove(materieClasa);
        }
    }
}
