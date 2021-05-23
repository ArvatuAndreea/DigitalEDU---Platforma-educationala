using System;
using System.Collections.ObjectModel;
using Tema_3___Platforma_educationala.Exceptions;
using Platforma_educationala___DigitalEDU.Models.EntityLayer;
using Platforma_educationala___DigitalEDU.Models.DataAccessLayer;
using Platforma_educationala___DigitalEDU.Models;

namespace Tema_3___Platforma_educationala.Models.BusinessLogicLayer
{
    class AdministratorBLL
    {
        public ObservableCollection<Administrator> AdministratorsList { get; set; }
        public string ErrorMessage { get; set; }

        AdministratorDAL administratorDAL = new AdministratorDAL();

        public void GetAllAdministratorsForUsers(Utilizator user)
        {
            AdministratorsList.Clear();
            AdministratorDAL adminDAL = new AdministratorDAL();
            var admins = adminDAL.GetAllAdminsForUsers(user);
            foreach (var a in admins)
            {
                AdministratorsList.Add(a);
            }
        }

        public void AddAdministrator(Administrator administrator)
        {
            if(String.IsNullOrEmpty(administrator.Nume))
            {
                throw new EDUException("Numele administratorului trebuie sa fie precizat.");
            }
            if(String.IsNullOrEmpty(administrator.Telefon))
            {
                throw new EDUException("Trebuie completat numarul de telefon.");
            }
            if(String.IsNullOrEmpty(administrator.Email))
            {
                throw new EDUException("Trebuie completat emailul.");
            }
            if(administrator.Id_utilizator == null)
            {
                throw new EDUException("Trebuie precizat id-ul utilizatorului.");
            }
            administratorDAL.AddAdmin(administrator);
            AdministratorsList.Add(administrator);
        }
        public void ModifyAdministrator(Administrator admin)
        {
            if(admin == null)
            {
                throw new EDUException("Trebuie selectat un administrator");
            }
            if (String.IsNullOrEmpty(admin.Nume))
            {
                throw new EDUException("Trebuie precizat numele administratorului.");
            }
            if (String.IsNullOrEmpty(admin.Telefon))
            {
                throw new EDUException("Trebuie precizat numarul de telefon.");
            }
            if (String.IsNullOrEmpty(admin.Email))
            {
                throw new EDUException("Trebuie precizat emailul.");
            }
            if (admin.Id_utilizator == null)
            {
                throw new EDUException("Trebuie precizat id-ul utilizatorului.");
            }
            administratorDAL.ModifyAdmin(admin);
        }

        public void DeleteAdministrator(Administrator admin)
        {
            if (admin == null || admin.Id_administrator == null)
            {
                throw new EDUException("Alege un administrator!");
            }
            administratorDAL.DeleteAdmin(admin);
            AdministratorsList.Remove(admin);
        }
    }
}
