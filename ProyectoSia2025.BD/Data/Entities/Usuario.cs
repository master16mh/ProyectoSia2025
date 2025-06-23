using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSia2025.BD.Data.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Rol { get; set; } // Ejemplo: "Administrador", "Inspector", "Diseñador" etc.
        public string Password { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaUltimoAcceso { get; set; }
        
        public List<Inspeccion> Inspecciones { get; set; } // Relación con el historial de inspecciones
        public List<Informe> Informes { get; set; } // Relación con los informes generados por el usuario
        public List<Seguimiento> Seguimientos { get; set; } // Relación con los seguimientos realizados por el usuario
        public List<Diseño> DiseñosSubidos { get; set; } // Relación con los planos o diseños subidos por el usuario
        public List<HistorialAccion> Historial { get; set; } // Relación con el historial de acciones del usuario
    }
}
