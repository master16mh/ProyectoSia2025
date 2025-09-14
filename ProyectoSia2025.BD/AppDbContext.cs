using Microsoft.EntityFrameworkCore;
using ProyectoSia2025.BD.Data.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSia2025.BD
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Empresas> Empresas { get; set; }
        public DbSet<ContactoEmpresas> ContactoEmpresas { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}
