using SUO.BusinessObjects.FichaPaciente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUO.DataAccessLayer.Repositories.FichaPaciente
{
    public interface IFichaPacienteRepository
    {
        Task<IEnumerable<GetFichaPacienteResponse>> FichaPacienteIdRut(int ID, string RUT);
    }
}
