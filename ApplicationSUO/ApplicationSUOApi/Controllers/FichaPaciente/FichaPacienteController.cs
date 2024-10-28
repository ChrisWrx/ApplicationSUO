using Microsoft.AspNetCore.Mvc;
using SUO.BusinessActions.FichaPaciente;

namespace ApplicationSUOWebApi.Controllers.FichaPaciente
{
    [ApiController]
    [Route("ApplicationSUOWebApi/")]
    public class FichaPacienteController : Controller
    {
        private readonly FichaPacienteAction _fichaPacientesAction;

        public FichaPacienteController(FichaPacienteAction fichaPacientesAction)
        {
            _fichaPacientesAction = fichaPacientesAction;
        }
        [HttpGet("FichaPacienteByIdRut")]
        public IActionResult FichaPacienteIdRut(int ID, string RUT)
        {
            var fichaPaciente = _fichaPacientesAction.FichaPacienteByIdRut(ID, RUT);

            if (fichaPaciente.Any())
            {
                return Ok(fichaPaciente);
            }
            else
            {
                return Ok(new { Code = "8014", Message = "No existen registros para este RUT" });
            }
        }
    }
}
