using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSia2025.BD.Data.Entities
{
    [Index(nameof(CUIT), Name = "Empresa_CUIT", IsUnique = true)] // Índice único en el campo CUIT
    public class Empresas : EntityBase
    {
        [Required(ErrorMessage = "El campo Nombre es obligatorio.")]
        public string Nombre { get; set; } // Nombre de la empresa

        [Required(ErrorMessage = "El campo Razón Social es obligatorio.")]
        public string RazonSocial { get; set; } // Razón social de la empresa

        [Required(ErrorMessage = "El campo CUIT es obligatorio.")]
        public string CUIT { get; set; } // CUIT de la empresa

        [Required(ErrorMessage = "El campo Dirección es obligatorio.")]
        public string Direccion { get; set; } // Dirección de la empresa
        public List<ContactoEmpresas> Contactos { get; set; } = new List<ContactoEmpresas>(); // Navegación a contactos
    }
}
