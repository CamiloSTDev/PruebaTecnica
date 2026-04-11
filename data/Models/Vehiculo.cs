using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaTecnica.data.Models
{
    public class Vehiculo
    {
        public int Id { get; set; }
        public string? Placa { get; set; }
        public required string Modelo { get; set; }
        public int Año { get; set; }
        public int MarcaId { get; set; }
        public required Marca Marca { get; set; }
        public ICollection<Venta> Ventas { get; set; }
    }
}
