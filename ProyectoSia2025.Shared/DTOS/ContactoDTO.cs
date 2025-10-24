using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSia2025.Shared.DTOS
{
    public class ContactoDTO
    {
        public int EmpresaId { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El apellido es obligatorio")]
        public string Apellido { get; set; }
        [Required(ErrorMessage = "El DNI es obligatorio")]
        public string DNI { get; set; }
        [Required(ErrorMessage = "El email es obligatorio")]
        public string Email { get; set; }
        [Required(ErrorMessage = "El teléfono es obligatorio")]
        public string Telefono { get; set; }
        [Required(ErrorMessage = "El cargo es obligatorio")]
        public string Cargo { get; set; }
    }
}
