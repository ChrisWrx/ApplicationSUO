using SUO.BusinessObjects.DeletePerfilUsuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUO.DataAccessLayer.Repositories.DeletePerfilUsuario
{
    public interface IDeletePerfilUsuarioRepository
    {
        Task<GetDeletePerfilUsuarioResponse> EliminaPerfilUsuario(DeletePerfilUsuarioRequest deleteUsuario);
    }
}
