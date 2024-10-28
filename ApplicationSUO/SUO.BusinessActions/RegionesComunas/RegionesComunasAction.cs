using SUO.BusinessObjects.Entidad;
using SUO.DataAccessLayer.Repositories.RegionesComunas;
using System.Collections.Generic;

namespace SUO.BusinessActions.RegionesComunas
{
    public class RegionesComunasAction
    {
        private readonly IRegionesComunasRepository _regionesComunasRepository;

        public RegionesComunasAction(IRegionesComunasRepository regionesComunasRepository)
        {
            _regionesComunasRepository = regionesComunasRepository;
        }

        public IEnumerable<GetRegionesComunasResponse> ListaComunasPorRegion(int IDREGION)
        {
            var regionComuna = _regionesComunasRepository.ListaComunasRegion(IDREGION);
            return regionComuna.Result;
        }

        public IEnumerable<GetRegionesComunasResponse> ListaRegiones() // Método para obtener regiones
        {
            var regiones = _regionesComunasRepository.ListaRegiones();
            return regiones.Result;
        }
    }
}
