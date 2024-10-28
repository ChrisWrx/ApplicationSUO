using SUO.BusinessObjects.ListaPerfilUsuario;
using SUO.BusinessObjects.ListaPerfilUsuarioByIdRut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUO.DataAccessLayer.Repositories.ListaPerfilUsuarioByIdRut
{
    public interface IListaPerfilUsuarioByIdRutRepository
    {
        Task<IEnumerable<GetListaPerfilUsuarioByIdRutResponse>> ListaPerfilUsuarioIdRut(int ID, string RUT);
    }
}
