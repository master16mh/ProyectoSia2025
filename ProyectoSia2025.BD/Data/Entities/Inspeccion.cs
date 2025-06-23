using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSia2025.BD.Data.Entities
{
    public class Inspeccion
    {
        public int Id { get; set; }
        public int ObraId { get; set; }
        public Obra Obra { get; set; }
        public int InspectorId { get; set; }
        public Usuario Inspector { get; set; }
        public DateTime FechaInspeccion { get; set; }
        public string ObservacionesGenerales { get; set; }
        public bool ChecklistUtilizado { get; set; }
        public bool SeGeneraInforme { get; set; }

        public Informe Informe { get; set; } // Informe asociado a la inspección
        public List<InspeccionCheckList> ChecklistItems { get; set; } // Lista de items del checklist
        public List<Seguimiento> Seguimientos { get; set; } // Lista de seguimientos asociados a la inspección
    }
}
