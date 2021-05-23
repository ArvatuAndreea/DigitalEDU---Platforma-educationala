using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platforma_educationala___DigitalEDU.Models.EntityLayer
{
    class Utilizator : BasePropertyChanged
    {
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

        private string tip_utilizator;
        public string Tip_utilizator
        {
            get
            {
                return tip_utilizator;
            }
            set
            {
                tip_utilizator = value;
                NotifyPropertyChanged("Tip_utilizator");
            }
        }
    }
}
