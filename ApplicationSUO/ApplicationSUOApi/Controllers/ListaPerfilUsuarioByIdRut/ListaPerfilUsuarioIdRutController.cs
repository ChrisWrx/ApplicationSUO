using Microsoft.AspNetCore.Mvc;
using SUO.BusinessActions.ListaPerfilUsuario;
using SUO.BusinessActions.ListaPerfilUsuarioByIdRut;

namespace ApplicationSUOWebApi.Controllers.ListaPerfilUsuarioByIdRut
{
    [ApiController]
    [Route("ApplicationSUOWebApi/")]
    public class ListaPerfilUsuarioIdRutController : Controller
    {
        private readonly ListaPerfilUsuarioByIdRutAction _listaPerfilUsuarioByIdRutAction;
        public ListaPerfilUsuarioIdRutController(ListaPerfilUsuarioByIdRutAction listaPerfilUsuarioByIdRutAction)
        {
            _listaPerfilUsuarioByIdRutAction = listaPerfilUsuarioByIdRutAction;
        }
        [HttpGet("ListaPerfilUsuarioByIdRut")]
        public IActionResult ListaPerfilUsuarioIdRut(int ID, string RUT)
        {
            var list = _listaPerfilUsuarioByIdRutAction.ListaPerfilUsuarioByIdRut(ID, RUT);

            if (list.Any())
            {
                return Ok(list);
            }
            else
            {
                return Ok(new { Code = "8014", Message = "No existe listado de usuarios" });
            }
        }
    }
}
