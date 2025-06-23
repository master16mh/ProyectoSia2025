using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSia2025.BD.Data.Entities
{
    public class HistorialAccion
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public DateTime Fecha { get; set; }
        public string Accion { get; set; } // Ej: "Creó inspección", "Editó informe"
        public string CampoModificado { get; set; } // Ej: "Inspeccion"
        public int EntidadId { get; set; }
        public string Descripcion { get; set; }
    }
}
