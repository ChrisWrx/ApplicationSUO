using SUO.BusinessObjects.Paciente;
using SUO.BusinessObjects.TipoPerfil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUO.DataAccessLayer.Repositories.TipoPerfil
{
    public interface ITipoPerfilRepository
    {
        Task<IEnumerable<GetTipoPerfilResponse>> ListaTipoPerfil();
    }
}
