using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaTecnica.data.Models
{
    public class Vendedor
    {
        public int Id { get; set; }
        public required string Cedula { get; set; }
        public required string Nombre { get; set; }
        public required string Apellido { get; set; }
        public string? Email { get; set; }
        public ICollection<Venta> Ventas { get; set; }
    }
}
