using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.negocio.Services;

namespace PruebaTecnica.web.Controllers
{
    public class VentasController(IVentaService ventaService) : Controller
    {
        private readonly IVentaService _ventaService = ventaService;

        [HttpGet]
        [ActionName("Eliminar")]
        public async Task<IActionResult> ListarVentas()
        {
            try
            {
                var ventas = await _ventaService.GetAllWithDetailsAsync();
                return View("Eliminar", ventas);
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return View("Eliminar");
            }
        }

        [HttpPost]
        [ActionName("Eliminar")]
        public async Task<IActionResult> EliminarVenta(int id)
        {
            try
            {
                await _ventaService.DeleteAsync(id);
                TempData["Exito"] = "Venta eliminada correctamente";
                return RedirectToAction(nameof(ListarVentas));
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction(nameof(ListarVentas));
            }
        }
    }
}
