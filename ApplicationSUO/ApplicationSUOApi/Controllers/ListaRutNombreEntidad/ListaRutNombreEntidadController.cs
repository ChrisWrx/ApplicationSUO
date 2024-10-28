using Microsoft.AspNetCore.Mvc;
using SUO.BusinessActions.ListaRutNombreEntidad;
using SUO.BusinessActions.RegionesComunas;

namespace ApplicationSUOWebApi.Controllers.ListaRutNombreEntidad
{
    [ApiController]
    [Route("ApplicationSUOWebApi/")]
    public class ListaRutNombreEntidadController : Controller
    {
        private readonly ListaRutNombreEntidadAction _listaRutNombreEntidadAction;

        public ListaRutNombreEntidadController(ListaRutNombreEntidadAction listaRutNombreEntidadAction)
        {
            _listaRutNombreEntidadAction = listaRutNombreEntidadAction;
        }

        [HttpGet("ListaEntidades")]
        public IActionResult ListaEntidades()
        {
            var entidades = _listaRutNombreEntidadAction.GetListaEntidades();
            
            if (entidades == null || !entidades.Any()) 
            {
                return Ok(new { Code = "8014", Message = "No existen registros de Entidades." });
            }
            return Ok(entidades);
        }

        [HttpGet("ListaRutPorEntidades")]
        public IActionResult ListaRutPorNombre(int ID)
        {
            var rutPorNombre = _listaRutNombreEntidadAction.GetListaRutPorNombre(ID);

            if (rutPorNombre.Any())
            {
                return Ok(rutPorNombre);
            }
            else
            {
                return Ok(new { Code = "8014", Message = "No existen registros para la entidad seleccionada" });
            }
        }
    }
}
