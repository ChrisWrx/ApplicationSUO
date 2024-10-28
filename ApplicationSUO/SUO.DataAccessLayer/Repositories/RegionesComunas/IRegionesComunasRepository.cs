using SUO.BusinessObjects.Entidad;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SUO.DataAccessLayer.Repositories.RegionesComunas
{
    public interface IRegionesComunasRepository
    {
        Task<IEnumerable<GetRegionesComunasResponse>> ListaComunasRegion(int IDREGION);
        Task<IEnumerable<GetRegionesComunasResponse>> ListaRegiones();
    }
}
