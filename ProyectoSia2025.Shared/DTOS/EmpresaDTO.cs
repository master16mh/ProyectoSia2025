using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProyectoSia2025.Shared.DTOS
{
    public class EmpresaDTO
    {
        [JsonPropertyName("id")]
        public int EmpresaId { get; set; }

        public string Nombre { get; set; } 
        public string RazonSocial { get; set; }
        public string CUIT { get; set; }
        public string Direccion { get; set; }
        public List<ContactoDTO> Contactos { get; set; } = new List<ContactoDTO>();
    }
}
