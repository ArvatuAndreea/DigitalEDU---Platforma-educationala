using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platforma_educationala___DigitalEDU.Models.EntityLayer
{
    class Materie : BasePropertyChanged
    {
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

        private string denumire;
        public string Denumire
        {
            get
            {
                return denumire;
            }
            set
            {
                denumire = value;
                NotifyPropertyChanged("Denumire");
            }
        }
    }
}
