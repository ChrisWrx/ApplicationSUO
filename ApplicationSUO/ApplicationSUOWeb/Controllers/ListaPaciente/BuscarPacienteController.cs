using ApplicationSUOWeb.Models.FichaPaciente;
using ApplicationSUOWeb.Models.GeneraPDF;
using ApplicationSUOWeb.Models.Login;
using ApplicationSUOWeb.Models.Pacientes;
using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Printing;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using PaperKind = DinkToPdf.PaperKind;

namespace ApplicationSUOWeb.Controllers.ListaPaciente
{
    public class BuscarPacienteController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly ApiSettings _apiSettings;
        private readonly IConverter _converter;

        public BuscarPacienteController(IConverter converter, HttpClient httpClient, ApiSettings apiSettings)
        {
            _httpClient = httpClient;
            _apiSettings = apiSettings;
            _converter = converter;
        }

        public async Task<IActionResult> Index()
        {
            // Intenta acceder a la sesión
            string loginResponseJson = HttpContext.Session.GetString("LoginResponse");

            if (!string.IsNullOrEmpty(loginResponseJson))
            {
                var loginResponse = JsonSerializer.Deserialize<LoginResponse>(loginResponseJson);
                ViewBag.LoginResponse = loginResponse;
            }

            return View();
        }


        [HttpGet]
        public async Task<IActionResult> BuscarPaciente(string RUT)
        {
            var response = await _httpClient.GetAsync($"{_apiSettings.BaseUrl}/ApplicationSUOWebApi/BuscaPaciente?RUT={RUT}");

            if (response.IsSuccessStatusCode)
            {
                var pacientes = await response.Content.ReadAsAsync<IEnumerable<PacienteResponse>>();
                return Json(pacientes);
            }
            else
            {
                return Json(new { Code = "8014", Message = "No existe lista de la empresa solicitada para mostrar" });
            }
        }

        [HttpGet]
        public async Task<IActionResult> FichaPacienteByIdRut(int id, string rut)
        {
            var response = await _httpClient.GetAsync($"{_apiSettings.BaseUrl}/ApplicationSUOWebApi/FichaPacienteByIdRut?ID={id}&RUT={rut}");

            if (response.IsSuccessStatusCode)
            {
                var fichaPacientes = await response.Content.ReadAsAsync<List<FichaPacienteResponse>>();

                var fichaPaciente = fichaPacientes.FirstOrDefault();

                if (fichaPaciente != null)
                {
                    return Json(fichaPaciente);
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
     

     }
}
