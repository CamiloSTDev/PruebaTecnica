using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaTecnica.data.Models
{
    public class Marca
    {
        public int Id { get; set; }
        public required string Nombre { get; set; }
        public string? Descripcion { get; set; }
        public required ICollection<Vehiculo> Vehiculos { get; set; }
    }
}
