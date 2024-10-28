using SUO.BusinessObjects.ListaImgCarrusel;
using SUO.DataAccessLayer.Repositories.ListaImgCarrusel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUO.BusinessActions.ListaImgCarrusel
{
    public class ListaImgCarruselAction
    {
        private readonly IListaImgCarruselRepository _listaImgCarruselRepository;

        public ListaImgCarruselAction(IListaImgCarruselRepository listaImgCarruselRepository)
        {
            _listaImgCarruselRepository = listaImgCarruselRepository;
        }   
        public IEnumerable<GetListaImgCarruselResponse> ListaImgCarruselById(int ID)
        {
            var imgCarrusel = _listaImgCarruselRepository.ListaImgCarrusel(ID);

            return (imgCarrusel.Result);
        }
    }
}
