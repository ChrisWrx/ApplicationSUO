using SUO.BusinessObjects.ListaImgCarrusel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUO.DataAccessLayer.Repositories.ListaImgCarrusel
{
    public interface IListaImgCarruselRepository
    {
        Task<IEnumerable<GetListaImgCarruselResponse>> ListaImgCarrusel(int ID);
    }
}
