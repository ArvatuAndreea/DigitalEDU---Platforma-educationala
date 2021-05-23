using System;
using System.Collections.ObjectModel;
using Tema_3___Platforma_educationala.Exceptions;
using Platforma_educationala___DigitalEDU.Models.EntityLayer;
using Platforma_educationala___DigitalEDU.Models.DataAccessLayer;
using Platforma_educationala___DigitalEDU.Models;

namespace Tema_3___Platforma_educationala.Models.BusinessLogicLayer
{
    class ProfesorBLL
    {
        public ObservableCollection<Profesor> ProfessorsList = new ObservableCollection<Profesor>();
        public string ErrorMessage { get; set; }

        ProfesorDAL profDAL = new ProfesorDAL();

        public void GetAllProfessorsForUsers(Utilizator user)
        {
            ProfessorsList.Clear();
            ProfesorDAL profDAL = new ProfesorDAL();
            var profs = profDAL.GetAllProfessorsForUsers(user);
            foreach (var p in profs)
            {
                ProfessorsList.Add(p);
            }
        }

        public ObservableCollection<Profesor> GetAllProfessors()
        {
            return profDAL.GetAllProfessors();
        }

        public ObservableCollection<Profesor> GetAllProfessorsWithoutSubjectClass()
        {
            return profDAL.GetAllProfessorsWithNoSubjectClass();
        }

        public void AddProfessor(Profesor prof)
        {
            if (String.IsNullOrEmpty(prof.Nume))
            {
                throw new EDUException("Numele profesorului trebuie sa fie precizat.");
            }
            if (String.IsNullOrEmpty(prof.Telefon))
            {
                throw new EDUException("Trebuie completat numarul de telefon.");
            }
            if (String.IsNullOrEmpty(prof.Email))
            {
                throw new EDUException("Trebuie completat emailul.");
            }
            if (prof.Id_utilizator == null)
            {
                throw new EDUException("Trebuie precizat id-ul utilizatorului.");
            }
            profDAL.AddProfessor(prof);
            ProfessorsList.Add(prof);
        }

        public void ModifyProfessor(Profesor prof)
        {
            if (prof == null)
            {
                throw new EDUException("Trebuie selectat un profesor");
            }
            if (String.IsNullOrEmpty(prof.Nume))
            {
                throw new EDUException("Numele profesorului trebuie sa fie precizat.");
            }
            if (String.IsNullOrEmpty(prof.Telefon))
            {
                throw new EDUException("Trebuie completat numarul de telefon.");
            }
            if (String.IsNullOrEmpty(prof.Email))
            {
                throw new EDUException("Trebuie completat emailul.");
            }
            if (prof.Id_utilizator == null)
            {
                throw new EDUException("Trebuie precizat id-ul utilizatorului.");
            }
            profDAL.ModifyProfessor(prof);
        }

        public void DeleteProfessor(Profesor prof)
        {
            if(prof == null || prof.Id_prof == null)
            {
                throw new EDUException("Alege un profesor!");
            }
            profDAL.DeleteProfessor(prof);
            ProfessorsList.Remove(prof);
        }
    }
}
