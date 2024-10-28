using SUO.BusinessObjects.ListaEntidadByIdRut;
using SUO.BusinessObjects.ListaPerfilUsuarioByIdRut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUO.DataAccessLayer.Repositories.ListaEntidadByIdRut
{
    public interface IListaEntidadByIdRutRepository
    {
        Task<IEnumerable<ListaEntidadByIdRutResponse>> ListaEntidadIdRut(int ID, string RUT);
    }
}
