using Microsoft.AspNetCore.Mvc;
using SUO.BusinessActions.UpdPerfilUsuario;
using SUO.BusinessObjects.UpdPerfilUsuario;

namespace ApplicationSUOWebApi.Controllers.UpdPerfilUsuario
{
    [ApiController]
    [Route("ApplicationSUOWebApi/")]
    public class UpdPerfilUsuarioController : Controller
    {
        private readonly ActualizaPerfilUsuarioAction _actualizaPerfilUsuarioAction;
        public UpdPerfilUsuarioController(ActualizaPerfilUsuarioAction actualizaPerfilUsuarioAction)
        {
            _actualizaPerfilUsuarioAction = actualizaPerfilUsuarioAction;
        }

        [Route("UpdatePerfilUsuario")]
        [HttpPut]
        public async Task<IActionResult> ActualizaPerfilUsuario([FromBody] UpdPerfilUsuarioRequest updPerfilUsuarioRequest)
        {
           if (updPerfilUsuarioRequest == null)

                return Ok(new { Code = "401", Message = "Los campos no pueden estar vacíos" });

            if (!ModelState.IsValid)
                return BadRequest(new { Code = "500", Message = "Los datos enviados no son válidos" });

            UpdPerfilUsuarioResponse usuarioActualizado = await _actualizaPerfilUsuarioAction.ActualizaPerfilUsuario(new UpdPerfilUsuarioRequest(

                updPerfilUsuarioRequest.IdLogin, 
                updPerfilUsuarioRequest.RutUsuario, 
                updPerfilUsuarioRequest.CorreoUsuario,
                updPerfilUsuarioRequest.IdEntidad,
                updPerfilUsuarioRequest.RutEntidad,                 
                updPerfilUsuarioRequest.IdPerfil, 
                updPerfilUsuarioRequest.IdEstado));

            return Ok(usuarioActualizado);
        }
    }
}
