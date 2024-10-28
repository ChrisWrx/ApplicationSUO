using Microsoft.AspNetCore.Mvc;
using SUO.BusinessActions.DeletePerfilUsuario;
using SUO.BusinessActions.UpdPerfilUsuario;
using SUO.BusinessObjects.DeletePerfilUsuario;

namespace ApplicationSUOWebApi.Controllers.DeletePerfilUsuario
{
    [ApiController]
    [Route("ApplicationSUOWebApi/")]
    public class DeletePerfilUsuarioController : Controller
    {
        private readonly DeletePerfilUsuarioAction _deletePerfilUsuarioAction;
        public DeletePerfilUsuarioController(DeletePerfilUsuarioAction deletePerfilUsuarioAction)
        {
            _deletePerfilUsuarioAction = deletePerfilUsuarioAction;
        }

        [Route("DeletePerfilUsuario")]
        [HttpDelete]
        public async Task<IActionResult> EliminaPerfilUsuario([FromBody] DeletePerfilUsuarioRequest deleteUsuario)
        {
            if (deleteUsuario == null)
                return Ok(new { Code = "401", Message = "Los campos no pueden estar vacíos" });

            if (!ModelState.IsValid)
                return BadRequest(new { Code = "500", Message = "Los datos enviados no son válidos" });

            GetDeletePerfilUsuarioResponse usuarioEliminado = await _deletePerfilUsuarioAction.DeletePerfilUsuario(new DeletePerfilUsuarioRequest(

               deleteUsuario.IdLogin,
               deleteUsuario.RutUsuario));
           
            return Ok(usuarioEliminado);
        }

    }
}
