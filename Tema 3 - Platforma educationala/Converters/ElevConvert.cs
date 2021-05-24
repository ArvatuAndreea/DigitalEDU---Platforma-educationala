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
    class ElevConvert : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
                int userId;
                if (!int.TryParse(values[3].ToString(), out userId))
                {
                    return null;
                }
                return new Elev()
                {
                    Nume = values[0].ToString(),
                    Cod_clasa = values[1].ToString(),
                    Id_utilizator = userId
                };
            
            
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            Elev elev = value as Elev;
            Object[] result = new object[3] { elev.Nume, elev.Cod_clasa, elev.Id_utilizator };
            return result;
        }
    }
}
