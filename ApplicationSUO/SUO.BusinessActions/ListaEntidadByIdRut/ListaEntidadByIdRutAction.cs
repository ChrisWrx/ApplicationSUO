using SUO.BusinessObjects.ListaEntidadByIdRut;
using SUO.BusinessObjects.ListaPerfilUsuarioByIdRut;
using SUO.DataAccessLayer.Repositories.ListaEntidadByIdRut;
using SUO.DataAccessLayer.Repositories.ListaPerfilUsuarioByIdRut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUO.BusinessActions.ListaEntidadByIdRut
{
    public class ListaEntidadByIdRutAction
    {
        private readonly IListaEntidadByIdRutRepository _listaEntidadByIdRutRepository;
        public ListaEntidadByIdRutAction(IListaEntidadByIdRutRepository listaEntidadByIdRutRepository)
        {
            _listaEntidadByIdRutRepository = listaEntidadByIdRutRepository;
        }
        public IEnumerable<ListaEntidadByIdRutResponse> ListaEntidadById(int ID, string RUT)
        {
            var list = _listaEntidadByIdRutRepository.ListaEntidadIdRut(ID, RUT);

            return list.Result;
        }
    }
}
