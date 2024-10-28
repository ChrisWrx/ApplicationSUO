using SUO.BusinessObjects.DeletePerfilUsuario;
using SUO.DataAccessLayer.Repositories.DeletePerfilUsuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUO.BusinessActions.DeletePerfilUsuario
{
    public class DeletePerfilUsuarioAction
    {
        private readonly IDeletePerfilUsuarioRepository _deletePerfilUsuarioRepository;
        public DeletePerfilUsuarioAction(IDeletePerfilUsuarioRepository deletePerfilUsuarioRepository)
        {
            _deletePerfilUsuarioRepository = deletePerfilUsuarioRepository;
        }
        public async Task<GetDeletePerfilUsuarioResponse> DeletePerfilUsuario(DeletePerfilUsuarioRequest deletePerfilUsuarioRequest)
        {
            var delete = await _deletePerfilUsuarioRepository.EliminaPerfilUsuario(deletePerfilUsuarioRequest);
            return delete;
        }
    }
}
