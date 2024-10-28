using Microsoft.AspNetCore.Mvc;
using SUO.BusinessActions.AddPerfilUsuario;
using SUO.BusinessObjects.AddPerfilUsuario;
using System.Threading.Tasks;

namespace ApplicationSUOWebApi.Controllers
{
    [ApiController]
    [Route("ApplicationSUOWebApi/")]
    public class AddPerfilUsuarioController : ControllerBase
    {
        private readonly AddPerfilUsuarioAction _addPerfilUsuarioAction;
   
        public AddPerfilUsuarioController(AddPerfilUsuarioAction addPerfilUsuarioAction)
        {
            _addPerfilUsuarioAction = addPerfilUsuarioAction;
        }

        [Route("AddPerfilUsuario")]
        [HttpPost]
        public async Task<IActionResult> CreatePerfilUsuario([FromBody] AddPerfilUsuarioRequest addPerfilUsuarioRequest)
        {
            
            if (addPerfilUsuarioRequest == null)
                return Ok(new { Code = "401", Message = "Los campos no pueden estar vacíos" });

            if (!ModelState.IsValid)
                return BadRequest(new { Code = "500", Message = "Los datos enviados no son válidos" });

            
            GetPerfilUsuarioResponse usuarioAgregado = await _addPerfilUsuarioAction.AddPerfilUsuario(new AddPerfilUsuarioRequest(

                addPerfilUsuarioRequest.RutUsuario,
                addPerfilUsuarioRequest.NombreUsuario,
                addPerfilUsuarioRequest.ApellidoPaterno,
                addPerfilUsuarioRequest.ApellidoMaterno,
                addPerfilUsuarioRequest.CorreoUsuario,
                addPerfilUsuarioRequest.IdEntidad,
                addPerfilUsuarioRequest.RutEntidad,                
                addPerfilUsuarioRequest.Password,
                addPerfilUsuarioRequest.IdPerfil,
                addPerfilUsuarioRequest.IdEstado));

          
            return Ok(usuarioAgregado);
        }
    }
}
