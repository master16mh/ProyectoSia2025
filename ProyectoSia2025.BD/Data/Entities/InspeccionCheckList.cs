using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSia2025.BD.Data.Entities
{
    public class InspeccionCheckList
    {
        public int Id { get; set; }
        public int InspeccionId { get; set; }
        public Inspeccion Inspeccion { get; set; }
        public int ChecklistItemId { get; set; }
        public CheckListItem ChecklistItem { get; set; }
        public string Estado { get; set; } // Ej: Correcto, Incorrecto
        public string Comentario { get; set; }
    }
}
