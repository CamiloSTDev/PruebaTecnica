using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaTecnica.data.Models
{
    public class Venta
    {
        public int Id { get; set; }
        public int VehiculoId { get; set; }
        public required Vehiculo Vehiculo { get; set; }
        public int VendedorId { get; set; }
        public required Vendedor Vendedor { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Precio { get; set; }
    }
}
