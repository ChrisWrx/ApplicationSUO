using SUO.BusinessObjects.AddPerfilUsuario;
using SUO.DataAccessLayer.Repositories.AddPerfilUsuario;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SUO.BusinessActions.AddPerfilUsuario
{
    public class AddPerfilUsuarioAction
    {
        private readonly IAddPerfilUsuarioRepository _addPerfilUsuarioRepository;

       
        public AddPerfilUsuarioAction(IAddPerfilUsuarioRepository addPerfilUsuarioRepository)
        {
            _addPerfilUsuarioRepository = addPerfilUsuarioRepository;
        }

       
        public async Task<GetPerfilUsuarioResponse> AddPerfilUsuario(AddPerfilUsuarioRequest addPerfilUsuarioRequest)
        {
            
            var result = await _addPerfilUsuarioRepository.CreaPerfilUsuario(addPerfilUsuarioRequest);
            return result;
        }
    }
}
