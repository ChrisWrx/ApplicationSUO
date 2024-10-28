using Microsoft.AspNetCore.Mvc;
using SUO.BusinessActions.ListaImgCarrusel;

namespace ApplicationSUOWebApi.Controllers.ListaImgCarrusel
{
    [ApiController]
    [Route("ApplicationSUOWebApi/")]
    public class ListaImgCarruselController : Controller
    {
        private readonly ListaImgCarruselAction _listaImgCarruselAction;

        public ListaImgCarruselController(ListaImgCarruselAction listaImgCarruselAction)
        {
            _listaImgCarruselAction = listaImgCarruselAction;
        }

        [HttpGet("ListaImagesCarruselById")]
        public IActionResult ListaImgCarrusel(int ID)
        {
            var images = _listaImgCarruselAction.ListaImgCarruselById(ID);

            if (images.Any()) 
            {
                return Ok(images);
            }
            else
            {
                return Ok(new { Code = "8014", Message = "No existe listado de imágenes" });
            }
        }
    }
}
