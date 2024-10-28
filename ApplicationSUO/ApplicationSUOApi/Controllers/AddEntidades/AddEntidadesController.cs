using Microsoft.AspNetCore.Mvc;
using SUO.BusinessActions.AddEntidades;
using SUO.BusinessActions.AddPerfilUsuario;
using SUO.BusinessObjects.AddEntidades;

namespace ApplicationSUOWebApi.Controllers.AddEntidades
{
    [ApiController]
    [Route("ApplicationSUOWebApi/")]
    public class AddEntidadesController : Controller
    {
        private readonly AddEntidadesAction _addEntidadesAction;

        public AddEntidadesController(AddEntidadesAction addEntidadesAction)
        {
            _addEntidadesAction = addEntidadesAction;
        }
        [Route("AddNuevaEntidad")]
        [HttpPost]       
        public async Task<IActionResult> CreaEntidad([FromBody] AddEntidadesRequest addEntidadesRequest)
        {
            if (addEntidadesRequest == null)
                return Ok(new { Code = "401", Message = "Los campos no pueden estar vacíos" });

            if (!ModelState.IsValid)
                return BadRequest(new { Code = "500", Message = "Los datos enviados no son válidos" });

            GetAddEntidadesResponse entidadAgregada = await _addEntidadesAction.CreaNuevaEntidad(new AddEntidadesRequest(

                addEntidadesRequest.RutEntidad,
                addEntidadesRequest.NombreEntidad,
                addEntidadesRequest.DireccionEntidad,
                addEntidadesRequest.IdRegion,
                addEntidadesRequest.IdComuna,
                addEntidadesRequest.TelefonoEntidad,
                addEntidadesRequest.ContactoEntidad,
                addEntidadesRequest.ImgEntidad1,                
                addEntidadesRequest.ImgEntidad2,               
                addEntidadesRequest.ImgEntidad3));

            return Ok(entidadAgregada);
        }
    }
}
