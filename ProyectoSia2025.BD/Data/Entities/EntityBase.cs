using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSia2025.BD.Data.Entities
{
    public class EntityBase : IEntityBase
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El estado del registro es obligatorio.")]
        public EnumEstadoRegistro Estado { get; set; } = EnumEstadoRegistro.EnGrabacion;
        public string Observacion { get; set; } = string.Empty;
    }
}
