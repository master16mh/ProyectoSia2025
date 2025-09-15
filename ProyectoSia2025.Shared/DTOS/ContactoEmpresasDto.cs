using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSia2025.Shared.DTOS
{
    public class ContactoEmpresasDto
    {
        public string Nombre { get; set; } 
        public string Apellido { get; set; } 
        public string DNI { get; set; } 
        public string Email { get; set; } 
        public string Telefono { get; set; } 
        public string Cargo { get; set; }  
        public int EmpresaId { get; set; }
    }
}
