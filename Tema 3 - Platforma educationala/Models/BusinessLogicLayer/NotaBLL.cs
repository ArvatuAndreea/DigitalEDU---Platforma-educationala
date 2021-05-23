using System;
using System.Collections.ObjectModel;
using Tema_3___Platforma_educationala.Exceptions;
using Platforma_educationala___DigitalEDU.Models.EntityLayer;
using Platforma_educationala___DigitalEDU.Models.DataAccessLayer;
using Platforma_educationala___DigitalEDU.Models;

namespace Tema_3___Platforma_educationala.Models.BusinessLogicLayer
{
    class NotaBLL
    {
        public ObservableCollection<Nota> GradesList { get; set; }
        public string ErrorMessage { get; set; }

        NotaDAL notaDAL = new NotaDAL();

        public ObservableCollection<Nota> GetAllGrades()
        {
            return notaDAL.GetAllGrades();
        }

        public void AddGrade(Nota nota)
        {
            if (nota.Id_elev == null)
            {
                throw new EDUException("Trebuie precizat id-ul elevului.");
            }
            if (nota.Id_materie == null)
            {
                throw new EDUException("Trebuie precizat id-ul materiei.");
            }
            if (nota.Punctaj == null)
            {
                throw new EDUException("Punctajul trebuie sa fie precizat.");
            }
            if (String.IsNullOrEmpty(nota.Data))
            {
                throw new EDUException("Data trebuie sa fie precizata.");
            }
            if (nota.Semestru == null)
            {
                throw new EDUException("Semestrul trebuie sa fie precizat.");
            }
            if (String.IsNullOrEmpty(nota.E_teza))
            {
                throw new EDUException("Trebuie sa fie precizat daca este teza.");
            }
            notaDAL.AddGrade(nota);
            GradesList.Add(nota);
        }

        public void ModifyGrade(Nota nota)
        {
            if(nota == null)
            {
                throw new EDUException("Trebuie selectata o nota");
            }
            if (nota.Id_elev == null)
            {
                throw new EDUException("Trebuie precizat id-ul elevului.");
            }
            if (nota.Id_materie == null)
            {
                throw new EDUException("Trebuie precizat id-ul materiei.");
            }
            if (nota.Punctaj == null)
            {
                throw new EDUException("Punctajul trebuie sa fie precizat.");
            }
            if (String.IsNullOrEmpty(nota.Data))
            {
                throw new EDUException("Data trebuie sa fie precizata.");
            }
            if (nota.Semestru == null)
            {
                throw new EDUException("Semestrul trebuie sa fie precizat.");
            }
            if (String.IsNullOrEmpty(nota.E_teza))
            {
                throw new EDUException("Trebuie sa fie precizat daca este teza.");
            }
            notaDAL.ModifyGrade(nota);
        }

        public void DeleteGrade(Nota nota)
        {
            if(nota == null || nota.Id_nota == null)
            {
                throw new EDUException("Alege o nota!");
            }
            notaDAL.DeleteGrade(nota);
            GradesList.Remove(nota);
        }
    }
}
