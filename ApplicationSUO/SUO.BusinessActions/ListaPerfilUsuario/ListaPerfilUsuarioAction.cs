using SUO.BusinessObjects.ListaPerfilUsuario;
using SUO.DataAccessLayer.Repositories.ListaPerfilUsuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUO.BusinessActions.ListaPerfilUsuario
{
    public class ListaPerfilUsuarioAction
    {
        private readonly IListaPerfilUsuarioRepository _listaPerfilUsuarioRepository;
        public ListaPerfilUsuarioAction(IListaPerfilUsuarioRepository listaPerfilUsuarioRepository)
        {
            _listaPerfilUsuarioRepository = listaPerfilUsuarioRepository;
        }
        public IEnumerable<GetListaPerfilUsuarioResponse> ListaPerfilDeUsuarios()
        {
            var list = _listaPerfilUsuarioRepository.ListaPerfilUsuario();

            return (list.Result);
        }
    }
}
