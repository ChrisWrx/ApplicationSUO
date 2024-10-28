using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SUO.BusinessObjects.ListaImgCarrusel
{
    public class GetListaImgCarruselResponse
    {
        public GetListaImgCarruselResponse(int idEntidad, string imgEntidad1, string imgEntidad2, string imgEntidad3)
        {
            IdEntidad = idEntidad;
            ImgEntidad1 = imgEntidad1;
            ImgEntidad2 = imgEntidad2;
            ImgEntidad3 = imgEntidad3;
        }

        [JsonPropertyName("idEntidad")]
        public int IdEntidad { get; set; }

        [JsonPropertyName("imgEntidad1")]
        public string ImgEntidad1 { get; set; }

        [JsonPropertyName("imgEntidad2")]
        public string ImgEntidad2 { get; set; }

        [JsonPropertyName("imgEntidad3")]
        public string ImgEntidad3 { get; set; }
    }
}
