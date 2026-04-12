using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.negocio.Services;
using PruebaTecnica.data.Models;

namespace PruebaTecnica.web.Controllers
{
    public class MarcasController(IMarcaService marcaService) : Controller
    {
        private readonly IMarcaService _marcaService = marcaService;

        [HttpGet]
        [ActionName("Crear")]
        public IActionResult MostrarFormularioCrear()
        {
            return View("Crear");
        }

        [HttpPost]
        [ActionName("Crear")]
        public async Task<IActionResult> CrearMarca(Marca marca)
        {
            try
            {
                await _marcaService.AddAsync(marca);
                TempData["Exito"] = "Marca creada correctamente";
                return RedirectToAction(nameof(MostrarFormularioCrear));
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return View("Crear", marca);
            }
        }
    }
}
