using Microsoft.AspNetCore.Mvc;
using Tienda.API.ResponseAPI;
using Tienda.Entidades;
using Tienda.Datos;

namespace Tienda.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController : Controller
    {
        private readonly ProductoDatos productoDatos;

        public ProductosController(ProductoDatos productoDatos)
        {
            this.productoDatos = productoDatos;
        }

        [HttpGet]
        public ActionResult<ResponseAPI<List<Producto>>> ListarProductos()
        {
            try
            {
                List<Producto> productos = productoDatos.ListarProductos();
                ResponseAPI<List<Producto>> respuesta = new ResponseAPI<List<Producto>>();
                respuesta.Success = true;
                respuesta.Message = "Servicio consumido con exito";
                respuesta.Data = productos;
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                var Response = new ResponseAPI<List<Producto>>();
                Response.Success = false;
                Response.Message = "Error al consumir el servicio";
                Response.Errors.Add(ex.Message);
                return BadRequest(Response);
            }
        }
    }
}