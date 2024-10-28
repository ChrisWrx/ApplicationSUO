using SUO.BusinessObjects.FichaPaciente;
using SUO.BusinessObjects.ListaPerfilUsuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUO.DataAccessLayer.Repositories.ListaPerfilUsuario
{
    public interface IListaPerfilUsuarioRepository
    {
        Task<IEnumerable<GetListaPerfilUsuarioResponse>> ListaPerfilUsuario();
    }
}
