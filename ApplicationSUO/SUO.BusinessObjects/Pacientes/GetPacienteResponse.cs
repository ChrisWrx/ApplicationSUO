using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SUO.BusinessObjects.Paciente
{
    public class GetPacienteResponse
    {

        public GetPacienteResponse(int idAtenciones, string rut, string nombrePaciente, string apellidoPaterno, string apellidoMaterno, string nombreEntidad, string direccion, string estado) 
        {
            IdAtenciones = idAtenciones;
            Rut = rut;
            NombrePaciente = nombrePaciente;
            ApellidoPaterno = apellidoPaterno;
            ApellidoMaterno = apellidoMaterno;
            NombreEntidad = nombreEntidad;
            Direccion = direccion;
            Estado = estado;

        }

        [JsonPropertyName("idAtenciones")]
        public int IdAtenciones { get; set; }

        [JsonPropertyName("rut")]
        public string Rut { get; set; }

        [JsonPropertyName("nombrePaciente")]
        public string NombrePaciente { get; set; }

        [JsonPropertyName("apellidoPaterno")]
        public string ApellidoPaterno { get; set; }

        [JsonPropertyName("apellidoMaterno")]
        public string ApellidoMaterno { get; set; }

        [JsonPropertyName("nombreEntidad")]
        public string NombreEntidad { get; set; }

        [JsonPropertyName("direccion")]
        public string Direccion { get; set; }

        [JsonPropertyName("estado")]
        public string Estado { get; set; }
    }
}
