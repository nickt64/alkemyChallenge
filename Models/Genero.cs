using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlkemyChallenge.Models
{
    public class Genero
    {
        public int GeneroId { get; set; }
        public string Imagen { get; set; }
        public string Nombre { get; set; }

        public int PeliculaId { get; set; }
        public List<Pelicula> Peliculas { get; set; }
        
    }
}
