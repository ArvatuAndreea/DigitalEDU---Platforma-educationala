using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platforma_educationala___DigitalEDU.Models.EntityLayer
{
    class Material_Didactic : BasePropertyChanged
    {
        private int? id_material;
        public int? Id_material
        {
            get
            {
                return id_material;
            }
            set
            {
                id_material = value;
                NotifyPropertyChanged("Id_material");
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

        private string titlu;
        public string Titlu
        {
            get
            {
                return titlu;
            }
            set
            {
                titlu = value;
                NotifyPropertyChanged("Titlu");
            }
        }
    }
}
