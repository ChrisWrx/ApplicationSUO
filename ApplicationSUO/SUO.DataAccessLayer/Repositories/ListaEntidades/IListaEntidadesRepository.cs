using SUO.BusinessObjects.ListaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUO.DataAccessLayer.Repositories.ListaEntidades
{
    public interface IListaEntidadesRepository
    {
        Task<IEnumerable<GetListaEntidadesResponse>> ListaEntidades();
    }
}
