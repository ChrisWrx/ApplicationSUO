using SUO.BusinessObjects.EstadoPerfil;
using SUO.DataAccessLayer.Repositories.EstadoPerfil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUO.BusinessActions.EstadoPerfil
{
    public class EstadoPerfilAction
    {
        private readonly IEstadoPerfilRepository _estadoPerfilRepository;
        public EstadoPerfilAction(IEstadoPerfilRepository estadoPerfilRepository)
        {
            _estadoPerfilRepository = estadoPerfilRepository;
        }
        public IEnumerable<GetEstadoPerfilResponse> GetListaEstadoPerfil()
        {
            var estado = _estadoPerfilRepository.ListaEstadoPerfil();

            return(estado.Result);
        }
    }
}
