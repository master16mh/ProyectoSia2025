using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSia2025.BD.Data.Entities
{
    public class Informe
    {
        public int Id { get; set; }
        public int InspeccionId { get; set; }
        public Inspeccion Inspeccion { get; set; }
        public string Resumen { get; set; }
        public bool TieneIrregularidades { get; set; }
        public int GeneradoPorId { get; set; }
        public Usuario GeneradoPor { get; set; }
        public DateTime FechaGeneracion { get; set; }
    }
}
