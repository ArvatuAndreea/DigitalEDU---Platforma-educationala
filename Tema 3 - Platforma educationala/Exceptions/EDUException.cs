using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema_3___Platforma_educationala.Exceptions
{
    class EDUException:ApplicationException
    {
        public EDUException(string message) 
            : base(message)
        {
        }
    }
}
