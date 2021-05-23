using System;
using System.Collections.ObjectModel;
using Tema_3___Platforma_educationala.Exceptions;
using Platforma_educationala___DigitalEDU.Models.EntityLayer;
using Platforma_educationala___DigitalEDU.Models.DataAccessLayer;
using Platforma_educationala___DigitalEDU.Models;

namespace Tema_3___Platforma_educationala.Models.BusinessLogicLayer
{
    class UtilizatorBLL
    {
        public ObservableCollection<Utilizator> UsersList = new ObservableCollection<Utilizator>();
        public string ErrorMessage { get; set; }

        UtilizatorDAL userDAL = new UtilizatorDAL();

        public ObservableCollection<Utilizator> GetAllUsers()
        {
            return userDAL.GetAllUsers();
        }
        public ObservableCollection<Utilizator> GetAllUsersWithoutAdmins()
        {
            return userDAL.GetAllUsersWithNoAdmins();
        }

        public ObservableCollection<Utilizator> GetAllUsersWithoutProfessors()
        {
            return userDAL.GetAllUsersWithNoProfessors();
        }

        public ObservableCollection<Utilizator> GetAllUsersWithoutStudents()
        {
            return userDAL.GetAllUsersWithNoStudents();
        }

        public void AddUser(Utilizator user)
        {
            if (String.IsNullOrEmpty(user.Tip_utilizator))
            {
                throw new EDUException("Trebuie completat tipul utilizatorului.");
            }
            userDAL.AddUser(user);
            UsersList.Add(user);
        }

        public void ModifyUser(Utilizator user)
        {
            if(user == null)
            {
                throw new EDUException("Trebuie selectat un utilizator");
            }
            if (String.IsNullOrEmpty(user.Tip_utilizator))
            {
                throw new EDUException("Trebuie completat tipul utilizatorului.");
            }
            userDAL.ModifyUser(user);
        }

        public void DeleteUser(Utilizator user)
        {
            if(user == null || user.Id_utilizator == null)
            {
                throw new EDUException("Alege un utilizator");
            }
            userDAL.DeleteUser(user);
            UsersList.Remove(user);
        }
    }
}
