using SUO.BusinessObjects.ListaPerfilUsuario;
using SUO.BusinessObjects.ListaPerfilUsuarioByIdRut;
using SUO.DataAccessLayer.Repositories.ListaPerfilUsuario;
using SUO.DataAccessLayer.Repositories.ListaPerfilUsuarioByIdRut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUO.BusinessActions.ListaPerfilUsuarioByIdRut
{
    public class ListaPerfilUsuarioByIdRutAction
    {
        private readonly IListaPerfilUsuarioByIdRutRepository _listaPerfilUsuarioByIdRutRepository;
        public ListaPerfilUsuarioByIdRutAction(IListaPerfilUsuarioByIdRutRepository listaPerfilUsuarioByIdRutRepository)
        {
            _listaPerfilUsuarioByIdRutRepository = listaPerfilUsuarioByIdRutRepository;
        }
        public IEnumerable<GetListaPerfilUsuarioByIdRutResponse> ListaPerfilUsuarioByIdRut(int ID, string RUT)
        {
            var list = _listaPerfilUsuarioByIdRutRepository.ListaPerfilUsuarioIdRut(ID, RUT);

            return list.Result;
        }
    }
}
