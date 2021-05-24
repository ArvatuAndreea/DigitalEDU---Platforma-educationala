using Platforma_educationala___DigitalEDU.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using Tema_3___Platforma_educationala.Models;

namespace Tema_3___Platforma_educationala.Converters
{
    class MaterieConverter : IMultiValueConverter
    {
            public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
            
                return new Materie()
                {
                    Denumire = values[0].ToString()
                };


            }
            public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
            {
                Materie materie = value as Materie;
                Object[] result = new object[1] { materie.Denumire };
                return result;
            }
        
    }
}
