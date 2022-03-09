using AutoMapper.Configuration.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AlkemyChallenge.Models.DTOs
{
    public class PersonajeDTO
    {
        public int PersonajeId { get; set; }

        [Required]
        public int Peso { get; set; }
        [Required]

        public string Nombre { get; set; }
        [Required]
        public int Edad { get; set; }
        [Required]
        public string Historia { get; set; }

        public string ImagenBase64 { get; set; }
        
    }
}
