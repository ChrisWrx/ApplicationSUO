using SUO.BusinessObjects.AddEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUO.BusinessObjects.UpdEntidad
{
    public interface IUpdEntidadRepository
    {
        Task<UpdEntidadResponse> ActualizaEntidad(UpdEntidadRequest updEntidadRequest);
    }
}
