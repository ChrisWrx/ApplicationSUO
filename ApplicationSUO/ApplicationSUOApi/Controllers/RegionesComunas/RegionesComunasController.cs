using Microsoft.AspNetCore.Mvc;
using SUO.BusinessActions.RegionesComunas;

namespace ApplicationSUOWebApi.Controllers.RegionesComunas
{
    [ApiController]
    [Route("ApplicationSUOWebApi/")]
    public class RegionesComunasController : Controller
    {
        private readonly RegionesComunasAction _regionesComunasAction;

        public RegionesComunasController(RegionesComunasAction regionesComunasAction)
        {
            _regionesComunasAction = regionesComunasAction;
        }

        [HttpGet("ListaRegiones")]
        public IActionResult ListaRegiones()
        {
            var regiones = _regionesComunasAction.ListaRegiones(); // Asegúrate de que este método exista

            if (regiones == null || !regiones.Any())
            {
                return Ok(new { Code = "8014", Message = "No existen registros de regiones." });
            }

            return Ok(regiones);
        }

        [HttpGet("ListaComunasPorRegion")]
        public IActionResult ListaComunasRegion(int IDREGION)
        {
            var regionComuna = _regionesComunasAction.ListaComunasPorRegion(IDREGION);

            if (regionComuna.Any())
            {
                return Ok(regionComuna);
            }
            else
            {
                return Ok(new { Code = "8014", Message = "No existen registros para la región seleccionada" });
            }
        }
    }
}
