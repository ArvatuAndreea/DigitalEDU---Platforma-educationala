using System;
using System.Collections.ObjectModel;
using Tema_3___Platforma_educationala.Exceptions;
using Platforma_educationala___DigitalEDU.Models.EntityLayer;
using Platforma_educationala___DigitalEDU.Models.DataAccessLayer;
using Platforma_educationala___DigitalEDU.Models;

namespace Tema_3___Platforma_educationala.Models.BusinessLogicLayer
{
    class MaterieBLL
    {
        public ObservableCollection<Materie> SubjectsList = new ObservableCollection<Materie>();
        public string ErrorMessage { get; set; }

        MaterieDAL materieDAL = new MaterieDAL();

        public ObservableCollection<Materie> GetAllSubjects()
        {
            return materieDAL.GetAllSubjects();
        }

        public ObservableCollection<Materie> GetAllSubjectsWithoutMaterial()
        {
            return materieDAL.GetAllSubjectsWithNoMaterial();
        }

        public ObservableCollection<Materie> GetAllSubjectsWithoutGrades()
        {
            return materieDAL.GetAllSubjectsWithNoGrades();
        }

        public ObservableCollection<Materie> GetAllSubjectsWithoutSubjectCLass()
        {
            return materieDAL.GetAllSubjectsWithNoSubjectClass();
        }

        public void AddSubject(Materie materie)
        {
            if (String.IsNullOrEmpty(materie.Denumire))
            {
                throw new EDUException("Denumirea materiei trebuie sa fie precizat.");
            }
            materieDAL.AddSubject(materie);
            SubjectsList.Add(materie);
        }

        public void ModifySubject(Materie materie)
        {
            if (materie == null)
            {
                throw new EDUException("Trebuie selectata o materie");
            }
            if (String.IsNullOrEmpty(materie.Denumire))
            {
                throw new EDUException("Denumirea materiei trebuie sa fie precizat.");
            }
            materieDAL.ModifySubject(materie);
        }

        public void DeleteSubject(Materie materie)
        {
            if(materie == null || materie.Id_materie == null)
            {
                throw new EDUException("Alege o materie!");
            }
            materieDAL.DeleteSubject(materie);
            SubjectsList.Remove(materie);
        }
    }
}
