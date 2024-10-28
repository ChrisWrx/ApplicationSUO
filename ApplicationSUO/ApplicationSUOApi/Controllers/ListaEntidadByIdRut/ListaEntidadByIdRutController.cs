using Microsoft.AspNetCore.Mvc;
using SUO.BusinessActions.ListaEntidadByIdRut;
using SUO.BusinessActions.ListaPerfilUsuarioByIdRut;

namespace ApplicationSUOWebApi.Controllers.ListaEntidadByIdRut
{
    [ApiController]
    [Route("ApplicationSUOWebApi/")]
    public class ListaEntidadByIdRutController : Controller
    {
        private readonly ListaEntidadByIdRutAction _listaEntidadByIdRutAction;
        public ListaEntidadByIdRutController(ListaEntidadByIdRutAction listaEntidadByIdRutAction)
        {
            _listaEntidadByIdRutAction = listaEntidadByIdRutAction;
        }

        [HttpGet("ListaEntidadByIdRut")]
        public IActionResult ListaEntidadIdRut(int ID, string RUT)
        {
            var list = _listaEntidadByIdRutAction.ListaEntidadById(ID, RUT);
            
            if (list.Any())
            {
                return Ok(list);
            }
            else
            {
                return Ok(new { Code = "8014", Message = "No existe listado de entidad" });
            }
        }
    }
}
