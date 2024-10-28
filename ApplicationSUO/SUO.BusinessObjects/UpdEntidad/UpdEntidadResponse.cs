using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SUO.BusinessObjects.UpdEntidad
{
    public class UpdEntidadResponse
    {
        public UpdEntidadResponse()
        {
        }

        public UpdEntidadResponse(int filaModificada) 
        {
            FilaModificada = filaModificada;
        } 
        [JsonPropertyName("filaModificada")]
        public int FilaModificada { get; set; }
    }
}
