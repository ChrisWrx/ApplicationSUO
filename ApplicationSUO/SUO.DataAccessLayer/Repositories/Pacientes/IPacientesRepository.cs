using SUO.BusinessObjects.Paciente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUO.DataAccessLayer.Repositories.Pacientes
{
    public interface IPacientesRepository
    {
        Task<IEnumerable<GetPacienteResponse>> BuscaPacienteRut(string RUT);
    }
}
