using SUO.BusinessObjects.FichaPaciente;
using SUO.DataAccessLayer.Repositories.FichaPaciente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUO.BusinessActions.FichaPaciente
{
    public class FichaPacienteAction
    {
        private readonly IFichaPacienteRepository _fichaPacienteRepository;

        public FichaPacienteAction(IFichaPacienteRepository fichaPacientesRepository)
        {
            _fichaPacienteRepository = fichaPacientesRepository;
        }
        public IEnumerable<GetFichaPacienteResponse> FichaPacienteByIdRut(int ID, string RUT)
        {
            var fichaPaciente = _fichaPacienteRepository.FichaPacienteIdRut(ID, RUT);

            return (fichaPaciente.Result);
        }
    }
}