using SUO.BusinessObjects.TipoPerfil;
using SUO.DataAccessLayer.Repositories.TipoPerfil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUO.BusinessActions.TipoPerfil
{
    public class TipoPerfilAction
    {
        private readonly ITipoPerfilRepository _tipoPerfilRepository;

        public TipoPerfilAction(ITipoPerfilRepository tipoPerfilRepository)
        {
            _tipoPerfilRepository = tipoPerfilRepository;
        }

        public IEnumerable<GetTipoPerfilResponse> GetListaTipoPerfil()
        {
            var tipoPerfil = _tipoPerfilRepository.ListaTipoPerfil();

            return (tipoPerfil.Result);
        }
    }
}
