using Microsoft.AspNetCore.Mvc;
using SUO.BusinessActions.UpdEntidad;
using SUO.BusinessObjects.UpdEntidad;

namespace ApplicationSUOWebApi.Controllers.UpdEntidad
{
    [ApiController]
    [Route("ApplicationSUOWebApi/")]
    public class UpdEntidadController : Controller
    {
        private readonly UpdEntidadAction _updEntidadAction;
        public UpdEntidadController(UpdEntidadAction updEntidadAction)
        {
            _updEntidadAction = updEntidadAction;
        }
        [Route("UpdateEntidad")]
        [HttpPut]
        public async Task<IActionResult> ActualizaEntidad([FromBody] UpdEntidadRequest updEntidadRequest)
        {
            if (updEntidadRequest == null)
                return Ok(new { Code = "401", Message = "Los campos no pueden estar vacíos" });

            if (!ModelState.IsValid)
                return BadRequest(new { Code = "500", Message = "Los datos enviados no son válidos" });

            UpdEntidadResponse entidadActualizada = await _updEntidadAction.UpdateEntidad(new UpdEntidadRequest(
                
                updEntidadRequest.IdEntidad,
                updEntidadRequest.RutEntidad,               
                updEntidadRequest.TelefonoEntidad,
                updEntidadRequest.ContactoEntidad,
                updEntidadRequest.ImgEntidad1,
                updEntidadRequest.ImgEntidad2,
                updEntidadRequest.ImgEntidad3));

            return Ok(entidadActualizada);
        }
    }
}
