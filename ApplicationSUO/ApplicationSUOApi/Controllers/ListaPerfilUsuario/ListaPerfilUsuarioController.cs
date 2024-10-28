using Microsoft.AspNetCore.Mvc;
using SUO.BusinessActions.ListaPerfilUsuario;

namespace ApplicationSUOWebApi.Controllers.ListaPerfilUsuario
{
    [ApiController]
    [Route("ApplicationSUOWebApi/")]
    public class ListaPerfilUsuarioController : Controller
    {
        private readonly ListaPerfilUsuarioAction _listaPerfilUsuarioAction;
        public ListaPerfilUsuarioController(ListaPerfilUsuarioAction listaPerfilUsuarioAction)
        {
            _listaPerfilUsuarioAction = listaPerfilUsuarioAction;
        }
        [HttpGet("ListaPerfilesUsuarios")]
        public IActionResult ListaPerfilUsuario() 
        {
            var list = _listaPerfilUsuarioAction.ListaPerfilDeUsuarios();

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
