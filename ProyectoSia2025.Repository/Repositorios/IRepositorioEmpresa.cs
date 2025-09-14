using ProyectoSia2025.BD.Data.Entities;
using ProyectoSia2025.Shared.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSia2025.Repository.Repositorios
{
    public interface IRepositorioEmpresa
    {
        public Task<List<EmpresaDTO>> SelectEmpresasConContactos();
    }
}
