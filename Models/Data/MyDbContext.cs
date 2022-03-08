using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlkemyChallenge.Models.Data
{
    public class MyDbContext: DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options)
            :base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<PersonajesPeliculas>().HasKey(x => new { x.PersonajeId, x.PeliculaId });

            base.OnModelCreating(modelbuilder);
        }
        public DbSet<Personaje> Personajes { get; set; }

        public DbSet<Genero> Generos { get; set; }
        public DbSet<Pelicula> Peliculas { get; set; }
        public DbSet<PersonajesPeliculas> PersonajesPeliculas { get; set; }

    }
}
