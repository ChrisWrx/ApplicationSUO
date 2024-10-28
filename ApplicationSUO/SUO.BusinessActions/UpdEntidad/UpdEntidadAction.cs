using SUO.BusinessObjects.UpdEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUO.BusinessActions.UpdEntidad
{
    public class UpdEntidadAction
    {
        private readonly IUpdEntidadRepository _updEntidadRepository;

        public UpdEntidadAction(IUpdEntidadRepository updEntidadRepository)
        {
            _updEntidadRepository = updEntidadRepository;
        }       
        public async Task<UpdEntidadResponse> UpdateEntidad(UpdEntidadRequest updEntidadRequest)
        {
            var upd = await _updEntidadRepository.ActualizaEntidad(updEntidadRequest);
            return upd;
        }
    }
}
