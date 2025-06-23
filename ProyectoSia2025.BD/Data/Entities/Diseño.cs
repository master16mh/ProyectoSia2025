using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSia2025.BD.Data.Entities
{
    public class Diseño
    {
        public int Id { get; set; }
        public int ObraId { get; set; }
        public Obra Obra { get; set; }
        public int DiseñadorId { get; set; }
        public Usuario Diseñador { get; set; }
        public string NombreArchivo { get; set; }
        public DateTime FechaSubida { get; set; }
        public string UrlArchivo { get; set; } = string.Empty;
    }
}
