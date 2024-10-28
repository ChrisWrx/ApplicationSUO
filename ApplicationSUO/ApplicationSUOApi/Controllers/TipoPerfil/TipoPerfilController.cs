using Microsoft.AspNetCore.Mvc;
using SUO.BusinessActions.TipoPerfil;

namespace ApplicationSUOWebApi.Controllers.TipoPerfil
{
    [ApiController]
    [Route("ApplicationSUOWebApi/")]
    public class TipoPerfilController : Controller
    {
        private readonly TipoPerfilAction _tipoPerfilAction;
        public TipoPerfilController(TipoPerfilAction tipoPerfilAction)
        {
           _tipoPerfilAction = tipoPerfilAction;
        }

        [HttpGet("ListaTipoPerfil")]
        public IActionResult ListaTipoPerfil() 
        { 
            var perfil = _tipoPerfilAction.GetListaTipoPerfil();

            if (perfil.Any())
            {
                return Ok(perfil);
            }
            else 
            {
                return Ok(new { Code = "8014", Message = "No existen registros de perfil" });
            }
        }
    }
}
