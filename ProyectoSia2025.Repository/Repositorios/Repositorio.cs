using Microsoft.EntityFrameworkCore;
using ProyectoSia2025.BD;
using ProyectoSia2025.BD.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;



namespace ProyectoSia2025.Repository.Repositorios
{
    public class Repositorio<E> : IRepositorio<E> where E : class, IEntityBase 
    {
        private readonly AppDbContext context;
        public Repositorio(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> Exist(int id)
        {
            bool exist = await context.Set<E>().AnyAsync(x => x.Id == id);
            return exist;
        }
        public async Task<List<E>> Select()
        {
            //todo lo que es await tiene que ser async
            return await context.Set<E>().ToListAsync();
        }

        public async Task<E?> SelectById(int id)
        {
            return await context.Set<E>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<E?> SelectById(int id, params Expression<Func<E, object>>[] includeProperties)
        {
            IQueryable<E> query = context.Set<E>();

            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return await query.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<int> Insert(E entidad)
        {
            try
            {
                await context.Set<E>().AddAsync(entidad);
                await context.SaveChangesAsync();
                return entidad.Id;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
