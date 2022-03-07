using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AlkemyChallenge.Models.DTOs.PeliculaDTOs
{
    public class PeliculaDTO
    {
        public int PeliculaId { get; set; }
        public string Imagen { get; set; }

        public string Titulo { get; set; }

        [DataType(DataType.Date)]
        public DateTime FechaCreacion { get; set; }

        public int Calificacion { get; set; }
    }
}
