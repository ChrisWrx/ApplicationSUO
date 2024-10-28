using Microsoft.AspNetCore.Mvc;
using SUO.BusinessActions.EstadoPerfil;
using SUO.BusinessActions.TipoPerfil;

namespace ApplicationSUOWebApi.Controllers.EstadoPerfil
{
    [ApiController]
    [Route("ApplicationSUOWebApi/")]
    public class EstadoPerfilController : Controller
    {
        private readonly EstadoPerfilAction _estadoPerfilAction;
        public EstadoPerfilController(EstadoPerfilAction estadoPerfilAction)
        {
            _estadoPerfilAction = estadoPerfilAction;
        }

        [HttpGet("ListaEstadoPerfil")]
        public IActionResult ListaEstadoPerfil()
        {
           var estado = _estadoPerfilAction.GetListaEstadoPerfil();

            if (estado.Any())
            {
                return Ok(estado);
            }
            else
            {
                return Ok(new { Code = "8014", Message = "No existen registros de estados" });
            }
        }
    }
}
