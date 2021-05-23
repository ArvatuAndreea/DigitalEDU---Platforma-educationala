using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Tema_3___Platforma_educationala.Exceptions;
using Tema_3___Platforma_educationala.Models;
using Platforma_educationala___DigitalEDU.Models.EntityLayer;
using Tema_3___Platforma_educationala.Models.BusinessLogicLayer;
using Tema_3___Platforma_educationala.ViewModels.Commands;

namespace Tema_3___Platforma_educationala.ViewModels
{
    class ProfesorVM : BasePropertyChanged
    {
        ProfesorBLL profBLL = new ProfesorBLL();
        UtilizatorBLL userBLL = new UtilizatorBLL();

        public ProfesorVM()
        {
            UsersList = userBLL.GetAllUsers();
        }

        #region Data Members

        private string errorMessage;
        public string ErrorMessage
        {
            get
            {
                return errorMessage;
            }
            set
            {
                errorMessage = value;
                NotifyPropertyChanged("ErrorMessage");
            }
        }
        public ObservableCollection<Profesor> ProfessorsList
        {
            get
            {
                return profBLL.ProfessorsList;
            }
            set
            {
                profBLL.ProfessorsList = value;
                NotifyPropertyChanged("ProfessorsList");
            }
        }

        private ObservableCollection<Utilizator> usersList;
        public ObservableCollection<Utilizator> UsersList
        {
            get
            {
                return userBLL.UsersList;
            }
            set
            {
                userBLL.UsersList = value;
                NotifyPropertyChanged("UsersList");
            }
        }

        #endregion

        #region ICommand Members

        private ICommand addCommand;
        public ICommand AddCommand
        {
            get
            {
                if (addCommand == null)
                {
                    addCommand = new RelayCommand<Profesor>(profBLL.AddProfessor);
                }
                return addCommand;
            }
            set
            {
                addCommand = value;
            }
        }

        private ICommand updateCommand;
        public ICommand UpdateCommand
        {
            get
            {
                if (updateCommand == null)
                {
                    updateCommand = new RelayCommand<Profesor>(profBLL.ModifyProfessor);
                }
                return updateCommand;
            }
            set
            {
                updateCommand = value;
            }
        }

        private ICommand deleteCommand;
        public ICommand DeleteCommand
        {
            get
            {
                if (deleteCommand == null)
                {
                    deleteCommand = new RelayCommand<Profesor>(profBLL.DeleteProfessor);
                }
                return deleteCommand;
            }
            set
            {
                deleteCommand = value;
            }
        }

        #endregion
    }
}
