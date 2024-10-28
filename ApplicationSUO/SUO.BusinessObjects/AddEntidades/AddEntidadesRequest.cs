using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SUO.BusinessObjects.AddEntidades
{
    public class AddEntidadesRequest
    {
        public AddEntidadesRequest(string rutEntidad, string nombreEntidad, string direccionEntidad, int idRegion, int idComuna, string telefonoEntidad, string contactoEntidad, string imgEntidad1, string imgEntidad2, string imgEntidad3)
        {
            RutEntidad = rutEntidad;
            NombreEntidad = nombreEntidad;
            DireccionEntidad = direccionEntidad;
            IdRegion = idRegion;
            IdComuna = idComuna;
            TelefonoEntidad = telefonoEntidad;
            ContactoEntidad = contactoEntidad;
            ImgEntidad1 = imgEntidad1;
            ImgEntidad2 = imgEntidad2;
            ImgEntidad3 = imgEntidad3;            
        }

        [JsonPropertyName("rutEntidad")]
        public string RutEntidad { get; set; }

        [JsonPropertyName("nombreEntidad")]
        public string NombreEntidad { get; set; }

        [JsonPropertyName("direccionEntidad")]
        public string DireccionEntidad { get; set; }

        [JsonPropertyName("idRegion")]
        public int IdRegion { get; set; }

        [JsonPropertyName("idComuna")]
        public int IdComuna { get; set; }

        [JsonPropertyName("telefonoEntidad")]
        public string TelefonoEntidad { get; set; }

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
