using Microsoft.AspNetCore.Mvc;
using SUO.BusinessActions.ListaEntidades;

namespace ApplicationSUOWebApi.Controllers.ListaEntidades
{
    [ApiController]
    [Route("ApplicationSUOWebApi/")]
    public class ListaEntidadesController : Controller
    {
        private readonly ListaEntidadesAction _listaEntidadesAction;
        public ListaEntidadesController(ListaEntidadesAction listaEntidadesAction)
        {
           _listaEntidadesAction = listaEntidadesAction;
        }

        [HttpGet("ListaDeEntidades")]
        public IActionResult ListaEntidades()
        {
            var list = _listaEntidadesAction.ListaTodasLasEntidades();

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
