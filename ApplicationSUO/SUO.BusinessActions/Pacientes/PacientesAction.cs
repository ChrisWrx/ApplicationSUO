using SUO.BusinessObjects.Paciente;
using SUO.DataAccessLayer.Repositories.Pacientes;
using System.Collections.Generic;

namespace SUO.BusinessActions.Pacientes
{
    public class PacientesAction
    {
        private readonly IPacientesRepository _pacientesRepository;

        public PacientesAction(IPacientesRepository pacientesRepository)
        {
            _pacientesRepository = pacientesRepository;
        }

        public IEnumerable<GetPacienteResponse> BuscaPacienteByRut(string RUT)
        {         
            var paciente = _pacientesRepository.BuscaPacienteRut(RUT);

            return (paciente.Result);
        }
    }
}
