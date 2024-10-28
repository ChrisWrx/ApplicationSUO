using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SUO.BusinessObjects.ListaEntidadByIdRut
{
    public class ListaEntidadByIdRutResponse
    {
     public ListaEntidadByIdRutResponse(int idEntidad, string rutEntidad, string nombreEntidad, string direccionEntidad, int idRegion, string regionEntidad, int idComuna, string comunaEntidad, string contactoEntidad, string telefonoEntidad, string imgEntidad1, string imgEntidad2, string imgEntidad3, string fechaModificacion)
        {
            IdEntidad = idEntidad;
            RutEntidad = rutEntidad;
            NombreEntidad = nombreEntidad;
            DireccionEntidad = direccionEntidad;
            IdRegion = idRegion;
            RegionEntidad = regionEntidad;
            IdComuna = idComuna;
            ComunaEntidad = comunaEntidad;
            ContactoEntidad = contactoEntidad;
            TelefonoEntidad = telefonoEntidad;
            ImgEntidad1 = imgEntidad1;
            ImgEntidad2 = imgEntidad2;
            ImgEntidad3 = imgEntidad3;
            FechaModificacion = fechaModificacion;
        }

        [JsonPropertyName("idEntidad")]
        public int IdEntidad { get; set; }

        [JsonPropertyName("rutEntidad")]
        public string RutEntidad { get; set; }

        [JsonPropertyName("nombreEntidad")]
        public string NombreEntidad { get; set; }

        [JsonPropertyName("direccionEntidad")]
        public string DireccionEntidad { get; set; }

        [JsonPropertyName("idRegion")]
        public int IdRegion { get; set; }

        [JsonPropertyName("regionEntidad")]
        public string RegionEntidad { get; set; }

        [JsonPropertyName("idComuna")]
        public int IdComuna { get; set; }

        [JsonPropertyName("comunaEntidad")]
        public string ComunaEntidad { get; set; }

        [JsonPropertyName("contactoEntidad")]
        public string ContactoEntidad { get; set; }

        [JsonPropertyName("telefonoEntidad")]
        public string TelefonoEntidad { get; set; }

        [JsonPropertyName("imgEntidad1")]
        public string ImgEntidad1 { get; set; }

        [JsonPropertyName("imgEntidad2")]
        public string ImgEntidad2 { get; set; }

        [JsonPropertyName("imgEntidad3")]
        public string ImgEntidad3 { get; set; }

        [JsonPropertyName("fechaModificacion")]
        public string FechaModificacion { get; set; }
    }
}
