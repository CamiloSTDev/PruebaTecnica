using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.negocio.Services;
using PruebaTecnica.data.Models;

namespace PruebaTecnica.web.Controllers
{
    public class VendedoresController(IVendedorService vendedorService, IVentaService ventaService) : Controller
    {
        private readonly IVendedorService _vendedorService = vendedorService;
        private readonly IVentaService _ventaService = ventaService;

        [HttpGet]
        [ActionName("Editar")]
        public IActionResult MostrarFormularioEdicion()
        {
            return View("Editar");
        }

        [HttpPost]
        [ActionName("BuscarParaEditar")]
        public async Task<IActionResult> BuscarVendedorParaEdicion(string cedula)
        {
            try
            {
                var vendedor = await _vendedorService.GetByCedulaAsync(cedula);
                return View("Editar", vendedor);
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return View("Editar");
            }
        }

        [HttpPost]
        [ActionName("Actualizar")]
        public async Task<IActionResult> ActualizarVendedor(Vendedor vendedor)
        {
            try
            {
                await _vendedorService.UpdateAsync(vendedor);
                TempData["Exito"] = "Vendedor actualizado correctamente";
                return RedirectToAction(nameof(MostrarFormularioEdicion));
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return View("Editar", vendedor);
            }
        }

        [HttpGet]
        [ActionName("ConsultarVentas")]
        public IActionResult MostrarConsultaVentas()
        {
            return View("ConsultarVentas");
        }

        [HttpPost]
        [ActionName("ConsultarVentas")]
        public async Task<IActionResult> ConsultarVentasPorCedula(string cedula)
        {
            try
            {
                var vehiculos = await _ventaService.GetVehiculosPorVendedorAsync(cedula);
                ViewBag.Cedula = cedula;
                return View("ConsultarVentas", vehiculos);
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return View("ConsultarVentas");
            }
        }
    }
}
