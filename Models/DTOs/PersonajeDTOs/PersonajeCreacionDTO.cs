﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AlkemyChallenge.Models.DTOs
{
    public class PersonajeCreacionDTO
    {
        public int Imagen { get; set; }
        [Required]
        public int Peso { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public int Edad { get; set; }
        [Required]
        public string Historia { get; set; }
    }
}
