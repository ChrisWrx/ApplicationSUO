using SUO.BusinessObjects.UpdPerfilUsuario;
using SUO.DataAccessLayer.Repositories.UpdPerfilUsuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUO.BusinessActions.UpdPerfilUsuario
{
    public class ActualizaPerfilUsuarioAction
    {
        private readonly IUpdPerfilUsuarioRepository _updPerfilUsuarioRepository;

        public ActualizaPerfilUsuarioAction(IUpdPerfilUsuarioRepository updPerfilUsuarioRepository)
        {
            _updPerfilUsuarioRepository = updPerfilUsuarioRepository;
        }
        public async Task<UpdPerfilUsuarioResponse> ActualizaPerfilUsuario(UpdPerfilUsuarioRequest updPerfilUsuarioRequest)
        {
            var upd = await _updPerfilUsuarioRepository.UpdatePerfilUsuario(updPerfilUsuarioRequest);
            return upd;
        }
    }
}
