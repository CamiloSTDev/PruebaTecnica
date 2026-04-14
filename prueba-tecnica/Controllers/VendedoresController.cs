using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.negocio.Services;
using PruebaTecnica.data.Models;

namespace PruebaTecnica.web.Controllers
{
    public class VendedoresController(IVendedorService vendedorService, IVentaService ventaService) : Controller
    {
        private readonly IVendedorService _vendedorService = vendedorService;
        private readonly IVentaService _ventaService = ventaService;

        private async Task CargarVendedoresDisponiblesAsync()
        {
            ViewBag.Vendedores = await _vendedorService.GetAllAsync();
        }

        [HttpGet]
        [ActionName("Editar")]
        public async Task<IActionResult> MostrarFormularioEdicion()
        {
            await CargarVendedoresDisponiblesAsync();
            return View("Editar");
        }

        [HttpPost]
        [ActionName("BuscarParaEditar")]
        public async Task<IActionResult> BuscarVendedorParaEdicion(string cedula)
        {
            try
            {
                var vendedor = await _vendedorService.GetByCedulaAsync(cedula);
                await CargarVendedoresDisponiblesAsync();
                return View("Editar", vendedor);
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                await CargarVendedoresDisponiblesAsync();
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
                return RedirectToAction("Editar");
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                await CargarVendedoresDisponiblesAsync();
                return View("Editar", vendedor);
            }
        }

        [HttpGet]
        [ActionName("ConsultarVentas")]
        public async Task<IActionResult> MostrarConsultaVentas()
        {
            await CargarVendedoresDisponiblesAsync();
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
                await CargarVendedoresDisponiblesAsync();
                return View("ConsultarVentas", vehiculos);
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                await CargarVendedoresDisponiblesAsync();
                return View("ConsultarVentas");
            }
        }
    }
}
