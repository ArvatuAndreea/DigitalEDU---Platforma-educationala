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
    class AdministratorVM : BasePropertyChanged
    {
        UtilizatorBLL userBLL = new UtilizatorBLL();
        AdministratorBLL adminBLL = new AdministratorBLL();
        public AdministratorVM()
        {
            UsersList = userBLL.GetAllUsers();
            AdministratorsList = adminBLL.GetAllAdministrators();
        }

        #region
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

        private ObservableCollection<Utilizator> usersList;
        public ObservableCollection<Utilizator> UsersList
        {
            get
            {
                return usersList;
            }
            set
            {
                usersList = value;
                NotifyPropertyChanged("UsersList");
            }
        }

        public ObservableCollection<Administrator> AdministratorsList
        {
            get
            {
                return adminBLL.AdministratorsList;
            }
            set
            {
                adminBLL.AdministratorsList = value;
                NotifyPropertyChanged("AdministratorsList");
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
                    addCommand = new RelayCommand<Administrator>(adminBLL.AddAdministrator);
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
                    updateCommand = new RelayCommand<Administrator>(adminBLL.ModifyAdministrator);
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
                    deleteCommand = new RelayCommand<Administrator>(adminBLL.DeleteAdministrator);
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
