using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AlkemyChallenge.Models
{
    public class Pelicula
    {
        public int PeliculaId { get; set; }
        public string Imagen { get; set; }

        public string Titulo { get; set; }

        [DataType(DataType.Date)]
        public DateTime FechaCreacion { get; set; }

        [Range(1,5)][Display(Prompt ="1 a 5")]
        public int Calificacion { get; set; }
        public int GeneroId { get; set; }
        public List<PersonajesPeliculas> PersonajesPeliculas     { get; set; }
    }
}
