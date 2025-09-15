using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoSia2025.BD;
using ProyectoSia2025.BD.Data.Entities;
using ProyectoSia2025.Repository.Repositorios;
using ProyectoSia2025.Shared;
using ProyectoSia2025.Shared.DTOS;

namespace ProyectoSia2025.Server.Controllers
{
    [ApiController]
    [Route("api/ContactoEmpresa")]
    public class ContactoEmpresaController : ControllerBase
    {
        private readonly AppDbContext context;
        private readonly IRepositorio<ContactoEmpresas> repositorio;

        // Constructor que recibe el contexto de la base de datos
        public ContactoEmpresaController (AppDbContext context, IRepositorio<ContactoEmpresas> repositorio)
        {
            this.context = context;
            this.repositorio = repositorio;
        }
        [HttpGet] // Obtiene todos los contactos de empresas
        public async Task<IActionResult> GetContactoEmpresa()
        {
            var contacto = await repositorio.Select();
            if (contacto == null)
            {
                return NotFound("No se encontró el contacto.");
            }
            if (contacto.Count == 0)
            {
                return NoContent(); // Devuelve 204 No Content si no hay empresas
            }

            var contactosDTO = contacto.Select(c => new ContactoEmpresasDto
            {
                EmpresaId = c.EmpresaId,
                Nombre = c.Nombre,
                Apellido = c.Apellido,
                DNI = c.DNI,
                Email = c.Email,
                Telefono = c.Telefono,
                Cargo = c.Cargo,
              
            }).ToList();

            return Ok(contactosDTO);
        }

        
        [HttpPost] // Crea un nuevo contacto de empresa
        public async Task<ActionResult<int>> Post([FromBody]ContactoEmpresasDto dto)
        {
            try
            {
                // Validar que la empresa exista
                bool existeEmpresa = await context.Empresas.AnyAsync(e => e.Id == dto.EmpresaId);
                if (!existeEmpresa)
                    return BadRequest("La empresa indicada no existe.");

                // Validar que no exista un contacto con el mismo DNI
                if (await context.ContactoEmpresas.AnyAsync(c => c.DNI == dto.DNI))
                    return BadRequest("Ya existe un contacto con ese DNI.");

                // Crear el contacto
                var contacto = new ContactoEmpresas
                {
                    EmpresaId = dto.EmpresaId,
                    Nombre = dto.Nombre,
                    Apellido = dto.Apellido,
                    DNI = dto.DNI,
                    Email = dto.Email,
                    Telefono = dto.Telefono,
                    Cargo = dto.Cargo
                };

                await context.ContactoEmpresas.AddAsync(contacto);
                await context.SaveChangesAsync();

                return Ok(contacto.Id);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al crear el contacto: {ex.Message}");
            }
        }

        //[HttpPut("{id:int}")]
        //public async Task<IActionResult> Put(int id, ContactoEmpresas contacto)
        //{
        //    var resultado = await repositorio.Update(id, contacto);
        //    if (!resultado)
        //    {
        //        return BadRequest("El ID del contacto no coincide o el contacto no existe.");
        //    }
        //    return Ok ($"Contacto actualizado correctamente.id del contacto: {id}");
        //}

        //[HttpDelete("{id:int}")]
        //public async Task<ActionResult> Delete(int id)
        //{
        //    var contacto = await context.ContactoEmpresas.FirstOrDefaultAsync(x => x.Id == id);
        //    if (contacto == null)
        //    {
        //        return NotFound($"No se encontró el contacto con el id: {id}.");
        //    }
        //    context.ContactoEmpresas.Remove(contacto);
        //    await context.SaveChangesAsync();
        //    return Ok($"Contacto con id {id} eliminado correctamente.");
        //}

    }
}
