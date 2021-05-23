using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platforma_educationala___DigitalEDU.Models.EntityLayer
{
    class Nota : BasePropertyChanged
    {
        private int? id_nota;
        public int? Id_nota
        {
            get
            {
                return id_nota;
            }
            set
            {
                id_nota = value;
                NotifyPropertyChanged("Id_nota");
            }
        }

        private int? id_elev;
        public int? Id_elev
        {
            get
            {
                return id_elev;
            }
            set
            {
                id_elev = value;
                NotifyPropertyChanged("Id_elev");
            }
        }

        private int? id_materie;
        public int? Id_materie
        {
            get
            {
                return id_materie;
            }
            set
            {
                id_materie = value;
                NotifyPropertyChanged("Id_materie");
            }
        }

        private int punctaj;
        public int Punctaj
        {
            get
            {
                return punctaj;
            }
            set
            {
                punctaj = value;
                NotifyPropertyChanged("Punctaj");
            }
        }

        private string data;
        public string Data
        {
            get
            {
                return data;
            }
            set
            {
                data = value;
                NotifyPropertyChanged("Data");
            }
        }

        private int semestru;
        public int Semestru
        {
            get
            {
                return semestru;
            }
            set
            {
                semestru = value;
                NotifyPropertyChanged("Semestru");
            }
        }

        private string e_teza;
        public string E_teza
        {
            get
            {
                return e_teza;
            }
            set
            {
                e_teza = value;
                NotifyPropertyChanged("E_teza");
            }
        }
    }
}
