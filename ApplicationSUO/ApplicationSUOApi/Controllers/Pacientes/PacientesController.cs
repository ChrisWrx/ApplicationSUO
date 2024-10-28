using Microsoft.AspNetCore.Mvc;
using SUO.BusinessActions.Pacientes;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationSUOWebApi.Controllers.Pacientes
{
    [ApiController]
    [Route("ApplicationSUOWebApi/")]
    public class PacientesController : Controller
    {
        private readonly PacientesAction _pacientesAction;

        public PacientesController(PacientesAction pacientesAction)
        {
            _pacientesAction = pacientesAction;
        }

        [HttpGet("BuscaPaciente")]
        public IActionResult BuscaPacienteRut(string RUT)
        {
            var paciente = _pacientesAction.BuscaPacienteByRut(RUT);

            if (paciente.Any())
            {
                return Ok(paciente);
            }
            else
            {
                return Ok(new { Code = "8014", Message = "No existen registros para este RUT" });
            }
        }
    }
}
