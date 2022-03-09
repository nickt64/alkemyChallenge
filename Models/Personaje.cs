﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AlkemyChallenge.Models
{
    public class Personaje
    {
        public int PersonajeId { get; set; }
        public string Imagen { get; set; }
        public int Peso { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public string Historia { get; set; }

        public List<PersonajesPeliculas> PersonajesPeliculas { get; set; }

    }
}
