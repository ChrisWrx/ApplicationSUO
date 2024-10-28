using SUO.BusinessObjects.ListaRutNombreEntidad;
using SUO.DataAccessLayer.Repositories.ListaRutNombreEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUO.BusinessActions.ListaRutNombreEntidad
{
    public class ListaRutNombreEntidadAction
    {
        private readonly IListaRutNombreEntidadRepository _listaRutNombreEntidadRepository;
        public ListaRutNombreEntidadAction(IListaRutNombreEntidadRepository listaRutNombreEntidadRepository)
        {
            _listaRutNombreEntidadRepository = listaRutNombreEntidadRepository;
        }
        public IEnumerable<GetListaRutNombreEntidadResponse> GetListaEntidades()
        {
            var entidades = _listaRutNombreEntidadRepository.ListaEntidades();
            return entidades.Result;
        }
        public IEnumerable<GetListaRutNombreEntidadResponse> GetListaRutPorNombre(int ID)
        {
            var rutPorNombre = _listaRutNombreEntidadRepository.ListaRutPorNombre(ID);
            return rutPorNombre.Result;
        }
    }
}
