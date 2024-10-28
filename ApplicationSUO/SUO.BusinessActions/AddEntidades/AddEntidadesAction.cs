using SUO.BusinessObjects.AddEntidades;
using SUO.DataAccessLayer.Repositories.AddEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUO.BusinessActions.AddEntidades
{
    public class AddEntidadesAction
    {
        private readonly IAddEntidadesRepository _addEntidadesRepository;

        public AddEntidadesAction(IAddEntidadesRepository addEntidadesRepository)
        {
            _addEntidadesRepository = addEntidadesRepository;
        }   
        public async Task<GetAddEntidadesResponse> CreaNuevaEntidad(AddEntidadesRequest addEntidadesRequest)
        {
            var result = await _addEntidadesRepository.CreaEntidad(addEntidadesRequest);
            return result;
        }
    }
}
