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
    class ClasaVM : BasePropertyChanged
    {
        ClasaBLL clasaBLL = new ClasaBLL();

        public ClasaVM()
        {
            ClassesList = clasaBLL.GetAllClasses();
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
        public ObservableCollection<Clasa> ClassesList
        {
            get
            {
                return clasaBLL.ClassesList;
            }
            set
            {
                clasaBLL.ClassesList = value;
                NotifyPropertyChanged("CalssesList");
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
                    addCommand = new RelayCommand<Clasa>(clasaBLL.AddClass);
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
                    updateCommand = new RelayCommand<Clasa>(clasaBLL.ModifyClass);
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
                    deleteCommand = new RelayCommand<Clasa>(clasaBLL.DeleteClass);
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
