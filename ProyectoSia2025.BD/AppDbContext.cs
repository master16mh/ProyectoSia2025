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
       
        public DbSet<Usuario> usuarios { get; set; }
        public DbSet<Inspeccion> Inspecciones { get; set; }
        public DbSet<Seguimiento> Seguimientos { get; set; }
        public DbSet<Informe> Informes { get; set; }
        public DbSet<InspeccionCheckList> InspeccionCheckLists { get; set; }
        public DbSet<CheckListItem> CheckLists { get; set; }
        public DbSet<Obra> Obras { get; set; }
        public DbSet<Diseño> Diseños { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<HistorialAccion> HistorialAcciones { get; set; }
        public Inspeccion Prueba = new Inspeccion();
        
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Informe 1:1 con Inspección
            modelBuilder.Entity<Informe>()
                .HasOne(i => i.Inspeccion)
                .WithOne(ins => ins.Informe)
                .HasForeignKey<Informe>(i => i.InspeccionId);

            // Informe generado por un Usuario
            modelBuilder.Entity<Informe>()
                .HasOne(i => i.GeneradoPor)
                .WithMany(u => u.Informes)
                .HasForeignKey(i => i.GeneradoPorId)
                .OnDelete(DeleteBehavior.Restrict);

            // Inspección realizada por un Usuario (Inspector)
            modelBuilder.Entity<Inspeccion>()
                .HasOne(i => i.Inspector)
                .WithMany(u => u.Inspecciones)
                .HasForeignKey(i => i.InspectorId)
                .OnDelete(DeleteBehavior.Restrict);

            // Seguimiento realizado por un Usuario
            modelBuilder.Entity<Seguimiento>()
                .HasOne(s => s.RealizadoPor)
                .WithMany(u => u.Seguimientos)
                .HasForeignKey(s => s.RealizadoPorId)
                .OnDelete(DeleteBehavior.Restrict);

            // Diseño subido por un Usuario
            modelBuilder.Entity<Diseño>()
                .HasOne(d => d.Diseñador)
                .WithMany(u => u.DiseñosSubidos)
                .HasForeignKey(d => d.DiseñadorId)
                .OnDelete(DeleteBehavior.Restrict);

            // Historial generado por un Usuario
            modelBuilder.Entity<HistorialAccion>()
                .HasOne(h => h.Usuario)
                .WithMany(u => u.Historial)
                .HasForeignKey(h => h.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación muchos a uno entre InspeccionCheckList e Inspección
            modelBuilder.Entity<InspeccionCheckList>()
                .HasOne(ic => ic.Inspeccion)
                .WithMany(i => i.ChecklistItems)
                .HasForeignKey(ic => ic.InspeccionId);

            // Relación muchos-a-uno entre InspeccionCheckList y ChecklistItem
            modelBuilder.Entity<InspeccionCheckList>()
                .HasOne(ic => ic.ChecklistItem)
                .WithMany()
                .HasForeignKey(ic => ic.ChecklistItemId);
        }
    }
}
