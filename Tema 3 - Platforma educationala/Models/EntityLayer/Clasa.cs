using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platforma_educationala___DigitalEDU.Models.EntityLayer
{
    class Clasa : BasePropertyChanged
    {
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

        private string sala;
        public string Sala
        {
            get
            {
                return sala;
            }
            set
            {
                sala = value;
                NotifyPropertyChanged("Sala");
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
    }
}
