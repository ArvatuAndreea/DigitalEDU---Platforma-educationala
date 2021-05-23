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
    class UtilizatorVM : BasePropertyChanged
    {
        UtilizatorBLL userBLL = new UtilizatorBLL();
        public UtilizatorVM()
        {
            UsersList = userBLL.GetAllUsers();
        }
        #region Data Members
        public string ErrorMessage
        {
            get
            {
                return userBLL.ErrorMessage;
            }
            set
            {
                userBLL.ErrorMessage = value;
                NotifyPropertyChanged("ErrorMessage");
            }
        }

        public ObservableCollection<Utilizator> UsersList
        {
            get
            {
                return userBLL.UsersList;
            }
            set
            {
                userBLL.UsersList = value;
            }
        }
        #endregion

        #region 
        private ICommand addCommand;
        public ICommand AddCommand
        {
            get
            {
                if (addCommand == null)
                {
                    addCommand = new RelayCommand<Utilizator>(userBLL.AddUser);
                }
                return addCommand;
            }
        }

        private ICommand updateCommand;
        public ICommand UpdateCommand
        {
            get
            {
                if (updateCommand == null)
                {
                    updateCommand = new RelayCommand<Utilizator>(userBLL.ModifyUser);
                }
                return updateCommand;
            }
        }

        private ICommand deleteCommand;
        public ICommand DeleteCommand
        {
            get
            {
                if (deleteCommand == null)
                {
                    deleteCommand = new RelayCommand<Utilizator>(userBLL.DeleteUser);
                }
                return deleteCommand;
            }
        }
        #endregion
    }
}
