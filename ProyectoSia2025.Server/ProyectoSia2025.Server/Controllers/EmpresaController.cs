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
    [Route("api/Empresas")]
    public class EmpresaController : ControllerBase
    {
        private readonly AppDbContext context;
        private readonly IRepositorio<Empresas> repositorio;
        private readonly IRepositorioEmpresa repositorioEmpresa;

        // Constructor que recibe el contexto de la base de datos
        public EmpresaController(AppDbContext context, IRepositorio<Empresas> repositorio, IRepositorioEmpresa repositorioEmpresa)
        {
            this.context = context;
            this.repositorio = repositorio;
            this.repositorioEmpresa = repositorioEmpresa;
        }
        [HttpGet] //Api/Empresas
        public async Task<IActionResult> GetEmpresas()
        {
            var empresas = await repositorioEmpresa.SelectEmpresasConContactos();
            if (empresas == null)
            {
                return NotFound("No se encontraron empresas.");
            }
            if (empresas.Count == 0)
            {
                return NoContent(); // Devuelve 204 No Content si no hay empresas
            }
            return Ok(empresas);
        }

        [HttpGet("{id:int}")] // Obtiene una empresa por su ID
        public async Task<ActionResult<Empresas>> GetById(int id)
        {
            var empresas = await repositorioEmpresa.SelectEmpresasConContactos();
            var empresa = empresas.FirstOrDefault(e => e.EmpresaId == id);
            if (empresa == null)
            {
                return NotFound($"No se encontró el registro con el id {id}.");
            }
            return Ok(empresa);
        }

        [HttpGet("by-cuit/{cuit}")]
        public async Task<ActionResult<Empresas>> GetByCUIT(string cuit)
        {
            var empresa = await context.Empresas.FirstOrDefaultAsync(x => x.CUIT == cuit);
            if (empresa == null)
            {
                return NotFound($"No se encontró la empresa con el CUIT {cuit}.");
            }
            return Ok(empresa);
        }
        [HttpPost] // Crea una nueva empresa
        public async Task<ActionResult<int>> Post([FromBody] EmpresasCrearDTO dto)
        {
            try
            {
                var empresa = new Empresas
                {
                    Nombre = dto.Nombre,
                    RazonSocial = dto.RazonSocial,
                    CUIT = dto.CUIT,
                    Direccion = dto.Direccion

                    // NO incluimos Contactos
                };

                await context.Empresas.AddAsync(empresa);
                await context.SaveChangesAsync();

                return Ok(empresa.Id);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al crear la empresa: {ex.InnerException?.Message ?? ex.Message}");
            }
        }
    }

    //    [HttpPut("{id:int}")]
    //    public async Task<IActionResult> Put(int id, Empresas empresa)
    //    {
    //        var resultado = await repositorio.Update(id, empresa);
    //        if (!resultado)
    //        {
    //            return BadRequest("El ID de la empresa no coincide o la empresa no existe.");
    //        }
    //        return Ok ($"Empresa actualizada correctamente.id de la empresa: {id}");
    //    }

    //    [HttpDelete("{id:int}")]
    //    public async Task<ActionResult> Delete(int id)
    //    {
    //        var empresa = await context.Empresas.FirstOrDefaultAsync(x => x.Id == id);
    //        if (empresa == null)
    //        {
    //            return NotFound($"No se encontró la empresa con el id: {id}.");
    //        }
    //        context.Empresas.Remove(empresa);
    //        await context.SaveChangesAsync();
    //        return Ok($"Empresa con id {id} eliminada correctamente.");
    //    }
    //}
}
