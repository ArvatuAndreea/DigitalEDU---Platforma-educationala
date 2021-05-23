using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platforma_educationala___DigitalEDU.Models.EntityLayer
{
    class Administrator : BasePropertyChanged
    {
        private int? id_administrator;
        public int? Id_administrator
        {
            get
            {
                return id_administrator;
            }
            set
            {
                id_administrator = value;
                NotifyPropertyChanged("Id_administrator");
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

        private string telefon;
        public string Telefon
        {
            get
            {
                return telefon;
            }
            set
            {
                telefon = value;
                NotifyPropertyChanged("Telefon");
            }
        }

        private string email;
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
                NotifyPropertyChanged("Email");
            }
        }
    }
}
