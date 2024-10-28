using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUO.DataAccessLayer
{
    public class RutaArchivoConfiguration
    {
        public RutaArchivoConfiguration(string rutaArchivoString)
        {
            RutaArchivoString = rutaArchivoString;
        }
        public string RutaArchivoString { get; set; }
    }
}
