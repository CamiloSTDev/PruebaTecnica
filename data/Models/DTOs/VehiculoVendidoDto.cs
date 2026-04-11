
namespace PruebaTecnica.data.Models.DTOs
{
    public class VehiculoVendidoDto
    {
        public string? Placa { get; set; }
        public required string Modelo { get; set; }
        public int Año { get; set; }
        public required string Marca { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Precio { get; set; }
    }
}
