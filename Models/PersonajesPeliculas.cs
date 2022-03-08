using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlkemyChallenge.Models
{
    public class PersonajesPeliculas
    {
        public int PersonajeId  { get; set; }
        public int PeliculaId { get; set; }
        public Personaje Personaje { get; set; }
        public Pelicula Pelicula { get; set; }
    }
}
