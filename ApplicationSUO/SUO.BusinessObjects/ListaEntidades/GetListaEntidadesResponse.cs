using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SUO.BusinessObjects.ListaEntidades
{
    public class GetListaEntidadesResponse
    {
        public GetListaEntidadesResponse(int idEntidad, string rutEntidad, string nombreEntidad, string direccionEntidad, string comunaEntidad, string regionEntidad, string contactoEntidad, string telefonoEntidad)
        {
            IdEntidad = idEntidad;
            RutEntidad = rutEntidad;
            NombreEntidad = nombreEntidad;
            DireccionEntidad = direccionEntidad;
            ComunaEntidad = comunaEntidad;
            RegionEntidad = regionEntidad;
            ContactoEntidad = contactoEntidad;
            TelefonoEntidad = telefonoEntidad;
        }

        [JsonPropertyName("idEntidad")]
        public int IdEntidad { get; set; }

        [JsonPropertyName("rutEntidad")]
        public string RutEntidad { get; set; }

        [JsonPropertyName("nombreEntidad")]
        public string NombreEntidad { get; set; }

        [JsonPropertyName("direccionEntidad")]
        public string DireccionEntidad { get; set; }

        [JsonPropertyName("comunaEntidad")]
        public string ComunaEntidad { get; set; }

        [JsonPropertyName("regionEntidad")]
        public string RegionEntidad { get; set; }

        [JsonPropertyName("contactoEntidad")]
        public string ContactoEntidad { get; set; }

        [JsonPropertyName("telefonoEntidad")]
        public string TelefonoEntidad { get; set; }
    }
}
