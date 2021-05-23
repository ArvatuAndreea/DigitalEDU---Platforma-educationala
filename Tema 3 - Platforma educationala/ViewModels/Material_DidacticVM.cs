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
    class Material_DidacticVM : BasePropertyChanged
    {
        Material_DidacticBLL materialBLL = new Material_DidacticBLL();
        MaterieBLL materieBLL = new MaterieBLL();
        ClasaBLL clasaBLL = new ClasaBLL();

        public Material_DidacticVM()
        {
            SubjectsList = materieBLL.GetAllSubjects();
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
                NotifyPropertyChanged("CLassesList");
            }
        }

        private ObservableCollection<Materie> subjectsList;
        public ObservableCollection<Materie> SubjectsList
        {
            get
            {
                return subjectsList;
            }
            set
            {
                subjectsList = value;
                NotifyPropertyChanged("SubjectsList");
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
                    addCommand = new RelayCommand<Material_Didactic>(materialBLL.AddMaterial);
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
                    updateCommand = new RelayCommand<Material_Didactic>(materialBLL.ModifyMaterial);
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
                    deleteCommand = new RelayCommand<Material_Didactic>(materialBLL.DeleteMaterial);
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
