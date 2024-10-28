using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text;
using Azure.Core;
using ApplicationSUOWeb.Models.Login;
using System.Net;
using ApplicationSUOWeb;
using ApplicationSUOWeb.Models.ListaImgCarrusel;

public class LoginController : Controller
{
    private readonly HttpClient _httpClient;
    private readonly string _baseUrl;
    private readonly string _imgUrl;

    public LoginController(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _baseUrl = configuration.GetSection("ApiSettings:BaseUrl").Value;    
    }



    [HttpPost]
    public async Task<IActionResult> LoginUser([FromBody] LoginRequest request)
    {
        if (request == null || string.IsNullOrEmpty(request.Usuario) || string.IsNullOrEmpty(request.Password))
        {
            return BadRequest(new { Code = "400", Message = "Usuario o Password no pueden estar vacíos" });
        }

        var apiUrl = $"{_baseUrl}/ApplicationSUOWebApi/LoginUsers?usuario={request.Usuario}&password={request.Password}";
        var response = await _httpClient.GetAsync(apiUrl);

        if (response.IsSuccessStatusCode)
        {
            var result = await response.Content.ReadAsStringAsync();

            var loginResponseList = JsonSerializer.Deserialize<List<LoginResponse>>(result);
            if (loginResponseList != null && loginResponseList.Count > 0)
            {
                var loginResponse = loginResponseList[0];
                TempData["LoginResponse"] = JsonSerializer.Serialize(loginResponse);
                HttpContext.Session.SetString("LoginResponse", JsonSerializer.Serialize(loginResponse));
                return Ok(loginResponse);

            }
            return BadRequest(new { Code = "404", Message = "No se encontró el usuario" });
        }
        else
        {
            var errorResponse = await response.Content.ReadAsStringAsync();
            return Json(new { Code = response.StatusCode.ToString(), Message = errorResponse });
        }
    }

    public IActionResult LoginUsuario()
    {
        if (TempData["LoginResponse"] != null)
        {
            var loginResponseJson = TempData["LoginResponse"].ToString();
            var loginResponse = JsonSerializer.Deserialize<LoginResponse>(loginResponseJson);

            return View(loginResponse);
        }

        return View();
    }
}