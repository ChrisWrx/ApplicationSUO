//using Microsoft.AspNetCore.Mvc;
//using SUO.DataAccessLayer.Repositories.LoginUsers;
//using SUO.BusinessActions.LoginUsers;
//using System.Net;

//namespace ApplicationSUOWebApi.Controllers
//{
//    [ApiController]
//    [Route("ApplicationSUOWebApi/")]
//    public class LoginUsersController : Controller
//    {
//        private readonly LoginUserAction _loginUsersRepository;

//        public LoginUsersController(LoginUserAction loginUsersRepository)
//        {
//            _loginUsersRepository = loginUsersRepository;
//        }

//        [HttpGet("LoginUsers")]
//        public IActionResult LoginUsersByRutPass(string usuario, string password)
//        {
//            var userLogin = _loginUsersRepository.LoginUsersByRutPass(usuario, password);           

//            if (userLogin.Any())
//            {
//                return Ok(userLogin);
//            }
//            else
//            {
//                return Unauthorized(new { Code = "401", Message = "Usuario y/o Password son incorrectos" });
//            }
//        }
//    }
//}

using Microsoft.AspNetCore.Mvc;
using SUO.DataAccessLayer.Repositories.LoginUsers;
using SUO.BusinessActions.LoginUsers;
using SUO.BusinessActions.ListaImgCarrusel;
using System.Linq;

namespace ApplicationSUOWebApi.Controllers
{
    [ApiController]
    [Route("ApplicationSUOWebApi/")]
    public class LoginUsersController : Controller
    {
        private readonly LoginUserAction _loginUsersRepository;
        private readonly ListaImgCarruselAction _listaImgCarruselAction;

        public LoginUsersController(LoginUserAction loginUsersRepository, ListaImgCarruselAction listaImgCarruselAction)
        {
            _loginUsersRepository = loginUsersRepository;
            _listaImgCarruselAction = listaImgCarruselAction;
        }

        [HttpGet("LoginUsers")]
        public IActionResult LoginUsersByRutPass(string usuario, string password)
        {
            var userLogin = _loginUsersRepository.LoginUsersByRutPass(usuario, password);

            if (userLogin.Any())
            {
                return Ok(userLogin);
            }
            else
            {
                return Unauthorized(new { Code = "401", Message = "Usuario y/o Password son incorrectos" });
            }
        }
    }
}
