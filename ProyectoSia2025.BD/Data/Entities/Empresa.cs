using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSia2025.BD.Data.Entities
{
    public class Empresa
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo Nombre es obligatorio.")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El campo CUIT es obligatorio.")]
        public string CUIT { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public List<Obra> Obras { get; set; } 
    }
}
