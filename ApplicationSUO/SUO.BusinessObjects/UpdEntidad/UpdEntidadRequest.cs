using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SUO.BusinessObjects.UpdEntidad
{
    public class UpdEntidadRequest
    {
        public UpdEntidadRequest(int idEntidad, string rutEntidad, string telefonoEntidad, string contactoEntidad, string imgEntidad1, string imgEntidad2, string imgEntidad3)
        {
            IdEntidad = idEntidad;
            RutEntidad = rutEntidad;           
            TelefonoEntidad = telefonoEntidad;
            ContactoEntidad = contactoEntidad;
            ImgEntidad1 = imgEntidad1;
            ImgEntidad2 = imgEntidad2;
            ImgEntidad3 = imgEntidad3;
        }

        [JsonPropertyName("idEntidad")]
        public int IdEntidad { get; set; }

        [JsonPropertyName("rutEntidad")]
        public string RutEntidad { get; set; }        

        [JsonPropertyName("telefonoEntidad")]
        public string TelefonoEntidad  { get; set; }

        [JsonPropertyName("contactoEntidad")]
        public string ContactoEntidad { get; set; }

        [JsonPropertyName("imgEntidad1")]
        public string ImgEntidad1 { get; set; }

        [JsonPropertyName("imgEntidad2")]
        public string ImgEntidad2 { get; set; }

        [JsonPropertyName("imgEntidad3")]
        public string ImgEntidad3 { get; set; }
    }
}
