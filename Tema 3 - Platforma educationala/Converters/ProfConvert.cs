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
    class ProfConvert : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int userId;
            if (!int.TryParse(values[3].ToString(), out userId))
            {
                return null;
            }
            return new Profesor()
            {
                Nume = values[0].ToString(),
                Telefon = values[1].ToString(),
                Email = values[2].ToString(),
                Id_utilizator = userId
            };


        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            Profesor prof = value as Profesor;
            Object[] result = new object[4] { prof.Nume, prof.Telefon, prof.Email, prof.Id_utilizator };
            return result;
        }
    }
}
