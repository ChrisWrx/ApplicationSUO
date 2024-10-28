using SUO.BusinessObjects.ListaEntidades;
using SUO.DataAccessLayer.Repositories.ListaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUO.BusinessActions.ListaEntidades
{
    public class ListaEntidadesAction
    {
        private readonly IListaEntidadesRepository _listaEntidadesRepository;

        public ListaEntidadesAction(IListaEntidadesRepository listaEntidadesRepository)
        {
            _listaEntidadesRepository = listaEntidadesRepository;
        }   
        public IEnumerable<GetListaEntidadesResponse> ListaTodasLasEntidades()
        {
            var list = _listaEntidadesRepository.ListaEntidades();

            return (list.Result);
        }
    }
}
