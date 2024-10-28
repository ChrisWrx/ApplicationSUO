using SUO.BusinessObjects.Entidad;
using SUO.BusinessObjects.ListaRutNombreEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUO.DataAccessLayer.Repositories.ListaRutNombreEntidad
{
    public interface IListaRutNombreEntidadRepository
    {
        Task<IEnumerable<GetListaRutNombreEntidadResponse>> ListaEntidades();
        Task<IEnumerable<GetListaRutNombreEntidadResponse>> ListaRutPorNombre(int ID);        
    }
}
