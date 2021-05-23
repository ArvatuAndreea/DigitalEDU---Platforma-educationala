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
    class MaterieVM : BasePropertyChanged
    {
        MaterieBLL materieBLL = new MaterieBLL();
        
        public MaterieVM()
        {
            SubjectsList = materieBLL.GetAllSubjects();
        }

        #region Data Members

        public string ErrorMessage
        {
            get
            {
                return materieBLL.ErrorMessage;
            }
            set
            {
                materieBLL.ErrorMessage = value;
                NotifyPropertyChanged("ErrorMessage");
            }
        }

        public ObservableCollection<Materie> SubjectsList
        {
            get
            {
                return materieBLL.SubjectsList;
            }
            set
            {
                materieBLL.SubjectsList = value;
            }
        }

        #endregion

        #region Command Members

        private ICommand addCommand;
        public ICommand AddCommand
        {
            get
            {
                if (addCommand == null)
                {
                    addCommand = new RelayCommand<Materie>(materieBLL.AddSubject);
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
                    updateCommand = new RelayCommand<Materie>(materieBLL.ModifySubject);
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
                    deleteCommand = new RelayCommand<Materie>(materieBLL.DeleteSubject);
                }
                return deleteCommand;
            }
        }
        #endregion
    }
}
