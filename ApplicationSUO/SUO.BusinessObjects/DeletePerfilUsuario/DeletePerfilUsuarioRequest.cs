using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SUO.BusinessObjects.DeletePerfilUsuario
{
    public class DeletePerfilUsuarioRequest
    {
        public DeletePerfilUsuarioRequest(int idLogin, string rutUsuario) 
        {             
            IdLogin = idLogin;
            RutUsuario = rutUsuario;
        }       

        [JsonPropertyName("idLogin")]
        public int IdLogin { get; set; }

        [JsonPropertyName("rutUsuario")]
        public string RutUsuario { get; set; }
    }
}
