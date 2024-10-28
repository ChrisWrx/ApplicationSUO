using SUO.BusinessObjects.EstadoPerfil;
using SUO.BusinessObjects.TipoPerfil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUO.DataAccessLayer.Repositories.EstadoPerfil
{
    public interface IEstadoPerfilRepository
    {
        Task<IEnumerable<GetEstadoPerfilResponse>> ListaEstadoPerfil();
    }
}
