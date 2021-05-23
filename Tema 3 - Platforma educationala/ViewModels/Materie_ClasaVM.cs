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
    class Materie_ClasaVM : BasePropertyChanged
    {
        Materie_ClasaBLL subClassBLL = new Materie_ClasaBLL();
        MaterieBLL materieBLL = new MaterieBLL();
        ProfesorBLL profBLL = new ProfesorBLL();
        ClasaBLL clasaBLL = new ClasaBLL();

        public Materie_ClasaVM()
        {
            ClassesList = clasaBLL.GetAllClasses();
            SubjectsList = materieBLL.GetAllSubjects();
            ProfsList = profBLL.GetAllProfessors();
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

        private ObservableCollection<Profesor> profsList;
        public ObservableCollection<Profesor> ProfsList
        {
            get
            {
                return profsList;
            }
            set
            {
                profsList = value;
                NotifyPropertyChanged("ProfsList");
            }
        }

        public ObservableCollection<Materie_Clasa> SubjectsClassList
        {
            get
            {
                return subClassBLL.SubjectsClassList;
            }
            set
            {
                subClassBLL.SubjectsClassList = value;
                NotifyPropertyChanged("SubjectsClassList");
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
                    addCommand = new RelayCommand<Materie_Clasa>(subClassBLL.AddSubjectClass);
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
                    updateCommand = new RelayCommand<Materie_Clasa>(subClassBLL.ModifySubjectClass);
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
                    deleteCommand = new RelayCommand<Materie_Clasa>(subClassBLL.DeleteSubjectClass);
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
