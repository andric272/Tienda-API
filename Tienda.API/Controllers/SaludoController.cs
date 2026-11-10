using Microsoft.AspNetCore.Mvc;
using Tienda.API.ResponseAPI;

namespace Tienda.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SaludoController:Controller
    {
        [HttpGet]
        public ActionResult<ResponseAPI<string>> Saludar()
        {
            var Response = new ResponseAPI<string>
            {
                Success = true,
                Message = "Servicio consumido con exito",
                Data = "Hola, bienvenido a la API de Tienda!"
            };
            return Ok(Response);
        }
    }
}
