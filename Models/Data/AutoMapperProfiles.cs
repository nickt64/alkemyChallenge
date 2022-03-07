using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlkemyChallenge.Models;
using AlkemyChallenge.Models.DTOs;
using AlkemyChallenge.Models.DTOs.PeliculaDTOs;

namespace AlkemyChallenge.Models.Data
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            //-------------------Personajes-----------------------


            CreateMap<Personaje, PersonajeDTO>()
                .ReverseMap();
            CreateMap<PersonajeCreacionDTO, Personaje>();
            CreateMap<Personaje, PersonajeListadoDTO>();


            //----------------Peliculas---------------------------
            CreateMap<Pelicula, PeliculaDTO>()
                .ReverseMap();
            CreateMap<Pelicula, PeliculaListadoDTO>();

        }
    }
}
