using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;
using ApplicationSUOWeb.Models.TipoPerfil;
using ApplicationSUOWeb.Models.EstadoPerfil;
using ApplicationSUOWeb.Models.ListaRutNombreEntidad;
using System.Text;
using ApplicationSUOWeb.Models.AddPerfilUsuario;
using ApplicationSUOWeb.Models.ListaPerfilUsuario;
using ApplicationSUOWeb.Models.ListaPerfilUsuarioByIdRutResponse;
using ApplicationSUOWeb.Models.UpdPerfilUsuario;
using ApplicationSUOWeb.Models.DeletePerfilUsuario;

namespace ApplicationSUOWeb.Controllers.PerfilUsuario
{
    public class PerfilUsuarioController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly ApiSettings _apiSettings;

        public PerfilUsuarioController(HttpClient httpClient, ApiSettings apiSettings) 
        {
            _httpClient = httpClient;
            _apiSettings = apiSettings;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerListaTipoPerfil()
        {            
            string apiUrl = $"{_apiSettings.BaseUrl}/ApplicationSUOWebApi/ListaTipoPerfil";

            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var perfiles = JsonConvert.DeserializeObject<List<TipoPerfilResponse>>(jsonResponse);
                return Json(perfiles);
            }
            else
            {
                return Json(new { Code = "8014", Message = "Error al obtener la lista de perfiles." });
            }
        }
        [HttpGet]
        public async Task<IActionResult> ObtenerListaEstadoPerfil()
        {
            string apiUrl = $"{_apiSettings.BaseUrl}/ApplicationSUOWebApi/ListaEstadoPerfil";

            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var estados = JsonConvert.DeserializeObject<List<EstadoPerfilResponse>>(jsonResponse);
                return Json(estados);
            }
            else
            {
                return Json(new { Code = "8014", Message = "Error al obtener la lista de estados." });
            }
        }

        [HttpGet]
        public async Task<IActionResult> ListaEntidades()
        {            
            string apiUrl = $"{_apiSettings.BaseUrl}/ApplicationSUOWebApi/ListaEntidades";

            try
            {
                var response = await _httpClient.GetAsync(apiUrl);
                response.EnsureSuccessStatusCode();
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var entidades = JsonConvert.DeserializeObject<List<ListaRutNombreEntidadResponse>>(jsonResponse);

                if (entidades == null || entidades.Count == 0)
                {
                    return Json(new { Code = "8014", Message = "No se encontraron entidades." });
                }

                return Json(entidades);
            }
            catch (HttpRequestException e)
            {
                return Json(new { Code = "8015", Message = "Error de conexión: " + e.Message });
            }
            catch (Exception ex)
            {
                return Json(new { Code = "5000", Message = "Error inesperado: " + ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> ListaRutPorNombre(int IdEntidad)
        {
            string apiUrl = $"{_apiSettings.BaseUrl}/ApplicationSUOWebApi/ListaRutPorEntidades?ID={IdEntidad}";

            try
            {
                var response = await _httpClient.GetAsync(apiUrl);
                response.EnsureSuccessStatusCode();
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var rutNombre = JsonConvert.DeserializeObject<List<ListaRutNombreEntidadResponse>>(jsonResponse);

                if (rutNombre == null || rutNombre.Count == 0)
                {
                    return Json(new { Code = "8014", Message = "No se encontraron rut para la entidad seleccionada." });
                }

                return Json(rutNombre);
            }
            catch (HttpRequestException e)
            {
                return Json(new { Code = "8015", Message = "Error de conexión: " + e.Message });
            }
            catch (Exception ex)
            {
                return Json(new { Code = "5000", Message = "Error inesperado: " + ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> CrearPerfilUsuario([FromBody] Models.AddPerfilUsuario.AddPerfilUsuarioRequest addPerfilUsuarioRequest)
        {
            if (addPerfilUsuarioRequest == null || !ModelState.IsValid)
            {
                return BadRequest(new { Code = "400", Message = "Los datos enviados no son válidos o están vacíos" });
            }

            string jsonRequest = JsonConvert.SerializeObject(addPerfilUsuarioRequest);
            StringContent content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

            string apiUrl = $"{_apiSettings.BaseUrl}/ApplicationSUOWebApi/AddPerfilUsuario";

            try
            {
                
                HttpResponseMessage response = await _httpClient.PostAsync(apiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var perfilUsuarioCreado = JsonConvert.DeserializeObject<AddPerfilUsuarioResponse>(jsonResponse);
            
                    return Ok(new { Code = "1", Message = "Usuario agregado exitosamente", Data = perfilUsuarioCreado });
                }
                else
                {
                    
                    string errorMessage = await response.Content.ReadAsStringAsync();
                    return BadRequest(new { Code = "500", Message = "Error al agregar el perfil de usuario", Details = errorMessage });
                }
            }
            catch (HttpRequestException e)
            {
                return BadRequest(new { Code = "500", Message = $"Error de conexión: {e.Message}" });
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUsuario([FromBody] Models.UpdPerfilUsuario.UpdPerfilUsuarioRequest updPerfilUsuarioRequest)
        {
            if (updPerfilUsuarioRequest == null || !ModelState.IsValid)
            {
                return BadRequest(new { Code = "400", Message = "Los datos enviados no son válidos o están vacíos" });
            }

            string jsonRequest = JsonConvert.SerializeObject(updPerfilUsuarioRequest);
            StringContent content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

            string apiUrl = $"{_apiSettings.BaseUrl}/ApplicationSUOWebApi/UpdatePerfilUsuario";

            try
            {
                
                HttpResponseMessage response = await _httpClient.PutAsync(apiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var perfilUsuarioActualizado = JsonConvert.DeserializeObject<UpdPerfilUsuarioResponse>(jsonResponse);

                    return Ok(new { Code = "1", Message = "Usuario actualizado exitosamente", Data = perfilUsuarioActualizado });
                }
                else
                {
                    string errorMessage = await response.Content.ReadAsStringAsync();
                    return BadRequest(new { Code = "500", Message = "Error al actualizar el perfil de usuario", Details = errorMessage });
                }
            }
            catch (HttpRequestException e)
            {
                return BadRequest(new { Code = "500", Message = $"Error de conexión: {e.Message}" });
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUsuario([FromBody] Models.DeletePerfilUsuario.DeletePerfilUsuarioRequest deletePerfilUsuarioRequest)
        {
            if (deletePerfilUsuarioRequest == null || !ModelState.IsValid)
            {
                return BadRequest(new { Code = "400", Message = "Los datos enviados no son válidos o están vacíos" });
            }

            string jsonRequest = JsonConvert.SerializeObject(deletePerfilUsuarioRequest);
            StringContent content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

            string apiUrl = $"{_apiSettings.BaseUrl}/ApplicationSUOWebApi/DeletePerfilUsuario";

            try
            {
               
                var request = new HttpRequestMessage(HttpMethod.Delete, apiUrl)
                {
                    Content = content
                };

                HttpResponseMessage response = await _httpClient.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var perfilUsuarioEliminado = JsonConvert.DeserializeObject<DeletePerfilUsuarioResponse>(jsonResponse);

                    return Ok(new { Code = "1", Message = "Usuario eliminado exitosamente", Data = perfilUsuarioEliminado });
                }
                else
                {
                    string errorMessage = await response.Content.ReadAsStringAsync();
                    return BadRequest(new { Code = "500", Message = "Error al eliminar el perfil de usuario", Details = errorMessage });
                }
            }
            catch (HttpRequestException e)
            {
                return BadRequest(new { Code = "500", Message = $"Error de conexión: {e.Message}" });
            }
        }
      

        [HttpGet]
        public async Task<IActionResult> ObtienePerfilUsuarioIdRut(int ID, string RUT)
        {
            var response = await _httpClient.GetAsync($"{_apiSettings.BaseUrl}/ApplicationSUOWebApi/ListaPerfilUsuarioByIdRut?ID={ID}&RUT={RUT}");

            if (response.IsSuccessStatusCode)
            {
                var listUser = await response.Content.ReadAsAsync<List<ListaPerfilUsuarioByIdRutResponse>>();

                var listUsers = listUser.FirstOrDefault();

                if (listUser != null)
                {
                    return Json(listUser);
                }
                else
                {
                    return Json(new { Code = "8014", Message = "No se encontró la ficha del paciente." });
                }
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Error en la llamada a la API: {errorContent}");
                return Json(new { Code = "8014", Message = "No se encontró la ficha del paciente." });
            }
        }

        [HttpGet]
        public async Task<IActionResult> ObtineneListadoUsuarios()
        {
            var response = await _httpClient.GetAsync($"{_apiSettings.BaseUrl}/ApplicationSUOWebApi/ListaPerfilesUsuarios");

            if (response.IsSuccessStatusCode)
            {
                var listUsuarios = await response.Content.ReadAsAsync<IEnumerable<ListaPerfilUsuarioResponse>>();
                return Json(listUsuarios);
            }
            else
            {
                return Json(new { Code = "8014", Message = "No existe lista de usuarios" });
            }
        }

    }
}
