using SUO.BusinessObjects.AddPerfilUsuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUO.DataAccessLayer.Repositories.AddPerfilUsuario
{
    public interface IAddPerfilUsuarioRepository
    {
        Task<GetPerfilUsuarioResponse> CreaPerfilUsuario(AddPerfilUsuarioRequest addPerfilUsuarioRequest);
    }
}
