using Microsoft.EntityFrameworkCore;
using ProyectoSia2025.BD;
using ProyectoSia2025.BD.Data.Entities;
using ProyectoSia2025.Shared.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSia2025.Repository.Repositorios
{
    public class RepositorioEmpresa : Repositorio<Empresas>, IRepositorioEmpresa
    {
        private readonly AppDbContext context;
        public RepositorioEmpresa(AppDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<List<EmpresaDTO>> SelectEmpresasConContactos()
        {
            return await context.Empresas
                                 .Include(e => e.Contactos)// Incluir los contactos relacionados
                                 .Select(e => new EmpresaDTO()
                                 {
                                     EmpresaId = e.Id,
                                     Nombre = e.Nombre,
                                     CUIT = e.CUIT,
                                     RazonSocial = e.RazonSocial,
                                     Direccion = e.Direccion,
                                     Contactos = e.Contactos.Select(c => new ContactoDTO
                                     {
                                         EmpresaId = c.EmpresaId,
                                         Nombre = c.Nombre,
                                         Apellido = c.Apellido,
                                         DNI = c.DNI,
                                         Email = c.Email,
                                         Telefono = c.Telefono,
                                         Cargo = c.Cargo
                                     }).ToList()
                                 }).ToListAsync();
        }
    }
}
