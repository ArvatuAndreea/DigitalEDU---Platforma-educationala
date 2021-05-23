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
    class ElevVM : BasePropertyChanged
    {
        ElevBLL elevBLL = new ElevBLL();
        ClasaBLL clasaBLL = new ClasaBLL();
        UtilizatorBLL userBLL = new UtilizatorBLL();

        public ElevVM()
        {
            ClassesList = clasaBLL.GetAllClasses();
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

        private ObservableCollection<Clasa> classesList;
        public ObservableCollection<Clasa> ClassesList
        {
            get
            {
                return classesList;
            }
            set
            {
                classesList = value;
                NotifyPropertyChanged("ClassesList");
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

        public ObservableCollection<Elev> StudentsList
        {
            get
            {
                return elevBLL.StudentsList;
            }
            set
            {
                elevBLL.StudentsList = value;
                NotifyPropertyChanged("StudentsList");
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
                    addCommand = new RelayCommand<Elev>(elevBLL.AddElev);
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
                    updateCommand = new RelayCommand<Elev>(elevBLL.ModifyStudent);
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
                    deleteCommand = new RelayCommand<Elev>(elevBLL.DeleteStudent);
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
