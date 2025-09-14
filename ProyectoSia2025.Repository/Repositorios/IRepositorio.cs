
using ProyectoSia2025.BD.Data.Entities;
using System.Linq.Expressions;

namespace ProyectoSia2025.Repository.Repositorios
{
    public interface IRepositorio<E> where E : class
    {
        Task<bool> Exist(int id);
        Task<int> Insert(E entidad);
        Task<List<E>> Select();
        Task<E?> SelectById(int id);
    }
}