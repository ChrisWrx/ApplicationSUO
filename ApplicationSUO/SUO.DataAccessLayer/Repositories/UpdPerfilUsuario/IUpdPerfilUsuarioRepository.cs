using SUO.BusinessObjects.UpdPerfilUsuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUO.DataAccessLayer.Repositories.UpdPerfilUsuario
{
    public interface IUpdPerfilUsuarioRepository
    {
        Task<UpdPerfilUsuarioResponse> UpdatePerfilUsuario(UpdPerfilUsuarioRequest updUsersSystemRequest);
    }
}
