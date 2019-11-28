using System;
using Microsoft.EntityFrameworkCore;

namespace Pruebas.Modelos
{
    public class CursosContext : DbContext
    {
        public DbSet<Autor> Autores { get; set; }

        public CursosContext(DbContextOptions<CursosContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            try
            {
                modelBuilder.ApplyConfiguration(new AutorConfig());
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }

        }
    }
}
