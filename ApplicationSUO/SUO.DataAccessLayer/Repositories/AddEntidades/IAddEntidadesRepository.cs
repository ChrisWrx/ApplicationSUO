using SUO.BusinessObjects.AddEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUO.DataAccessLayer.Repositories.AddEntidades
{
    public interface IAddEntidadesRepository
    {
        Task<GetAddEntidadesResponse> CreaEntidad(AddEntidadesRequest addEntidadRequest);
    }
}
