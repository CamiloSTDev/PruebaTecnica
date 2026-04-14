using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.negocio.Services;
using PruebaTecnica.data.Models;

namespace PruebaTecnica.web.Controllers
{
    public class MarcasController(IMarcaService marcaService) : Controller
    {
        private readonly IMarcaService _marcaService = marcaService;

        private async Task CargarMarcasDisponiblesAsync()
        {
            ViewBag.Marcas = await _marcaService.GetAllAsync();
        }

        [HttpGet]
        [ActionName("Crear")]
        public async Task<IActionResult> MostrarFormularioCrear()
        {
            await CargarMarcasDisponiblesAsync();
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
                return RedirectToAction("Crear");
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                await CargarMarcasDisponiblesAsync();
                return View("Crear", marca);
            }
        }
    }
}
