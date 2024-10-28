using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SUO.BusinessObjects.ListaRutNombreEntidad
{
    public class GetListaRutNombreEntidadResponse
    {
        public GetListaRutNombreEntidadResponse(int idEntidad, string nombreEntidad, string rutEntidad)
        {
            IdEntidad = idEntidad;
            NombreEntidad = nombreEntidad;
            RutEntidad = rutEntidad;
            
        }

        [JsonPropertyName("idEntidad")]
        public int IdEntidad { get; set; }

        [JsonPropertyName("nombreEntidad")]
        public string NombreEntidad { get; set; }

        [JsonPropertyName("rutEntidad")]
        public string RutEntidad { get; set; }
    }
}
