using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSia2025.BD.Data.Entities
{
    public class Seguimiento
    {
        public int Id { get; set; }
        public int InspeccionId { get; set; }
        public Inspeccion Inspeccion { get; set; }
        public DateTime FechaSeguimiento { get; set; }
        public string Descripcion { get; set; }
        public int RealizadoPorId { get; set; }
        public Usuario RealizadoPor { get; set; }
        public bool Corregido { get; set; }
    }
}
