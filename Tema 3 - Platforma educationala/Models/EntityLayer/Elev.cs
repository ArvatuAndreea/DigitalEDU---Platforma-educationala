using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platforma_educationala___DigitalEDU.Models.EntityLayer
{
    class Elev : BasePropertyChanged
    {
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

        private string nume;
        public string Nume
        {
            get
            {
                return nume;
            }
            set
            {
                nume = value;
                NotifyPropertyChanged("Nume");
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

        private int? id_utilizator;
        public int? Id_utilizator
        {
            get
            {
                return id_utilizator;
            }
            set
            {
                id_utilizator = value;
                NotifyPropertyChanged("Id_utilizator");
            }
        }
    }
}
