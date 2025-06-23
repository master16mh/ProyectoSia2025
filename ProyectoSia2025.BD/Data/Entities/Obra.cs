using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSia2025.BD.Data.Entities
{
    public class Obra
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public int EmpresaId { get; set; }
        public Empresa Empresa { get; set; }
        public string Estado { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }

        public List<Inspeccion> Inspecciones { get; set; }
        public List<Diseño> Diseños { get; set; }
    }
}
