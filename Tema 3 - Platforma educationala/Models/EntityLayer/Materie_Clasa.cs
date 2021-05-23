using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platforma_educationala___DigitalEDU.Models.EntityLayer
{
    class Materie_Clasa : BasePropertyChanged
    {
        private int? cod;
        public int? Cod
        {
            get
            { 
                return cod;
            }
            set
            {
                cod = value;
                NotifyPropertyChanged("Cod");
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

        private int? id_prof;
        public int? Id_prof
        {
            get
            {
                return id_prof;
            }
            set
            {
                id_prof = value;
                NotifyPropertyChanged("Id_prof");
            }
        }

        private string cod_clasa;
        public string Cod_clasa
        {
            get
            {
                return cod_clasa;
            }
            set
            {
                cod_clasa = value;
                NotifyPropertyChanged("Cod_clasa");
            }
        }

        private string are_teza;
        public string Are_teza
        {
            get
            {
                return are_teza;
            }
            set
            {
                are_teza = value;
                NotifyPropertyChanged("Are_teza");
            }
        }
    }
}
